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

public partial class Client_Admin_DataEngery_SCTBaoCaoChoPheDuyetView : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int RpId = 0;
            if (Request.QueryString["Id"] != null)
                int.TryParse(Request.QueryString["Id"], out RpId);
            GetNamBaoCao(RpId);
            CreateListFuel(RpId);
            pnNoneAction.Visible = true;
            pnAction.Visible = false;
        }
    }

    private void GetNamBaoCao(int RpId)
    {
        using (var db = new ReportModels())
        {
            ltNamBaoCao.Text = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == RpId).First().NamBaoCao.ToString();
        }
    }


    private void CreateListFuel(int RpId)
    {
        MemberValidation memberVal = new MemberValidation();
        //memberVal.OrgId

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

                par3Temp += string.Format("<td><input value='{3}' readonly id=\"id_{0}_{1}_{2}\" TOEattr=\"{2}\" type=\"text\" /></td>", j.FuelId, j.MeasurementId, j.TOE, MucTieuThu);

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

    protected void btLuu_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    GetData();
        //    int RpId = 0;
        //    if (Request.QueryString["Id"] != null)
        //        int.TryParse(Request.QueryString["Id"], out RpId);
        //    if (RpId > 0)
        //        CreateListFuel(RpId);
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    protected void btnSendReport_Click(object sender, EventArgs e)
    {
        //string YKien = txtNoiDungYKien.Text.Trim();
        //int rpYear = Convert.ToInt32(ddlNamBaoCao.SelectedValue);
        //int OrgId = memberVal.OrgId;

        //int RpId = 0;
        //if (Request.QueryString["RpId"] != null)
        //    int.TryParse(Request.QueryString["RpId"], out RpId);

        //try
        //{
        //    using (var db = new ReportModels())
        //    {
        //        if (db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == OrgId && o.NamBaoCao == rpYear && o.AutoID == RpId))
        //        {
        //            var Rp = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == RpId).FirstOrDefault();
        //            if (Rp != null)
        //            {
        //                Rp.MoTaBaoCao = YKien;
        //                Rp.TrangThai = 1;
        //                Rp.NgayGuiBC = DateTime.Now;
        //                db.SaveChanges();

        //                txtNoiDungYKien.Text = string.Empty;
        //            }
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    protected void btnQuayLai_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SCTBaoCaoChoPheDuyet/Default.aspx");
    }

    protected void btPheDuyetBaoCao_Click(object sender, EventArgs e)
    {
        int RpId = 0;
        if (Request.QueryString["Id"] != null)
            int.TryParse(Request.QueryString["Id"], out RpId);
        if (RpId > 0)
        {
            using (var db = new ReportModels())
            {
                var rp = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == RpId).First();
                rp.NoiDungPheDuyetSCT = txtNoiDungYKien.Text.Trim();
                if (rdDongYBaoCao.Checked)
                {
                    rp.TrangThai = 3; //Đồng ý phê duyệt
                    rp.NgayDuyetBC = DateTime.Now;
                }
                else
                    rp.TrangThai = 4;//Yêu cầu hiệu chỉnh

                //Nội dung comment
                BC_SDNL_DS_TheoNam_Comment comment = new BC_SDNL_DS_TheoNam_Comment();
                comment.ReportID = RpId;
                comment.NoiDung = txtNoiDungYKien.Text.Trim();
                comment.TaiKhoan = m_UserValidation.UserName;
                comment.ThoiGian = DateTime.Now;
                db.BC_SDNL_DS_TheoNam_Comment.Add(comment);

                db.SaveChanges();

                Response.Redirect("~/Admin/SCTBaoCaoChoPheDuyet/Default.aspx");
            }
        }
    }

}