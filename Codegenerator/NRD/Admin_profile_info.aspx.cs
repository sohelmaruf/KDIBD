using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_profile_info : System.Web.UI.Page
{
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadLoginInHiddenField();
            LoadDropdownlist();
            loadAllData();
            LoadDefaultData();
            if (CommonManager.SQLInjectionChecking(Request.QueryString["saved"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Saved Successfully..";
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["delete"]) != null)
            {
                Delete_profile_info();
                Response.Redirect("Admin_profile_info.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_profile_info();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_profile_info()
    {
        try
        {
            string sql=@"Select * from [profile_info] where profile_info_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_NRD(sql).Tables[0].Rows[0];
            
            txtFirst_Name.Text = dr["First_Name"].ToString();
            txtMiddle_Name.Text = dr["Middle_Name"].ToString();
            txtLast_Name.Text = dr["Last_Name"].ToString();
            txtGender.Text = dr["Gender"].ToString();
            txtAddress_Line_1.Text = dr["Address_Line_1"].ToString();
            txtAddress_Line_2.Text = dr["Address_Line_2"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtZip.Text = dr["Zip"].ToString();
            txtSpouse_Name.Text = dr["Spouse_Name"].ToString();
            txtCell_Phone.Text = dr["Cell_Phone"].ToString();
            txtWork_Phone.Text = dr["Work_Phone"].ToString();
            txtEmail_aaddress_1.Text = dr["Email_aaddress_1"].ToString();
            txtEmail_aaddress_2.Text = dr["Email_aaddress_2"].ToString();
            txtCurrent_Affiliation.Text = dr["Current_Affiliation"].ToString();
            txtYealy_Income_Range.Text = dr["Yealy_Income_Range"].ToString();
            txtPrevious_Employment_1.Text = dr["Previous_Employment_1"].ToString();
            txtPrevious_Employment_2.Text = dr["Previous_Employment_2"].ToString();
            txtMajor_Subject_1.Text = dr["Major_Subject_1"].ToString();
            txtMajor_Subject_2.Text = dr["Major_Subject_2"].ToString();
            txtMajor_Subject_3.Text = dr["Major_Subject_3"].ToString();
            txtPublication_Link.Text = dr["Publication_Link"].ToString();
            txtExpertise_Area.Text = dr["Expertise_Area"].ToString();
            txtLinkedin_Profile.Text = dr["Linkedin_Profile"].ToString();
            txtFacebook_Profile.Text = dr["Facebook_Profile"].ToString();
            txtJob_Seeker.Text = dr["Job_Seeker"].ToString();
            txtprofile_info.Text = Decimal.Parse(dr["profile_info"].ToString()).ToString("0,0");
            ddlEducational_Institution_1_ID.SelectedValue = dr["Educational_Institution_1_ID"].ToString();
            ddlEducational_Institution_2_ID.SelectedValue = dr["Educational_Institution_2_ID"].ToString();
            ddlEducational_Institution_3_ID.SelectedValue = dr["Educational_Institution_3_ID"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_profile_info()
    {
        try
        {
            string sql=@"Delete [profile_info] where profile_info_ID = "+Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec_NRD(sql);
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }  
    private void loadLoginInHiddenField()
    {
        if (hfLoginID.Value == "")
        {
            hfLoginID.Value = getLogin().LoginID.ToString();
        }
    }

    private Login getLogin()
    {
        Login login = new Login();

        try
        {
            if (Session["Login"] != null)
            {
                login = (Login)Session["Login"];
            }
            else if (hfLoginID.Value != "")
            {
                login = LoginManager.GetLoginByID(int.Parse(hfLoginID.Value));
            }
            else
            { Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); }

        }
        catch (Exception ex)
        { }

        return login;
    }

    private void LoadDropdownlist()
    {
        try
        {
            DataSet ds = new DataSet();
            try
            {
                string sql=@"
                    select Educational_Institution_1_ID, Educational_Institution_1_Name from [Educational_Institution_1]
                    order by Educational_Institution_1_Name
                    select Educational_Institution_2_ID, Educational_Institution_2_Name from [Educational_Institution_2]
                    order by Educational_Institution_2_Name
                    select Educational_Institution_3_ID, Educational_Institution_3_Name from [Educational_Institution_3]
                    order by Educational_Institution_3_Name";
                if(sql!="")
                ds = CommonManager.SQLExec_NRD(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
            }



            ddlEducational_Institution_1_ID.Items.Clear();
            ddlEducational_Institution_1_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlEducational_Institution_1_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlEducational_Institution_2_ID.Items.Clear();
            ddlEducational_Institution_2_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ddlEducational_Institution_2_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlEducational_Institution_3_ID.Items.Clear();
            ddlEducational_Institution_3_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ddlEducational_Institution_3_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    private void loadAllData()
    {
        try
        {
            string sql = @"Select 
                [profile_info].profile_info
                ,[profile_info].First_Name
                ,[profile_info].Middle_Name
                ,[profile_info].Last_Name
                ,[profile_info].Gender
                ,[profile_info].Address_Line_1
                ,[profile_info].Address_Line_2
                ,[profile_info].City
                ,[profile_info].State
                ,[profile_info].Zip
                ,[profile_info].Spouse_Name
                ,[profile_info].Cell_Phone
                ,[profile_info].Work_Phone
                ,[profile_info].Email_aaddress_1
                ,[profile_info].Email_aaddress_2
                ,[profile_info].Current_Affiliation
                ,[profile_info].Yealy_Income_Range
                ,[profile_info].Previous_Employment_1
                ,[profile_info].Previous_Employment_2
                ,[Educational_Institution_1].Educational_Institution_1_Name
                ,[Educational_Institution_2].Educational_Institution_2_Name
                ,[Educational_Institution_3].Educational_Institution_3_Name
                ,[profile_info].Major_Subject_1
                ,[profile_info].Major_Subject_2
                ,[profile_info].Major_Subject_3
                ,[profile_info].Publication_Link
                ,[profile_info].Expertise_Area
                ,[profile_info].Linkedin_Profile
                ,[profile_info].Facebook_Profile
                ,[profile_info].Job_Seeker
         from [profile_info]
            inner join [Educational_Institution_1] on [Educational_Institution_1].Educational_Institution_1_ID = [profile_info].Educational_Institution_1_ID
            inner join [Educational_Institution_2] on [Educational_Institution_2].Educational_Institution_2_ID = [profile_info].Educational_Institution_2_ID
            inner join [Educational_Institution_3] on [Educational_Institution_3].Educational_Institution_3_ID = [profile_info].Educational_Institution_3_ID
        order by [profile_info].profile_info_Name";
        DataSet ds = CommonManager.SQLExec_NRD(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>profile info</th>
                <th>First Name</th>
                <th>Middle Name</th>
                <th>Last Name</th>
                <th>Gender</th>
                <th>Address Line 1</th>
                <th>Address Line 2</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Spouse Name</th>
                <th>Cell Phone</th>
                <th>Work Phone</th>
                <th>Email aaddress 1</th>
                <th>Email aaddress 2</th>
                <th>Current Affiliation</th>
                <th>Yealy Income Range</th>
                <th>Previous Employment 1</th>
                <th>Previous Employment 2</th>
                <th>Educational Institution 1</th>
                <th>Educational Institution 2</th>
                <th>Educational Institution 3</th>
                <th>Major Subject 1</th>
                <th>Major Subject 2</th>
                <th>Major Subject 3</th>
                <th>Publication Link</th>
                <th>Expertise Area</th>
                <th>Linkedin Profile</th>
                <th>Facebook Profile</th>
                <th>Job Seeker</th>
                                </tr>
                            </thead>
                            <tbody>";int count=0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            
            if (count++ % 2 == 0)
            {
                html += @"
                <tr class='odd gradeX'>";
            }
            else
            {
                html += @"
                <tr class='even gradeX'>";
            }

            html +=@"
                
                            <td>"+decimal.Parse(dr["profile_info"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+dr["First_Name"].ToString()+@"</td>
                
                            <td>"+dr["Middle_Name"].ToString()+@"</td>
                
                            <td>"+dr["Last_Name"].ToString()+@"</td>
                
                            <td>"+dr["Gender"].ToString()+@"</td>
                
                            <td>"+dr["Address_Line_1"].ToString()+@"</td>
                
                            <td>"+dr["Address_Line_2"].ToString()+@"</td>
                
                            <td>"+dr["City"].ToString()+@"</td>
                
                            <td>"+dr["State"].ToString()+@"</td>
                
                            <td>"+dr["Zip"].ToString()+@"</td>
                
                            <td>"+dr["Spouse_Name"].ToString()+@"</td>
                
                            <td>"+dr["Cell_Phone"].ToString()+@"</td>
                
                            <td>"+dr["Work_Phone"].ToString()+@"</td>
                
                            <td>"+dr["Email_aaddress_1"].ToString()+@"</td>
                
                            <td>"+dr["Email_aaddress_2"].ToString()+@"</td>
                
                            <td>"+dr["Current_Affiliation"].ToString()+@"</td>
                
                            <td>"+dr["Yealy_Income_Range"].ToString()+@"</td>
                
                            <td>"+dr["Previous_Employment_1"].ToString()+@"</td>
                
                            <td>"+dr["Previous_Employment_2"].ToString()+@"</td>
                
                            <td>"+dr["Educational_Institution_1_Name"].ToString()+@"</td>
                
                            <td>"+dr["Educational_Institution_2_Name"].ToString()+@"</td>
                
                            <td>"+dr["Educational_Institution_3_Name"].ToString()+@"</td>
                
                            <td>"+dr["Major_Subject_1"].ToString()+@"</td>
                
                            <td>"+dr["Major_Subject_2"].ToString()+@"</td>
                
                            <td>"+dr["Major_Subject_3"].ToString()+@"</td>
                
                            <td>"+dr["Publication_Link"].ToString()+@"</td>
                
                            <td>"+dr["Expertise_Area"].ToString()+@"</td>
                
                            <td>"+dr["Linkedin_Profile"].ToString()+@"</td>
                
                            <td>"+dr["Facebook_Profile"].ToString()+@"</td>
                
                            <td>"+dr["Job_Seeker"].ToString()+@"</td>
                    </tr>";
            }

            html +=@"

                                    </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>";
            lblList.Text=html;

        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    private void LoadDefaultData()
    {
        
        txtprofile_info.Text="0";
        ddlEducational_Institution_1_ID.SelectedValue="0";
        ddlEducational_Institution_2_ID.SelectedValue="0";
        ddlEducational_Institution_3_ID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_profile_info_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_profile_info_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_profile_info_Action()
    {
        string sql=@"INSERT INTO [profile_info]
                (
                profile_info,
                First_Name,
                Middle_Name,
                Last_Name,
                Gender,
                Address_Line_1,
                Address_Line_2,
                City,
                State,
                Zip,
                Spouse_Name,
                Cell_Phone,
                Work_Phone,
                Email_aaddress_1,
                Email_aaddress_2,
                Current_Affiliation,
                Yealy_Income_Range,
                Previous_Employment_1,
                Previous_Employment_2,
                Educational_Institution_1_ID,
                Educational_Institution_2_ID,
                Educational_Institution_3_ID,
                Major_Subject_1,
                Major_Subject_2,
                Major_Subject_3,
                Publication_Link,
                Expertise_Area,
                Linkedin_Profile,
                Facebook_Profile,
                Job_Seeker)
                Values(
                "+CommonManager.SQLInjectionChecking(txtprofile_info.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtFirst_Name.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtMiddle_Name.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtLast_Name.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtGender.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress_Line_1.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress_Line_2.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtSpouse_Name.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCell_Phone.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtWork_Phone.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtEmail_aaddress_1.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtEmail_aaddress_2.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCurrent_Affiliation.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtYealy_Income_Range.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPrevious_Employment_1.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPrevious_Employment_2.Text)+@"',
                "+CommonManager.SQLInjectionChecking(ddlEducational_Institution_1_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlEducational_Institution_2_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlEducational_Institution_3_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtMajor_Subject_1.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtMajor_Subject_2.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtMajor_Subject_3.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPublication_Link.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtExpertise_Area.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtLinkedin_Profile.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFacebook_Profile.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtJob_Seeker.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_NRD(sql);
        Response.Redirect("Admin_profile_info.aspx?saved=1");
            
    }

    protected void Edit_profile_info_Action()
    {
        string sql=@"Update [profile_info]
                Set
                profile_info="+CommonManager.SQLInjectionChecking(txtprofile_info.Text.Replace(",",""))+@",
                First_Name='"+CommonManager.SQLInjectionChecking(txtFirst_Name.Text)+@"',
                Middle_Name='"+CommonManager.SQLInjectionChecking(txtMiddle_Name.Text)+@"',
                Last_Name='"+CommonManager.SQLInjectionChecking(txtLast_Name.Text)+@"',
                Gender='"+CommonManager.SQLInjectionChecking(txtGender.Text)+@"',
                Address_Line_1='"+CommonManager.SQLInjectionChecking(txtAddress_Line_1.Text)+@"',
                Address_Line_2='"+CommonManager.SQLInjectionChecking(txtAddress_Line_2.Text)+@"',
                City='"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                State='"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                Zip='"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                Spouse_Name='"+CommonManager.SQLInjectionChecking(txtSpouse_Name.Text)+@"',
                Cell_Phone='"+CommonManager.SQLInjectionChecking(txtCell_Phone.Text)+@"',
                Work_Phone='"+CommonManager.SQLInjectionChecking(txtWork_Phone.Text)+@"',
                Email_aaddress_1='"+CommonManager.SQLInjectionChecking(txtEmail_aaddress_1.Text)+@"',
                Email_aaddress_2='"+CommonManager.SQLInjectionChecking(txtEmail_aaddress_2.Text)+@"',
                Current_Affiliation='"+CommonManager.SQLInjectionChecking(txtCurrent_Affiliation.Text)+@"',
                Yealy_Income_Range='"+CommonManager.SQLInjectionChecking(txtYealy_Income_Range.Text)+@"',
                Previous_Employment_1='"+CommonManager.SQLInjectionChecking(txtPrevious_Employment_1.Text)+@"',
                Previous_Employment_2='"+CommonManager.SQLInjectionChecking(txtPrevious_Employment_2.Text)+@"',
                Educational_Institution_1_ID="+CommonManager.SQLInjectionChecking(ddlEducational_Institution_1_ID.SelectedValue)+@",
                Educational_Institution_2_ID="+CommonManager.SQLInjectionChecking(ddlEducational_Institution_2_ID.SelectedValue)+@",
                Educational_Institution_3_ID="+CommonManager.SQLInjectionChecking(ddlEducational_Institution_3_ID.SelectedValue)+@",
                Major_Subject_1='"+CommonManager.SQLInjectionChecking(txtMajor_Subject_1.Text)+@"',
                Major_Subject_2='"+CommonManager.SQLInjectionChecking(txtMajor_Subject_2.Text)+@"',
                Major_Subject_3='"+CommonManager.SQLInjectionChecking(txtMajor_Subject_3.Text)+@"',
                Publication_Link='"+CommonManager.SQLInjectionChecking(txtPublication_Link.Text)+@"',
                Expertise_Area='"+CommonManager.SQLInjectionChecking(txtExpertise_Area.Text)+@"',
                Linkedin_Profile='"+CommonManager.SQLInjectionChecking(txtLinkedin_Profile.Text)+@"',
                Facebook_Profile='"+CommonManager.SQLInjectionChecking(txtFacebook_Profile.Text)+@"',
                Job_Seeker='"+CommonManager.SQLInjectionChecking(txtJob_Seeker.Text)+@"' 
        where profile_info_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_NRD(sql);
        Response.Redirect("Admin_profile_info.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtFirst_Name.Text="";
        txtMiddle_Name.Text="";
        txtLast_Name.Text="";
        txtGender.Text="";
        txtAddress_Line_1.Text="";
        txtAddress_Line_2.Text="";
        txtCity.Text="";
        txtState.Text="";
        txtZip.Text="";
        txtSpouse_Name.Text="";
        txtCell_Phone.Text="";
        txtWork_Phone.Text="";
        txtEmail_aaddress_1.Text="";
        txtEmail_aaddress_2.Text="";
        txtCurrent_Affiliation.Text="";
        txtYealy_Income_Range.Text="";
        txtPrevious_Employment_1.Text="";
        txtPrevious_Employment_2.Text="";
        txtMajor_Subject_1.Text="";
        txtMajor_Subject_2.Text="";
        txtMajor_Subject_3.Text="";
        txtPublication_Link.Text="";
        txtExpertise_Area.Text="";
        txtLinkedin_Profile.Text="";
        txtFacebook_Profile.Text="";
        txtJob_Seeker.Text="";
        txtprofile_info.Text="";
        ddlEducational_Institution_1_ID.SelectedValue="0";
        ddlEducational_Institution_2_ID.SelectedValue="0";
        ddlEducational_Institution_3_ID.SelectedValue="0";
    }

}
