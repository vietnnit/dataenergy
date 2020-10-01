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
using System.Collections.Generic;
using System.Text;
using ETO;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;
using System.IO;


public partial class Client_Modules_DataEnergy_MyAuditReport : System.Web.UI.UserControl
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
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (memVal.IsSigned())
            {
                Tool.BindYear(ddlAuditYear, "Chọn năm", "");
                Tool.BindYear(ddlDataYear, "Chọn năm", "");
                BindData();
            }
            else
                Response.Redirect(ResolveUrl("~"));
        }

    }

    private void BindData()
    {
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (memVal.OrgId > 0)
        {
            DataTable list = new AuditReportService().FindList(0, 0, 0, memVal.OrgId, 0, 0, -1, 0, "", paging);
            rptAuditReport.DataSource = list;
            rptAuditReport.DataBind();
            if (list != null && list.Rows.Count > 0)
            {
                Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging.PageSize = PageSize;
                Paging.DataLoad();
                if (Paging.TotalPages > 1)
                {
                    Paging.Visible = true;
                }
                else
                {
                    Paging.Visible = false;
                }
            }
            else
            {
                Paging.Visible = false;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        AuditReportService faqsBSO = new AuditReportService();
        AuditReport report = faqsBSO.FindByKey(Convert.ToInt32(btnDelete.CommandArgument));
        if (report != null && report.Status > 0)
        {
            if (faqsBSO.Delete(Convert.ToInt32(btnDelete.CommandArgument)) > 0)
                BindData();
            else
            {
                Tool.Message(this.Page, "Xóa không thành công. Vui lòng thử lại");
            }
        }
        else
        {
            Tool.Message(this.Page, "Báo cáo đã được gửi đi đang được duyệt, bạn không thể xóa báo cáo này.");
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

    }
    protected void btnExcel_DirectClick(object sender, EventArgs e)
    {
        voidbindexcel(int.Parse(hddma.Value));
    }
    protected void btnAddReport_Click(object sender, EventArgs e)
    {
        if (memVal.OrgId > 0)
        {
            AuditReport report = new AuditReport();
            report.EnterpriseId = Convert.ToInt32(memVal.OrgId);
            report.AuditYear = Convert.ToInt32(ddlAuditYear.SelectedValue);
            report.DataYear = Convert.ToInt32(ddlDataYear.SelectedValue);
            report.AuditConsultancyName = txtAuditConsultant.Text.Trim();
            report.Address = txtAddress.Text.Trim();
            report.AuditorName = txtAuditor.Text.Trim();
            report.AuditingScope = txtAuditScope.Text.Trim();
            report.ShiftNo = Convert.ToInt32(rbtShiftNo.SelectedValue);
            report.AuditorCode = txtAuditorCode.Text.Trim();
            report.TaxNo = txtMST.Text.Trim();
            int ret = new AuditReportService().Insert(report);
            if (ret > 0)
            {
                Response.Redirect(ResolveUrl("~") + "bao-cao-so-kiem-toan-nl-" + ret + ".aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "addReport", "ShowDialogAuditReport();", true);
            }

        }
    }


    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }
    protected void rptAuditReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            Literal ltEdit = (Literal)e.Item.FindControl("ltEdit");
            LinkButton lbtDownload = (LinkButton)e.Item.FindControl("lbtDownload");
            if (item != null && item["PathFile"] != null && item["PathFile"].ToString() != "")
            {
                lbtDownload.Visible = true;
            }
            else
                lbtDownload.Visible = false;
            int status = 0;
            if (item != null && item["Status"] != DBNull.Value)
            {
                status = Convert.ToInt32(item["Status"]);
                if (status == 1 || status == 3)
                {
                    btnDelete.Visible = false;
                    ltEdit.Text = "<a class='' href='" + ResolveUrl("~") + "bao-cao-so-kiem-toan-nl-" + item["Id"] + ".aspx'><i class='fa fa-search'></i></a>";
                }
                else
                {
                    ltEdit.Text = "<a class='' href='" + ResolveUrl("~") + "bao-cao-so-kiem-toan-nl-" + item["Id"] + ".aspx'><i class='fa fa-edit'></i></a>";
                    if (status == 0)
                    {
                        btnDelete.Visible = true;
                        
                       
                    }
                    else
                    {
                        btnDelete.Visible = false;
                    }
                }
            }
            
        }
    }

    protected void rptAuditReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("WordComment"))
        {
            voidbindexcel(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
        }
    }
    protected void voidbindexcel(int Idbaocao)
    {
        #region get data
        WordExtend ex = new WordExtend();
        string temp = "TempReport/TemMauBaoCao" + drpmaubaocao.SelectedValue + ".dot";
        ex.OpenFile(Server.MapPath(ResolveUrl("~") + temp));
        Enterprise or = new Enterprise();
        EnterpriseService orser = new EnterpriseService();
        or = orser.FindByKey(memVal.OrgId);
        if (or != null)
            ex.WriteToMergeField("BC_Title", or.Title);
        else
            ex.WriteToMergeField("BC_Title", "");
        ex.WriteToMergeField("BC_Year", DateTime.Now.Year.ToString());
        ex.WriteToMergeField("BC_NgayLap", DateTime.Now.ToString("dd/MM/yyyy"));
        DataTable dt = new DataTable();
        DataTable dthientai = new DataTable();
        DataTable dtdukien = new DataTable();

        DataSet dshientai = new DataSet("tbl1");
        DataSet dsdukien = new DataSet("tbl1");
        if (memVal.OrgId > 0)
        {
            dt = new ReportFuelService().GetReportByxuatphieu(Idbaocao);
        }
        //   DataRow dr;
        dt.Columns.Add("dvnhietnang", typeof(string));
        dt.Columns.Add("dvnhieulieu", typeof(string));
        dthientai = dt.Clone();
        dtdukien = dt.Clone();
        foreach (DataRow item in dt.Rows)
        {
            if (Convert.ToBoolean(item["IsNextYear"]) == true)
            {
                DataRow workRow = null;
                workRow = dtdukien.NewRow();
                workRow = item;
                if (workRow["MeasurementName"].ToString().Contains("Mét khối"))
                {
                    workRow["dvnhietnang"] = "kJ/m3";
                }
                else
                {
                    workRow["dvnhietnang"] = "kJ/kg";
                }
                if (workRow["MeasurementName"].ToString().Contains("tấn") || workRow["MeasurementName"].ToString().Contains("Klg"))
                {
                    workRow["dvnhieulieu"] = "kJ/tấn";
                }
                else
                {
                    workRow["dvnhieulieu"] = "đ/m3";
                }
                workRow.AcceptChanges();
                dtdukien.ImportRow(workRow);
                dtdukien.AcceptChanges();
            }
            else
            {
                DataRow workRow = null;
                workRow = dthientai.NewRow();
                workRow = item;
                if (workRow["MeasurementName"].ToString().Contains("Mét khối"))
                {
                    workRow["dvnhietnang"] = "kJ/m3";
                }
                else
                {
                    workRow["dvnhietnang"] = "kJ/kg";
                }
                if (workRow["MeasurementName"].ToString().Contains("tấn") || workRow["MeasurementName"].ToString().Contains("Klg"))
                {
                    workRow["dvnhieulieu"] = "kJ/tấn";
                }
                else
                {
                    workRow["dvnhieulieu"] = "đ/m3";
                }
                workRow.AcceptChanges();
                dthientai.AcceptChanges();
                dthientai.ImportRow(workRow);

            }
        }
        dshientai.Merge(dthientai);
        if (dshientai.Tables.Count > 0)
        {
            dshientai.Tables[0].TableName = "tbl1";
            ex.WriteDataSetToMergeField(dshientai);
        }
        dsdukien.Merge(dtdukien);
        if (dsdukien.Tables.Count > 0)
        {
            dsdukien.Tables[0].TableName = "tbl2";
            ex.WriteDataSetToMergeField(dsdukien);
        }
        // dsg.Tables.Add(dst); 
        //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        #endregion
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/Bao-cao-nam-" + DateTime.Now.ToString("yyyy") + ".doc"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/Bao-cao-nam-" + DateTime.Now.ToString("yyyy") + ".doc")),
              ""
          ));
    }
    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        LinkButton lbtDownload = (LinkButton)sender;
        AuditReport report = new AuditReportService().FindByKey(Convert.ToInt32(lbtDownload.CommandArgument));
        if (report != null && report.PathFile != "")
        {
            string Filpath = Server.MapPath("~/UserFile/Report/" + report.PathFile);
            DownLoad(Filpath);
        }
    }

    public void DownLoad(string FName)
    {
        string path = FName;
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream"; // download […]
            Response.WriteFile(path);
            Response.End();
        }
    }
}
