<?php
session_start();
require_once './config/config.php';
require_once 'includes/auth_validate.php';

//Only super admin is allowed to access this page
if ($_SESSION['admin_type'] !== 'super') {
    // show permission denied message
    echo 'Permission Denied';
    exit();
}
//Get data from query string
$search_string = filter_input(INPUT_GET, 'search_string');
$del_id = filter_input(INPUT_GET, 'del_id');

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


// Delete a user using user_id
if ($del_id && $_SESSION['admin_type'] == 'super') {
    $admin_user_id = filter_input(INPUT_GET, 'del_id');
    $db->where('id', $admin_user_id);
    $stat = $db->delete('admin_accounts');
    if ($stat) {
        $del_stat = TRUE;
    }
}
// select the columns
$select = array('id', 'user_name', 'admin_type');

// If user searches 
if ($search_string) {
    $db->where('user_name', '%' . $search_string . '%', 'like');
}


if ($order_by) {

    $db->orderBy($filter_col, $order_by);
}

//$result = $db->get('customers',NULL,$select);

$db->pageLimit = $pagelimit;
$result = $db->arraybuilder()->paginate("admin_accounts", $page, $select);
$total_pages = $db->totalPages;


// get columns for order filter
foreach ($result as $value) {
    foreach ($value as $col_name => $col_value) {
        $filter_options[$col_name] = $col_name;
    }
    //execute only once
    break;
}


require_once 'includes/header.php';
?>

<div id="page-wrapper">
<div class="row">
     <div class="col-lg-6">
            <h1 class="page-header">Admin users</h1>
        </div>
        <div class="col-lg-6" style="">
            <div class="page-action-links text-right">
            <a href="add_admin.php"> <button class="btn btn-success">Add new</button></a>
            </div>
        </div>
</div>
 <?php include('./includes/flash_messages.php') ?>

    <?php
    if (isset($del_stat) && $del_stat == 1) {
        echo '<div class="alert alert-info">Successfully deleted</div>';
    }
    ?>
    
    <!--    Begin filter section-->
    <div class="well text-center filter-form">
        <form class="form form-inline" action="">
            <label for="input_search">Search</label>
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
                <th class="header">#</th>
                <th>Name</th>
                <th>Admin type</th>
                <th>Actions</th>

            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($result as $row) {
                echo '<tr>';
                echo '<td>' . $row['id'] . '</td>';
                echo '<td>' . $row['user_name'] . '</td>';
                echo '<td>' . $row['admin_type'] . '</td>';
                echo '<td><a href="edit_admin.php?admin_user_id=' . $row['id'] . '&operation=edit" class="btn btn-primary" style="margin-right: 8px;"><span class="glyphicon glyphicon-edit"></span>';
                if ($_SESSION['admin_type'] == 'super') {
                    echo '<a href="admin_users.php?del_id=' . $row['id'] . '" class="btn btn-danger delete_btn" style="margin-right: 8px;"><span class="glyphicon glyphicon-trash"></span></td>';
                }
                echo '</tr>';
            }
            ?>      
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
                echo '<li' . $li_class . '><a href="index.php' . $http_query . '&page=' . $i . '">' . $i . '</a></li>';
            }
            echo '</ul></div>';
        }
        ?>
    </div>
</div>
<!--Main container end-->
<script type="text/javascript">
    $(document).ready(function () {
        $('.delete_btn').click(function () {
            var r = confirm("Are you sure?")
            if (r == true) {
                return true;
            } else {
                return false;
            }
        });
    });
</script> 


<?php include_once 'includes/footer.php'; ?>