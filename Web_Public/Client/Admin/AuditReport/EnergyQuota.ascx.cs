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

public partial class Client_Admin_DataEngery_EnergyQuota : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
                //ltAuditYear2.Text = ltAuditYear.Text = ltDataYear.Text = (ReportYear - 1).ToString();
                BindData();
               
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
            sb.Append("<table class='table table-bordered table-hover mbn' width='100%'>");
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
}