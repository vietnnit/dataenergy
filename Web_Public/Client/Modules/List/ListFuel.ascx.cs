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
using ETO;
using BSO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Text;
public partial class Client_Modules_List_ListFuel : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroupFuel();
            BindData();
        }
    }

    void BindGroupFuel()
    {
        IList<GroupFuel> list = new List<GroupFuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
        {
            list = new GroupFuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, list);
        }
        else
            list = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);
        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list orderby o.SortOrder ascending select o;
            ddlParent.DataSource = listSearch;
            ddlParent.DataTextField = "Title";
            ddlParent.DataValueField = "Id";
            ddlParent.DataBind();
        }
        else
        {
            ddlParent.DataSource = null;
            ddlParent.DataBind();
        }
        ddlParent.Items.Insert(0, new ListItem("---Tất cả---", ""));

    }
    void BindData()
    {
        FuelService objFuelService = new FuelService();
        DataTable list = new DataTable();
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(1000, 1);
        int groupId = 0;
        string strKey = string.Empty;

        if (ddlParent.SelectedIndex > 0)
            groupId = Convert.ToInt32(ddlParent.SelectedValue);

        list = objFuelService.FindFuelList(strKey, 0, groupId, paging, true);

        grvFuel.DataSource = list;
        grvFuel.DataBind();
    }

    protected void grvFuel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal ltTOE = (Literal)e.Row.FindControl("ltTOE");
            int fid = Convert.ToInt32(grvFuel.DataKeys[e.Row.RowIndex].Values[0]);
            DataTable dt = new MeasurementFuelService().GetMeasurementByFuel(fid);
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                decimal dfrom = 0;
                decimal dto = 0;
                string strscript = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try { dfrom = Convert.ToDecimal(dt.Rows[i]["From_TOE"]); }
                    catch { }
                    try { dto = Convert.ToDecimal(dt.Rows[i]["To_TOE"]); }
                    catch { }

                    if (dfrom < dto)
                    {
                        strscript = "'" + dt.Rows[i]["Id"].ToString() + "','" + dt.Rows[i]["FuelName"].ToString() + "','" + dt.Rows[i]["FuelId"].ToString() + "','" + dfrom + "','" + dto + "','" + dt.Rows[i]["MeasurementId"].ToString() + "'";
                        sb.Append("<p><strong>" + dt.Rows[i]["MeasurementName"] + "</strong>: " + dfrom.ToString("G29") + " - " + dto.ToString("G29") + "</p>");
                    }
                    else
                    {
                        strscript = "'" + dt.Rows[i]["Id"].ToString() + "','" + dt.Rows[i]["FuelName"].ToString() + "','" + dt.Rows[i]["FuelId"].ToString() + "','" + dfrom + "','','" + dt.Rows[i]["MeasurementId"].ToString() + "'";
                        sb.Append("<p><strong>" + dt.Rows[i]["MeasurementName"] + "</strong>: " + dfrom.ToString("G29") + "</p>");
                    }
                }
                ltTOE.Text = sb.ToString();
            }
        }
    }
}
