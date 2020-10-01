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
public partial class Admin_Controls_ListHome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            BindMenuAdminCate(0);
        }
        //BindMenuAdmin();
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesBySlug(url);
        if(modules!=null)
            litModules.Text = modules.ModulesName;
    }
    #endregion

    private void BindMenuAdminCate(int cId)
    {
        if (Session["Admin_Username"] != null)
        {
            DataTable table = new DataTable();
            ModulesBSO modulesBSO = new ModulesBSO();

            if (AspNetCache.CheckCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString()) == false)
            {
                table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());
                AspNetCache.SetCacheWithTime("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString(), table, 150);
            }
            else
            {
                table = (DataTable)AspNetCache.GetCache("HTML_MainHome_Admin_" + Session["Admin_Username"].ToString());
            }

            Modules _module = modulesBSO.GetModulesBySlug(Request["dll"].ToString());
            if (_module != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "Modules_Parent = " + _module.ModulesID + " And isView = true";
                table = dataView.ToTable();

                DataList2.DataSource = table;
                DataList2.DataBind();
            }
            


        }
        else
            Response.Redirect("~/Default.aspx");
    }


}
