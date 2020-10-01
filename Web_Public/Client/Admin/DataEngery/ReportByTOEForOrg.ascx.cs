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
using System.Collections.Generic;
using System.Text;
using ETO;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;


public partial class Client_Admin_DataEnergy_ReportByTOEForOrg : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null)
                return Convert.ToInt32(ViewState["PageSize"].ToString());
            else
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"].ToString() != "")
                return (int)ViewState["ReportId"];
            else
                return 0;
        }
        set { ViewState["ReportId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        ReportId = Id;
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            Tool.BindYear(ddlYear, "Tất cả", "");
            BindArea();
            BindSubArea();
            //BindProvince();
            //BindDistrict();
            //BindEnterprise();          
            BindData();
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
    void BindArea()
    {
        IList<Area> list = new List<Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.SortOrder ascending select o;
            ddlArea.DataSource = listSearch;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
        }
        else
        {
            ddlArea.DataSource = null;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Tất cả---", ""));

        }
    }
    void BindSubArea()
    {
        ddlSubArea.Items.Clear();
        IList<Area> list = new List<Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        if (list != null && list.Count > 0)
        {
            if (ddlArea.SelectedIndex > 0)
            {
                int ParentId = Convert.ToInt32(ddlArea.SelectedValue);
                var listSearch = from o in list where o.ParentId == ParentId orderby o.AreaName, o.SortOrder ascending select o;
                ddlSubArea.DataSource = listSearch;
                ddlSubArea.DataTextField = "AreaName";
                ddlSubArea.DataValueField = "Id";
                ddlSubArea.DataBind();
                ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
            }
            else
            {
                var listSearch = from o in list where o.ParentId != null && o.ParentId > 0 orderby o.AreaName ascending, o.SortOrder ascending select o;
                ddlSubArea.DataSource = listSearch;
                ddlSubArea.DataTextField = "AreaName";
                ddlSubArea.DataValueField = "Id";
                ddlSubArea.DataBind();
                ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
            }
        }
        else
        {
            ddlSubArea.DataSource = null;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
        }
    }
    private void BindData()
    {
        IList<GroupFuel> listGroupFuel = new List<GroupFuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
        {
            listGroupFuel = new GroupFuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, listGroupFuel);
        }
        else
            listGroupFuel = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);

        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        //if (ddlYear.SelectedIndex > 0)
        //    AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        //if (ddlSubArea.SelectedIndex > 0)
        //    SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        int OrgId = 0;

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.GetReportTOETemp2014(AreaId, SubAreaId, m_UserValidation.OrgId, 0, Year, txtKeyword.Text.Trim(), paging);
        rptData.DataSource = list;
        rptData.DataBind();
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltNotice.Text = "Có tổng số " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltNotice.Text = "Hiển thị từ " + st + " - " + end + " trong tổng số " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = true;
            }
        }
        else
        {
            ltNotice.Text = "";
            Paging.Visible = false;
        }
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();

    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListReportForProvince/Default.aspx");

    }
    protected void btn_new_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editReportFuel/Default.aspx");

    }

    protected void rptNoFuelFuture_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",true); return false;");

        }
    }
}
