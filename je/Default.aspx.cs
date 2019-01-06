using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JensenEngineers.Data;
using JensenEngineers;
using JensenEngineers.Repository;

public partial class je_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadLogin();
            loadMenu("project");
            loadInitialUser();
            load_ddl();
        }

    }

    private void loadLogin()
    {
        try
        {
            getLogin();
        }
        catch (Exception e)
        {
            
            
        }

    }

    private DataRow getLogin()
    {
        if (hfLoggedInEmployeeID.Value == "")
        {
            if (Session["EmployeeID"] == null)
                Response.Redirect("../Default.aspx");
        }
        else
        {
            DataSet ds = CommonManager.SQLExec(@"SELECT   [Id]
                      ,[FirstName]
                      ,[LastName]
                      ,[Name]
                      ,[Designation]
                      ,[Phone]
                      ,[Email]
                      ,[Address]
                      ,[City]
                      ,[State]
                      ,[Zip]
                      ,[HasReviewAuthorization]
                      ,[IsInManagement]
                      ,[IsInDirectorPanel]
                      ,[Password]
                      ,[RoleID]
                  FROM  [Employee]
                  where [id]='" + hfLoggedInEmployeeID.Value + @"'");
            Session["EmployeeID"] = ds.Tables[0].Rows[0];
        }

        DataRow dr = (DataRow)Session["EmployeeID"];
        lblLoginUserName.Text = dr["Name"].ToString();
        lblLoginUserName1.Text = dr["Name"].ToString();
        hfLoggedInEmployeeID.Value = dr["id"].ToString();

        return dr;
    }

    #region Others

    private DataRow InitialRow(DataTable dt, string text)
    {
        DataRow newRow = dt.NewRow();
        newRow[0] = 0;
        newRow[1] = text;

        return newRow;
    }

    private void load_ddl()
    {

        try
        {
            string sql = @"SELECT  [Id]
      ,[StatusTitle]
  FROM [TaskStatus] order by StatusTitle;

SELECT [Id]
      ,[Name]
  FROM  [Employee] order by [Name]

Select Id ,Title from [Customer] order by Title

SELECT [ID]
      ,[RoleName]
  FROM [UserRole]

select [Id],StatusTitle from ProjectStatus order by StatusTitle

SELECT [Id]
      ,[PriorityTitle]
  FROM [dbo].[ProjectPriority]

SELECT [Id]
      ,[FoundationTypeTitle]
  FROM [dbo].[FoundationType]

SELECT [Id]
      ,[ProjectTypeTitle]
  FROM [dbo].[ProjectType]
 
";
            DataSet ds = CommonManager.SQLExec(sql);

            ddlTaskStatusID.Items.Clear();
            ddlTaskStatusID.Items.Add(new ListItem("Select Status", "0"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlTaskStatusID.Items.Add(new ListItem(dr["StatusTitle"].ToString(), dr["id"].ToString()));

            }

            ddlTaskAssignedTo.Items.Clear();
            ddlTaskAssignedTo.Items.Add(new ListItem("Select Designer", "0"));
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ddlTaskAssignedTo.Items.Add(new ListItem(dr["Name"].ToString(), dr["id"].ToString()));

            }

            ddlClientID.Items.Clear();
            ddlClientID.Items.Add(new ListItem("Select Client", "0"));
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ddlClientID.Items.Add(new ListItem(dr["Title"].ToString(), dr["id"].ToString()));
                ddlClientIDView.Items.Add(new ListItem(dr["Title"].ToString(), dr["id"].ToString()));

            }

            ddlcustomer_ID.Items.Clear();
            ddlcustomer_ID.Items.Add(new ListItem("Select Client", "0"));
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ddlcustomer_ID.Items.Add(new ListItem(dr["Title"].ToString(), dr["id"].ToString()));

            }

            ddlUserRole.Items.Clear();
            ddlUserRole.Items.Add(new ListItem("Select Role", "0"));
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                ddlUserRole.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["id"].ToString()));
            }


            ddlStatus_ID.Items.Clear();
            ddlStatus_ID.Items.Add(new ListItem("", "0"));
            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                ddlStatus_ID.Items.Add(new ListItem(dr["StatusTitle"].ToString(), dr["id"].ToString()));
            }


            ddlPriority_ID.Items.Clear();
            ddlPriority_ID.Items.Add(new ListItem("", "0"));
            foreach (DataRow dr in ds.Tables[5].Rows)
            {
                ddlPriority_ID.Items.Add(new ListItem(dr["PriorityTitle"].ToString(), dr["id"].ToString()));
            }



            ddlFoundation_type_ID.Items.Clear();
            ddlFoundation_type_ID.Items.Add(new ListItem("", "0"));
            foreach (DataRow dr in ds.Tables[6].Rows)
            {
                ddlFoundation_type_ID.Items.Add(new ListItem(dr["FoundationTypeTitle"].ToString(), dr["id"].ToString()));
            }


            ddlprojectType_ID.Items.Clear();
            ddlprojectType_ID.Items.Add(new ListItem("", "0"));
            foreach (DataRow dr in ds.Tables[7].Rows)
            {
                ddlprojectType_ID.Items.Add(new ListItem(dr["ProjectTypeTitle"].ToString(), dr["id"].ToString()));
            }

            sql = @"Select 
                [Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_ID
                ,[Admin_DropDownList_Control].Admin_DropDownList_Control_Name
                ,[Admin_DropDownList_Control].Admin_DropDownList_Control_ID
                ,[Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_Name
                ,[Admin_DropDownList_Control_Value].IsActive
         from [Admin_DropDownList_Control_Value]
            inner join [Admin_DropDownList_Control] on [Admin_DropDownList_Control].Admin_DropDownList_Control_ID = [Admin_DropDownList_Control_Value].Admin_DropDownList_Control_ID
        order by [Admin_DropDownList_Control].Admin_DropDownList_Control_Name,
[Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_Name";
            ds = CommonManager.SQLExec(sql);

            /*
             ddlStatus_ID.SelectedValue="0";
        ddlPriority_ID.SelectedValue="0";
        ddlFoundation_type_ID.SelectedValue="0";
        ddlcustomer_ID.SelectedValue="0";
        ddlprojectType_ID.SelectedValue="0";
        
            ddlAddressCity_ID.SelectedValue="0";
        ddlAddressState_ID.SelectedValue="0";
        ddlPierType_ID.SelectedValue="0";
        ddlPierDiameter_ID.SelectedValue="0";
        ddlCrawlSpaceJoists_ID.SelectedValue="0";
        ddlCrawlSpaceGirders_ID.SelectedValue="0";
        ddlJoist_floor_ID.SelectedValue="0";
        ddlJoist_spacing_ID.SelectedValue="0";
        ddlJoist_ceiling_ID.SelectedValue="0";
        ddlRoofing_ID.SelectedValue="0";
        ddlRoofing_weight_ID.SelectedValue="0";
             */

            ddlAddressCity_ID.Items.Clear();
            ddlProposalAddressAddressCity_ID.Items.Clear();
            ddlAddressState_ID.Items.Clear();
            ddlProposalAddressAddressState_ID.Items.Clear();
            ddlPierType_ID.Items.Clear();
            ddlPierDiameter_ID.Items.Clear();
            ddlCrawlSpaceJoists_ID.Items.Clear();
            ddlCrawlSpaceGirders_ID.Items.Clear();
            ddlJoist_floor_ID.Items.Clear();
            ddlJoist_spacing_ID.Items.Clear();
            ddlJoist_ceiling_ID.Items.Clear();
            ddlRoofing_ID.Items.Clear();
            ddlRoofing_weight_ID.Items.Clear();
            ddlClientType.Items.Clear();

            ddlAddressCity_ID.Items.Add(new ListItem("", "4"));
            ddlProposalAddressAddressCity_ID.Items.Add(new ListItem("", "4"));
            ddlAddressState_ID.Items.Add(new ListItem("", "4"));
            ddlProposalAddressAddressState_ID.Items.Add(new ListItem("", "4"));
            ddlPierType_ID.Items.Add(new ListItem("", "4"));
            ddlPierDiameter_ID.Items.Add(new ListItem("", "4"));
            ddlCrawlSpaceJoists_ID.Items.Add(new ListItem("", "4"));
            ddlCrawlSpaceGirders_ID.Items.Add(new ListItem("", "4"));
            ddlJoist_floor_ID.Items.Add(new ListItem("", "4"));
            ddlJoist_spacing_ID.Items.Add(new ListItem("", "4"));
            ddlJoist_ceiling_ID.Items.Add(new ListItem("", "4"));
            ddlRoofing_ID.Items.Add(new ListItem("", "4"));
            ddlRoofing_weight_ID.Items.Add(new ListItem("", "4"));
            ddlClientType.Items.Add(new ListItem("", "4"));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem li = new ListItem(dr["Admin_DropDownList_Control_Value_Name"].ToString()
                    , dr["Admin_DropDownList_Control_Value_ID"].ToString());
                switch (dr["Admin_DropDownList_Control_ID"].ToString())
                {
                    case "1"://city
                        ddlAddressCity_ID.Items.Add(li);
                        ddlProposalAddressAddressCity_ID.Items.Add(new ListItem(
                            dr["Admin_DropDownList_Control_Value_Name"].ToString()
                            , dr["Admin_DropDownList_Control_Value_ID"].ToString()));
                        break;
                    case "2"://State
                        ddlAddressState_ID.Items.Add(li);
                        ddlProposalAddressAddressState_ID.Items.Add(new ListItem(
                            dr["Admin_DropDownList_Control_Value_Name"].ToString()
                            , dr["Admin_DropDownList_Control_Value_ID"].ToString()));
                        break;
                    case "3"://Piers
                        ddlPierType_ID.Items.Add(li);
                        break;
                    case "4"://Diameter
                        ddlPierDiameter_ID.Items.Add(li);
                        break;
                    case "5"://Crawl Space Joists
                        ddlCrawlSpaceJoists_ID.Items.Add(li);
                        break;
                    case "6"://Crawl Space Girders
                        ddlCrawlSpaceGirders_ID.Items.Add(li);
                        break;
                    case "7"://Framing Type Of Floor joist
                        ddlJoist_floor_ID.Items.Add(li);
                        break;
                    case "8"://Framing - Max Floor Joist Spacing
                        ddlJoist_spacing_ID.Items.Add(li);
                        break;
                    case "9"://Framing - Type Of Ceiling Joist
                        ddlJoist_ceiling_ID.Items.Add(li);
                        break;
                    case "10"://Framing - Roofing Materials
                        ddlRoofing_ID.Items.Add(li);
                        break;
                    case "11"://Design Load for Roofing Material
                        ddlRoofing_weight_ID.Items.Add(li);
                        break;
                    case "12"://Design Load for Roofing Material
                        ddlClientType.Items.Add(li);
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception e)
        {

        }
    }
    private void DivView(string clickName)
    {
        try
        {
            makeInvisibleAllDiv();
            switch (clickName)
            {
                case "UserMenuClick":
                    div_User_View.Visible = true;
                    break;
                case "ClientMenuClick":
                    div_Client_View.Visible = true;
                    break;
                case "ProposalMenuClick":
                    div_Proposal_View.Visible = true;
                    break;
                case "ProjectMenuClick":
                    divProjectView.Visible = true;
                    break;
                case "btnAddTaskClose_OnClick":
                    divProjectView.Visible = true;
                    break;
                case "btnAddTask_onClick":
                    divAddTask.Visible = true;
                    break;
                case "lbtnTaskEdit_Click":
                    div_TaskDetails.Visible = true;
                    break;
                case "btnUserViewEdit_OnClick":
                    div_UserEdit.Visible = true;
                    break;
                case "btnProposalViewEdit_OnClick":
                    div_ProposalEdit.Visible = true;
                    break;
                case "btnClientViewEdit_OnClick":
                    div_ClientEdit.Visible = true;
                    break;
                case "btnProjectViewEdit_OnClick":
                    divProjectEdit.Visible = true;
                    break;

                default:
                    break;
            }
        }
        catch (Exception e)
        {
        }
    }

    private void makeInvisibleAllDiv()
    {
        divAddTask.Visible = false;
        divProjectEdit.Visible = false;
        div_TaskDetails.Visible = false;
        divProjectView.Visible = false;
        div_User_View.Visible = false;
        div_Client_View.Visible = false;
        div_Proposal_View.Visible = false;
        div_ClientEdit.Visible = false;
        div_UserEdit.Visible = false;
        div_ProposalEdit.Visible = false;
    }






    #endregion



    #region Menu
    private void loadMenu(string activeOne)
    {
        try
        {
            string id = "";
            id=hfSelectedID.Value;
            string activeUserCss = "";
            string activeClientCss = "";
            string activeProposalCss = "";
            string activeProjectCss = "";

            switch (activeOne)
            {
                case "user":
                    activeUserCss = "active ";
                    break;
                case "client":
                    activeClientCss = "active ";
                    break;
                case "proposal":
                    activeProposalCss = "active ";
                    break;
                case "project":
                    activeProjectCss = "active ";
                    break;
                default:
                    break;
            }

            string sql = @"
Declare @isSelected bit
Set @isSelected=1
Declare @isNotSelected bit
Set @isNotSelected=0

SELECT   [Id]
      ,[Name]
,@isSelected as isSelected
,@isNotSelected as isNotSelected
  FROM [Employee]
"+loadUserStatus()+@"

SELECT  top " + hfClientCount.Value + @" [Id]
      ,[Title]
,@isSelected as isSelected
,@isNotSelected as isNotSelected
  FROM [Customer]
where Title <> '' " + (txtClientSearch.Text.Trim() != "" ? " and Title like '%" + txtClientSearch.Text.Trim() + "%'" : "") + @"
order by Title


SELECT  top " + hfProposalCount.Value + @"  [Id]
      ,[Name]
,@isSelected as isSelected
,@isNotSelected as isNotSelected
  FROM [Proposal]
" + (txtProposalSearch.Text.Trim() != "" ? " where Name like '%" + txtProposalSearch.Text.Trim() + "%'" : "") + @"
order by Name

SELECT  top " + hfProjectCount.Value + @"  Project_ID as [Id]
      ,projectNumber as  [Title]
,@isSelected as isSelected
,@isNotSelected as isNotSelected
 ,(projectNumber + ' [Due date: '+ cast(DueDate as nvarchar)+']') as tooltip
FROM [Project]
where projectNumber<>'' " + (txtProjectSearch.Text.Trim()!=""? " and projectNumber like '%"+ txtProjectSearch.Text.Trim() + "%'" : "")+ @"
order by projectNumber
";

            DataSet ds = CommonManager.SQLExec(sql);


            #region Client Menus
            lblMenuClient.Text = @"
        <li class='" + activeClientCss + @"treeview'>
          <a href='#'>
            <i class='fa  fa-user-plus'></i> <span>Client</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";

            DataRow newRow1 = ds.Tables[1].NewRow();
            newRow1[0] = "0";
            newRow1[1] = "New Client";
            newRow1[2] = "true";
            newRow1[3] = "false";
            ds.Tables[1].Rows.InsertAt(newRow1, 0);
            foreach (DataRow drClient in ds.Tables[1].Rows)
            {
                if (activeClientCss != "" && drClient[0].ToString() == id)
                {
                    drClient["isSelected"] = "false";
                    drClient["isNotSelected"] = "true";
                }
            }
            gvClientUser.DataSource = ds.Tables[1];
            gvClientUser.DataBind();

            lblMenuProposal.Text = @"
          </ul>
        </li>
        
";
            #endregion


            #region Proposal Menus
            lblMenuProposal.Text += @"
        <li class='" + activeProposalCss + @"treeview'>
          <a href='#'>
            <i class='fa fa-list'></i> <span>Proposal</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            ddlAddTaskProposal.Items.Clear();
            ddlAddTaskProposal.Items.Add(new ListItem("Select Proposal","0"));
            foreach (DataRow drProposal in ds.Tables[2].Rows)
            {
                ddlAddTaskProposal.Items.Add(new ListItem(drProposal["Name"].ToString(), drProposal["id"].ToString()));
                if (activeProposalCss != "" && drProposal[0].ToString() == id)
                {
                    drProposal["isSelected"] = "false";
                    drProposal["isNotSelected"] = "true";
                }
            }
            DataRow newRow2 = ds.Tables[2].NewRow();
            newRow2[0] = "0";
            newRow2[1] = "New Proposal";
            newRow2[2] = "true";
            newRow2[3] = "false";
            ds.Tables[2].Rows.InsertAt(newRow2, 0);
            
            gvMenuProposal.DataSource = ds.Tables[2];
            gvMenuProposal.DataBind();

            lblMenuProject1.Text = @"
          </ul>
        </li>
        
";
            #endregion


            #region Project Menus
            lblMenuProject1.Text += @"
        <li class='" + activeProjectCss + @"treeview'>
          <a href='#'>
            <i class='fa fa-table'></i> <span>Project</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            ddlAddTaskProject.Items.Clear();
            ddlAddTaskProject.Items.Add(new ListItem("Select Project", "0"));
            foreach (DataRow drProject in ds.Tables[3].Rows)
            {
                ddlAddTaskProject.Items.Add(new ListItem(drProject["Title"].ToString(), drProject["id"].ToString()));
                if (activeProjectCss != "" && drProject[0].ToString() == id)
                {
                    drProject["isSelected"] = "false";
                    drProject["isNotSelected"] = "true";
                }
            }
            DataRow newRow = ds.Tables[3].NewRow();
            newRow[0] = "0";
            newRow[1] = "New Project";
            newRow[2] = "true";
            newRow[3] = "false";
            newRow[4] = "new";
            ds.Tables[3].Rows.InsertAt(newRow, 0);
            
            gvMenuProject.DataSource = ds.Tables[3];
            gvMenuProject.DataBind();

            lblMenuUser.Text = @"
          </ul>
        </li>
        
";

            #endregion




            #region User Menus

            lblMenuUser.Text += @"
        <li class='" + activeUserCss + @" treeview'>
          <a href='#'>
            <i class='fa fa-users'></i> <span>User</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            liAdmin.Visible = false;

            DataRow dr = getLogin();
            if (dr["RoleID"].ToString() == "1")
            {
                DataRow newRow0 = ds.Tables[0].NewRow();
                newRow0[0] = "0";
                newRow0[1] = "New User";
                newRow0[2] = "true";
                newRow0[3] = "false";
                ds.Tables[0].Rows.InsertAt(newRow0, 0);
                liAdmin.Visible = true;
            }

            foreach (DataRow drUser in ds.Tables[0].Rows)
            {
                if (activeUserCss != "" && drUser[0].ToString() == id)
                {
                    drUser["isSelected"] = "false";
                    drUser["isNotSelected"] = "true";
                }
            }
            gvMenuUser.DataSource = ds.Tables[0];
            gvMenuUser.DataBind();
            
            #endregion

        }
        catch (Exception e)
        {
        }
    }

    private string loadUserStatus()
    {
        string sql = "";
        switch (ddlUserStatus.SelectedValue)
        {
            case "Active":
                sql = "where [IsInManagement]=1";
                break;

            case "In-Active":
                sql = "where [IsInManagement]=0";
                break;
        }
        return sql;
    }


    protected void lbMenuUser_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        string id;
        id = linkButton.CommandArgument.ToString();


        lblSelectedMenu.Text = " User : (" + linkButton.ToolTip + ")";
        hfSelectedID.Value = id;

        loadMenu("user");
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Task.DesignByEmployeeID=" + id;
        loadTasks(sql);
        hfSelectedMenu.Value = "user";
        Edit_Employee(id);
    }

    protected void lbMenuClient_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        string id;
        id = linkButton.CommandArgument.ToString();
        lblSelectedMenu.Text = " Client : (" + linkButton.ToolTip + ")";

        loadClientMenu(id);
        loadClientKeyPersonList();
    }

    private void loadClientMenu(string id)
    {
        hfSelectedID.Value = id;
        loadMenu("client");
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Customer.id=" + id;
        loadTasks(sql);

        hfSelectedMenu.Value = "client";
        Edit_Customer(id);
    }

    protected void lbMenuProposal_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        string id;
        id = linkButton.CommandArgument.ToString();
        lblSelectedMenu.Text = " Proposal : (" + linkButton.ToolTip + ")";

        loadProposalMenu(id);
    }

    private void loadProposalMenu(string id)
    {
        hfSelectedID.Value = id;
        loadMenu("proposal");
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Proposal.Name,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Proposal.Name AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Proposal ON Task.ProjectID = Proposal.Id 
        ON Customer.Id=Proposal.[ClientID]
where Task.TaskForProject=0 and Proposal.ID=" + id;
        loadTasks(sql);
        hfSelectedMenu.Value = "proposal";
        LoadProposalEditsAndEdit(id);
    }

    protected void lbMenuProject_Click(object sender, EventArgs e)
    {

        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        string id;
        id = linkButton.CommandArgument.ToString();
        lblSelectedMenu.Text = " Project : (" + linkButton.ToolTip + ")";

        loadProjectMenu(id);

    }

    private void loadProjectMenu(string id)
    {

        hfSelectedID.Value = id;
        loadMenu("project");
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id 
        ON Customer.Id = Project.CustomerID
where  Task.TaskForProject=1 and Project.id=" + id;
        loadTasks(sql);
        hfSelectedMenu.Value = "project";
        txtId.Text = id;
        loadProject(id);
    }

    #endregion

    #region Task
   

    private void loadTasks(string sql)
    {

        try
        {
            DataSet ds = CommonManager.SQLExec(sql);
            gvTasks.DataSource = ds.Tables[0];
            gvTasks.DataBind();
        }
        catch (Exception e)
        {

        }
    }

    private string loadSQLForTaskList()
    {
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle,Employee.Name as AssignedTo
,Task.ShortDescription, Task.FullDescription

FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID INNER JOIN
        Employee ON Task.DesignByEmployeeID = Employee.Id
where ";

        switch (hfSelectedMenu.Value)
        {
            case "user":
                sql += "Task.DesignByEmployeeID=" + hfSelectedID.Value;
                break;
            case "client":
                sql += "Customer.id=" + hfSelectedID.Value;
                break;
            case "proposal":
                sql += "Project.id=" + hfSelectedID.Value;
                break;
            case "project":
                sql += "Project.id=" + hfSelectedID.Value;
                break;
            default:
                break;
        }

        return sql;
    }

    private void loadTaskDetails(DataRow dr)
    {

        try
        {
            lblTaskTitleDetails.Text = dr["TaskName"].ToString();
            lblTaskDetails_AssignedTo.Text = dr["TaskName"].ToString();
            lblTaskDetails_Deadline.Text = DateTime.Parse(dr["Deadline"].ToString()).ToString("MM/dd/yyyy");
            lblTaskDetails_FullDescription.Text = dr["FullDescription"].ToString();
            lblTaskDetails_TaskStatus.Text = dr["StatusTitle"].ToString();
            lblTaskDetails_ShortDetails.Text = dr["ShortDescription"].ToString();

            LoadNotes();
        }
        catch (Exception e)
        {

        }
    }

    private void LoadNotes()
    {
        try
        {
            string sql = @"select * from [Note] where TaskId="+hfTaskID.Value+ " order by CreatedDate desc";
            DataSet ds = CommonManager.SQLExec(sql);
            rptNotes.DataSource = ds.Tables[0];
            rptNotes.DataBind();
        }
        catch (Exception e)
        {
            
        }
    }

    protected void btnAddTask_onClick(object sender, EventArgs e)
    {
        DivView("btnAddTask_onClick");


    }

    protected void btnAddTaskClose_OnClick(object sender, EventArgs e)
    {
        hfTaskID.Value = "0";
        DivView("btnAddTaskClose_OnClick");
    }
    protected void btnAddTaskForm_OnClick(object sender, EventArgs e)
    {
        try
        {
            string sql = @"INSERT INTO [dbo].[Task]
           ([ProjectID]
           ,[TaskStatusID]
           ,[TaskName]
           ,[DesignByEmployeeID]
           ,[Deadline]
           ,[ShortDescription]
           ,[FullDescription]
           ,[NewReviewNotes]
           ,[ReviewNotes]
           ,[TaskForProject]
           ,[CreatedDate]
           ,[CreatedBy])
     VALUES
           (" + (ddlAddTaskProposal.SelectedValue == "0" ? ddlAddTaskProject.SelectedValue : ddlAddTaskProposal.SelectedValue) + @"--ProjectID, int,>
                    ," + ddlTaskStatusID.SelectedValue + @"--TaskStatusID, int,>
                    ,'" + txtTaskTitle.Text + @"'--TaskName, nvarchar(100),>
                    ," + ddlTaskAssignedTo.SelectedValue + @"--DesignByEmployeeID, int,>
                    ,'" + txtDateline.Text + @"'--Deadline, datetime,>
                    ,'" + txtTaskShortDescription.Text + @"'--ShortDescription, nvarchar(200),>
                    ,'" + "" + @"'--FullDescription, nvarchar(500),>
                    ,'" + "" + @"'--NewReviewNotes, nvarchar(500),>
                    ,'" + "" + @"'--ReviewNotes, nvarchar(500),>
                    ," +(ddlAddTaskProposal.SelectedValue=="0"?"1": "0") + @"--TaskForProject, bit,>
                    ,GETDATE()--CreatedDate, date,>
                    ,1--CreatedBy, int,>
                    )";
            CommonManager.SQLExec(sql);
            
            btnAddTaskClose_OnClick(this, new EventArgs());
            if(ddlAddTaskProposal.SelectedValue == "0")
                loadProjectMenu(ddlAddTaskProject.SelectedValue);
            else
            {
                loadProposalMenu(ddlAddTaskProposal.SelectedValue);
            }
            
            taskCleanup();
        }
        catch (Exception exception)
        {

        }
    }

    private void taskCleanup()
    {
        try
        {
            txtTaskTitle.Text = "";
            txtDateline.Text = "";
            txtTaskShortDescription.Text = "";
        }
        catch (Exception e)
        {
        }
    }


    protected void btnAddNote_OnClick(object sender, EventArgs e)
    {
        //btnAddTaskClose_OnClick(this, new EventArgs());
        string sql = @"
INSERT INTO [dbo].[Note]
           ([TaskId]
           ,[Comment]
           ,[CreatedDate]
           ,[CreatedByEmployeeId])
     VALUES
           ("+hfTaskID.Value+ @"--<TaskId, int,>
           ,'" + txtTaskNote.Text+ @"'--<Comment, varchar(250),>
           ,GETDATE()--<CreatedDate, datetime,>
           ,1--<CreatedByEmployeeId, int,>
);
";

        CommonManager.SQLExec(sql);
        sql = loadSQLForTaskList() + " and Task.id=" + hfTaskID.Value;
        txtTaskNote.Text = "";
        DataSet ds = CommonManager.SQLExec(sql );
        try
        {
            btnAddTaskClose_OnClick(this,new EventArgs());
            //loadTaskDetails(ds.Tables[0].Rows[0]);
        }
        catch (Exception exception)
        {
        }

    }
    protected void lbtnTaskEdit_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        string sql = loadSQLForTaskList();
        DataSet ds = CommonManager.SQLExec(sql + " and Task.id=" + linkButton.CommandArgument);
        hfTaskID.Value = linkButton.CommandArgument;
        loadTaskDetails(ds.Tables[0].Rows[0]);
        //btnAddTaskClose_OnClick(this, new EventArgs());
        DivView("lbtnTaskEdit_Click");
    }


    #endregion


    #region Project
    private void loadProjectInitial()
    {
        hfSelectedMenu.Value = "project";
        hfSelectedID.Value = "1";
        lblSelectedMenu.Text = " Project : ";

        loadMenu("project");
        string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Project.id=" + 1;
        loadTasks(sql);
        txtId.Text = "1";

        loadProject("1");
        DivView("ProjectMenuClick");
    }

   
    private void assignTextValues()
    {
        DataRow dr = null;

        try
        {
            string sql = @"Select * from [Project] where Project_ID = " + txtId.Text;
            dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtAddressNumber.Text = dr["AddressNumber"].ToString();
            lblAddressNumber.Text = dr["AddressNumber"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtGeotechName.Text = dr["GeotechName"].ToString();
            lblGeotechName.Text = dr["GeotechName"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtprojectNumber.Text = dr["projectNumber"].ToString();
            lblProjectDetails_ProjectName.Text = dr["projectNumber"].ToString();
            
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtPlan.Text = dr["Plan"].ToString();
            lblProjectDetails_PlanName.Text = dr["Plan"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtPlanNum.Text = dr["PlanNum"].ToString();
            lblProjectDetails_PlanNumber.Text = dr["PlanNum"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtAddressStreet.Text = dr["AddressStreet"].ToString();
            lblAddressStreet.Text = dr["AddressStreet"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtAddressSuite.Text = dr["AddressSuite"].ToString();
            lblAddressSuite.Text = dr["AddressSuite"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtAddressZip.Text = dr["AddressZip"].ToString();
            lblProjectDetails_JobZip.Text= dr["AddressZip"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtLot.Text = dr["Lot"].ToString();
            lblLot.Text = dr["Lot"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtBlock.Text = dr["Block"].ToString();
            lblBlock.Text = dr["Block"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtSubdivision.Text = dr["Subdivision"].ToString();
            lblSubdivision.Text = dr["Subdivision"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            LoadReviewBy(dr["ReviewBy"].ToString());
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtprojectTypeNotes.Text = dr["projectTypeNotes"].ToString();
            lblProjectDetails_ProjectType.Text = dr["projectTypeNotes"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtSoilReportNo.Text = dr["SoilReportNo"].ToString();
            lblSoilReportNo.Text = dr["SoilReportNo"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtPierBells.Text = dr["PierBells"].ToString();
            lblPierBells.Text = dr["PierBells"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtMaterial_notes.Text = dr["Material_notes"].ToString();
            lblProjectDetails_ProjectMaterialNotes.Text = dr["Material_notes"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtCustomer_data.Text = dr["Customer_data"].ToString();
            lblProjectDetails_CustomerData.Text = dr["Customer_data"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtHold_note.Text = dr["Hold_note"].ToString();
            lblProjectDetails_ProjectHoldHotes.Text = dr["Hold_note"].ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtStartDate.Text = DateTime.Parse(dr["StartDate"].ToString()).ToString("MM/dd/yyyy");
            lblProjectDetails_StartDate.Text = txtStartDate.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            txtDueDate.Text = DateTime.Parse(dr["DueDate"].ToString()).ToString("MM/dd/yyyy");
            lblProjectDetails_DueDate.Text = txtDueDate.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlStatus_ID.SelectedValue = dr["Status_ID"].ToString();
            lblProjectDetails_ProjectStatus.Text = ddlStatus_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlPriority_ID.SelectedValue = dr["Priority_ID"].ToString();
            lblProjectDetails_Priority.Text = ddlPriority_ID.SelectedItem.Text;
            
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlAddressCity_ID.SelectedValue = dr["AddressCity_ID"].ToString();
            lblProjectDetails_JobCity.Text = ddlAddressCity_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlAddressState_ID.SelectedValue = dr["AddressState_ID"].ToString();
            lblProjectDetails_JobState.Text = ddlAddressState_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlcustomer_ID.SelectedValue = dr["customer_ID"].ToString();
            lblProjectDetails_ClientName.Text = ddlcustomer_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlprojectType_ID.SelectedValue = dr["projectType_ID"].ToString();
            lblProjectDetails_ProjectType.Text = ddlprojectType_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlPierType_ID.SelectedValue = dr["PierType_ID"].ToString();
            lblPierType_ID.Text = ddlPierType_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlPierDiameter_ID.SelectedValue = dr["PierDiameter_ID"].ToString();
            lblPierDiameter_ID.Text = ddlPierDiameter_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlFoundation_type_ID.SelectedValue = dr["Foundation_type_ID"].ToString();
            lblProjectDetails_FoundationType.Text = ddlFoundation_type_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlCrawlSpaceJoists_ID.SelectedValue = dr["CrawlSpaceJoists_ID"].ToString();
            lblProjectDetails_FoundationCrawlSpaceJoist.Text = ddlCrawlSpaceJoists_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlCrawlSpaceGirders_ID.SelectedValue = dr["CrawlSpaceGirders_ID"].ToString();
            lblCrawlSpaceGirders_ID.Text = ddlCrawlSpaceGirders_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlJoist_floor_ID.SelectedValue = dr["Joist_floor_ID"].ToString();
            lblProjectDetails_TypeOfFloorJoist.Text = ddlJoist_floor_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlJoist_spacing_ID.SelectedValue = dr["Joist_spacing_ID"].ToString();
            lblProjectDetails_MaxFloorJoistSpacing.Text = ddlJoist_spacing_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlJoist_ceiling_ID.SelectedValue = dr["Joist_ceiling_ID"].ToString();
            lblProjectDetails_TypeOfCeilingJoist.Text = ddlJoist_ceiling_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlRoofing_ID.SelectedValue = dr["Roofing_ID"].ToString();
            lblProjectDetails_RoofingMaterials.Text = ddlRoofing_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            ddlRoofing_weight_ID.SelectedValue = dr["Roofing_weight_ID"].ToString();
            lblProjectDetails_WeightOfRoofingMaterials.Text = ddlRoofing_weight_ID.SelectedItem.Text;
        }
        catch (Exception ex)
        {
        }
        try
        {
            chkIs_projectSoil.Checked = bool.Parse(dr["Is_projectSoil"].ToString());
            lblProjectDetails_IsHaveSoilsReport.Text = bool.Parse(dr["Is_projectSoil"].ToString()).ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            chkIs_Pier.Checked = bool.Parse(dr["Is_Pier"].ToString());
            lblIs_Pier.Text = bool.Parse(dr["Is_Pier"].ToString()).ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            chkIs_Foundation.Checked = bool.Parse(dr["Is_Foundation"].ToString());
            lblProjectDetails_IsFoundation.Text = bool.Parse(dr["Is_Foundation"].ToString()).ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            chkIs_PierBeamFoundation.Checked = bool.Parse(dr["Is_PierBeamFoundation"].ToString());
            lblIs_PierBeamFoundation.Text = bool.Parse(dr["Is_PierBeamFoundation"].ToString()).ToString();
        }
        catch (Exception ex)
        {
        }
        try
        {
            chkIs_Framing.Checked = bool.Parse(dr["Is_Framing"].ToString());
            lblProjectDetails_IsFraming.Text= bool.Parse(dr["Is_Framing"].ToString()).ToString();
        }
        catch (Exception ex)
        {
        }

        #region Project Details View
        /*
        try
        {lblProjectDetails_JobAddress.Text = project.JobAddress;
        }catch (Exception e){}try{lblProjectDetails_TypeOfCeilingJoist.Text = project.TypeOfCeilingJoist;
        }catch (Exception e){}try{lblProjectDetails_JobCity.Text = project.JobCity;
        }catch (Exception e){}try{lblProjectDetails_CustomerData.Text = project.CustomerData;
        }catch (Exception e){}try{lblProjectDetails_Invoice.Text = project.Invoice;
        }catch (Exception e){}try{lblProjectDetails_CourierToAddress.Text = project.CouriertoAddress;
        }catch (Exception e){}try{lblProjectDetails_CourierToWhom.Text = project.CouriertoWhom;
        }catch (Exception e){}try{lblProjectDetails_FoundationCrawlSpaceJoist.Text = project.CrawlSpaceJoist;
        }catch (Exception e){}try{lblProjectDetails_DueDate.Text = Convert.ToDateTime(project.DueDate).ToString("MM/dd/yyyy"); ;
        }catch (Exception e){}try{lblProjectDetails_StartDate.Text = Convert.ToDateTime(project.StartDate).ToString("MM/dd/yyyy");
        }catch (Exception e){}try{lblProjectDetails_EmailAddress.Text = project.EmailAddress;
        }catch (Exception e){}try{lblProjectDetails_MaxFloorJoistSpacing.Text = project.MaxFloorJoistSpacing;
        }catch (Exception e){}try{lblProjectDetails_TypeOfFloorJoist.Text = project.TypeOfFloorJoist;
        }catch (Exception e){}try{lblProjectDetails_ProjectHoldHotes.Text = project.ProjectHoldNotes;
        }catch (Exception e){}try{lblProjectDetails_SoilReportSent.Text = project.How_WhenSending;
        }catch (Exception e){}try{lblProjectDetails_ProjectMaterialNotes.Text = project.ProjectMaterialNotes;
        }catch (Exception e){}try{lblProjectDetails_RoofingMaterials.Text = project.RoofingMaterials;
        }catch (Exception e){}try{lblProjectDetails_WeightOfRoofingMaterials.Text = project.WeightOfRoofingMaterials;
        }catch (Exception e){}try{lblProjectDetails_NumberOfCopies.Text = project.NumberOfCopies.ToString();
        }catch (Exception e){}try{lblProjectDetails_PlanName.Text = project.PlanName;
        }catch (Exception e){}try{lblProjectDetails_PickupByPersonPhoneNumber.Text = project.PickupByPersonPhoneNumber;
        }catch (Exception e){}try{lblProjectDetails_PickUpByPersonName.Text = project.PickupByPersonName;
        }catch (Exception e){}try{lblProjectDetails_PlanName.Text = project.PlanName;
        }catch (Exception e){}try{lblProjectDetails_ProjectName.Text = project.Title;
        }catch (Exception e){}try{lblProjectDetails_ProjectTypeNote.Text = project.ProjectTypeNotes;
        }catch (Exception e){}try{lblProjectDetails_ProjectNumber.Text = project.ProjectNumber;
        }catch (Exception e){}try{lblProjectDetails_JobZip.Text = project.JobZipAddress;

        }catch (Exception e){}try{lblProjectDetails_FoundationType.Text = DropDownFoundationType.SelectedItem.Text;//FoundationTypeID.ToString();
        }catch (Exception e){}try{lblProjectDetails_ProjectType.Text = DropDownProjectType.SelectedItem.Text;//FoundationTypeID.ToString();
        }catch (Exception e){}try{lblProjectDetails_ReviewedBy.Text = DropDownProjetReviewed.SelectedItem.Text;//ReviewedByID.ToString();
        }catch (Exception e){}try{lblProjectDetails_Priority.Text = dropDownProjectPriority.SelectedItem.Text;//ProjectPriorityID.ToString();
        }catch (Exception e){}try{lblProjectDetails_ClientName.Text = dropdownClient.SelectedItem.Text;//CustomerID.ToString();
        }catch (Exception e){}try{lblProjectDetails_ProjectStatus.Text = dropdownProjectStatus.SelectedItem.Text;//ProjectStatusID.ToString();
        }catch (Exception e){}try{lblProjectDetails_JobState.Text = dropdownState.SelectedItem.Text;//JobState;

        }catch (Exception e){}try{lblProjectDetails_IsFoundation.Text = chkFoundation.Checked.ToString();// = project.IsFoundation;
        }catch (Exception e){}try{lblProjectDetails_IsHaveCourierPlans.Text = chkIsCourier.Checked.ToString();//= project.IsHaveCourierPlans;
        }catch (Exception e){}try{lblProjectDetails_IsFraming.Text = chkIsFraming.Checked.ToString();//= project.IsFraming;
        }catch (Exception e){}try{lblProjectDetails_IsHaveEmail.Text = chkIsHaveEmail.Checked.ToString();//= project.IsHaveEmail;
        }catch (Exception e){}try{lblProjectDetails_IsClientWillPickup.Text = chkPickup.Checked.ToString();//= project.IsCustomerWillPickup;
        }catch (Exception e){}try{lblProjectDetails_IsHaveSoilsReport.Text = chkSoilReport.Checked.ToString();//= project.IsHaveSoilsReport;
}catch (Exception e){}
*/
        #endregion

    }

    private void LoadReviewBy(string reviewBy)
    {
        lblProjectDetails_ReviewedBy.Text = "";
        foreach (ListItem li in DropDownProjetReviewed.Items)
        {
            if ((reviewBy + ",").Contains(li.Value + ","))
            {
                li.Selected = true;
                lblProjectDetails_ReviewedBy.Text += "<br/>" + li.Text;
            }
        }
    }

    private void loadProject(string id)
    {
        try
        {
            txtId.Text = id;
            if (id == "0")
            {
                DivView("btnProjectViewEdit_OnClick");
                projectReset();
                return;
            }
            
            assignTextValues();
            //Layout.SelectedSubMenuId = project.Id.ToString();

            string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle,Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Project.id=" + id;
            loadTasks(sql);
            DivView("ProjectMenuClick");
        }
        catch (Exception e)
        {


        }

    }



    protected void btnAdd_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (txtId.Text=="0")
            {
                Add_Project_Action();
            }
            else
            {
                Edit_Project_Action();
            }
        }
        catch (Exception ex)
        {
        }
        this.lblMessage.Text = "Project updated successfully!";
        loadProject(txtId.Text);
        loadMenu("project");
        btnAddTaskClose_OnClick(this, new EventArgs());

    }

    protected void Add_Project_Action()
    {
        string sql = @"INSERT INTO [Project]
                (
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
                '" + CommonManager.SQLInjectionChecking(txtprojectNumber.Text) + @"',
                " + CommonManager.SQLInjectionChecking(ddlStatus_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlPriority_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(txtPlan.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtPlanNum.Text) + @"',,,,
                '" + CommonManager.SQLInjectionChecking(txtAddressStreet.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtAddressSuite.Text) + @"',
                " + CommonManager.SQLInjectionChecking(ddlAddressCity_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlAddressState_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(txtAddressZip.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtLot.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtBlock.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtSubdivision.Text) + @"',
                " + CommonManager.SQLInjectionChecking(ddlcustomer_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(GetReviewBy()) + @"',
                " + CommonManager.SQLInjectionChecking(ddlprojectType_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(txtprojectTypeNotes.Text) + @"',
                " + (chkIs_projectSoil.Checked ? 1 : 0) + @",,
                '" + CommonManager.SQLInjectionChecking(txtSoilReportNo.Text) + @"',
                " + (chkIs_Pier.Checked ? 1 : 0) + @",
                " + CommonManager.SQLInjectionChecking(ddlPierType_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlPierDiameter_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(txtPierBells.Text) + @"',
                " + (chkIs_Foundation.Checked ? 1 : 0) + @",
                " + CommonManager.SQLInjectionChecking(ddlFoundation_type_ID.SelectedValue) + @",
                " + (chkIs_PierBeamFoundation.Checked ? 1 : 0) + @",
                " + CommonManager.SQLInjectionChecking(ddlCrawlSpaceJoists_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlCrawlSpaceGirders_ID.SelectedValue) + @",
                " + (chkIs_Framing.Checked ? 1 : 0) + @",
                " + CommonManager.SQLInjectionChecking(ddlJoist_floor_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlJoist_spacing_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlJoist_ceiling_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlRoofing_ID.SelectedValue) + @",
                " + CommonManager.SQLInjectionChecking(ddlRoofing_weight_ID.SelectedValue) + @",
                '" + CommonManager.SQLInjectionChecking(txtMaterial_notes.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtCustomer_data.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtHold_note.Text) + @"');";
        DataSet ds = CommonManager.SQLExec(sql);
        Response.Redirect("Admin_Project.aspx?saved=1");

    }

    private string GetReviewBy()
    {
        string reviewBy = "";
        foreach (ListItem li in DropDownProjetReviewed.Items)
        {
            if(li.Selected)
            reviewBy +=(reviewBy==""?"":",")+ li.Value;
        }

        return reviewBy;
    }

    protected void Edit_Project_Action()
    {
        string sql = @"Update [Project]
                Set
                projectNumber='" + CommonManager.SQLInjectionChecking(txtprojectNumber.Text) + @"',
                Status_ID=" + CommonManager.SQLInjectionChecking(ddlStatus_ID.SelectedValue) + @",
                Priority_ID=" + CommonManager.SQLInjectionChecking(ddlPriority_ID.SelectedValue) + @",
                Plan='" + CommonManager.SQLInjectionChecking(txtPlan.Text) + @"',
                PlanNum='" + CommonManager.SQLInjectionChecking(txtPlanNum.Text) + @"',,,,
                AddressStreet='" + CommonManager.SQLInjectionChecking(txtAddressStreet.Text) + @"',
                AddressSuite='" + CommonManager.SQLInjectionChecking(txtAddressSuite.Text) + @"',
                AddressCity_ID=" + CommonManager.SQLInjectionChecking(ddlAddressCity_ID.SelectedValue) + @",
                AddressState_ID=" + CommonManager.SQLInjectionChecking(ddlAddressState_ID.SelectedValue) + @",
                AddressZip='" + CommonManager.SQLInjectionChecking(txtAddressZip.Text) + @"',
                Lot='" + CommonManager.SQLInjectionChecking(txtLot.Text) + @"',
                Block='" + CommonManager.SQLInjectionChecking(txtBlock.Text) + @"',
                Subdivision='" + CommonManager.SQLInjectionChecking(txtSubdivision.Text) + @"',
                customer_ID=" + CommonManager.SQLInjectionChecking(ddlcustomer_ID.SelectedValue) + @",
                ReviewBy='" + CommonManager.SQLInjectionChecking(GetReviewBy()) + @"',
                projectType_ID=" + CommonManager.SQLInjectionChecking(ddlprojectType_ID.SelectedValue) + @",
                projectTypeNotes='" + CommonManager.SQLInjectionChecking(txtprojectTypeNotes.Text) + @"',
                Is_projectSoil=" + (chkIs_projectSoil.Checked ? 1 : 0) + @",,
                SoilReportNo='" + CommonManager.SQLInjectionChecking(txtSoilReportNo.Text) + @"',
                Is_Pier=" + (chkIs_Pier.Checked ? 1 : 0) + @",
                PierType_ID=" + CommonManager.SQLInjectionChecking(ddlPierType_ID.SelectedValue) + @",
                PierDiameter_ID=" + CommonManager.SQLInjectionChecking(ddlPierDiameter_ID.SelectedValue) + @",
                PierBells='" + CommonManager.SQLInjectionChecking(txtPierBells.Text) + @"',
                Is_Foundation=" + (chkIs_Foundation.Checked ? 1 : 0) + @",
                Foundation_type_ID=" + CommonManager.SQLInjectionChecking(ddlFoundation_type_ID.SelectedValue) + @",
                Is_PierBeamFoundation=" + (chkIs_PierBeamFoundation.Checked ? 1 : 0) + @",
                CrawlSpaceJoists_ID=" + CommonManager.SQLInjectionChecking(ddlCrawlSpaceJoists_ID.SelectedValue) + @",
                CrawlSpaceGirders_ID=" + CommonManager.SQLInjectionChecking(ddlCrawlSpaceGirders_ID.SelectedValue) + @",
                Is_Framing=" + (chkIs_Framing.Checked ? 1 : 0) + @",
                Joist_floor_ID=" + CommonManager.SQLInjectionChecking(ddlJoist_floor_ID.SelectedValue) + @",
                Joist_spacing_ID=" + CommonManager.SQLInjectionChecking(ddlJoist_spacing_ID.SelectedValue) + @",
                Joist_ceiling_ID=" + CommonManager.SQLInjectionChecking(ddlJoist_ceiling_ID.SelectedValue) + @",
                Roofing_ID=" + CommonManager.SQLInjectionChecking(ddlRoofing_ID.SelectedValue) + @",
                Roofing_weight_ID=" + CommonManager.SQLInjectionChecking(ddlRoofing_weight_ID.SelectedValue) + @",
                Material_notes='" + CommonManager.SQLInjectionChecking(txtMaterial_notes.Text) + @"',
                Customer_data='" + CommonManager.SQLInjectionChecking(txtCustomer_data.Text) + @"',
                Hold_note='" + CommonManager.SQLInjectionChecking(txtHold_note.Text) + @"' 
        where Project_ID=" + Request.QueryString["edit"];
        DataSet ds = CommonManager.SQLExec(sql);

    }

    private void projectReset()
    {

        txtprojectNumber.Text = "";
        txtPlan.Text = "";
        txtPlanNum.Text = "";
        txtAddressStreet.Text = "";
        txtAddressSuite.Text = "";
        txtAddressZip.Text = "";
        txtLot.Text = "";
        txtBlock.Text = "";
        txtSubdivision.Text = "";
        resetReviewBy();
        txtprojectTypeNotes.Text = "";
        txtSoilReportNo.Text = "";
        txtPierBells.Text = "";
        txtMaterial_notes.Text = "";
        txtCustomer_data.Text = "";
        txtHold_note.Text = "";
        ddlStatus_ID.SelectedValue = "0";
        ddlPriority_ID.SelectedValue = "0";
        ddlAddressCity_ID.SelectedValue = "0";
        ddlAddressState_ID.SelectedValue = "0";
        ddlcustomer_ID.SelectedValue = "0";
        ddlprojectType_ID.SelectedValue = "0";
        ddlPierType_ID.SelectedValue = "0";
        ddlPierDiameter_ID.SelectedValue = "0";
        ddlFoundation_type_ID.SelectedValue = "0";
        ddlCrawlSpaceJoists_ID.SelectedValue = "0";
        ddlCrawlSpaceGirders_ID.SelectedValue = "0";
        ddlJoist_floor_ID.SelectedValue = "0";
        ddlJoist_spacing_ID.SelectedValue = "0";
        ddlJoist_ceiling_ID.SelectedValue = "0";
        ddlRoofing_ID.SelectedValue = "0";
        ddlRoofing_weight_ID.SelectedValue = "0";
        chkIs_projectSoil.Checked = false;
        chkIs_Pier.Checked = false;
        chkIs_Foundation.Checked = false;
        chkIs_PierBeamFoundation.Checked = false;
        chkIs_Framing.Checked = false;
    }

    private void resetReviewBy()
    {
        foreach (ListItem li in DropDownProjetReviewed.Items)
        {
            li.Selected = false;
        }
    }

    protected void btnProjectViewEdit_OnClick(object sender, EventArgs e)
    {
        DivView("btnProjectViewEdit_OnClick");
    }


    #endregion
    
    #region Proposal

    private void LoadProposalEditsAndEdit(string id)
    {
        try
        {
            if (id == "0")
            {
                txtProposalID.Text = "0";
                DivView("btnProposalViewEdit_OnClick");
                btnResetProposal();
                return;
            }

            string sql = @"Select * from [Proposal] where ID = " + id;
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];

            txtName.Text = dr["Name"].ToString();
            txtProposalAddress.Text = dr["Address"].ToString();
            txtProposalCity.Text = dr["City"].ToString();
            txtProposalState.Text = dr["State"].ToString();
            txtProposalZip.Text = dr["zip"].ToString();
            txtDetails.Text = dr["Details"].ToString();
            txtProposalType.Text = dr["ProposalType"].ToString();
            txtDailyType.Text = dr["DailyType"].ToString();
            txtProjectType.Text = dr["ProjectType"].ToString();
            txtProjectOtherTypeValue.Text = dr["ProjectOtherTypeValue"].ToString();
            txtFoundationTypeValue.Text = dr["FoundationTypeValue"].ToString();
            txtFoundationSlabTypeValue.Text = dr["FoundationSlabTypeValue"].ToString();
            txtFoundationPierTypeValue.Text = dr["FoundationPierTypeValue"].ToString();
            txtFoundationPierRemiedialTypeValue.Text = dr["FoundationPierRemiedialTypeValue"].ToString();
            txtFoundationPierRemiedialOtherTypeValue.Text = dr["FoundationPierRemiedialOtherTypeValue"].ToString();
            txtFoundationOtherTypeValue.Text = dr["FoundationOtherTypeValue"].ToString();
            txtFrameTypeValue.Text = dr["FrameTypeValue"].ToString();
            txtFrameResidentialValue.Text = dr["FrameResidentialValue"].ToString();
            txtFrameResidentialOtherValue.Text = dr["FrameResidentialOtherValue"].ToString();
            txtFrameExteriorValue.Text = dr["FrameExteriorValue"].ToString();
            txtFrameExteriorOtherValue.Text = dr["FrameExteriorOtherValue"].ToString();
            txtFrameRoofTypeValue.Text = dr["FrameRoofTypeValue"].ToString();
            txtFrameRoofTypeOtherValue.Text = dr["FrameRoofTypeOtherValue"].ToString();
            txtRetainingWallValue.Text = dr["RetainingWallValue"].ToString();
            txtRetainingWallTypeValue.Text = dr["RetainingWallTypeValue"].ToString();
            txtRetainingWallTypeWallValue.Text = dr["RetainingWallTypeWallValue"].ToString();
            txtRetainingWallTypeWallOtherValue.Text = dr["RetainingWallTypeWallOtherValue"].ToString();
            txtPoolValue.Text = dr["PoolValue"].ToString();
            txtPoolCompnayDesignValue.Text = dr["PoolCompnayDesignValue"].ToString();
            txtProposalID.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0");
            txtInitialContractDate.Text = DateTime.Parse(dr["InitialContractDate"].ToString()).ToString("dd/MM/yyyy");
            txtSubmittalDate.Text = DateTime.Parse(dr["SubmittalDate"].ToString()).ToString("dd/MM/yyyy");
            txtRevisionDate.Text = DateTime.Parse(dr["RevisionDate"].ToString()).ToString("dd/MM/yyyy");
            ddlClientID.SelectedValue = dr["ClientID"].ToString();

            #region Proposal View

            lblProposalName1.Text = dr["Name"].ToString();
            lblProposalName2.Text = dr["Name"].ToString();
            lblProposalAddress.Text = dr["Address"].ToString();
            lblProposalCity.Text = dr["City"].ToString();
            lblProposalState.Text = dr["State"].ToString();
            lblProposalZip.Text = dr["zip"].ToString();
            lblDetails.Text = dr["Details"].ToString();
            lblProposalType.Text = dr["ProposalType"].ToString();
            lblDailyType.Text = dr["DailyType"].ToString();
            lblProjectType.Text = dr["ProjectType"].ToString();
            lblProjectOtherTypeValue.Text = dr["ProjectOtherTypeValue"].ToString();
            lblFoundationTypeValue.Text = dr["FoundationTypeValue"].ToString();
            lblFoundationSlabTypeValue.Text = dr["FoundationSlabTypeValue"].ToString();
            lblFoundationPierTypeValue.Text = dr["FoundationPierTypeValue"].ToString();
            lblFoundationPierRemiedialTypeValue.Text = dr["FoundationPierRemiedialTypeValue"].ToString();
            lblFoundationPierRemiedialOtherTypeValue.Text = dr["FoundationPierRemiedialOtherTypeValue"].ToString();
            lblFoundationOtherTypeValue.Text = dr["FoundationOtherTypeValue"].ToString();
            lblFrameTypeValue.Text = dr["FrameTypeValue"].ToString();
            lblFrameResidentialValue.Text = dr["FrameResidentialValue"].ToString();
            lblFrameResidentialOtherValue.Text = dr["FrameResidentialOtherValue"].ToString();
            lblFrameExteriorValue.Text = dr["FrameExteriorValue"].ToString();
            lblFrameExteriorOtherValue.Text = dr["FrameExteriorOtherValue"].ToString();
            lblFrameRoofTypeValue.Text = dr["FrameRoofTypeValue"].ToString();
            lblFrameRoofTypeOtherValue.Text = dr["FrameRoofTypeOtherValue"].ToString();
            lblRetainingWallValue.Text = dr["RetainingWallValue"].ToString();
            lblRetainingWallTypeValue.Text = dr["RetainingWallTypeValue"].ToString();
            lblRetainingWallTypeWallValue.Text = dr["RetainingWallTypeWallValue"].ToString();
            lblRetainingWallTypeWallOtherValue.Text = dr["RetainingWallTypeWallOtherValue"].ToString();
            lblPoolValue.Text = dr["PoolValue"].ToString();
            lblPoolCompnayDesignValue.Text = dr["PoolCompnayDesignValue"].ToString();
            lblInitialContractDate.Text = DateTime.Parse(dr["InitialContractDate"].ToString()).ToString("dd/MM/yyyy");
            lblSubmittalDate.Text = DateTime.Parse(dr["SubmittalDate"].ToString()).ToString("dd/MM/yyyy");
            lblRevisionDate.Text = DateTime.Parse(dr["RevisionDate"].ToString()).ToString("dd/MM/yyyy");
            ddlClientID.SelectedValue = dr["ClientID"].ToString();

            #endregion

            DivView("ProposalMenuClick");

        }
        catch (Exception ex)
        {

        }
    }


    protected void btnProposalViewEdit_OnClick(object sender, EventArgs e)
    {
        DivView("btnProposalViewEdit_OnClick");

    }

    

    

    protected void btnAddProposalClose_OnClick(object sender, EventArgs e)
    {
        DivView("ProposalMenuClick");
    }
    private void btnResetProposal()
    {

        txtName.Text = "";
        txtProposalAddress.Text = "";
        txtProposalCity.Text = "";
        txtProposalState.Text = "";
        txtProposalZip.Text = "";
        txtDetails.Text = "";
        txtProposalType.Text = "";
        txtDailyType.Text = "";
        txtProjectType.Text = "";
        txtProjectOtherTypeValue.Text = "";
        txtFoundationTypeValue.Text = "";
        txtFoundationSlabTypeValue.Text = "";
        txtFoundationPierTypeValue.Text = "";
        txtFoundationPierRemiedialTypeValue.Text = "";
        txtFoundationPierRemiedialOtherTypeValue.Text = "";
        txtFoundationOtherTypeValue.Text = "";
        txtFrameTypeValue.Text = "";
        txtFrameResidentialValue.Text = "";
        txtFrameResidentialOtherValue.Text = "";
        txtFrameExteriorValue.Text = "";
        txtFrameExteriorOtherValue.Text = "";
        txtFrameRoofTypeValue.Text = "";
        txtFrameRoofTypeOtherValue.Text = "";
        txtRetainingWallValue.Text = "";
        txtRetainingWallTypeValue.Text = "";
        txtRetainingWallTypeWallValue.Text = "";
        txtRetainingWallTypeWallOtherValue.Text = "";
        txtPoolValue.Text = "";
        txtPoolCompnayDesignValue.Text = "";
        txtId.Text = "";
        txtInitialContractDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        txtSubmittalDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        txtRevisionDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        ddlClientID.SelectedValue = "0";
    }

    protected void btnAddOrEditProposal_OnClick(object sender, EventArgs e)
    {
        DivView("ProposalMenuClick");
        try
        {
            if (txtProposalID.Text == "0")
            {
                Add_Proposal_Action();
            }
            else
            {
                Edit_Proposal_Action();
            }
            loadMenu("proposal");

        }
        catch (Exception ex)
        {
        }
    }

    protected void Add_Proposal_Action()
    {
        string sql = @"INSERT INTO [Proposal]
                (
                Name,
                Address,
                City,
                State,
                zip,
                Details,
                InitialContractDate,
                SubmittalDate,
                RevisionDate,
                ProposalType,
                DailyType,
                ProjectType,
                ProjectOtherTypeValue,
                FoundationTypeValue,
                FoundationSlabTypeValue,
                FoundationPierTypeValue,
                FoundationPierRemiedialTypeValue,
                FoundationPierRemiedialOtherTypeValue,
                FoundationOtherTypeValue,
                FrameTypeValue,
                FrameResidentialValue,
                FrameResidentialOtherValue,
                FrameExteriorValue,
                FrameExteriorOtherValue,
                FrameRoofTypeValue,
                FrameRoofTypeOtherValue,
                RetainingWallValue,
                RetainingWallTypeValue,
                RetainingWallTypeWallValue,
                RetainingWallTypeWallOtherValue,
                PoolValue,
                PoolCompnayDesignValue,
                ClientID)
                Values(
                '" + CommonManager.SQLInjectionChecking(txtName.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProposalAddress.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProposalCity.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProposalState.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProposalZip.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtDetails.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtInitialContractDate.Text)).ToString("yyyy-MM-dd hh:mm tt")) + @"',
                '" + CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtSubmittalDate.Text)).ToString("yyyy-MM-dd hh:mm tt")) + @"',
                '" + CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtRevisionDate.Text)).ToString("yyyy-MM-dd hh:mm tt")) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProposalType.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtDailyType.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProjectType.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtProjectOtherTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationSlabTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationPierTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialOtherTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFoundationOtherTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameResidentialValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameResidentialOtherValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameExteriorValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameExteriorOtherValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameRoofTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFrameRoofTypeOtherValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtRetainingWallValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallOtherValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtPoolValue.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtPoolCompnayDesignValue.Text) + @"',
                " + CommonManager.SQLInjectionChecking(ddlClientID.SelectedValue) + @");";
        DataSet ds = CommonManager.SQLExec(sql);
        
    }

    protected void Edit_Proposal_Action()
    {
        string sql = @"Update [Proposal]
                Set
                Name='" + CommonManager.SQLInjectionChecking(txtName.Text) + @"',
                Address='" + CommonManager.SQLInjectionChecking(txtProposalAddress.Text) + @"',
                City='" + CommonManager.SQLInjectionChecking(txtProposalCity.Text) + @"',
                State='" + CommonManager.SQLInjectionChecking(txtProposalState.Text) + @"',
                zip='" + CommonManager.SQLInjectionChecking(txtProposalZip.Text) + @"',
                Details='" + CommonManager.SQLInjectionChecking(txtDetails.Text) + @"',
                InitialContractDate='" + DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtInitialContractDate.Text))).ToString("yyyy-MM-dd hh:mm tt") + @"',
                SubmittalDate='" + DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtSubmittalDate.Text))).ToString("yyyy-MM-dd hh:mm tt") + @"',
                RevisionDate='" + DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtRevisionDate.Text))).ToString("yyyy-MM-dd hh:mm tt") + @"',
                ProposalType='" + CommonManager.SQLInjectionChecking(txtProposalType.Text) + @"',
                DailyType='" + CommonManager.SQLInjectionChecking(txtDailyType.Text) + @"',
                ProjectType='" + CommonManager.SQLInjectionChecking(txtProjectType.Text) + @"',
                ProjectOtherTypeValue='" + CommonManager.SQLInjectionChecking(txtProjectOtherTypeValue.Text) + @"',
                FoundationTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationTypeValue.Text) + @"',
                FoundationSlabTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationSlabTypeValue.Text) + @"',
                FoundationPierTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationPierTypeValue.Text) + @"',
                FoundationPierRemiedialTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialTypeValue.Text) + @"',
                FoundationPierRemiedialOtherTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialOtherTypeValue.Text) + @"',
                FoundationOtherTypeValue='" + CommonManager.SQLInjectionChecking(txtFoundationOtherTypeValue.Text) + @"',
                FrameTypeValue='" + CommonManager.SQLInjectionChecking(txtFrameTypeValue.Text) + @"',
                FrameResidentialValue='" + CommonManager.SQLInjectionChecking(txtFrameResidentialValue.Text) + @"',
                FrameResidentialOtherValue='" + CommonManager.SQLInjectionChecking(txtFrameResidentialOtherValue.Text) + @"',
                FrameExteriorValue='" + CommonManager.SQLInjectionChecking(txtFrameExteriorValue.Text) + @"',
                FrameExteriorOtherValue='" + CommonManager.SQLInjectionChecking(txtFrameExteriorOtherValue.Text) + @"',
                FrameRoofTypeValue='" + CommonManager.SQLInjectionChecking(txtFrameRoofTypeValue.Text) + @"',
                FrameRoofTypeOtherValue='" + CommonManager.SQLInjectionChecking(txtFrameRoofTypeOtherValue.Text) + @"',
                RetainingWallValue='" + CommonManager.SQLInjectionChecking(txtRetainingWallValue.Text) + @"',
                RetainingWallTypeValue='" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeValue.Text) + @"',
                RetainingWallTypeWallValue='" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallValue.Text) + @"',
                RetainingWallTypeWallOtherValue='" + CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallOtherValue.Text) + @"',
                PoolValue='" + CommonManager.SQLInjectionChecking(txtPoolValue.Text) + @"',
                PoolCompnayDesignValue='" + CommonManager.SQLInjectionChecking(txtPoolCompnayDesignValue.Text) + @"',
                ClientID=" + CommonManager.SQLInjectionChecking(ddlClientID.SelectedValue.Replace(",", "")) + @" 
        where ID=" + txtProposalID.Text;
        DataSet ds = CommonManager.SQLExec(sql);

    }



    #endregion
  
    #region User

    private void loadInitialUser()
    {
        try
        {
            string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.id, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Task.DesignByEmployeeID=" + hfLoggedInEmployeeID.Value;
            loadTasks(sql);
            hfSelectedMenu.Value = "user";
            hfSelectedID.Value = hfLoggedInEmployeeID.Value;
            Edit_Employee(hfLoggedInEmployeeID.Value);
        }
        catch (Exception e)
        {
            
        }
    }

    protected void btnUserViewEdit_OnClick(object sender, EventArgs e)
    {
        DivView("btnUserViewEdit_OnClick");
    }
    protected void btnAddOrEditUserClose_OnClick(object sender, EventArgs e)
    {
        DivView("UserMenuClick");

    }

    protected void btnAddOrEditUser_OnClick(object sender, EventArgs e)
    {
        DivView("UserMenuClick");
        try
        {
            if (txtUserID.Text == "0")
            {
                Add_Employee_Action();
            }
            else
            {
                Edit_Employee_Action();
            }
            loadMenu("user");

        }
        catch (Exception ex)
        {
        }

    }

  
    private void Edit_Employee(string id)
    {
        try
        {
            if (id == "0")
            {
                txtUserID.Text = "0";
                
                DivView("btnUserViewEdit_OnClick");
                EmployeeReset();
                return;
            }

            string sql = @"Select * from [Employee] where ID = " + id;
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];

            txtFirstName.Text = dr["FirstName"].ToString();
            txtLastName.Text = dr["LastName"].ToString();
            txtUserName.Text = txtFirstName.Text+" "+ txtLastName.Text;
            txtDesignation.Text = dr["Designation"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtUserAddress.Text = dr["Address"].ToString();
            txtUserAddressCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtZip.Text = dr["Zip"].ToString();
            try
            {
                txtPassword.Text = dr["Password"].ToString();
                ddlUserRole.SelectedValue = dr["RoleID"].ToString();
                lbluserRole.Text = ddlUserRole.SelectedItem.Text;

            }
            catch (Exception e)
            {
            }
            txtUserID.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0");
            chkHasReviewAuthorization.Checked = bool.Parse(dr["HasReviewAuthorization"].ToString());
            chkIsInManagement.Checked = bool.Parse(dr["IsInManagement"].ToString());
            chkIsInDirectorPanel.Checked = bool.Parse(dr["IsInDirectorPanel"].ToString());

            #region User View

            lblFirstName.Text = dr["FirstName"].ToString();
            lblLastName.Text = dr["LastName"].ToString();
            lblUserName.Text = dr["Name"].ToString();
            lblUserName1.Text = dr["Name"].ToString();
            lblDesignation.Text = dr["Designation"].ToString();
            lblPhone.Text = dr["Phone"].ToString();
            lblEmail.Text = dr["Email"].ToString();
            lblUserAddress.Text = dr["Address"].ToString();
            lblUserCity.Text = dr["City"].ToString();
            lblUserState.Text = dr["State"].ToString();
            lblUserZip.Text = dr["Zip"].ToString();
            chkHasReviewAuthorization.Checked = bool.Parse(dr["HasReviewAuthorization"].ToString());
            chkIsInManagement.Checked = bool.Parse(dr["IsInManagement"].ToString());
            chkIsInDirectorPanel.Checked = bool.Parse(dr["IsInDirectorPanel"].ToString());

            #endregion

            DivView("UserMenuClick");

        }
        catch (Exception ex)
        {
        }
    }

    protected void Add_Employee_Action()
    {
        string sql = @"INSERT INTO [Employee]
                (
                FirstName,
                LastName,
                Name,
                Designation,
                Phone,
                Email,
                Address,
                City,
                State,
                Zip,
                HasReviewAuthorization,
                IsInManagement,
                IsInDirectorPanel,
Password,
RoleID)
                Values(
                '" + CommonManager.SQLInjectionChecking(txtFirstName.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtLastName.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtFirstName.Text+" "+ txtLastName.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtDesignation.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtPhone.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtEmail.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtUserAddress.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtUserAddressCity.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtState.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtZip.Text) + @"',
                " + (chkHasReviewAuthorization.Checked ? 1 : 0) + @",
                " + (chkIsInManagement.Checked ? 1 : 0) + @",
                " + (chkIsInDirectorPanel.Checked ? 1 : 0) + @",
                '" + CommonManager.SQLInjectionChecking(txtPassword.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(ddlUserRole.SelectedValue) + @"'
);";
        DataSet ds = CommonManager.SQLExec(sql);
    }

    protected void Edit_Employee_Action()
    {
        string sql = @"Update [Employee]
                Set
                FirstName='" + CommonManager.SQLInjectionChecking(txtFirstName.Text) + @"',
                LastName='" + CommonManager.SQLInjectionChecking(txtLastName.Text) + @"',
                Name='" + CommonManager.SQLInjectionChecking(txtFirstName.Text + " " + txtLastName.Text) + @"',
                Designation='" + CommonManager.SQLInjectionChecking(txtDesignation.Text) + @"',
                Phone='" + CommonManager.SQLInjectionChecking(txtPhone.Text) + @"',
                Email='" + CommonManager.SQLInjectionChecking(txtEmail.Text) + @"',
                [Password]='" + CommonManager.SQLInjectionChecking(txtPassword.Text) + @"',
                Address='" + CommonManager.SQLInjectionChecking(txtUserAddress.Text) + @"',
                City='" + CommonManager.SQLInjectionChecking(txtUserAddressCity.Text) + @"',
                State='" + CommonManager.SQLInjectionChecking(txtState.Text) + @"',
                Zip='" + CommonManager.SQLInjectionChecking(txtZip.Text) + @"',
                HasReviewAuthorization=" + (chkHasReviewAuthorization.Checked ? 1 : 0) + @",
                IsInManagement=" + (chkIsInManagement.Checked ? 1 : 0) + @",
                IsInDirectorPanel=" + (chkIsInDirectorPanel.Checked ? 1 : 0) + @" ,
                RoleID=" + ddlUserRole.SelectedValue + @" 
        where ID=" + txtUserID.Text;
        DataSet ds = CommonManager.SQLExec(sql);
    }

    private void EmployeeReset()
    {
        
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtUserName.Text = "";
        txtDesignation.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtRetypePassword.Text = "";
        txtUserAddress.Text = "";
        txtUserAddressCity.Text = "";
        txtState.Text = "";
        txtZip.Text = "";
        txtId.Text = "";
        ddlUserRole.SelectedValue = "0";
        chkHasReviewAuthorization.Checked = false;
        chkIsInManagement.Checked = false;
        chkIsInDirectorPanel.Checked = false;
    }


    #endregion

    #region Client

    protected void btnAddOrEditClient_OnClick(object sender, EventArgs e)
    {
        DivView("ClientMenuClick");
        try
        {
            if (txtClientID.Text == "0")
            {
                Add_Customer_Action();

            }
            else
            {
                Edit_Customer_Action();
            }
            loadMenu("client");

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAddOrEditClientClose_OnClick(object sender, EventArgs e)
    {
        DivView("ClientMenuClick");

    }
    protected void btnClientViewEdit_OnClick(object sender, EventArgs e)
    {
        DivView("btnClientViewEdit_OnClick");

    }

    private void Edit_Customer(string id)
    {
        try
        {
            if (id == "0")
            {
                DivView("btnClientViewEdit_OnClick");
                ClientReset();
                return;
            }

            string sql = @"Select * from [Customer] where ID = " + id;
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];

            txtClientTitle.Text = dr["Title"].ToString();
            //txtKeyPerson.Text = dr["KeyPerson"].ToString();
            txtClientAddress.Text = dr["Address"].ToString();
            txtClientCity.Text = dr["City"].ToString();
            txtClientState.Text = dr["State"].ToString();
            txtClientZip.Text = dr["Zip"].ToString();
            txtClientPhone.Text = dr["Phone"].ToString();
            txtAltPhone.Text = dr["AltPhone"].ToString();
            txtClientEmail.Text = dr["Email"].ToString();
            txtNotes.Text = dr["Notes"].ToString();
            txtClientID.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0");
            ddlClientType.SelectedValue = dr["ClientType"].ToString();
            ddlClientKeyPersonTitle.SelectedValue = dr["keyPersonTitle"].ToString();
            txtClientAddressStreet.Text = dr["Street"].ToString();
            txtClientAddressSuite.Text = dr["Suite"].ToString();
            txtClientOfficePhone.Text = dr["OfficePhone"].ToString();
            txtClientFax.Text = dr["Fax"].ToString();

            #region Client View

            lblClientTitle.Text = dr["Title"].ToString();
            lblClientTitle1.Text = dr["Title"].ToString();
            lblKeyPerson.Text = dr["KeyPerson"].ToString();
            lblClientKeypersonTitle.Text = dr["keyPersonTitle"].ToString();
            lblClientType.Text = dr["ClientType"].ToString();
            lblClientAddress.Text = dr["Address"].ToString()+", "+ dr["Street"].ToString() + ", " + dr["Suite"].ToString() ;
            lblClientCity.Text = dr["City"].ToString();
            lblClientState.Text = dr["State"].ToString();
            lblClientZip.Text = dr["Zip"].ToString();
            lblClientPhone.Text = dr["Phone"].ToString();
            lblAltPhone.Text = dr["AltPhone"].ToString();
            lblClientOfficePhone.Text = dr["OfficePhone"].ToString();
            lblClientFax.Text = dr["Fax"].ToString();
            lblClientEmail.Text = dr["Email"].ToString();
            lblNotes.Text = dr["Notes"].ToString();
            lblClientID.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0");

            #endregion

            DivView("ClientMenuClick");

        }
        catch (Exception ex)
        {
        }
    }

   

    protected void Add_Customer_Action()
    {
        string sql = @"INSERT INTO [Customer]
                (
                Title,
                KeyPerson,
                Address,
                City,
                State,
                Zip,
                Phone,
                AltPhone,
                Email,
                Notes
           ,[ClientType]
           ,[keyPersonTitle]
           ,[Street]
           ,[Suite]
           ,[OfficePhone]
           ,[Fax])
                Values(
                '" + CommonManager.SQLInjectionChecking(txtClientTitle.Text) + @"',
                '" + CommonManager.SQLInjectionChecking("") + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientAddress.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientCity.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientState.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientZip.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientPhone.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtAltPhone.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientEmail.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtNotes.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(ddlClientType.SelectedValue) + @"',
                '" + CommonManager.SQLInjectionChecking(ddlClientKeyPersonTitle.SelectedValue) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientAddressStreet.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientAddressSuite.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientOfficePhone.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtClientFax.Text) + @"');
Select Max(ID) From Customer;
";
        DataSet ds = CommonManager.SQLExec(sql);
        loadClientMenu(ds.Tables[0].Rows[0][0].ToString());
    }

    protected void Edit_Customer_Action()
    {
        string sql = @"Update [Customer]
                Set
                Title='" + CommonManager.SQLInjectionChecking(txtClientTitle.Text) + @"',
                KeyPerson='" + CommonManager.SQLInjectionChecking("") + @"',
                Address='" + CommonManager.SQLInjectionChecking(txtClientAddress.Text) + @"',
                City='" + CommonManager.SQLInjectionChecking(txtClientCity.Text) + @"',
                State='" + CommonManager.SQLInjectionChecking(txtClientState.Text) + @"',
                Zip='" + CommonManager.SQLInjectionChecking(txtClientZip.Text) + @"',
                Phone='" + CommonManager.SQLInjectionChecking(txtClientPhone.Text) + @"',
                AltPhone='" + CommonManager.SQLInjectionChecking(txtAltPhone.Text) + @"',
                Email='" + CommonManager.SQLInjectionChecking(txtClientEmail.Text) + @"',
                Notes='" + CommonManager.SQLInjectionChecking(txtNotes.Text) + @"' 
                ,[ClientType]='" + CommonManager.SQLInjectionChecking(ddlClientType.SelectedValue) + @"' 
                ,[keyPersonTitle]='" + CommonManager.SQLInjectionChecking(ddlClientKeyPersonTitle.SelectedValue) + @"' 
                ,[Street]='" + CommonManager.SQLInjectionChecking(txtClientAddressStreet.Text) + @"' 
                ,[Suite]='" + CommonManager.SQLInjectionChecking(txtClientAddressSuite.Text) + @"' 
                ,[OfficePhone]='" + CommonManager.SQLInjectionChecking(txtClientOfficePhone.Text) + @"' 
                ,[Fax]='" + CommonManager.SQLInjectionChecking(txtClientFax.Text) + @"' 
        where ID=" + txtClientID.Text;
        DataSet ds = CommonManager.SQLExec(sql);

    }

    private void ClientReset()
    {

        txtClientTitle.Text = "";
        //txtKeyPerson.Text = "";
        txtClientAddress.Text = "";
        txtClientCity.Text = "";
        txtClientState.Text = "";
        txtClientZip.Text = "";
        txtClientPhone.Text = "";
        txtAltPhone.Text = "";
        txtClientEmail.Text = "";
        txtNotes.Text = "";
        txtClientID.Text = "0";
    }
    #endregion

    protected void txtProjectSearch_OnTextChanged(object sender, EventArgs e)
    {
        loadMenu("project");
    }

    protected void txtClientSearch_OnTextChanged(object sender, EventArgs e)
    {
        loadMenu("client");
    }

    protected void txtProposalSearch_OnTextChanged(object sender, EventArgs e)
    {
        loadMenu("proposal");
    }

    protected void lbtnClientMore_OnClick(object sender, EventArgs e)
    {
        hfClientCount.Value += (30 + int.Parse(hfClientCount.Value));
        loadMenu("client");
    }

    protected void lbtnResetClient_OnClick(object sender, EventArgs e)
    {
        txtClientSearch.Text = "";
        loadMenu("client");
    }

    protected void lbtnResetProposal_OnClick(object sender, EventArgs e)
    {

        txtProposalSearch.Text = "";
        loadMenu("proposal");
    }

    protected void lbtnProposalMore_OnClick(object sender, EventArgs e)
    {
        hfProposalCount.Value += (30 + int.Parse(hfProposalCount.Value));
        loadMenu("proposal");


    }

    protected void lbtnResetProject_OnClick(object sender, EventArgs e)
    {
        txtProjectSearch.Text = "";
        loadMenu("project");

    }

    protected void lbtnProjectMore_OnClick(object sender, EventArgs e)
    {
        hfProjectCount.Value += (30 + int.Parse(hfProjectCount.Value));
        loadMenu("project");


    }

    protected void ddlUserStatus_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        loadMenu("user");
    }

    protected void btnAddKeyPerson_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (Client_Key_Person_ID.Value == "")
            {
                string sql = @"INSERT INTO [Client_Key_Person]
                (
                Customer_ID,
                Key_Person,
                Title,
                Contact_No)
                Values(
                " + CommonManager.SQLInjectionChecking(hfSelectedID.Value) + @",
                '" + CommonManager.SQLInjectionChecking(txtKey_Person.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtTitle.Text) + @"',
                '" + CommonManager.SQLInjectionChecking(txtContact_No.Text) + @"');";
                DataSet ds = CommonManager.SQLExec(sql);
            }
            else
            {
                string sql = @"Update [Client_Key_Person]
                Set
                        Customer_ID=" + CommonManager.SQLInjectionChecking(hfSelectedID.Value) + @",
                        Key_Person='" + CommonManager.SQLInjectionChecking(txtKey_Person.Text) + @"',
                        Title='" + CommonManager.SQLInjectionChecking(txtTitle.Text) + @"',
                        Contact_No='" + CommonManager.SQLInjectionChecking(txtContact_No.Text) + @"' 
                where Client_Key_Person_ID=" + Client_Key_Person_ID.Value;
                DataSet ds = CommonManager.SQLExec(sql);
            }

            loadClientKeyPersonList();
        }
        catch (Exception exception)
        {
            
        }
    }

    private void loadClientKeyPersonList()
    {
        try
        {
            string sql = @"
SELECT  ROW_NUMBER() OVER(ORDER BY [Client_Key_Person].Key_Person asc) AS RowNo
                    ,[Client_Key_Person].Client_Key_Person_ID as id
                    ,[Client_Key_Person].Key_Person
                    ,[Client_Key_Person].Title
                    ,[Client_Key_Person].Contact_No
                from [Client_Key_Person]
                where [Client_Key_Person].Customer_ID=" + hfSelectedID.Value + @"
                        order by [Client_Key_Person].Key_Person";
            DataSet ds = CommonManager.SQLExec(sql);

            gvClientKeyPerson.DataSource = ds.Tables[0];
            gvClientKeyPerson.DataBind();

            gvClientKeyPersonView.DataSource = ds.Tables[0];
            gvClientKeyPersonView.DataBind();
        }
        catch (Exception e)
        {
            

        }
    }

    protected void lbtnClientKeyPersonEdit_Click(object sender, EventArgs e)
    {
        clearClientKeyPersonField();
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Client_Key_Person_ID.Value = id.ToString();

        string sql = @"Select * from [Client_Key_Person] where Client_Key_Person_ID = " + id.ToString();
        DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];

        txtKey_Person.Text = dr["Key_Person"].ToString();
        txtTitle.Text = dr["Title"].ToString();
        txtContact_No.Text = dr["Contact_No"].ToString();
        
    }

    private void clearClientKeyPersonField()
    {
        try
        {
            Client_Key_Person_ID.Value = "";
            txtKey_Person.Text = "";
            txtTitle.Text = "";
            txtContact_No.Text = "";
        }
        catch (Exception e)
        {
            
        }
    }

    protected void lbtnNewClient_OnClick(object sender, EventArgs e)
    {
        loadClientMenu("0");
    }

    protected void rbtnlProposalType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnlProposalType.SelectedValue == "Daily")
        {
            div_ProposalType_daily.Visible = true;
            div_ProposalType_Project.Visible = false;
        }
        else
        {
            div_ProposalType_daily.Visible = false;
            div_ProposalType_Project.Visible = true;
        }
    }
}