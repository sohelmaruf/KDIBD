<%@ Page Title="profile info" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_profile_info.aspx.cs" Inherits="Admin_profile_info" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    <div class="row">
    <div class="col-lg-12">
    <h1 class="page-header">
    profile info</h1>
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
                                                First Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFirst_Name' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Middle Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtMiddle_Name' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Last Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtLast_Name' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Gender
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtGender' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Address Line 1
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAddress_Line_1' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Address Line 2
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtAddress_Line_2' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                City
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtCity' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                State
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtState' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Zip
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtZip' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Spouse Name
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtSpouse_Name' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Cell Phone
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtCell_Phone' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Work Phone
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtWork_Phone' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Email aaddress 1
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtEmail_aaddress_1' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Email aaddress 2
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtEmail_aaddress_2' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Current Affiliation
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtCurrent_Affiliation' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Yealy Income Range
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtYealy_Income_Range' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Previous Employment 1
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPrevious_Employment_1' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Previous Employment 2
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPrevious_Employment_2' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Major Subject 1
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtMajor_Subject_1' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Major Subject 2
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtMajor_Subject_2' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Major Subject 3
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtMajor_Subject_3' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Publication Link
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtPublication_Link' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Expertise Area
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtExpertise_Area' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Linkedin Profile
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtLinkedin_Profile' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Facebook Profile
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtFacebook_Profile' runat='server' class='form-control'  TextMode='MultiLine' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Job Seeker
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtJob_Seeker' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                profile info
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:TextBox ID='txtprofile_info' runat='server' class='form-control' ></asp:TextBox>
                        </td>
                                </tr>
                </table>
               </div>
                        <div class='col-lg-6'> <table><tr class='form-group'>
                                    <td class='control-label'>
                                                Educational Institution 1
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlEducational_Institution_1_ID' runat='server' class='chzn-select'>
                                            </asp:DropDownList>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Educational Institution 2
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlEducational_Institution_2_ID' runat='server' class='chzn-select'>
                                            </asp:DropDownList>
                        </td>
                                </tr>
                <tr class='form-group'>
                                    <td class='control-label'>
                                                Educational Institution 3
                                    </td>
                                    <td class='col-lg-10'>
                    <asp:DropDownList ID='ddlEducational_Institution_3_ID' runat='server' class='chzn-select'>
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
                    profile info List
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