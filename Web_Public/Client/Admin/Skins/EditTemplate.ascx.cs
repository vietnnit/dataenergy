using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ETO;
using BSO;
using System.IO;
public partial class Client_Admin_EditTemplate : System.Web.UI.UserControl
{
    string strParentFolder = "";
    static DataTable tb;
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            ViewTemplate();
            initControl(Id);
        }
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

   

    #region ViewTemplate
    private void ViewTemplate()
    {
        SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
        DataTable table = templateBSO.GetSYS_TemplatePageAll(Language.language);

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvTemplate, table);
    }
    #endregion

    #region initControl
    private void initControl(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
                SYS_TemplatePage template = templateBSO.GetSYS_TemplatePageById(Id);


                hddID.Value = Convert.ToString(template.Id);
               
                txtName.Text = template.TemplateName;
                txtInfo.Text = template.Info;
                GetFile();
                dropControl.SelectedValue = template.TemplateControl;
                GetFileMasterPage();
                ddlMasterPage.SelectedValue = template.MasterControl;

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            GetFile();
            GetFileMasterPage();
            btn_edit.Visible = false;
            btn_add.Visible = true;

            btn_edit1.Visible = false;
            btn_add1.Visible = true;
            btn_add2.Visible = true;

        }
    }
    #endregion

    #region ReceiveHtml
    private SYS_TemplatePage ReceiveHtml()
    {

        SYS_TemplatePage template = new SYS_TemplatePage();
        template.Id = (hddID.Value != "") ? Convert.ToInt32(hddID.Value) : 0;
        template.TemplateName = txtName.Text;
        template.Info = txtInfo.Text;
        if (dropControl.SelectedIndex > 0)
        {
            template.TemplateControl = dropControl.SelectedValue;
        }

        if (ddlMasterPage.SelectedIndex > 0)
        {
            template.MasterControl = ddlMasterPage.SelectedValue;
        }
        template.Language = Language.language;

        return template;
    }
    #endregion

    protected void grvTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTemplate.PageIndex = e.NewPageIndex;

        ViewTemplate();
    }
    protected void grvTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "_edit":
                Response.Redirect("~/Admin/EditTemplate/" + Id +"/Default.aspx");
                break;

            case "_delete":
                SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
                templateBSO.DeleteSYS_TemplatePage(Id);

                ViewTemplate();
                break;
        }
    }
    protected void grvTemplate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        try
        {
            
                SYS_TemplatePage template = new SYS_TemplatePage();
                template = ReceiveHtml();


                SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
                int id = templateBSO.CreateSYS_TemplatePageGet(template);

                ViewTemplate();
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
                initControl(id);

          
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }

    }

    protected void btn_add_Click_more(object sender, EventArgs e)
    {

        try
        {
           
                SYS_TemplatePage template = new SYS_TemplatePage();
                template = ReceiveHtml();


                SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
                int id = templateBSO.CreateSYS_TemplatePageGet(template);

                ViewTemplate();
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";

           
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }

    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_TemplatePage template = new SYS_TemplatePage();
            template = ReceiveHtml();

            SYS_TemplatePageBSO templateBSO = new SYS_TemplatePageBSO();
            templateBSO.UpdateSYS_TemplatePage(template);

            ViewTemplate();
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(template.Id);
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }




    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }

    private void GetFile()
    {
        
        strParentFolder = "Client/Skins/Templates";


        //load o len cay bang phuong phap de quy
        // khai bao mang o dia
        string _path = ResolveUrl("~/") + @"/" + strParentFolder;
        tb = CreateDataTable();
        //TreeNode treeNode;
        for (int i = 0; i < 1; i++)
        {
            DataRow dr = tb.NewRow();
            dr["ForderName"] = Server.MapPath(_path);// "CMSUpload";
            dr["Path"] = Server.MapPath(_path);
            tb.Rows.Add(dr);
            LoadFolders(Server.MapPath(_path));
        }
        //  List<FileInfo> _listfile = new List<FileInfo>();
        if (tb.Rows.Count > 0)
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Name";
            myDataTable.Columns.Add(myDataColumn);

            // DataRow row = myDataTable.NewRow();


            foreach (DataRow dr in tb.Rows)
            {
                string upFolder = dr["ForderName"].ToString();
                DirectoryInfo dir = new DirectoryInfo(upFolder);
                FileInfo[] fFileList = dir.GetFiles();
                if (fFileList != null)
                {
                    if (fFileList.Length > 0)
                    {
                        foreach (FileInfo objFile in fFileList)
                        {

                            if (objFile.Extension.ToLower() == ".ascx")
                            {
                                //   row["Name"] = objFile.FullName.ToString();
                                myDataTable.Rows.Add(objFile.Name.ToString());
                            }
                        }
                    }
                }
            }

            dropControl.DataSource = myDataTable;
            dropControl.DataTextField = "Name";
            dropControl.DataValueField = "Name";

            dropControl.DataBind();
            dropControl.Items.Insert(0, "------ Chọn -------");
        }

    }

    private void GetFileMasterPage()
    {

        strParentFolder = "Client/Skin/Template";


        //load o len cay bang phuong phap de quy
        // khai bao mang o dia
        string _path = ResolveUrl("~/") + @"/" + strParentFolder;
        tb = CreateDataTable();
        //TreeNode treeNode;
        for (int i = 0; i < 1; i++)
        {
            DataRow dr = tb.NewRow();
            dr["ForderName"] = Server.MapPath(_path);// "CMSUpload";
            dr["Path"] = Server.MapPath(_path);
            tb.Rows.Add(dr);
            LoadFolders(Server.MapPath(_path));
        }
        //  List<FileInfo> _listfile = new List<FileInfo>();
        if (tb.Rows.Count > 0)
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Name";
            myDataTable.Columns.Add(myDataColumn);

            // DataRow row = myDataTable.NewRow();


            foreach (DataRow dr in tb.Rows)
            {
                string upFolder = dr["ForderName"].ToString();
                DirectoryInfo dir = new DirectoryInfo(upFolder);
                FileInfo[] fFileList = dir.GetFiles();
                if (fFileList != null)
                {
                    if (fFileList.Length > 0)
                    {
                        foreach (FileInfo objFile in fFileList)
                        {

                            if (objFile.Extension.ToLower() == ".master")
                            {
                                //   row["Name"] = objFile.FullName.ToString();
                                myDataTable.Rows.Add(objFile.Name.ToString());
                            }
                        }
                    }
                }
            }

            ddlMasterPage.DataSource = myDataTable;
            ddlMasterPage.DataTextField = "Name";
            ddlMasterPage.DataValueField = "Name";

            ddlMasterPage.DataBind();
            ddlMasterPage.Items.Insert(0, "------ Chọn -------");
        }

    }

    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ForderName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Path";
        myDataTable.Columns.Add(myDataColumn);


        return myDataTable;
    }

    private void LoadFolders(string _path)
    {
        // tim duong dan va add vao chinh no
        string Path = _path;
        //try
        //{   // tao mang cho folder
        string[] arrFolder = Directory.GetDirectories(Path);

        for (int i = 0; i < arrFolder.Length; i++)
        {
            DataRow dr = tb.NewRow();

            string _forderName = _path + "/" + arrFolder[i].Substring(arrFolder[i].LastIndexOf("\\") + 1, arrFolder[i].Length - arrFolder[i].LastIndexOf("\\") - 1);
            int _indexStart = 0;
            int _indexEnd = -1;

            _indexStart = _forderName.IndexOf("Portals");
            //Tool.Message(this.Page, "Count:=" + _indexStart.ToString());
            if (_indexStart > 0)
            {
                _indexEnd = _forderName.Length - _indexStart;
                _forderName = "" + _forderName.Substring(_indexStart, _indexEnd);
            }
            _forderName = _forderName.Replace("\\", "/");
            dr["ForderName"] = _forderName;
            dr["Path"] = _path + "/" + arrFolder[i].Substring(arrFolder[i].LastIndexOf("\\") + 1, arrFolder[i].Length - arrFolder[i].LastIndexOf("\\") - 1);
            tb.Rows.Add(dr);
            //Tool.Message(this.Page, "Count:=" + dr["Path"].ToString());
            LoadFolders(dr["Path"].ToString());

        }
        //}
        //catch { }
    }

    


}
