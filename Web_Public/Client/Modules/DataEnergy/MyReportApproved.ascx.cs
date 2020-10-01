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


public partial class Client_Modules_DataEnergy_MyReportApproved : System.Web.UI.UserControl
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
                BindData();
        }

    }
    private void BindData()
    {
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (memVal.OrgId > 0)
        {
            DataTable list = new ReportFuelService().FindList(false, 0, 0, 0, memVal.OrgId, 0, 0, 2, true, 0, null, null, "", paging);
            rptNoFuelCurrent.DataSource = list;
            rptNoFuelCurrent.DataBind();
            if (list.Rows.Count > 0)
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
        ReportFuelService faqsBSO = new ReportFuelService();
        if (faqsBSO.Delete(Convert.ToInt32(btnDelete.CommandArgument)) > 0)
            BindData();
        else
        {
            Tool.Message(this.Page, "Xóa không thành công. Vui lòng thử lại");
        }
    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

    }
    protected void btnExcel_DirectClick(object sender, EventArgs e)
    {
        voidbindexcel(int.Parse(hddma.Value));
    }
    protected void rptNoFuelFuture_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            //LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            Literal ltEdit = (Literal)e.Item.FindControl("btnEdit");
            ltEdit.Text = "<a href='" + ResolveUrl("~") + "bao-cao-so-lieu-hang-nam.aspx?ReportId=" + item["Id"] + "'><i class='fa fa-edit'></i></a>";
            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");            

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            //LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            //btnEdit.PostBackUrl = ResolveUrl("~") + "bao-cao-so-lieu-hang-nam.aspx?Id=" + btnEdit.CommandArgument;
            Literal ltEdit = (Literal)e.Item.FindControl("ltEdit");
            ltEdit.Text = "<a class='btn btn-info btn-xs fs14' href='" + ResolveUrl("~") + "bao-cao-so-lieu-hang-nam.aspx?Id=" + item["Id"] + "'><i class='fa fa-edit'></i></a>";
        }
    }
    protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e)
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
        or = orser.FindByKey(Convert.ToInt32(memVal.OrgId));
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
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/mauBaoCao.dot"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/mauBaoCao.dot")),
              ""
          ));
    }
}
