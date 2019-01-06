using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_E_Page : System.Web.UI.Page
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
                Delete_E_Page();
                Response.Redirect("Admin_E_Page.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_E_Page();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_E_Page()
    {
        try
        {
            string sql=@"Select * from [E_Page] where E_Page_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_Protal_eEngr(sql).Tables[0].Rows[0];
            
            txtPageTitle.Text = dr["PageTitle"].ToString();
            txtLogo.Text = dr["Logo"].ToString();
            txtBanner.Text = dr["Banner"].ToString();
            txtDetails.Text = dr["Details"].ToString();
            ddlPageID.SelectedValue = dr["PageID"].ToString();
            ddlMem_MemberID.SelectedValue = dr["Mem_MemberID"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_E_Page()
    {
        try
        {
            string sql=@"Delete [E_Page] where E_Page_ID = "+Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec_Protal_eEngr(sql);
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
                ds = CommonManager.SQLExec_Protal_eEngr(sql);
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
                [E_Page].PageID
                ,[E_Page].Mem_MemberID
                ,[E_Page].PageTitle
                ,[E_Page].Logo
                ,[E_Page].Banner
                ,[E_Page].Details
         from [E_Page]
        order by [E_Page].E_Page_Name";
        DataSet ds = CommonManager.SQLExec_Protal_eEngr(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>PageID</th>
                <th>Mem MemberID</th>
                <th>PageTitle</th>
                <th>Logo</th>
                <th>Banner</th>
                <th>Details</th>
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
                
                            <td>"+decimal.Parse(dr["PageID"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+decimal.Parse(dr["Mem_MemberID"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+dr["PageTitle"].ToString()+@"</td>
                
                            <td>"+dr["Logo"].ToString()+@"</td>
                
                            <td>"+dr["Banner"].ToString()+@"</td>
                
                            <td>"+dr["Details"].ToString()+@"</td>
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
        
        ddlPageID.SelectedValue="0";
        ddlMem_MemberID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_E_Page_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_E_Page_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_E_Page_Action()
    {
        string sql=@"INSERT INTO [E_Page]
                (
                PageID,
                Mem_MemberID,
                PageTitle,
                Logo,
                Banner,
                Details)
                Values(
                "+CommonManager.SQLInjectionChecking(txtPageID.Text.Replace(",",""))+@",
                "+CommonManager.SQLInjectionChecking(txtMem_MemberID.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtPageTitle.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtLogo.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtBanner.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_Protal_eEngr(sql);
        Response.Redirect("Admin_E_Page.aspx?saved=1");
            
    }

    protected void Edit_E_Page_Action()
    {
        string sql=@"Update [E_Page]
                Set
                PageID="+CommonManager.SQLInjectionChecking(txtPageID.Text.Replace(",",""))+@",
                Mem_MemberID="+CommonManager.SQLInjectionChecking(txtMem_MemberID.Text.Replace(",",""))+@",
                PageTitle='"+CommonManager.SQLInjectionChecking(txtPageTitle.Text)+@"',
                Logo='"+CommonManager.SQLInjectionChecking(txtLogo.Text)+@"',
                Banner='"+CommonManager.SQLInjectionChecking(txtBanner.Text)+@"',
                Details='"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"' 
        where E_Page_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_Protal_eEngr(sql);
        Response.Redirect("Admin_E_Page.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtPageTitle.Text="";
        txtLogo.Text="";
        txtBanner.Text="";
        txtDetails.Text="";
        ddlPageID.SelectedValue="0";
        ddlMem_MemberID.SelectedValue="0";
    }

}
