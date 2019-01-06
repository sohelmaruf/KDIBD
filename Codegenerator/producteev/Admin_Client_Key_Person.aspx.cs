using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Client_Key_Person : System.Web.UI.Page
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
                Delete_Client_Key_Person();
                Response.Redirect("Admin_Client_Key_Person.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Client_Key_Person();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Client_Key_Person()
    {
        try
        {
            string sql=@"Select * from [Client_Key_Person] where Client_Key_Person_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];
            
            txtKey_Person.Text = dr["Key_Person"].ToString();
            txtTitle.Text = dr["Title"].ToString();
            txtContact_No.Text = dr["Contact_No"].ToString();
            ddlCustomer_ID.SelectedValue = dr["Customer_ID"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Client_Key_Person()
    {
        try
        {
            string sql=@"Delete [Client_Key_Person] where Client_Key_Person_ID = "+Request.QueryString["delete"];
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
                    select Customer_ID, Customer_Name from [Customer]
                    order by Customer_Name";
                if(sql!="")
                ds = CommonManager.SQLExec_producteev(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
            }



            ddlCustomer_ID.Items.Clear();
            ddlCustomer_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCustomer_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
                [Client_Key_Person].Client_Key_Person_ID
                ,[Customer].Customer_Name
                ,[Client_Key_Person].Key_Person
                ,[Client_Key_Person].Title
                ,[Client_Key_Person].Contact_No
         from [Client_Key_Person]
            inner join [Customer] on [Customer].Customer_ID = [Client_Key_Person].Customer_ID
        order by [Client_Key_Person].Client_Key_Person_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Customer</th>
                <th>Key Person</th>
                <th>Title</th>
                <th>Contact No</th>
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
                
                            <td>
                                        <div class='btn-group'>
                                            <button data-toggle='dropdown' class='btn btn-primary dropdown-toggle'>
                                                Action <span class='caret'></span>
                                            </button>
                                            <ul class='dropdown-menu'>
                                                <li><a href='Admin_Client_Key_Person.aspx?edit="+dr["Client_Key_Person_ID"].ToString()+@"'>Edit</a></li>
                                                <li><a href='Admin_Client_Key_Person.aspx?delete="+dr["Client_Key_Person_ID"].ToString()+@"'  onclick="+"\"return confirm('Are you sure you want to edit?')\""+@">Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>
                
                            <td>"+dr["Customer_Name"].ToString()+@"</td>
                
                            <td>"+dr["Key_Person"].ToString()+@"</td>
                
                            <td>"+dr["Title"].ToString()+@"</td>
                
                            <td>"+dr["Contact_No"].ToString()+@"</td>
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
        
        ddlCustomer_ID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Client_Key_Person_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Client_Key_Person_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Client_Key_Person_Action()
    {
        string sql=@"INSERT INTO [Client_Key_Person]
                (
                Customer_ID,
                Key_Person,
                Title,
                Contact_No)
                Values(
                "+CommonManager.SQLInjectionChecking(ddlCustomer_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtKey_Person.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtTitle.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtContact_No.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Client_Key_Person.aspx?saved=1");
            
    }

    protected void Edit_Client_Key_Person_Action()
    {
        string sql=@"Update [Client_Key_Person]
                Set
                Customer_ID="+CommonManager.SQLInjectionChecking(ddlCustomer_ID.SelectedValue)+@",
                Key_Person='"+CommonManager.SQLInjectionChecking(txtKey_Person.Text)+@"',
                Title='"+CommonManager.SQLInjectionChecking(txtTitle.Text)+@"',
                Contact_No='"+CommonManager.SQLInjectionChecking(txtContact_No.Text)+@"' 
        where Client_Key_Person_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Client_Key_Person.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtKey_Person.Text="";
        txtTitle.Text="";
        txtContact_No.Text="";
        ddlCustomer_ID.SelectedValue="0";
    }

}
