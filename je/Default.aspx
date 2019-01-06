<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="je_Default2" %>

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
                                        <ul class="dropdown-menu">
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
                            <ul class='sidebar-menu'>

                                <li id="liAdmin" runat="server"><a href="Admin_Admin_DropDownList_Control_Value.aspx"><i class="fa fa-circle-o text-red"></i><span>Admin</span></a></li>

                                <asp:Literal ID="lblMenuClient" runat="server"></asp:Literal>
                                <asp:TextBox ID="txtClientSearch" runat="server" placeholder="Search"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="txtClientSearch_OnTextChanged">
                                    <img src="../images/search-black.png" width="26px" style="background: white;padding: 2px;margin-top: -3px;"/>
                                </asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton13" runat="server" OnClick="lbtnResetClient_OnClick">
                                    <img src="../images/clear.png" width="20px"/>
                                </asp:LinkButton>
                                <asp:GridView ID="gvClientUser" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" ShowHeader="False" CellPadding="5"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbSelect" runat="server"
                                                    ToolTip='<%#Eval("Title") %>' Visible='<%#Eval("isSelected") %>'
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuClient_Click">
                                <i class='fa fa-arrow-circle-o-right'></i>  <%#Eval("Title") %>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LinkButton14" runat="server"
                                                    ToolTip='<%#Eval("Title") %>' Visible='<%#Eval("isNotSelected") %>' CssClass="selected"
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuClient_Click">
                                                    <i class='fa fa-arrow-circle-o-right'></i>  <%#Eval("Title") %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="lbtnClientMore" runat="server" OnClick="lbtnClientMore_OnClick">More >></asp:LinkButton>
                                <asp:HiddenField ID="hfClientCount" runat="server" Value="30" />
                                <asp:Literal ID="lblMenuProposal" runat="server"></asp:Literal>
                                <asp:TextBox ID="txtProposalSearch" runat="server" placeholder="Search"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton10" runat="server" OnClick="txtProposalSearch_OnTextChanged">
                                    <img src="../images/search-black.png" width="26px" style="background: white;padding: 2px;margin-top: -3px;"/>
                                </asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton11" runat="server" OnClick="lbtnResetProposal_OnClick">
                                    <img src="../images/clear.png" width="20px"/>
                                </asp:LinkButton>
                                <asp:GridView ID="gvMenuProposal" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" ShowHeader="False" CellPadding="5"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbSelect" runat="server" Visible='<%#Eval("isSelected") %>'
                                                    ToolTip='<%#Eval("Name") %>'
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuProposal_Click">
                                <i class='fa fa-arrow-right'></i>  <%#Eval("Name") %>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton14" runat="server"
                                                    ToolTip='<%#Eval("Name") %>' Visible='<%#Eval("isNotSelected") %>' CssClass="selected"
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuProposal_Click">
                                                    <i class='fa fa-arrow-right'></i>  <%#Eval("Name") %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <asp:LinkButton ID="lbtnProposalMore" runat="server" OnClick="lbtnProposalMore_OnClick">More >></asp:LinkButton>
                                <asp:HiddenField ID="hfProposalCount" runat="server" Value="30" />
                                <asp:Literal ID="lblMenuProject1" runat="server"></asp:Literal>
                                <asp:TextBox ID="txtProjectSearch" runat="server" placeholder="Search"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton8" runat="server" OnClick="txtProjectSearch_OnTextChanged">
                                <img src="../images/search-black.png" width="26px" style="background: white;padding: 2px;margin-top: -3px;"/>
                                </asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton9" runat="server" OnClick="lbtnResetProject_OnClick">
                                    <img src="../images/clear.png" width="20px"/>
                                </asp:LinkButton>
                                <%--<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="../images/search.jpg"  OnClick="txtProjectSearch_OnTextChanged"/>--%>
                                <%--<asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="../images/clear.png" OnClick="lbtnResetProject_OnClick" />--%>
                                <asp:GridView ID="gvMenuProject" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" ShowHeader="False" CellPadding="5"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbSelect" runat="server"
                                                    ToolTip='<%#Eval("tooltip") %>' Visible='<%#Eval("isSelected") %>'
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuProject_Click">
                                                    <i class='fa fa-chevron-circle-right'></i>  <%#Eval("Title") %>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton14" runat="server"
                                                    ToolTip='<%#Eval("tooltip") %>' Visible='<%#Eval("isNotSelected") %>' CssClass="selected"
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuProject_Click">
                                                    <i class='fa fa-chevron-circle-right'></i>  <%#Eval("Title") %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="lbtnProjectMore" runat="server" OnClick="lbtnProjectMore_OnClick">More >></asp:LinkButton>
                                <asp:HiddenField ID="hfProjectCount" runat="server" Value="30" />


                                <asp:Literal ID="lblMenuUser" runat="server"></asp:Literal>
                                <asp:DropDownList ID="ddlUserStatus" runat="server" AutoPostBack="True"
                                    CssClass="form-control"
                                    OnSelectedIndexChanged="ddlUserStatus_OnSelectedIndexChanged">
                                    <asp:ListItem Value="Active">Active Users Only</asp:ListItem>
                                    <asp:ListItem Value="In-Active">In-Active Users Only</asp:ListItem>
                                    <asp:ListItem Value="All">All Users</asp:ListItem>
                                </asp:DropDownList>
                                <asp:GridView ID="gvMenuUser" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" ShowHeader="False" CellPadding="5"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbSelect" runat="server"
                                                    ToolTip='<%#Eval("Name") %>' Visible='<%#Eval("isSelected") %>'
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuUser_Click">
                                                    <i class='fa fa-arrow-circle-right'></i>  <%#Eval("Name") %>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LinkButton14" runat="server"
                                                    ToolTip='<%#Eval("Name") %>' Visible='<%#Eval("isNotSelected") %>' CssClass="selected"
                                                    CommandArgument='<%#Eval("id") %>' OnClick="lbMenuUser_Click">
                                                    <i class='fa fa-arrow-circle-right'></i>  <%#Eval("Name") %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ul>
                            </li>
    </ul>
                        </section>
                        <!-- /.sidebar -->
                    </aside>



                    <!-- Content Wrapper. Contains page content -->
                    <div class="content-wrapper">
                        <!-- Content Header (Page header) -->
                        <section class="content-header">
                            <h1>
                                <asp:Label ID="lblSelectedMenu" runat="server" Text=""></asp:Label>

                            </h1>
                            <%--<ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Dashboard</li>
      </ol>--%>
                        </section>
                        <asp:HiddenField ID="hfSelectedMenu" runat="server" Value="project" />
                        <asp:HiddenField ID="hfSelectedID" runat="server" Value="1" />
                        <!-- Main content -->
                        <section class="content">
                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-8">
                                    <div class="box box-primary" id="divAddTask" runat="server" visible="False">
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    Add Task
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="btnAddTaskClose" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class="form-group">
                                                <label for="cc-task" class="control-label mb-1">Task Title</label>
                                                <asp:TextBox runat="server" ID="txtTaskTitle" Name="txtPlanNumber" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter task title"
                                                    autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                                                <span class="help-block field-validation-valid" data-valmsg-for="cc-task" data-valmsg-replace="true"></span>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="cc-task_status" class="control-label mb-1">Task Status</label>
                                                        <asp:DropDownList runat="server" ID="ddlTaskStatusID" class="form-control-md form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="cc-assignd" class="control-label mb-1">Assigned To</label>
                                                        <asp:DropDownList runat="server" ID="ddlTaskAssignedTo" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="cc-dateline" class="control-label mb-1">Deadline</label>
                                                        <asp:TextBox runat="server" ID="txtDateline" class="form-control"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender3' runat='server'
                                                            TargetControlID='txtDateline'>
                                                        </ajaxToolkit:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="col-md-6"></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="cc-assignd" class="control-label mb-1">Project</label>
                                                        <asp:DropDownList runat="server" ID="ddlAddTaskProject" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-md-1"><b>Or</b></div>
                                                <div class="col-md-5">
                                                    <div class="form-group">
                                                        <label for="cc-assignd" class="control-label mb-1">Proposal</label>
                                                        <asp:DropDownList runat="server" ID="ddlAddTaskProposal" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>





                                            <div class="form-group">
                                                <label for="cc-note" class="control-label mb-1">Short Description</label>
                                                <asp:TextBox runat="server" ID="txtTaskShortDescription" Name="txtPlanNumber" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter task short Description"
                                                    autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                                            </div>


                                            <div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <asp:Button runat="server" ID="btnAddTaskForm" OnClick="btnAddTaskForm_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <asp:Button runat="server" ID="Button2" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box box-primary" id="div_UserEdit" runat="server" visible="False">
                                        <asp:TextBox runat="server" ID="TextBox1" Visible="False"></asp:TextBox>
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    <h3>User Information</h3>

                                                    <asp:CheckBox ID='chkIsInManagement' runat='server' Text='Active?' />
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="btnAddOrEditUserClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Status
                                                </label>
                                                <asp:DropDownList ID="ddlStatus" runat="server" class='form-control'>
                                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                                    <asp:ListItem Value="In-Active">In-Active</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    FirstName
                                                </label>
                                                <asp:TextBox ID='txtFirstName' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    LastName
                                                </label>
                                                <asp:TextBox ID='txtLastName' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Name
                                                </label>
                                                <asp:TextBox ID='txtUserName' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Designation
                                                </label>
                                                <asp:TextBox ID='txtDesignation' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Phone
                                                </label>
                                                <asp:TextBox ID='txtPhone' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Email
                                                </label>
                                                <asp:TextBox ID='txtEmail' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Password
                                                </label>
                                                <asp:TextBox ID='txtPassword' runat='server' TextMode="Password" class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Retype Password
                                                </label>
                                                <asp:TextBox ID='txtRetypePassword' TextMode="Password" runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Address
                                                </label>
                                                <asp:TextBox ID='txtUserAddress' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    City
                                                </label>
                                                <asp:TextBox ID='txtUserAddressCity' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    State
                                                </label>
                                                <asp:TextBox ID='txtState' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Zip
                                                </label>
                                                <asp:TextBox ID='txtZip' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Id
                                                </label>
                                                <asp:TextBox ID='txtUserID' runat='server' class='form-control'></asp:TextBox>
                                            </div>

                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                                <asp:CheckBox ID='chkHasReviewAuthorization' runat='server' Text='HasReviewAuthorization ?' />
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                                <asp:CheckBox ID='chkIsInDirectorPanel' runat='server' Text='IsInDirectorPanel ?' />
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Role
                                                </label>
                                                <asp:DropDownList ID="ddlUserRole" runat="server" class='form-control'></asp:DropDownList>
                                            </div>
                                            <div class="row">

                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button5" OnClick="btnAddOrEditUser_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button6" OnClick="btnAddOrEditUserClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box box-primary" id="div_ClientEdit" runat="server" visible="False">
                                        <asp:TextBox runat="server" ID="TextBox2" Visible="False"></asp:TextBox>
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    <h3>Client Details</h3>
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="btnAddOrEditClientClose_OnClick">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <div class='form-group'>
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                            Company / Client
                                                        </label>
                                                        <asp:TextBox ID='txtClientTitle' runat='server' class='form-control'></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class='form-group'>
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                            Client Type (Category)
                                                        </label>
                                                        <asp:DropDownList runat="server" ID="ddlClientType" class="form-control-md form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="jumbotron">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Key Person
                                                            </label>
                                                            <asp:TextBox ID='txtKey_Person' runat='server' class='form-control'></asp:TextBox>
                                                            <asp:HiddenField ID="Client_Key_Person_ID" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Title
                                                            </label>
                                                            <asp:TextBox ID='txtTitle' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Contact No
                                                            </label>
                                                            <asp:TextBox ID='txtContact_No' runat='server' class='form-control' TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                        </label>
                                                        <asp:Button ID="btnAddKeyPerson" runat="server" Text="Add"
                                                            OnClick="btnAddKeyPerson_OnClick" />
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class='form-group'>
                                                            <asp:DropDownList runat="server"
                                                                Visible="False"
                                                                ID="ddlClientKeyPersonTitle" class="form-control-md form-control">
                                                                <asp:ListItem Selected="True" Value=""> select Title</asp:ListItem>
                                                                <asp:ListItem Value="President">President</asp:ListItem>
                                                                <asp:ListItem Value="Purchasing Manager">Purchasing Manager</asp:ListItem>
                                                                <asp:ListItem Value="Owner">Owner</asp:ListItem>
                                                                <asp:ListItem Value="Superintendent">Superintendent</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:GridView ID="gvClientKeyPerson" runat="server" AutoGenerateColumns="false"
                                                                CssClass="table table-bordered table-hover dataTable">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Key Person">
                                                                        <ItemTemplate>
                                                                            <%#Eval("RowNo") %>. 
                                <asp:LinkButton ID="lbtnClientKeyPersonEdit" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="lbtnClientKeyPersonEdit_Click">
                                    <i class="fa fa-edit"></i> <%#Eval("Key_Person") %>
                                </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Title">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Title") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact No">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Contact_No") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="jumbotron">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <h3>Address</h3>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Number
                                                            </label>
                                                            <asp:TextBox ID='txtClientAddress' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Street
                                                            </label>
                                                            <asp:TextBox ID='txtClientAddressStreet' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Suite
                                                            </label>
                                                            <asp:TextBox ID='txtClientAddressSuite' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                City
                                                            </label>
                                                            <asp:TextBox ID='txtClientCity' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                State
                                                            </label>
                                                            <asp:TextBox ID='txtClientState' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Zip
                                                            </label>
                                                            <asp:TextBox ID='txtClientZip' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Email
                                                </label>
                                                <asp:TextBox ID='txtClientEmail' runat='server' class='form-control'></asp:TextBox>
                                            </div>

                                            <div class="jumbotron">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <h3>Phone(s)</h3>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Cell
                                                            </label>
                                                            <asp:TextBox ID='txtClientPhone' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Office
                                                            </label>
                                                            <asp:TextBox ID='txtClientOfficePhone' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Fax
                                                            </label>
                                                            <asp:TextBox ID='txtClientFax' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Others
                                                            </label>
                                                            <asp:TextBox ID='txtAltPhone' runat='server' class='form-control'></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Notes
                                                </label>
                                                <asp:TextBox ID='txtNotes' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Id
                                                </label>
                                                <asp:TextBox ID='txtClientID' runat='server' class='form-control'></asp:TextBox>
                                            </div>
                                            <div class="row">

                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button7" OnClick="btnAddOrEditClient_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button8" OnClick="btnAddOrEditClientClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box box-primary" id="div_ProposalEdit" runat="server" visible="False">
                                        <asp:TextBox runat="server" ID="TextBox3" Visible="False"></asp:TextBox>
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    <h3>Proposal Information</h3>
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="btnAddProposalClose" runat="server" OnClick="btnAddProposalClose_OnClick">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Name (Company Name if applicable)
                                                </label>
                                                <asp:TextBox ID='txtName' runat='server' class="form-control-md form-control"></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Phone #
                                                </label>
                                                <asp:TextBox ID='txtProposalState' runat='server' class="form-control-md form-control"></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Email
                                                </label>
                                                <asp:TextBox ID='txtProposalZip' runat='server' class="form-control-md form-control"></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Client  (<asp:LinkButton ID="lbtnNewClient_OnClick10" runat="server" OnClick="lbtnNewClient_OnClick">Create a Client</asp:LinkButton>)
                                                </label>
                                                <asp:DropDownList ID='ddlClientID' runat='server' class='form-control-md form-control'>
                                                </asp:DropDownList>

                                            </div>
                                            <div class="jumbotron">
                                                <h3>Address</h3>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-address" class="control-label mb-1">Number</label>
                                                            <asp:TextBox ID="txtProposalAddressAddressNumber" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-address" class="control-label mb-1">Street</label>
                                                            <asp:TextBox ID="txtProposalAddressAddressStreet" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-address" class="control-label mb-1">Suite</label>
                                                            <asp:TextBox ID="txtProposalAddressAddressSuite" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-city" class="control-label mb-1">City</label>
                                                            <asp:DropDownList runat="server" ID="ddlProposalAddressAddressCity_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-state" class="control-label mb-1">State</label>

                                                            <asp:DropDownList runat="server" ID="ddlProposalAddressAddressState_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="cc-zipcode" class="control-label mb-1">Zip Code</label>
                                                            <asp:TextBox ID="txtProposalAddressAddressZip" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                                                                data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                                                                autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                                                            <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Details
                                                </label>
                                                <asp:TextBox ID='txtDetails' runat='server' class="form-control-md form-control"></asp:TextBox>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Proposal Type
                                                </label>
                                                <asp:RadioButtonList ID="rbtnlProposalType" runat="server" RepeatDirection="Horizontal" 
                                                    AutoPostBack="True" OnSelectedIndexChanged="rbtnlProposalType_OnSelectedIndexChanged">
                                                    <asp:ListItem Value="Daily" Selected="True">Daily</asp:ListItem>
                                                    <asp:ListItem Value="Project">Project</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:TextBox ID='txtProposalType' Visible="False" runat='server' class="form-control-md form-control"></asp:TextBox>
                                            </div>
                                            <div id="div_ProposalType_daily" runat="server">
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Daily Type
                                                    </label>
                                                    <asp:DropDownList ID="RadioButtonList2" runat="server" RepeatDirection="Vertical" CssClass="form-control">
                                                        <asp:ListItem Value="Forensic Evaluation" Selected="True">Forensic Evaluation (MJ typical – foundation/structure evaluation)</asp:ListItem>
                                                        <asp:ListItem Value="Remodel / Addition">Remodel / Addition – typically preliminary discovery</asp:ListItem>
                                                        <asp:ListItem Value="Insurance Claim">Insurance Claim - various damages to structure</asp:ListItem>
                                                    </asp:DropDownList>
                                                    Daily Type Description
                                                <asp:TextBox ID='txtDailyType' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class="jumbotron">
                                                    <div class='form-group'>
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                            Foundation
                                                        </label>
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <div class='form-group'>
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                            Foundation Type
                                                        </label>
                                                        <asp:CheckBoxList ID="DropDownList1" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Pier & Beam">Pier & Beam</asp:ListItem>
                                                            <asp:ListItem Value="Slab">Slab</asp:ListItem>
                                                            <asp:ListItem Value="Conventional">Conventional</asp:ListItem>
                                                            <asp:ListItem Value="Strip foundation">Strip foundation</asp:ListItem>
                                                            <asp:ListItem Value="Post Tension">Post Tension</asp:ListItem>
                                                            <asp:ListItem Value="Others">Other</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                        TYPE EXISTING
                                                    <asp:TextBox ID='txtFoundationTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Framing Type
                                                            </label>
                                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" 
                                                                                 OnSelectedIndexChanged="rbtnlProposalType_OnSelectedIndexChanged">
                                                                <asp:ListItem Value="conventional wood frame" Selected="True">Conventional wood frame</asp:ListItem>
                                                                <asp:ListItem Value="Concrete">Concrete</asp:ListItem>
                                                                <asp:ListItem Value="Other">Other</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Plan provided 
                                                            </label>
                                                            <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                
                                            </div>
                                            <div id="div_ProposalType_Project" runat="server" visible="False">
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Project Coordinator contact information
                                                    </label>
                                                    <asp:TextBox ID='txtProposalAddress' runat='server' TextMode="MultiLine" class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Job Site Contact Information
                                                    </label>
                                                    <asp:TextBox ID='txtProposalCity' TextMode="MultiLine" runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Arch/ Designer
                                                            </label>
                                                            <asp:TextBox ID='TextBox4' TextMode="MultiLine" runat='server' class="form-control-md form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Seal or Issue Date
                                                            </label>
                                                            <div class='input-group'>
                                                                <asp:TextBox ID='TextBox5' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:TextBox>
                                                                <span class='input-group-addon'>mm/dd/yyyy</span>
                                                                <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender7' runat='server'
                                                                    TargetControlID='txtRevisionDate'>
                                                                </ajaxToolkit:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Revision Date
                                                            </label>
                                                            <div class='input-group'>
                                                                <asp:TextBox ID='txtRevisionDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:TextBox>
                                                                <span class='input-group-addon'>mm/dd/yyyy</span>
                                                                <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender2' runat='server'
                                                                    TargetControlID='txtRevisionDate'>
                                                                </ajaxToolkit:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Foundation Type
                                                            </label>
                                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Pier & Beam" Selected="True">Pier & Beam</asp:ListItem>
                                                                <asp:ListItem Value="Basement">Basement</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID='txtProjectType' Visible="False" runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <label for="cc-projectname" class="control-label mb-1">
                                                            Additional first floor specs (For Pier & Beam)
                                                        </label>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class='form-group'>
                                                                    <label for="cc-projectname" class="control-label mb-1">
                                                                        Piers
                                                                    </label>
                                                                    <asp:TextBox ID='TextBox6' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class='form-group'>
                                                                    <label for="cc-projectname" class="control-label mb-1">
                                                                        Girders (material and sizes)
                                                                    </label>
                                                                    <asp:TextBox ID='TextBox7' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class='form-group'>
                                                                    <label for="cc-projectname" class="control-label mb-1">
                                                                        Sub Floor Joists (material, size, spacing)
                                                                    </label>
                                                                    <asp:TextBox ID='TextBox8' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class='form-group'>
                                                                    <label for="cc-projectname" class="control-label mb-1">
                                                                        Floor Decking (thickness)
                                                                    </label>
                                                                    <asp:TextBox ID='TextBox9' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="col-md-6">
                                                                <div class='form-group'>
                                                                    <label for="cc-projectname" class="control-label mb-1">
                                                                        Drop for Tile
                                                                    </label>
                                                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        
                                                    </div>

                                                </div>
                                                <div class="row">
                                                            
                                            <div class="col-md-6">
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Piers Type
                                                    </label>
                                                    <asp:TextBox ID='txtProjectOtherTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                                    <div class="col-md-6">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Piers Size
                                                            </label>
                                                            <asp:TextBox ID='TextBox10' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Geotech Report
                                                            </label>
                                                            <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Geotech Name
                                                            </label>
                                                            <asp:TextBox ID='TextBox11' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Geotech Name
                                                            </label>
                                                            <asp:TextBox ID='TextBox12' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Rec'd report
                                                            </label>
                                                            <asp:TextBox ID='TextBox13' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Material Specs
                                                    </label>
                                                    </div>
                                                    <div class="row">
                                                        
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Exterior wall (Exterior finish)
                                                            </label>
                                                            <asp:DropDownList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" CssClass="form-control">
                                                                <asp:ListItem Value="siding" Selected="True">siding</asp:ListItem>
                                                                <asp:ListItem Value="stucco">stucco</asp:ListItem>
                                                                <asp:ListItem Value="brick/stone">brick/stone</asp:ListItem>
                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Interior wall (2x, other)
                                                            </label>
                                                            <asp:TextBox ID='TextBox14' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class='form-group'>
                                                            <label for="cc-projectname" class="control-label mb-1">
                                                                Beam Material preference
                                                            </label>
                                                            <asp:TextBox ID='TextBox15' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Roof Material (Rafters)
                                                    </label>
                                                    <asp:TextBox ID='txtFoundationSlabTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Special Treatments to house
                                                    </label>
                                                    <asp:TextBox ID='txtFoundationPierTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Other structures (detached from main house project) Designer
                                                        information for special sub projects
                                                    </label>
                                                    <asp:DropDownList ID="DropDownList3" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Cabana" Selected="True">Cabana</asp:ListItem>
                                                        <asp:ListItem Value="Pool">Pool</asp:ListItem>
                                                        <asp:ListItem Value="Retaining Wall">Retaining Wall</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID='txtFoundationPierRemiedialTypeValue' Visible="False" runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Foundation Pier Remiedial Other Type
                                                    </label>
                                                    <asp:TextBox ID='txtFoundationPierRemiedialOtherTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Foundation Other Type
                                                    </label>
                                                    <asp:TextBox ID='txtFoundationOtherTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Type
                                                    </label>
                                                    <asp:TextBox ID='txtFrameTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Residential
                                                    </label>
                                                    <asp:TextBox ID='txtFrameResidentialValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Residential Other
                                                    </label>
                                                    <asp:TextBox ID='txtFrameResidentialOtherValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Exterior
                                                    </label>
                                                    <asp:TextBox ID='txtFrameExteriorValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Exterior Other
                                                    </label>
                                                    <asp:TextBox ID='txtFrameExteriorOtherValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Roof Type
                                                    </label>
                                                    <asp:TextBox ID='txtFrameRoofTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Frame Roof Type Other
                                                    </label>
                                                    <asp:TextBox ID='txtFrameRoofTypeOtherValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Retaining Wall
                                                    </label>
                                                    <asp:TextBox ID='txtRetainingWallValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Retaining Wall Type
                                                    </label>
                                                    <asp:TextBox ID='txtRetainingWallTypeValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Retaining Wall Type Wall
                                                    </label>
                                                    <asp:TextBox ID='txtRetainingWallTypeWallValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Retaining Wall Type Wall Other
                                                    </label>
                                                    <asp:TextBox ID='txtRetainingWallTypeWallOtherValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Pool
                                                    </label>
                                                    <asp:TextBox ID='txtPoolValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Pool CompanyDesign
                                                    </label>
                                                    <asp:TextBox ID='txtPoolCompnayDesignValue' runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none;">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Id
                                                    </label>
                                                    <asp:TextBox ID='txtProposalID' value="0" runat='server' class="form-control-md form-control"></asp:TextBox>
                                                </div>
                                                <div class='form-group' style="display: none">
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Initial Contract Date
                                                    </label>
                                                    <div class='input-group'>
                                                        <asp:TextBox ID='txtInitialContractDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:TextBox>
                                                        <span class='input-group-addon'>mm/dd/yyyy</span>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender5' runat='server'
                                                            TargetControlID='txtInitialContractDate'>
                                                        </ajaxToolkit:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class='form-group'>
                                                    <label for="cc-projectname" class="control-label mb-1">
                                                        Submittal Date
                                                    </label>
                                                    <div class='input-group'>
                                                        <asp:TextBox ID='txtSubmittalDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:TextBox>
                                                        <span class='input-group-addon'>mm/dd/yyyy</span>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender1' runat='server'
                                                            TargetControlID='txtSubmittalDate'>
                                                        </ajaxToolkit:CalendarExtender>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button1" OnClick="btnAddOrEditProposal_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Button4" OnClick="btnAddProposalClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box box-primary" id="divProjectEdit" runat="server" visible="False">
                                        <asp:TextBox runat="server" ID="txtId" Visible="False"></asp:TextBox>
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    <h3>Project Details</h3>
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="cc-projectnumber" class="control-label mb-1">Project Number</label>
                                                        <asp:TextBox ID="txtprojectNumber" name="txtPNumber" type="tel" class="form-control cc-projectnumber identified visa" value="" data-val="true" data-val-required="Please enter the  project number"
                                                            data-val-cc-number="Please enter a valid card number" autocomplete="cc-projectnumber" runat="server"></asp:TextBox>
                                                        <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnumber" data-valmsg-replace="true"></span>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-project_status" class="control-label mb-1">Project Status</label>

                                                        <asp:DropDownList runat="server" ID="ddlStatus_ID" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-priority" class="control-label mb-1">Project Priority</label>

                                                        <asp:DropDownList runat="server" ID="ddlPriority_ID" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-planname" class="control-label mb-1">Plan Name</label>
                                                        <asp:TextBox runat="server" ID="txtPlan" Name="txtPlan" class="form-control cc-planname valid" data-val="true" data-val-required="Please enter the plan name"
                                                            autocomplete="cc-planname" aria-required="true" aria-invalid="false" aria-describedby="cc-planname-error"></asp:TextBox>
                                                        <span class="help-block field-validation-valid" data-valmsg-for="cc-planname" data-valmsg-replace="true"></span>
                                                    </div>





                                                    <div class="form-group">
                                                        <label for="cc-plannumber" class="control-label mb-1">Plan Number</label>
                                                        <asp:TextBox runat="server" ID="txtPlanNum" Name="txtPlanNum" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter the plan number"
                                                            autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                                                        <span class="help-block field-validation-valid" data-valmsg-for="cc-plannumber" data-valmsg-replace="true"></span>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-start_date" class="control-label mb-1">Start Date</label>
                                                        <asp:TextBox runat="server" ID="txtStartDate" class="form-control cc-start_date identified visa" value=""></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender4' runat='server'
                                                            TargetControlID='txtStartDate'>
                                                        </ajaxToolkit:CalendarExtender>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-Due_date" class="control-label mb-1">Due Date</label>
                                                        <asp:TextBox runat="server" ID="txtDueDate" class="form-control cc-start_date identified visa" value=""></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender6' runat='server'
                                                            TargetControlID='txtDueDate'>
                                                        </ajaxToolkit:CalendarExtender>

                                                    </div>

                                                    <div class="form-group" style="display: none;">
                                                        <label for="cc-projectname" class="control-label mb-1">Project Name</label>
                                                        <asp:TextBox ID="txtProjectName" name="txtPName" type="tel" class="form-control cc-projectname identified visa" value="" data-val="true" data-val-required="Please enter the  projectname"
                                                            data-val-cc-number="Please enter a valid card number" autocomplete="cc-projectname" runat="server"></asp:TextBox>
                                                        <span class="help-block field-validation-valid" data-valmsg-for="cc-projectname" data-valmsg-replace="true"></span>
                                                    </div>
                                                    <div class="jumbotron">
                                                        <h3>Job Address</h3>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-address" class="control-label mb-1">Number</label>
                                                                    <asp:TextBox ID="txtAddressNumber" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                        autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                                    <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-address" class="control-label mb-1">Street</label>
                                                                    <asp:TextBox ID="txtAddressStreet" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                        autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                                    <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-address" class="control-label mb-1">Suite</label>
                                                                    <asp:TextBox ID="txtAddressSuite" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                                                                        autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                                                                    <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-city" class="control-label mb-1">City</label>
                                                                    <asp:DropDownList runat="server" ID="ddlAddressCity_ID" class="form-control-md form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-state" class="control-label mb-1">State</label>

                                                                    <asp:DropDownList runat="server" ID="ddlAddressState_ID" class="form-control-md form-control">
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-zipcode" class="control-label mb-1">Zip Code</label>
                                                                    <asp:TextBox ID="txtAddressZip" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                                                                        data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                                                                        autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                                                                    <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-zipcode" class="control-label mb-1">Lot</label>
                                                                    <asp:TextBox ID="txtLot" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                                                                        data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                                                                        autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                                                                    <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-zipcode" class="control-label mb-1">Block</label>
                                                                    <asp:TextBox ID="txtBlock" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                                                                        data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                                                                        autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                                                                    <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="cc-zipcode" class="control-label mb-1">Subdivision</label>
                                                                    <asp:TextBox ID="txtSubdivision" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                                                                        data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                                                                        autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                                                                    <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
                                                                </div>
                                                            </div>
                                                        </div>




                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-client" class="control-label mb-1">Customer / Client (<asp:LinkButton ID="LinkButton15" runat="server" OnClick="lbtnNewClient_OnClick">Create a Client</asp:LinkButton>)</label>

                                                        <asp:DropDownList runat="server" ID="ddlcustomer_ID" class="form-control-md form-control">
                                                            <asp:ListItem Selected="True" Value="-1"> select Client </asp:ListItem>

                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-review" class="control-label mb-1">PROJECT Reviewed By</label>
                                                        <asp:CheckBoxList runat="server" ID="DropDownProjetReviewed" class="form-control-md form-control" Style="height: auto !important;">
                                                            <asp:ListItem Value="1">R1   kunderhill@jensenengineers.com</asp:ListItem>
                                                            <asp:ListItem Value="2">R2   kroan@jensenengineers.com</asp:ListItem>
                                                            <asp:ListItem Value="3">R3   mallard@jensenengineers.com</asp:ListItem>
                                                        </asp:CheckBoxList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-projecttype" class="control-label mb-1">Project Type</label>

                                                        <asp:DropDownList runat="server" ID="ddlprojectType_ID" class="form-control-md form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label for="cc-projectnote" class="control-label mb-1">Project Type Note</label>
                                                        <asp:TextBox runat="server" ID="txtprojectTypeNotes" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                            autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                        <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                    </div>

                                                    <div class="jumbotron">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Have Soils Report?
                                                                <asp:CheckBox ID="chkIs_projectSoil" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-howsend" class="control-label mb-1">Geotech Name</label>

                                                            <asp:TextBox runat="server" ID="txtGeotechName" class="form-control cc-howsend valid" data-val="true" data-val-required="Geotech Name"
                                                                autocomplete="cc-howsend" aria-required="true" aria-invalid="false" aria-describedby="cc-howsend-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-howsend" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-howsend" class="control-label mb-1">Report No.</label>

                                                            <asp:TextBox runat="server" ID="txtSoilReportNo" class="form-control cc-howsend valid" data-val="true" data-val-required="Please enter the how send"
                                                                autocomplete="cc-howsend" aria-required="true" aria-invalid="false" aria-describedby="cc-howsend-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-howsend" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-howsend" class="control-label mb-1">Report Date</label>
                                                            <asp:TextBox runat="server" ID="txtSoilReportDate" class="form-control cc-start_date identified visa" value=""></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy' ID='CalendarExtender8' runat='server'
                                                            TargetControlID='txtSoilReportDate'>
                                                        </ajaxToolkit:CalendarExtender>
                                                        </div>
                                                    </div>
                                                       <div class="jumbotron">
                                                        <div class="form-group" style="display: none;">
                                                            <label class="checkboxstyle">
                                                                Is client Will Pickup?
                            <asp:CheckBox ID="chkPickup" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group" style="display: none;">
                                                            <label for="cc-pickupperson" class="control-label mb-1">Pickup By Person Name?</label>

                                                            <asp:TextBox runat="server" ID="txtPickPersonName" Name="txtPickPersonName" class="form-control cc-pickupperson valid" data-val="true" data-val-required="Please enter the number pick up person?"
                                                                autocomplete="cc-pickupperson" aria-required="true" aria-invalid="false" aria-describedby="cc-pickupperson-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-pickupperson" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group" style="display: none;">
                                                            <label for="cc-personphonenumber" class="control-label mb-1">Pickup By Person Phone Number?</label>

                                                            <asp:TextBox runat="server" ID="txtPersonalPhoneNumber" Name="txtPersonalPhoneNumber" class="form-control cc-personphonenumber valid" data-val="true" data-val-required="Please enter the number person phone number?"
                                                                autocomplete="cc-personphonenumber" aria-required="true" aria-invalid="false" aria-describedby="cc-personphonenumber-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-personphonenumber" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group" style="display: none;">
                                                            <label for="cc-numbercopies" class="control-label mb-1">Number Of Copies?</label>

                                                            <asp:TextBox runat="server" ID="txtNumberOfCopies" Name="txtNumberOfCopies" type="number" class="form-control cc-numbercopies valid" data-val="true" data-val-required="Please enter the number ofcopies?"
                                                                autocomplete="cc-numbercopies" aria-required="true" aria-invalid="false" aria-describedby="cc-numbercopies-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-numbercopies" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-holdernotice" class="control-label mb-1">Project Hold Notes</label>

                                                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtHold_note" class="form-control cc-holdernotice valid" data-val="true" data-val-required="Please enter the holder notice?"
                                                                autocomplete="cc-holdernotice" aria-required="true" aria-invalid="false" aria-describedby="cc-holdernotice-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-holdernotice" data-valmsg-replace="true"></span>
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="cc-howsend" class="control-label mb-1">Project Hold note Date/Time stamp</label>
                                                            <asp:TextBox runat="server" ID="txtprojectHoldNoteDateTimeStamp" class="form-control cc-start_date identified visa" value=""></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy hh:mm tt' ID='CalendarExtender9' runat='server'
                                                            TargetControlID='txtprojectHoldNoteDateTimeStamp'>
                                                        </ajaxToolkit:CalendarExtender>
                                                        </div>
                                                        <div class="form-group" style="display:none;">
                                                            <label for="cc-clientdate" class="control-label mb-1">Client Data</label>

                                                            <asp:TextBox runat="server" ID="txtCustomer_data" TextMode="MultiLine" Name="txtClientData" class="form-control cc-clientdate valid" data-val="true" data-val-required="Please enter the client date?"
                                                                autocomplete="cc-clientdate" aria-required="true" aria-invalid="false" aria-describedby="cc-clientdate-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-clientdate" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-clientinvoice" class="control-label mb-1">Invoice #</label>
                                                            <asp:TextBox runat="server" ID="txtClientInvoice" Name="txtClientInvoice" class="form-control cc-clientinvoice valid" data-val="true" data-val-required="Please enter the client invoice"
                                                                autocomplete="cc-clientinvoice" aria-required="true" aria-invalid="false" aria-describedby="cc-clientinvoice-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-clientinvoice" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <h3>Building Materials Specifications</h3>
                                                    <div class="jumbotron">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Piers
                                                            <asp:CheckBox ID="chkIs_Pier" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Type</label>
                                                            <asp:DropDownList runat="server" ID="ddlPierType_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Diameter</label>
                                                            <asp:DropDownList runat="server" ID="ddlPierDiameter_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Bells</label>
                                                            <asp:CheckBox ID="chkPierBells" runat="server" Text="Yes"/>
                                                            <br /> Bell Diameters<br />
                                                            <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                                <asp:ListItem>Diameter-1</asp:ListItem>
                                                                <asp:ListItem>Diameter-1</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox runat="server" ID="txtPierBells" Visible="false" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Bell Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox16"  Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>

                                                    <div class="jumbotron">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Foundation
                             <asp:CheckBox ID="chkIs_Foundation" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-foundationtype" class="control-label mb-1">Foundation Type</label>


                                                            <asp:DropDownList runat="server" ID="ddlFoundation_type_ID" class="form-control-md form-control">
                                                                <asp:ListItem Selected="True" Value="-1"> select Type </asp:ListItem>
                                                                <asp:ListItem Value="1"> Pier Beam </asp:ListItem>
                                                                <asp:ListItem Value="2"> Conventional Reinforced Slab w/o Piers </asp:ListItem>
                                                                <asp:ListItem Value="2"> Conventional Reinforced Slab w/o Piers </asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Foundation Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox17" Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>

                                                    <div class="jumbotron">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Pier and Beam Foundation
                                                                <asp:CheckBox ID="chkIs_PierBeamFoundation" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Crawl Space Joists</label>
                                                            <asp:DropDownList runat="server" ID="ddlCrawlSpaceJoists_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:CheckBox ID="CheckBox4" runat="server" Text="Drop for Tile?" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Crawl Space Girders</label>
                                                            <asp:DropDownList runat="server" ID="ddlCrawlSpaceGirders_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Crawl Space Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox18"  Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>


                                                    <div class="jumbotron">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Framing
                            <asp:CheckBox ID="chkIs_Framing" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-floorjoist" class="control-label mb-1">Type of Floor joist</label>
                                                            <br />
                                                            <asp:CheckBox ID="CheckBox5" runat="server" Text="regarding/repeat for 2nd, 3rd, 4th floors"/>
                                                            <br />
                                                            <asp:DropDownList runat="server" ID="ddlJoist_floor_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-joistspace" class="control-label mb-1">Max Floor Joist Spacing</label>

                                                            <asp:DropDownList runat="server" ID="ddlJoist_spacing_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>

                                                        </div>
                                                         <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Floor Joist Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox19"  Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-ceilingjoist" class="control-label mb-1">Type Of Ceiling Joist</label>
                                                            <br />
                                                            <asp:CheckBox ID="CheckBox6" runat="server" Text="All Active Attic Storage"/>
                                                            <br />
                                                            <asp:DropDownList runat="server" ID="ddlJoist_ceiling_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-joistspace" class="control-label mb-1">Ceiling Joist Max Spacing</label>

                                                            <asp:DropDownList runat="server" ID="DropDownList5" class="form-control-md form-control">
                                                                <asp:ListItem>16"</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Ceiling Joists Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox20"  Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-roofingmaterials" class="control-label mb-1">Roofing Materials</label>
                                                            <asp:DropDownList runat="server" ID="ddlRoofing_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-weightmaterials" class="control-label mb-1">Roof Materials Design Load</label>
                                                            <asp:DropDownList runat="server" ID="ddlRoofing_weight_ID" class="form-control-md form-control">
                                                            </asp:DropDownList>
                                                            <asp:TextBox runat="server" Visible="False" ID="txtWeightMaterials" Name="txtWeightMaterials" class="form-control cc-weightmaterials valid" data-val="true" data-val-required="Please enter the weight materials  ?"
                                                                autocomplete="cc-weightmaterials" aria-required="true" aria-invalid="false" aria-describedby="cc-weightmaterials-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-weightmaterials" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-projectnote" class="control-label mb-1">Roof Materials Note</label>
                                                            <asp:TextBox runat="server" ID="TextBox21"  Textmode="MultiLine" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                                                                autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-materialnotes" class="control-label mb-1">Project Material Notes</label>

                                                            <asp:TextBox runat="server" ID="txtMaterial_notes" class="form-control cc-materialnotes valid" data-val="true" data-val-required="Please enter the material notes ?"
                                                                autocomplete="cc-materialnotes" aria-required="true" aria-invalid="false" aria-describedby="cc-materialnotes-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-floorjoist" data-valmsg-replace="true"></span>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-howsend" class="control-label mb-1">Project Material Notes Date/Time stamp</label>
                                                            <asp:TextBox runat="server" ID="txtprojectNaterualsNoteDateTimeStamp" class="form-control cc-start_date identified visa" value=""></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender Format='MM/dd/yyyy hh:mm tt' ID='CalendarExtender10' runat='server'
                                                            TargetControlID='txtprojectNaterualsNoteDateTimeStamp'>
                                                        </ajaxToolkit:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="jumbotron" style="display: none;">
                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Is Have Courier Plans?
                                                    <asp:CheckBox ID="chkIsCourier" runat="server" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-courier" class="control-label mb-1">Courier to Whom?</label>
                                                            <asp:TextBox runat="server" ID="txtCourierWhom" Name="txtCourierWhom" class="form-control cc-courier valid" data-val="true" data-val-required="Please enter the courier ?"
                                                                autocomplete="cc-courier" aria-required="true" aria-invalid="false" aria-describedby="cc-courier-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-courier" data-valmsg-replace="true"></span>

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-courieraddress" class="control-label mb-1">Courier to Address?</label>

                                                            <asp:TextBox runat="server" ID="txtCourierAddress" Name="txtCourierAddress" class="form-control cc-courieraddress valid" data-val="true" data-val-required="Please enter the courier address?"
                                                                autocomplete="cc-courieraddress" aria-required="true" aria-invalid="false" aria-describedby="cc-courieraddress-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-courieraddress" data-valmsg-replace="true"></span>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="checkboxstyle">
                                                                Is Have Email?
                            <asp:CheckBox ID="chkIsHaveEmail" runat="server" Checked="true" />
                                                                <span class="checkmark"></span>
                                                            </label>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cc-emailaddress" class="control-label mb-1">Email Address?</label>

                                                            <asp:TextBox runat="server" ID="txtEmailAddress" Name="txtEmailAddress" class="form-control cc-emailaddress valid" data-val="true" data-val-required="Please enter the email address?"
                                                                autocomplete="cc-emailaddress" aria-required="true" aria-invalid="false" aria-describedby="cc-emailaddress-error"></asp:TextBox>
                                                            <span class="help-block field-validation-valid" data-valmsg-for="cc-emailaddress" data-valmsg-replace="true"></span>
                                                        </div>
                                                    </div>
                                                 
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="Add" OnClick="btnAdd_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                                </div>
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" ID="btnCancelProjectEdit" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="box box-primary" id="div_TaskDetails" runat="server" visible="False">
                                        <div class="box-header with-border">
                                            <div class="row">
                                                <div class="col-lg-11">
                                                    <h3>Task Details</h3>
                                                </div>
                                                <div class="col-lg-1">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <div class="form-group">
                                                <asp:Label ID="lblTaskTitleDetails" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hfTaskID" runat="server" />
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <address class="mt-3">
                                                        <strong>Deadline</strong>
                                                        <br>
                                                        <asp:Label ID="lblTaskDetails_Deadline" runat="server" Text=""></asp:Label>
                                                        <br>
                                                        <strong>Assigned to : </strong>
                                                        <asp:Label ID="lblTaskDetails_AssignedTo" runat="server" Text=""></asp:Label>
                                                        <br>
                                                        <strong>Status : </strong>
                                                        <asp:Label ID="lblTaskDetails_TaskStatus" runat="server" Text=""></asp:Label>
                                                        <br>
                                                        <strong>Short Details</strong>
                                                        <br>
                                                        <asp:Label ID="lblTaskDetails_ShortDetails" runat="server" Text=""></asp:Label>
                                                        <br>
                                                        <strong>Full Description : </strong>
                                                        <asp:Label ID="lblTaskDetails_FullDescription" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        <div class="box box-success" style="">
                                                            <div class="box-header">
                                                                <i class="fa fa-comments-o"></i>

                                                                <h3 class="box-title">Notes</h3>

                                                            </div>
                                                            <div class="box-body chat" id="chat-box">
                                                                <!-- chat item -->
                                                                <asp:Repeater ID="rptNotes" runat="server">
                                                                    <ItemTemplate>
                                                                        <div class="item" style="border-bottom: 1px solid green;">

                                                                            <p class="message">
                                                                                <a href="#" class="name">
                                                                                    <small class="text-muted pull-right"><i class="fa fa-clock-o"></i>
                                                                                        <%#Eval("CreatedDate","{0:MM/dd/yyyy hh:mm tt}") %>
                                                                                    </small>
                                                                                    <%--User Name--%>
                                                                                    <br />
                                                                                </a>
                                                                                <%#Eval("Comment") %>
                                                                            </p>

                                                                            <!-- /.attachment -->
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>

                                                                <!-- /.item -->
                                                                <!-- chat item -->

                                                                <!-- /.item -->
                                                            </div>
                                                            <!-- /.chat -->
                                                            <div class="box-footer">
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ID="txtTaskNote" Name="txtClientInvoice" class="form-control cc-clientinvoice valid" data-val="true" placeholder="Type note..."
                                                                        autocomplete="cc-clientinvoice" aria-required="true" aria-invalid="false" aria-describedby="cc-clientinvoice-error"></asp:TextBox>

                                                                    <div class="input-group-btn">
                                                                        <asp:LinkButton runat="server" ID="btnAddNote" OnClick="btnAddNote_OnClick" class="btn btn-success" Text="Add Note"><i class="fa fa-plus"></i>Add Note</asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </address>
                                                </div>

                                            </div>
                                            <div class="row">

                                                <div class="col-lg-12">
                                                    <asp:Button runat="server" ID="Button3" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>

                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <div class="col-lg-2"></div>
                            </div>

                            <div class="row " id="divTaskList" runat="server">
                                <div class="col-md-12">

                                    <div class="table-responsive table-responsive-data2">
                                        <div class="box box-primary">
                                            <div class="box-header with-border">
                                                <h3 class="box-title">Tasks</h3>
                                                <asp:LinkButton ID="btnAddTask" runat="server"
                                                    OnClick="btnAddTask_onClick"
                                                    class="au-btn au-btn-icon au-btn--green au-btn--small">
                            (<i class="fa fa-plus"></i>Add New Task)
                                                </asp:LinkButton>
                                            </div>
                                            <!-- /.box-header -->
                                            <!-- form start -->

                                            <div class="box-body" style="height: 450px!important; overflow: scroll !important;">

                                                <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="false"
                                                    CssClass="table table-bordered table-hover dataTable">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Task">
                                                            <ItemTemplate>
                                                                <%#Eval("RowNo") %>. 
                                <asp:LinkButton ID="lbtnTaskEdit" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="lbtnTaskEdit_Click">
                                    <i class="fa fa-edit"></i> <%#Eval("TaskName") %>
                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Proposal / Project">
                                                            <ItemTemplate>
                                                                <%#Eval("ProjectTitle") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client">
                                                            <ItemTemplate>
                                                                <%#Eval("ClientTitle") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deadline">
                                                            <ItemTemplate>
                                                                <%#Eval("Deadline", "{0:MM/dd/yyyy}") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <%#Eval("StatusTitle") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- END DATA TABLE -->
                                </div>
                            </div>
                            <br />
                            <div class="box box-primary" id="div_User_View" runat="server">
                                <div class="box-header with-border">
                                    <h3>
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btnUserViewEdit_OnClick"><i class="fa fa-edit"></i></asp:LinkButton>
                                        <asp:Label ID="lblUserName1" runat="server" Text=""></asp:Label>
                                    </h3>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    FirstName
                                                </label>
                                                <asp:Label ID='lblFirstName' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    LastName
                                                </label>
                                                <asp:Label ID='lblLastName' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Name
                                                </label>
                                                <asp:Label ID='lblUserName' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Designation
                                                </label>
                                                <asp:Label ID='lblDesignation' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Phone
                                                </label>
                                                <asp:Label ID='lblPhone' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Email
                                                </label>
                                                <asp:Label ID='lblEmail' runat='server' class='form-control'></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">

                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Address
                                                </label>
                                                <asp:Label ID='lblUserAddress' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    City
                                                </label>
                                                <asp:Label ID='lblUserCity' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    State
                                                </label>
                                                <asp:Label ID='lblUserState' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Zip
                                                </label>
                                                <asp:Label ID='lblUserZip' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Role
                                                </label>
                                                <asp:Label ID='lbluserRole' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Id
                                                </label>
                                                <asp:Label ID='lblUserID' runat='server' class='form-control'></asp:Label>
                                            </div>

                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                                <asp:CheckBox ID='CheckBox1' runat='server' Text='HasReviewAuthorization ?' />
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                                <asp:CheckBox ID='CheckBox2' runat='server' Text='IsInManagement ?' />
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                </label>
                                                <asp:CheckBox ID='CheckBox3' runat='server' Text='IsInDirectorPanel ?' />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box box-primary" id="div_Client_View" runat="server">
                                <div class="box-header with-border">
                                    <h3>
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnClientViewEdit_OnClick"><i class="fa fa-edit"></i></asp:LinkButton>
                                        <asp:Label ID="lblClientTitle1" runat="server" Text=""></asp:Label>
                                    </h3>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Company / Client
                                                </label>
                                                <asp:Label ID='lblClientTitle' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Client Type
                                                </label>
                                                <asp:Label ID='lblClientType' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Key Person
                                                </label>
                                                <asp:Label ID='lblKeyPerson' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Key Person Title
                                                </label>
                                                <asp:Label ID='lblClientKeypersonTitle' runat='server' class='form-control'></asp:Label>
                                            </div>


                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Notes
                                                </label>
                                                <asp:Label ID='lblNotes' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Id
                                                </label>
                                                <asp:Label ID='lblClientID' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Email
                                                </label>
                                                <asp:Label ID='lblClientEmail' runat='server' class='form-control'></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Address
                                                </label>
                                                <asp:Label ID='lblClientAddress' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    City
                                                </label>
                                                <asp:Label ID='lblClientCity' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    State
                                                </label>
                                                <asp:Label ID='lblClientState' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Zip
                                                </label>
                                                <asp:Label ID='lblClientZip' runat='server' class='form-control'></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Cell
                                                </label>
                                                <asp:Label ID='lblClientPhone' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Office
                                                </label>
                                                <asp:Label ID='lblClientOfficePhone' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Fax
                                                </label>
                                                <asp:Label ID='lblClientFax' runat='server' class='form-control'></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Others
                                                </label>
                                                <asp:Label ID='lblAltPhone' runat='server' class='form-control'></asp:Label>
                                            </div>

                                        </div>
                                        <div class="col-md-2">
                                        </div>
                                        <div class="col-md-8">

                                            <asp:GridView ID="gvClientKeyPersonView" runat="server" AutoGenerateColumns="false"
                                                CssClass="table table-bordered table-hover dataTable">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <%#Eval("RowNo") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Key Person">
                                                        <ItemTemplate>
                                                            <%#Eval("Key_Person") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Title">
                                                        <ItemTemplate>
                                                            <%#Eval("Title") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact No">
                                                        <ItemTemplate>
                                                            <%#Eval("Contact_No") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                    </div>
                                </div>
                            </div>
                            <div class="box box-primary" id="div_Proposal_View" runat="server">
                                <div class="box-header with-border">
                                    <h3>
                                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btnProposalViewEdit_OnClick"><i class="fa fa-edit"></i></asp:LinkButton>
                                        <asp:Label ID="lblProposalName1" runat="server" Text=""></asp:Label>
                                    </h3>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Client 
                                                </label>
                                                <br />
                                                <asp:DropDownList ID='ddlClientIDView' runat='server' class='form-control-md form-control'>
                                                </asp:DropDownList>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Name
                                                </label>
                                                <asp:Label ID='lblProposalName2' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Address
                                                </label>
                                                <asp:Label ID='lblProposalAddress' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    City
                                                </label>
                                                <asp:Label ID='lblProposalCity' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    State
                                                </label>
                                                <asp:Label ID='lblProposalState' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    zip
                                                </label>
                                                <asp:Label ID='lblProposalZip' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Details
                                                </label>
                                                <asp:Label ID='lblDetails' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Initial Contract Date
                                                </label>
                                                <div class='input-group'>
                                                    <asp:Label ID='lblInitialContractDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:Label>
                                                    <span class='input-group-addon'>mm/dd/yyyy</span>

                                                </div>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Submittal Date
                                                </label>
                                                <div class='input-group'>
                                                    <asp:Label ID='lblSubmittalDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:Label>
                                                    <span class='input-group-addon'>mm/dd/yyyy</span>

                                                </div>
                                            </div>

                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Revision Date
                                                </label>
                                                <div class='input-group'>
                                                    <asp:Label ID='lblRevisionDate' runat='server' class="form-control-md form-control" data-mask='99/99/9999'></asp:Label>
                                                    <span class='input-group-addon'>mm/dd/yyyy</span>

                                                </div>
                                            </div>



                                        </div>
                                        <div class="col-lg-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Proposal Type
                                                </label>
                                                <asp:Label ID='lblProposalType' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Daily Type
                                                </label>
                                                <asp:Label ID='lblDailyType' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Project Type
                                                </label>
                                                <asp:Label ID='lblProjectType' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Project Other Type
                                                </label>
                                                <asp:Label ID='lblProjectOtherTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Type
                                                </label>
                                                <asp:Label ID='lblFoundationTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Slab Type
                                                </label>
                                                <asp:Label ID='lblFoundationSlabTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Pier Type
                                                </label>
                                                <asp:Label ID='lblFoundationPierTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Pier Remiedial Type
                                                </label>
                                                <asp:Label ID='lblFoundationPierRemiedialTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Pier Remiedial Other Type
                                                </label>
                                                <asp:Label ID='lblFoundationPierRemiedialOtherTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Foundation Other Type
                                                </label>
                                                <asp:Label ID='lblFoundationOtherTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Type
                                                </label>
                                                <asp:Label ID='lblFrameTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Residential
                                                </label>
                                                <asp:Label ID='lblFrameResidentialValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Residential Other
                                                </label>
                                                <asp:Label ID='lblFrameResidentialOtherValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Exterior
                                                </label>
                                                <asp:Label ID='lblFrameExteriorValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Exterior Other
                                                </label>
                                                <asp:Label ID='lblFrameExteriorOtherValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Roof Type
                                                </label>
                                                <asp:Label ID='lblFrameRoofTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Frame Roof Type Other
                                                </label>
                                                <asp:Label ID='lblFrameRoofTypeOtherValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Retaining Wall
                                                </label>
                                                <asp:Label ID='lblRetainingWallValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Retaining Wall Type
                                                </label>
                                                <asp:Label ID='lblRetainingWallTypeValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Retaining Wall Type Wall
                                                </label>
                                                <asp:Label ID='lblRetainingWallTypeWallValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Retaining Wall Type Wall Other
                                                </label>
                                                <asp:Label ID='lblRetainingWallTypeWallOtherValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Pool
                                                </label>
                                                <asp:Label ID='lblPoolValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Pool Company Design
                                                </label>
                                                <asp:Label ID='lblPoolCompnayDesignValue' runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>
                                            <div class='form-group' style="display: none;">
                                                <label for="cc-projectname" class="control-label mb-1">
                                                    Id
                                                </label>
                                                <asp:Label ID='lblProposalID' value="0" runat='server' class="form-control-md form-control"></asp:Label>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box box-primary" id="divProjectView" runat="server">
                                <div class="box-header with-border">
                                    <h3>
                                        <asp:LinkButton ID="btnProjectViewEdit" runat="server" OnClick="btnProjectViewEdit_OnClick"><i class="fa fa-edit"></i></asp:LinkButton>
                                        <asp:Label ID="lblProjectDetails_ProjectName" runat="server" Text=""></asp:Label>
                                    </h3>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <address class="mt-3">
                                                <strong>Client</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_ClientName" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Project Number : </strong>
                                                <asp:Label ID="lblProjectDetails_ProjectNumber" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Priority : </strong>
                                                <asp:Label ID="lblProjectDetails_Priority" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Status</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_ProjectStatus" runat="server" Text=""></asp:Label>

                                            </address>
                                        </div>
                                        <div class="col-lg-3">
                                            <address class="mt-3">
                                                <strong>Address</strong>
                                                <br>
                                                <strong>Number : </strong>
                                                <asp:Label ID="lblAddressNumber" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Street : </strong>
                                                <asp:Label ID="lblAddressStreet" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Suite : </strong>
                                                <asp:Label ID="lblAddressSuite" runat="server" Text=""></asp:Label>
                                                <br>

                                                <strong>City : </strong>
                                                <asp:Label ID="lblProjectDetails_JobCity" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>State : </strong>
                                                <asp:Label ID="lblProjectDetails_JobState" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Zip : </strong>
                                                <asp:Label ID="lblProjectDetails_JobZip" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>LOT : </strong>
                                                <asp:Label ID="lblLot" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Block : </strong>
                                                <asp:Label ID="lblBlock" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Subdivision : </strong>
                                                <asp:Label ID="lblSubdivision" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>

                                                <strong>Start Date : </strong>
                                                <asp:Label ID="lblProjectDetails_StartDate" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Due Date : </strong>
                                                <asp:Label ID="lblProjectDetails_DueDate" runat="server" Text=""></asp:Label>

                                            </address>
                                        </div>
                                        <div class="col-lg-3">
                                            <strong>Type : </strong>
                                            <asp:Label ID="lblProjectDetails_ProjectType" runat="server" Text=""></asp:Label>
                                            <br>
                                            <br>
                                            <strong>Plan Name</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_PlanName" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Plan Number : </strong>
                                            <asp:Label ID="lblProjectDetails_PlanNumber" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Reviewed By</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_ReviewedBy" runat="server" Text=""></asp:Label>
                                        </div>

                                        <div class="col-lg-3">

                                            <strong>Project Type Note</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_ProjectTypeNote" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Number Of Copies</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_NumberOfCopies" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Project Hold Notes</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_ProjectHoldHotes" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Customer Data</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_CustomerData" runat="server" Text=""></asp:Label>
                                            <br>
                                            <strong>Invoice</strong>
                                            <br>
                                            <asp:Label ID="lblProjectDetails_Invoice" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="jumbotron">
                                                <strong>Is Foundateion? --></strong>
                                                <asp:Label ID="lblProjectDetails_IsFoundation" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Foundation Type</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_FoundationType" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Pier and Beam Foundation? --></strong>
                                                <asp:Label ID="lblIs_PierBeamFoundation" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Crawl Space Joist</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_FoundationCrawlSpaceJoist" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Crawl Space Girders</strong>
                                                <br>
                                                <asp:Label ID="lblCrawlSpaceGirders_ID" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="jumbotron">
                                                <strong>Have Soils Report? --></strong>
                                                <asp:Label ID="lblProjectDetails_IsHaveSoilsReport" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Geotech Name</strong>
                                                <br>
                                                <asp:Label ID="lblGeotechName" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Report #</strong>
                                                <br>
                                                <asp:Label ID="lblSoilReportNo" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="jumbotron">
                                                <strong>Piers? --></strong>
                                                <asp:Label ID="lblIs_Pier" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Type</strong>
                                                <br>
                                                <asp:Label ID="lblPierType_ID" runat="server" Text=""></asp:Label>
                                                <br>
                                                <strong>Diameter</strong>
                                                <br>
                                                <asp:Label ID="lblPierDiameter_ID" runat="server" Text=""></asp:Label>
                                                <strong>Bells</strong>
                                                <br>
                                                <asp:Label ID="lblPierBells" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="jumbotron">
                                                <strong>Is Framing? --></strong>
                                                <asp:Label ID="lblProjectDetails_IsFraming" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Type of Floor Joist</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_TypeOfFloorJoist" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Max Floor Joist Spacing</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_MaxFloorJoistSpacing" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Type Of Ceiling Joist?</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_TypeOfCeilingJoist" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Roofing Materials</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_RoofingMaterials" runat="server" Text=""></asp:Label>

                                                <br>
                                                <br>
                                                <strong>Design Load for Roofing Material</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_WeightOfRoofingMaterials" runat="server" Text=""></asp:Label>
                                                <br>
                                                <br>
                                                <strong>Project Material Notes</strong>
                                                <br>
                                                <asp:Label ID="lblProjectDetails_ProjectMaterialNotes" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
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
                    <h3 class="control-sidebar-heading">Recent Activity</h3>
                    <ul class="control-sidebar-menu">
                        <li>
                            <a href="javascript:void(0)">
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
