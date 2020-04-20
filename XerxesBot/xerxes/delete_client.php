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
    $status = $db->delete('clients');

    if ($status)
    {
        $_SESSION['info'] = "client deleted successfully!";
        header('location: clients.php');
        exit;
    }
    else
    {
        $_SESSION['failure'] = "Unable to delete client";
        header('location: clients.php');
        exit;
    }
}
if ($del_ids && $_SERVER['REQUEST_METHOD'] == 'POST') {
    $status = false;
    if ($_SESSION['admin_type'] != 'super') {
        $_SESSION['failure'] = "You don't have permission to perform this action";
        header('location: clients.php');
        exit;
    }
    foreach (explode(":", $del_ids) as $del_id) {
        $db->where('imei', $del_id);
        $status = $db->delete('clients');
    }

    if ($status) {
        $_SESSION['info'] = "Client deleted successfully!";
        header('location: clients.php');
        exit;
    } else {
        $_SESSION['failure'] = "Unable to delete Clients";
        header('location: clients.php');
        exit;
    }
}