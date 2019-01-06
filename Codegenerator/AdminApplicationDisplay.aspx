<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminApplicationDisplay.aspx.cs" Inherits="AdminApplicationDisplay" Title="Display Application By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvApplication" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("ApplicationID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ControlNo">
                    <ItemTemplate>
                        <asp:Label ID="lblControlNo" runat="server" Text='<%#Eval("ControlNo") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RepresentativeID">
                    <ItemTemplate>
                        <asp:Label ID="lblRepresentativeID" runat="server" Text='<%#Eval("RepresentativeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ApplicantTypeID">
                    <ItemTemplate>
                        <asp:Label ID="lblApplicantTypeID" runat="server" Text='<%#Eval("ApplicantTypeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IntroduceYourselfID">
                    <ItemTemplate>
                        <asp:Label ID="lblIntroduceYourselfID" runat="server" Text='<%#Eval("IntroduceYourselfID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HearAboutUsID">
                    <ItemTemplate>
                        <asp:Label ID="lblHearAboutUsID" runat="server" Text='<%#Eval("HearAboutUsID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NationalityID">
                    <ItemTemplate>
                        <asp:Label ID="lblNationalityID" runat="server" Text='<%#Eval("NationalityID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CourseID">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SecurityQuestionID">
                    <ItemTemplate>
                        <asp:Label ID="lblSecurityQuestionID" runat="server" Text='<%#Eval("SecurityQuestionID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SecurityQuestionAnswer">
                    <ItemTemplate>
                        <asp:Label ID="lblSecurityQuestionAnswer" runat="server" Text='<%#Eval("SecurityQuestionAnswer") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PassportNumber">
                    <ItemTemplate>
                        <asp:Label ID="lblPassportNumber" runat="server" Text='<%#Eval("PassportNumber") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ApplicantName">
                    <ItemTemplate>
                        <asp:Label ID="lblApplicantName" runat="server" Text='<%#Eval("ApplicantName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateOfBirth">
                    <ItemTemplate>
                        <asp:Label ID="lblDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sex">
                    <ItemTemplate>
                        <asp:Label ID="lblSex" runat="server" Text='<%#Eval("Sex") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AltEmail">
                    <ItemTemplate>
                        <asp:Label ID="lblAltEmail" runat="server" Text='<%#Eval("AltEmail") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MaritalStatus">
                    <ItemTemplate>
                        <asp:Label ID="lblMaritalStatus" runat="server" Text='<%#Eval("MaritalStatus") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PersonalMobileNumber">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalMobileNumber" runat="server" Text='<%#Eval("PersonalMobileNumber") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PassportIssuedPlace">
                    <ItemTemplate>
                        <asp:Label ID="lblPassportIssuedPlace" runat="server" Text='<%#Eval("PassportIssuedPlace") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PassportIssueDate">
                    <ItemTemplate>
                        <asp:Label ID="lblPassportIssueDate" runat="server" Text='<%#Eval("PassportIssueDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PassportExpiryDate">
                    <ItemTemplate>
                        <asp:Label ID="lblPassportExpiryDate" runat="server" Text='<%#Eval("PassportExpiryDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa">
                    <ItemTemplate>
                        <asp:Label ID="lblVisa" runat="server" Text='<%#Eval("Visa") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VisaExpiryDate">
                    <ItemTemplate>
                        <asp:Label ID="lblVisaExpiryDate" runat="server" Text='<%#Eval("VisaExpiryDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReleaseLetterIssued">
                    <ItemTemplate>
                        <asp:Label ID="lblReleaseLetterIssued" runat="server" Text='<%#Eval("ReleaseLetterIssued") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NameOfCollegeUniv">
                    <ItemTemplate>
                        <asp:Label ID="lblNameOfCollegeUniv" runat="server" Text='<%#Eval("NameOfCollegeUniv") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VisaType">
                    <ItemTemplate>
                        <asp:Label ID="lblVisaType" runat="server" Text='<%#Eval("VisaType") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField1">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField2">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField3">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField4">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField5">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField6">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField6" runat="server" Text='<%#Eval("ExtraField6") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField7">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField7" runat="server" Text='<%#Eval("ExtraField7") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField8">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField8" runat="server" Text='<%#Eval("ExtraField8") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField9">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField9" runat="server" Text='<%#Eval("ExtraField9") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField10">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField10" runat="server" Text='<%#Eval("ExtraField10") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField11">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField11" runat="server" Text='<%#Eval("ExtraField11") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField12">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField12" runat="server" Text='<%#Eval("ExtraField12") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField13">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField13" runat="server" Text='<%#Eval("ExtraField13") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField14">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField14" runat="server" Text='<%#Eval("ExtraField14") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField15">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField15" runat="server" Text='<%#Eval("ExtraField15") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField16">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField16" runat="server" Text='<%#Eval("ExtraField16") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField17">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField17" runat="server" Text='<%#Eval("ExtraField17") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField18">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField18" runat="server" Text='<%#Eval("ExtraField18") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField19">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField19" runat="server" Text='<%#Eval("ExtraField19") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField20">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField20" runat="server" Text='<%#Eval("ExtraField20") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField21">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField21" runat="server" Text='<%#Eval("ExtraField21") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField22">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField22" runat="server" Text='<%#Eval("ExtraField22") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField23">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField23" runat="server" Text='<%#Eval("ExtraField23") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField24">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField24" runat="server" Text='<%#Eval("ExtraField24") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField25">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField25" runat="server" Text='<%#Eval("ExtraField25") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField26">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField26" runat="server" Text='<%#Eval("ExtraField26") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField27">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField27" runat="server" Text='<%#Eval("ExtraField27") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField28">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField28" runat="server" Text='<%#Eval("ExtraField28") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField29">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField29" runat="server" Text='<%#Eval("ExtraField29") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField30">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField30" runat="server" Text='<%#Eval("ExtraField30") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StatusID">
                    <ItemTemplate>
                        <asp:Label ID="lblStatusID" runat="server" Text='<%#Eval("StatusID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RowStatusID">
                    <ItemTemplate>
                        <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country1">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry1" runat="server" Text='<%#Eval("Country1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country2">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry2" runat="server" Text='<%#Eval("Country2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country3">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry3" runat="server" Text='<%#Eval("Country3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField31">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField31" runat="server" Text='<%#Eval("ExtraField31") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField32">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField32" runat="server" Text='<%#Eval("ExtraField32") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField33">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField33" runat="server" Text='<%#Eval("ExtraField33") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField34">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField34" runat="server" Text='<%#Eval("ExtraField34") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField35">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField35" runat="server" Text='<%#Eval("ExtraField35") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField36">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField36" runat="server" Text='<%#Eval("ExtraField36") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField37">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField37" runat="server" Text='<%#Eval("ExtraField37") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField38">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField38" runat="server" Text='<%#Eval("ExtraField38") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField39">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField39" runat="server" Text='<%#Eval("ExtraField39") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField40">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField40" runat="server" Text='<%#Eval("ExtraField40") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ApplicationID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
