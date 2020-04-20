<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';
$del_id = filter_input(INPUT_POST, 'del_id');
$del_ids = filter_input(INPUT_POST, 'del_ids');
if ($del_id && $_SERVER['REQUEST_METHOD'] == 'POST')
{
    if($_SESSION['admin_type']!='super'){
        $_SESSION['failure'] = "You don't have permission to perform this action";
        header('location: clients.php');
        exit;
    }
    $client_id = $del_id;
    $db->where('id', $client_id);
    $status = $db->delete('locked_clients');

    if ($status)
    {
        $_SESSION['info'] = "Locked client deleted successfully!";
        header('location: locked_clients.php');
        exit;
    }
    else
    {
        $_SESSION['failure'] = "Unable to delete locked client";
        header('location: locked_clients.php');
        exit;
    }
}
if ($del_ids && $_SERVER['REQUEST_METHOD'] == 'POST') {
    $status = false;
    if ($_SESSION['admin_type'] != 'super') {
        $_SESSION['failure'] = "You don't have permission to perform this action";
        header('location: locked_clients.php');
        exit;
    }
    foreach (explode(":", $del_ids) as $del_id) {
        $db->where('imei', $del_id);
        $status = $db->delete('locked_clients');
    }

    if ($status) {
        $_SESSION['info'] = "Locked client deleted successfully!";
        header('location: locked_clients.php');
        exit;
    } else {
        $_SESSION['failure'] = "Unable to delete Locked clients";
        header('location: locked_clients.php');
        exit;
    }
}