using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class je_Admin_DropDownList : System.Web.UI.Page
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
                divSuccessfull.Visible = true;
                lblMSG.Text = "Saved Successfully..";
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["delete"]) != null)
            {
                Delete_Admin_DropDownList_Control();
                Response.Redirect("Admin_Admin_DropDownList_Control.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible = true;
                lblMSG.Text = "Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Admin_DropDownList_Control();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible = true;
                lblMSG.Text = "Edited Successfully..";
            }
        }
    }
    private void Edit_Admin_DropDownList_Control()
    {
        try
        {
            string sql = @"Select * from [Admin_DropDownList_Control] where Admin_DropDownList_Control_ID = " + Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];

            txtAdmin_DropDownList_Control_Name.Text = dr["Admin_DropDownList_Control_Name"].ToString();
        }
        catch (Exception ex)
        {
            divSuccessfull.Visible = true;
            lblMSG.Text = ex.Message;
        }
    }
    private void Delete_Admin_DropDownList_Control()
    {
        try
        {
            string sql = @"Delete [Admin_DropDownList_Control] where Admin_DropDownList_Control_ID = " + Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec(sql);
        }
        catch (Exception ex)
        {
            divSuccessfull.Visible = true;
            lblMSG.Text = ex.Message;
        }
    }
    private void loadLoginInHiddenField()
    {
        
    }

    private void LoadDropdownlist()
    {
        try
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = @"";
                if (sql != "")
                    ds = CommonManager.SQLExec(sql);
            }
            catch (Exception ex)
            {
                divSuccessfull.Visible = true;
                lblMSG.Text = ex.Message;
            }



        }
        catch (Exception ex)
        {
            divSuccessfull.Visible = true;
            lblMSG.Text = ex.Message;
        }
    }

    private void loadAllData()
    {
        try
        {
            string sql = @"Select 
                [Admin_DropDownList_Control].Admin_DropDownList_Control_ID
                ,[Admin_DropDownList_Control].Admin_DropDownList_Control_Name
         from [Admin_DropDownList_Control]
        order by [Admin_DropDownList_Control].Admin_DropDownList_Control_Name";
            DataSet ds = CommonManager.SQLExec(sql);
            string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Edit
                                    </th>
                <th>Field Name</th>
                                </tr>
                            </thead>
                            <tbody>"; int count = 0;
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

                html += @"
                
                            <td>
                                        <div class='btn-group'>
<a href='Admin_Admin_DropDownList_Control.aspx?edit=" + dr["Admin_DropDownList_Control_ID"].ToString() + @"'>Edit</a>

                                            <button style='display:none;' data-toggle='dropdown' class='btn btn-primary dropdown-toggle'>
                                                Action <span class='caret'></span>
                                            </button>
                                            <ul class='dropdown-menu' style='display:none;'>
                                                <li></li>
                                                <li style='display:none;'><a href='Admin_Admin_DropDownList_Control.aspx?delete=" + dr["Admin_DropDownList_Control_ID"].ToString() + @"'  onclick=" + "\"return confirm('Are you sure you want to edit?')\"" + @">Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>
                
                            <td>" + dr["Admin_DropDownList_Control_Name"].ToString() + @"</td>
                    </tr>";
            }

            html += @"

                                    </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>";
            lblList.Text = html;

        }
        catch (Exception ex)
        {
            divSuccessfull.Visible = true;
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
                Add_Admin_DropDownList_Control_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Admin_DropDownList_Control_Action();
            }
        }
        catch (Exception ex)
        {
            divSuccessfull.Visible = true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Admin_DropDownList_Control_Action()
    {
        string sql = @"INSERT INTO [Admin_DropDownList_Control]
                (
                Admin_DropDownList_Control_Name)
                Values(
                '" + CommonManager.SQLInjectionChecking(txtAdmin_DropDownList_Control_Name.Text) + @"');";
        DataSet ds = CommonManager.SQLExec(sql);
        Response.Redirect("Admin_Admin_DropDownList_Control.aspx?saved=1");

    }

    protected void Edit_Admin_DropDownList_Control_Action()
    {
        string sql = @"Update [Admin_DropDownList_Control]
                Set
                Admin_DropDownList_Control_Name='" + CommonManager.SQLInjectionChecking(txtAdmin_DropDownList_Control_Name.Text) + @"' 
        where Admin_DropDownList_Control_ID=" + Request.QueryString["edit"];
        DataSet ds = CommonManager.SQLExec(sql);
        Response.Redirect("Admin_Admin_DropDownList_Control.aspx?edited=1");

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible = true;
        lblMSG.Text = "Reset Successfully..";

        txtAdmin_DropDownList_Control_Name.Text = "";
    }

}