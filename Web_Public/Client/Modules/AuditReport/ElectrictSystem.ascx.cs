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
using System.Text;

public partial class Client_Module_DataEngery_ElectrictSystem : System.Web.UI.UserControl
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
            if (ReportId > 0)
            {
                BindMBA();
                BindSupply();
                btnAddFuelFuture.Visible = btnSave.Visible = btnSaveSupply.Visible = btnAddSelf.Visible = AllowEdit;
            }
        }
    }

    void BindMBA()
    {
        DataTable dt = new ElectricSupplyingService().GetElectrict(ReportId, false);
        rptMBA.DataSource = dt;
        rptMBA.DataBind();
    }
    void BindSupply()
    {
        DataTable dt = new ElectricSupplyingService().GetElectrict(ReportId, true);
        rptSelf.DataSource = dt;
        rptSelf.DataBind();
    }
    protected void rptSelf_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void rptMBA_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void btnEditMBA_Click(object sender, EventArgs e)
    {
        int MBAId = 0;
        LinkButton lbtnDelete = (LinkButton)sender;
        if (lbtnDelete != null)
        {
            MBAId = Convert.ToInt32(lbtnDelete.CommandArgument);
            ElectricSupplying obj = new ElectricSupplyingService().FindByKey(MBAId);
            if (obj != null)
            {
                hdnId.Value = obj.Id.ToString();
                if (obj.Capacity > 0)
                    txtCapacity.Text = obj.Capacity.ToString();
                if (obj.Coefficient > 0)
                    txtCoefficient.Text = obj.Coefficient.ToString();
                if (obj.Cos > 0)
                    txtCos.Text = obj.Cos.ToString();
                if (obj.PlacingCapacity > 0)
                    txtPlacingCapacity.Text = obj.PlacingCapacity.ToString();
                if (obj.Performance > 0)
                    txtPerformance.Text = obj.Performance.ToString();
                txtMBAName.Text = obj.DeviceName;
                txtVoltageLevel.Text = obj.VoltageLevel;
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictMBA();", true);
            }
        }
    }
    protected void btnEditSupply_Click(object sender, EventArgs e)
    {
        int MBAId = 0;
        LinkButton lbtnDelete = (LinkButton)sender;
        if (lbtnDelete != null)
        {
            MBAId = Convert.ToInt32(lbtnDelete.CommandArgument);
            ElectricSupplying obj = new ElectricSupplyingService().FindByKey(MBAId);
            if (obj != null)
            {
                hdnIdS.Value = obj.Id.ToString();
                if (obj.Capacity > 0)
                    txtCapacityS.Text = obj.Capacity.ToString();
                if (obj.Coefficient > 0)
                    txtCoefficientS.Text = obj.Coefficient.ToString();
                if (obj.Cos > 0)
                    txtCosS.Text = obj.Cos.ToString();
                if (obj.PlacingCapacity > 0)
                    txtPlacingCapacityS.Text = obj.PlacingCapacity.ToString();
                if (obj.Performance > 0)
                    txtPerformanceS.Text = obj.Performance.ToString();
                txtMBANameS.Text = obj.DeviceName;
                txtVoltageLevelS.Text = obj.VoltageLevel;
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictSupply();", true);
            }
        }
    }
    protected void btnDeleteMBA_Click(object sender, EventArgs e)
    {
        int MBAId = 0;
        LinkButton lbtnDelete = (LinkButton)sender;
        if (lbtnDelete != null)
        {
            MBAId = Convert.ToInt32(lbtnDelete.CommandArgument);
            long i = new ElectricSupplyingService().Delete(MBAId);
            if (i > 0)
            {
                BindMBA();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
    }

    protected void btnDeleteSupply_Click(object sender, EventArgs e)
    {
        int MBAId = 0;
        LinkButton lbtnDelete = (LinkButton)sender;
        if (lbtnDelete != null)
        {
            MBAId = Convert.ToInt32(lbtnDelete.CommandArgument);
            long i = new ElectricSupplyingService().Delete(MBAId);
            if (i > 0)
            {
                BindSupply();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
    }

    protected void btnSaveSupply_Click(object sender, EventArgs e)
    {
        ElectricSupplyingService otherService = new ElectricSupplyingService();
        ElectricSupplying electricSupplying = new ElectricSupplying();
        electricSupplying.AuditReportId = ReportId;
        electricSupplying.IsSelf = true;
        electricSupplying.PlacingCapacity = Convert.ToInt32(txtPlacingCapacityS.Text.Trim());
        electricSupplying.VoltageLevel = txtVoltageLevelS.Text.Trim();
        electricSupplying.DeviceName = txtMBANameS.Text.Trim();
        electricSupplying.Capacity = Convert.ToInt32(txtCapacityS.Text.Trim());
        electricSupplying.Cos = Convert.ToDecimal(txtCosS.Text.Trim());
        electricSupplying.Coefficient = Convert.ToDecimal(txtCoefficientS.Text.Trim());
        electricSupplying.Performance = Convert.ToDecimal(txtPerformanceS.Text.Trim());
        if (hdnIdS.Value != "" && Convert.ToInt32(hdnIdS.Value) > 0)
        {
            electricSupplying.Id = Convert.ToInt32(hdnIdS.Value);
            if (otherService.Update(electricSupplying) != null)
            {
                BindSupply();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictSupply();alert('Cập nhật không thành công');", true);
            }
        }
        else
        {
            if (otherService.Insert(electricSupplying) > 0)
            {
                BindSupply();
            }
            else
            { ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictSupply(); alert('Cập nhật không thành công');", true); }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ElectricSupplyingService otherService = new ElectricSupplyingService();
        ElectricSupplying electricSupplying = new ElectricSupplying();
        electricSupplying.AuditReportId = ReportId;
        electricSupplying.IsSelf = false;
        electricSupplying.PlacingCapacity = Convert.ToInt32(txtPlacingCapacity.Text.Trim());
        electricSupplying.VoltageLevel = txtVoltageLevel.Text.Trim();
        electricSupplying.DeviceName = txtMBAName.Text.Trim();
        electricSupplying.Capacity = Convert.ToInt32(txtCapacity.Text.Trim());
        electricSupplying.Cos = Convert.ToDecimal(txtCos.Text.Trim());
        electricSupplying.Coefficient = Convert.ToDecimal(txtCoefficient.Text.Trim());
        electricSupplying.Performance = Convert.ToDecimal(txtPerformance.Text.Trim());
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            electricSupplying.Id = Convert.ToInt32(hdnId.Value);
            if (otherService.Update(electricSupplying) != null)
            {
                BindMBA();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictMBA();alert('Cập nhật không thành công');", true);
            }
        }
        else
        {
            if (otherService.Insert(electricSupplying) > 0)
            {
                BindMBA();
            }
            else
            { ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictMBA(); alert('Cập nhật không thành công');", true); }
        }

    }
}