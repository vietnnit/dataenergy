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

public partial class Client_Module_AuditReport_AuditOperationArea : System.Web.UI.UserControl
{
    MemberValidation memVal = new MemberValidation();
    public int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"].ToString() != "")
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
            if (ViewState["ReportYear"] != null && ViewState["ReportYear"].ToString() != "")
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
            if (ViewState["AllowEdit"] != null && ViewState["AllowEdit"].ToString() != "")
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
            BindData();
            if (ReportId > 0)
            {
                BindOperation();
            }
        }
    }

    void BindData()
    {
        Enterprise enter = new Enterprise();
        if (memVal.OrgId > 0)
        {
            enter = new EnterpriseService().FindByKey(memVal.OrgId);
            if (enter != null)
            {
                ///ltActiveYear.Text = enter.ActiveYear.ToString();
            }
        }

        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        //ltOldYear.Text = ("I. Kết quả thực hiện năm " + ReportYear.ToString()).ToUpper();
        //ltNextYear.Text = ("II. Kế hoạch thực hiện năm " + (ReportYear + 1).ToString()).ToUpper();
        //}
        btnAddOperation.Visible = btnSave.Visible = AllowEdit; ;

    }

    protected void rptOperation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

        }
    }
    protected void rptOperation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            OperationAreaService operationAreaService = new OperationAreaService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            long i = operationAreaService.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindOperation();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            OperationAreaService operationAreaService = new OperationAreaService();
            OperationArea operationArea = new ePower.DE.Domain.OperationArea();
            int OperationId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            operationArea = operationAreaService.FindByKey(OperationId);
            if (operationArea != null)
            {
                try
                {
                    if (operationArea.OperationHours > 0)
                        txtHours.Text = operationArea.OperationHours.ToString();
                    txtAreaName.Text = operationArea.AreaName;
                }
                catch { }
                hdnId.Value = OperationId.ToString();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogOperation(" + hdnId.Value + ");", true);
        }
    }

    public void btnSave_Click(object sender, EventArgs e)
    {
        OperationAreaService operationAreaService = new OperationAreaService();
        OperationArea operationArea = new ePower.DE.Domain.OperationArea();
        operationArea.AreaName = txtAreaName.Text.Trim();
        operationArea.AuditReportId = ReportId;
        operationArea.OperationHours = Convert.ToInt32(txtHours.Text.Trim());
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            operationArea.Id = Convert.ToInt32(hdnId.Value);
            if (operationAreaService.Update(operationArea) != null)
            {
                BindOperation();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogOperation(" + hdnId.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = operationAreaService.Insert(operationArea);
            if (i <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogOperation();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
            else
            {
                BindOperation();
            }
        }

    }

    private void BindOperation()
    {
        OperationAreaService operationAreaService = new OperationAreaService();
        DataTable list = new DataTable();
        list = operationAreaService.GetOperationByReport(ReportId);
        rptOperation.DataSource = list;
        rptOperation.DataBind();
    }

}