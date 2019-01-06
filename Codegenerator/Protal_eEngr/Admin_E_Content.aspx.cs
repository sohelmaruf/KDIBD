using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_E_Content : System.Web.UI.Page
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
                Delete_E_Content();
                Response.Redirect("Admin_E_Content.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_E_Content();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_E_Content()
    {
        try
        {
            string sql=@"Select * from [E_Content] where E_Content_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_Protal_eEngr(sql).Tables[0].Rows[0];
            
            txtDetails.Text = dr["Details"].ToString();
            txtContentTitle.Text = Decimal.Parse(dr["ContentTitle"].ToString()).ToString("0,0");
            ddlContentID.SelectedValue = dr["ContentID"].ToString();
            ddlPageID.SelectedValue = dr["PageID"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_E_Content()
    {
        try
        {
            string sql=@"Delete [E_Content] where E_Content_ID = "+Request.QueryString["delete"];
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
                [E_Content].ContentID
                ,[E_Content].PageID
                ,[E_Content].ContentTitle
                ,[E_Content].Details
         from [E_Content]
        order by [E_Content].E_Content_Name";
        DataSet ds = CommonManager.SQLExec_Protal_eEngr(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>ContentID</th>
                <th>PageID</th>
                <th>ContentTitle</th>
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
                
                            <td>"+decimal.Parse(dr["ContentID"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+decimal.Parse(dr["PageID"].ToString()).ToString("0,0")+@"</td>
                
                            <td>"+decimal.Parse(dr["ContentTitle"].ToString()).ToString("0,0")+@"</td>
                
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
        
        txtContentTitle.Text="0";
        ddlContentID.SelectedValue="0";
        ddlPageID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_E_Content_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_E_Content_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_E_Content_Action()
    {
        string sql=@"INSERT INTO [E_Content]
                (
                ContentID,
                PageID,
                ContentTitle,
                Details)
                Values(
                "+CommonManager.SQLInjectionChecking(txtContentID.Text.Replace(",",""))+@",
                "+CommonManager.SQLInjectionChecking(txtPageID.Text.Replace(",",""))+@",
                "+CommonManager.SQLInjectionChecking(txtContentTitle.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_Protal_eEngr(sql);
        Response.Redirect("Admin_E_Content.aspx?saved=1");
            
    }

    protected void Edit_E_Content_Action()
    {
        string sql=@"Update [E_Content]
                Set
                ContentID="+CommonManager.SQLInjectionChecking(txtContentID.Text.Replace(",",""))+@",
                PageID="+CommonManager.SQLInjectionChecking(txtPageID.Text.Replace(",",""))+@",
                ContentTitle="+CommonManager.SQLInjectionChecking(txtContentTitle.Text.Replace(",",""))+@",
                Details='"+CommonManager.SQLInjectionChecking(txtDetails.Text)+@"' 
        where E_Content_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_Protal_eEngr(sql);
        Response.Redirect("Admin_E_Content.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtDetails.Text="";
        txtContentTitle.Text="";
        ddlContentID.SelectedValue="0";
        ddlPageID.SelectedValue="0";
    }

}
