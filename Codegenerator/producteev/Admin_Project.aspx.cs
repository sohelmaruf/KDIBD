using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Project : System.Web.UI.Page
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
                Delete_Project();
                Response.Redirect("Admin_Project.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Project();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Project()
    {
        try
        {
            string sql=@"Select * from [Project] where Project_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_producteev(sql).Tables[0].Rows[0];
            
            txtAddressNumber.Text = dr["AddressNumber"].ToString();
            txtGeotechName.Text = dr["GeotechName"].ToString();
            txtprojectNumber.Text = dr["projectNumber"].ToString();
            txtPlan.Text = dr["Plan"].ToString();
            txtPlanNum.Text = dr["PlanNum"].ToString();
            txtAddressStreet.Text = dr["AddressStreet"].ToString();
            txtAddressSuite.Text = dr["AddressSuite"].ToString();
            txtAddressZip.Text = dr["AddressZip"].ToString();
            txtLot.Text = dr["Lot"].ToString();
            txtBlock.Text = dr["Block"].ToString();
            txtSubdivision.Text = dr["Subdivision"].ToString();
            txtReviewBy.Text = dr["ReviewBy"].ToString();
            txtprojectTypeNotes.Text = dr["projectTypeNotes"].ToString();
            txtSoilReportNo.Text = dr["SoilReportNo"].ToString();
            txtPierBells.Text = dr["PierBells"].ToString();
            txtMaterial_notes.Text = dr["Material_notes"].ToString();
            txtCustomer_data.Text = dr["Customer_data"].ToString();
            txtHold_note.Text = dr["Hold_note"].ToString();
            txtStartDate.Text = dr["StartDate"].ToString();
            txtDueDate.Text = dr["DueDate"].ToString();
            ddlStatus_ID.SelectedValue = dr["Status_ID"].ToString();
            ddlPriority_ID.SelectedValue = dr["Priority_ID"].ToString();
            ddlAddressCity_ID.SelectedValue = dr["AddressCity_ID"].ToString();
            ddlAddressState_ID.SelectedValue = dr["AddressState_ID"].ToString();
            ddlcustomer_ID.SelectedValue = dr["customer_ID"].ToString();
            ddlprojectType_ID.SelectedValue = dr["projectType_ID"].ToString();
            ddlPierType_ID.SelectedValue = dr["PierType_ID"].ToString();
            ddlPierDiameter_ID.SelectedValue = dr["PierDiameter_ID"].ToString();
            ddlFoundation_type_ID.SelectedValue = dr["Foundation_type_ID"].ToString();
            ddlCrawlSpaceJoists_ID.SelectedValue = dr["CrawlSpaceJoists_ID"].ToString();
            ddlCrawlSpaceGirders_ID.SelectedValue = dr["CrawlSpaceGirders_ID"].ToString();
            ddlJoist_floor_ID.SelectedValue = dr["Joist_floor_ID"].ToString();
            ddlJoist_spacing_ID.SelectedValue = dr["Joist_spacing_ID"].ToString();
            ddlJoist_ceiling_ID.SelectedValue = dr["Joist_ceiling_ID"].ToString();
            ddlRoofing_ID.SelectedValue = dr["Roofing_ID"].ToString();
            ddlRoofing_weight_ID.SelectedValue = dr["Roofing_weight_ID"].ToString();
            chkIs_projectSoil.Checked = bool.Parse(dr["Is_projectSoil"].ToString());
            chkIs_Pier.Checked = bool.Parse(dr["Is_Pier"].ToString());
            chkIs_Foundation.Checked = bool.Parse(dr["Is_Foundation"].ToString());
            chkIs_PierBeamFoundation.Checked = bool.Parse(dr["Is_PierBeamFoundation"].ToString());
            chkIs_Framing.Checked = bool.Parse(dr["Is_Framing"].ToString());
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Project()
    {
        try
        {
            string sql=@"Delete [Project] where Project_ID = "+Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec_producteev(sql);
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
                    select project_ID, project_Name from [project]
                    order by project_Name
                    select Status_ID, Status_Name from [Status]
                    order by Status_Name
                    select Priority_ID, Priority_Name from [Priority]
                    order by Priority_Name
                    select AddressCity_ID, AddressCity_Name from [AddressCity]
                    order by AddressCity_Name
                    select AddressState_ID, AddressState_Name from [AddressState]
                    order by AddressState_Name
                    select customer_ID, customer_Name from [customer]
                    order by customer_Name
                    select projectType_ID, projectType_Name from [projectType]
                    order by projectType_Name
                    select PierType_ID, PierType_Name from [PierType]
                    order by PierType_Name
                    select PierDiameter_ID, PierDiameter_Name from [PierDiameter]
                    order by PierDiameter_Name
                    select Foundation_type_ID, Foundation_type_Name from [Foundation_type]
                    order by Foundation_type_Name
                    select CrawlSpaceJoists_ID, CrawlSpaceJoists_Name from [CrawlSpaceJoists]
                    order by CrawlSpaceJoists_Name
                    select CrawlSpaceGirders_ID, CrawlSpaceGirders_Name from [CrawlSpaceGirders]
                    order by CrawlSpaceGirders_Name
                    select Joist_floor_ID, Joist_floor_Name from [Joist_floor]
                    order by Joist_floor_Name
                    select Joist_spacing_ID, Joist_spacing_Name from [Joist_spacing]
                    order by Joist_spacing_Name
                    select Joist_ceiling_ID, Joist_ceiling_Name from [Joist_ceiling]
                    order by Joist_ceiling_Name
                    select Roofing_ID, Roofing_Name from [Roofing]
                    order by Roofing_Name
                    select Roofing_weight_ID, Roofing_weight_Name from [Roofing_weight]
                    order by Roofing_weight_Name";
                if(sql!="")
                ds = CommonManager.SQLExec_producteev(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
            }



            ddlproject_ID.Items.Clear();
            ddlproject_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlproject_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlStatus_ID.Items.Clear();
            ddlStatus_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ddlStatus_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlPriority_ID.Items.Clear();
            ddlPriority_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ddlPriority_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlAddressCity_ID.Items.Clear();
            ddlAddressCity_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                ddlAddressCity_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlAddressState_ID.Items.Clear();
            ddlAddressState_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                ddlAddressState_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlcustomer_ID.Items.Clear();
            ddlcustomer_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[5].Rows)
            {
                ddlcustomer_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlprojectType_ID.Items.Clear();
            ddlprojectType_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[6].Rows)
            {
                ddlprojectType_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlPierType_ID.Items.Clear();
            ddlPierType_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[7].Rows)
            {
                ddlPierType_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlPierDiameter_ID.Items.Clear();
            ddlPierDiameter_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[8].Rows)
            {
                ddlPierDiameter_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlFoundation_type_ID.Items.Clear();
            ddlFoundation_type_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[9].Rows)
            {
                ddlFoundation_type_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlCrawlSpaceJoists_ID.Items.Clear();
            ddlCrawlSpaceJoists_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[10].Rows)
            {
                ddlCrawlSpaceJoists_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlCrawlSpaceGirders_ID.Items.Clear();
            ddlCrawlSpaceGirders_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[11].Rows)
            {
                ddlCrawlSpaceGirders_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlJoist_floor_ID.Items.Clear();
            ddlJoist_floor_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[12].Rows)
            {
                ddlJoist_floor_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlJoist_spacing_ID.Items.Clear();
            ddlJoist_spacing_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[13].Rows)
            {
                ddlJoist_spacing_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlJoist_ceiling_ID.Items.Clear();
            ddlJoist_ceiling_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[14].Rows)
            {
                ddlJoist_ceiling_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlRoofing_ID.Items.Clear();
            ddlRoofing_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[15].Rows)
            {
                ddlRoofing_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           
            ddlRoofing_weight_ID.Items.Clear();
            ddlRoofing_weight_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[16].Rows)
            {
                ddlRoofing_weight_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
                [project].project_Name
                ,[Project].projectNumber
                ,[Status].Status_Name
                ,[Priority].Priority_Name
                ,[Project].Plan
                ,[Project].PlanNum
                ,[Project].StartDate
                ,[Project].DueDate
                ,[Project].AddressNumber
                ,[Project].AddressStreet
                ,[Project].AddressSuite
                ,[AddressCity].AddressCity_Name
                ,[AddressState].AddressState_Name
                ,[Project].AddressZip
                ,[Project].Lot
                ,[Project].Block
                ,[Project].Subdivision
                ,[customer].customer_Name
                ,[Project].ReviewBy
                ,[projectType].projectType_Name
                ,[Project].projectTypeNotes
                ,[Project].Is_projectSoil
                ,[Project].GeotechName
                ,[Project].SoilReportNo
                ,[Project].Is_Pier
                ,[PierType].PierType_Name
                ,[PierDiameter].PierDiameter_Name
                ,[Project].PierBells
                ,[Project].Is_Foundation
                ,[Foundation_type].Foundation_type_Name
                ,[Project].Is_PierBeamFoundation
                ,[CrawlSpaceJoists].CrawlSpaceJoists_Name
                ,[CrawlSpaceGirders].CrawlSpaceGirders_Name
                ,[Project].Is_Framing
                ,[Joist_floor].Joist_floor_Name
                ,[Joist_spacing].Joist_spacing_Name
                ,[Joist_ceiling].Joist_ceiling_Name
                ,[Roofing].Roofing_Name
                ,[Roofing_weight].Roofing_weight_Name
                ,[Project].Material_notes
                ,[Project].Customer_data
                ,[Project].Hold_note
         from [Project]
            inner join [project] on [project].project_ID = [Project].project_ID
            inner join [Status] on [Status].Status_ID = [Project].Status_ID
            inner join [Priority] on [Priority].Priority_ID = [Project].Priority_ID
            inner join [AddressCity] on [AddressCity].AddressCity_ID = [Project].AddressCity_ID
            inner join [AddressState] on [AddressState].AddressState_ID = [Project].AddressState_ID
            inner join [customer] on [customer].customer_ID = [Project].customer_ID
            inner join [projectType] on [projectType].projectType_ID = [Project].projectType_ID
            inner join [PierType] on [PierType].PierType_ID = [Project].PierType_ID
            inner join [PierDiameter] on [PierDiameter].PierDiameter_ID = [Project].PierDiameter_ID
            inner join [Foundation_type] on [Foundation_type].Foundation_type_ID = [Project].Foundation_type_ID
            inner join [CrawlSpaceJoists] on [CrawlSpaceJoists].CrawlSpaceJoists_ID = [Project].CrawlSpaceJoists_ID
            inner join [CrawlSpaceGirders] on [CrawlSpaceGirders].CrawlSpaceGirders_ID = [Project].CrawlSpaceGirders_ID
            inner join [Joist_floor] on [Joist_floor].Joist_floor_ID = [Project].Joist_floor_ID
            inner join [Joist_spacing] on [Joist_spacing].Joist_spacing_ID = [Project].Joist_spacing_ID
            inner join [Joist_ceiling] on [Joist_ceiling].Joist_ceiling_ID = [Project].Joist_ceiling_ID
            inner join [Roofing] on [Roofing].Roofing_ID = [Project].Roofing_ID
            inner join [Roofing_weight] on [Roofing_weight].Roofing_weight_ID = [Project].Roofing_weight_ID
        order by [Project].Project_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>project</th>
                <th>projectNumber</th>
                <th>Status</th>
                <th>Priority</th>
                <th>Plan</th>
                <th>PlanNum</th>
                <th>StartDate</th>
                <th>DueDate</th>
                <th>AddressNumber</th>
                <th>AddressStreet</th>
                <th>AddressSuite</th>
                <th>AddressCity</th>
                <th>AddressState</th>
                <th>AddressZip</th>
                <th>Lot</th>
                <th>Block</th>
                <th>Subdivision</th>
                <th>customer</th>
                <th>ReviewBy</th>
                <th>projectType</th>
                <th>projectTypeNotes</th>
                <th>Is projectSoil</th>
                <th>GeotechName</th>
                <th>SoilReportNo</th>
                <th>Is Pier</th>
                <th>PierType</th>
                <th>PierDiameter</th>
                <th>PierBells</th>
                <th>Is Foundation</th>
                <th>Foundation type</th>
                <th>Is PierBeamFoundation</th>
                <th>CrawlSpaceJoists</th>
                <th>CrawlSpaceGirders</th>
                <th>Is Framing</th>
                <th>Joist floor</th>
                <th>Joist spacing</th>
                <th>Joist ceiling</th>
                <th>Roofing</th>
                <th>Roofing weight</th>
                <th>Material notes</th>
                <th>Customer data</th>
                <th>Hold note</th>
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
                
                            <td>"+dr["project_Name"].ToString()+@"</td>
                
                            <td>"+dr["projectNumber"].ToString()+@"</td>
                
                            <td>"+dr["Status_Name"].ToString()+@"</td>
                
                            <td>"+dr["Priority_Name"].ToString()+@"</td>
                
                            <td>"+dr["Plan"].ToString()+@"</td>
                
                            <td>"+dr["PlanNum"].ToString()+@"</td>
                
                            <td>"+dr["StartDate"].ToString()+@"</td>
                
                            <td>"+dr["DueDate"].ToString()+@"</td>
                
                            <td>"+dr["AddressNumber"].ToString()+@"</td>
                
                            <td>"+dr["AddressStreet"].ToString()+@"</td>
                
                            <td>"+dr["AddressSuite"].ToString()+@"</td>
                
                            <td>"+dr["AddressCity_Name"].ToString()+@"</td>
                
                            <td>"+dr["AddressState_Name"].ToString()+@"</td>
                
                            <td>"+dr["AddressZip"].ToString()+@"</td>
                
                            <td>"+dr["Lot"].ToString()+@"</td>
                
                            <td>"+dr["Block"].ToString()+@"</td>
                
                            <td>"+dr["Subdivision"].ToString()+@"</td>
                
                            <td>"+dr["customer_Name"].ToString()+@"</td>
                
                            <td>"+dr["ReviewBy"].ToString()+@"</td>
                
                            <td>"+dr["projectType_Name"].ToString()+@"</td>
                
                            <td>"+dr["projectTypeNotes"].ToString()+@"</td>
                
                            <td>"+dr["Is_projectSoil"].ToString()+@"</td>
                
                            <td>"+dr["GeotechName"].ToString()+@"</td>
                
                            <td>"+dr["SoilReportNo"].ToString()+@"</td>
                
                            <td>"+dr["Is_Pier"].ToString()+@"</td>
                
                            <td>"+dr["PierType_Name"].ToString()+@"</td>
                
                            <td>"+dr["PierDiameter_Name"].ToString()+@"</td>
                
                            <td>"+dr["PierBells"].ToString()+@"</td>
                
                            <td>"+dr["Is_Foundation"].ToString()+@"</td>
                
                            <td>"+dr["Foundation_type_Name"].ToString()+@"</td>
                
                            <td>"+dr["Is_PierBeamFoundation"].ToString()+@"</td>
                
                            <td>"+dr["CrawlSpaceJoists_Name"].ToString()+@"</td>
                
                            <td>"+dr["CrawlSpaceGirders_Name"].ToString()+@"</td>
                
                            <td>"+dr["Is_Framing"].ToString()+@"</td>
                
                            <td>"+dr["Joist_floor_Name"].ToString()+@"</td>
                
                            <td>"+dr["Joist_spacing_Name"].ToString()+@"</td>
                
                            <td>"+dr["Joist_ceiling_Name"].ToString()+@"</td>
                
                            <td>"+dr["Roofing_Name"].ToString()+@"</td>
                
                            <td>"+dr["Roofing_weight_Name"].ToString()+@"</td>
                
                            <td>"+dr["Material_notes"].ToString()+@"</td>
                
                            <td>"+dr["Customer_data"].ToString()+@"</td>
                
                            <td>"+dr["Hold_note"].ToString()+@"</td>
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
        
        ddlStatus_ID.SelectedValue="0";
        ddlPriority_ID.SelectedValue="0";
        ddlAddressCity_ID.SelectedValue="0";
        ddlAddressState_ID.SelectedValue="0";
        ddlcustomer_ID.SelectedValue="0";
        ddlprojectType_ID.SelectedValue="0";
        ddlPierType_ID.SelectedValue="0";
        ddlPierDiameter_ID.SelectedValue="0";
        ddlFoundation_type_ID.SelectedValue="0";
        ddlCrawlSpaceJoists_ID.SelectedValue="0";
        ddlCrawlSpaceGirders_ID.SelectedValue="0";
        ddlJoist_floor_ID.SelectedValue="0";
        ddlJoist_spacing_ID.SelectedValue="0";
        ddlJoist_ceiling_ID.SelectedValue="0";
        ddlRoofing_ID.SelectedValue="0";
        ddlRoofing_weight_ID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Project_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Project_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Project_Action()
    {
        string sql=@"INSERT INTO [Project]
                (
                project_ID,
                projectNumber,
                Status_ID,
                Priority_ID,
                Plan,
                PlanNum,,,,
                AddressStreet,
                AddressSuite,
                AddressCity_ID,
                AddressState_ID,
                AddressZip,
                Lot,
                Block,
                Subdivision,
                customer_ID,
                ReviewBy,
                projectType_ID,
                projectTypeNotes,
                Is_projectSoil,,
                SoilReportNo,
                Is_Pier,
                PierType_ID,
                PierDiameter_ID,
                PierBells,
                Is_Foundation,
                Foundation_type_ID,
                Is_PierBeamFoundation,
                CrawlSpaceJoists_ID,
                CrawlSpaceGirders_ID,
                Is_Framing,
                Joist_floor_ID,
                Joist_spacing_ID,
                Joist_ceiling_ID,
                Roofing_ID,
                Roofing_weight_ID,
                Material_notes,
                Customer_data,
                Hold_note)
                Values(
                "+CommonManager.SQLInjectionChecking(ddlproject_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtprojectNumber.Text)+@"',
                "+CommonManager.SQLInjectionChecking(ddlStatus_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlPriority_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtPlan.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPlanNum.Text)+@"',,,,
                '"+CommonManager.SQLInjectionChecking(txtAddressStreet.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddressSuite.Text)+@"',
                "+CommonManager.SQLInjectionChecking(ddlAddressCity_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlAddressState_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtAddressZip.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtLot.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtBlock.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtSubdivision.Text)+@"',
                "+CommonManager.SQLInjectionChecking(ddlcustomer_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtReviewBy.Text)+@"',
                "+CommonManager.SQLInjectionChecking(ddlprojectType_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtprojectTypeNotes.Text)+@"',
                "+(chkIs_projectSoil.Checked?1:0)+@",,
                '"+CommonManager.SQLInjectionChecking(txtSoilReportNo.Text)+@"',
                "+(chkIs_Pier.Checked?1:0)+@",
                "+CommonManager.SQLInjectionChecking(ddlPierType_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlPierDiameter_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtPierBells.Text)+@"',
                "+(chkIs_Foundation.Checked?1:0)+@",
                "+CommonManager.SQLInjectionChecking(ddlFoundation_type_ID.SelectedValue)+@",
                "+(chkIs_PierBeamFoundation.Checked?1:0)+@",
                "+CommonManager.SQLInjectionChecking(ddlCrawlSpaceJoists_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlCrawlSpaceGirders_ID.SelectedValue)+@",
                "+(chkIs_Framing.Checked?1:0)+@",
                "+CommonManager.SQLInjectionChecking(ddlJoist_floor_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlJoist_spacing_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlJoist_ceiling_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlRoofing_ID.SelectedValue)+@",
                "+CommonManager.SQLInjectionChecking(ddlRoofing_weight_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtMaterial_notes.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCustomer_data.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtHold_note.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Project.aspx?saved=1");
            
    }

    protected void Edit_Project_Action()
    {
        string sql=@"Update [Project]
                Set
                project_ID="+CommonManager.SQLInjectionChecking(ddlproject_ID.SelectedValue)+@",
                projectNumber='"+CommonManager.SQLInjectionChecking(txtprojectNumber.Text)+@"',
                Status_ID="+CommonManager.SQLInjectionChecking(ddlStatus_ID.SelectedValue)+@",
                Priority_ID="+CommonManager.SQLInjectionChecking(ddlPriority_ID.SelectedValue)+@",
                Plan='"+CommonManager.SQLInjectionChecking(txtPlan.Text)+@"',
                PlanNum='"+CommonManager.SQLInjectionChecking(txtPlanNum.Text)+@"',,,,
                AddressStreet='"+CommonManager.SQLInjectionChecking(txtAddressStreet.Text)+@"',
                AddressSuite='"+CommonManager.SQLInjectionChecking(txtAddressSuite.Text)+@"',
                AddressCity_ID="+CommonManager.SQLInjectionChecking(ddlAddressCity_ID.SelectedValue)+@",
                AddressState_ID="+CommonManager.SQLInjectionChecking(ddlAddressState_ID.SelectedValue)+@",
                AddressZip='"+CommonManager.SQLInjectionChecking(txtAddressZip.Text)+@"',
                Lot='"+CommonManager.SQLInjectionChecking(txtLot.Text)+@"',
                Block='"+CommonManager.SQLInjectionChecking(txtBlock.Text)+@"',
                Subdivision='"+CommonManager.SQLInjectionChecking(txtSubdivision.Text)+@"',
                customer_ID="+CommonManager.SQLInjectionChecking(ddlcustomer_ID.SelectedValue)+@",
                ReviewBy='"+CommonManager.SQLInjectionChecking(txtReviewBy.Text)+@"',
                projectType_ID="+CommonManager.SQLInjectionChecking(ddlprojectType_ID.SelectedValue)+@",
                projectTypeNotes='"+CommonManager.SQLInjectionChecking(txtprojectTypeNotes.Text)+@"',
                Is_projectSoil="+(chkIs_projectSoil.Checked?1:0)+@",,
                SoilReportNo='"+CommonManager.SQLInjectionChecking(txtSoilReportNo.Text)+@"',
                Is_Pier="+(chkIs_Pier.Checked?1:0)+@",
                PierType_ID="+CommonManager.SQLInjectionChecking(ddlPierType_ID.SelectedValue)+@",
                PierDiameter_ID="+CommonManager.SQLInjectionChecking(ddlPierDiameter_ID.SelectedValue)+@",
                PierBells='"+CommonManager.SQLInjectionChecking(txtPierBells.Text)+@"',
                Is_Foundation="+(chkIs_Foundation.Checked?1:0)+@",
                Foundation_type_ID="+CommonManager.SQLInjectionChecking(ddlFoundation_type_ID.SelectedValue)+@",
                Is_PierBeamFoundation="+(chkIs_PierBeamFoundation.Checked?1:0)+@",
                CrawlSpaceJoists_ID="+CommonManager.SQLInjectionChecking(ddlCrawlSpaceJoists_ID.SelectedValue)+@",
                CrawlSpaceGirders_ID="+CommonManager.SQLInjectionChecking(ddlCrawlSpaceGirders_ID.SelectedValue)+@",
                Is_Framing="+(chkIs_Framing.Checked?1:0)+@",
                Joist_floor_ID="+CommonManager.SQLInjectionChecking(ddlJoist_floor_ID.SelectedValue)+@",
                Joist_spacing_ID="+CommonManager.SQLInjectionChecking(ddlJoist_spacing_ID.SelectedValue)+@",
                Joist_ceiling_ID="+CommonManager.SQLInjectionChecking(ddlJoist_ceiling_ID.SelectedValue)+@",
                Roofing_ID="+CommonManager.SQLInjectionChecking(ddlRoofing_ID.SelectedValue)+@",
                Roofing_weight_ID="+CommonManager.SQLInjectionChecking(ddlRoofing_weight_ID.SelectedValue)+@",
                Material_notes='"+CommonManager.SQLInjectionChecking(txtMaterial_notes.Text)+@"',
                Customer_data='"+CommonManager.SQLInjectionChecking(txtCustomer_data.Text)+@"',
                Hold_note='"+CommonManager.SQLInjectionChecking(txtHold_note.Text)+@"' 
        where Project_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Project.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtprojectNumber.Text="";
        txtPlan.Text="";
        txtPlanNum.Text="";
        txtAddressStreet.Text="";
        txtAddressSuite.Text="";
        txtAddressZip.Text="";
        txtLot.Text="";
        txtBlock.Text="";
        txtSubdivision.Text="";
        txtReviewBy.Text="";
        txtprojectTypeNotes.Text="";
        txtSoilReportNo.Text="";
        txtPierBells.Text="";
        txtMaterial_notes.Text="";
        txtCustomer_data.Text="";
        txtHold_note.Text="";
        ddlStatus_ID.SelectedValue="0";
        ddlPriority_ID.SelectedValue="0";
        ddlAddressCity_ID.SelectedValue="0";
        ddlAddressState_ID.SelectedValue="0";
        ddlcustomer_ID.SelectedValue="0";
        ddlprojectType_ID.SelectedValue="0";
        ddlPierType_ID.SelectedValue="0";
        ddlPierDiameter_ID.SelectedValue="0";
        ddlFoundation_type_ID.SelectedValue="0";
        ddlCrawlSpaceJoists_ID.SelectedValue="0";
        ddlCrawlSpaceGirders_ID.SelectedValue="0";
        ddlJoist_floor_ID.SelectedValue="0";
        ddlJoist_spacing_ID.SelectedValue="0";
        ddlJoist_ceiling_ID.SelectedValue="0";
        ddlRoofing_ID.SelectedValue="0";
        ddlRoofing_weight_ID.SelectedValue="0";
        chkIs_projectSoil.Checked=false;
        chkIs_Pier.Checked=false;
        chkIs_Foundation.Checked=false;
        chkIs_PierBeamFoundation.Checked=false;
        chkIs_Framing.Checked=false;
    }

}
