using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data;
using System.Web.UI;
public partial class Client_Modules_List_ListOrganization : System.Web.UI.UserControl
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

        if (!IsPostBack)
        {
            BindProvince();
            BindData();
        }

    }

    private void BindData()
    {
        OrganizationService comBSO = new OrganizationService();
        DataTable list = new DataTable();
        int provinceId = 0;
        if (ddlProvinceSearch.SelectedIndex > 0)
            provinceId = Convert.ToInt32(ddlProvinceSearch.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.FindOrganizationList(txtKeyword.Text.Trim(), provinceId, paging, true);
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltrTotal.Text = "Có tổng số " + paging.RowsCount + " đơn vị";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " đơn vị";
                Paging.Visible = true;
            }

        }
        else
        {
            ltrTotal.Text = "";
            Paging.Visible = false;
        }
        grvOrg.DataSource = list;
        grvOrg.DataBind();
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
        var listSearch = from o in list orderby o.ProvinceName ascending select o;
        ddlProvinceSearch.DataSource = listSearch;
        ddlProvinceSearch.DataTextField = "ProvinceName";
        ddlProvinceSearch.DataValueField = "Id";
        ddlProvinceSearch.DataBind();
        ddlProvinceSearch.Items.Insert(0, new ListItem("---Tất cả---"));
    }



    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

}
