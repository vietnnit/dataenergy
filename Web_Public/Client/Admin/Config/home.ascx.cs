using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
public partial class Admin_Controls_Main : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMenuAdminCate(0);
        }
        //BindMenuAdmin();
    }

    private void BindMenuAdminCate(int cId)
    {
        if (Session["Admin_Username"] != null)
        {
            DataTable table = new DataTable();
            if (AspNetCache.CheckCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString()) == false)
            {
                ModulesBSO modulesBSO = new ModulesBSO();
                table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());
 
                AspNetCache.SetCacheWithTime("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString(), table, 150);
            }
            else
            {
                table = (DataTable)AspNetCache.GetCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString());
             }

            DataView dataView = new DataView(table);
            dataView.RowFilter = "Modules_Parent = " + cId;

            DataList1.DataSource = dataView;
            DataList1.DataBind();
        }
        else
            Response.Redirect("~/Default.aspx");

       
    }

    protected void DataList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater dtl2 = (Repeater)e.Item.FindControl("DataList2");

        int cateId;
        int.TryParse(DataBinder.Eval(e.Item.DataItem, "Modules_ID").ToString(), out cateId);


        if (Session["Admin_Username"] != null)
        {
            DataTable table = new DataTable();
            if (AspNetCache.CheckCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString()) == false)
            {
                ModulesBSO modulesBSO = new ModulesBSO();
                table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());

                AspNetCache.SetCacheWithTime("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString(), table, 150);
            }
            else
            {
                table = (DataTable)AspNetCache.GetCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString());
            }

            DataView dataView = new DataView(table);
            dataView.RowFilter = "Modules_Parent = " + cateId +" And isView = true";
            dtl2.DataSource = dataView;
            dtl2.DataBind();
        }
        else
            Response.Redirect("~/Default.aspx");


    }

   
}
