using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using ePower.DE.Domain;
using ePower.DE.Service;
using System.Text;
using System.Configuration;
using log4net;
public partial class Client_Admin_EditEnterpriseForOrg : System.Web.UI.UserControl
{

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
                return 1000;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    int ItemId
    {
        get
        {
            if (ViewState["ItemId"] != null)
                return (int)ViewState["ItemId"];
            else
                return 0;
        }
        set { ViewState["ItemId"] = value; }
    }

    int OrgId
    {
        get
        {
            if (ViewState["OrgId"] != null)
                return (int)ViewState["OrgId"];
            else
                return 0;
        }
        set { ViewState["OrgId"] = value; }
    }
    int MemberId
    {
        get
        {
            if (ViewState["MemberId"] != null)
                return (int)ViewState["MemberId"];
            else
                return 0;
        }
        set { ViewState["MemberId"] = value; }
    }
    string ImportantYears
    {
        get
        {
            if (ViewState["ImportantYears"] != null && ViewState["ImportantYears"].ToString() != "")
                return ViewState["ImportantYears"].ToString();
            else
                return string.Empty;
        }
        set { ViewState["ImportantYears"] = value; }
    }
    protected int activeTab
    {
        get
        {
            if (ViewState["activeTab"] != null && ViewState["activeTab"].ToString() != "")
                return (int)ViewState["activeTab"];
            else
                return 0;
        }
        set { ViewState["activeTab"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out cId);
        ItemId = cId;

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            int activeId = 0;
            if (!string.IsNullOrEmpty(Request["activetab"]))
                int.TryParse(Request["activetab"].Replace(",", ""), out activeId);
            activeTab = activeId;
            cbxIsImportant.Text = "Đang là DN sử dụng năng lượng trọng điểm năm " + DateTime.Today.Year;
            BindOrganization();
            BindArea();
            BindSubArea();
            BindProvince();
            BindDistrict();
            BindDistrictReporter();
            if (ItemId > 0)
            {
                BindYear();
                rowTab.Visible = true;
                BindMember();
                BindTOEOld();
                BindTOECurrent();
                BindImportantYear();
                BindData();
            }
            else
            {
                rowTab.Visible = false;
            }
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
        ddlOrg.Items.Insert(0, new ListItem("---Chọn ---", ""));
    }


    void BindYear()
    {
        ddlImportantYear.Items.Clear();
        for (int startYear = DateTime.Today.Year; startYear >= 2010; startYear--)
        {
            ddlImportantYear.Items.Add(startYear.ToString());
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
            //var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.AreaName ascending, o.SortOrder ascending select o;
            var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.AreaName ascending select o;
            ddlArea.DataSource = listSearch;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Chọn---", ""));
        }
        else
        {
            ddlArea.DataSource = null;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Chọn---", ""));

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
            //var listSearch = from o in list where o.ParentId == ParentId orderby o.AreaName ascending, o.SortOrder ascending select o;
            var listSearch = from o in list where o.ParentId == ParentId orderby o.AreaName ascending select o;
            ddlSubArea.DataSource = listSearch;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn---", ""));
        }
        else
        {
            ddlSubArea.DataSource = null;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn---", ""));
        }
    }
    void BindProvince()
    {
        IList<Province> list = new List<Province>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
        {
            list = new ProvinceService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
        }
        else
            list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);
        var listSearch = from o in list orderby o.ProvinceName select o;
        ddlProvince.DataSource = listSearch;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "Id";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("---Chọn---", ""));

        ddlProvinceReporter.DataSource = listSearch;
        ddlProvinceReporter.DataTextField = "ProvinceName";
        ddlProvinceReporter.DataValueField = "Id";
        ddlProvinceReporter.DataBind();
        ddlProvinceReporter.Items.Insert(0, new ListItem("---Chọn---", ""));
    }
    void BindDistrictReporter()
    {
        ddlDistrictReporter.Items.Clear();
        IList<District> list = new List<District>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
        {
            list = new DistrictService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
        }
        else
            list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
        if (ddlProvinceReporter.SelectedIndex > 0)
        {
            var listSearch = from o in list where o.ProvinceId == Convert.ToInt32(ddlProvinceReporter.SelectedValue) orderby o.DistrictName ascending select o;
            ddlDistrictReporter.DataSource = listSearch;
            ddlDistrictReporter.DataTextField = "DistrictName";
            ddlDistrictReporter.DataValueField = "Id";
            ddlDistrictReporter.DataBind();
        }
        ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn---", ""));
    }
    void BindDistrict()
    {
        ddlDistrict.Items.Clear();
        IList<District> list = new List<District>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
        {
            list = new DistrictService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
        }
        else
            list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
        if (ddlProvince.SelectedIndex > 0)
        {
            var listSearch = from o in list where o.ProvinceId == Convert.ToInt32(ddlProvince.SelectedValue) orderby o.DistrictName ascending select o;
            ddlDistrict.DataSource = listSearch;
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();
        }
        ddlDistrict.Items.Insert(0, new ListItem("---Chọn---", ""));
    }
    private void BindData()
    {
        if (ItemId > 0)
        {
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj = objlogic.FindByKey(ItemId);
            if (obj != null)
            {
                txtTitle.Text = obj.Title;
                if (obj.OrganizationId > 0)
                {
                    ddlOrg.SelectedValue = obj.OrganizationId.ToString();
                }
                if (obj.AreaId > 0)
                {
                    ddlArea.SelectedValue = obj.AreaId.ToString();
                    BindSubArea();
                    if (obj.SubAreaId > 0)
                        ddlSubArea.SelectedValue = obj.SubAreaId.ToString();
                }
                if (obj.ProvinceId > 0)
                {
                    ddlProvince.SelectedValue = obj.ProvinceId.ToString();
                    BindDistrict();
                    if (obj.DistrictId > 0)
                        ddlDistrict.SelectedValue = obj.DistrictId.ToString();
                }
                txtMST.Text = obj.TaxCode;
                txtCustomerCode.Text = obj.CustomerCode;
                txtPhone.Text = obj.Phone;
                txtFax.Text = obj.Fax;
                txtEmail.Text = obj.Email;
                txtResponsible.Text = obj.ManPerson;
                txtAddress.Text = obj.Address;
                if (obj.OwnerId > 0)
                    ddlOwner.SelectedValue = obj.OwnerId.ToString();

                cbxActive.Checked = obj.IsActive;
                if (obj.ActiveYear > 0)
                    txtAtiveYear.Text = obj.ActiveYear.ToString();
                txtNote.Text = obj.Info;

                OrgId = obj.OrganizationId;
                txtParentName.Text = obj.ParentName;
                if (obj.ManProvinceId > 0)
                {
                    ddlProvinceReporter.SelectedValue = obj.ManProvinceId.ToString();
                    BindDistrictReporter();
                    if (obj.ManDistrictId > 0)
                    {
                        ddlDistrictReporter.SelectedValue = obj.ManDistrictId.ToString();
                    }
                }

                txtAddressReporter.Text = obj.ManAddress;
                txtPhoneReporter.Text = obj.ManPhone;
                txtFaxReporter.Text = obj.ManFax;
                txtManEmail.Text = obj.ManEmail;

            }
        }
        if (ImportantYears != "" && ImportantYears.Contains(DateTime.Today.ToString("yyyy")))
        {
            divImportantYear.Visible = false;
        }
        else divImportantYear.Visible = true;

    }
    void BindTOECurrent()
    {
        ltData.Text = "";
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

        //if (ddlOrg.SelectedIndex > 0)
        //    OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.FindList(false, AreaId, SubAreaId, ItemId, 0, 0, 0, 1, true, Year, null, null, "", paging);
        ltHeader.Text = "";
        foreach (GroupFuel group in listGroupFuel)
        {
            ltHeader.Text = ltHeader.Text + "<th>" + group.Title + " (" + group.MeasurementName + ")</th>";
        }
        if (list != null && list.Rows.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
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
                        DataTable listDetail = new ReportFuelDetailService().GetNoFuelDetailGroupByReport(ReportId, false);
                        int SumTOE = 0;
                        if (listDetail != null && listDetail.Rows.Count > 0)
                        {
                            foreach (GroupFuel group in listGroupFuel)
                            {
                                DataRow[] dr = listDetail.Select("GroupFuelId=" + group.Id);
                                if (dr != null && dr.Count() > 0)
                                {
                                    sb.Append("<td>" + dr[0]["NoFuel"]);
                                    SumTOE = SumTOE + Convert.ToInt32(dr[0]["NoFuel_TOE"]);
                                }
                                else
                                {
                                    sb.Append("<td>0</td>");
                                }

                            }
                            sb.Append("<td>" + SumTOE + "</td>");
                        }
                        else
                        {
                            for (int j = 0; j < listGroupFuel.Count; j++)
                            {
                                sb.Append("<td>0</td>");
                            }
                            sb.Append("<td>0</td>");
                        }

                    }
                    sb.Append("</tr>");
                }
            }
            ltData.Text = sb.ToString();
        }
    }
    void BindTOEOld()
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
        int iOrgId = 0;

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(100, 1);
        list = comBSO.GetReportTOETemp2014(AreaId, SubAreaId, iOrgId, ItemId, Year, "", paging);
        rptData.DataSource = list;
        rptData.DataBind();
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            ltNotice.Text = "Tổng số có " + paging.RowsCount + " báo cáo";
        }
        else
        {
            ltNotice.Text = "";
        }
    }
    void BindImportantYear()
    {
        if (ItemId > 0)
        {
            IList<EnterpriseYear> lstEnterpriseYear = new EnterpriseYearService().GetYearByEnterprise(ItemId);
            if (lstEnterpriseYear != null && lstEnterpriseYear.Count > 0)
            {
                ImportantYears = string.Empty;
                foreach (EnterpriseYear en in lstEnterpriseYear)
                {
                    if (en.IsKey == true)
                    {
                        if (ImportantYears != "")
                        {
                            ImportantYears += "; " + en.Year.ToString();
                        }
                        else ImportantYears = en.Year.ToString();
                    }
                }
                ltrTotalImportant.Text = "Tổng số có " + lstEnterpriseYear.Count.ToString() + " năm";
            }
            else
            {
                ltrTotalImportant.Text = "Chưa cập nhật dữ liệu";
            }
            rptImportantYear.DataSource = lstEnterpriseYear;
            rptImportantYear.DataBind();
            if (ImportantYears != "")
                ltrImportantInfo.Text = "<p>Là DN sử dụng năng lượng trọng điểm năm: " + ImportantYears + "</p>";
            else
                ltrImportantInfo.Text = "<p>Chưa cập nhật dữ liệu về sử dụng năng lượng trọng điểm</p>";

        }
        else
        {
            ltrTotalImportant.Text = "Chưa cập nhật dữ liệu";
            ltrImportantInfo.Text = "<p>Chưa cập nhật dữ liệu về sử dụng năng lượng trọng điểm</p>";
        }
    }

    protected void grvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn chắc chắn muốn xóa ?');");

        }
    }
    protected void grvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string aId = e.CommandArgument.ToString();
        string aName = e.CommandName.ToLower();

        switch (aName)
        {
            case "_edit":
                ePower.DE.Domain.Member adminEdit = new ePower.DE.Domain.Member();
                adminEdit = new MemberService().FindByKey(Convert.ToInt32(aId));
                if (adminEdit != null)
                {
                    hdnMemberId.Value = aId;
                    txtAdminName1.Text = adminEdit.AccountName;
                    txtAdminName.Enabled = false;
                    frmConfirmPass.Visible = false;
                    frmPass.Visible = false;
                    txtAdminFullName.Text = adminEdit.FullName;
                    txtAdminEmail.Text = adminEdit.Email;
                    cbxManActive.Checked = adminEdit.IsActive;
                    txtAdminAddress.Text = adminEdit.Address;
                    txtAdminPhone.Text = adminEdit.Phone;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatemember();", true);
                }
                break;
            case "_reset":
                ePower.DE.Domain.Member adminReset = new ePower.DE.Domain.Member();
                adminReset = new MemberService().FindByKey(Convert.ToInt32(aId));
                if (adminReset != null)
                {
                    hdnMemberId.Value = aId;
                    txtAdminName.Text = adminReset.AccountName;
                    txtAdminName.Enabled = false;
                    txtAdminFullName.Text = adminReset.FullName;
                    txtAdminEmail.Text = adminReset.Email;
                    cbxManActive.Checked = adminReset.IsActive;
                    txtAdminAddress.Text = adminReset.Address;
                    txtAdminPhone.Text = adminReset.Phone;
                    string spassdefault = "abc123";
                    spassdefault = ConfigurationManager.AppSettings["DefaultPassword"].ToString();
                    txtAdminPass.Text = spassdefault;
                    txtAdminConfirmPass.Text = spassdefault;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatePass();", true);
                }
                break;
            case "_delete":
                MemberService adminBSO = new MemberService();
                ePower.DE.Domain.Member admin = adminBSO.FindByKey(Convert.ToInt32(aId));
                admin.IsDelete = true;
                adminBSO.Update(admin);
                BindMember();
                break;
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
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        if (OrgId > 0)
        {
            Organization org = new OrganizationService().FindByKey(OrgId);
            if (org != null)
            {
                int noAccount = new EnterpriseService().GetNoAccount(OrgId);
                SecurityBSO securityBSO = new SecurityBSO();
                AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                Utils objUtil = new Utils();
                MemberService memberService = new MemberService();
                ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                member.EnterpriseId = ItemId;
                member.IsDelete = false;
                member.IsActive = true;
                member.AccountName = "dn." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToLower() + "." + (noAccount).ToString("000");
                string spassdefault = "abc123";
                spassdefault = ConfigurationManager.AppSettings["DefaultPassword"].ToString();
                member.Password = securityBSO.EncPwd(spassdefault);
                if (memberService.Insert(member) > 0)
                {
                    BindMember();
                }
                else
                    error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Tạo tài khoản không thành công !</div>";
            }
            else
                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Chưa cập nhật đơn vị quản lý !</div>";

        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj.Title = txtTitle.Text;
            if (ddlOrg.SelectedIndex > 0)
                obj.OrganizationId = Convert.ToInt32(ddlOrg.SelectedValue);
            if (ddlProvince.SelectedIndex > 0)
                obj.ProvinceId = Convert.ToInt32(ddlProvince.SelectedValue);
            if (ddlDistrict.SelectedIndex > 0)
                obj.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);

            if (ddlArea.SelectedIndex > 0)
                obj.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
            if (ddlSubArea.SelectedIndex > 0)
                obj.SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);

            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (txtMST.Text != "")
                obj.TaxCode = txtMST.Text.Trim();
            if (txtCustomerCode.Text != "")
                obj.CustomerCode = txtCustomerCode.Text.Trim();
            obj.Phone = txtPhone.Text;
            obj.Email = txtEmail.Text;
            obj.Fax = txtFax.Text;
            obj.ManPerson = txtResponsible.Text;
            obj.Address = txtAddress.Text;
            obj.OwnerId = Convert.ToInt32(ddlOwner.SelectedValue);

            obj.ParentName = txtParentName.Text;
            if (ddlProvinceReporter.SelectedIndex > 0)
                obj.ManProvinceId = Convert.ToInt32(ddlProvinceReporter.SelectedValue);
            if (ddlDistrictReporter.SelectedIndex > 0)
                obj.ManDistrictId = Convert.ToInt32(ddlDistrictReporter.SelectedValue);
            obj.ManAddress = txtAddressReporter.Text;
            obj.ManPhone = txtPhoneReporter.Text;
            obj.ManFax = txtFaxReporter.Text;
            obj.ManEmail = txtManEmail.Text;
            if (cbxActive.Checked)
                obj.IsActive = true;
            else obj.IsActive = false;
            try
            {
                if (txtAtiveYear.Text.Trim() != "")
                    obj.ActiveYear = Convert.ToInt32(txtAtiveYear.Text);
            }
            catch { }

            if (ItemId > 0)
            {
                obj.Id = ItemId;
                if (objlogic.Update(obj) != null)
                {
                    /*Cap nhat du lieu trong diem nam hien tai*/
                    if (ImportantYears != "" && !ImportantYears.Contains(DateTime.Today.ToString("yyyy")) && cbxIsImportant.Checked)
                    {
                        EnterpriseYear ey = new EnterpriseYear();
                        ey.EnterpriseId = ItemId;
                        ey.Year = DateTime.Today.Year;
                        ey.IsKey = true;
                        new EnterpriseYearService().Insert(ey);
                    }
                    BindImportantYear();
                    BindData();
                    error.Text = "<div class='alert alert-primary'>Cập nhật thành công !</div>";
                }
                else
                    error.Text = "<div class='alert alert-dangers'>Cập nhật không thành công !</div>";
            }
            else
            {
                ItemId = objlogic.Insert(obj);
                if (ItemId > 0)
                {
                    /*Tao tai khoan mac dinh*/
                    Organization org = new OrganizationService().FindByKey(obj.OrganizationId);
                    if (org != null)
                    {
                        int noAccount = new EnterpriseService().GetNoAccount(obj.OrganizationId);
                        SecurityBSO securityBSO = new SecurityBSO();
                        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                        Utils objUtil = new Utils();
                        MemberService memberService = new MemberService();
                        ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                        member.EnterpriseId = ItemId;
                        member.IsDelete = false;
                        member.IsActive = true;
                        member.AccountName = "DN." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToUpper() + "." + (noAccount).ToString("000");
                        string spassdefault = "abc123";
                        spassdefault = ConfigurationManager.AppSettings["DefaultPassword"].ToString();
                        member.Password = securityBSO.EncPwd(spassdefault);
                        if (memberService.Insert(member) > 0)
                        {
                            BindMember();
                        }
                        else
                            error.Text = "<div class='alert alert-dangers'>Tạo tài khoản không thành công !</div>";
                    }
                    /*Cap nhat du lieu trong diem nam hien tai*/
                    if (ImportantYears != "" && !ImportantYears.Contains(DateTime.Today.ToString("yyyy")) && cbxIsImportant.Checked)
                    {
                        EnterpriseYear ey = new EnterpriseYear();
                        ey.EnterpriseId = ItemId;
                        ey.Year = DateTime.Today.Year;
                        ey.IsKey = true;
                        new EnterpriseYearService().Insert(ey);
                    }
                    Response.Redirect(ResolveUrl("~") + "Admin/EditEnterpriseForOrg/" + ItemId.ToString() + "/Default.aspx");
                }
                else
                    error.Text = "<div class='alert alert-dangers'>Thêm mới không thành công !</div>";
            }
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }

    }
    void BindMember()
    {
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        UserValidation mem = new UserValidation();
        DataTable dt = new MemberService().FindList(0, ItemId, null, null, null, "", paging);
        grvAdmin.DataSource = dt;
        grvAdmin.DataBind();

        if (dt != null && dt.Rows.Count > 0)
        {
            btnAddMember.Visible = false;
            paging.RowsCount = Convert.ToInt32(dt.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(dt.Rows[0]["Total"]);
            Paging.DataLoad();
            if (Paging.TotalPages <= 1)
            {
                ltTotal.Text = "Tổng số " + paging.RowsCount + " tài khoản";
                Paging.Visible = false;
            }
            else
            {
                ltTotal.Text = "Tổng số " + paging.RowsCount + " tài khoản";
                Paging.Visible = true;
            }
        }
        else
        {
            btnAddMember.Visible = true;
            ltTotal.Text = "Có tổng số " + paging.RowsCount + " tài khoản";
            Paging.Visible = false;
        }
    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindMember();
    }
    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListEnterprise/Default.aspx");
    }

    protected void btn_edit_importantyear_Click(object sender, EventArgs e)
    {
        if (ItemId > 0)
        {
            LinkButton btn_edit_importantyear = (LinkButton)sender;
            int iEditId = 0;
            iEditId = Convert.ToInt32(btn_edit_importantyear.CommandArgument);
            if (iEditId > 0)
            {
                EnterpriseYear ey = new EnterpriseYear();
                ey = new EnterpriseYearService().FindByKey(iEditId);
                if (ey != null)
                {
                    hdnImportantYearEdit.Value = iEditId.ToString();
                    ddlImportantYear.SelectedValue = ey.Year.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "UpdateImportantYear();", true);
                }
            }
        }
    }


    protected void btn_delete_importantyear_Click(object sender, EventArgs e)
    {
        if (ItemId > 0)
        {
            LinkButton btn_delete_importantyear = (LinkButton)sender;
            int iDelteteId = 0;
            iDelteteId = Convert.ToInt32(btn_delete_importantyear.CommandArgument);
            if (iDelteteId > 0)
            {
                EnterpriseYear ey = new EnterpriseYear();
                ey = new EnterpriseYearService().FindByKey(iDelteteId);
                if (ey != null)
                {
                    ey.IsDelete = true;
                    if (new EnterpriseYearService().Update(ey) != null)
                    {
                        BindImportantYear();
                        BindData();
                        ltErrorImportantYear.Text = "<div class='alert alert-primary'>Xóa thành công !</div>";
                    }
                    else ltErrorImportantYear.Text = "<div class='alert alert-dangers'>Xóa không thành công !</div>";
                }
            }
        }
    }

    protected void btnAddImportantYear_Click(object sender, EventArgs e)
    {
        if (ItemId > 0)
        {
            if (hdnImportantYearEdit.Value != "0")
            {
                EnterpriseYear ey = new EnterpriseYear();
                ey = new EnterpriseYearService().FindByKey(Convert.ToInt32(hdnImportantYearEdit.Value));
                if (ey != null)
                {
                    if (ImportantYears != "" && !ImportantYears.Contains(ddlImportantYear.SelectedValue))
                    {
                        if (txtNoTOE.Text.Trim() != "")
                            ey.No_TOE = Convert.ToDecimal(txtNoTOE.Text.Trim());
                        ey.IsKey = (rblKeu.SelectedIndex == 0);
                        ey.Year = Convert.ToInt32(ddlImportantYear.SelectedValue);
                        if (new EnterpriseYearService().Update(ey) != null)
                        {
                            BindImportantYear();
                            BindData();
                            ltErrorImportantYear.Text = "<div class='alert alert-primary'>Cập nhật thành công !</div>";
                        }
                        else ltErrorImportantYear.Text = "<div class='alert alert-dangers'>Cập nhật không thành công !</div>";
                    }
                }
            }
            else
            {
                EnterpriseYear ey = new EnterpriseYear();
                if (ImportantYears != "" && !ImportantYears.Contains(ddlImportantYear.SelectedValue))
                {
                    ey.EnterpriseId = ItemId;
                    ey.Year = Convert.ToInt32(ddlImportantYear.SelectedValue);
                    ey.IsKey = true;
                    ey.IsDelete = false;
                    if (new EnterpriseYearService().Insert(ey) > 0)
                    {
                        BindImportantYear();
                        BindData();
                        ltErrorImportantYear.Text = "<div class='alert alert-primary'>Thêm mới thành công !</div>";
                    }
                    else ltErrorImportantYear.Text = "<div class='alert alert-dangers'>Thêm mới không thành công !</div>";
                }
            }
            hdnImportantYearEdit.Value = "0";
        }
    }

    protected void btnUpdateAccount_Click(object sender, EventArgs e)
    {
        ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
        member.AccountName = txtAdminName.Text.Trim();
        member.Password = new SecurityBSO().EncPwd(txtAdminPass.Text.Trim());
        member.IsDelete = false;
        member.EnterpriseId = ItemId;
        if (MemberId > 0)
        {
            member.Id = MemberId;
            if (new MemberService().Update(member) != null)
                error.Text = "<div class='alert alert-primary'>Cập nhật thành công !</div>";
            else
                error.Text = "<div class='alert alert-dangers'>Cập nhật không thành công !</div>";
        }
        else
        {
            if (new MemberService().Insert(member) > 0)
                error.Text = "<div class='alert alert-primary'>Thêm mới thành công !</div>";
            else
                error.Text = "<div class='alert alert-dangers'>Thêm mới không thành công !</div>";
        }
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrict();
    }

    protected void ddlProvinceReporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrictReporter();
    }

    protected void btnSavePass_Click(object sender, EventArgs e)
    {
        ltErrorMember.Text = "";
        if (hdnMemberId.Value != "" && Convert.ToInt32(hdnMemberId.Value) > 0)
        {
            ePower.DE.Domain.Member admin = new ePower.DE.Domain.Member();
            try
            {
                SecurityBSO securityBSO = new SecurityBSO();
                MemberService adminBSO = new MemberService();
                admin = adminBSO.FindByKey(Convert.ToInt32(hdnMemberId.Value));
                if (admin != null)
                {
                    if (txtAdminPass.Text != "")
                        admin.Password = securityBSO.EncPwd(txtAdminPass.Text.Trim());
                    if (adminBSO.Update(admin) != null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showform", "alert('Reset mật khẩu DN thành công');", true);
                    }
                    else
                    {
                        ltErrorMember.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Reset mật khẩu DN không thành công !</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatePass();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }

    }
    protected void btnSaveAccount_Click(object sender, EventArgs e)
    {
        ltErrorMember.Text = "";
        if (hdnMemberId.Value != "" && Convert.ToInt32(hdnMemberId.Value) > 0)
        {
            ePower.DE.Domain.Member admin = new ePower.DE.Domain.Member();
            try
            {
                SecurityBSO securityBSO = new SecurityBSO();
                MemberService adminBSO = new MemberService();
                admin = adminBSO.FindByKey(Convert.ToInt32(hdnMemberId.Value));
                admin.Email = txtAdminEmail.Text.Trim();
                admin.IsActive = cbxManActive.Checked;
                admin.FullName = txtAdminFullName.Text.Trim();
                admin.Address = txtAdminAddress.Text.Trim();
                admin.Phone = txtAdminPhone.Text.Trim();
                admin.EnterpriseId = ItemId;

                if (adminBSO.Update(admin) != null)
                {
                    BindMember();
                    ltErrorMember.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
                }
                else
                {
                    ltErrorMember.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không thành công !</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatemember();", true);
                }

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            MemberService adminBSO = new MemberService();
            SecurityBSO securityBSO = new SecurityBSO();
            ePower.DE.Domain.Member admin = new ePower.DE.Domain.Member();

            admin.Password = securityBSO.EncPwd(txtAdminPass1.Text);
            admin.AccountName = txtAdminName1.Text.Trim();
            admin.Email = txtAdminEmail.Text.Trim();
            admin.IsActive = cbxManActive.Checked;
            admin.FullName = txtAdminFullName.Text.Trim();
            admin.Address = txtAdminAddress.Text.Trim();
            admin.Phone = txtAdminPhone.Text.Trim();
            admin.EnterpriseId = ItemId;
            if (adminBSO.ExistAccount(admin.AccountName))
            {
                ltErrorMember.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Tài khoản đã được đăng ký. Vui lòng nhập tên tài khoản khác !</div>";
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatemember();", true);
            }
            else
                if (adminBSO.ExistEmail(admin.Email))
                {
                    ltErrorMember.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Địa chỉ Email đã được đăng ký. Vui lòng nhập Email tài khoản khác !</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatemember();", true);
                }
                else
                {
                    int id = adminBSO.Insert(admin);
                    if (id > 0)
                    {
                        ltErrorMember.Text = "";
                        BindMember();
                    }
                    else
                    {
                        ltErrorMember.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Tạo mới tài khoản không thành công !</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatemember();", true);
                    }

                }
        }
    }
}