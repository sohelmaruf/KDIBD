<%@ Page Title="Table 1" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Table_1.aspx.cs" Inherits="Admin_Table_1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Table 1</h1>
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
                                                state
                                    </td>
                                    <td class='col-lg-10'>
                    <div class='input-group'>
                                            <asp:TextBox ID='txtstate' runat='server' class='form-control' data-mask='99/99/9999'></asp:TextBox>
                                            <span class='input-group-addon'>dd/mm/yyyy</span>
                                            <ajaxToolkit:CalendarExtender Format='dd/MM/yyyy' ID='CalendarExtender5' runat='server'
                                                TargetControlID='txtstate'>
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
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
                    Table 1 List
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