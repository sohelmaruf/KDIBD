using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Employee : System.Web.UI.Page
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
                Delete_Employee();
                Response.Redirect("Admin_Employee.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Employee();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Employee()
    {
        try
        {
            string sql=@"Select * from [Employee] where Employee_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_producteev(sql).Tables[0].Rows[0];
            
            txtFirstName.Text = dr["FirstName"].ToString();
            txtLastName.Text = dr["LastName"].ToString();
            txtName.Text = dr["Name"].ToString();
            txtDesignation.Text = dr["Designation"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtZip.Text = dr["Zip"].ToString();
            txtId.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0,0");
            chkHasReviewAuthorization.Checked = bool.Parse(dr["HasReviewAuthorization"].ToString());
            chkIsInManagement.Checked = bool.Parse(dr["IsInManagement"].ToString());
            chkIsInDirectorPanel.Checked = bool.Parse(dr["IsInDirectorPanel"].ToString());
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Employee()
    {
        try
        {
            string sql=@"Delete [Employee] where Employee_ID = "+Request.QueryString["delete"];
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
                [Employee].Id
                ,[Employee].FirstName
                ,[Employee].LastName
                ,[Employee].Name
                ,[Employee].Designation
                ,[Employee].Phone
                ,[Employee].Email
                ,[Employee].Address
                ,[Employee].City
                ,[Employee].State
                ,[Employee].Zip
                ,[Employee].HasReviewAuthorization
                ,[Employee].IsInManagement
                ,[Employee].IsInDirectorPanel
         from [Employee]
        order by [Employee].Employee_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Id</th>
                <th>FirstName</th>
                <th>LastName</th>
                <th>Name</th>
                <th>Designation</th>
                <th>Phone</th>
                <th>Email</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>HasReviewAuthorization</th>
                <th>IsInManagement</th>
                <th>IsInDirectorPanel</th>
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
                
                            <td>"+dr["FirstName"].ToString()+@"</td>
                
                            <td>"+dr["LastName"].ToString()+@"</td>
                
                            <td>"+dr["Name"].ToString()+@"</td>
                
                            <td>"+dr["Designation"].ToString()+@"</td>
                
                            <td>"+dr["Phone"].ToString()+@"</td>
                
                            <td>"+dr["Email"].ToString()+@"</td>
                
                            <td>"+dr["Address"].ToString()+@"</td>
                
                            <td>"+dr["City"].ToString()+@"</td>
                
                            <td>"+dr["State"].ToString()+@"</td>
                
                            <td>"+dr["Zip"].ToString()+@"</td>
                
                            <td>"+dr["HasReviewAuthorization"].ToString()+@"</td>
                
                            <td>"+dr["IsInManagement"].ToString()+@"</td>
                
                            <td>"+dr["IsInDirectorPanel"].ToString()+@"</td>
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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Employee_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Employee_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Employee_Action()
    {
        string sql=@"INSERT INTO [Employee]
                (
                Id,
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
                IsInDirectorPanel)
                Values(
                "+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtFirstName.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtLastName.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtDesignation.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPhone.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                "+(chkHasReviewAuthorization.Checked?1:0)+@",
                "+(chkIsInManagement.Checked?1:0)+@",
                "+(chkIsInDirectorPanel.Checked?1:0)+@");";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Employee.aspx?saved=1");
            
    }

    protected void Edit_Employee_Action()
    {
        string sql=@"Update [Employee]
                Set
                Id="+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                FirstName='"+CommonManager.SQLInjectionChecking(txtFirstName.Text)+@"',
                LastName='"+CommonManager.SQLInjectionChecking(txtLastName.Text)+@"',
                Name='"+CommonManager.SQLInjectionChecking(txtName.Text)+@"',
                Designation='"+CommonManager.SQLInjectionChecking(txtDesignation.Text)+@"',
                Phone='"+CommonManager.SQLInjectionChecking(txtPhone.Text)+@"',
                Email='"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                Address='"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                City='"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                State='"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                Zip='"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                HasReviewAuthorization="+(chkHasReviewAuthorization.Checked?1:0)+@",
                IsInManagement="+(chkIsInManagement.Checked?1:0)+@",
                IsInDirectorPanel="+(chkIsInDirectorPanel.Checked?1:0)+@" 
        where Employee_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Employee.aspx?edited=1");
            
    }

    private void EmployeeReset()
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtFirstName.Text="";
        txtLastName.Text="";
        txtName.Text="";
        txtDesignation.Text="";
        txtPhone.Text="";
        txtEmail.Text="";
        txtAddress.Text="";
        txtCity.Text="";
        txtState.Text="";
        txtZip.Text="";
        txtId.Text="";
        chkHasReviewAuthorization.Checked=false;
        chkIsInManagement.Checked=false;
        chkIsInDirectorPanel.Checked=false;
    }

}
