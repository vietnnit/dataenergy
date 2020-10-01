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

public partial class Client_Admin_DataEngery_AuditProduct : System.Web.UI.UserControl
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
      
           
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

    }
  
    protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           

        }
    }
    protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
           
        }
        else if (e.CommandName.Equals("edit"))
        {
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
}