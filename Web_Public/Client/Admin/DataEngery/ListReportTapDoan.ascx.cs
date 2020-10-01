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
public partial class Client_Admin_DataEngery_ListReportTapDoan : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            bind();
        }
    }
    void BindYear()
    {
        for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 20; i--)
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        ddlYear.Items.Insert(0, new ListItem("---Chọn---", ""));
        ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
    }
    public void bind()
    {        
        ReportService rptbso = new ReportService();
        DataTable tbl = new DataTable();
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        DateTime begin = new DateTime();
        DateTime end = new DateTime();
                
        if (txtStartDateTime.Text.ToString() != "")
        {
            begin = DateTime.ParseExact(txtStartDateTime.Text, "dd/MM/yyyy", culture);
        }
        if (txtEndDateTime.Text != "")
        {
            end = DateTime.ParseExact(txtEndDateTime.Text, "dd/MM/yyyy", culture);
        }
        if (txtStartDateTime.Text.ToString() != "" && txtEndDateTime.Text != "")
        {
            tbl = rptbso.GetReportByEnerprise(m_UserValidation.OrgId, begin, end, txtKeyword.Text);
        }
        else
        {
            tbl = rptbso.GetReportByEnerprise(m_UserValidation.OrgId, null, null, txtKeyword.Text);
        }
        rptNoFuelCurrent.DataSource = tbl;
        rptNoFuelCurrent.DataBind();
    }
    protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            Report rpt = new Report();
            ReportService rptbso = new ReportService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            bind();
            //   voidbindexcel(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
        }
        else if (e.CommandName.Equals("edit"))
        {
            Report rpt = new Report();
            ReportService rptbso = new ReportService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));

            if (rpt != null)
            {
                hddvalue.Value = rpt.Id.ToString();
                //txttieude.Text = rpt.Title;
                try
                {
                    ddlYear.SelectedValue = rpt.Title;
                }
                catch { }
                txtmota.Text = rpt.Des;
                hddngaytao.Value = rpt.ReportDate.ToString();
                txtNgaytao.Text = String.Format("{0:dd/MM/yyyy}", rpt.ReportDate);
                txtfile.Text = rpt.FilePath;
                ScriptManager.RegisterStartupScript(this, GetType(), "ad", "showforms(0);", true);
            }

        }
    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        bind();
    }

    protected void btnsave_DirectClick(object sender, EventArgs e)
    {
        try
        {
            Report rpt = new Report();
            ReportService rptbso = new ReportService();            
            if (Convert.ToInt32(hddvalue.Value == "" ? "0" : hddvalue.Value) < 1)
            {
                rpt.Title = ddlYear.SelectedValue;
                rpt.CreateByUser = m_UserValidation.UserId;
                rpt.Createdate = DateTime.Now;
                rpt.Des = txtmota.Text;
                rpt.EnterpriseId = 0;
                //rpt.Title = txttieude.Text;
                rpt.OrganizationId = m_UserValidation.OrgId;
                rpt.ModifileByUser = 0;
                rpt.ModifileDate = DateTime.Now;
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                rpt.ReportDate = DateTime.ParseExact(txtNgaytao.Text, "dd/MM/yyyy", culture);
                rpt.IsApproval = true;
                if (ffile.HasFile)
                {
                    string fileName = "Upload/" + ffile.FileName;
                    string filePath = Server.MapPath(ResolveUrl("~") + fileName);
                    ffile.SaveAs(filePath);
                    rpt.FilePath = fileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ad", "alert('Bạn Chưa chọn file!');", true);
                    return;
                }
                int i = rptbso.Insert(rpt);
                if (i > 0)
                {                    
                    bind();
                }
                else
                {
                    clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thất bại !</div>";
                }
            }
            else
            {
                rpt = rptbso.FindByKey(Convert.ToInt32(hddvalue.Value.ToString()));
                rpt.Title = ddlYear.SelectedValue;
                rpt.ModifileByUser = m_UserValidation.UserId;
                rpt.ModifileDate = DateTime.Now;
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                rpt.ReportDate = DateTime.ParseExact(txtNgaytao.Text, "dd/MM/yyyy", culture);
                rpt.Title = ddlYear.SelectedValue;
                rpt.Des = txtmota.Text;
                rpt.IsApproval = true;
                if (ffile.HasFile)
                {
                    string fileName = "Upload/" + ffile.FileName;
                    string filePath = Server.MapPath(ResolveUrl("~") + fileName);
                    ffile.SaveAs(filePath);
                    rpt.FilePath = fileName;
                }
                else
                {
                    rpt.FilePath = txtfile.Text;
                }
                int i = rptbso.Update(rpt);
                if (i > 0)
                {                    
                    bind();
                }
                else
                {
                    clientview.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thất bại !</div>";
                }
            }
        }
        catch (Exception ex)
        { }
    }
}