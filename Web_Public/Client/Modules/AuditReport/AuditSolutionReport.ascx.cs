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

public partial class Client_Module_DataEngery_AuditSolutionReport : System.Web.UI.UserControl
{
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
            BindFuel();
            BindSolution();
            BindData();
            BindResultTKNL();
        }
    }

    void BindData()
    {
        btnAddPlan.Visible = btnAddSolution.Visible = btnSaveAddPlan.Visible = btnSaveSolution.Visible = AllowEdit;
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
        var listSearch = from o in list orderby o.FuelName ascending select o;

        ddlFuelType.DataSource = listSearch;
        ddlFuelType.DataValueField = "Id";
        ddlFuelType.DataTextField = "FuelName";
        ddlFuelType.DataBind();
        ddlFuelType.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

    }
    void BindSolution()
    {
        ddlSolution.Items.Clear();

        GiaiPhapService gps = new GiaiPhapService();
        DataTable lst = gps.GetGiaiPhepByEnerprise(memVal.OrgId);
        ddlSolution.DataSource = lst;
        ddlSolution.DataBind();
        ddlSolution.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));
    }
    protected void rptResultTKNL_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void rptResultTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            SaveSolution rpt = new SaveSolution();
            SaveSolutionService rptbso = new SaveSolutionService();
            if (rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument)) > 0)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Không xóa được. Vui lòng thử lại.');", true);
            }
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            SaveSolution rpt = new SaveSolution();
            SaveSolutionService rptbso = new SaveSolutionService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            hdnId.Value = rpt.Id.ToString();
            if (rpt.Budget > 0)
                txtBudget.Text = rpt.Budget.ToString();
            if (rpt.Quantity > 0)
                txtQuantity.Text = rpt.Quantity.ToString();
            if (rpt.TimeExecuted > 0)
                txtTimeExecuted.Text = rpt.TimeExecuted.ToString();
            if (rpt.FuelId > 0)
            {
                ddlFuelType.SelectedValue = rpt.FuelId.ToString();
                BindMeasurement();
                if (rpt.MeasurementFuelId > 0)
                {
                    ddlMeasure.SelectedValue = rpt.MeasurementFuelId.ToString();
                }
            }
            if (rpt.SolutionId > 0)
                ddlSolution.SelectedValue = rpt.SolutionId.ToString();

            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSaveSolution();", true);
        }
    }


    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        gp.EnterpriseId = memVal.OrgId;

        gp.MoTa = txtDes.Text;
        gp.TenGiaiPhap = txtSolutionName.Text;
        if (gpser.Insert(gp) > 0)
        {
            ltNoticeSolution.Text = "Lưu giải pháp mới thành công";
            BindSolution();
        }
        else
            ltNoticeSolution.Text = "Không lưu được giải pháp mới. Vui lòng thử lại";
    }

    private void BindResultTKNL()
    {
        SaveSolutionService plangpservice = new SaveSolutionService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetSaveSolution(ReportId);
        rptResultTKNL.DataSource = tbl;
        rptResultTKNL.DataBind();
    }
    public void btnSaveAddPlan_Click(object sender, EventArgs e)
    {
        SaveSolutionService saveSolutionService = new SaveSolutionService();
        SaveSolution plantknl = new SaveSolution();
        plantknl.EnterpriseId = memVal.OrgId;
        if (ddlFuelType.SelectedIndex > 0)
            plantknl.FuelId = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlMeasure.SelectedIndex > 0)
            plantknl.MeasurementFuelId = Convert.ToInt32(ddlMeasure.SelectedValue);
        if (ddlSolution.SelectedIndex > 0)
            plantknl.SolutionId = Convert.ToInt32(ddlSolution.SelectedValue);
        plantknl.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
        plantknl.Budget = Convert.ToDecimal(txtBudget.Text.Trim());
        plantknl.TimeExecuted = Convert.ToDecimal(txtTimeExecuted.Text.Trim());
        plantknl.AuditReportId = ReportId;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {            
            plantknl.Id = Convert.ToInt32(hdnId.Value);
            if (saveSolutionService.Update(plantknl) != null)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSaveSolution();", true);
                
            }
        }
        else
        {
            int i = saveSolutionService.Insert(plantknl);
            if (i > 0)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogAddSaveSolution();", true);
                
            }
        }
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSaveSolution();", true);
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
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
        if (ddlMeasure.Items.Count >= 2)
        {
            ddlMeasure.SelectedIndex = 1;
        }
    }
}