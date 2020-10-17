using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;
using System.Data;
using ReportEF;

public partial class Client_Module_DataEngery_DetailPlanYear : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    MemberValidation memVal = new MemberValidation();
    public int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"] != "")
                return Convert.ToInt32(ViewState["ReportId"]);
            else
                return 0;
        }
        set { ViewState["ReportId"] = value; }
    }
    public int ReportYear
    {
        get
        {
            if (ViewState["ReportYear"] != null && ViewState["ReportYear"] != "")
                return Convert.ToInt32(ViewState["ReportYear"]);
            else
                return 0;
        }
        set { ViewState["ReportYear"] = value; }
    }
    public bool AllowEdit
    {
        get
        {
            if (ViewState["AllowEdit"] != null && ViewState["AllowEdit"] != "")
                return Convert.ToBoolean(ViewState["AllowEdit"]);
            else
                return false;
        }
        set { ViewState["AllowEdit"] = value; }
    }
    int PlanId
    {
        get
        {
            if (ViewState["PlanId"] != null && ViewState["PlanId"] != "")
                return Convert.ToInt32(ViewState["PlanId"]);
            else
                return 0;
        }
        set { ViewState["PlanId"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            BindMeasurement();
            ReportId = Id;
            BindFuel();
            BindSolution();
            BindData();
            BindPlanTKNL();
            BindThietBi();
            BindResultTB();
            BindResultTKNL();
            BindUsingEnerySystem();
        }
    }
    void BindMeasurement()
    {
        ddlMeasure.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuelType.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuelType.SelectedValue));
        }

        ddlMeasure.DataSource = list;
        ddlMeasure.DataValueField = "Id";
        ddlMeasure.DataTextField = "MeasurementName";
        ddlMeasure.DataBind();
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
        if (ddlMeasure.Items.Count == 2)
        {
            ddlMeasure.SelectedIndex = 1;
        }
    }
    void BindMeasurement2()
    {
        ddlMeasure2.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuelType2.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuelType2.SelectedValue));
        }

        ddlMeasure2.DataSource = list;
        ddlMeasure2.DataValueField = "Id";
        ddlMeasure2.DataTextField = "MeasurementName";
        ddlMeasure2.DataBind();
        ddlMeasure2.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
        if (ddlMeasure2.Items.Count == 2)
        {
            ddlMeasure2.SelectedIndex = 1;
        }
    }



    protected void BindUsingEnerySystem()
    {
        ReportModels reportModels = new ReportModels();
        var res = reportModels.DE_UsingSystem.Where(o => o.SysState == 0).ToList();

        ddlUseSysName.DataValueField = "SysCode";
        ddlUseSysName.DataTextField = "SysName";
        ddlUseSysName.DataSource = res;
        ddlUseSysName.DataBind();


        ddlUseSysNamePlan.DataValueField = "SysCode";
        ddlUseSysNamePlan.DataTextField = "SysName";
        ddlUseSysNamePlan.DataSource = res;
        ddlUseSysNamePlan.DataBind();
    }

    void BindData()
    {
        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        ltOldYear.Text = ("I. Kết quả thực hiện năm " + (ReportYear - 1).ToString()).ToUpper();
        ltNextYear.Text = ("II. Kế hoạch thực hiện năm " + ReportYear.ToString()).ToUpper();
        //}
        btnAddDevice.Visible = btnAddPlan.Visible = btnAddPlanDeviceNext.Visible = btnAddPlanNext.Visible = btnAddSolution.Visible = btnAddSolution2.Visible = AllowEdit; ;

    }
    void BindFuel()
    {
        ddlFuelType.Items.Clear();
        IList<Fuel> list = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            list = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, list);
        }
        else
            list = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        int GroupId = 0;
        if (ddlFuelType.SelectedIndex > 0)
            GroupId = Convert.ToInt32(ddlFuelType.SelectedValue);

        var listSearch = from o in list where o.GroupFuelId == GroupId || GroupId == 0 select o;
        ddlFuelType.DataSource = listSearch;
        ddlFuelType.DataValueField = "Id";
        ddlFuelType.DataTextField = "FuelName";
        ddlFuelType.DataBind();
        ddlFuelType.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

        ddlFuelType2.DataSource = listSearch;
        ddlFuelType2.DataValueField = "Id";
        ddlFuelType2.DataTextField = "FuelName";
        ddlFuelType2.DataBind();
        ddlFuelType2.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

    }
    void BindSolution()
    {
        ddlSolution2.Items.Clear();
        ddlSolution.Items.Clear();
        GiaiPhapService gps = new GiaiPhapService();
        DataTable lst = gps.GetGiaiPhepByEnerprise(memVal.OrgId);
        ddlSolution.DataSource = lst;
        ddlSolution.DataBind();
        ddlSolution.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));

        ddlSolution2.DataSource = lst;
        ddlSolution2.DataBind();
        ddlSolution2.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));
    }
    void BindThietBi()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, false, true);
        rptKHBoSungTB.DataSource = tbl;
        rptKHBoSungTB.DataBind();
    }

    private void BindPlanTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, false, true);
        rptSolutionPlan.DataSource = tbl;
        rptSolutionPlan.DataBind();
    }

    protected void rptPlanTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            rptbso.Delete(int.Parse(btnDelete.CommandArgument));
            BindPlanTKNL();
        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            rpt = rptbso.FindByKey(int.Parse(btnEdit.CommandArgument));
            txtmuctieuTKNL.Text = rpt.MucTieuGP;
            txtchiphidukienTKNL.Text = rpt.ChiPhiDuKien;
            if (rpt.IdGiaPhap > 0)
                ddlSolution.SelectedValue = rpt.IdGiaPhap.ToString();
            try
            {
                ddlCamKet.SelectedValue = rpt.MucCamKet;
            }
            catch { }
            if (rpt.LoaiNhienLieu > 0)
            {
                ddlFuelType.SelectedValue = rpt.LoaiNhienLieu.ToString();
                BindMeasurement();
            }
            if (rpt.MeasurementId > 0)
                ddlMeasure.SelectedValue = rpt.MeasurementId.ToString();
            txtGhiChu.Text = rpt.GhiChu;
            txtLoiIchKhac.Text = rpt.LoiIchKhac;
            txtThanhTien.Text = rpt.ThanhTien;
            txtTuongDuong.Text = rpt.TuongDuong;

            txtKhaNangTKNL.Text = rpt.KhaNangThucHien;

            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "ShowDialogSolutionPlanOne(" + hddkhtknl.Value + ");", true);
        }
    }

    protected void rptKHBoSungTB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindThietBi();

        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));

            if (rpt.CachLapDat != "")
            {
                try
                {
                    ddlCacThucLD.SelectedValue = rpt.CachLapDat;
                }
                catch { }
            }
            txtlydoTB.Text = rpt.LyDo;
            txtTenTB.Text = rpt.NameTB;
            try
            {
                ddlCamKetTB.SelectedValue = rpt.CamKet;
            }
            catch { }
            txtKhaNangTB.Text = rpt.KhaNang;
            txtTinhNangTB.Text = rpt.TinhNang;
            hddkhTB.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogDevicePlanOne(" + hddkhTB.Value + ");", true);
        }
    }

    protected void rptResultTB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindResultTB();

        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (rpt.CachLapDat != "")
            {
                try
                {
                    ddlCacThucLDBS.SelectedValue = rpt.CachLapDat;
                }
                catch { }
            }

            txtMoTaTinhNangBS.Text = rpt.TinhNang;
            txtTenTietBiBS.Text = rpt.NameTB;
            txtLyDoKhongThucHien.Text = rpt.LyDo;
            if (rpt.IsExecuted)
                rblThucHien.SelectedIndex = 0;
            else
                rblThucHien.SelectedIndex = 1;
            if (rpt.IsNew)
                rblIsNew.SelectedIndex = 1;
            else
                rblIsNew.SelectedIndex = 0;

            txtLyDoKhongThucHien.Text = rpt.LyDoLapDat;

            txtLyDoKhongThucHien.Text = rpt.LyDoLapDat;

            hddkhTB.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogDeviceResultOne(" + hddkhTB.Value + ");", true);
        }
    }
    protected void rptResultTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindPlanTKNL();
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            hddkhtknl.Value = rpt.Id.ToString();
            txtMucDichGPTT.Text = rpt.MucTieuGP;
            txtMucTietKiemNLTT.Text = rpt.MucTKThucTe;
            if (rpt.IdGiaPhap > 0)
                ddlSolution2.SelectedValue = rpt.IdGiaPhap.ToString();
            txtTKCPThucTe.Text = rpt.MucTKCPThucTe;
            txtChiPhiThucTe.Text = rpt.CPThucTe;
            txtGhiChuTT.Text = rpt.GhiChuTT;
            txtTuongDuongTT.Text = rpt.TuongDuongTT;
            if (!string.IsNullOrEmpty(rpt.HeThongSuDung))
                ddlUseSysName.SelectedValue = rpt.HeThongSuDung;

            if (rpt.LoaiNhienLieu > 0)
            {
                ddlFuelType2.SelectedValue = rpt.LoaiNhienLieu.ToString();
                BindMeasurement2();
            }
            if (rpt.MeasurementId > 0)
                ddlMeasure2.SelectedValue = rpt.MeasurementId.ToString();
            txtLoiIchKhacTT.Text = rpt.LoiIchKhacTT;
            try
            {
                txtKhaNangTKNL.Text = rpt.KhaNangThucHien;
            }
            catch { }
            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "ShowDialogSolutionResultOne(" + hddkhtknl.Value + ");", true);
        }
    }

    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();

        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSolutionPlanOne('" + hddkhtknl.Value + "');", true);

    }
    protected void ddlFuel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement2();

        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSolutionResultOne('" + hddkhtknl.Value + "');", true);

    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        BindPlanTKNL();
    }
    public void btnSaveDevice_Click(object sender, EventArgs e)
    {
        try
        {
            PlanTB plantb = new PlanTB();
            PlanTBService plantbservice = new PlanTBService();
            if (ddlCacThucLD.SelectedIndex > 0)
                plantb.CachLapDat = ddlCacThucLD.SelectedValue;
            plantb.EnterpriseId = Convert.ToInt32(memVal.OrgId);
            plantb.NameTB = txtTenTB.Text;
            plantb.TinhNang = txtTinhNangTB.Text;
            plantb.LyDo = txtlydoTB.Text;
            plantb.Nam = (ReportYear + 1);//Convert.ToInt32(txtnamTB.Text);
            if (ddlCamKetTB.SelectedIndex > 0)
                plantb.CamKet = ddlCamKetTB.SelectedValue;
            plantb.KhaNang = txtKhaNangTB.Text.Trim();
            plantb.IdPlan = ReportId;
            plantb.IsFiveYear = false;
            plantb.IsPlan = true;
            plantb.IsNew = false;
            if (hddkhTB.Value != "" && Convert.ToInt32(hddkhTB.Value) > 0)
            {
                plantb.Id = Convert.ToInt32(hddkhTB.Value);
                if (plantbservice.Update(plantb) != null)
                {
                    BindThietBi();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogDevicePlanOne(" + hddkhTB.Value + ");", true);
                }

            }
            else
            {
                int i = plantbservice.Insert(plantb);
                if (i > 0)
                {
                    BindThietBi();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showx", "alert('Cập nhật không thành công!');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogDevicePlanOne(0);", true);
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    public void btnSavePlan_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        plantknl.NamBatDau = ReportYear + 1;
        plantknl.NamKetThuc = ReportYear + 1;
        plantknl.ThanhTien = txtThanhTien.Text.Trim();
        plantknl.ChiPhiDuKien = txtchiphidukienTKNL.Text;
        plantknl.MucTieuGP = txtmuctieuTKNL.Text;
        plantknl.KhaNangThucHien = txtKhaNangTKNL.Text;
        plantknl.MucCamKet = ddlCamKet.SelectedValue;
        plantknl.MucTietKiemDuKien = txtTKNLMucTieuDukien.Text;
        plantknl.LoiIchKhac = txtLoiIchKhac.Text.Trim();
        plantknl.TuongDuong = txtTuongDuong.Text.Trim();
        plantknl.GhiChu = txtGhiChu.Text.Trim();
        plantknl.IsFiveYear = false;
        plantknl.IsPlan = true;
        plantknl.HeThongSuDung = ddlUseSysNamePlan.SelectedValue;

        plantknl.EnterpriseId = memVal.OrgId;
        if (ddlSolution.SelectedIndex > 0)
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution.SelectedValue);
        if (ddlFuelType.SelectedIndex > 0)
            plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlMeasure.SelectedIndex > 0)
            plantknl.MeasurementId = Convert.ToInt32(ddlMeasure.SelectedValue);
        plantknl.IdPlan = ReportId;
        plantknl.ReportId = ReportId;
        if (hddkhtknl.Value != "" && Convert.ToInt32(hddkhtknl.Value) > 0)
        {
            plantknl.Id = Convert.ToInt32(hddkhtknl.Value);
            if (planser.Update(plantknl) != null)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionPlanOne(" + hddkhtknl.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionPlanOne(0);", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }

    }

    protected void rptResultTB_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        gp.EnterpriseId = Convert.ToInt32(memVal.OrgId);
        if (txtnamegp.Text != "")
        {
            gp.MoTa = txtmotagp.Text;
            gp.TenGiaiPhap = txtnamegp.Text;
            if (gpser.Insert(gp) > 0)
            {
                ltNoticeSolution.Text = "Lưu giải pháp mới thành công";
                BindSolution();
            }
            else
                ltNoticeSolution.Text = "Không lưu được giải pháp mới. Vui lòng thử lại";

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showGP", "showgiaiphap();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ac", "alert('Chưa nhập tên giải pháp!');", true);
        }
    }

    void BindResultTB()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, false, false);
        rptResultTB.DataSource = tbl;
        rptResultTB.DataBind();
    }
    private void BindResultTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, false, false);
        rptResultTKNL.DataSource = tbl;
        rptResultTKNL.DataBind();
    }


    public void btnSaveSolutionResult_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        plantknl.NamBatDau = ReportYear;
        plantknl.NamKetThuc = ReportYear;
        plantknl.CPThucTe = txtChiPhiThucTe.Text;
        plantknl.MucTieuGP = txtMucDichGPTT.Text;
        plantknl.MucTKCPThucTe = txtTKCPThucTe.Text;
        plantknl.MucTKThucTe = txtMucTietKiemNLTT.Text;
        plantknl.CPThucTe = txtChiPhiThucTe.Text.Trim();
        plantknl.LoiIchKhacTT = txtLoiIchKhacTT.Text.Trim();
        plantknl.TuongDuongTT = txtTuongDuongTT.Text.Trim();
        plantknl.GhiChuTT = txtGhiChuTT.Text.Trim();
        plantknl.IsFiveYear = false;
        plantknl.IsPlan = false;
        plantknl.ReportId = ReportId;
        plantknl.IdPlan = ReportId;
        plantknl.EnterpriseId = memVal.OrgId;
        plantknl.HeThongSuDung = ddlUseSysName.SelectedValue;
        if (ddlSolution2.SelectedIndex > 0)
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution2.SelectedValue);
        if (ddlFuelType2.SelectedIndex > 0)
            plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType2.SelectedValue);
        if (ddlMeasure2.SelectedIndex > 0)
            plantknl.MeasurementId = Convert.ToInt32(ddlMeasure2.SelectedValue);

        if (hddkhtknl.Value != "" && Convert.ToInt32(hddkhtknl.Value) > 0)
        {
            plantknl.Id = Convert.ToInt32(hddkhtknl.Value);
            if (planser.Update(plantknl) != null)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionResultOne(" + hddkhtknl.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionResultOne();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }
    }
    public void btnSaveAddDevice_Click(object sender, EventArgs e)
    {
        try
        {
            PlanTB plantb = new PlanTB();
            PlanTBService plantbservice = new PlanTBService();
            if (hddkhTB.Value != "")
            {
                plantb = plantbservice.FindByKey(Convert.ToInt32(hddkhTB.Value));
                if (ddlCacThucLDBS.SelectedIndex > 0)
                    plantb.CachLapDat = ddlCacThucLDBS.SelectedValue;
                plantb.EnterpriseId = Convert.ToInt32(memVal.OrgId);
                plantb.NameTB = txtTenTietBiBS.Text;
                plantb.TinhNang = txtMoTaTinhNangBS.Text;

                plantb.IsNew = (rblThucHien.SelectedIndex == 1);


                plantb.LyDo = txtLyDoKhongThucHien.Text;
                plantb.LyDoLapDat = txtLyDoKhongThucHien.Text;
                plantb.Nam = ReportYear;
                plantb.IsExecuted = (rblThucHien.SelectedIndex == 0);
                plantb.IdPlan = ReportId;
                plantb.IsFiveYear = false;
                plantb.IsPlan = false;

                int i = plantbservice.Update(plantb).Id;
                if (i > 0)
                {
                    BindResultTB();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "updateiaiphapTB();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }

            }
            else
            {
                plantb.EnterpriseId = Convert.ToInt32(memVal.OrgId);
                if (ddlCacThucLDBS.SelectedIndex > 0)
                    plantb.CachLapDat = ddlCacThucLDBS.SelectedValue;
                plantb.NameTB = txtTenTietBiBS.Text;
                plantb.TinhNang = txtMoTaTinhNangBS.Text;
                plantb.Nam = ReportYear;
                plantb.IsExecuted = (rblThucHien.SelectedIndex == 0);
                plantb.IsNew = (rblThucHien.SelectedIndex == 1);

                plantb.LyDo = txtLyDoKhongThucHien.Text;
                plantb.LyDoLapDat = txtLyDoKhongThucHien.Text;
                plantb.IsFiveYear = false;
                plantb.IsPlan = false;
                plantb.IdPlan = ReportId;
                int i = plantbservice.Insert(plantb);
                if (i > 0)
                {
                    BindResultTB();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "updateiaiphapTB();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showx", "alert('Cập nhật không thành công!');", true);

                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

}