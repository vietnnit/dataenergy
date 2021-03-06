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

public partial class Admin_Controls_EditWidgetType : System.Web.UI.UserControl
{
    //string strParentFolder = "Client/Modules/MainHome";
    string strParentFolder = "Client/Admin/Skins/WidgetType";
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
            ViewWidgetType();
            initControl(ID);
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

    #region ViewWidgetType
    private void ViewWidgetType()
    {
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        DataTable table = _widgetTypeBSO.GetSYS_WidgetTypeAll();

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvWidgetType, table);
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
                SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
                SYS_WidgetType _widgetType = _widgetTypeBSO.GetSYS_WidgetTypeById(ID);

                txtWidgetTypeName.Text = _widgetType.WidgetTypeName;
                GetFile();
                dropControl.SelectedValue = _widgetType.WidgetControl;
                hddDir.Value = _widgetType.WidgetDir;
                txtInfo.Text = _widgetType.WidgetInfo;
                chkStatus.Checked = _widgetType.WidgetStatus;
                hddOrders.Value = _widgetType.Orders.ToString();

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            GetFile();
            txtID.Value = "";
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;
        }
    }
    #endregion


    #region AddNews
    protected void Add()
    {
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        SYS_WidgetType _widgetType = ReceiveHtml();
        try
        {

            int id = _widgetTypeBSO.CreateSYS_WidgetTypeGet(_widgetType);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(id);
            ViewWidgetType();
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
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        SYS_WidgetType _widgetType = ReceiveHtml();
        try
        {
            _widgetTypeBSO.UpdateSYS_WidgetType(_widgetType);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(_widgetType.Id);
            ViewWidgetType();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    #endregion

    #region ReceiveHtml
    public SYS_WidgetType ReceiveHtml()
    {
        SYS_WidgetType _widgetType = new SYS_WidgetType();

        _widgetType.Id = (txtID.Value != "") ? Convert.ToInt32(txtID.Value) : 0;
        _widgetType.WidgetTypeName = (txtWidgetTypeName.Text != "") ? txtWidgetTypeName.Text.Trim() : "";

        _widgetType.WidgetDir = (hddDir.Value != "") ? hddDir.Value : strParentFolder;

        if (dropControl.SelectedIndex > 0)
        {
            _widgetType.WidgetControl = dropControl.SelectedValue;
        }
        //_widgetType.WidgetControl = (dropControl.SelectedValue != "") ? dropControl.SelectedValue.Replace(".ascx", "") : "";
        _widgetType.WidgetInfo = txtInfo.Text;
        _widgetType.WidgetStatus = chkStatus.Checked;
        _widgetType.Orders = (hddOrders.Value != "") ? Convert.ToInt32(hddOrders.Value) : 0;

        return _widgetType;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Add();
        AspNetCache.Reset();
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        SYS_WidgetType _widgetType = ReceiveHtml();
        try
        {
            int id = _widgetTypeBSO.CreateSYS_WidgetTypeGet(_widgetType);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            AspNetCache.Reset();
            ViewWidgetType();
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
    }

    protected void grvWidgetType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvWidgetType.PageIndex = e.NewPageIndex;

        ViewWidgetType();
    }
    protected void grvWidgetType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "_edit":
                Response.Redirect("~/Homepage.aspx?dll=EditWidgetType&id=" + Id);
                break;

            case "_delete":
                SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
                _widgetTypeBSO.DeleteSYS_WidgetType(Id);

                ViewWidgetType();
                break;
        }
    }
    protected void grvWidgetType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
        }
    }

    #region
    private void GetFile()
    {
        //strParentFolder = "Client/Admin/TVShow/WidgetType";
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
    #endregion

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvWidgetType.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int ID = Convert.ToInt32(row.Cells[0].Text);
            SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
            _widgetTypeBSO.SYS_WidgetTypeUpOrder(ID, cOrder);
        }

        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        ViewWidgetType();
        AspNetCache.Reset();
    }

}
