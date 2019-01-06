using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminApplicationInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadRepresentative();
            loadApplicantType();
            loadIntroduceYourself();
            loadHearAboutUs();
            loadNationality();
            loadCourse();
            loadSecurityQuestion();
            loadStatus();
            loadRowStatus();
            if (Request.QueryString["applicationID"] != null)
            {
                int applicationID = Int32.Parse(Request.QueryString["applicationID"]);
                if (applicationID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showApplicationData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Application application = new Application();

        application.ControlNo = txtControlNo.Text;
        application.RepresentativeID = Int32.Parse(ddlRepresentative.SelectedValue);
        application.ApplicantTypeID = Int32.Parse(ddlApplicantType.SelectedValue);
        application.IntroduceYourselfID = Int32.Parse(ddlIntroduceYourself.SelectedValue);
        application.HearAboutUsID = Int32.Parse(ddlHearAboutUs.SelectedValue);
        application.NationalityID = Int32.Parse(ddlNationality.SelectedValue);
        application.CourseID = Int32.Parse(ddlCourse.SelectedValue);
        application.SecurityQuestionID = Int32.Parse(ddlSecurityQuestion.SelectedValue);
        application.SecurityQuestionAnswer = txtSecurityQuestionAnswer.Text;
        application.PassportNumber = txtPassportNumber.Text;
        application.ApplicantName = txtApplicantName.Text;
        application.DateOfBirth = txtDateOfBirth.Text;
        application.Sex = txtSex.Text;
        application.Email = txtEmail.Text;
        application.AltEmail = txtAltEmail.Text;
        application.MaritalStatus = txtMaritalStatus.Text;
        application.PersonalMobileNumber = txtPersonalMobileNumber.Text;
        application.PassportIssuedPlace = txtPassportIssuedPlace.Text;
        application.PassportIssueDate = txtPassportIssueDate.Text;
        application.PassportExpiryDate = txtPassportExpiryDate.Text;
        application.Visa = cbVisa.Checked;
        application.VisaExpiryDate = txtVisaExpiryDate.Text;
        application.ReleaseLetterIssued = txtReleaseLetterIssued.Text;
        application.NameOfCollegeUniv = txtNameOfCollegeUniv.Text;
        application.VisaType = txtVisaType.Text;
        application.ExtraField1 = txtExtraField1.Text;
        application.ExtraField2 = txtExtraField2.Text;
        application.ExtraField3 = txtExtraField3.Text;
        application.ExtraField4 = txtExtraField4.Text;
        application.ExtraField5 = txtExtraField5.Text;
        application.ExtraField6 = txtExtraField6.Text;
        application.ExtraField7 = txtExtraField7.Text;
        application.ExtraField8 = txtExtraField8.Text;
        application.ExtraField9 = txtExtraField9.Text;
        application.ExtraField10 = txtExtraField10.Text;
        application.ExtraField11 = txtExtraField11.Text;
        application.ExtraField12 = txtExtraField12.Text;
        application.ExtraField13 = txtExtraField13.Text;
        application.ExtraField14 = txtExtraField14.Text;
        application.ExtraField15 = txtExtraField15.Text;
        application.ExtraField16 = txtExtraField16.Text;
        application.ExtraField17 = txtExtraField17.Text;
        application.ExtraField18 = txtExtraField18.Text;
        application.ExtraField19 = txtExtraField19.Text;
        application.ExtraField20 = txtExtraField20.Text;
        application.ExtraField21 = txtExtraField21.Text;
        application.ExtraField22 = txtExtraField22.Text;
        application.ExtraField23 = txtExtraField23.Text;
        application.ExtraField24 = txtExtraField24.Text;
        application.ExtraField25 = txtExtraField25.Text;
        application.ExtraField26 = txtExtraField26.Text;
        application.ExtraField27 = txtExtraField27.Text;
        application.ExtraField28 = txtExtraField28.Text;
        application.ExtraField29 = txtExtraField29.Text;
        application.ExtraField30 = txtExtraField30.Text;
        application.StatusID = Int32.Parse(ddlStatus.SelectedValue);
        application.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        application.Country1 = txtCountry1.Text;
        application.Country2 = txtCountry2.Text;
        application.Country3 = txtCountry3.Text;
        application.ExtraField31 = txtExtraField31.Text;
        application.ExtraField32 = txtExtraField32.Text;
        application.ExtraField33 = txtExtraField33.Text;
        application.ExtraField34 = txtExtraField34.Text;
        application.ExtraField35 = txtExtraField35.Text;
        application.ExtraField36 = txtExtraField36.Text;
        application.ExtraField37 = txtExtraField37.Text;
        application.ExtraField38 = txtExtraField38.Text;
        application.ExtraField39 = txtExtraField39.Text;
        application.ExtraField40 = txtExtraField40.Text;
        int resutl = ApplicationManager.InsertApplication(application);
        Response.Redirect("AdminApplicationDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Application application = new Application();
        application = ApplicationManager.GetApplicationByID(Int32.Parse(Request.QueryString["applicationID"]));
        Application tempApplication = new Application();
        tempApplication.ApplicationID = application.ApplicationID;

        tempApplication.ControlNo = txtControlNo.Text;
        tempApplication.RepresentativeID = Int32.Parse(ddlRepresentative.SelectedValue);
        tempApplication.ApplicantTypeID = Int32.Parse(ddlApplicantType.SelectedValue);
        tempApplication.IntroduceYourselfID = Int32.Parse(ddlIntroduceYourself.SelectedValue);
        tempApplication.HearAboutUsID = Int32.Parse(ddlHearAboutUs.SelectedValue);
        tempApplication.NationalityID = Int32.Parse(ddlNationality.SelectedValue);
        tempApplication.CourseID = Int32.Parse(ddlCourse.SelectedValue);
        tempApplication.SecurityQuestionID = Int32.Parse(ddlSecurityQuestion.SelectedValue);
        tempApplication.SecurityQuestionAnswer = txtSecurityQuestionAnswer.Text;
        tempApplication.PassportNumber = txtPassportNumber.Text;
        tempApplication.ApplicantName = txtApplicantName.Text;
        tempApplication.DateOfBirth = txtDateOfBirth.Text;
        tempApplication.Sex = txtSex.Text;
        tempApplication.Email = txtEmail.Text;
        tempApplication.AltEmail = txtAltEmail.Text;
        tempApplication.MaritalStatus = txtMaritalStatus.Text;
        tempApplication.PersonalMobileNumber = txtPersonalMobileNumber.Text;
        tempApplication.PassportIssuedPlace = txtPassportIssuedPlace.Text;
        tempApplication.PassportIssueDate = txtPassportIssueDate.Text;
        tempApplication.PassportExpiryDate = txtPassportExpiryDate.Text;
        tempApplication.Visa = cbVisa.Checked;
        tempApplication.VisaExpiryDate = txtVisaExpiryDate.Text;
        tempApplication.ReleaseLetterIssued = txtReleaseLetterIssued.Text;
        tempApplication.NameOfCollegeUniv = txtNameOfCollegeUniv.Text;
        tempApplication.VisaType = txtVisaType.Text;
        tempApplication.ExtraField1 = txtExtraField1.Text;
        tempApplication.ExtraField2 = txtExtraField2.Text;
        tempApplication.ExtraField3 = txtExtraField3.Text;
        tempApplication.ExtraField4 = txtExtraField4.Text;
        tempApplication.ExtraField5 = txtExtraField5.Text;
        tempApplication.ExtraField6 = txtExtraField6.Text;
        tempApplication.ExtraField7 = txtExtraField7.Text;
        tempApplication.ExtraField8 = txtExtraField8.Text;
        tempApplication.ExtraField9 = txtExtraField9.Text;
        tempApplication.ExtraField10 = txtExtraField10.Text;
        tempApplication.ExtraField11 = txtExtraField11.Text;
        tempApplication.ExtraField12 = txtExtraField12.Text;
        tempApplication.ExtraField13 = txtExtraField13.Text;
        tempApplication.ExtraField14 = txtExtraField14.Text;
        tempApplication.ExtraField15 = txtExtraField15.Text;
        tempApplication.ExtraField16 = txtExtraField16.Text;
        tempApplication.ExtraField17 = txtExtraField17.Text;
        tempApplication.ExtraField18 = txtExtraField18.Text;
        tempApplication.ExtraField19 = txtExtraField19.Text;
        tempApplication.ExtraField20 = txtExtraField20.Text;
        tempApplication.ExtraField21 = txtExtraField21.Text;
        tempApplication.ExtraField22 = txtExtraField22.Text;
        tempApplication.ExtraField23 = txtExtraField23.Text;
        tempApplication.ExtraField24 = txtExtraField24.Text;
        tempApplication.ExtraField25 = txtExtraField25.Text;
        tempApplication.ExtraField26 = txtExtraField26.Text;
        tempApplication.ExtraField27 = txtExtraField27.Text;
        tempApplication.ExtraField28 = txtExtraField28.Text;
        tempApplication.ExtraField29 = txtExtraField29.Text;
        tempApplication.ExtraField30 = txtExtraField30.Text;
        tempApplication.StatusID = Int32.Parse(ddlStatus.SelectedValue);
        tempApplication.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        tempApplication.Country1 = txtCountry1.;
        tempApplication.Country2 = txtCountry2.Text;
        tempApplication.Country3 = txtCountry3.Text;
        tempApplication.ExtraField31 = txtExtraField31.Text;
        tempApplication.ExtraField32 = txtExtraField32.Text;
        tempApplication.ExtraField33 = txtExtraField33.Text;
        tempApplication.ExtraField34 = txtExtraField34.Text;
        tempApplication.ExtraField35 = txtExtraField35.Text;
        tempApplication.ExtraField36 = txtExtraField36.Text;
        tempApplication.ExtraField37 = txtExtraField37.Text;
        tempApplication.ExtraField38 = txtExtraField38.Text;
        tempApplication.ExtraField39 = txtExtraField39.Text;
        tempApplication.ExtraField40 = txtExtraField40.Text;
        bool result = ApplicationManager.UpdateApplication(tempApplication);
        Response.Redirect("AdminApplicationDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtControlNo.Text = "";
        ddlRepresentative.SelectedIndex = 0;
        ddlApplicantType.SelectedIndex = 0;
        ddlIntroduceYourself.SelectedIndex = 0;
        ddlHearAboutUs.SelectedIndex = 0;
        ddlNationality.SelectedIndex = 0;
        ddlCourse.SelectedIndex = 0;
        ddlSecurityQuestion.SelectedIndex = 0;
        txtSecurityQuestionAnswer.Text = "";
        txtPassportNumber.Text = "";
        txtApplicantName.Text = "";
        txtDateOfBirth.Text = "";
        txtSex.Text = "";
        txtEmail.Text = "";
        txtAltEmail.Text = "";
        txtMaritalStatus.Text = "";
        txtPersonalMobileNumber.Text = "";
        txtPassportIssuedPlace.Text = "";
        txtPassportIssueDate.Text = "";
        txtPassportExpiryDate.Text = "";
        cbVisa.Checked = false;
        txtVisaExpiryDate.Text = "";
        txtReleaseLetterIssued.Text = "";
        txtNameOfCollegeUniv.Text = "";
        txtVisaType.Text = "";
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
        txtExtraField6.Text = "";
        txtExtraField7.Text = "";
        txtExtraField8.Text = "";
        txtExtraField9.Text = "";
        txtExtraField10.Text = "";
        txtExtraField11.Text = "";
        txtExtraField12.Text = "";
        txtExtraField13.Text = "";
        txtExtraField14.Text = "";
        txtExtraField15.Text = "";
        txtExtraField16.Text = "";
        txtExtraField17.Text = "";
        txtExtraField18.Text = "";
        txtExtraField19.Text = "";
        txtExtraField20.Text = "";
        txtExtraField21.Text = "";
        txtExtraField22.Text = "";
        txtExtraField23.Text = "";
        txtExtraField24.Text = "";
        txtExtraField25.Text = "";
        txtExtraField26.Text = "";
        txtExtraField27.Text = "";
        txtExtraField28.Text = "";
        txtExtraField29.Text = "";
        txtExtraField30.Text = "";
        ddlStatus.SelectedIndex = 0;
        ddlRowStatus.SelectedIndex = 0;
        txtCountry1.Text = "";
        txtCountry2.Text = "";
        txtCountry3.Text = "";
        txtExtraField31.Text = "";
        txtExtraField32.Text = "";
        txtExtraField33.Text = "";
        txtExtraField34.Text = "";
        txtExtraField35.Text = "";
        txtExtraField36.Text = "";
        txtExtraField37.Text = "";
        txtExtraField38.Text = "";
        txtExtraField39.Text = "";
        txtExtraField40.Text = "";
    }
    private void showApplicationData()
    {
        Application application = new Application();
        application = ApplicationManager.GetApplicationByID(Int32.Parse(Request.QueryString["applicationID"]));

        txtControlNo.Text = application.ControlNo;
        ddlRepresentative.SelectedValue = application.RepresentativeID.ToString();
        ddlApplicantType.SelectedValue = application.ApplicantTypeID.ToString();
        ddlIntroduceYourself.SelectedValue = application.IntroduceYourselfID.ToString();
        ddlHearAboutUs.SelectedValue = application.HearAboutUsID.ToString();
        ddlNationality.SelectedValue = application.NationalityID.ToString();
        ddlCourse.SelectedValue = application.CourseID.ToString();
        ddlSecurityQuestion.SelectedValue = application.SecurityQuestionID.ToString();
        txtSecurityQuestionAnswer.Text = application.SecurityQuestionAnswer;
        txtPassportNumber.Text = application.PassportNumber;
        txtApplicantName.Text = application.ApplicantName;
        txtDateOfBirth.Text = application.DateOfBirth;
        txtSex.Text = application.Sex;
        txtEmail.Text = application.Email;
        txtAltEmail.Text = application.AltEmail;
        txtMaritalStatus.Text = application.MaritalStatus;
        txtPersonalMobileNumber.Text = application.PersonalMobileNumber;
        txtPassportIssuedPlace.Text = application.PassportIssuedPlace;
        txtPassportIssueDate.Text = application.PassportIssueDate;
        txtPassportExpiryDate.Text = application.PassportExpiryDate;
        cbVisa.Checked = application.IsFeature;
        txtVisaExpiryDate.Text = application.VisaExpiryDate;
        txtReleaseLetterIssued.Text = application.ReleaseLetterIssued;
        txtNameOfCollegeUniv.Text = application.NameOfCollegeUniv;
        txtVisaType.Text = application.VisaType;
        txtExtraField1.Text = application.ExtraField1;
        txtExtraField2.Text = application.ExtraField2;
        txtExtraField3.Text = application.ExtraField3;
        txtExtraField4.Text = application.ExtraField4;
        txtExtraField5.Text = application.ExtraField5;
        txtExtraField6.Text = application.ExtraField6;
        txtExtraField7.Text = application.ExtraField7;
        txtExtraField8.Text = application.ExtraField8;
        txtExtraField9.Text = application.ExtraField9;
        txtExtraField10.Text = application.ExtraField10;
        txtExtraField11.Text = application.ExtraField11;
        txtExtraField12.Text = application.ExtraField12;
        txtExtraField13.Text = application.ExtraField13;
        txtExtraField14.Text = application.ExtraField14;
        txtExtraField15.Text = application.ExtraField15;
        txtExtraField16.Text = application.ExtraField16;
        txtExtraField17.Text = application.ExtraField17;
        txtExtraField18.Text = application.ExtraField18;
        txtExtraField19.Text = application.ExtraField19;
        txtExtraField20.Text = application.ExtraField20;
        txtExtraField21.Text = application.ExtraField21;
        txtExtraField22.Text = application.ExtraField22;
        txtExtraField23.Text = application.ExtraField23;
        txtExtraField24.Text = application.ExtraField24;
        txtExtraField25.Text = application.ExtraField25;
        txtExtraField26.Text = application.ExtraField26;
        txtExtraField27.Text = application.ExtraField27;
        txtExtraField28.Text = application.ExtraField28;
        txtExtraField29.Text = application.ExtraField29;
        txtExtraField30.Text = application.ExtraField30;
        ddlStatus.SelectedValue = application.StatusID.ToString();
        ddlRowStatus.SelectedValue = application.RowStatusID.ToString();
        txtCountry1.Text = application.Country1;
        txtCountry2.Text = application.Country2;
        txtCountry3.Text = application.Country3;
        txtExtraField31.Text = application.ExtraField31;
        txtExtraField32.Text = application.ExtraField32;
        txtExtraField33.Text = application.ExtraField33;
        txtExtraField34.Text = application.ExtraField34;
        txtExtraField35.Text = application.ExtraField35;
        txtExtraField36.Text = application.ExtraField36;
        txtExtraField37.Text = application.ExtraField37;
        txtExtraField38.Text = application.ExtraField38;
        txtExtraField39.Text = application.ExtraField39;
        txtExtraField40.Text = application.ExtraField40;
    }
    private void loadRepresentative()
    {
        ListItem li = new ListItem("Select Representative...", "0");
        ddlRepresentative.Items.Add(li);

        List<Representative> representatives = new List<Representative>();
        representatives = RepresentativeManager.GetAllRepresentatives();
        foreach (Representative representative in representatives)
        {
            ListItem item = new ListItem(representative.RepresentativeName.ToString(), representative.RepresentativeID.ToString());
            ddlRepresentative.Items.Add(item);
        }
    }
    private void loadApplicantType()
    {
        ListItem li = new ListItem("Select ApplicantType...", "0");
        ddlApplicantType.Items.Add(li);

        List<ApplicantType> applicantTypes = new List<ApplicantType>();
        applicantTypes = ApplicantTypeManager.GetAllApplicantTypes();
        foreach (ApplicantType applicantType in applicantTypes)
        {
            ListItem item = new ListItem(applicantType.ApplicantTypeName.ToString(), applicantType.ApplicantTypeID.ToString());
            ddlApplicantType.Items.Add(item);
        }
    }
    private void loadIntroduceYourself()
    {
        ListItem li = new ListItem("Select IntroduceYourself...", "0");
        ddlIntroduceYourself.Items.Add(li);

        List<IntroduceYourself> introduceYourselfs = new List<IntroduceYourself>();
        introduceYourselfs = IntroduceYourselfManager.GetAllIntroduceYourselfs();
        foreach (IntroduceYourself introduceYourself in introduceYourselfs)
        {
            ListItem item = new ListItem(introduceYourself.IntroduceYourselfName.ToString(), introduceYourself.IntroduceYourselfID.ToString());
            ddlIntroduceYourself.Items.Add(item);
        }
    }
    private void loadHearAboutUs()
    {
        ListItem li = new ListItem("Select HearAboutUs...", "0");
        ddlHearAboutUs.Items.Add(li);

        List<HearAboutUs> hearAboutUss = new List<HearAboutUs>();
        hearAboutUss = HearAboutUsManager.GetAllHearAboutUss();
        foreach (HearAboutUs hearAboutUs in hearAboutUss)
        {
            ListItem item = new ListItem(hearAboutUs.HearAboutUsName.ToString(), hearAboutUs.HearAboutUsID.ToString());
            ddlHearAboutUs.Items.Add(item);
        }
    }
    private void loadNationality()
    {
        ListItem li = new ListItem("Select Nationality...", "0");
        ddlNationality.Items.Add(li);

        List<Nationality> nationalities = new List<Nationality>();
        nationalities = NationalityManager.GetAllNationalities();
        foreach (Nationality nationality in nationalities)
        {
            ListItem item = new ListItem(nationality.NationalityName.ToString(), nationality.NationalityID.ToString());
            ddlNationality.Items.Add(item);
        }
    }
    private void loadCourse()
    {
        ListItem li = new ListItem("Select Course...", "0");
        ddlCourse.Items.Add(li);

        List<Course> courses = new List<Course>();
        courses = CourseManager.GetAllCourses();
        foreach (Course course in courses)
        {
            ListItem item = new ListItem(course.CourseName.ToString(), course.CourseID.ToString());
            ddlCourse.Items.Add(item);
        }
    }
    private void loadSecurityQuestion()
    {
        ListItem li = new ListItem("Select SecurityQuestion...", "0");
        ddlSecurityQuestion.Items.Add(li);

        List<SecurityQuestion> securityQuestions = new List<SecurityQuestion>();
        securityQuestions = SecurityQuestionManager.GetAllSecurityQuestions();
        foreach (SecurityQuestion securityQuestion in securityQuestions)
        {
            ListItem item = new ListItem(securityQuestion.SecurityQuestionName.ToString(), securityQuestion.SecurityQuestionID.ToString());
            ddlSecurityQuestion.Items.Add(item);
        }
    }
    private void loadStatus()
    {
        ListItem li = new ListItem("Select Status...", "0");
        ddlStatus.Items.Add(li);

        List<Status> statuss = new List<Status>();
        statuss = StatusManager.GetAllStatuss();
        foreach (Status status in statuss)
        {
            ListItem item = new ListItem(status.StatusName.ToString(), status.StatusID.ToString());
            ddlStatus.Items.Add(item);
        }
    }
    private void loadRowStatus()
    {
        ListItem li = new ListItem("Select RowStatus...", "0");
        ddlRowStatus.Items.Add(li);

        List<RowStatus> rowStatuss = new List<RowStatus>();
        rowStatuss = RowStatusManager.GetAllRowStatuss();
        foreach (RowStatus rowStatus in rowStatuss)
        {
            ListItem item = new ListItem(rowStatus.RowStatusName.ToString(), rowStatus.RowStatusID.ToString());
            ddlRowStatus.Items.Add(item);
        }
    }
}
