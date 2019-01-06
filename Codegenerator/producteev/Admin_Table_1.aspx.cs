using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Table_1 : System.Web.UI.Page
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
                Delete_Table_1();
                Response.Redirect("Admin_Table_1.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Table_1();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Table_1()
    {
        try
        {
            string sql=@"Select * from [Table_1] where Table_1_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_producteev(sql).Tables[0].Rows[0];
            
            txtstate.Text = DateTime.Parse(dr["state"].ToString()).ToString("dd/MM/yyyy");
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Table_1()
    {
        try
        {
            string sql=@"Delete [Table_1] where Table_1_ID = "+Request.QueryString["delete"];
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
                [Table_1].state
         from [Table_1]
        order by [Table_1].Table_1_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>state</th>
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
                
                            <td>"+DateTime.Parse(dr["state"].ToString()).ToString("dd MMM yyyy")+@"</td>
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
        
        txtstate.Text=DateTime.Today.ToString("dd/MM/yyyy");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Table_1_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Table_1_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Table_1_Action()
    {
        string sql=@"INSERT INTO [Table_1]
                (
                state)
                Values(
                '"+CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txtstate.Text)).ToString("yyyy-MM-dd hh:mm tt"))+@"');";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Table_1.aspx?saved=1");
            
    }

    protected void Edit_Table_1_Action()
    {
        string sql=@"Update [Table_1]
                Set
                state='"+DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txtstate.Text))).ToString("yyyy-MM-dd hh:mm tt")+@"' 
        where Table_1_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Table_1.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtstate.Text=DateTime.Today.ToString("dd/MM/yyyy");
    }

}
