<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="je_Default2" %>

<%@ Register Src="~/Controls/SiteTitle.ascx" TagPrefix="uc1" TagName="SiteTitle" %>
<%@ Register Src="~/Controls/PageTitle.ascx" TagPrefix="uc1" TagName="PageTitle" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>
        <uc1:PageTitle runat="server" ID="PageTitle" />
    </title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="../AdminLTE/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../AdminLTE/dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
    folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../AdminLTE/dist/css/skins/_all-skins.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="../AdminLTE/plugins/iCheck/flat/blue.css">
    <!-- Morris chart -->
    <link rel="stylesheet" href="../AdminLTE/plugins/morris/morris.css">
    <!-- jvectormap -->
    <link rel="stylesheet" href="../AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <!-- Date Picker -->
    <link rel="stylesheet" href="../AdminLTE/plugins/datepicker/datepicker3.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../AdminLTE/plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="../AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .gridCss {
            width: 100%;
            margin-left: 20px;
        }

            .gridCss td {
                padding: 5px !important;
            }

        .jumbotron {
            padding: 10px;
            padding-top: 10px !important;
            padding-bottom: 10px !important;
        }

            .jumbotron .row .col-md-12 h3 {
                margin-top: 0px !important;
            }

        #gvClientUser_lbSelect_0, #gvMenuUser_lbSelect_0, #gvMenuProposal_lbSelect_0, #gvMenuProject_lbSelect_0 {
            font-weight: bold !important;
            color: #3c8dbc !important;
            text-decoration: underline;
        }

        .chat .item > .message {
            margin-left: 0px !important;
            margin-top: 0px !important;
        }

        .slimScrollDiv, #chat-box {
            height: auto !important;
            max-height: 200px !important;
            overflow: scroll;
        }

        span.form-control {
            border-color: white !important;
        }

        .treeview-menu div {
            max-height: 400px;
            overflow: scroll;
        }

            .treeview-menu div::-webkit-scrollbar {
                width: 12px;
            }

            .treeview-menu div::-webkit-scrollbar-track {
                -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0);
                border-radius: 10px;
            }

            .treeview-menu div::-webkit-scrollbar-thumb {
                border-radius: 10px;
                -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,1);
            }

        .treeview-menu input {
            margin-top: 10px;
        }

        .selected {
            border: 1px solid white;
            padding: 5px 5px 5px 2px;
        }
    </style>
</head>
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper">
        <form id="form1" runat="server">
            <script src="../js/jsUpdateProgress.js" type="text/javascript"></script>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress1">
                <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
                    <ProgressTemplate>
                        <div style="position: relative; top: 30%; text-align: center; width: 150px; height: 150px;">
                            <img src="../images/loading.gif" style="vertical-align: middle"
                                alt="Processing" width="100px" height="100px" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </asp:Panel>
            <script type="text/javascript" language="javascript">
                var ModalProgress = '<%=ModalProgress.ClientID %>';         
            </script>
            <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
                BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <header class="main-header">
                        <!-- Logo -->
                        <a href="#" class="logo">
                            <!-- mini logo for sidebar mini 50x50 pixels -->
                            <span class="logo-mini"><b>J</b>E</span>
                            <!-- logo for regular state and mobile devices -->
                            <span class="logo-lg">
                                <uc1:SiteTitle runat="server" ID="SiteTitle" />
                            </span>
                        </a>
                        <!-- Header Navbar: style can be found in header.less -->
                        <nav class="navbar navbar-static-top">
                            <!-- Sidebar toggle button-->
                            <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                                <span class="sr-only">Toggle navigation</span>
                            </a>

                            <div class="navbar-custom-menu">
                                <ul class="nav navbar-nav">
                                    <!-- Messages: style can be found in dropdown.less-->
                                    <li class="dropdown messages-menu" style="display: none;">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                            <i class="fa fa-envelope-o"></i>
                                            <span class="label label-success">4</span>
                                        </a>
                                        <ul class="dropdown-menu">
                                            <li class="header">You have 4 messages</li>
                                            <li>
                                                <!-- inner menu: contains the actual data -->
                                                <ul class="menu">
                                                    <li>
                                                        <!-- start message -->
                                                        <a href="#">
                                                            <div class="pull-left">
                                                                <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
                                                            </div>
                                                            <h4>Support Team
                        <small><i class="fa fa-clock-o"></i>5 mins</small>
                                                            </h4>
                                                            <p>Why not buy a new awesome theme?</p>
                                                        </a>
                                                    </li>
                                                    <!-- end message -->
                                                    <li>
                                                        <a href="#">
                                                            <div class="pull-left">
                                                                <img src="../AdminLTE/dist/img/user3-128x128.jpg" class="img-circle" alt="User Image">
                                                            </div>
                                                            <h4>AdminLTE Design Team
                        <small><i class="fa fa-clock-o"></i>2 hours</small>
                                                            </h4>
                                                            <p>Why not buy a new awesome theme?</p>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <div class="pull-left">
                                                                <img src="../AdminLTE/dist/img/user4-128x128.jpg" class="img-circle" alt="User Image">
                                                            </div>
                                                            <h4>Developers
                        <small><i class="fa fa-clock-o"></i>Today</small>
                                                            </h4>
                                                            <p>Why not buy a new awesome theme?</p>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <div class="pull-left">
                                                                <img src="../AdminLTE/dist/img/user3-128x128.jpg" class="img-circle" alt="User Image">
                                                            </div>
                                                            <h4>Sales Department
                        <small><i class="fa fa-clock-o"></i>Yesterday</small>
                                                            </h4>
                                                            <p>Why not buy a new awesome theme?</p>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <div class="pull-left">
                                                                <img src="../AdminLTE/dist/img/user4-128x128.jpg" class="img-circle" alt="User Image">
                                                            </div>
                                                            <h4>Reviewers
                        <small><i class="fa fa-clock-o"></i>2 days</small>
                                                            </h4>
                                                            <p>Why not buy a new awesome theme?</p>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </li>
                                            <li class="footer"><a href="#">See All Messages</a></li>
                                        </ul>
                                    </li>
                                    <!-- Notifications: style can be found in dropdown.less -->
                                    <li class="dropdown notifications-menu" style="display: none;">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                            <i class="fa fa-bell-o"></i>
                                            <span class="label label-warning">10</span>
                                        </a>
                                        <ul class="dropdown-menu">
                                            <li class="header">You have 10 notifications</li>
                                            <li>
                                                <!-- inner menu: contains the actual data -->
                                                <ul class="menu">
                                                    <li>
                                                        <a href="#">
                                                            <i class="fa fa-users text-aqua"></i>5 new members joined today
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="fa fa-warning text-yellow"></i>Very long description here that may not fit into the
                      page and may cause design problems
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="fa fa-users text-red"></i>5 new members joined
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="fa fa-shopping-cart text-green"></i>25 sales made
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#">
                                                            <i class="fa fa-user text-red"></i>You changed your username
                                                        </a>
                                                    </li>
                                                </ul>
                                            </li>
                                            <li class="footer"><a href="#">View all</a></li>
                                        </ul>
                                    </li>
                                    <!-- Tasks: style can be found in dropdown.less -->
                                    <li class="dropdown tasks-menu" style="display: none;">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                            <i class="fa fa-flag-o"></i>
                                            <span class="label label-danger">9</span>
                                        </a>
                                        <ul class="dropdown-menu">
                                            <li class="header">You have 9 tasks</li>
                                            <li>
                                                <!-- inner menu: contains the actual data -->
                                                <ul class="menu">
                                                    <li>
                                                        <!-- Task item -->
                                                        <a href="#">
                                                            <h3>Design some buttons
                        <small class="pull-right">20%</small>
                                                            </h3>
                                                            <div class="progress xs">
                                                                <div class="progress-bar progress-bar-aqua" style="width: 20%" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                                    <span class="sr-only">20% Complete</span>
                                                                </div>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <!-- end task item -->
                                                    <li>
                                                        <!-- Task item -->
                                                        <a href="#">
                                                            <h3>Create a nice theme
                        <small class="pull-right">40%</small>
                                                            </h3>
                                                            <div class="progress xs">
                                                                <div class="progress-bar progress-bar-green" style="width: 40%" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                                    <span class="sr-only">40% Complete</span>
                                                                </div>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <!-- end task item -->
                                                    <li>
                                                        <!-- Task item -->
                                                        <a href="#">
                                                            <h3>Some task I need to do
                        <small class="pull-right">60%</small>
                                                            </h3>
                                                            <div class="progress xs">
                                                                <div class="progress-bar progress-bar-red" style="width: 60%" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                                    <span class="sr-only">60% Complete</span>
                                                                </div>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <!-- end task item -->
                                                    <li>
                                                        <!-- Task item -->
                                                        <a href="#">
                                                            <h3>Make beautiful transitions
                        <small class="pull-right">80%</small>
                                                            </h3>
                                                            <div class="progress xs">
                                                                <div class="progress-bar progress-bar-yellow" style="width: 80%" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                                                                    <span class="sr-only">80% Complete</span>
                                                                </div>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <!-- end task item -->
                                                </ul>
                                            </li>
                                            <li class="footer">
                                                <a href="#">View all tasks</a>
                                            </li>
                                        </ul>
                                    </li>
                                    <!-- User Account: style can be found in dropdown.less -->
                                    <li class="dropdown user user-menu">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                            <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="user-image" alt="User Image">
                                            <span class="hidden-xs">
                                                <asp:Label ID="lblLoginUserName" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hfLoggedInEmployeeID" runat="server" />
                                            </span>
                                        </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<ul class="dropdown-menu">
                                            <!-- User image -->
                                            <li class="user-header">
                                                <img src="../AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">

                                                <p>
                                                    <asp:Label ID="lblLoginUserName1" runat="server" Text=""></asp:Label>
                                                    <%--<small>Designation</small>--%>
                                                </p>
                                            </li>
                                            <!-- Menu Body -->
                                            <li class="user-body" style="display: none;">
                                                <div class="row">
                                                    <div class="col-xs-4 text-center">
                                                        <a href="#">Followers</a>
                                                    </div>
                                                    <div class="col-xs-4 text-center">
                                                        <a href="#">Sales</a>
                                                    </div>
                                                    <div class="col-xs-4 text-center">
                                                        <a href="#">Friends</a>
                                                    </div>
                                                </div>
                                                <!-- /.row -->
                                            </li>
                                            <!-- Menu Footer-->
                                            <li class="user-footer">
                                                <div class="pull-left">
                                                    <a href="#" class="btn btn-default btn-flat">Profile</a>
                                                </div>
                                                <div class="pull-right">
                                                    <a href="../Default.aspx" class="btn btn-default btn-flat">Sign out</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </li>
                                    <!-- Control Sidebar Toggle Button -->
                                    <li style="display: none;">
                                        <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                                    </li>
                                </ul>
                            </div>
                        </nav>
                    </header>
                    <!-- Left side column. contains the logo and sidebar -->
                    <aside class="main-sidebar">
                        <!-- sidebar: style can be found in sidebar.less -->
                        <section class="sidebar">
                            <ul class="sidebar-menu">
                                <li><a href="Default.aspx"><i class="fa fa-circle-o text-red"></i><span>Dashboard</span></a></li>
                                <li><a href="Admin_Admin_DropDownList_Control.aspx"><i class="fa fa-circle-o text-red"></i><span>Dropdownlist Field Title</span></a></li>
                                <li><a href="Admin_Admin_DropDownList_Control_Value.aspx"><i class="fa fa-circle-o text-yellow"></i><span>Dropdownlist Data</span></a></li>
                            </ul>

                        </section>
                        <!-- /.sidebar -->
                    </aside>

                    <!-- Content Wrapper. Contains page content -->
                    <div class="content-wrapper">
                        <!-- Content Header (Page header) -->
                        <section class="content-header">
                            <h1>Profile
                            </h1>
                            <%--<ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Dashboard</li>
      </ol>--%>
                        </section>

                        <!-- Main content -->
                        <section class="content">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Add / Edit Information
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    
                                                        <tr class='form-group'>
                                                            <td class='control-label'>First Name
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtFirst_Name' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Middle Name
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtMiddle_Name' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Last Name
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtLast_Name' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Gender
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtGender' runat='server' class='form-control'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Address Line 1
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtAddress_Line_1' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Address Line 2
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtAddress_Line_2' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>City
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtCity' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>State
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtState' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Zip
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtZip' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Spouse Name
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtSpouse_Name' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Cell Phone
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtCell_Phone' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Work Phone
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtWork_Phone' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Email aaddress 1
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtEmail_aaddress_1' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Email aaddress 2
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtEmail_aaddress_2' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Current Affiliation
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtCurrent_Affiliation' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Yealy Income Range
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtYealy_Income_Range' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Previous Employment 1
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtPrevious_Employment_1' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Previous Employment 2
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtPrevious_Employment_2' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Major Subject 1
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtMajor_Subject_1' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Major Subject 2
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtMajor_Subject_2' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Major Subject 3
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtMajor_Subject_3' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Publication Link
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtPublication_Link' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Expertise Area
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtExpertise_Area' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Linkedin Profile
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtLinkedin_Profile' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Facebook Profile
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtFacebook_Profile' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class='form-group'>
                                                            <td class='control-label'>Job Seeker
                                                            </td>
                                                            <td class='col-lg-10'>
                                                                <asp:TextBox ID='txtJob_Seeker' runat='server' class='form-control'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    
                                                </div>
                                                <div class='col-lg-6'>
                                                    
                                                        <div class="form-group">
                                                            <label for="cc-assignd" class="control-label mb-1">Profile
                                                            </label>
                                                                <asp:DropDownList ID='ddlProfile_ID' runat='server' class='form-control  chzn-select'>
                                                                </asp:DropDownList>
                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-assignd" class="control-label mb-1">Educational Institution 1
                                                            </label>
                                                                <asp:DropDownList ID='ddlEducational_Institution_1_ID' runat='server' class='form-control  chzn-select'>
                                                                </asp:DropDownList>
                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-assignd" class="control-label mb-1">Educational Institution 2
                                                            </label>
                                                                <asp:DropDownList ID='ddlEducational_Institution_2_ID' runat='server' class='form-control  chzn-select'>
                                                                </asp:DropDownList>
                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-assignd" class="control-label mb-1">Educational Institution 3
                                                            </label>
                                                                <asp:DropDownList ID='ddlEducational_Institution_3_ID' runat='server' class='form-control  chzn-select'>
                                                                </asp:DropDownList>
                                                            
                                                        </div>
                                                    

                                                </div>
                                            </div>
                                            <center style='margin-top: 30px;'>
<asp:Button ID='btnSave' runat='server' Text='Save' class='btn btn-default' 
                                            onclick='btnSave_Click'  />
                                        <asp:Button ID='btnReset' runat='server' Text='Reset' class='btn btn-default' 
                                            onclick='btnReset_Click' />
<div class='alert alert-info alert-dismissable'  ID='divSuccessfull' runat='server' Visible='false' style='width:50%'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                                <asp:Label ID='lblMSG' runat='server' Text=''></asp:Label>
                            </div>
</center>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </section>
                        <!-- /.content -->
                    </div>
                    <!-- /.content-wrapper -->
                    <footer class="main-footer">
                        <div class="pull-right hidden-xs">
                            <b>Version</b> 2.3.7
                        </div>
                        <strong>Copyright &copy; 2014-2018 <a href="http://rncdata.net">RNC Data Inc.</a>.</strong> All rights
    reserved.
                    </footer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
        <!-- Control Sidebar -->
        <aside class="control-sidebar control-sidebar-dark">
            <!-- Create the tabs -->
            <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
                <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
                <!-- Home tab content -->
                <div class="tab-pane" id="control-sidebar-home-tab">
                    <h3 class="control-sidebar-heading">Recent Activity
                    ass="control-sidebar-menu">
                                                    f="javascript:void(0)">
                                <i class="menu-icon fa fa-birthday-cake bg-red"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                                    <p>Will be 23 on April 24th</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-user bg-yellow"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>

                                    <p>New phone +1(800)555-1234</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>

                                    <p>nora@example.com</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-file-code-o bg-green"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>

                                    <p>Execution time 5 seconds</p>
                                </div>
                            </a>
                        </li>
                        </ul>
                    <!-- /.control-sidebar-menu -->

                        <h3 class="control-sidebar-heading">Tasks Progress</h3>
                        <ul class="control-sidebar-menu">
                            <li>
                                <a href="javascript:void(0)">
                                    <h4 class="control-sidebar-subheading">Custom Template Design
                <span class="label label-danger pull-right">70%</span>
                                    </h4>

                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:void(0)">
                                    <h4 class="control-sidebar-subheading">Update Resume
                <span class="label label-success pull-right">95%</span>
                                    </h4>

                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-success" style="width: 95%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:void(0)">
                                    <h4 class="control-sidebar-subheading">Laravel Integration
                <span class="label label-warning pull-right">50%</span>
                                    </h4>

                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="javascript:void(0)">
                                    <h4 class="control-sidebar-subheading">Back End Framework
                <span class="label label-primary pull-right">68%</span>
                                    </h4>

                                    <div class="progress progress-xxs">
                                        <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- /.control-sidebar-menu -->
                </div>
                <!-- /.tab-pane -->
                <!-- Stats tab content -->
                <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
                <!-- /.tab-pane -->
                <!-- Settings tab content -->
                <div class="tab-pane" id="control-sidebar-settings-tab">
                    <form method="post">
                        <h3 class="control-sidebar-heading">General Settings</h3>

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Report panel usage
              <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Some information about this general settings option
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Allow mail redirect
              <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Other sets of options are available
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Expose author name in posts
              <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Allow the user to show his name in blog posts
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <h3 class="control-sidebar-heading">Chat Settings</h3>

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Show me as online
              <input type="checkbox" class="pull-right" checked>
                            </label>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Turn off notifications
              <input type="checkbox" class="pull-right">
                            </label>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Delete chat history
              <a href="javascript:void(0)" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
                            </label>
                        </div>
                        <!-- /.form-group -->
                    </form>
                </div>
                <!-- /.tab-pane -->
            </div>
        </aside>
        <!-- /.control-sidebar -->
        <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
        <div class="control-sidebar-bg"></div>
    </div>
    <!-- ./wrapper -->

    <!-- jQuery 2.2.3 -->
    <script src="../AdminLTE/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <!-- Bootstrap 3.3.6 -->
    <script src="../AdminLTE/bootstrap/js/bootstrap.min.js"></script>
    <!-- Morris.js charts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="../AdminLTE/plugins/morris/morris.min.js"></script>
    <!-- Sparkline -->
    <script src="../AdminLTE/plugins/sparkline/jquery.sparkline.min.js"></script>
    <!-- jvectormap -->
    <script src="../AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../AdminLTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="../AdminLTE/plugins/knob/jquery.knob.js"></script>
    <!-- daterangepicker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script src="../AdminLTE/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- datepicker -->
    <script src="../AdminLTE/plugins/datepicker/bootstrap-datepicker.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="../AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../AdminLTE/plugins/fastclick/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../AdminLTE/dist/js/app.min.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../AdminLTE/dist/js/pages/dashboard.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../AdminLTE/dist/js/demo.js"></script>

</body>
</html>
