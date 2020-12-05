using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using ReportEF;
using System.Data.SqlClient;

public partial class Client_Modules_DataEnergy_UpdateInfo : System.Web.UI.UserControl
{
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReportTemplate();
            BindArea();
            BindProvince();
            BindDistrict();
            BindDistrictReporter();
            if (memVal.IsSigned())
            {
                BindData();
                BindImportantYear();
            }
        }
    }

    void BindReportTemplate()
    {
        ReportModels rp = new ReportModels();
        var list = rp.DE_BaocaoLinhVuc.Where(x => x.PhanLoaiBC == ReportKey.PLAN).ToList();
        ddlReportTemplate.DataValueField = "AutoId";
        ddlReportTemplate.DataTextField = "TenMauBC";
        ddlReportTemplate.DataSource = list;
        ddlReportTemplate.DataBind();
    }

    void BindArea()
    {
        //IList<Area> list = new List<Area>();
        //if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        //{
        //    list = new AreaService().FindAll();
        //    AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        //}
        //else
        //    list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        //if (list != null && list.Count > 0)
        //{
        //    var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.SortOrder ascending select o;
        //    ddlArea.DataSource = listSearch;
        //    ddlArea.DataTextField = "AreaName";
        //    ddlArea.DataValueField = "Id";
        //    ddlArea.DataBind();
        //    ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));
        //}
        //else
        //{
        //    ddlArea.DataSource = null;
        //    ddlArea.DataTextField = "AreaName";
        //    ddlArea.DataValueField = "Id";
        //    ddlArea.DataBind();
        //    ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));

        //}

        ReportModels rp = new ReportModels();
        //var linhvuc = rp.DE_MainArea.ToList();
        var list = rp.DE_Area.Where(x => x.ParentId == 0).ToList();
        ddlArea.DataSource = list;
        ddlArea.DataTextField = "AreaName";
        ddlArea.DataValueField = "Id";
        ddlArea.DataBind();
        ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));
    }
    void BindSubArea()
    {
        if (ddlArea.SelectedValue == "")
            return;
        ddlSubArea.Items.Clear();
        int pId = Convert.ToInt32(ddlArea.SelectedValue);
        if (pId > 0)
        {
            ReportModels rp = new ReportModels();
            List<DE_Area> listArea = getListSubArea(pId);
            ddlSubArea.DataSource = listArea;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("Chọn Phân ngành", ""));
        }

        //ddlSubArea.Items.Clear();
        //IList<Area> list = new List<Area>();
        //if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        //{
        //    list = new AreaService().FindAll();
        //    AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        //}
        //else
        //    list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);

        //if (list != null && list.Count > 0 && ddlArea.SelectedIndex > 0)
        //{
        //    int ParentId = Convert.ToInt32(ddlArea.SelectedValue);
        //    var listSearch = from o in list where o.ParentId == ParentId orderby o.AreaName ascending select o;
        //    ddlSubArea.DataSource = listSearch;
        //    ddlSubArea.DataTextField = "AreaName";
        //    ddlSubArea.DataValueField = "Id";
        //    ddlSubArea.DataBind();
        //    ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
        //}
        //else
        //{
        //    ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
        //}
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

        ddlProvinceReporter.DataSource = list;
        ddlProvinceReporter.DataTextField = "ProvinceName";
        ddlProvinceReporter.DataValueField = "Id";
        ddlProvinceReporter.DataBind();
        ddlProvinceReporter.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));

        ddlProvince.DataSource = list;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "Id";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));

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
            ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
        else
        {
            ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
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
            ddlDistrict.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
        else
        {
            ddlDistrict.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrict();
    }
    protected void ddlProvinceReporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrictReporter();
    }

    void BindImportantYear()
    {
        if (memVal.OrgId > 0)
        {
            IList<EnterpriseYear> lstEnterpriseYear = new EnterpriseYearService().GetYearByEnterprise(memVal.OrgId);
            if (lstEnterpriseYear != null && lstEnterpriseYear.Count > 0)
            {
                ltrTotalImportant.Text = "Tổng số có " + lstEnterpriseYear.Count.ToString() + " năm";
            }
            else
            {
                ltrTotalImportant.Text = "Chưa có dữ liệu";
            }
            rptImportantYear.DataSource = lstEnterpriseYear;
            rptImportantYear.DataBind();
        }
        else
        {
            ltrTotalImportant.Text = "Chưa cập nhật dữ liệu";
        }
    }

    private void BindData()
    {
        if (memVal.UserId > 0 && memVal.OrgId > 0)
        {
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj = objlogic.FindByKey(Convert.ToInt32(memVal.OrgId));
            if (obj != null)
            {
                txtTitle.Text = obj.Title;
                try
                {
                    if (obj.ProvinceId > 0)
                    {
                        ddlProvince.SelectedValue = obj.ProvinceId.ToString();
                        BindDistrict();
                        if (obj.DistrictId > 0)
                            ddlDistrict.SelectedValue = obj.DistrictId.ToString();
                    }
                }
                catch { }
                if (obj.AreaId > 0)
                {
                    ddlArea.SelectedValue = obj.AreaId.ToString();
                    BindSubArea();
                    if (obj.SubAreaId > 0)
                        ddlSubArea.SelectedValue = obj.SubAreaId.ToString();
                }
                if (obj.ReportTemplate != null && obj.ReportTemplate > 0)
                    ddlReportTemplate.SelectedValue = obj.ReportTemplate.ToString();

                txtMST.Text = obj.TaxCode;
                txtCustomerCode.Text = obj.CustomerCode;
                txtPhone.Text = obj.Phone;
                txtFax.Text = obj.Fax;
                txtEmail.Text = obj.Email;
                txtResponsible.Text = obj.ManPerson;
                txtAddress.Text = obj.Address;
                if (obj.OwnerId > 0)
                    ddlOwner.SelectedValue = obj.OwnerId.ToString();
                txtNote.Text = obj.Info;

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
                if (obj.ActiveYear > 0)
                    txtActiveYear.Text = obj.ActiveYear.ToString();
                txtAddressReporter.Text = obj.ManAddress;
                txtPhoneReporter.Text = obj.ManPhone;
                txtFaxReporter.Text = obj.ManFax;
                txtManEmail.Text = obj.ManEmail;

                int _MoHinhQLNL = obj.MoHinhQLNL;
                switch (_MoHinhQLNL)
                {
                    case 0:
                        cbMoHinhQLNL_ChuaAD.Checked = true;
                        break;
                    case 1:
                        cbMoHinhQLNL_DaAD.Checked = true;
                        break;
                    case 2:
                        cbMoHinhQLNL_DaAD_ISO.Checked = true;
                        break;
                }

                ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                member = new MemberService().FindByKey(memVal.UserId);
                if (member != null)
                {
                    ltrAdminName.Text = member.AccountName;
                    txtAdminName.Text = member.AccountName;
                    txtAdminEmail.Text = member.Email;
                    txtAddressMember.Text = member.Address;
                    txtFullName.Text = member.FullName;
                    txtPhoneMember.Text = member.Phone;
                }

            }
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj = objlogic.FindByKey(memVal.OrgId);
            if (obj != null)
            {
                if (ddlProvince.SelectedIndex > 0)
                    obj.ProvinceId = Convert.ToInt32(ddlProvince.SelectedValue);
                if (ddlDistrict.SelectedIndex > 0)
                    obj.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);

                if (ddlArea.SelectedIndex > 0)
                    obj.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
                else
                    obj.AreaId = 0;
                if (ddlSubArea.SelectedIndex > 0)
                    obj.SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
                else
                    obj.SubAreaId = 0;

                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

                obj.TaxCode = txtMST.Text.Trim();

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
                else
                    obj.ManProvinceId = 0;
                if (ddlDistrictReporter.SelectedIndex > 0)
                    obj.ManDistrictId = Convert.ToInt32(ddlDistrictReporter.SelectedValue);
                else
                    obj.ManDistrictId = 0;
                obj.ManAddress = txtAddressReporter.Text;
                obj.ManPhone = txtPhoneReporter.Text;
                obj.ManFax = txtFaxReporter.Text;
                obj.ManEmail = txtManEmail.Text;
                if (txtActiveYear.Text.Trim() != "")
                    obj.ActiveYear = Convert.ToInt32(txtActiveYear.Text.Trim());

                int _MoHinhQLNL = 0;
                if (cbMoHinhQLNL_DaAD.Checked)
                    _MoHinhQLNL = 1;
                if (cbMoHinhQLNL_DaAD_ISO.Checked)
                    _MoHinhQLNL = 2;

                obj.MoHinhQLNL = _MoHinhQLNL;
                int tmpMoHinhQLNL = obj.MoHinhQLNL;
                obj.ReportTemplate = Convert.ToInt32(ddlReportTemplate.SelectedValue);

                if (memVal.OrgId > 0)
                {
                    if (objlogic.Update(obj) != null)
                    {
                        try
                        {
                            /*Cap nhat lich su*/
                            EnterpriseHistory objHist = new EnterpriseHistory();
                            objHist.Address = obj.Address;
                            objHist.AreaId = obj.AreaId;
                            objHist.DistrictId = obj.DistrictId;
                            objHist.Email = obj.Email;
                            objHist.Fax = obj.Fax;
                            objHist.Id = obj.Id;
                            objHist.Info = obj.Info;
                            objHist.IsActive = obj.IsActive;
                            objHist.IsConfirm = obj.IsConfirm;
                            objHist.IsDelete = obj.IsDelete;
                            objHist.IsImportant = obj.IsImportant;
                            objHist.ManAddress = obj.ManAddress;
                            objHist.ManDistrictId = obj.ManDistrictId;
                            objHist.ManEmail = obj.ManEmail;
                            objHist.ManFax = obj.ManFax;
                            objHist.ManPerson = obj.ManPerson;
                            objHist.ManPhone = obj.ManPhone;
                            objHist.ManProvinceId = obj.ManProvinceId;
                            objHist.MST = obj.TaxCode;
                            objHist.OrganizationId = obj.OrganizationId;
                            objHist.ParentName = obj.ParentName;
                            objHist.Phone = obj.Phone;
                            objHist.ProvinceId = obj.ProvinceId;
                            objHist.ShortName = obj.ShortName;
                            objHist.SubAreaId = obj.SubAreaId;
                            objHist.Title = obj.Title;
                            objHist.MoHinhQLNL = tmpMoHinhQLNL;

                            new EnterpriseHistoryService().Insert(objHist);
                        }
                        catch { }
                        error.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
                    }
                    else
                        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không thành công !</div>";
                }
            }

        }
        catch (Exception ex)
        {

            error.Text = ex.Message.ToString();
        }
    }

    protected void btnUpdateInfo_Click(object sender, EventArgs e)
    {
        ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
        member = new MemberService().FindByKey(memVal.UserId);
        ltInfoErr.Text = "";
        if (member != null)
        {
            member.Address = txtAddressMember.Text.Trim();
            member.Phone = txtPhoneMember.Text.Trim();
            member.FullName = txtFullName.Text.Trim();
            member.Email = txtAdminEmail.Text.Trim();
            //member.EnterpriseId = Convert.ToInt32(memVal.OrgId);
            if (new MemberService().Update(member) != null)
            {
                ltInfoErr.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
            }
            else
            {
                ltInfoErr.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không thành công !</div>";
            }
        }
    }

    protected void btnUpdateAccount_Click(object sender, EventArgs e)
    {
        if (memVal != null && memVal.UserName != null && memVal.UserName != "")
        {
            if (new MemberService().ChangePass(new SecurityBSO().EncPwd(txtAdminPass.Text.Trim()), new SecurityBSO().EncPwd(txtOldPass.Text.Trim()), memVal.UserName) > 0)
                ltErrPass.Text = "<div class='alert alert-sm alert-success bg-gradient'>Đổi mật khẩu thành công!</div>";
            else
                ltErrPass.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Đổi mật khẩu không thành công. Vui lòng thử lại!</div>";

        }

    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }

    private List<DE_Area> getListSubArea(int pId)
    {
        ReportModels rp = new ReportModels();
        string sp = "de_area_get_by_parentId @Parent";
        var result = rp.DE_Area.SqlQuery(sp, new SqlParameter("@Parent", pId)).ToList<DE_Area>();
        return result;
    }
}