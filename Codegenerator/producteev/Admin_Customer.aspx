<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Customer.aspx.cs" Inherits="Admin_Customer" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Customer</h1>
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
                                                Title
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtTitle' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                KeyPerson
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtKeyPerson' runat='server' class='form-control' ></asp:TextBox>
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
                                                Phone
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPhone' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                AltPhone
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAltPhone' runat='server' class='form-control' ></asp:TextBox>
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
                                                Notes
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtNotes' runat='server' class='form-control' ></asp:TextBox>
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
                        <div class='col-lg-6'> <table></table>

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
                    Customer List
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