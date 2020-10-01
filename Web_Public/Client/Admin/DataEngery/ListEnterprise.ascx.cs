using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data.OleDb;

public partial class Client_Admin_ListOrganization : System.Web.UI.UserControl
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
            BindArea();
            BindDistrict();
            BindData();
        }
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
    void BindDistrict()
    {
        ddlDistrict.Items.Clear();
        if (m_UserValidation.OrgId > 0)
        {
            Organization org = new OrganizationService().FindByKey(m_UserValidation.OrgId);
            if (org != null)
            {
                IList<District> list = new List<District>();
                if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
                {
                    list = new DistrictService().FindAll();
                    AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
                }
                else
                    list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
                var listSearch = from o in list where o.ProvinceId == org.ProvinceId orderby o.DistrictName ascending select o;
                ddlDistrict.DataSource = listSearch;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("---Tất cả---", ""));
            }
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
        //BindSubArea();
    }
    #region View Data
    private void BindData()
    {
        EnterpriseService comBSO = new EnterpriseService();
        DataTable dt = new DataTable();
        int AreaId = 0;
        int DistrictId = 0;
        int OrgId = 0;
        int Year = 0;
        string strclientview = string.Empty;
        string strKey = string.Empty;

        if (ddlArea.SelectedIndex > 0)
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        if (ddlDistrict.SelectedIndex > 0)
            DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (m_UserValidation.OrgId > 0)
        {
            OrgId = m_UserValidation.OrgId;
            dt = comBSO.GetDataTable(Year, AreaId, DistrictId, OrgId, 0, DistrictId, null, strKey, paging);
        }
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
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj.IsDelete = true;
            if (objlogic.Update(obj) != null)
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
        Response.Redirect("~/Admin/EditEnterprise/Default.aspx");
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
                }
            }
        }
    }
    protected void btnImportTemp_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", Server.MapPath("~/UserFile/Data_2016.xls"));
        //string query = String.Format("select * from [{0}$]", "Area");
        string query = String.Format("select * from [{0}$]", "Nam_2016");
        SecurityBSO securityBSO = new SecurityBSO();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        DataTable myTable = dataSet.Tables[0];
        EnterpriseService comBSO = new EnterpriseService();
        foreach (DataRow drow in myTable.Rows)
        {
            ReportTemp2014 temp = new ReportTemp2014();
            Enterprise area = new Enterprise();
            area.Title = drow["Title"].ToString();
            temp.Title = area.Title;
            if (drow["Address"] != null)
            {
                area.Address = drow["Address"].ToString();
                temp.Address = area.Address;
            }

            area.OrganizationId = Convert.ToInt32(drow["OrgId"]);
            temp.OrgId = area.OrganizationId;
            Organization org = new OrganizationService().FindByKey(area.OrganizationId);

            if (drow["AreaName"] != null && drow["AreaName"].ToString() != "")
            {
                temp.AreaName = drow["AreaName"].ToString();
                if (drow["AreaName"].ToString() == "Công nghiệp")
                    area.AreaId = 5;
                else
                    if (drow["AreaName"].ToString() == "Nông nghiệp")
                        area.AreaId = 3;
                    else
                        if (drow["AreaName"].ToString() == "Công trình xây dựng")
                            area.AreaId = 6;
                        else
                            area.AreaId = 1;
                temp.AreaId = area.AreaId;
            }
            if (drow["SubAreaName"] != null && drow["SubAreaName"].ToString() != "")
            {
                DataTable dtSub = new AreaService().getAreaByName(drow["SubAreaName"].ToString());
                if (dtSub != null && dtSub.Rows.Count > 0)
                {
                    area.SubAreaId = Convert.ToInt32(dtSub.Rows[0]["Id"]);
                    temp.SubAreaId = area.SubAreaId;
                }
                else
                {
                    Area sub = new Area();
                    sub.AreaName = drow["SubAreaName"].ToString();
                    sub.ParentId = area.AreaId;
                    sub.IsStatus = 1;
                    sub.SortOrder = 0;
                    int subId = new AreaService().Insert(sub);
                    temp.SubAreaId = subId;
                    area.SubAreaId = subId;
                }
                area.Info = drow["SubAreaName"].ToString();
                temp.SubAreaName = drow["SubAreaName"].ToString();
            }

            area.ProvinceId = Convert.ToInt32(drow["ProvinceId"]);
            area.ManProvinceId = Convert.ToInt32(drow["ManProvinceId"]);
            int eId = comBSO.Insert(area);//Them doanh  nghiep

            if (eId > 0)
            {
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

                if (drow["Note"] != null && drow["Note"].ToString().Trim() != "")
                    temp.Note = drow["Note"].ToString();


                EnterpriseYearService eYService = new EnterpriseYearService();
                EnterpriseYear ey = new EnterpriseYear();
                ey.EnterpriseId = eId;

                if (drow["No_TOE"] != null && drow["No_TOE"].ToString().Trim() != "" && Convert.ToDecimal(drow["No_TOE"]) > 0)
                {
                    ey.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                    temp.No_TOE = ey.No_TOE;
                    temp.Year = 2016;
                    int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                    ey.IsDelete = false;
                    ey.Year = temp.Year;
                    eYService.Insert(ey);//Them nam bao cao
                }
                //Tao tai khoan doanh nghiep

                Utils objUtil = new Utils();
                MemberService memberService = new MemberService();
                int STT = 0;

                STT = new EnterpriseService().GetNoAccount(area.OrganizationId);

                STT++;
                ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                member.EnterpriseId = eId;
                member.IsDelete = false;
                member.AccountName = "dn." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToLower() + "." + STT.ToString("000");
                member.Password = securityBSO.EncPwd("123456");
                memberService.Insert(member);

            }

        }
    }
}
