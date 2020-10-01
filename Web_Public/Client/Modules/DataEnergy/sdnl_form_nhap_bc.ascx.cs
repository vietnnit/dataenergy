using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportEF;
using ReportBUS;
using ReportBUS.CustomModels;
using System.Web.Script.Serialization;

public partial class Client_Modules_DataEnergy_sdnl_form_nhap_bc : System.Web.UI.UserControl
{
    MemberValidation memberVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListNamBaoCao();
            int Year = DateTime.Now.Year;
            int RpId = 0;
            if (Request.QueryString["RpId"] != null)
                int.TryParse(Request.QueryString["RpId"], out RpId);

            /*SetYear(memberVal.OrgId, RpId);
            if (RpId > 0)
                ddlNamBaoCao.Enabled = false;
            else
                ddlNamBaoCao.Enabled = true;
            */
            if (RpId == 0)//Them moi bao cao
            {
                ListDefautlReport();
            }
            else //Hieu chinh bao cao
            {
                CreateListFuel(RpId);
                BindComment(RpId);
            }

            if (Request.QueryString["act"] != null)
            {
                pnNoneAction.Visible = true;
                pnAction.Visible = false;
            }
            else
            {
                pnNoneAction.Visible = false;
                pnAction.Visible = true;
            }

        }
    }


    private void ListDefautlReport()
    {
        int rpYear = Convert.ToInt32(ddlNamBaoCao.SelectedValue);
        int OrgId = memberVal.OrgId;
        hdReportId.Value = "0";
        using (var db = new ReportModels())
        {
            if (db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == OrgId && o.NamBaoCao == rpYear))
            {
                var Rp = db.BC_SDNL_DS_TheoNam.Where(o => o.IdDN == OrgId && o.NamBaoCao == rpYear).FirstOrDefault();
                if (Rp != null)
                {
                    CreateListFuel(Rp.AutoID);
                    ddlNamBaoCao.SelectedValue = Rp.NamBaoCao.ToString();
                }
            }
            else
            {
                CreateListFuel(0);
            }
        }
    }

    private void CreateListFuel(int RpId)
    {
        MemberValidation memberVal = new MemberValidation();
        //memberVal.OrgId
        hdReportId.Value = RpId.ToString();

        string temp = string.Empty;
        temp += "<table id='tableTOE' style='border-collapse:collapse;' class='table table-striped table-bordered table-hover mbn' cellspacing='0' rules='all' border='1' >";

        temp += "<tr class='primary fs12'>";
        temp += "<th>STT</th>";
        temp += "<th>Dạng năng lượng sử dụng</th>";
        temp += "<th>Đơn vị tính</th>";
        temp += "<th>Mức tiêu thụ</th>";
        temp += "<th>Năng lượng quy đổi TOE</th>";
        temp += "</tr>";
        //string trTemp = "<tr>";
        //trTemp += "<td>{0}</td>";
        //trTemp += "<td>{1}</td>";
        //trTemp += "<td>{2}</td>";
        //trTemp += "<td>{3}</td>";
        //trTemp += "<td>{4}</td>";
        //trTemp += "</tr>";
        if (RpId > 0)
        {
            using (var db = new ReportModels())
            {
                var rp = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == RpId).FirstOrDefault();
                ddlNamBaoCao.SelectedValue = rp.NamBaoCao.ToString();
            }
        }

        SDNLHangNam bus = new SDNLHangNam();
        List<rpSDNLHangNam> dataSource = bus.DN_Get_BaoCao(RpId);
        List<int> fuels = dataSource.Select(o => o.FuelId).Distinct().ToList();

        decimal TotalTOE = 0;
        int i = 0;
        foreach (int fuelid in fuels)
        {
            i++;
            var rowData = dataSource.Where(o => o.FuelId == fuelid).ToList();

            //{0}: = i.tostring
            int par0Val = i;
            string par0Temp = string.Format("<td rowspan='{0}'>{1}</td>", rowData.Count(), par0Val);
            //{1}: 
            string par1Val = rowData[0].FuelName;
            string par1Temp = string.Format("<td rowspan='{0}'>{1}</td>", rowData.Count(), par1Val);

            //{2}:

            int k = 0;
            foreach (var j in rowData)
            {
                string par2Temp = string.Empty;
                string par3Temp = string.Empty;
                string par4Temp = string.Empty;

                par2Temp += string.Format("<td>{0}</td>", j.MeasurementName);
                //id='id_{0}_{1}_{2}':id_fuelId_measurementId_toe
                string MucTieuThu = j.MucTieuThu > 0 ? j.MucTieuThu.ToString() : "";
                MucTieuThu = MucTieuThu.Replace(",", ".");

                par3Temp += string.Format("<td><input value='{3}' onkeyup='TOEChanged(this)' id=\"id_{0}_{1}_{2}\" TOEattr=\"{2}\" type=\"text\" oninput=\"this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\\..*)\\./g, '$1');\" /></td>", j.FuelId, j.MeasurementId, j.TOE, MucTieuThu);

                string NangLuongQuyDoi = "";
                if (j.NangLuongQuyDoi > 0)
                {
                    TotalTOE += j.NangLuongQuyDoi;
                    NangLuongQuyDoi = j.NangLuongQuyDoi.ToString();
                }
                par4Temp += string.Format("<td><label>{0}</label></td>", NangLuongQuyDoi.Replace(",", "."));
                //tạo dữ liệu cho tr bằng cách gộp 5 giá trị par4Temp
                if (k == 0)
                    temp += string.Format("<tr>{0}{1}{2}{3}{4}</tr>", par0Temp, par1Temp, par2Temp, par3Temp, par4Temp);
                else//chỉ thêm par0Temp, par1Temp 01 lần vì có thuộc tính rowspan
                    temp += string.Format("<tr>{0}{1}{2}</tr>", par2Temp, par3Temp, par4Temp);
                k++;
            }
        }

        string lastRow = string.Format("<tr><td colspan='4' style='font-weight:bold; text-align:center;'>TỔNG NĂNG LƯỢNG TIÊU THỤ QUY ĐỔI TOE</td><td><label id='lbTongNLTTQuyDoiTOE'>{0}</label></td><tr>", TotalTOE > 0 ? TotalTOE.ToString() : "");
        temp += lastRow;
        temp += "</table>";

        ltReport.Text = temp;
    }

    private void ListNamBaoCao()
    {
        if (memberVal.IsSigned())
        {
            int startYear = 2010;
            int endYear = DateTime.Now.Year;
            SDNLHangNam ctx = new SDNLHangNam();
            List<int> source = ctx.DN_Get_NamBaoCao(memberVal.OrgId);
            for (int i = startYear; i <= endYear; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                ddlNamBaoCao.Items.Add(item);
            }
        }
    }

    private int GetData()
    {
        int ReportId = 0;
        if (Request.QueryString["RpId"] != null)
            int.TryParse(Request.QueryString["RpId"], out ReportId);


        using (var ctx = new ReportModels())
        {
            int OrgId = memberVal.OrgId;
            int NamBaoCao = Convert.ToInt32(ddlNamBaoCao.SelectedValue);

            if (ctx.BC_SDNL_DS_TheoNam.Any(o => o.AutoID == ReportId) == false)
            {
                var OrgInfoRp = new BC_SDNL_DS_TheoNam();
                OrgInfoRp.IdDN = OrgId;
                OrgInfoRp.NamBaoCao = NamBaoCao;
                OrgInfoRp.NgayLapBC = DateTime.Now;
                OrgInfoRp.TrangThai = 0;
                ctx.BC_SDNL_DS_TheoNam.Add(OrgInfoRp);
                ctx.SaveChanges();

                ReportId = OrgInfoRp.AutoID;
            }

            string jsonData = ltDuLieuNhap.Value;
            if (jsonData.Length > 10)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<formdata> dataObject = js.Deserialize<List<formdata>>(jsonData);
                List<BC_SDNL_HangNam> listData = new List<BC_SDNL_HangNam>();
                var oldData = ctx.BC_SDNL_HangNam.Where(o => o.ReportId == ReportId && o.TrangThai >= 0).ToList();

                foreach (formdata item in dataObject)
                {
                    if (item.MucTieuThu > 0)
                    {
                        //Dữ liệu chưa tồn tại =>Thêm
                        if (!oldData.Any(o => o.FuelId == item.FuelId && o.MeasurementId == item.MeasurementId))
                        {
                            listData.Add(new BC_SDNL_HangNam
                            {
                                IdDN = OrgId,
                                ReportId = ReportId,
                                TrangThai = 0,
                                NamBaoCao = NamBaoCao,
                                FuelId = item.FuelId,
                                MeasurementId = item.MeasurementId,
                                MucTieuThu = item.MucTieuThu,
                                NangLuongQuyDoi = item.NangLuongQuyDoi,
                                NgayCapNhat = DateTime.Now
                            });
                        }
                        //else if (oldData.Any(o => o.FuelId == item.FuelId && o.MeasurementId == item.MeasurementId && o.MucTieuThu != item.MucTieuThu))
                        else //Đã tồn tại=>Update
                        {
                            var x = oldData.Where(o => o.FuelId == item.FuelId && o.MeasurementId == item.MeasurementId).FirstOrDefault();
                            x.MucTieuThu = item.MucTieuThu;
                            x.NangLuongQuyDoi = item.NangLuongQuyDoi;
                        }
                    }
                }

                ctx.BC_SDNL_HangNam.AddRange(listData);
                //Save all changed
                ctx.SaveChanges();
            }

            return ReportId;
        }
    }

    private void SetYear(int id_dn, int ReportId)
    {
        using (var db = new ReportModels())
        {
            if (db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == id_dn && o.AutoID == ReportId && o.TrangThai == 0))
            {
                var rp = db.BC_SDNL_DS_TheoNam.Where(o => o.IdDN == id_dn && o.AutoID == ReportId && o.TrangThai == 0).FirstOrDefault();
                ddlNamBaoCao.SelectedValue = rp.NamBaoCao.ToString();
            }
            else
                ddlNamBaoCao.SelectedValue = DateTime.Now.Year.ToString();
        }
    }

    public class formdata
    {
        public int FuelId { get; set; }
        public int MeasurementId { get; set; }
        public decimal TOE { get; set; }
        public decimal MucTieuThu { get; set; }
        public decimal NangLuongQuyDoi { get; set; }
    }

    protected void btLuu_Click(object sender, EventArgs e)
    {
        try
        {
            int ReportId = GetData();

            int RpId = 0;
            if (Request.QueryString["RpId"] != null)
                int.TryParse(Request.QueryString["RpId"], out RpId);
            if (RpId > 0)
                CreateListFuel(RpId);
            else
                ListDefautlReport();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSendReport_Click(object sender, EventArgs e)
    {
        int Result = 0;
        string YKien = txtNoiDungYKien.Text.Trim();
        int rpYear = Convert.ToInt32(ddlNamBaoCao.SelectedValue);
        int OrgId = memberVal.OrgId;

        int RpId = 0;
        if (Request.QueryString["RpId"] != null)
            int.TryParse(Request.QueryString["RpId"], out RpId);

        RpId = GetData();

        try
        {
            using (var db = new ReportModels())
            {
                if (db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == OrgId && o.NamBaoCao == rpYear && o.AutoID == RpId))
                {
                    var Rp = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == RpId).FirstOrDefault();
                    if (Rp != null)
                    {
                        Rp.MoTaBaoCao = YKien;
                        if (Rp.TrangThai == 0)
                            Rp.TrangThai = 1;
                        if (Rp.TrangThai == 4)
                            Rp.TrangThai = 5;
                        Rp.NgayGuiBC = DateTime.Now;

                        //Nội dung comment
                        BC_SDNL_DS_TheoNam_Comment comment = new BC_SDNL_DS_TheoNam_Comment();
                        comment.ReportID = RpId;
                        comment.NoiDung = YKien;
                        comment.TaiKhoan = memberVal.UserName.ToUpper().Trim();
                        comment.ThoiGian = DateTime.Now;
                        db.BC_SDNL_DS_TheoNam_Comment.Add(comment);

                        Result = db.SaveChanges();

                        txtNoiDungYKien.Text = string.Empty;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (Result > 0)
        {
            string viewUrl = string.Format("dn-lap-bao-cao.aspx?RpId={0}&act=", RpId);
            Response.Redirect(viewUrl);
        }
    }

    protected void ddlNamBaoCao_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListDefautlReport();
    }

    protected void btnQuayLai_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/dn-su-dung-nang-luong.aspx");
    }

    private void BindComment(int ReportID)
    {
        using (var db = new ReportModels())
        {
            var comment = db.BC_SDNL_DS_TheoNam_Comment.Where(o => o.ReportID == ReportID && o.NoiDung != null).ToList();
            if (comment != null && comment.Count > 0)
            {
                rptComment.DataSource = comment;
                rptComment.DataBind();
            }
        }
    }
}