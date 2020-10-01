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
public partial class Client_Admin_TinhHinhBaoCaoDNChoSCT : System.Web.UI.UserControl
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
        ddlOrg.Items.Insert(0, new ListItem("---Chọn sở---", ""));
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
            ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));
        }
        else
        {
            ddlArea.DataSource = null;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));

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
        if (list != null && list.Count > 0 && ddlArea.SelectedIndex > 0)
        {
            int ParentId = Convert.ToInt32(ddlArea.SelectedValue);
            var listSearch = from o in list where o.ParentId == ParentId orderby o.SortOrder ascending select o;
            ddlSubArea.DataSource = listSearch;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
        }
        else
        {
            ddlSubArea.DataSource = null;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
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
        IList<Enterprise> list = new List<Enterprise>();
        int AreaId = 0;
        int SubAreaId = 0;
        int OrgId = 0;

        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.FindList(0, AreaId, SubAreaId, OrgId, 0, 0, null, txtKeyword.Text.Trim(), paging);
        if (list != null && list.Count() > 0)
        {
            paging.RowsCount = list[0].Total;
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = list[0].Total;
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                clientview.Text = "Có tổng số " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = false;
            }
            else
            {
                clientview.Text = "Có " + list.Count() + " trong tổng số " + paging.RowsCount + " doanh nghiệp";
                Paging.Visible = true;
            }
        }
        else
        {
            clientview.Text = "";
            Paging.Visible = false;
        }
        grvNewsGroup.DataSource = list;

        grvNewsGroup.DataBind();

    }
    #endregion


    protected void btnCreateMember_Click(object sender, EventArgs e)
    {
        EnterpriseService enterpriseService = new EnterpriseService();

        OrganizationService comBSO = new OrganizationService();
        IList<Organization> listOrg = new List<Organization>();
        listOrg = comBSO.FindAll();
        SecurityBSO securityBSO = new SecurityBSO();
        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
        AdminBSO adminBSO = new AdminBSO();
        Utils objUtil = new Utils();
        MemberService memberService = new MemberService();

        foreach (Organization org in listOrg)
        {
            int STT = 0;
            IList<Enterprise> list = enterpriseService.FindList(0, 0, 0, org.Id, 0, 0, null, "", new ePower.Core.PagingInfo(1000, 1));
            foreach (Enterprise enter in list)
            {
                STT++;
                ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                member.EnterpriseId = enter.Id;
                member.IsDelete = false;
                member.AccountName = "DN." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToUpper() + "." + (STT).ToString("000");
                member.Password = securityBSO.EncPwd("123456");
                memberService.Insert(member);
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        //new OrganizationBSO().Delete(Convert.ToInt32(btnDelete.CommandArgument));
        Enterprise org = new EnterpriseService().FindByKey(Convert.ToInt32(btnDelete.CommandArgument));
        if (org != null)
        {
            org.IsDelete = true;
            if (new EnterpriseService().Update(org) != null)
            {
                BindData();
            }
        }

    }
    protected void btn_Order_Click(object sender, EventArgs e)
    {


    }
    protected void btn_slug_click(object sender, EventArgs e)
    {


    }

    protected void btn_img_click(object sender, EventArgs e)
    {


    }

    protected void btn_img1_click(object sender, EventArgs e)
    {

    }
    protected void btn_img2_click(object sender, EventArgs e)
    {


    }
    protected void btn_down_click(object sender, EventArgs e)
    {


    }

    protected void btn_down_thumb_click(object sender, EventArgs e)
    {


    }

    protected void btn_html_click(object sender, EventArgs e)
    {


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
        Response.Redirect("~/Admin/EditEnterprise/Default.aspx");
    }

}
