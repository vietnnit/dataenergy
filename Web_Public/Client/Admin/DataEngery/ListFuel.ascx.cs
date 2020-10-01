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
public partial class Client_Admin_ListFuel : System.Web.UI.UserControl
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            BindGroupFuel();
            BindMeasurement();
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

            ddlGroupFuel.DataSource = listSearch;
            ddlGroupFuel.DataTextField = "Title";
            ddlGroupFuel.DataValueField = "Id";
            ddlGroupFuel.DataBind();
        }
        else
        {
            ddlParent.DataSource = null;
            ddlParent.DataBind();

            ddlGroupFuel.DataSource = null;
            ddlGroupFuel.DataBind();


        }
        ddlParent.Items.Insert(0, new ListItem("---Tất cả---", ""));
        ddlGroupFuel.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    #region ViewNewsGroup

    void BindMeasurement()
    {
        IList<Measurement> list = new List<Measurement>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Measurement_All))
        {
            list = new MeasurementService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Measurement_All, list);
        }
        else
            list = (IList<Measurement>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Measurement_All);
        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list orderby o.MeasurementName ascending select o;
            ddlMeasurement.DataSource = listSearch;
            ddlMeasurement.DataTextField = "MeasurementName";
            ddlMeasurement.DataValueField = "Id";
            ddlMeasurement.DataBind();

            ddlMeasurement1.DataSource = listSearch;
            ddlMeasurement1.DataTextField = "MeasurementName";
            ddlMeasurement1.DataValueField = "Id";
            ddlMeasurement1.DataBind();
        }
        else
        {
            ddlMeasurement.DataSource = null;
            ddlMeasurement.DataBind();

            ddlMeasurement1.DataSource = null;
            ddlMeasurement1.DataBind();
        }
        ddlMeasurement.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
        ddlMeasurement1.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
    }
    void BindData()
    {
        FuelService objFuelService = new FuelService();
        DataTable list = new DataTable();
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        int groupId = 0;
        string strKey = string.Empty;
        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        if (ddlParent.SelectedIndex > 0)
            groupId = Convert.ToInt32(ddlParent.SelectedValue);

        list = objFuelService.FindFuelList(strKey, 0, groupId, paging, true);
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltrTotal.Text = "Tổng số " + paging.RowsCount + " nhiên liệu";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " nhiên liệu";
                Paging.Visible = true;
            }
        }
        else
        {
            ltrTotal.Text = "";
            Paging.Visible = false;
        }
        grvFuel.DataSource = list;
        grvFuel.DataBind();
    }
    #endregion

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }


    protected void btnSaveTOE_Click(object sender, EventArgs e)
    {
        MeasurementFuelService measurementFuelService = new MeasurementFuelService();
        MeasurementFuel objMeasurementFuel = new MeasurementFuel();
        int mId = 0;
        int fid = 0;
        if (hdnToeId.Value != "")
        {
            try
            {
                mId = Convert.ToInt32(hdnToeId.Value.Trim());
            }
            catch
            { }
        }
        if (hdnfuelid.Value != "")
        {
            try
            {
                fid = Convert.ToInt32(hdnfuelid.Value.Trim());
            }
            catch
            { }
        }
        if (txtNoCO2.Text != "")
        {
            objMeasurementFuel.NoCO2 = Convert.ToDecimal(txtNoCO2.Text.Trim());
        }
        if (txttoeFrom.Text != "" && txttoeFrom.Text.Trim() != "" && ddlMeasurement1.SelectedValue != "" && fid > 0)
        {
            if (ddlMeasurement1.SelectedValue != "")
                objMeasurementFuel.MeasurementId = Convert.ToInt32(ddlMeasurement1.SelectedValue);
            objMeasurementFuel.FuelId = fid;
            decimal dfrom = 0;
            decimal dto = 0;
            try
            {
                dfrom = Convert.ToDecimal(txttoeFrom.Text);
            }
            catch
            {
            }
            if (txttoeto.Text != "" && txttoeto.Text.Trim() != "")
            {
                try
                {
                    dto = Convert.ToDecimal(txttoeto.Text.Trim());
                }
                catch
                {
                }
            }
            if (dfrom > 0)
            {
                objMeasurementFuel.From_TOE = dfrom;
                objMeasurementFuel.TOE = dfrom;
            }
            if (dto >= 0 && dto > dfrom)
            {
                objMeasurementFuel.To_TOE = dto;
            }

            if (mId > 0)
            {
                objMeasurementFuel.Id = mId;
                if (measurementFuelService.Update(objMeasurementFuel) != null)
                {
                    BindData();
                    hdnToeId.Value = "0";
                    hdnfuelid.Value = "0";
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "showupdatetoefuel();", true);
            }
            else
            {
                if (measurementFuelService.Insert(objMeasurementFuel) > 0)
                {
                    BindData();
                    hdnToeId.Value = "0";
                    hdnfuelid.Value = "0";
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "addtoefuel();", true);
            }
        }
    }
    protected void btnDeleteTOE_Click(object sender, EventArgs e)
    {
        int mId = 0;
        if (hdnToeId.Value != "")
        {
            try
            {
                mId = Convert.ToInt32(hdnToeId.Value.Trim());
            }
            catch
            { }
            if (mId > 0)
            {
                long iDelete = 0;
                iDelete = new MeasurementFuelService().Delete(mId);
                if (iDelete > 0)
                {
                    BindData();
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FuelService fuelService = new FuelService();
        Fuel fuel = new Fuel();
        int FuelId = 0;
        if (hdnEditId.Value != "")
        {
            try
            {
                FuelId = Convert.ToInt32(hdnEditId.Value.Trim());
            }
            catch
            { }
        }
        fuel.FuelName = txtTitle.Text.Trim();
        if (ddlGroupFuel.SelectedIndex > 0)
            fuel.GroupFuelId = Convert.ToInt32(ddlGroupFuel.SelectedValue);
        if (ddlMeasurement.SelectedIndex > 0)
            fuel.MeasurementId = Convert.ToInt32(ddlMeasurement.SelectedValue);
        if (FuelId > 0)
        {
            fuel.Id = FuelId;
            if (fuelService.Update(fuel) != null)
            {
                BindData();
                hdnEditId.Value = "0";
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateFuel();", true);
        }
        else
        {
            int id = fuelService.Insert(fuel);
            if (id > 0)
            {
                MeasurementFuelService measurementFuelService = new MeasurementFuelService();
                MeasurementFuel objMeasurementFuel = new MeasurementFuel();
                if (txtNoCO2_S.Text != "")
                {
                    objMeasurementFuel.NoCO2 = Convert.ToDecimal(txtNoCO2_S.Text.Trim());
                }
                if (txtFromTOE_S.Text != "" && txtToTOE_S.Text.Trim() != "" && ddlMeasurement.SelectedValue != "" && id > 0)
                {
                    if (ddlMeasurement.SelectedValue != "")
                        objMeasurementFuel.MeasurementId = Convert.ToInt32(ddlMeasurement.SelectedValue);
                    objMeasurementFuel.FuelId = fuel.Id;
                    decimal dfrom = 0;
                    decimal dto = 0;
                    try
                    {
                        dfrom = Convert.ToDecimal(txtFromTOE_S.Text);
                    }
                    catch
                    {
                    }
                    if (txtToTOE_S.Text != "" && txtToTOE_S.Text.Trim() != "")
                    {
                        try
                        {
                            dto = Convert.ToDecimal(txtToTOE_S.Text.Trim());
                        }
                        catch
                        {
                        }
                    }
                    if (dfrom > 0)
                    {
                        objMeasurementFuel.From_TOE = dfrom;
                        objMeasurementFuel.TOE = dfrom;
                    }
                    if (dto >= 0 && dto > dfrom)
                    {
                        objMeasurementFuel.To_TOE = dto;

                    }

                }
                measurementFuelService.UpdateTOE(objMeasurementFuel.FuelId, objMeasurementFuel.MeasurementId, objMeasurementFuel.From_TOE, objMeasurementFuel.To_TOE);
                BindData();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "addFuel();", true);
        }

    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void grvFuel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string aId = e.CommandArgument.ToString();
        string aName = e.CommandName.ToLower();
        int fid = 0;
        try
        {
            fid = Convert.ToInt32(aId);
        }
        catch { }

        if (fid > 0)
        {
            Fuel fuel = new FuelService().FindByKey(fid);
            if (fuel != null)
            {
                if (aName.Contains("_edit"))
                {
                    hdnEditId.Value = fid.ToString();
                    txtTitle.Text = fuel.FuelName;
                    try
                    {
                        if (fuel.GroupFuelId > 0)
                            ddlGroupFuel.SelectedValue = fuel.GroupFuelId.ToString();
                    }
                    catch { }
                    try
                    {
                        if (fuel.MeasurementId > 0)
                            ddlMeasurement.SelectedValue = fuel.MeasurementId.ToString();
                    }
                    catch { }
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateFuel();", true);
                }
                else if (aName.Contains("_delete"))
                {
                    long iDelete = 0;
                    iDelete = new FuelService().Delete(fid);
                    if (iDelete > 0)
                    {
                        BindData();
                    }
                }
            }
        }
    }

    protected void grvFuel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal ltTOE = (Literal)e.Row.FindControl("ltTOE");
            Literal ltCO2 = (Literal)e.Row.FindControl("ltCO2");

            int fid = Convert.ToInt32(grvFuel.DataKeys[e.Row.RowIndex].Values[0]);
            DataTable dt = new MeasurementFuelService().GetMeasurementByFuel(fid);
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbCO2 = new StringBuilder();
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
                        strscript = "'" + dt.Rows[i]["Id"].ToString() + "','" + dt.Rows[i]["FuelName"].ToString() + "','" + dt.Rows[i]["FuelId"].ToString() + "','" + Tool.ConvertDecimalToString(dfrom) + "','" + Tool.ConvertDecimalToString(dto) + "','" + (dt.Rows[i]["NoCO2"] != DBNull.Value ? Tool.ConvertDecimalToString(dt.Rows[i]["NoCO2"]) : "") + "','" + dt.Rows[i]["MeasurementId"].ToString() + "'";
                        sb.Append("<p><strong>" + dt.Rows[i]["MeasurementName"] + "</strong>: " + Tool.ConvertDecimalToString(dfrom) + " - " + Tool.ConvertDecimalToString(dto) + "<a class='pull-right' title='Xóa hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-remove_2 fs18 text-danger'></span></a><a class='pull-right' title='Cập nhật hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-edit fs18'></span>&nbsp;&nbsp;</a></p><hr/>");
                    }
                    else
                    {

                        strscript = "'" + dt.Rows[i]["Id"].ToString() + "','" + dt.Rows[i]["FuelName"].ToString() + "','" + dt.Rows[i]["FuelId"].ToString() + "','" + Tool.ConvertDecimalToString(dfrom) + "','','" + (dt.Rows[i]["NoCO2"] != DBNull.Value ? Tool.ConvertDecimalToString(dt.Rows[i]["NoCO2"]) : "") + "','" + dt.Rows[i]["MeasurementId"].ToString() + "'";
                        sb.Append("<p><strong>" + dt.Rows[i]["MeasurementName"] + "</strong>: " + Tool.ConvertDecimalToString(dfrom) + "<a class='pull-right' title='Xóa hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-remove_2 fs18 text-danger'></span></a><a class='pull-right' title='Cập nhật hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-edit fs18'></span>&nbsp;&nbsp;</a></p><hr/>");
                    }
                    if (dt.Rows[i]["NoCO2"] != DBNull.Value)
                        sbCO2.Append("<p><strong>" + dt.Rows[i]["MeasurementName"] + "</strong>: " + Tool.ConvertDecimalToString(dt.Rows[i]["NoCO2"]) + "<a class='pull-right' title='Xóa hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-remove_2 fs18 text-danger'></span></a><a class='pull-right' title='Cập nhật hệ số quy đổi' onclick=\"javascript:updatetoefuel(" + strscript + ");return false;\"><span class='glyphicons glyphicons-edit fs18'></span>&nbsp;&nbsp;</a></p><hr/>");
                }
                ltTOE.Text = sb.ToString();
                ltCO2.Text = sbCO2.ToString();
            }
        }
    }
}
