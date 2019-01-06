<%@ Page Title="Client Key Person" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Client_Key_Person.aspx.cs" Inherits="Admin_Client_Key_Person" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Client Key Person</h1>
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
                                                Key Person
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtKey_Person' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Title
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtTitle' runat='server' class='form-control' ></asp:TextBox>
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
                </table>
               </div>
                        <div class='col-lg-6'> <table><tr class='form-group'>
                                    <td class='control-label'>
                                                Customer
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlCustomer_ID' runat='server' class='chzn-select'>
                                            </asp:DropDownList>
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
                    Client Key Person List
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