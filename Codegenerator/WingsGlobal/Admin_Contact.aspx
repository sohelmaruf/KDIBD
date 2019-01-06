<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Contact.aspx.cs" Inherits="Admin_Contact" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Contact</h1>
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
                                                Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtName' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Contact No
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtContact_No' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Email
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtEmail' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Company
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtCompany' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Address
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAddress' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Note
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtNote' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
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
                    Contact List
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