using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NRB_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadAllData();
        }
    }
    private void loadAllData()
    {
        try
        {
            string sql = @"Select 
                p.profile_info_ID
                ,p.First_Name
                ,p.Middle_Name
                ,p.Last_Name
                ,p.Gender
                ,p.Address_Line_1
                ,p.Address_Line_2
                ,p.City
                ,p.State
                ,p.Zip
                ,p.Spouse_Name
                ,p.Cell_Phone
                ,p.Work_Phone
                ,p.Email_aaddress_1
                ,p.Email_aaddress_2
                ,p.Current_Affiliation
                ,p.Yealy_Income_Range
                ,p.Previous_Employment_1
                ,p.Previous_Employment_2
,i1.Educational_Institution_Name as Educational_Institution_1
                ,p.Major_Subject_1
,i2.Educational_Institution_Name as Educational_Institution_2
                ,p.Major_Subject_2
,i3.Educational_Institution_Name as Educational_Institution_3
                ,p.Major_Subject_3
                ,p.Publication_Link
                ,p.Expertise_Area
                ,p.Linkedin_Profile
                ,p.Facebook_Profile
                ,p.Job_Seeker
         from [profile_info] as p
inner join Educational_Institution as i1 on i1.Educational_Institution_ID=p.[Educational_Institution_1_ID]
inner join Educational_Institution as i2 on i2.Educational_Institution_ID=p.[Educational_Institution_2_ID]
inner join Educational_Institution as i3 on i3.Educational_Institution_ID=p.[Educational_Institution_3_ID]
            order by [p].First_Name";
            DataSet ds = CommonManager.SQLExec(sql);
            string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
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
                <th>Edu. Institution-1</th>
                <th>Major Subject 1</th>
                <th>Edu. Institution-2</th>
                <th>Major Subject 2</th>
                <th>Edu. Institution-3</th>
                <th>Major Subject 3</th>
                <th>Publication Link</th>
                <th>Expertise Area</th>
                <th>Linkedin Profile</th>
                <th>Facebook Profile</th>
                <th>Job Seeker</th>
                                </tr>
                            </thead>
                            <tbody>"; int count = 0;
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

                html += @"
                
                            <td><a href='default.aspx?edit=" + dr["profile_info_ID"].ToString() + @"'>Edit</a></td>
                
                            <td>" + dr["First_Name"].ToString() + @"</td>
                
                            <td>" + dr["Middle_Name"].ToString() + @"</td>
                
                            <td>" + dr["Last_Name"].ToString() + @"</td>
                
                            <td>" + dr["Gender"].ToString() + @"</td>
                
                            <td>" + dr["Address_Line_1"].ToString() + @"</td>
                
                            <td>" + dr["Address_Line_2"].ToString() + @"</td>
                
                            <td>" + dr["City"].ToString() + @"</td>
                
                            <td>" + dr["State"].ToString() + @"</td>
                
                            <td>" + dr["Zip"].ToString() + @"</td>
                
                            <td>" + dr["Spouse_Name"].ToString() + @"</td>
                
                            <td>" + dr["Cell_Phone"].ToString() + @"</td>
                
                            <td>" + dr["Work_Phone"].ToString() + @"</td>
                
                            <td>" + dr["Email_aaddress_1"].ToString() + @"</td>
                
                            <td>" + dr["Email_aaddress_2"].ToString() + @"</td>
                
                            <td>" + dr["Current_Affiliation"].ToString() + @"</td>
                
                            <td>" + dr["Yealy_Income_Range"].ToString() + @"</td>
                
                            <td>" + dr["Previous_Employment_1"].ToString() + @"</td>
                
                            <td>" + dr["Previous_Employment_2"].ToString() + @"</td>
                
                            <td>" + dr["Educational_Institution_1"].ToString() + @"</td>
                
                
                            <td>" + dr["Major_Subject_1"].ToString() + @"</td>
                
                            <td>" + dr["Educational_Institution_2"].ToString() + @"</td>
                            <td>" + dr["Major_Subject_2"].ToString() + @"</td>
                            <td>" + dr["Educational_Institution_3"].ToString() + @"</td>
                
                            <td>" + dr["Major_Subject_3"].ToString() + @"</td>
                
                            <td>" + dr["Publication_Link"].ToString() + @"</td>
                
                            <td>" + dr["Expertise_Area"].ToString() + @"</td>
                
                            <td>" + dr["Linkedin_Profile"].ToString() + @"</td>
                
                            <td>" + dr["Facebook_Profile"].ToString() + @"</td>
                
                            <td>" + dr["Job_Seeker"].ToString() + @"</td>
                    </tr>";
            }

            html += @"

                                    </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>";
            lblList.Text = html;

        }
        catch (Exception ex)
        {
        }
    }
}
