<%@ Page Title="Project" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Project.aspx.cs" Inherits="Admin_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
            <asp:HiddenField ID='hfLoginID' runat='server' />
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Project</h1>
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
                                <div class="col-lg-6">
                                    <table>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressNumber
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtAddressNumber' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>GeotechName
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtGeotechName' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>projectNumber
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtprojectNumber' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Plan
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtPlan' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>PlanNum
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtPlanNum' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressStreet
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtAddressStreet' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressSuite
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtAddressSuite' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressZip
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtAddressZip' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Lot
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtLot' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Block
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtBlock' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Subdivision
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtSubdivision' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>ReviewBy
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtReviewBy' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>projectTypeNotes
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtprojectTypeNotes' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>SoilReportNo
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtSoilReportNo' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>PierBells
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtPierBells' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Material notes
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtMaterial_notes' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Customer data
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtCustomer_data' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Hold note
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtHold_note' runat='server' class='form-control' TextMode='MultiLine'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>StartDate
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtStartDate' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>DueDate
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:TextBox ID='txtDueDate' runat='server' class='form-control'></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class='col-lg-6'>
                                    <table>
                                        <tr class='form-group'>
                                            <td class='control-label'>Status
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlStatus_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Priority
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlPriority_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressCity
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlAddressCity_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>AddressState
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlAddressState_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>customer
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlcustomer_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>projectType
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlprojectType_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>PierType
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlPierType_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>PierDiameter
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlPierDiameter_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Foundation type
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlFoundation_type_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>CrawlSpaceJoists
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlCrawlSpaceJoists_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>CrawlSpaceGirders
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlCrawlSpaceGirders_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Joist floor
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlJoist_floor_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Joist spacing
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlJoist_spacing_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Joist ceiling
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlJoist_ceiling_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Roofing
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlRoofing_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'>Roofing weight
                                            </td>
                                            <td class='col-lg-10'>
                                                <asp:DropDownList ID='ddlRoofing_weight_ID' runat='server' class='chzn-select'>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'></td>
                                            <td class='col-lg-10'>
                                                <asp:CheckBox ID='chkIs_projectSoil' runat='server' Text='Is projectSoil ?' />
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'></td>
                                            <td class='col-lg-10'>
                                                <asp:CheckBox ID='chkIs_Pier' runat='server' Text='Is Pier ?' />
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'></td>
                                            <td class='col-lg-10'>
                                                <asp:CheckBox ID='chkIs_Foundation' runat='server' Text='Is Foundation ?' />
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'></td>
                                            <td class='col-lg-10'>
                                                <asp:CheckBox ID='chkIs_PierBeamFoundation' runat='server' Text='Is PierBeamFoundation ?' />
                                            </td>
                                        </tr>
                                        <tr class='form-group'>
                                            <td class='control-label'></td>
                                            <td class='col-lg-10'>
                                                <asp:CheckBox ID='chkIs_Framing' runat='server' Text='Is Framing ?' />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                            <center style='margin-top: 30px;'>
                                <asp:Button ID='btnSave' runat='server' Text='Save' class='btn btn-default'
                                    OnClick='btnSave_Click' />
                                <asp:Button ID='btnReset' runat='server' Text='Reset' class='btn btn-default'
                                    OnClick='btnReset_Click' />
                                <div class='alert alert-info alert-dismissable' id='divSuccessfull' runat='server' visible='false' style='width: 50%'>
                                    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                                    <asp:Label ID='lblMSG' runat='server' Text=''></asp:Label>
                                </div>
                            </center>
                        </div>
                    </div>
                </div>
            </div>
            <div class='row'>
                <div class='col-lg-12'>
                    <div class='panel panel-default'>
                        <div class='panel-heading'>
                            Project List
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
