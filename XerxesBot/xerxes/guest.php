<?php
require_once './config/config.php';

# get the secret and try to find it in database
$secret = preg_quote($_GET['i']);

$db->where('secret', $secret);
$guest = $db->getOne('guests');

if ($guest) {
    # guest has been found. Creating db request for get clients
    $select = array('imei', 'version', 'country', 'lastConnect', 'firstConnect');
    $db->where('version_apk', '%'.$guest['filter'].'%', 'like');
    $clients = $db->get('clients');

    $client_count = $db->count;
    ?>
    Total clients: <?php echo $client_count ?>
    </br>

    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th></th>
            <th>IMEI</th>
            <th>Android</th>
            <th>Country</th>
            <th>LastConnect</th>
            <th>FirstConnect</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($clients as $row) { ?>
            <tr>
                <td><i class="fa fa-android" aria-hidden="true" <?php if ((time() - $row['lastConnect'])<300) {echo 'style="color:#5bb85c;"';}?>></i></td>
                <td><?php echo $row['imei'] ?></td>
                <td><?php echo $row['version'] ?> </td>
                <td><?php echo $row['country'] ?></td>
                <td><?php echo date("Y-m-d H:i",$row['lastConnect']) ?></td>
                <td><?php echo date("Y-m-d H:i",$row['firstConnect']) ?></td>
            </tr>
        <?php } ?>
        </tbody>
    </table>


<?php
}

?>