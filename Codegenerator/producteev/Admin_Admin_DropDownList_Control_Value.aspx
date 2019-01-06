<%@ Page Title="Admin DropDownList Control Value" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Admin_DropDownList_Control_Value.aspx.cs" Inherits="Admin_Admin_DropDownList_Control_Value" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Admin DropDownList Control Value</h1>
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
                                                Admin DropDownList Control Value Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAdmin_DropDownList_Control_Value_Name' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                </table>
               </div>
                        <div class='col-lg-6'> <table><tr class='form-group'>
                                    <td class='control-label'>
                                                Admin DropDownList Control
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlAdmin_DropDownList_Control_ID' runat='server' class='chzn-select'>
                                            </asp:DropDownList>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:CheckBox ID='chkIsActive' runat='server' Text='IsActive ?' />
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
                    Admin DropDownList Control Value List
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