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
using Telerik.Web.UI;
using System.IO;
using System.Collections.Generic;


public partial class Admin_Controls_EditWidget : System.Web.UI.UserControl
{
    //string strParentFolder = "Client/Modules/MainHome";
    string strParentFolder = "Client/Modules";
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

           // GetFile();
            initControl(ID);
            ViewWidgetAll();
           // ActipFile();
            
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
            txtID.Value = Convert.ToString(ID);
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;

            try
            {
                SYS_WidgetBSO sys_WidgetBSO = new SYS_WidgetBSO();
                SYS_Widget sys_Widget = sys_WidgetBSO.GetSYS_WidgetById(ID);

                Bind_ddlWidgetType();
                ddlWidgetType.SelectedValue = Convert.ToString(sys_Widget.WidgetType);

                txtWidgetName.Text = sys_Widget.WidgetName;

                GetFile();
                GetFileControl = sys_Widget.WidgetControl + ".ascx";
                ActipFile();

                try
                {
                    dropFolder.SelectedItem.Text = sys_Widget.WidgetDir.ToString();
                    dropFolder.SelectedValue = sys_Widget.WidgetDir.ToString();
                }
                catch { }
                txtInfo.Text = sys_Widget.WidgetInfo;
                chkStatus.Checked = sys_Widget.WidgetStatus;
              }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            GetFile();
            ActipFile();
            Bind_ddlWidgetType();
            txtID.Value = "";
            ddlWidgetType.SelectedIndex = 0;
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;

        }
    }
    #endregion

    #region Bind_ddlWidgetType
    protected void Bind_ddlWidgetType()
    {
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        DataTable table = _widgetTypeBSO.GetSYS_WidgetTypeAll();
        commonBSO commonBSO = new commonBSO();
        ddlWidgetType.Items.Clear();
        commonBSO.FillToDropDown(ddlWidgetType, table, "", "", "WidgetTypeName", "Id", "");
    }
    #endregion

    #region AddNews
    protected void Add()
    {
        SYS_WidgetBSO sys_WidgetBSO = new SYS_WidgetBSO();
        SYS_Widget sys_Widget = ReceiveHtml();
        try
        {
            
            int id =  sys_WidgetBSO.CreateSYS_WidgetGet(sys_Widget);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới thành công !</div>";
            initControl(id);
            
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
        SYS_WidgetBSO sys_WidgetBSO = new SYS_WidgetBSO();
        SYS_Widget sys_Widget = ReceiveHtml();
        try
        {
            sys_WidgetBSO.UpdateSYS_Widget(sys_Widget);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
            initControl(sys_Widget.Id);
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    #endregion

    #region ReceiveHtml
    public SYS_Widget ReceiveHtml()
    {
        SYS_Widget sys_Widget = new SYS_Widget();

        sys_Widget.Id = (txtID.Value != "") ? Convert.ToInt32(txtID.Value) : 0;
        sys_Widget.WidgetName = (txtWidgetName.Text != "") ? txtWidgetName.Text.Trim() : "";
        sys_Widget.WidgetDir = (dropFolder.SelectedValue != "") ? dropFolder.SelectedItem.Text : "";
        sys_Widget.WidgetControl = (dropControl.SelectedValue != "") ? dropControl.SelectedValue.Replace(".ascx", "") : "";
        sys_Widget.WidgetType = (ddlWidgetType.SelectedValue != "") ? Convert.ToInt32(ddlWidgetType.SelectedValue) : 0;

        sys_Widget.WidgetInfo = txtInfo.Text;
 
        sys_Widget.WidgetStatus = chkStatus.Checked;

        return sys_Widget;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Add();
        AspNetCache.Reset();
        ViewWidgetAll();
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        SYS_WidgetBSO sys_WidgetBSO = new SYS_WidgetBSO();
        SYS_Widget sys_Widget = ReceiveHtml();
        try
        {

            int id = sys_WidgetBSO.CreateSYS_WidgetGet(sys_Widget);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới thành công !</div>";
            AspNetCache.Reset();
            ViewWidgetAll();

        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
        
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        Edit();
        AspNetCache.Reset();
        ViewWidgetAll();
    }

    #region ViewWidgetAll
    private void ViewWidgetAll()
    {
        SYS_WidgetBSO _widgetBSO = new SYS_WidgetBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetAllFull();
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();

    }
    #endregion


    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridItem gridViewRow = e.Item;
        if (e.Item.ItemType == GridItemType.Item)
        {
            LinkButton image_del = (LinkButton)e.Item.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
        }
    }


    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int Id = 0;

        if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            Id = Convert.ToInt32(e.CommandArgument.ToString());

        string nName = e.CommandName.ToLower();
        switch (nName)
        {

            case "_edit":
                Response.Redirect("~/Homepage.aspx?dll=EditWidget&id=" + Id);
                break;
            case "_delete":
                SYS_WidgetBSO _widgetBSO = new SYS_WidgetBSO();
                _widgetBSO.DeleteSYS_Widget(Id);
                ViewWidgetAll();
                AspNetCache.Reset();
                break;
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

    #endregion
   
}
