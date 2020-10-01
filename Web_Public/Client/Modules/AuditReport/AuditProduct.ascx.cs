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

public partial class Client_Module_DataEngery_AuditProduct : System.Web.UI.UserControl
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
            BindData();
            if (ReportId > 0)
            {
                BindMaterialConsume();
                BindProductConsume();
            }
        }
    }

    void BindData()
    {
        Enterprise enter = new Enterprise();
        if (memVal.OrgId > 0)
        {
            enter = new EnterpriseService().FindByKey(memVal.OrgId);
            if (enter != null)
            {
                ///ltActiveYear.Text = enter.ActiveYear.ToString();
            }
        }
        btnAddProductPlan.Visible = btnAddProductNext.Visible = btnAddProductNextResult.Visible = btnAddProductResult.Visible = AllowEdit; ;

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
        var listMaterial = from o in list where o.IsProduct == false select o;
        ddlMaterial.DataSource = listMaterial;
        ddlMaterial.DataValueField = "Id";
        ddlMaterial.DataTextField = "ProductName";
        ddlMaterial.DataBind();
        ddlMaterial.Items.Insert(0, new ListItem("---Chọn nguyên liệu---", ""));
    }

    protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

        }
    }
    protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            ProductConsumeService rptbso = new ProductConsumeService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            long i = rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindProductConsume();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            ProductConsume productCapacity = new ProductConsume();
            ProductConsumeService productCapacityService = new ProductConsumeService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                try
                {
                    txtProductQty.Text = productCapacity.Quantity.ToString();
                    ddlProduct.SelectedValue = productCapacity.ProductId.ToString();
                    Product product = new Product();
                    ProductService productService = new ProductService();
                    product = productService.FindByKey(productCapacity.ProductId);
                    ltProductMeasurement.Text = "(" + product.Measurement + ")";
                }
                catch { }
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogProduct(" + hdnId.Value + ");", true);
        }
    }

    public void btnSaveProduct_Click(object sender, EventArgs e)
    {
        ProductService productService = new ProductService();
        Product product = new Product();
        product.ProductName = txtProductName.Text.Trim();
        if (txtYearStart.Text.Trim() != "")
            product.YearStart = Convert.ToInt32(txtYearStart.Text.Trim());
        if (txtYearEnd.Text.Trim() != "")
            product.YearEnd = Convert.ToInt32(txtYearEnd.Text.Trim());
        product.Quantity = Convert.ToInt32(txtDesignQty.Text.Trim());
        product.Measurement = txtMeasurement.Text.Trim();
        product.Note = txtDescription.Text.Trim();
        product.EnterpriseId = memVal.OrgId;
        product.IsProduct = true;
        int i = productService.Insert(product);
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogMaterial();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProduct();
        }

    }
    public void btnSaveMaterialList_Click(object sender, EventArgs e)
    {
        ProductService productService = new ProductService();
        Product product = new Product();
        product.ProductName = txtMaterialName.Text.Trim();

        product.YearStart = 0;

        product.YearEnd = 0;
        product.Quantity = 0;
        product.Measurement = txtMeasurementM.Text.Trim();
        product.Note = txtDesM.Text.Trim();
        product.EnterpriseId = memVal.OrgId;
        product.IsProduct = false;
        int i = productService.Insert(product);
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogMaterialList();", true);
        }
        else
        {
            BindProduct();
        }

    }
    public void btnSaveMaterial_Click(object sender, EventArgs e)
    {
        ProductConsumeService productCapacityService = new ProductConsumeService();
        ProductConsume productCapacity = new ProductConsume();

        if (txtMaterialQty.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToDecimal(txtMaterialQty.Text.Trim());
        productCapacity.ProductId = Convert.ToInt32(ddlMaterial.SelectedValue);
        productCapacity.AuditReportId = ReportId;

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogMaterial(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindMaterialConsume();
        }

    }

    public void btnSaveProductUse_Click(object sender, EventArgs e)
    {
        ProductConsumeService productCapacityService = new ProductConsumeService();
        ProductConsume productCapacity = new ProductConsume();

        if (txtProductQty.Text.Trim() != "")
            productCapacity.Quantity = Convert.ToDecimal(txtProductQty.Text.Trim());
        productCapacity.ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
        productCapacity.AuditReportId = ReportId;

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }

        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogProduct(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProductConsume();
        }

    }
    protected void rptMaterial_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            ProductConsumeService rptbso = new ProductConsumeService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            long i = rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindMaterialConsume();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            ProductConsume productCapacity = new ProductConsume();
            ProductConsumeService productCapacityService = new ProductConsumeService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                try
                {
                    txtMaterialQty.Text = productCapacity.Quantity.ToString();
                    ddlMaterial.SelectedValue = productCapacity.ProductId.ToString();
                    Product product = new Product();
                    ProductService productService = new ProductService();
                    product = productService.FindByKey(productCapacity.ProductId);
                    ltMaterialMeasurement.Text = "(" + product.Measurement + ")";
                }
                catch { }
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "ShowDialogMaterial(" + hdnId.Value + ");", true);
        }
    }
    protected void rptMaterial_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }


    private void BindMaterialConsume()
    {
        ProductConsumeService productConsumeService = new ProductConsumeService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetProductConsume(ReportId, false);
        rptMaterial.DataSource = tbl;
        rptMaterial.DataBind();
    }
    private void BindProductConsume()
    {
        ProductConsumeService productConsumeService = new ProductConsumeService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetProductConsume(ReportId, true);
        rptProduct.DataSource = tbl;
        rptProduct.DataBind();
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product = productService.FindByKey(Convert.ToInt32(ddlProduct.SelectedValue));
            ltProductMeasurement.Text = product.Measurement;
        }
        else
        {
            ltProductMeasurement.Text = "";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogProduct();", true);
    }
    protected void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMaterial.SelectedIndex > 0)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product = productService.FindByKey(Convert.ToInt32(ddlMaterial.SelectedValue));
            ltMaterialMeasurement.Text = product.Measurement;

        }
        else
        {
            ltMaterialMeasurement.Text = "";

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogMaterial();", true);
    }
}