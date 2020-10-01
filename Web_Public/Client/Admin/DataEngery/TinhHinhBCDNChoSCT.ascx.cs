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
using System.Text;
public partial class Client_Admin_TinhHinhBCDNChoSCT : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);
    protected int TongChuaDuyet
    {
        get
        {
            if (ViewState["TongChuaDuyet"] != null)
                return Convert.ToInt32(ViewState["TongChuaDuyet"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TongChuaDuyet"] = value;
        }
    }
    protected int TongDaGui
    {
        get
        {
            if (ViewState["TongDaGui"] != null)
                return Convert.ToInt32(ViewState["TongDaGui"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TongDaGui"] = value;
        }
    }
    protected int TongDaDuyet
    {
        get
        {
            if (ViewState["TongDaDuyet"] != null)
                return Convert.ToInt32(ViewState["TongDaDuyet"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TongDaDuyet"] = value;
        }
    }
    protected int TongChuaBC
    {
        get
        {
            if (ViewState["TongChuaBC"] != null)
                return Convert.ToInt32(ViewState["TongChuaBC"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TongChuaBC"] = value;
        }
    }

    protected int TongDN
    {
        get
        {
            if (ViewState["TongDN"] != null)
                return Convert.ToInt32(ViewState["TongDN"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TongDN"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            Tool.BindYear(ddlYear, "Chọn năm", "");
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


    #region ViewNewsGroup
    private void BindData()
    {
        OrganizationService comBSO = new OrganizationService();
        IList<Organization> list = new List<Organization>();
        list = comBSO.FindAll();
        if (list != null && list.Count() > 0)
        {
            var listSearch = from o in list where o.IsDelete == false orderby o.SortOrder ascending, o.Title ascending select o;
            rptData.DataSource = listSearch;
            rptData.DataBind();
        }
        else
        {
            rptData.DataSource = null;
            rptData.DataBind();
        }
    }
    #endregion


    public void Paging_Click(object sender, CommandEventArgs e)
    {



    }

    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/EditDEOrganization/Default.aspx");
    }
    protected void grvNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        TongChuaBC = 0;
        TongChuaDuyet = 0;
        TongDaDuyet = 0;
        TongChuaBC = 0;
        TongDN = 0;
        BindData();
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Organization org = (Organization)e.Item.DataItem;
            Literal ltSent = (Literal)e.Item.FindControl("ltSent");
            Literal ltNoWait = (Literal)e.Item.FindControl("ltNoWait");
            Literal ltNoApproved = (Literal)e.Item.FindControl("ltNoApproved");
            Literal ltNoBussines = (Literal)e.Item.FindControl("ltNoBussines");
            Literal ltNoUnReport = (Literal)e.Item.FindControl("ltNoUnReport");
            ltSent.Text = "0";
            ltNoWait.Text = "0";
            ltNoApproved.Text = "0";
            ltNoUnReport.Text = "0";
            ltNoBussines.Text = "0";
            DataSet dset = new DataSet();
            int IsKey = -1;
            if (rblKey.SelectedIndex > 0)
            {
                if (rblKey.SelectedIndex == 1)
                    IsKey = 1;
                else
                    IsKey = 0;

            }
            int iYear=0;
            if (ddlYear.SelectedIndex > 0)
                iYear = Convert.ToInt32(ddlYear.SelectedValue);
            dset = new ReportService().CountReport(IsKey, iYear, org.Id);
            int tongdagui = 0;
            int tongchuaduyet = 0;
            int tongdaduyet = 0;
            int tongchua = 0;
            int dagui = 0;
            int tong = 0;
            if (dset != null && dset.Tables.Count > 0)
            {
                if (dset.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                    {
                        int iSatus = Convert.ToInt32(dset.Tables[0].Rows[i]["SendSatus"]);

                        if (iSatus >= 5)
                        {
                            ltNoApproved.Text = dset.Tables[0].Rows[i]["NoReport"].ToString();
                            tongdaduyet += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                            dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                        }
                        else
                        {
                            if (iSatus >= 2 && iSatus < 5)
                            {
                                ltNoWait.Text = dset.Tables[0].Rows[i]["NoReport"].ToString();
                                tongchuaduyet += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                                dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                            }
                            else
                            {
                                dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                            }
                        }
                        ltSent.Text = dagui.ToString();
                        tongdagui += dagui;
                    }
                }
                tong = Convert.ToInt32(dset.Tables[1].Rows[0]["NoBussiness"]);

                tongchua = tong - dagui;
                ltNoBussines.Text = dset.Tables[1].Rows[0]["NoBussiness"].ToString();
                ltNoUnReport.Text = tongchua.ToString();
            }
            TongDN += tong;
            TongDaDuyet += tongdaduyet;
            TongChuaDuyet += tongchuaduyet;
            TongChuaBC += tongchua;
            TongDaGui += tongdagui;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/force-download";
        Response.AddHeader("content-disposition", "attachment; filename=Tong-hop-tinh-hinh-bao-cao-" + ddlYear.SelectedValue + ".xls");
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

        StringBuilder sb = new StringBuilder();
        sb.Append("<table class='table table-bordered table-hover mbn' width='100%'>");
        sb.Append("<tr class='primary fs12'>");
        sb.Append("<th>#");
        sb.Append("</th>");
        sb.Append("<th>Sở công thương</th>");
        sb.Append("<th>Điện thoại</th>");
        sb.Append("<th>Email</th>");
        sb.Append("<th>Đã gửi</th>");
        sb.Append("<th>Đang duyệt</th>");
        sb.Append("<th>Đã duyệt</th>");
        sb.Append("<th>Chưa gửi</th>");
        sb.Append("<th>Tổng số</th>");
        sb.Append("</tr>");
        OrganizationService comBSO = new OrganizationService();
        IList<Organization> list = new List<Organization>();
        list = comBSO.FindAll();
        if (list != null && list.Count() > 0)
        {
            var listSearch = from o in list where o.IsDelete == false orderby o.SortOrder ascending, o.Title ascending select o;
            rptData.DataSource = listSearch;
            rptData.DataBind(); int t = 0;
            foreach (Organization org in listSearch)
            {
                t++;
                sb.Append("<tr>");
                sb.Append("<td>" + t + "</td>");
                sb.Append("<td>" + org.Title + "</td>");
                sb.Append("<td>" + org.Phone + "</td>");
                sb.Append("<td>" + org.Email + "</td>");
                DataSet dset = new DataSet();
                int IsKey = -1;
                if (rblKey.SelectedIndex > 0)
                {
                    if (rblKey.SelectedIndex == 1)
                        IsKey = 1;
                    else
                        IsKey = 0;
                }
                dset = new ReportService().CountReport(IsKey, Convert.ToInt32(ddlYear.SelectedValue), org.Id);
                int tongdagui = 0;
                int tongchuaduyet = 0;
                int tongdaduyet = 0;
                int tongchua = 0;
                int dagui = 0;
                int tong = 0;
                if (dset != null && dset.Tables.Count > 0)
                {
                    if (dset.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                        {
                            int iSatus = Convert.ToInt32(dset.Tables[0].Rows[i]["SendSatus"]);

                            if (iSatus >= 5)
                            {
                                tongdaduyet += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                                dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                            }
                            else
                            {
                                if (iSatus >= 2 && iSatus < 5)
                                {
                                    tongchuaduyet += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                                    dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                                }
                                else
                                {
                                    dagui += Convert.ToInt32(dset.Tables[0].Rows[i]["NoReport"]);
                                }
                            }
                            tongdagui += dagui;
                        }
                    }
                    tong = Convert.ToInt32(dset.Tables[1].Rows[0]["NoBussiness"]);

                    tongchua = tong - dagui;
                    sb.Append("<td>" + dagui + "</td>");
                    sb.Append("<td>" + tongchuaduyet + "</td>");
                    sb.Append("<td>" + tongdaduyet + "</td>");
                    sb.Append("<td>" + tongchua + "</td>");
                    sb.Append("<td>" + tong + "</td>");
                }
                TongDN += tong;
                TongDaDuyet += tongdaduyet;
                TongChuaDuyet += tongchuaduyet;
                TongChuaBC += tongchua;
                TongDaGui += tongdagui;
                sb.Append("</tr>");
            }
        }
        sb.Append("</table>");

        Response.Write(sb.ToString());
        Response.Write("</body></html>");
        Response.End();
    }
}
