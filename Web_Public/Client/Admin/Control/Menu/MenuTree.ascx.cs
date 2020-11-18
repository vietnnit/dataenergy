using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ETO;
using BSO;

public partial class Client_Admin_Control_Menu_MenuTree : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string strMenu = "";

        //if (AspNetCache.CheckCache("HTML_MenuTree_Admin_" + Session["Admin_Username"].ToString()) == false)
        //{
        strMenu += BindMenu("", 0);

        //AspNetCache.SetCacheWithTime("HTML_MenuTree_Admin_" + Session["Admin_Username"].ToString(), strMenu, 150);
        MenuNews.Text = strMenu;

        //}
        //else
        //{
        //    MenuNews.Text = (string)AspNetCache.GetCache("HTML_MenuTree_Admin_" + Session["Admin_Username"].ToString());
        //}
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
                SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
                table = common.CreateDataView(SQL);
            }
            else
            {
                SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " And Slug in ('" + strModules + "') Order by [Modules_Order] ASC";
                table = common.CreateDataView(SQL);
            }
            //strMenuSub += "<ul>";
            //strMenuSub += "<li class='sidebar-label pt20'><a href='" + ResolveUrl("~/") + "Admin/home/Default.aspx'>Trang chủ</a></li>";
            if (table.Rows.Count > 0)
            {

                foreach (DataRow dataRow in table.Rows)
                {
                    strMenuSub += "<li class='sidebar-label pt20'>";
                    //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Modules_Url"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                    //if (checkActive(Request["dll"].ToString(), dataRow["Slug"].ToString()))
                    //{
                    //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";
                    strMenuSub += dataRow["Modules_Name"].ToString();
                    //strMenuSub += "<span class='closed opened'></span>";
                    //strMenuSub += "<div style='display: block;'>";
                    //}
                    //else
                    //{
                    //    strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";

                    //    //strMenuSub += "<span class='closed'></span>";
                    //    //strMenuSub += "<div style='display: none;'>";
                    //}
                    strMenuSub += "</li>";
                    strMenuSub += GetSubMenu("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), Session["Admin_Username"].ToString(), strModules);

                    //strMenuSub += "</div>";

                }


            }
            //strMenuSub += "</ul>";
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
        string strMenu = "";
        string strOpen = "";

        if (AdminName.Equals("administrator"))
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }
        else
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " And Slug in ('" + strModules + "') Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }


        if (datatable.Rows.Count > 0)
        {
            //strMenuSub += "<ul>";
            foreach (DataRow dataRow in datatable.Rows)
            {


                if (checkActive(Request["dll"].ToString(), dataRow["Slug"].ToString()))
                {
                    strMenuSub += "<li class='active'>";
                    strOpen = "menu-open";
                }
                else
                {
                    strOpen = "";
                    strMenuSub += "<li>";
                }
                strMenu = GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);
                if (strMenu != "")
                {
                    //strMenuSub += "<span class='closed opened'></span>";
                    strMenuSub += "<a class='accordion-toggle " + strOpen + "' href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";
                    strMenuSub += "<span class='" + ((dataRow["Modules_Icon"] != DBNull.Value && dataRow["Modules_Icon"].ToString() != "") ? dataRow["Modules_Icon"].ToString() : "glyphicons glyphicons-more_items") + "'></span>";
                    strMenuSub += "<span class='sidebar-title'>" + dataRow["Modules_Name"].ToString() + "</span>";
                    strMenuSub += "<span class='caret'></span>";
                    strMenuSub += "</a>";
                    strMenuSub += GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);
                }
                else
                {
                    strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";
                    strMenuSub += "<span class='" + ((dataRow["Modules_Icon"] != DBNull.Value && dataRow["Modules_Icon"].ToString() != "") ? dataRow["Modules_Icon"].ToString() : "glyphicons glyphicons-more_items") + "'></span>";
                    strMenuSub += "<span class='sidebar-title'>" + dataRow["Modules_Name"].ToString() + "</span>";
                    //strMenuSub += "<span class='caret'></span>";
                    strMenuSub += "</a>";

                }
                //strMenuSub += "<div style='display: block;'>";

                //}
                //else
                //{
                //    //strMenuSub += "<span class='closed'></span>";
                //    //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";
                //    //strMenuSub += "<div style='display: none;'>";
                //    strMenuSub += "<li>";
                //    strMenuSub += "<a class='accordion-toggle' href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";
                //    strMenuSub += "<span class='glyphicons glyphicons-fire'></span>";
                //    strMenuSub += "<span class='sidebar-title'>" + dataRow["Modules_Name"].ToString() + "</span>";
                //    strMenuSub += "<span class='caret'></span>";
                //    strMenuSub += "</a>";
                //}

                //strMenuSub += "<span class='closed'></span>";
                //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";
                //strMenuSub += "<div style='display: none;'>";

                //strMenuSub += strMenu;// GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);

                //strMenuSub += "</div>";
                strMenuSub += "</li>";
            }
            //strMenuSub += "</ul>";

        }
        return strMenuSub;

    }

    private string GetSubMenu2(string strMenuSub, int iCate, string AdminName, string strModules)
    {
        DataTable datatable = new DataTable();
        commonBSO common = new commonBSO();
        String SQL = "";
        string strMenu = "";

        if (AdminName.Equals("administrator"))
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }
        else
        {
            SQL = "SELECT * FROM tblModules Where [IsMenu] =1 And [Modules_Parent] = " + iCate + " And Slug in ('" + strModules + "') Order by [Modules_Order] ASC";
            datatable = common.CreateDataView(SQL);
        }


        if (datatable.Rows.Count > 0)
        {
            strMenuSub += "<ul class='nav sub-nav'>";
            foreach (DataRow dataRow in datatable.Rows)
            {


                if (checkActive(Request["dll"].ToString(), dataRow["Slug"].ToString()))
                {
                    strMenuSub += "<li class='active'>";
                }
                else
                {
                    strMenuSub += "<li>";
                }
                strMenu = GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);
                if (strMenu != "")
                {
                    strMenuSub += "<a class='accordion-toggle' href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";
                    strMenuSub += "<span class='glyphicons glyphicons-globe'></span>";
                    strMenuSub += dataRow["Modules_Name"].ToString();
                    strMenuSub += "<span class='caret'></span>";
                    strMenuSub += "</a>";
                    strMenuSub += GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);
                }
                else
                {
                    //strMenuSub += "<span class='closed opened'></span>";
                    strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";

                    strMenuSub += dataRow["Modules_Name"].ToString();
                    strMenuSub += "</a>";
                    //strMenuSub += "<span class='caret'></span>";

                    //strMenuSub += "<div style='display: block;'>";
                }
                //}
                //else
                //{
                //    //strMenuSub += "<span class='closed opened'></span>";
                //    strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>";

                //    strMenuSub += dataRow["Modules_Name"].ToString();
                //    //strMenuSub += "<span class='caret'></span>";
                //    strMenuSub += "</a>";
                //    //strMenuSub += "<div style='display: block;'>";

                //}

                //strMenuSub += "<span class='closed'></span>";
                //strMenuSub += "<a href='" + ResolveUrl("~/") + "Admin/" + dataRow["Slug"] + "/Default.aspx'>" + dataRow["Modules_Name"].ToString() + "</a>";
                //strMenuSub += "<div style='display: none;'>";

                //strMenuSub += GetSubMenu2("", Convert.ToInt32(dataRow["Modules_ID"].ToString()), AdminName, strModules);

                //strMenuSub += "</div>";
                strMenuSub += "</li>";
            }
            strMenuSub += "</ul>";

        }
        return strMenuSub;

    }

    private bool checkActive(string dll, string url)
    {
        ModulesBSO moduleBSO = new ModulesBSO();
        Modules _module = new Modules();

        _module = moduleBSO.GetModulesBySlug(dll);

        if (_module.Slug.Equals(url))
            return true;
        else
            while (_module.ModulesParent != 0 && !_module.Slug.Equals(url))
            {
                _module = moduleBSO.GetModulesById(_module.ModulesParent);
                if (_module.Slug.Equals(url))
                    return true;
            }

        return false;
    }

    private bool checkActive(string dll, int id_url)
    {
        ModulesBSO moduleBSO = new ModulesBSO();
        Modules _module = new Modules();

        _module = moduleBSO.GetModulesBySlug(dll);

        if (_module.ModulesParent == id_url)
            return true;
        else
            while (_module.ModulesParent != 0 && _module.ModulesParent != id_url)
            {
                _module = moduleBSO.GetModulesById(_module.ModulesParent);
                if (_module.ModulesParent == id_url)
                    return true;
            }

        return false;
    }
}