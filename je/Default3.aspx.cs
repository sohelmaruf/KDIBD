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
public partial class je_Default : System.Web.UI.Page
{
 
        private Project project;
        private ProjectRepository repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadMenu();
            if (!IsPostBack)
            {
                //Layout.SelectedMainMenu = "Project";
            dropdownState.GenerateStateItems();
                dropdownClient.GenerateClientItems();
                dropdownProjectStatus.GenerateProjectStatus();
                dropDownProjectPriority.GenerateProjectPriority();
                DropDownProjectType.GenerateProjectType();
                if (Request.QueryString["id"] != null)
                {
                    loadProject(Request.QueryString["id"]);

                }
                else
                {
                    txtId.Text = "0";
                }
                load_ddl();
            }

    }
    private void loadMenu()
    {
        try
        {
            string sql = @"


SELECT  [Id]
      ,[Name]
  FROM [Employee]

SELECT  [Id]
      ,[Title]
  FROM [Customer]


SELECT  [Id]
      ,[Name]
  FROM [Proposal]

SELECT  [Id]
      ,[Title]
  FROM [Project]
";

            DataSet ds = CommonManager.SQLExec(sql);

           

            #region User Menus
            lblMenuUser.Text = @"
        <li class='active treeview'>
          <a href='#'>
            <i class='fa fa-dashboard'></i> <span>User</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
            gvMem_RAJUK.DataSource = ds.Tables[0];
            gvMem_RAJUK.DataBind();
            lblMenuClient.Text = @"
          </ul>
        </li>
        
";
            #endregion


            #region Client Menus
            lblMenuClient.Text += @"
        <li class='treeview'>
          <a href='#'>
            <i class='fa fa-dashboard'></i> <span>Client</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            Repeater2.DataSource = ds.Tables[1];
            Repeater2.DataBind();

            lblMenuProposal.Text = @"
          </ul>
        </li>
        
";
            #endregion


            #region Proposal Menus
            lblMenuProposal.Text += @"
        <li class='treeview'>
          <a href='#'>
            <i class='fa fa-dashboard'></i> <span>Proposal</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            Repeater3.DataSource = ds.Tables[2];
            Repeater3.DataBind();

            lblMenuProject1.Text = @"
          </ul>
        </li>
        
";
            #endregion


            #region Project Menus
            lblMenuProject1.Text += @"
        <li class='treeview'>
          <a href='#'>
            <i class='fa fa-dashboard'></i> <span>Project</span>
            <span class='pull-right-container'>
              <i class='fa fa-angle-left pull-right'></i>
            </span>
          </a>
          <ul class='treeview-menu'>";
            Repeater4.DataSource = ds.Tables[3];
            Repeater4.DataBind();

           
            #endregion

            
        }
        catch (Exception e)
        {
        }
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
  FROM  [Employee] order by [Name]";
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
            }
            catch (Exception e)
            {

            }
        }

        private void loadProject(string id)
        {
            try
            {
                project = new Project();
                this.project.Id = int.Parse(id);
                this.repository = new ProjectRepository();
                this.project = repository.Get(this.project.Id);
                assignTextValues();
                //Layout.SelectedSubMenuId = project.Id.ToString();

                loadTasks(id);
            }
            catch (Exception e)
            {


            }

        }

        private void loadTasks(string id)
        {

            try
            {
                string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle
FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID
where Project.id=" + Request.QueryString["id"];

                DataSet ds = CommonManager.SQLExec(sql);
                rptrTaskList.DataSource = ds.Tables[0];
                rptrTaskList.DataBind();
                string html = @"
<table class='table table-data2 taskList' >
                    <thead>
                        <tr>
                            <th>SI</th>
                            <th>Project / Proposal</th>
                            <th>Client</th>
                            <th>Task Title</th>
                            <th>Deadline</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                       ";


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    html += @"
                    <tr class='tr-shadow'>
                            <td>1</td>
                            <td>
                                <span class='block-email'>" + dr["ProjectTitle"].ToString() + @"</span>
                            </td>
                            <td class='desc'>" + dr["ClientTitle"].ToString() + @"</td>
                            <td>" + dr["TaskName"].ToString() + @"</td>
                            <td>" + DateTime.Parse(dr["Deadline"].ToString()).ToString("MM/dd/yyyy") + @"</td>
                            <td>
                                <span class='status--process'>" + dr["StatusTitle"].ToString() + @"</span>
                            </td>
                            <td>
                                <div class='table-data-feature'>
                                    <button class='item' data-toggle='tooltip' data-placement='top' title='Edit'>
                                        <i class='zmdi zmdi-edit'></i>
                                    </button>
                                    <button class='item' data-toggle='tooltip' data-placement='top' title='Delete'>
                                        <i class='zmdi zmdi-delete'></i>
                                    </button>
                                </div>
                            </td>
                        </tr>
                        <tr class='spacer'></tr>
                    ";

                }


                html += @"       
                            </tbody>
                        </table>
                        ";

                //lblTaskList.Text = html;
            }
            catch (Exception e)
            {

            }
        }
        protected void rptrTaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


            string sql = @"SELECT  ROW_NUMBER() OVER(ORDER BY Project.Title,Task.TaskName asc) AS RowNo,
TaskStatus.StatusTitle, Task.TaskName, Project.Title AS ProjectTitle,
Task.Deadline, Customer.Title as ClientTitle,Employee.Name as AssignedTo
,Task.ShortDescription, Task.FullDescription

FROM    Customer INNER JOIN
        TaskStatus INNER JOIN
        Task ON TaskStatus.Id = Task.TaskStatusID INNER JOIN
        Project ON Task.ProjectID = Project.Id ON Customer.Id = Project.CustomerID INNER JOIN
        Employee ON Task.DesignByEmployeeID = Employee.Id
where Project.id=" + Request.QueryString["id"];

            DataSet ds = CommonManager.SQLExec(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["RowNo"].ToString() == (e.Item.ItemIndex + 1).ToString())
                {
                    loadTaskDetails(dr);
                    btnAddTaskClose_OnClick(this, new EventArgs());
                    div_TaskDetails.Visible = true;
                    break;
                }
            }



        }

        private void loadTaskDetails(DataRow dr)
        {

            try
            {
                lblTaskTitleDetails.Text = dr["TaskName"].ToString();
                lblTaskDetails_AssignedTo.Text = dr["TaskName"].ToString();
                lblTaskDetails_Deadline.Text = dr["Deadline"].ToString();
                lblTaskDetails_FullDescription.Text = dr["FullDescription"].ToString();
                lblTaskDetails_TaskStatus.Text = dr["StatusTitle"].ToString();
                lblTaskDetails_ShortDetails.Text = dr["ShortDescription"].ToString();
            }
            catch (Exception e)
            {

            }
        }

        private void assignTextValues()
        {
            this.txtId.Text = project.Id.ToString();
            this.txtAddress.Text = project.JobAddress;
            this.txtCeilingJoist.Text = project.TypeOfCeilingJoist;
            this.txtCity.Text = project.JobCity;
            this.txtClientData.Text = project.CustomerData;
            this.txtClientInvoice.Text = project.Invoice;
            this.txtCourierAddress.Text = project.CouriertoAddress;
            this.txtCourierWhom.Text = project.CouriertoWhom;
            this.txtCrawlSpace.Text = project.CrawlSpaceJoist;
            this.txtDueDate.Text = Convert.ToDateTime(project.DueDate).ToString("yyyy-MM-dd"); ;
            this.txtStartDate.Text = Convert.ToDateTime(project.StartDate).ToString("yyyy-MM-dd");
            this.txtEmailAddress.Text = project.EmailAddress;
            this.txtFloorJoistSpacing.Text = project.MaxFloorJoistSpacing;
            this.txtFloorjoist.Text = project.TypeOfFloorJoist;
            this.txtHoldNote.Text = project.ProjectHoldNotes;
            this.txtHowSend.Text = project.How_WhenSending;
            this.txtMaterialNotes.Text = project.ProjectMaterialNotes;
            this.txtRoofingMaterials.Text = project.RoofingMaterials;
            this.txtWeightMaterials.Text = project.WeightOfRoofingMaterials;
            this.txtNumberOfCopies.Text = project.NumberOfCopies.ToString();
            this.txtPlanNumber.Text = project.PlanName;
            this.txtPersonalPhoneNumber.Text = project.PickupByPersonPhoneNumber;
            this.txtPickPersonName.Text = project.PickupByPersonName;
            this.txtPlanName.Text = project.PlanName;
            this.txtProjectName.Text = project.Title;
            this.txtProjectNote.Text = project.ProjectTypeNotes;
            this.txtProjectNumber.Text = project.ProjectNumber;
            this.txtZipCode.Text = project.JobZipAddress;

            this.DropDownFoundationType.SelectedValue = project.FoundationTypeID.ToString();
            this.DropDownProjectType.SelectedValue = project.FoundationTypeID.ToString();
            this.DropDownProjetReviewed.SelectedValue = project.ReviewedByID.ToString();
            this.dropDownProjectPriority.SelectedValue = project.ProjectPriorityID.ToString();
            this.dropdownClient.SelectedValue = project.CustomerID.ToString();
            this.dropdownProjectStatus.SelectedValue = project.ProjectStatusID.ToString();
            this.dropdownState.SelectedValue = project.JobState;

            this.chkFoundation.Checked = project.IsFoundation;
            this.chkIsCourier.Checked = project.IsHaveCourierPlans;
            this.chkIsFraming.Checked = project.IsFraming;
            this.chkIsHaveEmail.Checked = project.IsHaveEmail;
            this.chkPickup.Checked = project.IsCustomerWillPickup;
            this.chkSoilReport.Checked = project.IsHaveSoilsReport;


            #region Project Details View

            lblProjectDetails_JobAddress.Text = project.JobAddress;
            lblProjectDetails_TypeOfCeilingJoist.Text = project.TypeOfCeilingJoist;
            lblProjectDetails_JobCity.Text = project.JobCity;
            lblProjectDetails_CustomerData.Text = project.CustomerData;
            lblProjectDetails_Invoice.Text = project.Invoice;
            lblProjectDetails_CourierToAddress.Text = project.CouriertoAddress;
            lblProjectDetails_CourierToWhom.Text = project.CouriertoWhom;
            lblProjectDetails_FoundationCrawlSpaceJoist.Text = project.CrawlSpaceJoist;
            lblProjectDetails_DueDate.Text = Convert.ToDateTime(project.DueDate).ToString("yyyy-MM-dd"); ;
            lblProjectDetails_StartDate.Text = Convert.ToDateTime(project.StartDate).ToString("yyyy-MM-dd");
            lblProjectDetails_EmailAddress.Text = project.EmailAddress;
            lblProjectDetails_MaxFloorJoistSpacing.Text = project.MaxFloorJoistSpacing;
            lblProjectDetails_TypeOfFloorJoist.Text = project.TypeOfFloorJoist;
            lblProjectDetails_ProjectHoldHotes.Text = project.ProjectHoldNotes;
            lblProjectDetails_SoilReportSent.Text = project.How_WhenSending;
            lblProjectDetails_ProjectMaterialNotes.Text = project.ProjectMaterialNotes;
            lblProjectDetails_RoofingMaterials.Text = project.RoofingMaterials;
            lblProjectDetails_WeightOfRoofingMaterials.Text = project.WeightOfRoofingMaterials;
            lblProjectDetails_NumberOfCopies.Text = project.NumberOfCopies.ToString();
            lblProjectDetails_PlanName.Text = project.PlanName;
            lblProjectDetails_PickupByPersonPhoneNumber.Text = project.PickupByPersonPhoneNumber;
            lblProjectDetails_PickUpByPersonName.Text = project.PickupByPersonName;
            lblProjectDetails_PlanName.Text = project.PlanName;
            lblProjectDetails_ProjectName.Text = project.Title;
            lblProjectDetails_ProjectTypeNote.Text = project.ProjectTypeNotes;
            lblProjectDetails_ProjectNumber.Text = project.ProjectNumber;
            lblProjectDetails_JobZip.Text = project.JobZipAddress;

            lblProjectDetails_FoundationType.Text = DropDownFoundationType.SelectedItem.Text;//FoundationTypeID.ToString();
            lblProjectDetails_ProjectType.Text = DropDownProjectType.SelectedItem.Text;//FoundationTypeID.ToString();
            lblProjectDetails_ReviewedBy.Text = DropDownProjetReviewed.SelectedItem.Text;//ReviewedByID.ToString();
            lblProjectDetails_Priority.Text = dropDownProjectPriority.SelectedItem.Text;//ProjectPriorityID.ToString();
            lblProjectDetails_ClientName.Text = dropdownClient.SelectedItem.Text;//CustomerID.ToString();
            lblProjectDetails_ProjectStatus.Text = dropdownProjectStatus.SelectedItem.Text;//ProjectStatusID.ToString();
            lblProjectDetails_JobState.Text = dropdownState.SelectedItem.Text;//JobState;

            lblProjectDetails_IsFoundation.Text = chkFoundation.Checked.ToString();// = project.IsFoundation;
            lblProjectDetails_IsHaveCourierPlans.Text = chkIsCourier.Checked.ToString();//= project.IsHaveCourierPlans;
            lblProjectDetails_IsFraming.Text = chkIsFraming.Checked.ToString();//= project.IsFraming;
            lblProjectDetails_IsHaveEmail.Text = chkIsHaveEmail.Checked.ToString();//= project.IsHaveEmail;
            lblProjectDetails_IsClientWillPickup.Text = chkPickup.Checked.ToString();//= project.IsCustomerWillPickup;
            lblProjectDetails_IsHaveSoilsReport.Text = chkSoilReport.Checked.ToString();//= project.IsHaveSoilsReport;

            #endregion

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Project project = new Project
            {
                Id = int.Parse(txtId.Text),
                ProjectNumber = txtProjectNumber.Text,
                PlanName = txtPlanName.Text,
                PlanNumber = txtPlanNumber.Text,
                ProjectTypeNotes = txtProjectNote.Text,
                CrawlSpaceJoist = txtCrawlSpace.Text,
                How_WhenSending = txtHowSend.Text,
                TypeOfFloorJoist = txtFloorjoist.Text,
                MaxFloorJoistSpacing = txtFloorJoistSpacing.Text,
                TypeOfCeilingJoist = txtCeilingJoist.Text,
                RoofingMaterials = txtRoofingMaterials.Text,
                WeightOfRoofingMaterials = txtWeightMaterials.Text,
                ProjectMaterialNotes = txtMaterialNotes.Text,
                CouriertoWhom = txtCourierWhom.Text,
                PickupByPersonName = txtPickPersonName.Text,
                PickupByPersonPhoneNumber = txtPersonalPhoneNumber.Text,
                NumberOfCopies = txtNumberOfCopies.Text,
                ProjectHoldNotes = txtHoldNote.Text,
                Invoice = txtClientInvoice.Text,
                CustomerData = txtClientData.Text,
                CouriertoAddress = txtCourierAddress.Text,
                CustomerID = int.Parse(dropdownClient.SelectedValue),
                DueDate = txtDueDate.Text,
                EmailAddress = txtEmailAddress.Text,
                FoundationTypeID = int.Parse(DropDownFoundationType.SelectedValue),
                IsCustomerWillPickup = chkPickup.Checked,
                IsFoundation = chkFoundation.Checked,
                IsFraming = chkIsFraming.Checked,
                IsHaveSoilsReport = chkSoilReport.Checked,
                IsHaveCourierPlans = chkIsCourier.Checked,
                IsHaveEmail = chkIsHaveEmail.Checked,
                JobCity = txtCity.Text,
                JobState = dropdownState.SelectedValue,
                JobZipAddress = txtZipCode.Text,
                StartDate = txtStartDate.Text,
                Title = txtProjectName.Text,
                ProjectStatusID = int.Parse(dropdownProjectStatus.SelectedValue),
                ProjectPriorityID = int.Parse(dropDownProjectPriority.SelectedValue),
                ReviewedByID = Int32.Parse(DropDownProjetReviewed.SelectedValue),
                ProjectTypeID = int.Parse(DropDownProjectType.SelectedValue),
                JobAddress = txtAddress.Text
            };
            var repo = new ProjectRepository();
            project = repo.Add(project);
            this.lblMessage.Text = "Project updated successfully!";
            loadProject(txtId.Text);
            btnAddTaskClose_OnClick(this, new EventArgs());

        }

        protected void btnAddTask_onClick(object sender, EventArgs e)
        {
            divAddTask.Visible = true;

        }

        protected void btnAddTaskClose_OnClick(object sender, EventArgs e)
        {
            divAddTask.Visible = false;
            divProjectEdit.Visible = false;
            div_TaskDetails.Visible = false;
            divProjectView.Visible = true;
        }

        protected void btnProjectViewEdit_OnClick(object sender, EventArgs e)
        {
            divAddTask.Visible = false;
            divProjectEdit.Visible = true;
            divProjectView.Visible = false;
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
           (" + Request.QueryString["id"] + @"--ProjectID, int,>
                    ," + ddlTaskStatusID.SelectedValue + @"--TaskStatusID, int,>
                    ,'" + txtTaskTitle.Text + @"'--TaskName, nvarchar(100),>
                    ," + ddlTaskAssignedTo.SelectedValue + @"--DesignByEmployeeID, int,>
                    ,'" + txtDateline.Text + @"'--Deadline, datetime,>
                    ,'" + txtTaskShortDescription.Text + @"'--ShortDescription, nvarchar(200),>
                    ,'" + "" + @"'--FullDescription, nvarchar(500),>
                    ,'" + "" + @"'--NewReviewNotes, nvarchar(500),>
                    ,'" + "" + @"'--ReviewNotes, nvarchar(500),>
                    ," + "1" + @"--TaskForProject, bit,>
                    ,GETDATE()--CreatedDate, date,>
                    ,1--CreatedBy, int,>
                    )";
                CommonManager.SQLExec(sql);
                btnAddTaskClose_OnClick(this, new EventArgs());
                loadTasks(Request.QueryString["id"]);
            }
            catch (Exception exception)
            {

            }
        }


        protected void btnAddNote_OnClick(object sender, EventArgs e)
        {

            btnAddTaskClose_OnClick(this, new EventArgs());
        }

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        //Inside ItemCreatedEvent
        ScriptManager scriptMan = ScriptManager.GetCurrent(this);
        LinkButton btn = e.Item.FindControl("LinkButton1") as LinkButton;
        if (btn != null)
        {
            btn.Click += LinkButton1_Click;
            scriptMan.RegisterAsyncPostBackControl(btn);
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {

        lbltest.Text = "";
    }
}