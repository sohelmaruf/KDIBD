using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Contact : System.Web.UI.Page
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
                Delete_Contact();
                Response.Redirect("Admin_Contact.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Contact();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Contact()
    {
        try
        {
            string sql=@"Select * from [Contact] where Contact_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_WingsGlobal(sql).Tables[0].Rows[0];
            
            txtName.Text = dr["Name"].ToString();
            txtContact_No.Text = dr["Contact_No"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtCompany.Text = dr["Company"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtNote.Text = dr["Note"].ToString();
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Contact()
    {
        try
        {
            string sql=@"Delete [Contact] where Contact_ID = "+Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec_WingsGlobal(sql);
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
                ds = CommonManager.SQLExec_WingsGlobal(sql);
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
                [Contact].Contact_ID
                ,[Contact].Name
                ,[Contact].Contact_No
                ,[Contact].Email
                ,[Contact].Company
                ,[Contact].Address
                ,[Contact].Note
         from [Contact]
        order by [Contact].Contact_Name";
        DataSet ds = CommonManager.SQLExec_WingsGlobal(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Name</th>
                <th>Contact No</th>
                <th>Email</th>
                <th>Company</th>
                <th>Address</th>
                <th>Note</th>
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
                                                <li><a href='Admin_Contact.aspx?edit="+dr["Contact_ID"].ToString()+@"'>Edit</a></li>
                                                <li><a href='Admin_Contact.aspx?delete="+dr["Contact_ID"].ToString()+@"'  onclick="+"\"return confirm('Are you sure you want to edit?')\""+@">Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>
                
                            <td>"+dr["Name"].ToString()+@"</td>
                
                            <td>"+dr["Contact_No"].ToString()+@"</td>
                
                            <td>"+dr["Email"].ToString()+@"</td>
                
                            <td>"+dr["Company"].ToString()+@"</td>
                
                            <td>"+dr["Address"].ToString()+@"</td>
                
                            <td>"+dr["Note"].ToString()+@"</td>
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
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Contact_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Contact_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Contact_Action()
    {
        string sql=@"INSERT INTO [Contact]
                (
                Name,
                Contact_No,
                Email,
                Company,
                Address,
                Note)
                Values(
                '"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtContact_No.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCompany.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtNote.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_WingsGlobal(sql);
        Response.Redirect("Admin_Contact.aspx?saved=1");
            
    }

    protected void Edit_Contact_Action()
    {
        string sql=@"Update [Contact]
                Set
                Name='"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                Contact_No='"+CommonManager.SQLInjectionChecking(txtContact_No.Text)+@"',
                Email='"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                Company='"+CommonManager.SQLInjectionChecking(txtCompany.Text)+@"',
                Address='"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                Note='"+CommonManager.SQLInjectionChecking(txtNote.Text)+@"' 
        where Contact_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_WingsGlobal(sql);
        Response.Redirect("Admin_Contact.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtName.Text="";
        txtContact_No.Text="";
        txtEmail.Text="";
        txtCompany.Text="";
        txtAddress.Text="";
        txtNote.Text="";
    }

}
