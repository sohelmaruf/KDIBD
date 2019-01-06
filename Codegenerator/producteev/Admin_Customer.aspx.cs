using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Customer : System.Web.UI.Page
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
                Delete_Customer();
                Response.Redirect("Admin_Customer.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Customer();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Customer()
    {
        try
        {
            string sql=@"Select * from [Customer] where Customer_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec_producteev(sql).Tables[0].Rows[0];
            
            txtTitle.Text = dr["Title"].ToString();
            txtKeyPerson.Text = dr["KeyPerson"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtZip.Text = dr["Zip"].ToString();
            txtPhone.Text = dr["Phone"].ToString();
            txtAltPhone.Text = dr["AltPhone"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtNotes.Text = dr["Notes"].ToString();
            txtId.Text = Decimal.Parse(dr["Id"].ToString()).ToString("0,0");
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Customer()
    {
        try
        {
            string sql=@"Delete [Customer] where Customer_ID = "+Request.QueryString["delete"];
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
                [Customer].Id
                ,[Customer].Title
                ,[Customer].KeyPerson
                ,[Customer].Address
                ,[Customer].City
                ,[Customer].State
                ,[Customer].Zip
                ,[Customer].Phone
                ,[Customer].AltPhone
                ,[Customer].Email
                ,[Customer].Notes
         from [Customer]
        order by [Customer].Customer_Name";
        DataSet ds = CommonManager.SQLExec_producteev(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Id</th>
                <th>Title</th>
                <th>KeyPerson</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone</th>
                <th>AltPhone</th>
                <th>Email</th>
                <th>Notes</th>
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
                
                            <td>"+dr["Title"].ToString()+@"</td>
                
                            <td>"+dr["KeyPerson"].ToString()+@"</td>
                
                            <td>"+dr["Address"].ToString()+@"</td>
                
                            <td>"+dr["City"].ToString()+@"</td>
                
                            <td>"+dr["State"].ToString()+@"</td>
                
                            <td>"+dr["Zip"].ToString()+@"</td>
                
                            <td>"+dr["Phone"].ToString()+@"</td>
                
                            <td>"+dr["AltPhone"].ToString()+@"</td>
                
                            <td>"+dr["Email"].ToString()+@"</td>
                
                            <td>"+dr["Notes"].ToString()+@"</td>
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
                Add_Customer_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Customer_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Customer_Action()
    {
        string sql=@"INSERT INTO [Customer]
                (
                Id,
                Title,
                KeyPerson,
                Address,
                City,
                State,
                Zip,
                Phone,
                AltPhone,
                Email,
                Notes)
                Values(
                "+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                '"+CommonManager.SQLInjectionChecking(txtTitle.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtKeyPerson.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtPhone.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtAltPhone.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                '"+CommonManager.SQLInjectionChecking(txtNotes.Text)+@"');";
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Customer.aspx?saved=1");
            
    }

    protected void Edit_Customer_Action()
    {
        string sql=@"Update [Customer]
                Set
                Id="+CommonManager.SQLInjectionChecking(txtId.Text.Replace(",",""))+@",
                Title='"+CommonManager.SQLInjectionChecking(txtTitle.Text)+@"',
                KeyPerson='"+CommonManager.SQLInjectionChecking(txtKeyPerson.Text)+@"',
                Address='"+CommonManager.SQLInjectionChecking(txtAddress.Text)+@"',
                City='"+CommonManager.SQLInjectionChecking(txtCity.Text)+@"',
                State='"+CommonManager.SQLInjectionChecking(txtState.Text)+@"',
                Zip='"+CommonManager.SQLInjectionChecking(txtZip.Text)+@"',
                Phone='"+CommonManager.SQLInjectionChecking(txtPhone.Text)+@"',
                AltPhone='"+CommonManager.SQLInjectionChecking(txtAltPhone.Text)+@"',
                Email='"+CommonManager.SQLInjectionChecking(txtEmail.Text)+@"',
                Notes='"+CommonManager.SQLInjectionChecking(txtNotes.Text)+@"' 
        where Customer_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec_producteev(sql);
        Response.Redirect("Admin_Customer.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtTitle.Text="";
        txtKeyPerson.Text="";
        txtAddress.Text="";
        txtCity.Text="";
        txtState.Text="";
        txtZip.Text="";
        txtPhone.Text="";
        txtAltPhone.Text="";
        txtEmail.Text="";
        txtNotes.Text="";
        txtId.Text="";
    }

}
