<%@ Page Title="" Language="C#" MasterPageFile="~/NRB/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="NRB_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .panel-heading {
            font-size: 20px;
        }

        .row {
            min-height: 20px;
        }

        .form-control, .btn {
            height: 19px !important;
            padding: 0px 12px !important;
        }

        .content {
            padding: 0px !important;
        }

        .panel-heading {
            padding: 3px 15px !important;
        }

        .panel-body {
            padding-bottom: 2px !important;
        }

        .col-sm-3 {
            padding-left: 3px !important;
            padding-right: 3px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<h1>Non-Resident Bangladeshi Database
        </h1>--%>
    <%--<ol class="breadcrumb">
          <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
          <li><a href="#">Layout</a></li>
          <li class="active">Top Navigation</li>
        </ol>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfLoggedInEmployeeID" runat="server" />
    <div class="row ">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Personal Information
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">

                                    <label for="cc-assignd" class="control-label mb-1">
                                        First Name
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtFirst_Name' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Middle Name
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtMiddle_Name' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Last Name
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtLast_Name' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Gender
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID='ddlGender' runat='server' class='form-control  chzn-select'>
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Address Line 1
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtAddress_Line_1' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Address Line 2
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtAddress_Line_2' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Zip
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID='txtZip' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID='btnLoadZipInfo' runat='server' Text='Load Zip Info' class='btn btn-default'
                                                    OnClick="btnLoadZipInfo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </div>

                        </div>

                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-sm-5">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        City
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID='txtCity' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        State
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID='txtState' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Cell Phone
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID='txtCell_Phone' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID='btnDuplicateChecking' runat='server' Text='Duplicate Checking' class='btn btn-default'
                                                    OnClick="btnDuplicateChecking_Click" />
                                                <asp:Label ID="lblDuplicateMSG" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                </div>


                            </div>

                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-sm-5">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Work Phone
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID='txtWork_Phone' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Spouse Name
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox ID='txtSpouse_Name' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>



                    </div>
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Email 1
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-9">
                                    <asp:TextBox ID='txtEmail_aaddress_1' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-7">
                            <div class="form-group">
                                <div class="col-sm-2">
                                    <label for="cc-assignd" class="control-label mb-1">
                                        Email 2
                                
                                
                                    </label>
                                </div>
                                <div class="col-sm-10">
                                    <asp:TextBox ID='txtEmail_aaddress_2' runat='server' class='form-control'></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                Ecucation & Employment
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Current Affiliation
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtCurrent_Affiliation' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Yealy Income Range
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">

                                <asp:DropDownList ID='ddlYealy_Income_Range' runat='server' class='form-control  chzn-select'>
                                    <asp:ListItem Value="$0 - $5,000">$0 - $5,000</asp:ListItem>
                                    <asp:ListItem Value="$5,001 - $10,000">$5,001 - $10,000</asp:ListItem>
                                    <asp:ListItem Value="$10,001 - $15,000">$10,001 - $15,000</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Prev. Employment 1
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtPrevious_Employment_1' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Prev. Employment 2
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtPrevious_Employment_2' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>

                    </div>


                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Edu. Institution 1
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:DropDownList ID='ddlEducational_Institution_1_ID' runat='server' class='form-control  chzn-select'>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Major Subject 1
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtMajor_Subject_1' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>


                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Edu. Institution 2
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:DropDownList ID='ddlEducational_Institution_2_ID' runat='server' class='form-control  chzn-select'>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Major Subject 2
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtMajor_Subject_2' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Edu. Institution 3
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:DropDownList ID='ddlEducational_Institution_3_ID' runat='server' class='form-control  chzn-select'>
                                </asp:DropDownList>
                            </div>

                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Major Subject 3
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtMajor_Subject_3' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Publication Link
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtPublication_Link' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Expertise Area
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtExpertise_Area' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Linkedin Profile
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtLinkedin_Profile' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Facebook Profile
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID='txtFacebook_Profile' runat='server' class='form-control'></asp:TextBox>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label for="cc-assignd" class="control-label mb-1">
                                    Job Seeker
                                
                                
                                </label>
                            </div>
                            <div class="col-sm-9">

                                <asp:DropDownList ID='ddlJob_Seeker' runat='server' class='form-control  chzn-select'>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <center style='margin-top: 30px;'>
<asp:Button ID='btnSave' runat='server' Text='Save' class='btn btn-default' 
                                            onclick='btnSave_Click'  />
                                        <asp:Button ID='btnReset' runat='server' Text='Reset' class='btn btn-default' 
                                            onclick='btnReset_Click' Visible="false" />
                            <br />
                                <asp:Label ID='lblMSG' runat='server' Text=''></asp:Label>

<div class='alert alert-info alert-dismissable'  ID='divSuccessfull' runat='server' Visible='false' style='width:50%'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                            </div>
</center>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="row">
        <div class="col-lg-10">
            <div class="form-group">
                <div class="col-sm-3">
                    <label for="cc-assignd" class="control-label mb-1">
                        New Edu. Institution:
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtNewEduInstitution" runat="server" class="form-control"></asp:TextBox>
                </div>

            </div>
        </div>
        <div class="col-lg-1">
            <div class="form-group">
               
                    <asp:Button ID="btnEducationalInstitution" runat="server" Text="Add" class="form-control" 
                        
                        OnClick="btnEducationalInstitution_Click"
                        />
                   

            </div>
        </div>
    </div>



            </div>
        </div>
    </div>
    
</asp:Content>

