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


public partial class Client_Admin_DataEnergy_ListReportFuelForOrg : System.Web.UI.UserControl
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
            //BindSubArea();
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
    /*void BindSubArea()
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
    }*/
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
    private void BindData()
    {
        ltData.Text = "";
        //IList<GroupFuel> listGroupFuel = new List<GroupFuel>();
        //if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
        //{
        //    listGroupFuel = new GroupFuelService().FindAll();
        //    AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, listGroupFuel);
        //}
        //else
        //    listGroupFuel = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);
        IList<Fuel> listFuel = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            listFuel = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, listFuel);
        }
        else
            listFuel = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        int OrgId = 0;
        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.FindList(false, AreaId, SubAreaId, OrgId, 0, 0, 0, -1, true, Year, null, null, txtKeyword.Text.Trim(), paging);
        ltHeader.Text = "";
        //foreach (GroupFuel group in listGroupFuel)
        //{
        //    ltHeader.Text = ltHeader.Text + "<th>" + group.Title + " (" + group.MeasurementName + ")</th>";
        //}
        foreach (Fuel group in listFuel)
        {
            ltHeader.Text = ltHeader.Text + "<th>" + group.FuelName + "</th>";
        }
        if (list != null && list.Rows.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                sb.Append("<tr><td class='text-center'>" + (i + 1) + "</td>");
                sb.Append("<td>" + list.Rows[i]["Title"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["Address"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["ProvinceName"] + "</td>");
                //sb.Append("<td></td>");//Vung
                //sb.Append("<td>" + list.Rows[i]["RegionName"] + "</td>");//Vung
                sb.Append("<td>" + list.Rows[i]["ParentAreaName"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["AreaName"] + "</td>");
                //sb.Append("<td></td>");
                if (list.Rows[i]["Id"] != null && list.Rows[i]["Id"].ToString() != "")
                {
                    int ReportId = Convert.ToInt32(list.Rows[i]["Id"]);
                    if (ReportId > 0)
                    {
                        DataTable listDetail = new ReportFuelDetailService().GetFuelTOEByReport(ReportId, false);
                        if (listDetail != null && listDetail.Rows.Count > 0)
                        {
                            int SumTOE = 0;
                            foreach (Fuel group in listFuel)
                            {
                                DataRow[] dr = listDetail.Select("FuelId=" + group.Id);
                                if (dr != null && dr.Count() > 0)
                                {
                                    sb.Append("<td>");

                                    for (int j = 0; j < dr.Count(); j++)
                                    {
                                        if (dr[j]["NoFuel_TOE"] != DBNull.Value)
                                        {
                                            SumTOE = SumTOE + Convert.ToInt32(dr[j]["NoFuel_TOE"]);
                                            sb.Append(Tool.ConvertDecimalToString(dr[j]["NoFuel"], 2) + " (" + dr[j]["MeasurementName"] + ")");
                                        }
                                        else
                                            sb.Append("-");
                                    }
                                    sb.Append("</td>");
                                }
                                else
                                {
                                    sb.Append("<td>-</td>");
                                }
                            }
                            sb.Append("<td>" + SumTOE + "</td>");
                        }
                        else
                        {
                            for (int j = 0; j < listFuel.Count; j++)
                            {
                                sb.Append("<td>-</td>");
                            }
                            sb.Append("<td>-</td>");
                        }
                    }
                    sb.Append("</tr>");
                }
            }
            ltData.Text = sb.ToString();
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
                ltNotice.Text = "Có " + list.Rows.Count + " trong tổng số " + paging.RowsCount + " báo cáo";
                Paging.Visible = true;
            }
        }
        else
        {
            ltNotice.Text = "";
            Paging.Visible = false;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/force-download";
        Response.AddHeader("content-disposition", "attachment; filename=Bao-cao-sct-" + ddlYear.SelectedValue + ".xls");
        Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
        Response.Write("<head>");
        Response.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
        Response.Write("<!--[if gte mso 9]><xml>");
        Response.Write("<x:ExcelWorkbook>");
        Response.Write("<x:ExcelWorksheets>");
        Response.Write("<x:ExcelWorksheet>");
        Response.Write("<x:Name>Report Data</x:Name>");
        Response.Write("<x:WorksheetOptions>");
        Response.Write("<x:Print>");
        Response.Write("<x:ValidPrinterInfo/>");
        Response.Write("</x:Print>");
        Response.Write("</x:WorksheetOptions>");
        Response.Write("</x:ExcelWorksheet>");
        Response.Write("</x:ExcelWorksheets>");
        Response.Write("</x:ExcelWorkbook>");
        Response.Write("</xml>");
        Response.Write("<![endif]--> ");
        Response.Write("</head><body>");
        //IList<GroupFuel> listGroupFuel = new List<GroupFuel>();
        //if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
        //{
        //    listGroupFuel = new GroupFuelService().FindAll();
        //    AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, listGroupFuel);
        //}
        //else
        //    listGroupFuel = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);
        IList<Fuel> listFuel = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            listFuel = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, listFuel);
        }
        else
            listFuel = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        int OrgId = 0;
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(3000, CurrentPage);
        list = comBSO.FindList(false, AreaId, SubAreaId, OrgId, 0, 0, 0, -1, true, Year, null, null, txtKeyword.Text.Trim(), paging);
        string strHeader = "";

        foreach (Fuel group in listFuel)
        {
            strHeader = strHeader + "<th>" + group.FuelName + "</th>";
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<table class='table table-bordered table-hover mbn' width='100%'>");
        sb.Append("<tr class='primary fs12'>");
        sb.Append("<th style='width:5%'>STT</th>");
        sb.Append("<th style='width:35%'>Tên doanh nghiệp</th>");
        sb.Append("<th style='width:10%'>Địa chỉ</th>");
        sb.Append("<th style='width:10%'>Tỉnh/TP</th>");
        sb.Append("<th style='width:10%'>Vùng</th>");
        sb.Append("<th style='width:10%'>Lĩnh vực SX</th>");
        sb.Append("<th style='width:10%'>Ngành nghề SX,KD</th>");
        sb.Append(strHeader);
        sb.Append("<th style='width:10%'>Năng lượng tiêu thụ quy đổi (TOE)</th>");
        sb.Append("</tr>");

        if (list != null && list.Rows.Count > 0)
        {
            for (int i = 0; i < list.Rows.Count; i++)
            {
                sb.Append("<tr><td>" + (i + 1) + "</td>");
                sb.Append("<td>" + list.Rows[i]["Title"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["Address"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["ProvinceName"] + "</td>");
                sb.Append("<td></td>");//Vung
                //sb.Append("<td>" + list.Rows[i]["RegionName"] + "</td>");//Vung
                sb.Append("<td>" + list.Rows[i]["ParentAreaName"] + "</td>");
                sb.Append("<td>" + list.Rows[i]["AreaName"] + "</td>");              
                if (list.Rows[i]["Id"] != null && list.Rows[i]["Id"].ToString() != "")
                {
                    int ReportId = Convert.ToInt32(list.Rows[i]["Id"]);
                    if (ReportId > 0)
                    {
                        DataTable listDetail = new ReportFuelDetailService().GetFuelTOEByReport(ReportId, false);
                        int SumTOE = 0;
                        if (listDetail != null && listDetail.Rows.Count > 0)
                        {
                            /*
                            foreach (Fuel group in listFuel)
                            {
                                DataRow[] dr = listDetail.Select("FuelId=" + group.Id);
                                if (dr != null && dr.Count() > 0)
                                {
                                    sb.Append("<td>");
                                    for (int j = 0; j < dr.Count(); j++)
                                    {
                                        sb.Append(Tool.ConvertDecimalToString(dr[j]["NoFuel"], 2) + " (" + dr[j]["MeasurementName"] + ")");
                                    }
                                    sb.Append("</td>");
                                }
                                else
                                {
                                    sb.Append("<td>0</td>");
                                }

                            }
                            sb.Append("<td>" + SumTOE + "</td>");

                            */

                            foreach (Fuel group in listFuel)
                            {
                                DataRow[] dr = listDetail.Select("FuelId=" + group.Id);
                                if (dr != null && dr.Count() > 0)
                                {
                                    sb.Append("<td>");

                                    for (int j = 0; j < dr.Count(); j++)
                                    {
                                        if (dr[j]["NoFuel_TOE"] != DBNull.Value)
                                        {
                                            SumTOE = SumTOE + Convert.ToInt32(dr[j]["NoFuel_TOE"]);
                                            sb.Append(Tool.ConvertDecimalToString(dr[j]["NoFuel"], 2) + " (" + dr[j]["MeasurementName"] + ")");
                                        }
                                    }
                                    sb.Append("</td>");
                                }
                                else
                                {
                                    sb.Append("<td>-</td>");
                                }
                            }
                            sb.Append("<td>" + SumTOE + "</td>");
                        }
                        else
                        {
                            for (int j = 0; j < listFuel.Count; j++)
                            {
                                sb.Append("<td>-</td>");
                            }
                            sb.Append("<td>-</td>");
                        }

                    }
                    sb.Append("</tr>");
                }
            }
        }
        sb.Append("</table>");

        Response.Write(sb.ToString());
        Response.Write("</body></html>");
        Response.End();
    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();

    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindSubArea();
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
