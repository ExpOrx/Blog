<?php
session_start();
require_once 'includes/auth_validate.php';
require_once './config/config.php';

// Serve deletion if POST method and del_id is set.

//Get data from query string
$search_string = filter_input(INPUT_GET, 'search_string');


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
$select = array('id', 'imei', 'command', 'command_name');

// If user searches
if ($search_string)
{
    $db->where('imei', '%' . $search_string . '%', 'like');
    $db->orwhere('command_name', '%' . $search_string . '%', 'like');
}


if ($order_by)
{
    $db->orderBy($filter_col, $order_by);
}

$db->pageLimit = $pagelimit;
$commands = $db->arraybuilder()->paginate("commands", $page, $select);
$total_pages = $db->totalPages;

// get columns for order filter
foreach ($commands as $value) {
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
            <h1 class="page-header">Commands</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-success" onclick="setNewCommand()" style="margin-right: 8px;"><span class="glyphicon glyphicon-plus"></span> Add new command </button>
                <button class="btn btn-danger delete_btn" onclick="deleteIds('delete_command.php')" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span> Delete selected commands </button>
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <form class="form form-inline" action="">
            <label for="input_search">Search IMEI or command by name</label>
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
            <input type="submit" value="Go" class="btn btn-primary">

        </form>
    </div>
    <!--   Filter section end-->

    <hr>


    <table class="table table-striped table-bordered table-condensed">
        <thead>
        <tr>
            <th class="header"><input type="checkbox" class="form-check-input" id="chk" onclick="chkAll()"></th>
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
                <td><input type="checkbox" class="form-check-input" id="chk_imei" value="<?php echo $row['id'] ?>"></td>
                <td><?php echo $row['id'] ?></td>
                <td><?php echo $row['imei'] ?></td>
                <td><?php echo $row['command_name'] ?></td>
                <td><?php echo base64_decode($row['command']) ?></td>
                <td>
                    <a href=""  class="btn btn-danger delete_btn" data-toggle="modal" data-target="#confirm-delete-<?php echo $row['id'] ?>" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>
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
                echo '<li' . $li_class . '><a href="commands.php' . $http_query . '&page=' . $i . '">' . $i . '</a></li>';
            }
            echo '</ul></div>';
        }
        ?>
    </div>

</div>
<!--Main container end-->


<?php include_once './includes/footer.php'; ?>

