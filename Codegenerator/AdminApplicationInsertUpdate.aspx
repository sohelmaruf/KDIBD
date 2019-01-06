<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminApplicationInsertUpdate.aspx.cs" Inherits="AdminApplicationInsertUpdate" Title="Application Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tableCss">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblControlNo" runat="server" Text="ControlNo: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtControlNo" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRepresentativeID" runat="server" Text="RepresentativeID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRepresentative" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblApplicantTypeID" runat="server" Text="ApplicantTypeID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlApplicantType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIntroduceYourselfID" runat="server" Text="IntroduceYourselfID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlIntroduceYourself" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHearAboutUsID" runat="server" Text="HearAboutUsID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHearAboutUs" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNationalityID" runat="server" Text="NationalityID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlNationality" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCourseID" runat="server" Text="CourseID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSecurityQuestionID" runat="server" Text="SecurityQuestionID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSecurityQuestionAnswer" runat="server" Text="SecurityQuestionAnswer: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityQuestionAnswer" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassportNumber" runat="server" Text="PassportNumber: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassportNumber" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblApplicantName" runat="server" Text="ApplicantName: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtApplicantName" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="DateOfBirth: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDateOfBirth" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSex" runat="server" Text="Sex: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSex" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAltEmail" runat="server" Text="AltEmail: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAltEmail" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMaritalStatus" runat="server" Text="MaritalStatus: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMaritalStatus" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPersonalMobileNumber" runat="server" Text="PersonalMobileNumber: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPersonalMobileNumber" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassportIssuedPlace" runat="server" Text="PassportIssuedPlace: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassportIssuedPlace" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassportIssueDate" runat="server" Text="PassportIssueDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassportIssueDate" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassportExpiryDate" runat="server" Text="PassportExpiryDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassportExpiryDate" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVisa" runat="server" Text="Visa: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbVisa" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVisaExpiryDate" runat="server" Text="VisaExpiryDate: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVisaExpiryDate" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReleaseLetterIssued" runat="server" Text="ReleaseLetterIssued: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtReleaseLetterIssued" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNameOfCollegeUniv" runat="server" Text="NameOfCollegeUniv: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNameOfCollegeUniv" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVisaType" runat="server" Text="VisaType: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVisaType" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField1" runat="server" Text="ExtraField1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField6" runat="server" Text="ExtraField6: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField6" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField7" runat="server" Text="ExtraField7: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField7" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField8" runat="server" Text="ExtraField8: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField8" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField9" runat="server" Text="ExtraField9: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField9" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField10" runat="server" Text="ExtraField10: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField10" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField11" runat="server" Text="ExtraField11: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField11" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField12" runat="server" Text="ExtraField12: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField12" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField13" runat="server" Text="ExtraField13: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField13" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField14" runat="server" Text="ExtraField14: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField14" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField15" runat="server" Text="ExtraField15: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField15" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField16" runat="server" Text="ExtraField16: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField16" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField17" runat="server" Text="ExtraField17: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField17" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField18" runat="server" Text="ExtraField18: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField18" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField19" runat="server" Text="ExtraField19: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField19" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField20" runat="server" Text="ExtraField20: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField20" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField21" runat="server" Text="ExtraField21: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField21" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField22" runat="server" Text="ExtraField22: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField22" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField23" runat="server" Text="ExtraField23: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField23" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField24" runat="server" Text="ExtraField24: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField24" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField25" runat="server" Text="ExtraField25: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField25" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField26" runat="server" Text="ExtraField26: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField26" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField27" runat="server" Text="ExtraField27: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField27" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField28" runat="server" Text="ExtraField28: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField28" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField29" runat="server" Text="ExtraField29: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField29" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField30" runat="server" Text="ExtraField30: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField30" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatusID" runat="server" Text="StatusID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRowStatusID" runat="server" Text="RowStatusID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRowStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCountry1" runat="server" Text="Country1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCountry2" runat="server" Text="Country2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCountry3" runat="server" Text="Country3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField31" runat="server" Text="ExtraField31: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField31" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField32" runat="server" Text="ExtraField32: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField32" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField33" runat="server" Text="ExtraField33: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField33" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField34" runat="server" Text="ExtraField34: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField34" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField35" runat="server" Text="ExtraField35: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField35" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField36" runat="server" Text="ExtraField36: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField36" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField37" runat="server" Text="ExtraField37: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField37" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField38" runat="server" Text="ExtraField38: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField38" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField39" runat="server" Text="ExtraField39: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField39" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField40" runat="server" Text="ExtraField40: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField40" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
