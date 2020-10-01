using ReportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Modules_DataEnergy_sdnl_dn_nhap_bao_cao : System.Web.UI.UserControl
{
    MemberValidation memberVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["__EVENTTARGET"] != null)
        {
            string target = Request["__EVENTTARGET"].ToString();
            if (target == btDelete.ClientID)
            {
                string parameter = Request["__EVENTARGUMENT"];
                DeleteReport(Convert.ToInt32(parameter));
            }
        }

        if (!IsPostBack)
        {
            ListBC_DangDuyet_ChuaGui();
            ListBC_DaDuyet();
        }

    }

    protected void btNhapBaoCao_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/dn-lap-bao-cao.aspx");
    }

    //List đang duyệt và chưa gửi
    private void ListBC_DangDuyet_ChuaGui()
    {
        List<int> choDuyet = new List<int>();
        choDuyet.Add(0); choDuyet.Add(1); choDuyet.Add(2); choDuyet.Add(4); choDuyet.Add(5);

        //Hiển thị view
        List<int> viewStatus = new List<int>();
        viewStatus.Add(1); viewStatus.Add(2); viewStatus.Add(5);

        using (var db = new ReportModels())
        {
            string rp = string.Empty;
            int OrgId = memberVal.OrgId;
            var srcExisted = db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == OrgId && choDuyet.Contains(o.TrangThai));

            if (srcExisted)
            {
                var src = db.BC_SDNL_DS_TheoNam.Where(o => o.IdDN == OrgId && choDuyet.Contains(o.TrangThai)).OrderByDescending(o => o.NgayLapBC).ToList();
                int counter = 1;
                foreach (var item in src)
                {
                    rp += "<tr>";
                    rp += string.Format("<td>{0}</td>", counter);
                    rp += string.Format("<td>{0}</td>", item.NamBaoCao);
                    rp += string.Format("<td>{0:dd/MM/yyyy}</td>", item.NgayLapBC);
                    if (item.NgayGuiBC == null)
                        rp += string.Format("<td>{0}</td>", "");
                    else
                        rp += string.Format("<td>{0:dd/MM/yyyy}</td>", item.NgayGuiBC);

                    rp += string.Format("<td>{0}</td>", Tool.TrangThaiBaoCao(item.TrangThai));

                    string editUrl = string.Format("dn-lap-bao-cao.aspx?RpId={0}", item.AutoID);
                    string btnEdit = string.Format("<a href='{0}'><i class=\"fa fa-edit\"></i></a>", editUrl);
                    string btnDelete = string.Format("<a href='javascript:DeleteBCChoGui({0})'><i class=\"fa fa-trash-o\"></i></a>", item.AutoID);
                    //
                    string viewUrl = string.Format("dn-lap-bao-cao.aspx?RpId={0}&act=", item.AutoID);
                    string btnView = string.Format("<a href='{0}'><i class=\"fa fa-search\"></i></a>", viewUrl);

                    if (viewStatus.Contains(item.TrangThai))
                        rp += string.Format("<td class=\"tex-center\" >{0}&nbsp</td>", btnView);
                    else
                        rp += string.Format("<td class=\"tex-center\" >{0}&nbsp;&nbsp;{1}</td>", btnEdit, btnDelete);
                    rp += "</tr>";
                    counter++;
                }
            }
            ltBaoCaoChuaGui.Text = rp;
        }
    }

    private void ListBC_DaDuyet()
    {
        List<int> choDuyet = new List<int>();
        choDuyet.Add(3);
        using (var db = new ReportModels())
        {
            string rp = string.Empty;
            int OrgId = memberVal.OrgId;
            var srcExisted = db.BC_SDNL_DS_TheoNam.Any(o => o.IdDN == OrgId && choDuyet.Contains(o.TrangThai));

            if (srcExisted)
            {
                var src = db.BC_SDNL_DS_TheoNam.Where(o => o.IdDN == OrgId && choDuyet.Contains(o.TrangThai)).OrderByDescending(o => o.NgayLapBC).ToList();
                int counter = 1;
                foreach (var item in src)
                {
                    rp += "<tr>";
                    rp += string.Format("<td>{0}</td>", counter);
                    rp += string.Format("<td>{0}</td>", item.NamBaoCao);
                    rp += string.Format("<td>{0:dd/MM/yyyy}</td>", item.NgayLapBC);
                    if (item.NgayGuiBC == null)
                        rp += string.Format("<td>{0}</td>", "");
                    else
                        rp += string.Format("<td>{0:dd/MM/yyyy}</td>", item.NgayGuiBC);

                    if (item.NgayDuyetBC == null)
                        rp += string.Format("<td>{0}</td>", "");
                    else
                        rp += string.Format("<td>{0:dd/MM/yyyy}</td>", item.NgayDuyetBC);

                    rp += string.Format("<td>{0}</td>", Tool.TrangThaiBaoCao(item.TrangThai));


                    //string editUrl = string.Format("dn-lap-bao-cao.aspx?RpId={0}", item.AutoID);
                    //string btnEdit = string.Format("<a href='{0}'><i class=\"fa fa-edit\"></i></a>", editUrl);
                    //string btnDelete = string.Format("<a href='javascript:DeleteBCChoGui({0})'><i class=\"fa fa-trash-o\"></i></a>", item.AutoID);
                    //rp += string.Format("<td class=\"tex-center\" >{0}&nbsp;&nbsp;{1}</td>", btnEdit, btnDelete);

                    string viewUrl = string.Format("dn-lap-bao-cao.aspx?RpId={0}&act=", item.AutoID);
                    string btnView = string.Format("<a href='{0}'><i class=\"fa fa-search\"></i></a>", viewUrl);
                    rp += string.Format("<td class=\"tex-center\" >{0}&nbsp</td>", btnView);
                    rp += "</tr>";
                    counter++;
                }
            }
            ltBaoCaoDaDuyet.Text = rp;
        }
    }


    private void DeleteReport(int ReportId)
    {
        using (var db = new ReportModels())
        {
            var rp = db.BC_SDNL_DS_TheoNam.Where(o => o.AutoID == ReportId).FirstOrDefault();
            db.BC_SDNL_HangNam.Where(o => o.IdDN == rp.IdDN && o.NamBaoCao == rp.NamBaoCao).FirstOrDefault().TrangThai = -1;
            rp.TrangThai = -1;
            db.SaveChanges();
            ListBC_DangDuyet_ChuaGui();
        }
    }
}
