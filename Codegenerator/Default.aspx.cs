using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GenerateCode_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDb();
        }
    }

    private void loadDb()
    {
        string sql = @"
SELECT [name]
FROM master.dbo.sysdatabases
WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');
";
        DataSet ds = CommonManager.SQLExec(sql);
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add(new ListItem("Select", "0"));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DropDownList1.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = @"
            SELECT name
            FROM " + DropDownList1.SelectedValue + @".sys.Tables
            order by name
            ";
        DataSet ds = CommonManager.SQLExec(sql);
        DropDownList2.Items.Clear();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DropDownList2.Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string sql = @"
            
SELECT *
FROM " + DropDownList1.SelectedValue + @".INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'" + DropDownList2.SelectedValue + @"'
and DATA_TYPE not in ('bit')
and COLUMN_NAME not in ('Added_By','Added_Date','Updated_By','Updated_Date','Rowstatus_ID')
and COLUMN_NAME not in ('" + DropDownList2.SelectedValue + @"_ID')
and COLUMN_NAME not like '%_ID'
order by DATA_TYPE desc, ORDINAL_POSITION 



SELECT *
FROM " + DropDownList1.SelectedValue + @".INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'" + DropDownList2.SelectedValue + @"'
and (DATA_TYPE  in ('bit') or COLUMN_NAME like '%_ID')
and COLUMN_NAME not in ('Added_By','Added_Date','Updated_By','Updated_Date','Rowstatus_ID')
and COLUMN_NAME not in ('" + DropDownList2.SelectedValue + @"_ID')
order by DATA_TYPE desc, ORDINAL_POSITION 


SELECT *
FROM " + DropDownList1.SelectedValue + @".INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'" + DropDownList2.SelectedValue + @"'
order by ORDINAL_POSITION 
            ";
        DataSet ds = CommonManager.SQLExec(sql);
        GenereateUI(ds);
        GenereateUI_cs(ds);
    }



    #region GenereateUI_cs
    private void GenereateUI_cs(DataSet ds)
    {


        string fileText = "";
        fileText += generate_usingSection(ds);
        fileText += generate_Page_Load_method(ds);
        fileText += generate_btnSave_Click_event(ds);
        fileText += generate_btnReset_Click_event(ds);

        fileText += @"
}
";
        string dirUrl = DropDownList1.SelectedItem.Text;
        string dirPath = Server.MapPath(dirUrl);
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllText( dirPath+@"\Admin_" + DropDownList2.SelectedValue + ".aspx.cs", fileText);

    }
    
    private string generate_Add_Action(DataSet ds)
    {
        string html = @"
    protected void Add_" + DropDownList2.SelectedValue + @"_Action()
    {
        ";

        string scema = "string sql=@\"INSERT INTO [" + DropDownList2.SelectedValue + @"]
                (";
        string value = @")
                Values(";
        bool is1stField = true;
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (dr["COLUMN_NAME"].ToString() != DropDownList2.SelectedValue + "_ID")
            {
                scema += (is1stField ? "" : ",");
                value += (is1stField ? "" : ",");
                is1stField = false;
            }
            switch (dr["DATA_TYPE"].ToString())
            {
                case "nvarchar":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    value += @"
                '" + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + @".Text)" + "+@\"'";
                    break;
                case "decimal":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    value += @"
                " + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + ".Text).Replace(\",\",\"\")" + "+@\"";
                    break;

                case "datetime":

                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    if (IslastCommonCol(dr["COLUMN_NAME"].ToString()))
                    {
                        value += @"
                '" + "\"+DateTime.Now.ToString(" + "\"yyyy-MM-dd hh:mm tt\")+@\"'";
                    }
                    else
                    {
                        value += @"
                '" + "\"+CommonManager.SQLInjectionChecking(DateTime.Parse(CommonManager.formatDate(txt" + dr["COLUMN_NAME"].ToString() + @".Text)" + ").ToString(" + "\"yyyy-MM-dd hh:mm tt\"))+@\"'";
                    }
                    break;

                case "int":
                    if (IslastCommonCol(dr["COLUMN_NAME"].ToString()))
                    {
                        scema += @"
                " + dr["COLUMN_NAME"].ToString();
                        if (dr["COLUMN_NAME"].ToString().Contains("_ID"))
                        {
                            value += @"
                1";
                        }
                        else
                        {
                            value += @"
                " + "\"+getLogin().LoginID+@\"";
                        }
                    }
                    else
                        if (dr["COLUMN_NAME"].ToString() != DropDownList2.SelectedValue + "_ID")
                        {
                            if (dr["COLUMN_NAME"].ToString().Contains("_ID"))
                            {
                                scema += @"
                " + dr["COLUMN_NAME"].ToString();
                                value += @"
                " + "\"+CommonManager.SQLInjectionChecking(ddl" + dr["COLUMN_NAME"].ToString() + @".SelectedValue)" + "+@\"";
                            }
                            else
                            {
                                scema += @"
                " + dr["COLUMN_NAME"].ToString();
                                value += @"
                " + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + ".Text.Replace(\",\",\"\"))" + "+@\"";
                            }
                        }

                    break;

                case "bit":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    value += @"
                " + "\"+(chk" + dr["COLUMN_NAME"].ToString() + @".Checked?1:0)" + "+@\"";
                    break;

                default:
                    break;
            }
        }

        html += scema + value + ");\";" + @"
        DataSet ds=  CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql);
        Response.Redirect(" + "\"Admin_" + DropDownList2.SelectedValue + ".aspx?saved=1\"" + @");
            
    }
";
        return html;
    }
    private string generate_Edit_Action(DataSet ds)
    {
        string html = @"
    protected void Edit_" + DropDownList2.SelectedValue + @"_Action()
    {
        ";

        string scema = "string sql=@\"Update [" + DropDownList2.SelectedValue + @"]
                Set";
        bool is1stField = true;
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (dr["COLUMN_NAME"].ToString() == "Added_Date"
                || dr["COLUMN_NAME"].ToString() == "Added_By")
                continue;
            if (dr["COLUMN_NAME"].ToString() != DropDownList2.SelectedValue + "_ID")
            {
                scema += (is1stField ? "" : ",");
                is1stField = false;
            }
            switch (dr["DATA_TYPE"].ToString())
            {
                case "nvarchar":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    scema += @"='" + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + @".Text)" + "+@\"'";
                    break;

                case "decimal":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    scema += @"=" + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + ".Text).Replace(\",\",\"\")" + "+@\"";
                    break;

                case "datetime":

                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    if (IslastCommonCol(dr["COLUMN_NAME"].ToString()))
                    {
                        if (dr["COLUMN_NAME"].ToString().Contains("Update"))
                        {
                            scema += @"='" + "\"+DateTime.Now.ToString(" + "\"yyyy-MM-dd hh:mm tt\")+@\"'";
                        }
                    }
                    else
                    {
                        scema += @"='" + "\"+DateTime.Parse(CommonManager.formatDate(CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + @".Text))" + ").ToString(" + "\"yyyy-MM-dd hh:mm tt\")+@\"'";
                    }
                    break;

                case "int":
                    if (IslastCommonCol(dr["COLUMN_NAME"].ToString()))
                    {
                        if (dr["COLUMN_NAME"].ToString().Contains("Update"))
                        {
                            scema += @"
                " + dr["COLUMN_NAME"].ToString();

                            scema += @"=" + "\"+getLogin().LoginID+@\"";
                        }
                    }
                    else
                        if (dr["COLUMN_NAME"].ToString() != DropDownList2.SelectedValue + "_ID")
                        {
                            if (dr["COLUMN_NAME"].ToString().Contains("_ID"))
                            {
                                scema += @"
                " + dr["COLUMN_NAME"].ToString();
                                scema += @"=" + "\"+CommonManager.SQLInjectionChecking(ddl" + dr["COLUMN_NAME"].ToString() + @".SelectedValue)" + "+@\"";
                            }
                            else
                            {
                                scema += @"
                " + dr["COLUMN_NAME"].ToString();
                                scema += @"=" + "\"+CommonManager.SQLInjectionChecking(txt" + dr["COLUMN_NAME"].ToString() + ".Text.Replace(\",\",\"\"))" + "+@\"";
                            }
                        }

                    break;

                case "bit":
                    scema += @"
                " + dr["COLUMN_NAME"].ToString();
                    scema += @"=" + "\"+(chk" + dr["COLUMN_NAME"].ToString() + @".Checked?1:0)" + "+@\"";
                    break;

                default:
                    break;
            }
        }

        html += scema+@" 
        where "+DropDownList2.SelectedValue +"_ID=\"+Request.QueryString[" + "\"edit\"" + @"];"+ @"
        DataSet ds=  CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql);
        Response.Redirect(" + "\"Admin_" + DropDownList2.SelectedValue + ".aspx?edited=1\"" + @");
            
    }
";
        return html;
    }
    private string generate_btnSave_Click_event(DataSet ds)
    {
        string html = @"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString[" + "\"edit\"" + @"] == null)
            {
                Add_" + DropDownList2.SelectedValue + @"_Action();
            }
            else
            if (Request.QueryString[" + "\"edit\"" + @"] != null)
            {
                Edit_" + DropDownList2.SelectedValue + @"_Action();
            }
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }
";
        html += generate_Add_Action(ds);
        html += generate_Edit_Action(ds);
        
        return html;
    }


    private string generate_btnReset_Click_event(DataSet ds)
    {
        string html = @"
    protected void btnReset_Click(object sender, EventArgs e)
    {
        divSuccessfull.Visible=true;
        lblMSG.Text=" + "\"Reset Successfully..\";" + @"
        ";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            
            switch (dr["DATA_TYPE"].ToString())
            {
                case "nvarchar":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=" + "\"\";";
                    break;
                case "decimal":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=" + "\"\";";
                    break;
                case "datetime":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=DateTime.Today.ToString(" + "\"dd/MM/yyyy\");";
                    break;
                case "int":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=" + "\"\";";
                    break;
                default:
                    break;
            }
        }

        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            switch (dr["DATA_TYPE"].ToString())
            {
                case "bit":
                    html += @"
        chk" + dr["COLUMN_NAME"].ToString() + @".Checked=false;";
                    break;

                case "int":
                    html += @"
        ddl" + dr["COLUMN_NAME"].ToString() + @".SelectedValue=" + "\"0\";";
                    break;
                default:
                    break;
            }
        }

        html += @"
    }
";
    return html;
    }

    private string generate_LoadDefaultData_methort(DataSet ds)
    {
        string html = @"
    private void LoadDefaultData()
    {
        ";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            switch (dr["DATA_TYPE"].ToString())
            {
                
                case "datetime":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=DateTime.Today.ToString(" + "\"dd/MM/yyyy\");";
                    break;
                case "int":
                    html += @"
        txt" + dr["COLUMN_NAME"].ToString() + @".Text=" + "\"0\";";
                    break;
                default:
                    break;
            }
        }

        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            switch (dr["DATA_TYPE"].ToString())
            {
                case "int":
                    html += @"
        ddl" + dr["COLUMN_NAME"].ToString() + @".SelectedValue=" + "\"0\";";
                    break;
                default:
                    break;
            }
        }

        html += @"
    }
";
        return html;
    }

    private string generate_Page_Load_method(DataSet ds)
    {

        string fileText = "";
        fileText += @"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadLoginInHiddenField();
            LoadDropdownlist();
            loadAllData();
            LoadDefaultData();
            if (CommonManager.SQLInjectionChecking(Request.QueryString[" + "\"saved\"" + @"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text=" + "\"Saved Successfully..\";" + @"
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString[" + "\"delete\"" + @"]) != null)
            {
                Delete_" +DropDownList2.SelectedValue+@"();
                Response.Redirect(" + "\"Admin_" + DropDownList2.SelectedValue + ".aspx?deleted=1\"" + @");
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString[" + "\"deleted\"" + @"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text=" + "\"Deleted Successfully..\";" + @"
            }

            if (CommonManager.SQLInjectionChecking(Request.QueryString[" + "\"edit\"" + @"]) != null)
            {
                Edit_" + DropDownList2.SelectedValue + @"();
            }
            if (CommonManager.SQLInjectionChecking(Request.QueryString[" + "\"edited\"" + @"]) != null)
            {
                divSuccessfull.Visible=true;
                lblMSG.Text=" + "\"Edited Successfully..\";" + @"
            }
        }
    }";

        fileText += generate_Edit(ds);
        fileText += generate_Delete(ds);
        fileText += generate_LoadLoginInHiddenField(ds);
        fileText += generate_LoadDropdownlist_method(ds);
        fileText += generate_loadAllData_method(ds);
        fileText += generate_LoadDefaultData_methort(ds);
        return fileText;
    }

    private string generate_Edit(DataSet ds)
    {
        string html = "";
        html += @"
    private void Edit_"+DropDownList2.SelectedValue+ @"()
    {
        try
        {
            string sql=@" + "\"Select * from [" + DropDownList2.SelectedValue + @"] where " + DropDownList2.SelectedValue + "_ID = \"" + "+Request.QueryString[" + "\"edit\"" + @"];
            DataRow dr = CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql).Tables[0].Rows[0];
            ";
    html+=loadDataForEidt(ds);

    html+=@"
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    } ";

        return html;
    }

    private string loadDataForEidt(DataSet ds)
    {
        string html = "";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            html += @"
            ";
            switch (dr["DATA_TYPE"].ToString())
            {
                case "datetime":
                html += @"txt" + dr["COLUMN_NAME"].ToString() + ".Text = DateTime.Parse(dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString()).ToString(\"dd/MM/yyyy\");";
                    break;
                case "int":
                    html += @"txt" + dr["COLUMN_NAME"].ToString() + ".Text = Decimal.Parse(dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString()).ToString(\"0,0\");";
                    break;
                case "decimal":
                    html += @"txt" + dr["COLUMN_NAME"].ToString() + ".Text = Decimal.Parse(dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString()).ToString(\"0,0.00\");";
                    break;
                default:
                html += @"txt" + dr["COLUMN_NAME"].ToString() + ".Text = dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString();";
                    break;

            }
        }
        
        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            html += @"
            ";
            switch (dr["DATA_TYPE"].ToString())
            {
                case "bit":
                html += @"chk" + dr["COLUMN_NAME"].ToString() + @".Checked = bool.Parse(dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString());";
                    break;

                case "int":
                html += @"ddl" + dr["COLUMN_NAME"].ToString() + ".SelectedValue = dr[" + "\"" + dr["COLUMN_NAME"].ToString() + "\"].ToString();";
                    
                    break;
                default:
                    break;
            }

        }

        return html;
    }


    private string generate_Delete(DataSet ds)
    {
        string html = "";
        html += @"
    private void Delete_" + DropDownList2.SelectedValue + @"()
    {
        try
        {
            string sql=@" + "\"Delete [" + DropDownList2.SelectedValue + @"] where " + DropDownList2.SelectedValue + "_ID = \"" + "+Request.QueryString[" + "\"delete\"" + @"];
            DataSet ds = CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql);
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }  ";

        return html;
    }

    private string generate_LoadLoginInHiddenField(DataSet ds)
    {
        string html = @"
    private void loadLoginInHiddenField()
    {
        if (hfLoginID.Value == "+"\"\""+@")
        {
            hfLoginID.Value = getLogin().LoginID.ToString();
        }
    }

    private Login getLogin()
    {
        Login login = new Login();

        try
        {
            if (Session["+"\"Login\""+@"] != null)
            {
                login = (Login)Session["+"\"Login\""+@"];
            }
            else if (hfLoginID.Value != " + "\"\"" + @")
            {
                login = LoginManager.GetLoginByID(int.Parse(hfLoginID.Value));
            }
            else
            { Session[" + "\"PreviousPage\"" + @"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect(" + "\"../LoginPage.aspx\"" + @"); }

        }
        catch (Exception ex)
        { }

        return login;
    }
";
        return html;
    }
    private string generate_LoadDropdownlist_method(DataSet ds)
    {

        string fileText = "";
        fileText += @"
    private void LoadDropdownlist()
    {
        try
        {
            DataSet ds = new DataSet();
            try
            {
                string sql=" + "@\"";

        string colums4SelectDropdownlist = "";
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (checkTableRelationDropDownlist(dr["COLUMN_NAME"].ToString()) != "")
            {
                colums4SelectDropdownlist += @"
                    " + checkTableRelationDropDownlist(dr["COLUMN_NAME"].ToString());
            }
        }

        fileText += colums4SelectDropdownlist + "\";" + @"
                if(sql!="+"\"\""+ @")
                ds = CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql);
            }
            catch (Exception ex)
            { 
                divSuccessfull.Visible=true;
                lblMSG.Text = ex.Message;
            }


";
        string colums4SelectDropdownlistGenerate = "";
        int rowNo = 0;
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (checkTableRelationDropDownlist(dr["COLUMN_NAME"].ToString()) != "")
            {
                colums4SelectDropdownlistGenerate += @"
            " + checkTableRelationDropDownlistGenerate(dr["COLUMN_NAME"].ToString(), rowNo++);
            }
        }

        fileText += colums4SelectDropdownlistGenerate;
fileText += @"
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }
";

        return fileText;
    }

    private string generate_loadAllData_method(DataSet ds)
    {

        string fileText = "";
        fileText += @"
    private void loadAllData()
    {
        try
        {
            string sql = @" + "\"Select ";

        string colums4Select = "";
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (checkTableRelation(dr["COLUMN_NAME"].ToString()) != "")
            {
                colums4Select +=
                    (colums4Select == "" ? @"
                " : @"
                ,") + checkTableRelation(dr["COLUMN_NAME"].ToString());
            }
        }

        fileText += colums4Select;
        fileText += @"
         from [" + DropDownList2.SelectedValue+"]";

        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            fileText += checkTableRelation4InnerJoin(dr["COLUMN_NAME"].ToString());

        }
        fileText += @"
        order by [" + DropDownList2.SelectedValue + "]." + DropDownList2.SelectedValue + "_Name\"" + @";
        DataSet ds = CommonManager.SQLExec_"+DropDownList1.SelectedItem.Text+@"(sql);
        string html = @" + "\"" + @"<table class='table table-striped table-bordered table-hover' id='dataTable'>
                            <thead>
                                <tr>
                                    <th>
                                        Action
                                    </th>";
        string colums4TableHeader = "";
        foreach (DataRow dr in ds.Tables[2].Rows)
        {
            if (checkTableRelation4TableHeader(dr["COLUMN_NAME"].ToString()) != "")
            {
                colums4TableHeader += @"
                <th>" + checkTableRelation4TableHeader(dr["COLUMN_NAME"].ToString()) + "</th>";
            }
        }

        fileText += colums4TableHeader + @"
                                </tr>
                            </thead>
                            <tbody>" + "\";";

        string colums4TableData = @"int count=0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ";
        colums4TableData += @"
            if (count++ % 2 == 0)
            {
                html += @" + "\"";
        colums4TableData += @"
                <tr class='odd gradeX'>" + "\";" + @"
            }
            else
            {
                html += @" + "\"";
        colums4TableData += @"
                <tr class='even gradeX'>" + "\";" + @"
            }

            html +=" + "@\"";

        foreach (DataRow dr in ds.Tables[2].Rows)
        {

            if (checkTableRelation4TableData(dr["COLUMN_NAME"].ToString(), dr["DATA_TYPE"].ToString()) != "")
            {
                colums4TableData += @"
                " + checkTableRelation4TableData(dr["COLUMN_NAME"].ToString(), dr["DATA_TYPE"].ToString());
            }

        }
        colums4TableData += @"
                    </tr>";
        fileText += colums4TableData + "\";" + @"
            }

            html +=" + "@\"" + @"
";

        fileText += @"
                                    </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>" + "\";";
        fileText += @"
            lblList.Text=html;
";
        fileText += @"
        }
        catch (Exception ex)
        { 
            divSuccessfull.Visible=true;
            lblMSG.Text = ex.Message;
        }
    }
";

        return fileText;
    }


    private string generate_usingSection(DataSet ds)
    {
        return @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_" + DropDownList2.SelectedValue + @" : System.Web.UI.Page
{
        ";
    }
    
    private string checkTableRelation4TableData(string colName,string dataType)
    {
        
        string retunvalue = "";
        if (IslastCommonCol(colName))
        {
            return "";
        }

        if (colName == DropDownList2.SelectedValue + "_ID")
        {
            retunvalue = @"
                            <td>
                                        <div class='btn-group'>
                                            <button data-toggle='dropdown' class='btn btn-primary dropdown-toggle'>
                                                Action <span class='caret'></span>
                                            </button>
                                            <ul class='dropdown-menu'>
                                                <li><a href='Admin_" + DropDownList2.SelectedValue + @".aspx?edit="+"\"+dr[\""+DropDownList2.SelectedValue + "_ID\"].ToString()+@\""+@"'>Edit</a></li>
                                                <li><a href='Admin_" + DropDownList2.SelectedValue + ".aspx?delete=" + "\"+dr[\"" + DropDownList2.SelectedValue + "_ID\"].ToString()+@\"" + @"'  onclick=" + "\"+\"\\\"return confirm('Are you sure you want to edit?')\\\"\"" + @"+@"">Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>";
        }
        else if (!colName.Contains("_ID"))
        {
            if (dataType == "datetime")
            {
                retunvalue = @"
                            <td>" + "\"+DateTime.Parse(dr[\"" + colName + "\"].ToString()).ToString(\"dd MMM yyyy\")+@\"" + "</td>";
            }
            else if (dataType == "decimal")
            {
                retunvalue = @"
                            <td>" + "\"+decimal.Parse(dr[\"" + colName + "\"].ToString()).ToString(\"0,0.00\")+@\"" + "</td>";
            }
            else if (dataType == "int")
            {
                retunvalue = @"
                            <td>" + "\"+decimal.Parse(dr[\"" + colName + "\"].ToString()).ToString(\"0,0\")+@\"" + "</td>";
            }
            else
            {
                retunvalue = @"
                            <td>" + "\"+dr[\"" + colName + "\"].ToString()+@\"" + "</td>";
            }
        }
        else
        {
            retunvalue = @"
                            <td>" + "\"+dr[\"" + colName.Substring(0, colName.Length - 2) + "Name" + "\"].ToString()+@\"" + "</td>";
        }

        return retunvalue;
    }

    private bool IslastCommonCol(string colName)
    {
        switch (colName)
        {
            case "Added_By":
                return true;
            case "Added_Date":
                return true;
            case "Updated_By":
                return true;
            case "Updated_Date":
                return true;
            case "Rowstatus_ID":
                return true;
            default:
                return false;
        }
    }

    private string checkTableRelation4TableHeader(string colName)
    {
        if (IslastCommonCol(colName))
        {
            return "";
        }
        string retunvalue = "";
        if (colName == DropDownList2.SelectedValue + "_ID")
        {
            retunvalue =  "";
        }
        else if (!colName.Contains("_ID"))
        {
            retunvalue = colName.Replace("_", " ");
        }
        else
        {
            retunvalue =  colName.Substring(0, colName.Length - 3).Replace("_"," ")  ;
        }

        return retunvalue;
    }

    private string checkTableRelation4InnerJoin(string colName)
    {
        if (IslastCommonCol(colName))
            return "";
        string retunvalue = "";
        if (colName == DropDownList2.SelectedValue + "_ID" || !colName.Contains("_ID"))
        {
            retunvalue= "";
        }
        else
        {
            retunvalue = @"
            inner join [" + colName.Substring(0, colName.Length - 3) + "] on [" + colName.Substring(0, colName.Length - 3) + "]." + colName + " = [" + DropDownList2.SelectedValue + "]." + colName;
        }

        return retunvalue;
    }
    private string checkTableRelationDropDownlistGenerate(string colName,int rowNo)
    {
        if (IslastCommonCol(colName))
            return "";
        string retunvalue = "";
        if (colName == DropDownList2.SelectedValue + "_ID" || !colName.Contains("_ID"))
        {
            retunvalue = "";
        }
        else
        {
            retunvalue =
            "ddl"+colName + @".Items.Clear();
            ddl" + colName + @".Items.Add(new ListItem("+"\"Select........\", \"0\""+@"));
            foreach (DataRow dr in ds.Tables[" +rowNo+@"].Rows)
            {
                ddl"+colName + @".Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
           ";
        }

        return retunvalue;
    }


    private string checkTableRelationDropDownlist(string colName)
    {
        if (IslastCommonCol(colName))
            return "";
        string retunvalue = "";
        if (colName == DropDownList2.SelectedValue + "_ID" || !colName.Contains("_ID"))
        {
            retunvalue = "";
        }
        else
        {
            retunvalue = 
            "select "+colName+", "+colName.Substring(0, colName.Length - 2) + "Name from "+
                "["+colName.Substring(0, colName.Length - 3) + @"]
                    order by " + colName.Substring(0, colName.Length - 2) + "Name";
        }

        return retunvalue;
    }

    private string checkTableRelation(string colName)
    {
        if (IslastCommonCol(colName))
            return "";
        string retunvalue="";
        if (colName == DropDownList2.SelectedValue + "_ID" || !colName.Contains("_ID"))
        {
            retunvalue ="["+ DropDownList2.SelectedValue+"]."+colName;
        }
        else
        {
            retunvalue = "[" + colName.Substring(0, colName.Length - 3) + "]." + colName.Substring(0, colName.Length - 2) + "Name";
        }

        return retunvalue;
    }
    #endregion

    #region GenereateUI
    private void GenereateUI(DataSet ds)
    {
        string fileText = InitialText();
        fileText += loadAddPart(ds);
        fileText += Generate_List();
        fileText += @"
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>";
        string dirUrl = DropDownList1.SelectedItem.Text;
        string dirPath = Server.MapPath(dirUrl);
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllText(dirPath + @"\Admin_" + DropDownList2.SelectedValue + ".aspx", fileText);
    }
    private string InitialText()
    {
        return "<%@ Page Title=\"" + DropDownList2.SelectedValue.Replace("_", " ") + "\" Language=\"C#\" MasterPageFile=\"~/Login/AdminMaster.master\" AutoEventWireup=\"true\"" + @"
    " + "CodeFile=\"Admin_" + DropDownList2.SelectedValue + ".aspx.cs\" Inherits=\"Admin_" + DropDownList2.SelectedValue + "\" %>" + @"
    " + "<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"Server\">" + @"
    " + "</asp:Content>" + @"
    " + "<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"ContentPlaceHolder1\" runat=\"Server\">" + @"
        <asp:UpdatePanel ID='UpdatePanel1' runat='server'>
        <ContentTemplate>
 <asp:HiddenField ID='hfLoginID' runat='server' />
    " + "<div class=\"row\">" + @"
    " + "<div class=\"col-lg-12\">" + @"
    " + "<h1 class=\"page-header\">" + @"
    " + DropDownList2.SelectedValue.Replace("_", " ") + "</h1>" + @"
    " + "</div>" + @"
    " + "</div>" + @"
    " + "<div class=\"row\">" + @"
    " + "<div class=\"col-lg-12\">" + @"
    " + "<div class=\"panel panel-default\">" + @"
    " + "<div class=\"panel-heading\">" + @"
    " + "Add / Edit Information" + @"
    " + "</div>" + @"
    " + "<div class=\"panel-body\">" + @"
    " + "<div class=\"row\">" + @"
    " + "<div class=\"col-lg-6\">";
    }
  

    private string loadAddPart(DataSet ds)
    {
        string html = "<table>";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            html += @"<tr class='form-group'>
                                    <td class='control-label'>
                                                " + dr["COLUMN_NAME"].ToString().Replace("_", " ") + @"
                                    </td>
                                    <td class='col-lg-10'>
                    ";
            switch (dr["DATA_TYPE"].ToString())
            {
                case "nvarchar":
                    html += @"<asp:TextBox ID='txt" + dr["COLUMN_NAME"].ToString() + @"' runat='server' class='form-control' " +
                             (dr["CHARACTER_MAXIMUM_LENGTH"].ToString() == "-1" ? " TextMode='MultiLine' " : "")
                             + @"></asp:TextBox>
                        ";
                    break;
                case "datetime":
                    html += @"<div class='input-group'>
                                            <asp:TextBox ID='txt" + dr["COLUMN_NAME"].ToString() + @"' runat='server' class='form-control' data-mask='99/99/9999'></asp:TextBox>
                                            <span class='input-group-addon'>dd/mm/yyyy</span>
                                            <ajaxToolkit:CalendarExtender Format='dd/MM/yyyy' ID='CalendarExtender5' runat='server'
                                                TargetControlID='txt" + dr["COLUMN_NAME"].ToString() + @"'>
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                        ";
                    break;
                
                default:
                    html += @"<asp:TextBox ID='txt" + dr["COLUMN_NAME"].ToString() + @"' runat='server' class='form-control' ></asp:TextBox>
                        ";
                    break;
            }

            html += @"</td>
                                </tr>
                ";
        }
        html += @"</table>
               </div>
                        <div class='col-lg-6'> <table>";

        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            html += @"<tr class='form-group'>
                                    <td class='control-label'>
                                                " + (dr["DATA_TYPE"].ToString() == "bit" ? "" : dr["COLUMN_NAME"].ToString().Replace("_ID", "").Replace("_", " ")) + @"
                                    </td>
                                    <td class='col-lg-10'>
                    ";
            switch (dr["DATA_TYPE"].ToString())
            {
                case "bit":
                    html += @"<asp:CheckBox ID='chk" + dr["COLUMN_NAME"].ToString() + @"' runat='server' Text='" + dr["COLUMN_NAME"].ToString().Replace("_", " ") + @" ?' />
                        ";
                    break;

                case "int":
                    html += @"<asp:DropDownList ID='ddl" + dr["COLUMN_NAME"].ToString() + @"' runat='server' class='chzn-select'>
                                            </asp:DropDownList>
                        ";
                    break;
                default:
                    break;
            }

            html += @"</td>
                                </tr>
                ";
        }

        html += @"</table>

                        </div>
                    </div>
<center style='margin-top:30px;'>
<asp:Button ID='btnSave' runat='server' Text='Save' class='btn btn-default' 
                                            onclick='btnSave_Click'  />
                                        <asp:Button ID='btnReset' runat='server' Text='Reset' class='btn btn-default' 
                                            onclick='btnReset_Click' />
<div class='alert alert-info alert-dismissable'  ID='divSuccessfull' runat='server' Visible='false' style='width:50%'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                                <asp:Label ID='lblMSG' runat='server' Text=''></asp:Label>
                            </div>
</center>
                </div>
            </div>
        </div>
    </div>";
        return html;
    }

    private string Generate_List()
    {
        return @"<div class='row'>
        <div class='col-lg-12'>
            <div class='panel panel-default'>
                <div class='panel-heading'>
                    "+DropDownList2.SelectedValue.Replace("_"," ")+@" List
                </div>
                <div class='panel-body'>
                    <div class='table-responsive'>
    <asp:Label ID='lblList' runat='server' Text=''></asp:Label>
    </div>
                </div>
            </div>
        </div>
    </div>";
    }


    #endregion

    protected void btnGenerateAllTable_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in DropDownList2.Items)
        {
            DropDownList2.SelectedValue = item.Value;
            btnGenerate_Click(this, new EventArgs());
        }
    }
}