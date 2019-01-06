<%@ Page Title="Proposal" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Proposal.aspx.cs" Inherits="Admin_Proposal" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    Proposal</h1>
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
                    <asp:TextBox ID='txtName' runat='server' class='form-control' ></asp:TextBox>
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
                                                zip
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtzip' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Details
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtDetails' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                ProposalType
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtProposalType' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                DailyType
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtDailyType' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                ProjectType
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtProjectType' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                ProjectOtherTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtProjectOtherTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationSlabTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationSlabTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationPierTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationPierTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationPierRemiedialTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationPierRemiedialTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationPierRemiedialOtherTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationPierRemiedialOtherTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FoundationOtherTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFoundationOtherTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameResidentialValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameResidentialValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameResidentialOtherValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameResidentialOtherValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameExteriorValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameExteriorValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameExteriorOtherValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameExteriorOtherValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameRoofTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameRoofTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                FrameRoofTypeOtherValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFrameRoofTypeOtherValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                RetainingWallValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtRetainingWallValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                RetainingWallTypeValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtRetainingWallTypeValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                RetainingWallTypeWallValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtRetainingWallTypeWallValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                RetainingWallTypeWallOtherValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtRetainingWallTypeWallOtherValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                PoolValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPoolValue' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                PoolCompnayDesignValue
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPoolCompnayDesignValue' runat='server' class='form-control' ></asp:TextBox>
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
                <tr class='form-group'>
                                    <td class='control-label'>
                                                InitialContractDate
                                    </td>
                                    <td class='col-lg-10'>
                    <div class='input-group'>
                                            <asp:TextBox ID='txtInitialContractDate' runat='server' class='form-control' data-mask='99/99/9999'></asp:TextBox>
                                            <span class='input-group-addon'>dd/mm/yyyy</span>
                                            <ajaxToolkit:CalendarExtender Format='dd/MM/yyyy' ID='CalendarExtender5' runat='server'
                                                TargetControlID='txtInitialContractDate'>
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                SubmittalDate
                                    </td>
                                    <td class='col-lg-10'>
                    <div class='input-group'>
                                            <asp:TextBox ID='txtSubmittalDate' runat='server' class='form-control' data-mask='99/99/9999'></asp:TextBox>
                                            <span class='input-group-addon'>dd/mm/yyyy</span>
                                            <ajaxToolkit:CalendarExtender Format='dd/MM/yyyy' ID='CalendarExtender5' runat='server'
                                                TargetControlID='txtSubmittalDate'>
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                RevisionDate
                                    </td>
                                    <td class='col-lg-10'>
                    <div class='input-group'>
                                            <asp:TextBox ID='txtRevisionDate' runat='server' class='form-control' data-mask='99/99/9999'></asp:TextBox>
                                            <span class='input-group-addon'>dd/mm/yyyy</span>
                                            <ajaxToolkit:CalendarExtender Format='dd/MM/yyyy' ID='CalendarExtender5' runat='server'
                                                TargetControlID='txtRevisionDate'>
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                        </td>
                                </tr>
                </table>
               </div>
                        <div class='col-lg-6'> <table><tr class='form-group'>
                                    <td class='control-label'>
                                                ClientID
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlClientID' runat='server' class='chzn-select'>
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
                    Proposal List
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