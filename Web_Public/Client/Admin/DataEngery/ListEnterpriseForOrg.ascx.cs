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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using ePower.DE.Service;
using ePower.DE.Domain;
public partial class Client_Admin_ListEnterpriseForOrg : System.Web.UI.UserControl
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            Tool.BindYear(ddlYear, "Tất cả", "");
            BindOrganization();
            BindArea();
            BindSubArea();
            BindData();
        }

    }
    void BindOrganization()
    {
        IList<Organization> list = new List<Organization>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Organization_All))
        {
            list = new OrganizationService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Organization_All, list);
        }
        else
            list = (IList<Organization>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Organization_All);
        ddlOrg.DataSource = list;
        ddlOrg.DataTextField = "Title";
        ddlOrg.DataValueField = "Id";
        ddlOrg.DataBind();
        ddlOrg.Items.Insert(0, new ListItem("---Tất cả---", ""));
    }
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
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
    #region ViewNewsGroup
    private void BindData()
    {
        EnterpriseService comBSO = new EnterpriseService();
        DataTable dt = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int OrgId = 0;
        int Year = 0;
        string strclientview = string.Empty;
        string strKey = string.Empty;
        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        if (ddlArea.SelectedIndex > 0)
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        if (ddlSubArea.SelectedIndex > 0)
            SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        dt = comBSO.GetDataTable(Year, AreaId, SubAreaId, OrgId, 0, 0, null, strKey, paging);
        if (dt != null && dt.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(dt.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(dt.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                strclientview = "Tổng số có " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                strclientview = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = true;
            }
        }
        else
        {
            strclientview = "";
            Paging.Visible = false;
        }
        grvNewsGroup.DataSource = dt;
        grvNewsGroup.DataBind();
        clientview.Text = strclientview;
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        int iId = 0;
        iId = Convert.ToInt32(btnDelete.CommandArgument);
        if (iId > 0)
        {           
            if (new EnterpriseService().Delete(iId) != null)
            {
                BindData();
            }
        }       
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }
    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/EditEnterpriseForOrg/Default.aspx");
    }
    protected void grvNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal ltImportant = (Literal)e.Row.FindControl("ltImportant");
            if (ltImportant != null)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (dr != null)
                {
                    int eID = Convert.ToInt32(dr["Id"]);
                    IList<EnterpriseYear> lstEnterpriseYear = new EnterpriseYearService().GetYearByEnterprise(eID);

                    if (lstEnterpriseYear != null && lstEnterpriseYear.Count > 0)
                    {
                        string strImportant = string.Empty;
                        foreach (EnterpriseYear en in lstEnterpriseYear)
                        {
                            if (strImportant != "")
                            {
                                strImportant += "<br/>" + en.Year + " (<b>" + en.No_TOE.ToString("#,####") + "</b>)";
                            }
                            else strImportant = en.Year + " (<b>" + en.No_TOE.ToString("#,####") + "</b>)";
                        }
                        ltImportant.Text = strImportant;
                    }
                    else
                    {
                        ltImportant.Text = "<span class='text-danger'>N/A</span>";
                    }
                }
            }
        }
    }
}
