using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin_DropDownList_Control_Value : System.Web.UI.Page
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
                Delete_Admin_DropDownList_Control_Value();
                Response.Redirect("Admin_Admin_DropDownList_Control_Value.aspx?deleted=1");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["deleted"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Deleted Successfully..";
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString["edit"]) != null)
            {
                Edit_Admin_DropDownList_Control_Value();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString["edited"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text="Edited Successfully..";
            }
        }
    }
    private void Edit_Admin_DropDownList_Control_Value()
    {
        try
        {
            string sql=@"Select * from [Admin_DropDownList_Control_Value] where Admin_DropDownList_Control_Value_ID = "+Request.QueryString["edit"];
            DataRow dr = CommonManager.SQLExec(sql).Tables[0].Rows[0];
            
            txtAdmin_DropDownList_Control_Value_Name.Text = dr["Admin_DropDownList_Control_Value_Name"].ToString();
            ddlAdmin_DropDownList_Control_ID.SelectedValue = dr["Admin_DropDownList_Control_ID"].ToString();
            chkIsActive.Checked = bool.Parse(dr["IsActive"].ToString());
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } 
    private void Delete_Admin_DropDownList_Control_Value()
    {
        try
        {
            string sql= @"Update [Admin_DropDownList_Control_Value] set IsActive=0 where Admin_DropDownList_Control_Value_ID = " + Request.QueryString["delete"];
            DataSet ds = CommonManager.SQLExec(sql);
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
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
                string sql=@"
                    select Admin_DropDownList_Control_ID, Admin_DropDownList_Control_Name from [Admin_DropDownList_Control]
                    order by Admin_DropDownList_Control_Name";
                if(sql!="")
                ds = CommonManager.SQLExec(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
            }



            ddlAdmin_DropDownList_Control_ID.Items.Clear();
            ddlAdmin_DropDownList_Control_ID.Items.Add(new ListItem("Select........", "0"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlAdmin_DropDownList_Control_ID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
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
                [Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_ID
                ,[Admin_DropDownList_Control].Admin_DropDownList_Control_Name
                ,[Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_Name
                ,[Admin_DropDownList_Control_Value].IsActive
         from [Admin_DropDownList_Control_Value]
            inner join [Admin_DropDownList_Control] on [Admin_DropDownList_Control].Admin_DropDownList_Control_ID = [Admin_DropDownList_Control_Value].Admin_DropDownList_Control_ID
        order by [Admin_DropDownList_Control].Admin_DropDownList_Control_Name,
[Admin_DropDownList_Control_Value].Admin_DropDownList_Control_Value_Name";
        DataSet ds = CommonManager.SQLExec(sql);
        string html = @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>
                <th>Drop down list</th>
                <th>Data</th>
                <th>Active?</th>
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
                                                <li><a href='Admin_Admin_DropDownList_Control_Value.aspx?edit="+dr["Admin_DropDownList_Control_Value_ID"].ToString()+@"'>Edit</a></li>
                                                <li><a href='Admin_Admin_DropDownList_Control_Value.aspx?delete="+dr["Admin_DropDownList_Control_Value_ID"].ToString()+@"'  onclick="+"\"return confirm('Are you sure you want to edit?')\""+@">Keep InActive</a></li>
                                            </ul>
                                        </div>
                                    </td>
                
                            <td>"+dr["Admin_DropDownList_Control_Name"].ToString()+@"</td>
                
                            <td>"+dr["Admin_DropDownList_Control_Value_Name"].ToString()+@"</td>
                
                            <td>"+dr["IsActive"].ToString()+@"</td>
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
        
        ddlAdmin_DropDownList_Control_ID.SelectedValue="0";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["edit"] == null)
            {
                Add_Admin_DropDownList_Control_Value_Action();
            }
            else
            if (Request.QueryString["edit"] != null)
            {
                Edit_Admin_DropDownList_Control_Value_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }

    protected void Add_Admin_DropDownList_Control_Value_Action()
    {
        string sql=@"INSERT INTO [Admin_DropDownList_Control_Value]
                (
                Admin_DropDownList_Control_ID,
                Admin_DropDownList_Control_Value_Name,
                IsActive)
                Values(
                "+CommonManager.SQLInjectionChecking(ddlAdmin_DropDownList_Control_ID.SelectedValue)+@",
                '"+CommonManager.SQLInjectionChecking(txtAdmin_DropDownList_Control_Value_Name.Text)+@"',
                "+(chkIsActive.Checked?1:0)+@");";
        DataSet ds=  CommonManager.SQLExec(sql);
        Response.Redirect("Admin_Admin_DropDownList_Control_Value.aspx?saved=1");
            
    }

    protected void Edit_Admin_DropDownList_Control_Value_Action()
    {
        string sql=@"Update [Admin_DropDownList_Control_Value]
                Set
                Admin_DropDownList_Control_ID="+CommonManager.SQLInjectionChecking(ddlAdmin_DropDownList_Control_ID.SelectedValue)+@",
                Admin_DropDownList_Control_Value_Name='"+CommonManager.SQLInjectionChecking(txtAdmin_DropDownList_Control_Value_Name.Text)+@"',
                IsActive="+(chkIsActive.Checked?1:0)+@" 
        where Admin_DropDownList_Control_Value_ID="+Request.QueryString["edit"];
        DataSet ds=  CommonManager.SQLExec(sql);
        Response.Redirect("Admin_Admin_DropDownList_Control_Value.aspx?edited=1");
            
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text="Reset Successfully..";
        
        txtAdmin_DropDownList_Control_Value_Name.Text="";
        ddlAdmin_DropDownList_Control_ID.SelectedValue="0";
        chkIsActive.Checked=false;
    }

}
