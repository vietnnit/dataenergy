using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data;
using System.Web.UI;
public partial class Client_Admin_List_ListProvince : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            BindRegion();
            BindData();
        }

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

    void BindRegion()
    {
        IList<Region> list = new List<Region>();
        if (!AspNetCache.CheckCache("Cache_List_Region_All"))
        {
            list = new RegionService().FindAll();
            AspNetCache.SetCache("Cache_List_Region_All", list);
        }
        else
            list = (IList<Region>)AspNetCache.GetCache("Cache_List_Region_All");

        ddlRegion.DataSource = list;
        ddlRegion.DataTextField = "RegionName";
        ddlRegion.DataValueField = "Id";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("---Chọn---", ""));

        ddlRegionSearch.DataSource = list;
        ddlRegionSearch.DataTextField = "RegionName";
        ddlRegionSearch.DataValueField = "Id";
        ddlRegionSearch.DataBind();
        ddlRegionSearch.Items.Insert(0, new ListItem("---Tất cả---", ""));
    }

    void BindData()
    {
        ProvinceService comBSO = new ProvinceService();
        DataTable listSearch = new DataTable();
        int regionId = 0;
        string strKey = string.Empty;
        if (ddlRegionSearch.SelectedValue != "")
            regionId = Convert.ToInt32(ddlRegionSearch.SelectedValue);

        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        listSearch = comBSO.GetProvinceList(strKey, regionId);
        if (listSearch != null && listSearch.Rows.Count > 0)
        {
            grvProvince.DataSource = listSearch;
            grvProvince.DataBind();
            clientview.Text = "Tổng số " + listSearch.Rows.Count + " tỉnh/thành phố";
        }
        else
        {
            grvProvince.DataSource = null;
            grvProvince.DataBind();
        }
    }
    #endregion
    protected void btn_Order_Click(object sender, EventArgs e)
    {
        if (grvProvince.Rows != null && grvProvince.Rows.Count > 2)
        {
            foreach (GridViewRow row in grvProvince.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                if (textOrder != null && textOrder.Text != "" && textOrder.Text.Trim() != "")
                {
                    int pOrder = Convert.ToInt32(textOrder.Text);
                    int pID = Convert.ToInt32(row.Cells[0].Text);
                    Province objProvince = new Province();
                    objProvince = new ProvinceService().FindByKey(pID);
                    if (objProvince != null)
                    {
                        objProvince.SortOrder = pOrder;
                        new ProvinceService().Update(objProvince);
                    }
                }
            }
            BindData();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateOrAdd();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        BindData();
    }

    void UpdateOrAdd()
    {
        int cId = 0;
        if (hdnEditId.Value != "" && hdnEditId.Value != "0")
        {
            cId = Convert.ToInt32(hdnEditId.Value);
        }
        ProvinceService objlogic = new ProvinceService();
        Province obj = new Province();
        obj.ProvinceName = txtTitle.Text.Trim();
        obj.ProvinceCode = txtProvinceCode.Text.Trim();
        try
        {
            obj.SortOrder = Convert.ToInt32(txtSorOrder.Text);
        }
        catch { }
        try
        {
            if (ddlRegion.SelectedIndex > 0)
                obj.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
        }
        catch { }
        if (cId > 0)
        {
            obj.Id = cId;
            if (objlogic.Update(obj) != null)
            {
                BindData();
                error.Text = "<div class='alert alert-primary'>Cập nhật thành công !</div>";
            }
            else
                error.Text = "<div class='alert alert-dangers'>Cập nhật không thành công !</div>";
        }
        else
        {
            if (objlogic.Insert(obj) > 0)
            {
                BindData();
                error.Text = "<div class='alert alert-primary'>Thêm mới thành công !</div>";

            }
            else
                error.Text = "<div class='alert alert-dangers'>Thêm mới không thành công !</div>";
        }
    }

    protected void grvProvince_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iEditId = 0;
        iEditId = Convert.ToInt32(e.CommandArgument.ToString());
        string aName = e.CommandName.ToLower();
        if (iEditId > 0)
        {
            ProvinceService objlogic = new ProvinceService();
            if (aName.Contains("_edit"))
            {

                Province obj = new Province();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    hdnEditId.Value = iEditId.ToString();
                    txtProvinceCode.Text = obj.ProvinceCode;
                    txtSorOrder.Text = obj.SortOrder.ToString();
                    txtTitle.Text = obj.ProvinceName;
                    try
                    {
                        if (obj.RegionId > 0)
                            ddlRegion.SelectedValue = obj.RegionId.ToString();
                    }
                    catch { }
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateprovince();", true);
                }
            }
            else if (aName.Contains("_delete"))
            {
                if (objlogic.Delete(Convert.ToInt32(iEditId)) > 0)
                {
                    BindData();
                }
            }
        }
    }

}
