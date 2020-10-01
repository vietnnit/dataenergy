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

public partial class Client_Module_DataEngery_EnergyQuota : System.Web.UI.UserControl
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
            BindProduct();
            BindFuel();
            BindData();
            if (ReportId > 0)
            {
                //ltAuditYear2.Text = ltAuditYear.Text = ltDataYear.Text = (ReportYear - 1).ToString();
                BindQuota();
                btnAddFuelFuture.Visible = btnDelete.Visible = btnSave.Visible = AllowEdit;
            }
        }
    }

    void BindData()
    {
        IList<Fuel> listFuel = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            listFuel = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, listFuel);
        }
        else
            listFuel = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        var listSearchFuel = from o in listFuel orderby o.FuelName ascending select o;

        IList<Product> list = new List<Product>();
        list = new ProductService().GetListByEnterprise(memVal.OrgId);
        var listProduct = from o in list where o.IsProduct == true select o;
        EnergyQuotaService consumseService = new EnergyQuotaService();

        DataTable dt = consumseService.GetDataByFuel(ReportId);
        if (listProduct != null && listProduct.Count() > 0)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbSub = new StringBuilder();
            StringBuilder sbData = new StringBuilder();
            sb.Append("<table class='table table-bordered table-hover mbn'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th>Sản phẩm</th>");
            for (int i = 0; i < listSearchFuel.Count(); i++)
            {
                sb.Append("<th>" + listSearchFuel.ToList()[i].FuelName + "</th>");
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            for (int j = 0; j < listProduct.Count(); j++)
            {
                sbData.Append("<tr>");
                sbData.Append("<td>" + listProduct.ToList()[j].ProductName + "</td>");
                for (int i = 0; i < listSearchFuel.Count(); i++)
                {
                    DataRow[] dr = dt.Select("FuelId=" + listSearchFuel.ToList()[i].Id.ToString() + " AND ProductId=" + listProduct.ToList()[j].Id);
                    if (dr != null && dr.Count() > 0)
                    {

                        sbData.Append("<td class='text-right'>" + dr[0]["Quantity"] + "</td>");
                    }
                    else
                        sbData.Append("<td class='text-right'>-</td>");
                }
                sbData.Append("</tr>");
            }
            sb.Append(sbData.ToString());
            sb.Append("</table>");
            ltQuota.Text = sb.ToString();
        }

    }
    void BindFuelMearsurement()
    {
        EnergyQuotaService consumseService = new EnergyQuotaService();
        int ProductId = 0;
        if (ddlProduct.SelectedIndex > 0)
            ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
        int FuelId = 0;
        if (ddlFuel.SelectedIndex > 0)
            FuelId = Convert.ToInt32(ddlFuel.SelectedValue);

        DataTable dt = consumseService.GetDataByFuel(ReportId, ProductId, FuelId);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Quantity"] != null)
                txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            ddlMeasure.SelectedValue = dt.Rows[0]["MeasurementId"].ToString();
        }
        else
            txtQuantity.Text = "";
    }

    void BindQuota()
    {
        EnergyQuotaService consumseService = new EnergyQuotaService();
        int ProductId = 0;
        if (ddlProduct.SelectedIndex > 0)
            ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
        DataTable dt = consumseService.GetDataByFuel(ReportId, ProductId);
        rptDataQuota.DataSource = dt;
        rptDataQuota.DataBind();
    }


    void BindProduct()
    {
        ddlProduct.Items.Clear();
        IList<Product> list = new List<Product>();
        list = new ProductService().GetListByEnterprise(memVal.OrgId);
        var listProduct = from o in list where o.IsProduct == true select o;
        ddlProduct.DataSource = listProduct;
        ddlProduct.DataValueField = "Id";
        ddlProduct.DataTextField = "ProductName";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("---Chọn sản phẩm---", ""));
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            int ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
            EnergyQuotaService otherService = new EnergyQuotaService();
            if (otherService.DeleteByProduct(ReportId, ProductId) >= 0)
            {
                ltErrConsume.Text = "Xóa thành công";
                BindData();
                BindQuota();
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);
            }
        }
        
    }


    void BindFuel()
    {
        ddlFuel.Items.Clear();
        IList<Fuel> list = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            list = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, list);
        }
        else
            list = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        var listSearch = from o in list orderby o.FuelName ascending select o;
        ddlFuel.DataSource = listSearch;
        ddlFuel.DataValueField = "Id";
        ddlFuel.DataTextField = "FuelName";
        ddlFuel.DataBind();
        ddlFuel.Items.Insert(0, new ListItem("---Chọn nhiên liệu---", ""));
        if (ddlFuel.Items.Count == 2)
            ddlFuel.SelectedIndex = 1;
        BindMeasurement();
    }

    void BindMeasurement()
    {
        ddlMeasure.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuel.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuel.SelectedValue));
        }

        ddlMeasure.DataSource = list;
        ddlMeasure.DataValueField = "Id";
        ddlMeasure.DataTextField = "MeasurementName";
        ddlMeasure.DataBind();
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
        if (ddlMeasure.Items.Count == 2)
        {
            ddlMeasure.SelectedIndex = 1;

        }
    }
    protected void btnDeleteFuel_Click(object sender, EventArgs e)
    {
        int FuelId = 0;
        LinkButton lbtnDelete = (LinkButton)sender;
        if (lbtnDelete != null)
        {
            FuelId = Convert.ToInt32(lbtnDelete.CommandArgument);
            int i = new EnergyQuotaService().DeleteByFuel(ReportId, Convert.ToInt32(ddlProduct.SelectedValue), FuelId);
            if (i > 0)
            {
                BindData();
                BindQuota();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);
    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        EnergyQuotaService otherService = new EnergyQuotaService();
        EnergyQuota energyQuota = new EnergyQuota();
        energyQuota.ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
        energyQuota.FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        energyQuota.MeasurementId = Convert.ToInt32(ddlMeasure.SelectedValue);
        energyQuota.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
        energyQuota.AuditReportId = ReportId;
        energyQuota.PlanOfYear = ReportYear;
        otherService.DeleteByFuel(ReportId, Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt32(ddlFuel.SelectedValue));
        if (otherService.Insert(energyQuota) > 0)
        {
            BindQuota();
            BindData();
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindQuota();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);
    }
    protected void ddlMeasure_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindFuelConsume();
        //ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);
    }
    protected void ddlFuelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFuel();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        BindFuelMearsurement();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogQuota();", true);

    }

}