using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Proposal : System.Web.UI.Page
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
                Delete_Proposal();
                Response.Redirect("Admin_Proposal.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Proposal();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Proposal()
    {
        try
        {
            string sql=@"Select * from [Proposal] where Proposal_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_producteev(sql).Tables[0].Rows[0];
            
            txtName.Text = dr["Name"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtzip.Text = dr["zip"].ToString();
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
            txtId.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0,0");
            txtInitialContractDate.Text = DateTime.Parse(dr["InitialContractDate"].ToString()).ToString("dd/MM/yyyy");
            txtSubmittalDate.Text = DateTime.Parse(dr["SubmittalDate"].ToString()).ToString("dd/MM/yyyy");
            txtRevisionDate.Text = DateTime.Parse(dr["RevisionDate"].ToString()).ToString("dd/MM/yyyy");
            ddlClientID.SelectedValue = dr["ClientID"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Proposal()
    {
        try
        {
            string sql=@"Delete [Proposal] where Proposal_ID = "+Request.QueryString["delete"];
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
                string sql=@"";
                if(sql!="")
                ds = CommonManager.SQLExec_producteev(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
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
                [Proposal].Id
                ,[Proposal].Name
                ,[Proposal].Address
                ,[Proposal].City
                ,[Proposal].State
                ,[Proposal].zip
                ,[Proposal].Details
                ,[Proposal].InitialContractDate
                ,[Proposal].SubmittalDate
                ,[Proposal].RevisionDate
                ,[Proposal].ProposalType
                ,[Proposal].DailyType
                ,[Proposal].ProjectType
                ,[Proposal].ProjectOtherTypeValue
                ,[Proposal].FoundationTypeValue
                ,[Proposal].FoundationSlabTypeValue
                ,[Proposal].FoundationPierTypeValue
                ,[Proposal].FoundationPierRemiedialTypeValue
                ,[Proposal].FoundationPierRemiedialOtherTypeValue
                ,[Proposal].FoundationOtherTypeValue
                ,[Proposal].FrameTypeValue
                ,[Proposal].FrameResidentialValue
                ,[Proposal].FrameResidentialOtherValue
                ,[Proposal].FrameExteriorValue
                ,[Proposal].FrameExteriorOtherValue
                ,[Proposal].FrameRoofTypeValue
                ,[Proposal].FrameRoofTypeOtherValue
                ,[Proposal].RetainingWallValue
                ,[Proposal].RetainingWallTypeValue
                ,[Proposal].RetainingWallTypeWallValue
                ,[Proposal].RetainingWallTypeWallOtherValue
                ,[Proposal].PoolValue
                ,[Proposal].PoolCompnayDesignValue
                ,[Proposal].ClientID
         from [Proposal]
        order by [Proposal].Proposal_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Id</th>
                <th>Name</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>zip</th>
                <th>Details</th>
                <th>InitialContractDate</th>
                <th>SubmittalDate</th>
                <th>RevisionDate</th>
                <th>ProposalType</th>
                <th>DailyType</th>
                <th>ProjectType</th>
                <th>ProjectOtherTypeValue</th>
                <th>FoundationTypeValue</th>
                <th>FoundationSlabTypeValue</th>
                <th>FoundationPierTypeValue</th>
                <th>FoundationPierRemiedialTypeValue</th>
                <th>FoundationPierRemiedialOtherTypeValue</th>
                <th>FoundationOtherTypeValue</th>
                <th>FrameTypeValue</th>
                <th>FrameResidentialValue</th>
                <th>FrameResidentialOtherValue</th>
                <th>FrameExteriorValue</th>
                <th>FrameExteriorOtherValue</th>
                <th>FrameRoofTypeValue</th>
                <th>FrameRoofTypeOtherValue</th>
                <th>RetainingWallValue</th>
                <th>RetainingWallTypeValue</th>
                <th>RetainingWallTypeWallValue</th>
                <th>RetainingWallTypeWallOtherValue</th>
                <th>PoolValue</th>
                <th>PoolCompnayDesignValue</th>
                <th>ClientID</th>
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
                
                            <td>"+decimal.Parse(dr["Id"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+dr["Name"].ToString()+@"</td>
                
                            <td>"+dr["Address"].ToString()+@"</td>
                
                            <td>"+dr["City"].ToString()+@"</td>
                
                            <td>"+dr["State"].ToString()+@"</td>
                
                            <td>"+dr["zip"].ToString()+@"</td>
                
                            <td>"+dr["Details"].ToString()+@"</td>
                
                            <td>"+DateTime.Parse(dr["InitialContractDate"].ToString()).ToString("dd MMM yyyy")+@"</td>
                
                            <td>"+DateTime.Parse(dr["SubmittalDate"].ToString()).ToString("dd MMM yyyy")+@"</td>
                
                            <td>"+DateTime.Parse(dr["RevisionDate"].ToString()).ToString("dd MMM yyyy")+@"</td>
                
                            <td>"+dr["ProposalType"].ToString()+@"</td>
                
                            <td>"+dr["DailyType"].ToString()+@"</td>
                
                            <td>"+dr["ProjectType"].ToString()+@"</td>
                
                            <td>"+dr["ProjectOtherTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationSlabTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationPierTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationPierRemiedialTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationPierRemiedialOtherTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FoundationOtherTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameResidentialValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameResidentialOtherValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameExteriorValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameExteriorOtherValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameRoofTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["FrameRoofTypeOtherValue"].ToString()+@"</td>
                
                            <td>"+dr["RetainingWallValue"].ToString()+@"</td>
                
                            <td>"+dr["RetainingWallTypeValue"].ToString()+@"</td>
                
                            <td>"+dr["RetainingWallTypeWallValue"].ToString()+@"</td>
                
                            <td>"+dr["RetainingWallTypeWallOtherValue"].ToString()+@"</td>
                
                            <td>"+dr["PoolValue"].ToString()+@"</td>
                
                            <td>"+dr["PoolCompnayDesignValue"].ToString()+@"</td>
                
                            <td>"+decimal.Parse(dr["ClientID"].ToString()).ToString("0,0")+@"</td>
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
        
        txtId.Text="0";
        txtInitialContractDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        txtSubmittalDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        txtRevisionDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        ddlClientID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Proposal_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Proposal_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Proposal_Action()
    {
        string sql=@"INSERT INTO [Proposal]
                (
                Id,
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
                "+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtzip.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtInitialContractDate.Text)).ToString("yyyy-MM-dd hh:mm tt"))+@"',
                '"+CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtSubmittalDate.Text)).ToString("yyyy-MM-dd hh:mm tt"))+@"',
                '"+CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtRevisionDate.Text)).ToString("yyyy-MM-dd hh:mm tt"))+@"',
                '"+CommonManager.SQLInjectionChecking(txtProposalType.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtDailyType.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtProjectType.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtProjectOtherTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationSlabTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationPierTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialOtherTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFoundationOtherTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameResidentialValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameResidentialOtherValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameExteriorValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameExteriorOtherValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameRoofTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtFrameRoofTypeOtherValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtRetainingWallValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallOtherValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPoolValue.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPoolCompnayDesignValue.Text)+@"',
                "+CommonManager.SQLInjectionChecking(txtClientID.Text.Replace(",",""))+@");";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Proposal.aspx?saved=1");
            
    }

    protected void Edit_Proposal_Action()
    {
        string sql=@"Update [Proposal]
                Set
                Id="+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                Name='"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                Address='"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                City='"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                State='"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                zip='"+CommonManager.SQLInjectionChecking(txtzip.Text)+@"',
                Details='"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"',
                InitialContractDate='"+DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtInitialContractDate.Text))).ToString("yyyy-MM-dd hh:mm tt")+@"',
                SubmittalDate='"+DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtSubmittalDate.Text))).ToString("yyyy-MM-dd hh:mm tt")+@"',
                RevisionDate='"+DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtRevisionDate.Text))).ToString("yyyy-MM-dd hh:mm tt")+@"',
                ProposalType='"+CommonManager.SQLInjectionChecking(txtProposalType.Text)+@"',
                DailyType='"+CommonManager.SQLInjectionChecking(txtDailyType.Text)+@"',
                ProjectType='"+CommonManager.SQLInjectionChecking(txtProjectType.Text)+@"',
                ProjectOtherTypeValue='"+CommonManager.SQLInjectionChecking(txtProjectOtherTypeValue.Text)+@"',
                FoundationTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationTypeValue.Text)+@"',
                FoundationSlabTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationSlabTypeValue.Text)+@"',
                FoundationPierTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationPierTypeValue.Text)+@"',
                FoundationPierRemiedialTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialTypeValue.Text)+@"',
                FoundationPierRemiedialOtherTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationPierRemiedialOtherTypeValue.Text)+@"',
                FoundationOtherTypeValue='"+CommonManager.SQLInjectionChecking(txtFoundationOtherTypeValue.Text)+@"',
                FrameTypeValue='"+CommonManager.SQLInjectionChecking(txtFrameTypeValue.Text)+@"',
                FrameResidentialValue='"+CommonManager.SQLInjectionChecking(txtFrameResidentialValue.Text)+@"',
                FrameResidentialOtherValue='"+CommonManager.SQLInjectionChecking(txtFrameResidentialOtherValue.Text)+@"',
                FrameExteriorValue='"+CommonManager.SQLInjectionChecking(txtFrameExteriorValue.Text)+@"',
                FrameExteriorOtherValue='"+CommonManager.SQLInjectionChecking(txtFrameExteriorOtherValue.Text)+@"',
                FrameRoofTypeValue='"+CommonManager.SQLInjectionChecking(txtFrameRoofTypeValue.Text)+@"',
                FrameRoofTypeOtherValue='"+CommonManager.SQLInjectionChecking(txtFrameRoofTypeOtherValue.Text)+@"',
                RetainingWallValue='"+CommonManager.SQLInjectionChecking(txtRetainingWallValue.Text)+@"',
                RetainingWallTypeValue='"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeValue.Text)+@"',
                RetainingWallTypeWallValue='"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallValue.Text)+@"',
                RetainingWallTypeWallOtherValue='"+CommonManager.SQLInjectionChecking(txtRetainingWallTypeWallOtherValue.Text)+@"',
                PoolValue='"+CommonManager.SQLInjectionChecking(txtPoolValue.Text)+@"',
                PoolCompnayDesignValue='"+CommonManager.SQLInjectionChecking(txtPoolCompnayDesignValue.Text)+@"',
                ClientID="+CommonManager.SQLInjectionChecking(txtClientID.Text.Replace(",",""))+@" 
        where Proposal_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Proposal.aspx?edited=1");
            
    }

    private void btnResetProposal()
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtName.Text="";
        txtAddress.Text="";
        txtCity.Text="";
        txtState.Text="";
        txtzip.Text="";
        txtDetails.Text="";
        txtProposalType.Text="";
        txtDailyType.Text="";
        txtProjectType.Text="";
        txtProjectOtherTypeValue.Text="";
        txtFoundationTypeValue.Text="";
        txtFoundationSlabTypeValue.Text="";
        txtFoundationPierTypeValue.Text="";
        txtFoundationPierRemiedialTypeValue.Text="";
        txtFoundationPierRemiedialOtherTypeValue.Text="";
        txtFoundationOtherTypeValue.Text="";
        txtFrameTypeValue.Text="";
        txtFrameResidentialValue.Text="";
        txtFrameResidentialOtherValue.Text="";
        txtFrameExteriorValue.Text="";
        txtFrameExteriorOtherValue.Text="";
        txtFrameRoofTypeValue.Text="";
        txtFrameRoofTypeOtherValue.Text="";
        txtRetainingWallValue.Text="";
        txtRetainingWallTypeValue.Text="";
        txtRetainingWallTypeWallValue.Text="";
        txtRetainingWallTypeWallOtherValue.Text="";
        txtPoolValue.Text="";
        txtPoolCompnayDesignValue.Text="";
        txtId.Text="";
        txtInitialContractDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        txtSubmittalDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        txtRevisionDate.Text=DateTime.Today.ToString("dd/MM/yyyy");
        ddlClientID.SelectedValue="0";
    }

}
