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
using System.Data.OleDb;


public partial class Client_Admin_DataEnergy_ReportByTOE : System.Web.UI.UserControl
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
            BindOrganization();
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
        int OrgId = 0;
        if (ddlArea.SelectedIndex > 0)
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        if (ddlSubArea.SelectedIndex > 0)
            SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.GetReportTOETemp2014(AreaId, SubAreaId, OrgId, 0, Year, txtKeyword.Text.Trim(), paging);
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
                ltNotice.Text = "Có tổng số " + paging.RowsCount + " báo cáo";
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
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();
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
    protected void btnImport_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", Server.MapPath("~/UserFile/Data_2016.xls"));
        //string query = String.Format("select * from [{0}$]", "Area");
        string query = String.Format("select * from [{0}$]", "2014_2015");

        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        DataTable myTable = dataSet.Tables[0];
        EnterpriseService comBSO = new EnterpriseService();
        foreach (DataRow drow in myTable.Rows)
        {
            ReportTemp2014 temp = new ReportTemp2014();
            temp.Title = drow["Title"].ToString();
            if (temp.Title != null && temp.Title != "")
            {
                temp.OrgId = Convert.ToInt32(drow["OrgId"]);
                DataTable dtE = comBSO.GetDNByName(temp.Title, temp.OrgId);
                if (drow["Address"] != null)
                {
                    temp.Address = drow["Address"].ToString();
                }

                if (drow["AreaName"] != null && drow["AreaName"].ToString() != "")
                {
                    temp.AreaName = drow["AreaName"].ToString();
                    if (drow["AreaName"].ToString() == "Công nghiệp")
                        temp.AreaId = 5;
                    else
                        if (drow["AreaName"].ToString() == "Nông nghiệp")
                            temp.AreaId = 3;
                        else
                            if (drow["AreaName"].ToString() == "Công trình xây dựng")
                                temp.AreaId = 6;
                            else
                                temp.AreaId = 1;
                }
                //Kiem phan nganh da co trong CSDL chua
                if (drow["SubAreaName"] != null && drow["SubAreaName"].ToString() != "")
                {
                    DataTable dtSub = new AreaService().getAreaByName(drow["SubAreaName"].ToString());
                    if (dtSub != null && dtSub.Rows.Count > 0)
                    {
                        temp.SubAreaId = Convert.ToInt32(dtSub.Rows[0]["Id"]);
                    }
                    else
                    {//Neu khong ton tai thi bo sung them phan nganh
                        Area sub = new Area();
                        sub.AreaName = drow["SubAreaName"].ToString();
                        sub.ParentId = temp.AreaId;
                        sub.IsStatus = 1;
                        sub.SortOrder = 0;
                        int subId = new AreaService().Insert(sub);
                        temp.SubAreaId = subId;
                    }
                    temp.SubAreaName = drow["SubAreaName"].ToString();
                }
                //Kiem tra xem doanh nghiep da ton tai
                if (dtE != null && dtE.Rows.Count > 0)
                {
                    if (dtE.Rows.Count == 1)
                    {
                        Enterprise area = new Enterprise();
                        int eId = Convert.ToInt32(dtE.Rows[0]["Id"]);
                        ////area = new EnterpriseService().FindByKey(eId);
                        ////area.SubAreaId = temp.SubAreaId;
                        ////area.AreaId = temp.AreaId;

                        EnterpriseYearService eYService = new EnterpriseYearService();
                        EnterpriseYear ey = new EnterpriseYear();
                        ey.EnterpriseId = eId;
                        if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "")
                        {
                            ey.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                        }
                        ey.IsDelete = false;
                        ey.Year = 2016;
                        eYService.Insert(ey);//Insert vao doanh nghiep trong diem nam
                        temp.EnterpriseId = eId;
                        if (drow["Dien_kWh"] != null && drow["Dien_kWh"].ToString().Trim() != "")
                            temp.Dien_kWh = drow["Dien_kWh"].ToString();

                        if (drow["Than_Tan"] != null && drow["Than_Tan"].ToString().Trim() != "")
                            temp.Than_Tan = drow["Than_Tan"].ToString();

                        if (drow["DO_Tan"] != null && drow["DO_Tan"].ToString().Trim() != "")
                            temp.DO_Tan = drow["DO_Tan"].ToString();
                        if (drow["DO_lit"] != null && drow["DO_lit"].ToString().Trim() != "")
                            temp.DO_lit = drow["DO_lit"].ToString();

                        if (drow["FO_Tan"] != null && drow["FO_Tan"].ToString().Trim() != "")
                            temp.FO_Tan = drow["FO_Tan"].ToString();
                        if (drow["FO_lit"] != null && drow["FO_lit"].ToString().Trim() != "")
                            temp.FO_lit = drow["FO_Tan"].ToString();

                        if (drow["Xang_Tan"] != null && drow["Xang_Tan"].ToString().Trim() != "")
                            temp.Xang_Tan = drow["Xang_Tan"].ToString();
                        if (drow["Xang_lit"] != null && drow["Xang_lit"].ToString().Trim() != "")
                            temp.Xang_lit = drow["Xang_lit"].ToString();

                        if (drow["Gas_Tan"] != null && drow["Gas_Tan"].ToString().Trim() != "")
                            temp.Gas_Tan = drow["Gas_Tan"].ToString();

                        if (drow["Khi_m3"] != null && drow["Khi_m3"].ToString().Trim() != "")
                            temp.Khi_M3 = drow["Khi_m3"].ToString();

                        if (drow["LPG_Tan"] != null && drow["LPG_Tan"].ToString().Trim() != "")
                            temp.LPG_Tan = drow["LPG_Tan"].ToString();
                        if (drow["NLPL_Tan"] != null && drow["NLPL_Tan"].ToString().Trim() != "")
                            temp.NLPL_Tan = drow["NLPL_Tan"].ToString();

                        if (drow["Khac_tan"] != null && drow["Khac_tan"].ToString().Trim() != "")
                            temp.KhacSoDo = drow["Khac_tan"].ToString();
                        if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                        {
                            temp.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                        }
                        temp.Year = 2016;                       
                        int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                    }
                    else
                    {
                        if (drow["Dien_kWh"] != null && drow["Dien_kWh"].ToString().Trim() != "")
                            temp.Dien_kWh = drow["Dien_kWh"].ToString();

                        if (drow["Than_Tan"] != null && drow["Than_Tan"].ToString().Trim() != "")
                            temp.Than_Tan = drow["Than_Tan"].ToString();

                        if (drow["DO_Tan"] != null && drow["DO_Tan"].ToString().Trim() != "")
                            temp.DO_Tan = drow["DO_Tan"].ToString();
                        if (drow["DO_lit"] != null && drow["DO_lit"].ToString().Trim() != "")
                            temp.DO_lit = drow["DO_lit"].ToString();

                        if (drow["FO_Tan"] != null && drow["FO_Tan"].ToString().Trim() != "")
                            temp.FO_Tan = drow["FO_Tan"].ToString();
                        if (drow["FO_lit"] != null && drow["FO_lit"].ToString().Trim() != "")
                            temp.FO_lit = drow["FO_Tan"].ToString();

                        if (drow["Xang_Tan"] != null && drow["Xang_Tan"].ToString().Trim() != "")
                            temp.Xang_Tan = drow["Xang_Tan"].ToString();
                        if (drow["Xang_lit"] != null && drow["Xang_lit"].ToString().Trim() != "")
                            temp.Xang_lit = drow["Xang_lit"].ToString();

                        if (drow["Gas_Tan"] != null && drow["Gas_Tan"].ToString().Trim() != "")
                            temp.Gas_Tan = drow["Gas_Tan"].ToString();

                        if (drow["Khi_m3"] != null && drow["Khi_m3"].ToString().Trim() != "")
                            temp.Khi_M3 = drow["Khi_m3"].ToString();

                        if (drow["LPG_Tan"] != null && drow["LPG_Tan"].ToString().Trim() != "")
                            temp.LPG_Tan = drow["LPG_Tan"].ToString();
                        if (drow["NLPL_Tan"] != null && drow["NLPL_Tan"].ToString().Trim() != "")
                            temp.NLPL_Tan = drow["NLPL_Tan"].ToString();

                        if (drow["Khac_tan"] != null && drow["Khac_tan"].ToString().Trim() != "")
                            temp.KhacSoDo = drow["Khac_tan"].ToString();
                        if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                        {
                            temp.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                        }
                        temp.Year = 2016;
                        if (dtE.Rows.Count > 1)
                        {
                            temp.Note = "Tim thay " + dtE.Rows.Count + " DN";
                        }

                        else
                            temp.Note = "Khong tim thay " + dtE.Rows.Count + " DN";
                        int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                    }
                }
                else
                {
                    if (drow["Dien_kWh"] != null && drow["Dien_kWh"].ToString().Trim() != "")
                        temp.Dien_kWh = drow["Dien_kWh"].ToString();

                    if (drow["Than_Tan"] != null && drow["Than_Tan"].ToString().Trim() != "")
                        temp.Than_Tan = drow["Than_Tan"].ToString();

                    if (drow["DO_Tan"] != null && drow["DO_Tan"].ToString().Trim() != "")
                        temp.DO_Tan = drow["DO_Tan"].ToString();
                    if (drow["DO_lit"] != null && drow["DO_lit"].ToString().Trim() != "")
                        temp.DO_lit = drow["DO_lit"].ToString();

                    if (drow["FO_Tan"] != null && drow["FO_Tan"].ToString().Trim() != "")
                        temp.FO_Tan = drow["FO_Tan"].ToString();
                    if (drow["FO_lit"] != null && drow["FO_lit"].ToString().Trim() != "")
                        temp.FO_lit = drow["FO_Tan"].ToString();

                    if (drow["Xang_Tan"] != null && drow["Xang_Tan"].ToString().Trim() != "")
                        temp.Xang_Tan = drow["Xang_Tan"].ToString();
                    if (drow["Xang_lit"] != null && drow["Xang_lit"].ToString().Trim() != "")
                        temp.Xang_lit = drow["Xang_lit"].ToString();

                    if (drow["Gas_Tan"] != null && drow["Gas_Tan"].ToString().Trim() != "")
                        temp.Gas_Tan = drow["Gas_Tan"].ToString();

                    if (drow["Khi_m3"] != null && drow["Khi_m3"].ToString().Trim() != "")
                        temp.Khi_M3 = drow["Khi_m3"].ToString();

                    if (drow["LPG_Tan"] != null && drow["LPG_Tan"].ToString().Trim() != "")
                        temp.LPG_Tan = drow["LPG_Tan"].ToString();
                    if (drow["NLPL_Tan"] != null && drow["NLPL_Tan"].ToString().Trim() != "")
                        temp.NLPL_Tan = drow["NLPL_Tan"].ToString();

                    if (drow["Khac_tan"] != null && drow["Khac_tan"].ToString().Trim() != "")
                        temp.KhacSoDo = drow["Khac_tan"].ToString();
                    if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                    {
                        temp.No_TOE = Convert.ToDecimal(drow["No_TOE"]);                        
                    }
                    temp.Year = 2016;
                    temp.Note = "Khong tim thay " + dtE.Rows.Count + " DN";
                    int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                }

            }
        }
    }
}
