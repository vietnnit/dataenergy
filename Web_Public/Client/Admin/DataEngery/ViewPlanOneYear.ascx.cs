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

public partial class Client_Admin_DataEngery_ViewPlanOneYear : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
            BindFuel();
            BindSolution();
            BindData();
            BindPlanTKNL();
            BindThietBi();
            BindResultTB();
            BindResultTKNL();
        }
    }

    void BindData()
    {
        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        ltOldYear.Text = ("I. Kết quả thực hiện năm " + (ReportYear - 1).ToString()).ToUpper();
        ltNextYear.Text = ("II .Kế hoạch thực hiện năm " + ReportYear.ToString()).ToUpper();
        //}        

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
        GiaiPhapService gps = new GiaiPhapService();
        DataTable lst = gps.GetGiaiPhepByEnerprise(Convert.ToInt32(m_UserValidation.OrgId));
        dllgiaiphap.DataSource = lst;
        dllgiaiphap.DataBind();
        dllgiaiphap.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));

        ddlSolution2.DataSource = lst;
        ddlSolution2.DataBind();
        ddlSolution2.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));
    }
    void BindThietBi()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(m_UserValidation.OrgId, ReportId, false, true);
        rptKHBoSungTB.DataSource = tbl;
        rptKHBoSungTB.DataBind();
    }

    private void BindPlanTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(m_UserValidation.OrgId, ReportId, false, true);
        cpRepeater.DataSource = tbl;
        cpRepeater.DataBind();
    }

    protected void cpRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindPlanTKNL();
            //ScriptManager.RegisterStartupScript(this, GetType(), "showkh", "showkehoach();", true);
            //  ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "showgiaiphapTKNL('1');", true);
            //   voidbindexcel(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            txtmuctieuTKNL.Text = rpt.MucTieuGP;
            txtchiphidukienTKNL.Text = rpt.ChiPhiDuKien;
            dllgiaiphap.SelectedValue = rpt.IdGiaPhap.ToString();
            txtcamketTKNL.Text = rpt.MucCamKet;
            //txtGiaiDoanTKNL.Text = rpt.GiaiDoan;            
            if (rpt.LoaiNhienLieu > 0)
                ddlFuelType.SelectedValue = rpt.LoaiNhienLieu.ToString();
            txtGhiChu.Text = rpt.GhiChu;
            txtLoiIchKhac.Text = rpt.LoiIchKhac;
            txtThanhTien.Text = rpt.ThanhTien;
            try
            {
                ddlKhaNang.Text = rpt.KhaNangThucHien;
            }
            catch { }
            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            //BindPlanTKNL();

            //ScriptManager.RegisterStartupScript(this, GetType(), "showkhdg", "showkehoach();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "showgiaiphapTKNL('1');", true);
        }
    }

    protected void cpRepeaterTB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindThietBi();
            ScriptManager.RegisterStartupScript(this, GetType(), "showkh", "showkehoach();", true);

        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            //txtMucCamKetTB.Text = rpt.CamKet;

            if (rpt.CachLapDat != "")
            {
                try
                {
                    ddlCacThucLD.SelectedValue = rpt.CachLapDat;
                }
                catch { }
            }
            txtlydoTB.Text = rpt.LyDo;
            txtnamTB.Text = rpt.Nam.ToString();
            txtTenTB.Text = rpt.NameTB;
            txtCamKetTB.Text = rpt.CamKet;
            ddlKhaNangTB.SelectedValue = rpt.KhaNang;
            txtTinhNangTB.Text = rpt.TinhNang;
            hddkhTB.Value = rpt.Id.ToString();
            //BindThietBi();
            ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "showkehoach();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "showgiaiphapTB('1');", true);
        }
    }

    protected void rptResultTB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindResultTB();

        }
        else if (e.CommandName.Equals("edit"))
        {
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
            cbxThucHien.Checked = rpt.IsExecuted;
            if (rpt.IsNew)
            {
                if (cbxThucHien.Checked)
                    txtLyDoKhongThucHien.Text = rpt.LyDoLapDat;
                else
                    txtLyDoKhongThucHien.Text = rpt.LyDo;
            }
            else
            {
                txtLyDoKhongThucHien.Text = rpt.LyDoLapDat;
            }
            hddkhTB.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "updategiaiphapTB();", true);
        }
    }
    protected void rptResultTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindPlanTKNL();
        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            hddkhtknl.Value = rpt.Id.ToString();
            txtMucDichGPTT.Text = rpt.MucTieuGP;
            txtMucTietKiemNLTT.Text = rpt.MucTKThucTe;
            ddlSolution2.SelectedValue = rpt.IdGiaPhap.ToString();
            txtTKCPThucTe.Text = rpt.MucTKCPThucTe;
            txtChiPhiThucTe.Text = rpt.CPThucTe;
            txtGhiChuTT.Text = rpt.GhiChuTT;
            txtTuongDuongTT.Text = rpt.TuongDuongTT;
            if (rpt.LoaiNhienLieu > 0)
                ddlFuelType2.SelectedValue = rpt.LoaiNhienLieu.ToString();
            txtLoiIchKhacTT.Text = rpt.LoiIchKhacTT;
            try
            {
                ddlKhaNang.Text = rpt.KhaNangThucHien;
            }
            catch { }
            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            //BindPlanTKNL();

            //ScriptManager.RegisterStartupScript(this, GetType(), "showkhdg", "showkehoach();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "updategiaiphapTKNL();", true);
        }
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
            if (hddkhTB.Value != "")
            {
                plantb = plantbservice.FindByKey(Convert.ToInt32(hddkhTB.Value));
                if (ddlCacThucLD.SelectedIndex > 0)
                    plantb.CachLapDat = ddlCacThucLD.SelectedValue;
                plantb.EnterpriseId = m_UserValidation.OrgId;
                plantb.NameTB = txtTenTB.Text;
                plantb.TinhNang = txtTinhNangTB.Text;
                plantb.LyDo = txtlydoTB.Text;
                plantb.Nam = Convert.ToInt32(txtnamTB.Text);
                if (ddlKhaNangTB.SelectedIndex > 0)
                    plantb.KhaNang = ddlKhaNangTB.SelectedValue;
                plantb.CamKet = txtCamKetTB.Text.Trim();
                plantb.IdPlan = ReportId;
                plantb.IsFiveYear = false;
                plantb.IsPlan = true;
                plantb.IsNew = false;
                int i = plantbservice.Update(plantb).Id;
                if (i > 0)
                {
                    BindThietBi();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "showgiaiphapTB('1');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }

            }
            else
            {
                //plantb.CamKet = txtMucCamKetTB.Text;
                if (ddlCacThucLD.SelectedIndex > 0)
                    plantb.CachLapDat = ddlCacThucLD.SelectedValue;
                plantb.EnterpriseId = m_UserValidation.OrgId;
                plantb.NameTB = txtTenTB.Text;
                plantb.TinhNang = txtTinhNangTB.Text;
                plantb.LyDo = txtlydoTB.Text;
                plantb.Nam = Convert.ToInt32(txtnamTB.Text);
                if (ddlKhaNangTB.SelectedIndex > 0)
                    plantb.KhaNang = ddlKhaNangTB.SelectedValue;
                plantb.CamKet = txtCamKetTB.Text.Trim();
                plantb.IsFiveYear = false;
                plantb.IsPlan = true;
                plantb.IsNew = false;
                plantb.IdPlan = ReportId;
                int i = plantbservice.Insert(plantb);
                if (i > 0)
                {
                    BindThietBi();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "showgiaiphapTB('1');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showx", "alert('Cập nhật không thành công!');", true);

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
        if (hddkhtknl.Value != "")
        {
            plantknl = planser.FindByKey(Convert.ToInt32(hddkhtknl.Value));
            plantknl.NamBatDau = ReportYear;
            plantknl.NamKetThuc = ReportYear;
            plantknl.ChiPhiDuKien = txtchiphidukienTKNL.Text;
            plantknl.MucTieuGP = txtmuctieuTKNL.Text;
            plantknl.KhaNangThucHien = ddlKhaNang.SelectedValue;
            plantknl.MucCamKet = txtcamketTKNL.Text;
            plantknl.MucTietKiemDuKien = txtTKNLMucTieuDukien.Text;
            plantknl.LoiIchKhac = txtLoiIchKhac.Text.Trim();
            plantknl.TuongDuong = txtTuongDuong.Text.Trim();
            plantknl.GhiChu = txtGhiChu.Text.Trim();
            plantknl.IsFiveYear = false;
            plantknl.IsPlan = true;
            plantknl.EnterpriseId = m_UserValidation.OrgId;
            if (ddlFuelType.SelectedIndex > 0)
                plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
            plantknl.IdPlan = ReportId;
            int i = planser.Update(plantknl).Id;
            if (i > 0)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "showgiaiphapTKNL('1');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            plantknl.NamBatDau = ReportYear;
            plantknl.NamKetThuc = ReportYear;
            plantknl.ChiPhiDuKien = txtchiphidukienTKNL.Text;
            plantknl.MucTieuGP = txtmuctieuTKNL.Text;
            plantknl.KhaNangThucHien = ddlKhaNang.SelectedValue;
            plantknl.MucCamKet = txtcamketTKNL.Text;
            plantknl.MucTietKiemDuKien = txtTKNLMucTieuDukien.Text;
            plantknl.IdGiaPhap = Convert.ToInt32(dllgiaiphap.SelectedValue);
            //plantknl.GiaiDoan = txtGiaiDoanTKNL.Text;
            plantknl.EnterpriseId = m_UserValidation.OrgId;
            plantknl.LoiIchKhac = txtLoiIchKhac.Text.Trim();
            plantknl.TuongDuong = txtTuongDuong.Text.Trim();
            plantknl.GhiChu = txtGhiChu.Text.Trim();
            plantknl.IsFiveYear = false;
            plantknl.IsPlan = true;
            if (ddlFuelType.SelectedIndex > 0)
                plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
            plantknl.IdPlan = ReportId;
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "showgiaiphapTKNL('1');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }

    }
    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        gp.EnterpriseId = m_UserValidation.OrgId;
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
        tbl = plangpservice.GetPlanTBEnterprise(m_UserValidation.OrgId, ReportId, false, false);
        rptResultTB.DataSource = tbl;
        rptResultTB.DataBind();
    }
    private void BindResultTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(m_UserValidation.OrgId, ReportId, false, false);
        rptResultTKNL.DataSource = tbl;
        rptResultTKNL.DataBind();
    }
    protected void btnsave_DirectClick(object sender, EventArgs e)
    {
        try
        {
            Plan rpt = new Plan();
            PlanService rptbso = new PlanService();
            if (PlanId < 1)
            {

                rpt.CreateByUser = m_UserValidation.UserId;
                rpt.CreateDate = DateTime.Now;
                rpt.Des = txtmota.Text;
                rpt.EnterpriseId = m_UserValidation.OrgId;
                rpt.ModifyByUser = 0;
                rpt.ModifyDate = DateTime.Now;
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                rpt.ReportId = ReportId;
                rpt.ReportDate = DateTime.ParseExact(txtNgaytao.Text, @"dd/MM/yyyy", culture);
                //rpt.BeginDate = DateTime.ParseExact(txFromYear.Text, @"dd/MM/yyyy", culture);
                //rpt.EndDate = DateTime.ParseExact(txtEndYear.Text, @"dd/MM/yyyy", culture);
                int i = rptbso.Insert(rpt);
                if (i > 0)
                {
                    PlanId = i;
                    clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
                    //BindPlanTKNL();
                }
                else
                {
                    clientview.Text = "div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thất bại !</div>";
                }
            }
            else
            {
                rpt = rptbso.FindByKey(PlanId);
                rpt.ModifyByUser = m_UserValidation.UserId;
                rpt.ModifyDate = DateTime.Now;
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                // rpt.ReportDate = DateTime.ParseExact(txtNgaytao.Text, "dd/MM/yyyy", culture);
                ///rpt.PlanName = txttieude.Text;
                rpt.Des = txtmota.Text;
                //rpt.EnterpriseId = Convert.ToInt32(memVal.OrgId);
                rpt.ReportDate = DateTime.ParseExact(txtNgaytao.Text, @"dd/MM/yyyy", culture);
                //rpt.BeginYear= DateTime.ParseExact(txFromYear.Text, @"dd/MM/yyyy", culture);
                //rpt.EndYear = DateTime.ParseExact(txtEndYear.Text, @"dd/MM/yyyy", culture);
                int i = rptbso.Update(rpt);
                if (i > 0)
                {
                    //ltDes.Text = rpt.Des;
                    clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
                    //BindPlanTKNL();
                }
                else
                {
                    clientview.Text = "div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thất bại !</div>";
                }
            }
        }
        catch (Exception ex)
        { }
    }

    public void btnSaveAddPlan_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        if (hddkhtknl.Value != "" && Convert.ToInt32(hddkhtknl.Value) > 0)
        {
            plantknl = planser.FindByKey(Convert.ToInt32(hddkhtknl.Value));
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
            plantknl.EnterpriseId = m_UserValidation.OrgId;
            if (ddlFuelType.SelectedIndex > 0)
                plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
            plantknl.IdPlan = ReportId;
            if (planser.Update(plantknl) != null)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "updategiaiphapTKNL();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            plantknl.EnterpriseId = m_UserValidation.OrgId;
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution2.SelectedValue);
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
            plantknl.IsAdd = true;
            plantknl.IdPlan = ReportId;
            if (ddlFuelType.SelectedIndex > 0)
                plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
            plantknl.IdPlan = ReportId;
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "updategiaiphapTKNL();", true);
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
                plantb.EnterpriseId = m_UserValidation.OrgId;
                plantb.NameTB = txtTenTietBiBS.Text;
                plantb.TinhNang = txtMoTaTinhNangBS.Text;
                if (cbxThucHien.Checked)
                    plantb.LyDoLapDat = txtLyDoKhongThucHien.Text;
                else
                    plantb.LyDo = txtLyDoKhongThucHien.Text;
                plantb.Nam = ReportYear;
                plantb.IsExecuted = cbxThucHien.Checked;
                plantb.IdPlan = ReportId;
                plantb.IsFiveYear = false;
                plantb.IsPlan = false;
                plantb.IsNew = false;
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
                plantb.EnterpriseId = m_UserValidation.OrgId;
                if (ddlCacThucLDBS.SelectedIndex > 0)
                    plantb.CachLapDat = ddlCacThucLDBS.SelectedValue;
                plantb.NameTB = txtTenTietBiBS.Text;
                plantb.TinhNang = txtMoTaTinhNangBS.Text;
                plantb.Nam = ReportYear;
                plantb.IsExecuted = cbxThucHien.Checked;
                if (cbxThucHien.Checked)
                    plantb.LyDoLapDat = txtLyDoKhongThucHien.Text;
                else
                    plantb.LyDo = txtLyDoKhongThucHien.Text;
                plantb.IsNew = true;
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