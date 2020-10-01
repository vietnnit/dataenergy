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

public partial class Client_Module_Audit_AuditDevice : System.Web.UI.UserControl
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
                BindFuel();
                BindElectricMotors();
                BindFurnaces();
                BindCompressor();
                BindBoiler();
            }
        }
    }

    void BindData()
    {
        //Enterprise enter = new Enterprise();
        //if (memVal.OrgId > 0)
        //{
        //    enter = new EnterpriseService().FindByKey(memVal.OrgId);
        //    if (enter != null)
        //    {
        //        ///ltActiveYear.Text = enter.ActiveYear.ToString();
        //    }
        //}
        btnAddBoiler.Visible = btnAddCompressor.Visible = btnAddElectrict.Visible = btnAddFurnaces.Visible = btnSaveC.Visible = btnSaveB.Visible = btnSaveE.Visible = btnSaveF.Visible = AllowEdit; ;

    }

    void BindFuel()
    {
        ddlFuelB.Items.Clear();
        IList<Fuel> list = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            list = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, list);
        }
        else
            list = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
      
        var listSearch = from o in list orderby o.FuelName ascending select o;
        ddlFuelB.DataSource = listSearch;
        ddlFuelB.DataValueField = "Id";
        ddlFuelB.DataTextField = "FuelName";
        ddlFuelB.DataBind();
        ddlFuelB.Items.Insert(0, new ListItem("---Chọn nhiên liệu---", ""));
        if (ddlFuelB.Items.Count == 2)
            ddlFuelB.SelectedIndex = 1;

        ddlFuelF.Items.Clear();

        ddlFuelF.DataSource = listSearch;
        ddlFuelF.DataValueField = "Id";
        ddlFuelF.DataTextField = "FuelName";
        ddlFuelF.DataBind();
        ddlFuelF.Items.Insert(0, new ListItem("---Chọn nhiên liệu---", ""));
        if (ddlFuelF.Items.Count == 2)
            ddlFuelF.SelectedIndex = 1;   
    }
    

    public void btnSaveC_Click(object sender, EventArgs e)
    {
        CompressorService productCapacityService = new CompressorService();
        Compressor productCapacity = new Compressor();

        if (txtPressureC.Text.Trim() != "")
            productCapacity.Pressure = Convert.ToDecimal(txtPressureC.Text.Trim());
        if (txtPressureLVC.Text.Trim() != "")
            productCapacity.PressureLV = Convert.ToDecimal(txtPressureLVC.Text.Trim());
        if (txtQuantityC.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToInt32(txtQuantityC.Text.Trim());
        if (txtHoursC.Text.Trim() != "")
            productCapacity.OperationHours = Convert.ToInt32(txtHoursC.Text.Trim());
        if (txtCapacityC.Text.Trim() != "")
            productCapacity.Capacity = Convert.ToDecimal(txtCapacityC.Text.Trim());
        productCapacity.AuditReportId = ReportId;
        

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogCompressor(" + hdnId.Value + ");", true);            
        }
        else
        {
            BindCompressor();
        }

    }
    
    public void btnSaveB_Click(object sender, EventArgs e)
    {
        BoilerService productCapacityService = new BoilerService();
        Boiler productCapacity = new Boiler();
        productCapacity.BoilerName = txtDeviceNameB.Text.Trim();
        if (txtQuantityB.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToInt32(txtQuantityB.Text.Trim());
        if (txtHoursB.Text.Trim() != "")
            productCapacity.OperationHours = Convert.ToInt32(txtHoursB.Text.Trim());
        if (txtCapacityB.Text.Trim() != "")
            productCapacity.CapacityInstalled = Convert.ToDecimal(txtCapacityB.Text.Trim());
        if (ddlFuelB.SelectedIndex>0)
            productCapacity.FuelId = Convert.ToInt32(ddlFuelB.SelectedValue);
        productCapacity.AuditReportId = ReportId;

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogCompress(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindBoiler();
        }

    }
    public void btnSaveF_Click(object sender, EventArgs e)
    {
        FurnacesService productCapacityService = new FurnacesService();
        Furnaces productCapacity = new Furnaces();
        productCapacity.DeviceName = txtDeviceNameF.Text.Trim();
        if (txtQuantityF.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToInt32(txtQuantityF.Text.Trim());
        if (txtHoursF.Text.Trim() != "")
            productCapacity.OperationHours = Convert.ToInt32(txtHoursF.Text.Trim());
        if (txtCapacityF.Text.Trim() != "")
            productCapacity.CapacityInstalled = Convert.ToDecimal(txtCapacityF.Text.Trim());
        if (ddlFuelF.SelectedIndex>0)
            productCapacity.FuelId = Convert.ToInt32(ddlFuelF.SelectedValue);
        productCapacity.AuditReportId = ReportId;

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFurnaces(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindFurnaces();
        }

    }
    public void btnSaveE_Click(object sender, EventArgs e)
    {
        ElectricMotorsService productCapacityService = new ElectricMotorsService();
        ElectricMotors productCapacity = new ElectricMotors();
        productCapacity.ElectricMotorsName = txtDeviceNameE.Text.Trim();
        if (txtQuantityE.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToInt32(txtQuantityE.Text.Trim());
        if (txtHoursE.Text.Trim() != "")
            productCapacity.OperationHours = Convert.ToInt32(txtHoursE.Text.Trim());
        if (txtCapacityE.Text.Trim() != "")
            productCapacity.Capacity = Convert.ToDecimal(txtCapacityE.Text.Trim());
        if (txtCapacityUse.Text.Trim() != "")
            productCapacity.CapacityUsed = Convert.ToDecimal(txtCapacityUse.Text.Trim());
        productCapacity.AuditReportId = ReportId;

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectricMotor(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindElectricMotors();
        }

    }
    protected void rptCompressor_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            CompressorService productCapacityService = new CompressorService();
            long i = productCapacityService.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindCompressor();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            Compressor productCapacity = new Compressor();
            CompressorService productCapacityService = new CompressorService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                txtDeviceNameC.Text = productCapacity.CompressorName;
                if (productCapacity.Quantity > 0)
                    txtQuantityC.Text = productCapacity.Quantity.ToString();
                if (productCapacity.Capacity > 0)
                    txtCapacityC.Text = productCapacity.Capacity.ToString();
                if (productCapacity.Pressure > 0)
                    txtPressureC.Text = productCapacity.Pressure.ToString();
                if (productCapacity.PressureLV > 0)
                    txtPressureLVC.Text = productCapacity.PressureLV.ToString();
                if (productCapacity.OperationHours > 0)
                    txtHoursC.Text = productCapacity.OperationHours.ToString();
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogCompressor(" + hdnId.Value + ");", true);
        }
    }
    protected void rptCompressor_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void rptBoiler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            BoilerService productCapacityService = new BoilerService();
            long i = productCapacityService.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindBoiler();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            Boiler productCapacity = new Boiler();
            BoilerService productCapacityService = new BoilerService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                txtDeviceNameB.Text = productCapacity.BoilerName;
                if (productCapacity.Quantity > 0)
                    txtQuantityB.Text = productCapacity.Quantity.ToString();
                if (productCapacity.CapacityInstalled > 0)
                    txtCapacityB.Text = productCapacity.CapacityInstalled.ToString();
                if (productCapacity.FuelId > 0)
                    ddlFuelB.SelectedValue = productCapacity.FuelId.ToString();
                if (productCapacity.OperationHours > 0)
                    txtHoursB.Text = productCapacity.OperationHours.ToString();
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogBoiler(" + hdnId.Value + ");", true);
        }
    }
    protected void rptBoiler_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

        }
    }
    
    protected void rptFurnaces_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            FurnacesService productCapacityService = new FurnacesService();
            long i = productCapacityService.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindFurnaces();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            Furnaces productCapacity = new Furnaces();
            FurnacesService productCapacityService = new FurnacesService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                txtDeviceNameF.Text = productCapacity.DeviceName;
                if (productCapacity.Quantity > 0)
                    txtQuantityF.Text = productCapacity.Quantity.ToString();
                if (productCapacity.CapacityInstalled > 0)
                    txtCapacityF.Text = productCapacity.CapacityInstalled.ToString();
                if (productCapacity.FuelId > 0)
                    ddlFuelF.SelectedValue = productCapacity.FuelId.ToString();
                if (productCapacity.OperationHours > 0)
                    txtHoursF.Text = productCapacity.OperationHours.ToString();
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogFurnaces(" + hdnId.Value + ");", true);
        }
    }
    protected void rptFurnaces_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void rptElectricMotors_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            ElectricMotorsService productCapacityService = new ElectricMotorsService();
            long i = productCapacityService.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindElectricMotors();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            ElectricMotors productCapacity = new ElectricMotors();
            ElectricMotorsService productCapacityService = new ElectricMotorsService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                txtDeviceNameE.Text = productCapacity.ElectricMotorsName;
                if (productCapacity.Quantity > 0)
                    txtQuantityE.Text = productCapacity.Quantity.ToString();
                if (productCapacity.Capacity > 0)
                    txtCapacityE.Text = productCapacity.Capacity.ToString();
                if (productCapacity.CapacityUsed > 0)
                    txtCapacityUse.Text = productCapacity.CapacityUsed.ToString();
                if (productCapacity.OperationHours > 0)
                    txtHoursE.Text = productCapacity.OperationHours.ToString();
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogElectricMotor(" + hdnId.Value + ");", true);
        }
    }
    protected void rptElectricMotors_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    private void BindCompressor()
    {
        CompressorService productConsumeService = new CompressorService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetCompressorByReport(ReportId);
        rptCompressor.DataSource = tbl;
        rptCompressor.DataBind();
    }
    private void BindBoiler()
    {
        BoilerService productConsumeService = new BoilerService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetBoilerList(ReportId);
        rptBoiler.DataSource = tbl;
        rptBoiler.DataBind();
    }
    private void BindFurnaces()
    {
        FurnacesService productConsumeService = new FurnacesService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetFurnacesByReport(ReportId);
        rptFurnaces.DataSource = tbl;
        rptFurnaces.DataBind();
    }
    private void BindElectricMotors()
    {
        ElectricMotorsService productConsumeService = new ElectricMotorsService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetElectricMotorsByReport(ReportId);
        rptElectricMotors.DataSource = tbl;
        rptElectricMotors.DataBind();
    }
  
   
}