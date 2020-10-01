using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Web.UI;
using System.Linq;

public partial class Client_Admin_List_ListDistrictForEnterprise : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
                return 35;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    private int ProvinceId
    {
        get
        {
            if (ViewState["ProvinceId"] != null)
                return Convert.ToInt32(ViewState["ProvinceId"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["ProvinceId"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            BindProvince();
            BindData();
        }

    }
    void BindProvince()
    {
        IList<Province> list = new List<Province>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
        {
            list = new ProvinceService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
        }
        else
            list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            OrganizationService objOrganizationService = new OrganizationService();
            Organization objOrganization = new Organization();
            objOrganization = objOrganizationService.FindByKey(m_UserValidation.OrgId);
            if (objOrganization != null && objOrganization.ProvinceId > 0)
            {
                ProvinceId = objOrganization.ProvinceId;
            }
        }
        if (ProvinceId > 0)
        {

            try
            {
                if (list != null && list.Count > 0)
                {
                    var listProvince = list.Where(m => m.Id == ProvinceId).ToList();
                    ddlProvince.DataSource = listProvince;
                    ddlProvince.DataTextField = "ProvinceName";
                    ddlProvince.DataValueField = "Id";
                    ddlProvince.DataBind();

                    ddlParent.DataSource = listProvince;
                    ddlParent.DataTextField = "ProvinceName";
                    ddlParent.DataValueField = "Id";
                    ddlParent.DataBind();

                    ddlProvince.SelectedValue = ProvinceId.ToString();
                    ddlParent.SelectedValue = ProvinceId.ToString();
                }
            }
            catch { }
        }
        ddlProvince.Items.Insert(0, new ListItem("---Tất cả---", ""));
        ddlParent.Items.Insert(0, new ListItem("---Chọn---", ""));
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
    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        if (grvArea.Rows != null && grvArea.Rows.Count > 2)
        {
            foreach (GridViewRow row in grvArea.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                if (textOrder != null && textOrder.Text != "" && textOrder.Text.Trim() != "")
                {
                    int pOrder = Convert.ToInt32(textOrder.Text);
                    int pID = Convert.ToInt32(row.Cells[0].Text);
                    District objDistrict = new District();
                    objDistrict = new DistrictService().FindByKey(pID);
                    if (objDistrict != null)
                    {
                        objDistrict.SortOrder = pOrder;
                        new DistrictService().Update(objDistrict);
                    }
                }
            }
        }
    }

    void BindData()
    {
        DistrictService comBSO = new DistrictService();
        DataTable list = new DataTable();
        int _provinceId = 0;
        string strKey = string.Empty;
        if (ddlProvince.SelectedValue != "")
            _provinceId = Convert.ToInt32(ddlProvince.SelectedValue);

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
        {
            strKey = txtKeyword.Text.Trim();
        }
        if (_provinceId > 0)
        {
            list = new DistrictService().FindList(ProvinceId, strKey, paging);
        }
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltrTotal.Text = "Tổng số " + paging.RowsCount + " quận huyện";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " quận huyện";
                Paging.Visible = true;
            }
        }
        else
        {
            ltrTotal.Text = "";
            Paging.Visible = false;
        }
        grvArea.DataSource = list;
        grvArea.DataBind();
    }

    #endregion

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    void UpdateOrAdd()
    {
        int cId = 0;
        if (hdnEditId.Value != "" && hdnEditId.Value != "0")
        {
            cId = Convert.ToInt32(hdnEditId.Value);
        }
        DistrictService objlogic = new DistrictService();
        District obj = new District();
        obj.DistrictName = txtTitle.Text.Trim();
        obj.DistrictCode = txtCode.Text.Trim();
        try
        {
            obj.SortOrder = Convert.ToInt32(txtSorOrder.Text);
        }
        catch { }
        if (ddlParent.SelectedIndex > 0)
            obj.ProvinceId = Convert.ToInt32(ddlParent.SelectedValue);

        if (cId > 0)
        {
            obj.Id = cId;
            if (objlogic.Update(obj) != null)
            {
                BindData();
                clientview.Text = "<div class='alert alert-primary'>Cập nhật thành công !</div>";
            }
            else
                clientview.Text = "<div class='alert alert-dangers'>Cập nhật không thành công !</div>";
        }
        else
        {
            if (objlogic.Insert(obj) > 0)
            {
                BindData();
                clientview.Text = "<div class='alert alert-primary'>Thêm mới thành công !</div>";

            }
            else
                clientview.Text = "<div class='alert alert-dangers'>Thêm mới không thành công !</div>";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateOrAdd();
    }

    protected void grvArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iEditId = 0;
        iEditId = Convert.ToInt32(e.CommandArgument.ToString());
        string aName = e.CommandName.ToLower();
        if (iEditId > 0)
        {
            DistrictService objlogic = new DistrictService();
            if (aName.Contains("_edit"))
            {

                District obj = new District();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    hdnEditId.Value = iEditId.ToString();
                    txtCode.Text = obj.DistrictCode;
                    txtSorOrder.Text = obj.SortOrder.ToString();
                    txtTitle.Text = obj.DistrictName;
                    if (obj.ProvinceId > 0)
                        ddlParent.SelectedValue = obj.ProvinceId.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updatedistrict();", true);
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
