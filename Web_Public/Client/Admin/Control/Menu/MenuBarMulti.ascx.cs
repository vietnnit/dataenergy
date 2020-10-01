using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;
public partial class Control_Modules_Menu_MenuBarMulti : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strMenu = "";

        if (AspNetCache.CheckCache("HTML_MenuBar_Admin_" + Session["Admin_Username"].ToString()) == false)
        {
            strMenu += BindMenu("", 0);

            AspNetCache.SetCacheWithTime("HTML_MenuBar_Admin_" + Session["Admin_Username"].ToString(), strMenu, 150);
            MenuNews.Text = strMenu;

        }
        else
        {
            MenuNews.Text = (string)AspNetCache.GetCache("HTML_MenuBar_Admin_" + Session["Admin_Username"].ToString());
        }
    }

    private string BindMenu(string strMenuSub, int iCate)
    {
        if (Session["Admin_Username"] != null)
        {
            DataTable table = new DataTable();
            commonBSO common = new commonBSO();
            String SQL = "";

            string AdminName = Session["Admin_Username"].ToString();
            AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
            string strRoles = adminRolesBSO.GetRoles(AdminName);
            RolesBSO rolesBSO = new RolesBSO();
            DataTable table1 = rolesBSO.GetRolesbyStrRolesID(strRoles);

            string strModules = "";

            if (table1.Rows.Count > 0)
            {
                foreach (DataRow row in table1.Rows)
                {
                    strModules += row["Roles_Modules"].ToString();
                }
                strModules = strModules.Remove(strModules.LastIndexOf(",")).Replace(",", "','");
            }

            if (AdminName.Equals("administrator"))
            {
                SQL = "SELECT * FROM tblModules Where [IsMenu] = 1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
                table = common.CreateDataView(SQL);
            }
            else
            {
                SQL = "SELECT * FROM tblModules Where [IsMenu] = 1 And [Modules_Parent] = " + iCate + " And Slug in ('" + strModules + "') Order by [Modules_Order] ASC";
                table = common.CreateDataView(SQL);
            }
            strMenuSub += "<ul>";
            strMenuSub += "<li><a href='" + ResolveUrl("~/") + "Admin/home/Default.aspx'>Trang chủ</li>";
            if (table.Rows.Count > 0)
            {
                
                foreach (DataRow dataRow in table.Rows)
                {
                    strMenuSub += "<li>";
                    strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                    strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), Session["Admin_Username"].ToString(), strModules);

                    strMenuSub += "</li>";
                }
               

            }
            strMenuSub += "</ul>";
        }
        else
            Response.Redirect("~/Default.aspx");



            

        return strMenuSub;

    }

    private string GetSubMenu(string strMenuSub, int iCate, string AdminName, string strModules)
    {
        DataTable datatable = new DataTable();
        commonBSO common = new commonBSO();
        String SQL = "";


        if (AdminName.Equals("administrator"))
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] = 1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }
        else
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] = 1 And [Modules_Parent] = " + iCate + " And Slug in ('" + strModules + "') Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }


        if (datatable.Rows.Count > 0)
        {
            strMenuSub += "<ul>";
            foreach (DataRow dataRow in datatable.Rows)
            {
                strMenuSub += "<li>";

                strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);

                strMenuSub += "</li>";
            }
            strMenuSub += "</ul>";

        }
        return strMenuSub;

    }
}