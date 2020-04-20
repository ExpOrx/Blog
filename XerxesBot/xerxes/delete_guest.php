<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';
$del_id = filter_input(INPUT_POST, 'del_id');
if ($del_id && $_SERVER['REQUEST_METHOD'] == 'POST')
{

    if($_SESSION['admin_type']!='super'){
        $_SESSION['failure'] = "You don't have permission to perform this action";
        header('location: settings.php');
        exit;
    }
    $guest_id = $del_id;
    $db->where('id', $guest_id);
    $status = $db->delete('guests');

    if ($status)
    {
        $_SESSION['info'] = "Guest has been deleted successfully!";
        header('location: settings.php');
        exit;
    }
    else
    {
        $_SESSION['failure'] = "Unable to delete guest";
        header('location: settings.php');
        exit;
    }

}