using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePower.DE.Domain;
using ePower.DE.Service;

public partial class Client_Modules_DataEnergy_ListProduct : System.Web.UI.UserControl
{
    MemberValidation m_UserValidation = new MemberValidation();
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
            Tool.BindYear(ddlYearStart, "--Tất cả--", "");
            Tool.BindYear(ddlYearEnd, "--Tất cả--", "");
            Tool.BindYear(ddlYearStartUpdate, "--Chọn năm--", "");
            Tool.BindYear(ddlYearEndUpdate, "--Chọn năm--", "");
            ddlYearStart.SelectedIndex = 0;
            //ddlYearStart.SelectedValue = DateTime.Now.AddYears(-2).ToString("yyyy");
            ddlYearEnd.SelectedIndex = 0;
            BindData();
        }
    }

    private void BindData()
    {
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            ProductService productService = new ProductService();
            ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
            int startYear = 0;
            int endYear = 0;
            int isproduct = -1;
            string strKey = string.Empty;
            string strTotalInfo = string.Empty;
            if (txtKeyword.Text != "" && txtKeyword.Text.Trim() != "")
            {
                strKey = txtKeyword.Text.Trim();
            }
            if (ddlYearStart.SelectedIndex > 0)
                startYear = Convert.ToInt32(ddlYearStart.SelectedValue);
            if (ddlYearEnd.SelectedIndex > 0)
                endYear = Convert.ToInt32(ddlYearEnd.SelectedValue);
            if (ddlType.SelectedValue != "")
                isproduct = Convert.ToInt32(ddlType.SelectedValue);
            DataTable lstProduct = new DataTable();
            lstProduct = productService.FindProductList(startYear, endYear, isproduct, strKey, m_UserValidation.OrgId, paging, true);
            if (lstProduct != null && lstProduct.Rows.Count > 0)
            {
                paging.RowsCount = Convert.ToInt32(lstProduct.Rows[0]["Total"]);
                Paging.PageSize = PageSize;
                Paging.CurrentPage = CurrentPage;
                Paging.TotalRecord = Convert.ToInt32(lstProduct.Rows[0]["Total"]);
                Paging.DataLoad();
                if (paging.PagesCount <= 1)
                {
                    strTotalInfo = "Tổng số " + paging.RowsCount + " sản phẩm";
                    Paging.Visible = false;
                }
                else
                {
                    int st = (CurrentPage - 1) * PageSize + 1;
                    long end = CurrentPage * PageSize;
                    if (end > paging.RowsCount)
                        end = paging.RowsCount;
                    strTotalInfo = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " sản phẩm";
                    Paging.Visible = true;
                }
                rptProduct.DataSource = lstProduct;
                rptProduct.DataBind();
            }
            else
            {
                rptProduct.DataSource = null;
                rptProduct.DataBind();
                strTotalInfo = "Không tìm thấy sản phẩm nào";
                Paging.Visible = false;
            }
            ltrTotal.Text = strTotalInfo;
        }
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void btn_delete_product_Click(object sender, EventArgs e)
    {
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            LinkButton btnDelete = (LinkButton)sender;
            int iId = 0;
            iId = Convert.ToInt32(btnDelete.CommandArgument);
            if (iId > 0)
            {
                ProductService objProductService = new ProductService();
                Product obj = new Product();
                if (objProductService.Delete(iId) > 0)
                {
                    BindData();
                }
            }
        }
    }
    protected void btn_edit_product_Click(object sender, EventArgs e)
    {
        if (m_UserValidation != null && m_UserValidation.OrgId > 0)
        {
            LinkButton btn_update = (LinkButton)sender;
            int iEditId = 0;
            iEditId = Convert.ToInt32(btn_update.CommandArgument);
            if (iEditId > 0)
            {
                Product product = new Product();
                product = new ProductService().FindByKey(iEditId);
                if (product != null)
                {
                    hdnEditId.Value = iEditId.ToString();
                    txtProductName.Text = product.ProductName;
                    txtQuantity.Text = product.Quantity.ToString();
                    txtMeasurement.Text = product.Measurement;
                    try
                    {
                        ddlYearStartUpdate.SelectedValue = product.YearStart.ToString();
                    }
                    catch { }
                    try
                    {
                        ddlYearEndUpdate.SelectedValue = product.YearEnd.ToString();
                    }
                    catch { }
                    txtNote.Text = product.Note;
                    if (product.IsProduct == true)
                        cbxIsproduct1.Checked = true;
                    else cbxIsproduct0.Checked = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateproduct();", true);
                }
            }
        }
    }

    public void btnSave_Click(object sender, EventArgs e)
    {
        if (hdnEditId.Value != "" && hdnEditId.Value != "0")
        {
            int iEditId = 0;
            iEditId = Convert.ToInt32(hdnEditId.Value);
            if (iEditId > 0)
            {
                ProductService objProductService = new ProductService();
                Product product = new Product();
                product = objProductService.FindByKey(iEditId);
                if (product != null)
                {
                    product.ProductName = txtProductName.Text;
                    if (txtQuantity.Text != "" && txtQuantity.Text.Trim() != "")
                    {
                        try
                        {
                            product.Quantity = Convert.ToDecimal(txtQuantity.Text);
                        }
                        catch { product.Quantity = 0; }
                    }
                    else product.Quantity = 0;
                    product.Measurement = txtMeasurement.Text;
                    if (ddlYearStartUpdate.SelectedValue != "")
                        product.YearStart = Convert.ToInt32(ddlYearStartUpdate.SelectedValue);
                    if (ddlYearEndUpdate.SelectedValue != "")
                        product.YearEnd = Convert.ToInt32(ddlYearEndUpdate.SelectedValue);
                    product.Note = txtNote.Text;
                    if (cbxIsproduct1.Checked)
                        product.IsProduct = true;
                    else product.IsProduct = false;
                    if (objProductService.Update(product) != null)
                    {
                        BindData();
                        ltNotice.Text = "<div class='alert alert-info'>Cập nhật " + product.ProductName + " thành công !</div>";
                    }
                    else ltNotice.Text = "<div class='alert alert-danger'>Cập nhật " + product.ProductName + " không thành công !</div>";
                }
            }
        }
        else
        {
            ProductService objProductService = new ProductService();
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            if (txtQuantity.Text != "" && txtQuantity.Text.Trim() != "")
            {
                try
                {
                    product.Quantity = Convert.ToDecimal(txtQuantity.Text);
                }
                catch { product.Quantity = 0; }
            }
            else product.Quantity = 0;
            product.Measurement = txtMeasurement.Text;
            if (ddlYearStartUpdate.SelectedValue != "")
                product.YearStart = Convert.ToInt32(ddlYearStartUpdate.SelectedValue);
            if (ddlYearEndUpdate.SelectedValue != "")
                product.YearEnd = Convert.ToInt32(ddlYearEndUpdate.SelectedValue);
            product.Note = txtNote.Text;
            if (cbxIsproduct1.Checked)
                product.IsProduct = true;
            else product.IsProduct = false;
            product.EnterpriseId = m_UserValidation.OrgId;
            if (objProductService.Insert(product) > 0)
            {
                BindData();
                ltNotice.Text = "<div class='alert alert-info'>Thêm mới  " + product.ProductName + " thành công !</div>";
            }
            else ltNotice.Text = "<div class='alert alert-danger'>Thêm mới " + product.ProductName + " không thành công !</div>";
        }
    }
}
