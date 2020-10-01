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
public partial class Client_Admin_ListFuelType : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);


        if (!IsPostBack)
        {
            BindData();
        }

    }
    void BindData()
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
            grvArea.DataSource = listSearch;

            grvArea.DataBind();
            ltrTotal.Text = String.Format("Có tổng số {0} bản ghi.", list.Count);
        }
        else
        {
            grvArea.DataSource = null;

            grvArea.DataBind();
            ltrTotal.Text = "Không có bản ghi nào.";

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

    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        new GroupFuelService().Delete(Convert.ToInt32(btnDelete.CommandArgument));
        BindData();

    }
    protected void btn_Order_Click(object sender, EventArgs e)
    { }




    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/CreateFuelType/Default.aspx");
    }
}
