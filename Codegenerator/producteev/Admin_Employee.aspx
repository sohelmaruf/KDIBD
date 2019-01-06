<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Employee.aspx.cs" Inherits="Admin_Employee" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Employee</h1>
    </div>
    </div>
    <div class="row">
    <div class="col-lg-12">
    <div class="panel panel-default">
    <div class="panel-heading">
    Add / Edit Information
    </div>
    <div class="panel-body">
    <div class="row">
    <div class="col-lg-6"><table><tr class='form-group'>
                                    <td class='control-label'>
                                                FirstName
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFirstName' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                LastName
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtLastName' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtName' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Designation
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtDesignation' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Phone
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPhone' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Email
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtEmail' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Address
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAddress' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                City
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtCity' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                State
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtState' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Zip
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtZip' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Id
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtId' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                </table>
               </div>
                        <div class='col-lg-6'> <table><tr class='form-group'>
                                    <td class='control-label'>
                                                
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:CheckBox ID='chkHasReviewAuthorization' runat='server' Text='HasReviewAuthorization ?' />
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:CheckBox ID='chkIsInManagement' runat='server' Text='IsInManagement ?' />
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:CheckBox ID='chkIsInDirectorPanel' runat='server' Text='IsInDirectorPanel ?' />
                        </td>
                                </tr>
                </table>

                        </div>
                    </div>
<center style='margin-top:30px;'>
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
    </div><div class='row'>
        <div class='col-lg-12'>
            <div class='panel panel-default'>
                <div class='panel-heading'>
                    Employee List
                </div>
                <div class='panel-body'>
                    <div class='table-responsive'>
    <asp:Label ID='lblList' runat='server' Text=''></asp:Label>
    </div>
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>