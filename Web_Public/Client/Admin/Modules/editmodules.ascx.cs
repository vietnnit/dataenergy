using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using DAO;
using BSO;
using System.IO;
using System.Collections.Generic;


public partial class Admin_Controls_CreateModules : System.Web.UI.UserControl
{
    string strParentFolder = "Client/Admin";
    static DataTable tb;


    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"], out ID);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            GetFile();
            BindDropDownList();
            initControl(ID);
            ActipFile();
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

    #region initControl
    protected void initControl(int ID)
    {
        if (ID > 0)
        {
            txtModulesID.Value = Convert.ToString(ID);
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                ModulesBSO modulesBSO = new ModulesBSO();

                Modules modulesRows = modulesBSO.GetModulesById(ID);
                ddlModules.SelectedValue = modulesRows.ModulesParent.ToString();
                txtModulesName.Text = modulesRows.ModulesName;
                //txtModulesDir.Text = modulesRows.ModulesDir;
                //txtModulesUrl.Text = modulesRows.ModulesUrl;
                GetFileControl = modulesRows.ModulesUrl + ".ascx";


                try
                {
                    dropFolder.SelectedItem.Text = modulesRows.ModulesDir.ToString();
                    dropFolder.SelectedValue = modulesRows.ModulesDir.ToString();
                }
                catch { }

                txtRadHelp.Text = modulesRows.ModulesHelp;
                hddIcon.Value = modulesRows.ModulesIcon;
                txtimage4_3.Text = modulesRows.ModulesIcon;
                //img_thumb.Text = "<img src='" + modulesRows.ModulesIcon + "' width='48px'>";
                chkMenu.Checked = modulesRows.IsMenu;
                chkStatus.Checked = modulesRows.Status;
                chkView.Checked = modulesRows.IsView;

                txtSlug.Text = modulesRows.Slug;

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            txtModulesID.Value = "";
            ddlModules.SelectedIndex = 0;
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;
        }
    }
    #endregion

    #region BindDropDownList
    protected void BindDropDownList()
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        DataTable table = modulesBSO.MixModules();
        commonBSO commonBSO = new commonBSO();
        ddlModules.Items.Clear();
        commonBSO.FillToDropDown(ddlModules, table, "~ Cấp độ modules ~", "0", "Modules_Name", "Modules_ID", "");
    }
    #endregion

    #region AddNews
    protected void Add()
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = ReceiveHtml();
        try
        {
            //if (modulesBSO.CheckExist(modules.ModulesUrl))
            //{
            //    error.Text = String.Format(Resources.StringAdmin.CheckExist, modules.ModulesUrl);
            //}
            //else
            //{
            int id = modulesBSO.AddModules(modules);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(id);
            BindDropDownList();
            //}
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }

    }
    #endregion

    #region Edit
    protected void Edit()
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = ReceiveHtml();
        try
        {
            modulesBSO.EditModules(modules);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(modules.ModulesID);
            BindDropDownList();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    #endregion

    #region ReceiveHtml
    public Modules ReceiveHtml()
    {
        Modules modules = new Modules();

        ////      string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Admin/Admin_Theme/Icons/";
        //string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Admin_Theme/Icons/";
        //commonBSO commonBSO = new commonBSO();
        //string icon_upload = commonBSO.UploadImage(uploadIcon, path, 55, 55);

        modules.ModulesID = (txtModulesID.Value != "") ? Convert.ToInt32(txtModulesID.Value) : 0;
        modules.ModulesName = (txtModulesName.Text != "") ? txtModulesName.Text.Trim() : "";
        modules.ModulesOrder = 0;
        modules.ModulesParent = (ddlModules.SelectedValue != "") ? Convert.ToInt32(ddlModules.SelectedValue) : 0;
        modules.ModulesDir = (dropFolder.SelectedValue != "") ? dropFolder.SelectedItem.Text : "";
        modules.ModulesUrl = (dropControl.SelectedValue != "") ? dropControl.SelectedValue.Replace(".ascx", "") : "";
        modules.ModulesHelp = txtRadHelp.Text;
        modules.ModulesIcon = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddIcon.Value;

        modules.Slug = (txtSlug.Text != "") ? txtSlug.Text.Trim() : dropControl.SelectedValue.Replace(".ascx", "");

        modules.Status = chkStatus.Checked;
        modules.IsMenu = chkMenu.Checked;
        modules.IsView = chkView.Checked;


        return modules;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Add();
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        Edit();

    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = ReceiveHtml();
        try
        {
            int id = modulesBSO.AddModules(modules);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            BindDropDownList();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
        
    }

    #region
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

    private void GetFile()
    {
        //load o len cay bang phuong phap de quy
        // khai bao mang o dia
        string _path = ResolveUrl("~/") + @"/" + strParentFolder;
        tb = CreateDataTable();
        for (int i = 0; i < 1; i++)
        {
            DataRow dr = tb.NewRow();
            dr["ForderName"] = Server.MapPath(_path);// "CMSUpload";
            dr["Path"] = Server.MapPath(_path);
            tb.Rows.Add(dr);
            LoadFolders(Server.MapPath(_path));
        }
        if (tb.Rows.Count > 0)
        {
            int _index = 0;
            foreach (DataRow dr in tb.Rows)
            {
                string[] _str = dr["Path"].ToString().Split('/');
                if (_index > 0)
                {

                    dr["Path"] = _str[_str.Length - 1].ToString();

                }
                else
                {
                    dr["Path"] = "------ Chọn -------";

                }
                _index++;
            }

            dropFolder.DataSource = tb;
            dropFolder.DataTextField = "Path";
            dropFolder.DataValueField = "ForderName";

            dropFolder.DataBind();

        }

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
    public string GetFileControl
    {
        get
        {
            //Check Exist ViewState
            if (ViewState["GetFileControl"] != null && ViewState["GetFileControl"] is string)
            {
                return (string)ViewState["GetFileControl"];
            }
            else

                return "";
        }
        set { ViewState["GetFileControl"] = value; }
    }
    private void ActipFile()
    {
        List<FileInfo> _listfile = new List<FileInfo>();
        if (tb.Rows.Count > 0)
        {
            if (tb != null)
            {
                if (tb.Rows.Count > 0)
                {

                    foreach (DataRow _dr in tb.Rows)
                    {
                        int _check = 0;
                        string upFolder = _dr["ForderName"].ToString();
                        DirectoryInfo dir = new DirectoryInfo(upFolder);
                        FileInfo[] fFileList = dir.GetFiles();
                        if (fFileList != null)
                        {
                            if (fFileList.Length > 0)
                            {
                                foreach (FileInfo objFile in fFileList)
                                {
                                    if (objFile.Extension.ToLower() == ".ascx" && objFile.Name == GetFileControl)
                                    {
                                        _check = 1;
                                        _listfile.Add(objFile);
                                    }
                                }
                            }
                        }
                        if (_check == 1)
                        {
                            break;
                        }
                    }
                }
            }

            dropControl.DataSource = _listfile;
            dropControl.DataTextField = "Name";
            dropControl.DataValueField = "Name";

            dropControl.DataBind();
            dropControl.Items.Insert(0, "------ Chọn -------");
            try
            {
                dropControl.SelectedValue = GetFileControl;
            }
            catch { }
        }
    }
    protected void dropFolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<FileInfo> _listfile = new List<FileInfo>();
        if (tb.Rows.Count > 0)
        {
            if (dropFolder.SelectedIndex > 0)
            {
                string upFolder = dropFolder.SelectedValue.ToString();
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

                                _listfile.Add(objFile);

                            }
                        }
                    }
                }
            }

            dropControl.DataSource = _listfile;
            dropControl.DataTextField = "Name";
            dropControl.DataValueField = "Name";

            dropControl.DataBind();
            dropControl.Items.Insert(0, "------ Chọn -------");
        }
    }

    protected void dropControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSlug.Text = dropControl.SelectedItem.Text.Replace(".ascx", "");
    }

    #endregion


}
