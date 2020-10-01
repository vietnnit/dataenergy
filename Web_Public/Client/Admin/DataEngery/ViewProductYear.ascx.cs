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

public partial class Client_Admin_DataEngery_ViewProductYear : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
    int PlanId
    {
        get
        {
            if (ViewState["PlanId"] != null && ViewState["PlanId"].ToString() != "")
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
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out Id);
            ReportId = Id;
            BindData();
            if (ReportId > 0)
            {
                BindInfrastructure();
                BindProductCapacity();
                BindProductCapacityPlan();
                BindElectrictPlan();
                BindElectrictResult();
            }
        }
    }

    void BindData()
    {
        Enterprise enter = new Enterprise();
        if (m_UserValidation.OrgId > 0)
        {
            enter = new EnterpriseService().FindByKey(m_UserValidation.OrgId);
            if (enter != null)
            {
                ltActiveYear.Text = enter.ActiveYear.ToString();
            }
        }

        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        //ltOldYear.Text = ("I. Kết quả thực hiện năm " + ReportYear.ToString()).ToUpper();
        //ltNextYear.Text = ("II. Kế hoạch thực hiện năm " + (ReportYear + 1).ToString()).ToUpper();
        //}
        //btnEditElecttrict.Visible = btnEditElectrictPlan.Visible = btnEditInfo.Visible = AllowEdit; ;

    }

    protected void rptProductResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item["NoFuel_TOE"] != DBNull.Value)
            //{
            //    No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            //}            

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptProductResult_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }


    protected void rptProductPlan_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void rptProductPlan_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item["NoFuel_TOE"] != DBNull.Value)
            //{
            //    No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            //}            

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }


    void BindInfrastructure()
    {
        Infrastructure infra = new Infrastructure();
        InfrastructureService infraService = new InfrastructureService();

        infra = infraService.GetInfrastructureByReport(ReportId);
        if (infra != null)
        {
            if (infra.ProduceAreaNo > 0)
                ltProduceArea.Text = infra.ProduceAreaNo.ToString();
            if (infra.OfficeAreaNo > 0)
                ltOfficeArea.Text = infra.OfficeAreaNo.ToString();
            if (infra.ProduceEmployeeNo > 0)
                ltProduceEmployeeNo.Text = infra.ProduceEmployeeNo.ToString();
            if (infra.OfficeEmployeeNo > 0)
                ltOfficeEmployeeNo.Text = infra.OfficeEmployeeNo.ToString();
        }
    }
    void BindElectrictResult()
    {
        UsingElectrict usingElectrict = new UsingElectrict();
        UsingElectrictService usingElectrictService = new UsingElectrictService();
        try
        {
            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, false);
            if (usingElectrict != null)
            {
                if (usingElectrict.InstalledCapacity > 0)
                    ltInstalledResult.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                else
                    ltInstalledResult.Text = "";
                if (usingElectrict.Capacity > 0)
                    ltCapacityResult.Text = usingElectrict.Capacity.ToString() + "(kV)";
                else
                    ltCapacityResult.Text = "";
                if (usingElectrict.BuyCost > 0)
                    ltCostTotalResult.Text = usingElectrict.BuyCost.ToString() + "(10<sup>3</sup>đồng)";
                else
                    ltCostTotalResult.Text = "";
                if (usingElectrict.ProduceQty > 0)
                    ltQuantityProduceResult.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                else
                    ltQuantityProduceResult.Text = "";
                if (usingElectrict.Technology != null)
                    ltTechnologyResult.Text = usingElectrict.Technology.ToString();

                if (usingElectrict.Quantity > 0)
                    ltQuantityResult.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                else
                    ltQuantityResult.Text = "";
                Fuel fuel = new Fuel();
                if (usingElectrict.FuelId > 0)
                {
                    fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                    if (fuel != null)
                    {
                        ltFuelResult.Text = fuel.FuelName;
                    }
                }

            }
        }
        catch { }
    }
    void BindElectrictPlan()
    {
        UsingElectrict usingElectrict = new UsingElectrict();
        UsingElectrictService usingElectrictService = new UsingElectrictService();
        try
        {
            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
            if (usingElectrict != null)
            {
                if (usingElectrict.InstalledCapacity > 0)
                    ltInstalledCapacityPlan.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                else
                    ltInstalledCapacityPlan.Text = "";
                if (usingElectrict.Capacity > 0)
                    ltCapacityPlan.Text = usingElectrict.Capacity.ToString() + "(kV)";
                else
                    ltCapacityPlan.Text = "";
                if (usingElectrict.BuyCost > 0)
                    ltPriceBuyPlan.Text = usingElectrict.BuyCost.ToString() + "(đồng/kWh)";
                else
                    ltPriceBuyPlan.Text = "";
                if (usingElectrict.ProduceQty > 0)
                    ltQuantityProducePlan.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                else
                    ltQuantityProducePlan.Text = "";
                if (usingElectrict.Technology != null)
                    ltTecnologyPlan.Text = usingElectrict.Technology.ToString();

                if (usingElectrict.Quantity > 0)
                    ltQuantityElectrictPlan.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                else
                    ltQuantityElectrictPlan.Text = "";
                if (usingElectrict.PriceProduce > 0)
                    ltPriceProducePlan.Text = usingElectrict.PriceProduce.ToString() + "(đồng/kWh)";
                else
                    ltPriceProducePlan.Text = "";

                Fuel fuel = new Fuel();
                if (usingElectrict.FuelId > 0)
                {
                    fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                    if (fuel != null)
                    {
                        ltFuelPlan.Text = fuel.FuelName;
                    }
                }
            }
        }
        catch { }
    }
    private void BindProductCapacity()
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, false);
        rptProductResult.DataSource = tbl;
        rptProductResult.DataBind();
    }
    private void BindProductCapacityPlan()
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, true);
        rptProductPlan.DataSource = tbl;
        rptProductPlan.DataBind();
    }
}