using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSignIn_OnClick(object sender, EventArgs e)
    {
        if(isloginSuccess())
        Response.Redirect("nrb");
    }

    private bool isloginSuccess()
    {
        bool isSuccess = false;

        DataSet ds = CommonManager.SQLExec(@"SELECT   [Id]
      ,[FirstName]
      ,[LastName]
      ,[Name]
      ,[Designation]
      ,[Phone]
      ,[Email]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zip]
      ,[HasReviewAuthorization]
      ,[IsInManagement]
      ,[IsInDirectorPanel]
      ,[Password]
      ,[RoleID]
  FROM  [Employee]
  where [Email]='"+txtEmail.Text.Trim()+ @"' or [Password]='" + txtPassword.Text.Trim() + @"'");

        if (ds.Tables[0].Rows.Count!=0)
        {
            isSuccess = true;
            Session["EmployeeID"] = ds.Tables[0].Rows[0];
        }
        else
        {
            Session["EmployeeID"] = null;
            lblMsg.Text = "<br/>Wrong Information.";
        }

        return isSuccess;
    }
}
