﻿using System;
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
using System.Text;
using ReportEF;

public partial class Client_Module_DataEngery_InputPlan5Year : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    MemberValidation memVal = new MemberValidation();

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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            //ReportId = Id;
            BindFuel();
            BindSolution();
            BindData();
            BindPlanTKNL();
            BindThietBi();
            BindResultTB();
            BindResultTKNL();
            BindResultSolution5Year();

            GetKQThucHienKeHoach();
        }
    }

    void BindData()
    {
        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        ltNextPeriod.Text = ("Kế hoạch, mục tiêu tiết kiệm và sử dụng hiệu quả năng lượng trong 5 năm tới (" + ReportYear.ToString() + " - " + (ReportYear + 4).ToString() + ")").ToUpper();
        ltPeriod.Text = ("Kết quả thực hiện kế hoạch 5 năm (" + (ReportYear - 5).ToString() + " - " + (ReportYear - 1).ToString() + ")").ToUpper();
        btnAddDevice.Visible = btnAddPlan.Visible = btnAddSolution.Visible = AllowEdit;
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

    }
    void BindThietBi()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, true, true);
        rptKHBoSungTB.DataSource = tbl;
        rptKHBoSungTB.DataBind();
    }
    void BindResultTB()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, true, false);
        rptKetQuaTB.DataSource = tbl;
        rptKetQuaTB.DataBind();
    }
    private void BindPlanTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, true, true);
        cpRepeater.DataSource = tbl;
        cpRepeater.DataBind();
        //PlanTKNLService plangpservice = new PlanTKNLService();
        //DataTable tbl = new DataTable();
        //tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, true, true);

        //StringBuilder sb = new StringBuilder();        
        //StringBuilder sbHeader = new StringBuilder();
        //sbHeader.Append("<tr>");
        //sbHeader.Append("<th>Năm</th>");
        //for (int i = 4; i >= 0; i++)
        //{
        //    sbHeader.Append("<th>" + (ReportYear - i).ToString() + "</th>");
        //    DataRow[] dr = tbl.Select("Nam=" + (ReportYear - i));
        //    if (dr != null && dr.Count() > 0)
        //    {
        //        for (int j = 0; j < dr.Count(); j++)
        //        {
        //            sb.Append("<tr><td colspan='5'>" + dr[j]["TenGiaiPhap"] + "</td></tr>");
        //            sb.Append("<tr><td colspan='5'>" + dr[j]["TenGiaiPhap"] + "</td></tr>");
        //        }
        //    }

        //}
        //sbHeader.Append("</tr>");
    }
    private void BindResultTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, true, false);

        rptKetQuaTKNL.DataSource = tbl;
        rptKetQuaTKNL.DataBind();

    }
    void BindResultSolution5Year()
    {
        return;
        StringBuilder sb = new StringBuilder();
        DataTable tbl = new DataTable();
        tbl.Columns.Add("Year", typeof(string));
        for (int i = 1; i <= 5; i++)
        {
            tbl.Columns.Add(i.ToString(), typeof(double));
        }
        DataTable dtSolution = new DataTable();
        dtSolution = new GiaiPhapService().GetSolutionYear(ReportYear - 4, ReportYear, memVal.OrgId);


        DataTable dtSolutionResult = new DataTable();
        dtSolutionResult = new PlanTKNLService().GetResultSolution5Year(ReportYear - 4, ReportYear, memVal.OrgId);
        if (dtSolution != null && dtSolution.Rows.Count > 0)
        {
            if (dtSolutionResult != null && dtSolutionResult.Rows.Count > 0)
            {
                for (int i = 0; i < dtSolution.Rows.Count; i++)
                {
                    DataTable tblTemp = tbl.Clone();
                    DataRow[] drResult = dtSolutionResult.Select("IdGiaPhap=" + dtSolution.Rows[i]["Id"]);
                    if (drResult.Count() > 0)
                    {
                        DataRow dr0 = tbl.NewRow();
                        dr0["Year"] = "<b>Giải pháp " + (i + 1) + ": " + dtSolution.Rows[i]["TenGiaiPhap"] + "</b>";
                        tbl.Rows.Add(dr0);
                        for (int j = 0; j < drResult.Count(); j++)
                        {
                            DataRow dr1 = tbl.NewRow();
                            dr1["Year"] = "Mức Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch	(kWh)";

                            DataRow dr2 = tbl.NewRow();
                            dr2["Year"] = "Mức tiết kiệm năng lượng – Thực tế đạt được	(kWh)";

                            DataRow dr3 = tbl.NewRow();
                            dr3["Year"] = "Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch	(%)";

                            DataRow dr4 = tbl.NewRow();
                            dr4["Year"] = "Mức tiết kiệm năng lượng – Thực tế đạt được (%)";

                            DataRow dr5 = tbl.NewRow();
                            dr5["Year"] = "Mức tiết kiệm chi phí – Dự kiến theo kế hoạch (Triệu đồng)";

                            DataRow dr6 = tbl.NewRow();
                            dr6["Year"] = "Mức tiết kiệm chi phí – Thực tế đạt được	(Triệu đồng)";

                            DataRow dr7 = tbl.NewRow();
                            dr7["Year"] = "Chi phí – Dự kiến theo kế họach (Triệu đồng)";

                            DataRow dr8 = tbl.NewRow();
                            dr8["Year"] = "Chi phí – Thực tế thực hiện (Triệu đồng)";

                            int nam = Convert.ToInt32(drResult[j]["NamBatDau"]);

                            int indexYear = 5 - (ReportYear - nam);
                            if (drResult[j]["MucTietKiemDuKien"] != DBNull.Value && drResult[j]["MucTietKiemDuKien"].ToString().Trim() != "")
                                dr1[indexYear.ToString()] = Convert.ToDouble(drResult[j]["MucTietKiemDuKien"]);
                            else
                                dr1[indexYear.ToString()] = 0;
                            if (drResult[j]["MucTKThucTe"] != DBNull.Value && drResult[j]["MucTKThucTe"].ToString().Trim() != "")
                                dr2[indexYear.ToString()] = Convert.ToDouble(drResult[j]["MucTKThucTe"]);
                            else
                                dr2[indexYear.ToString()] = 0;
                            if (drResult[j]["TuongDuong"] != DBNull.Value && drResult[j]["TuongDuong"].ToString().Trim() != "")
                                dr3[indexYear.ToString()] = Convert.ToDouble(drResult[j]["TuongDuong"]);
                            else
                                dr3[indexYear.ToString()] = 0;
                            if (drResult[j]["TuongDuongTT"] != DBNull.Value && drResult[j]["TuongDuongTT"].ToString().Trim() != "")
                                dr4[indexYear.ToString()] = Convert.ToDouble(drResult[j]["TuongDuongTT"]);
                            else
                                dr4[indexYear.ToString()] = 0;
                            if (drResult[j]["TKCPDuKien"] != DBNull.Value && drResult[j]["TKCPDuKien"].ToString().Trim() != "")
                                dr5[indexYear.ToString()] = Convert.ToDouble(drResult[j]["TKCPDuKien"]);
                            else
                                dr5[indexYear.ToString()] = 0;
                            if (drResult[j]["MucTKCPThucTe"] != DBNull.Value && drResult[j]["MucTKCPThucTe"].ToString().Trim() != "")
                                dr6[indexYear.ToString()] = Convert.ToDouble(drResult[j]["MucTKCPThucTe"]);
                            else
                                dr6[indexYear.ToString()] = 0;
                            if (drResult[j]["ChiPhiDuKien"] != DBNull.Value && drResult[j]["ChiPhiDuKien"].ToString().Trim() != "")
                                dr7[indexYear.ToString()] = Convert.ToDouble(drResult[j]["ChiPhiDuKien"]);
                            else
                                dr7[indexYear.ToString()] = 0;
                            if (drResult[j]["CPThucTe"] != DBNull.Value && drResult[j]["CPThucTe"].ToString().Trim() != "")
                                dr8[indexYear.ToString()] = Convert.ToDouble(drResult[j]["CPThucTe"]);
                            else
                                dr8[indexYear.ToString()] = 0;
                            tbl.Rows.Add(dr1);
                            tbl.Rows.Add(dr2);
                            tbl.Rows.Add(dr3);
                            tbl.Rows.Add(dr4);
                            tbl.Rows.Add(dr5);
                            tbl.Rows.Add(dr6);
                            tbl.Rows.Add(dr7);
                            tbl.Rows.Add(dr8);
                        }
                    }
                }
            }
        }
        rptResultSolution.DataSource = tbl;
        rptResultSolution.DataBind();
    }

    DataTable GetKQThucHienKeHoach()
    {
        StringBuilder sb = new StringBuilder();
        DataTable tbl = new DataTable();
        tbl.Columns.Add("Year", typeof(string));
        for (int i = ReportYear - 5; i < ReportYear; i++)
            tbl.Columns.Add(i.ToString(), typeof(string));
        var firstRow = tbl.NewRow();

        foreach (DataColumn col in tbl.Columns)
        {
            firstRow["Year"] = "Năm";
            for (int i = ReportYear - 5; i < ReportYear; i++)
                firstRow[i.ToString()] = i;
        }


        DataTable dtSolution = new DataTable();
        int _startPlanYear = ReportYear - 4;
        ReportModels rp = new ReportModels();
        var Solution5Year = (from a in rp.DE_GiaiPhap
                             join b in rp.DE_PlanTKNL on a.Id equals b.IdGiaPhap
                             join c in rp.DE_ReportFuel on b.IdPlan equals c.Id
                             where c.EnterpriseId == memVal.OrgId && c.ReportType == ReportKey.PLAN && b.IsPlan == true
                             && c.Year >= _startPlanYear && c.Year <= ReportYear
                             orderby c.Year
                             select new
                             {
                                 DE_GiaiPhap = a,
                                 DE_PlanTKNL = b,
                                 DE_ReportFuel = c
                             }).ToList();

        int _startResultYear = ReportYear - 5;

        var Result5Year = (from a in rp.DE_GiaiPhap
                           join b in rp.DE_PlanTKNL on a.Id equals b.IdGiaPhap
                           join c in rp.DE_ReportFuel on b.IdPlan equals c.Id
                           where c.EnterpriseId == memVal.OrgId && c.ReportType == ReportKey.PLAN && b.IsPlan == false
                           && c.Year >= _startResultYear && c.Year <= ReportYear && a.IsDelete == false
                           orderby c.Year
                           select new
                           {
                               DE_GiaiPhap = a,
                               DE_PlanTKNL = b,
                               DE_ReportFuel = c
                           }).ToList();

        var ListSol = Solution5Year.Select(o => new { o.DE_GiaiPhap.Id, o.DE_GiaiPhap.TenGiaiPhap }).Distinct().ToList();

        int _counter = 1;

        foreach (var sol in ListSol)
        {
            var plan = Solution5Year.Where(o => o.DE_GiaiPhap.Id == sol.Id);
            var result = Result5Year.Where(o => o.DE_GiaiPhap.Id == sol.Id);

            var row1 = tbl.NewRow();
            row1["Year"] = string.Format("<b>Giải pháp {0}: {1}</b>", _counter, sol.TenGiaiPhap);


            var row2 = tbl.NewRow();
            row2["Year"] = "Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (kWh)";

            var row3 = tbl.NewRow();
            row3["Year"] = "Mức tiết kiệm năng lượng - Thực tế đạt được	(kWh)";

            var row4 = tbl.NewRow();
            row4["Year"] = "Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (%)";

            var row5 = tbl.NewRow();
            row5["Year"] = "Mức tiết kiệm năng lượng - Thực tế đạt được	(%)";

            var row6 = tbl.NewRow();
            row6["Year"] = "Mức tiết kiệm chi phí - Dự kiến theo kế hoạch (Triệu đồng)";

            var row7 = tbl.NewRow();
            row7["Year"] = "Mức tiết kiệm chi phí - Thực tế đạt được (Triệu đồng)";

            var row8 = tbl.NewRow();
            row8["Year"] = "Chi phí - Dự kiến theo kế họach	(Triệu đồng)";

            var row9 = tbl.NewRow();
            row9["Year"] = "Chi phí - Thực tế thực hiện (Triệu đồng)";

            tbl.Rows.Add(row1);
            tbl.Rows.Add(row2);
            tbl.Rows.Add(row3);
            tbl.Rows.Add(row4);
            tbl.Rows.Add(row5);
            tbl.Rows.Add(row6);
            tbl.Rows.Add(row7);
            tbl.Rows.Add(row8);
            tbl.Rows.Add(row9);


            //Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (kWh)
            foreach (var p in plan)
            {
                foreach (DataColumn col in tbl.Columns)
                    if ((p.DE_ReportFuel.Year).ToString() == col.ColumnName)
                    {
                        row2[col.ColumnName] = p.DE_PlanTKNL.MucTietKiemDuKien != null ? p.DE_PlanTKNL.MucTietKiemDuKien : "";
                        row4[col.ColumnName] = p.DE_PlanTKNL.TuongDuong != null ? p.DE_PlanTKNL.TuongDuong : "";
                        row6[col.ColumnName] = p.DE_PlanTKNL.TKCPDuKien != null ? p.DE_PlanTKNL.TKCPDuKien : "";
                        row8[col.ColumnName] = p.DE_PlanTKNL.ChiPhiDuKien != null ? p.DE_PlanTKNL.ChiPhiDuKien : "";
                    }

            }

            //Mức tiết kiệm năng lượng - Thực tế đạt được	(kWh)
            foreach (var re in result)
            {
                foreach (DataColumn col in tbl.Columns)
                    if ((re.DE_ReportFuel.Year - 1).ToString() == col.ColumnName)
                    {
                        row3[col.ColumnName] = re.DE_PlanTKNL.MucTKThucTe != null ? re.DE_PlanTKNL.MucTKThucTe : "";
                        row5[col.ColumnName] = re.DE_PlanTKNL.TuongDuongTT != null ? re.DE_PlanTKNL.TuongDuongTT : "";
                        row7[col.ColumnName] = re.DE_PlanTKNL.MucTKCPThucTe != null ? re.DE_PlanTKNL.MucTKCPThucTe : "";
                        row9[col.ColumnName] = re.DE_PlanTKNL.CPThucTe != null ? re.DE_PlanTKNL.CPThucTe : "";
                    }

            }

            _counter++;
        }
        rptResultSolutionPlan5.DataSource = tbl;
        rptResultSolutionPlan5.DataBind();
        return tbl;
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
            if (rpt.IdGiaPhap > 0)
                ddlSolution.SelectedValue = rpt.IdGiaPhap.ToString();
            if (rpt.LoaiNhienLieu > 0)
            {
                ddlFuelType.SelectedValue = rpt.LoaiNhienLieu.ToString();
                BindMeasurement();
            }
            if (rpt.MeasurementId > 0)
                ddlMeasure.SelectedValue = rpt.MeasurementId.ToString();
            try
            {
                ddlCamKet.SelectedValue = rpt.MucCamKet;
            }
            catch { }
            txtvonTKNL.Text = rpt.HoanVon;
            txtGhiChu.Text = rpt.GhiChu;
            txtLoiIchKhac.Text = rpt.LoiIchKhac;
            txtThanhTien.Text = rpt.ThanhTien;
            txtNamBD.Text = rpt.NamBatDau.ToString(); ;
            txtNamKT.Text = rpt.NamKetThuc.ToString();
            txtTuongDuong.Text = rpt.TuongDuong;
            if (rpt.ThanhTien != null)
                txtThanhTien.Text = rpt.ThanhTien;

            txtKhaNangTKNL.Text = rpt.KhaNangThucHien;

            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            //BindPlanTKNL();

            //ScriptManager.RegisterStartupScript(this, GetType(), "showkhdg", "showkehoach();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "ShowDialogSolutionPlan(" + hddkhtknl.Value + "," + hdnPlan.Value + ");", true);
        }
    }


    protected void rptKHBoSungTB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTB rpt = new PlanTB();
            PlanTBService rptbso = new PlanTBService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindThietBi();

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
                    ddlCachThucLD.SelectedValue = rpt.CachLapDat;
                }
                catch { }
            }
            txtlydoTB.Text = rpt.LyDo;
            txtnamTB.Text = rpt.Nam.ToString();
            txtTenTB.Text = rpt.NameTB;
            try
            {
                ddlCamKetTB.Text = rpt.CamKet;
            }
            catch { }

            txtKhaNangTKNL.Text = rpt.KhaNang;
            txtTinhNangTB.Text = rpt.TinhNang;
            hddkhTB.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogDevicePlan(" + hddkhTB.Value + "," + hdnPlan.Value + ");", true);
        }
    }
    protected void rptResultTB_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item["NoFuel_TOE"] != DBNull.Value)
            //{
            //    No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            //}
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptKetQuaTB_ItemCommand(object source, RepeaterCommandEventArgs e)
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

            hddkhTB.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "updateiaiphapTB5(" + hdnFiveYear.Value + "," + hdnPlan.Value + ");", true);
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
            if (ddlCachThucLD.SelectedIndex > 0)
                plantb.CachLapDat = ddlCachThucLD.SelectedValue;
            plantb.EnterpriseId = memVal.OrgId;
            plantb.NameTB = txtTenTB.Text;
            plantb.TinhNang = txtTinhNangTB.Text;
            plantb.LyDo = txtlydoTB.Text;
            plantb.Nam = Convert.ToInt32(txtnamTB.Text);
            if (ddlCamKetTB.SelectedIndex > 0)
                plantb.CamKet = ddlCamKetTB.SelectedValue;
            plantb.KhaNang = txtKhaNangTB.Text.Trim();
            plantb.IdPlan = ReportId;
            plantb.IsFiveYear = true;
            plantb.IsPlan = true;
            if (hddkhTB.Value != "" && Convert.ToInt32(hddkhTB.Value) > 0)
            {
                plantb.Id = Convert.ToInt32(hddkhTB.Value);
                if (plantbservice.Update(plantb) != null)
                {
                    BindThietBi();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "ShowDialogDevicePlan(" + hddkhTB.Value + ",1);", true);
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "ShowDialogDevicePlan(0,1);", true);

                }
            }
        }
        catch (Exception)
        {

            throw;
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
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSolutionPlan('" + hddkhtknl.Value + "');", true);
    }

    public void btnSavePlan_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        plantknl.NamBatDau = Convert.ToInt32(txtNamBD.Text.Trim());
        plantknl.NamKetThuc = Convert.ToInt32(txtNamKT.Text.Trim());
        plantknl.ChiPhiDuKien = txtchiphidukienTKNL.Text;
        plantknl.MucTieuGP = txtmuctieuTKNL.Text;
        plantknl.KhaNangThucHien = txtKhaNangTKNL.Text;
        plantknl.MucCamKet = ddlCamKet.SelectedValue;
        plantknl.MucTietKiemDuKien = txtTKNLMucTieuDukien.Text;
        plantknl.HoanVon = txtvonTKNL.Text;
        plantknl.LoiIchKhac = txtLoiIchKhac.Text.Trim();
        plantknl.TuongDuong = txtTuongDuong.Text.Trim();
        plantknl.ThanhTien = txtThanhTien.Text.Trim();
        plantknl.GhiChu = txtGhiChu.Text.Trim();
        plantknl.IsFiveYear = true;
        plantknl.IsPlan = true;
        plantknl.EnterpriseId = memVal.OrgId;
        if (ddlFuelType.SelectedIndex > 0)
            plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlSolution.SelectedIndex > 0)
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution.SelectedValue);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "showgiaiphapTKNL5(" + hdnFiveYear.Value + "," + hdnPlan.Value + ");", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "showgiaiphapTKNL5(" + hdnFiveYear.Value + "," + hdnPlan.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }

    }

    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        gp.EnterpriseId = memVal.OrgId;
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showGP", "showgiaiphap5(" + hdnFiveYear.Value + "," + hdnPlan.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ac", "alert('Chưa nhập tên giải pháp!');", true);
        }
    }
    void BindSolution()
    {
        GiaiPhapService gps = new GiaiPhapService();
        DataTable lst = gps.GetGiaiPhepByEnerprise(memVal.OrgId);
        ddlSolution.DataSource = lst;
        ddlSolution.DataBind();
        ddlSolution.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));
    }
}