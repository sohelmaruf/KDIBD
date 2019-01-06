using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataMigration_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = @"
                 Select distinct [projectAddressCity]
                    FROM [producteev].[dbo].[jen_Projects]";
            DataSet ds = CommonManager.SQLExec(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string zipCode = "";
                foreach (string zip in dr["projectAddressCity"].ToString().Split(' '))
                {
                    try
                    {
                        zipCode = int.Parse(zip.Trim()).ToString();
                        break;
                    }
                    catch (Exception exception)
                    {
                        
                    }
                }
                if(zipCode.Trim()!="")
                CommonManager.SQLExec("update [producteev].[dbo].[jen_Projects] set projectAddressCity='"+dr["projectAddressCity"].ToString().Replace(zipCode.Trim(),"").Trim() + "',projectAddressZip='"+zipCode.Trim()+"' where projectAddressCity='" + dr["projectAddressCity"].ToString() + "'");
            }

            #region MyRegion


            /*
             update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Allen'
	where [projectAddressCity] in (
	'Allan'
	)

        update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Argyle / Northlake'
	where [projectAddressCity] in (
	'Argyle / Northlake'
,'Argyle/ Northlake'
,'Argyle/Northlake'
	)

        update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Dallas'
	where [projectAddressCity] in (
	'DAllas'
	)


        	update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Fort Worth'
	where [projectAddressCity] in (
	'Ft  Worth'
,'Ft Worth'
	)

        update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Lewisville'
	where [projectAddressCity] in (
'Ledwisville'
,'Leweisville'
,'Lewisville'
	)

        update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Lucas'
	where [projectAddressCity] in (
'Lucas City'
,'Lucas Texas'
,'Lucas'
	)

        
	update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='New Braunfels'
	where [projectAddressCity] in (
'New Braunfels'
,'New Braunsfels TZ'
,'New Braunsfels'
	)

        update  [producteev].[dbo].[jen_Projects] set [projectAddressCity]='Mansfield'
	where [projectAddressCity] in (
'Mansfield'
,'Mansfieldz'
	)
             */

            #endregion
        }
    }
}