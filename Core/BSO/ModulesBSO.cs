using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using ETO;
using DAO;
namespace BSO
{
    public class ModulesBSO
    {
        public ModulesBSO() 
        {
            //Constructor
        }
        

        #region AddModules     
        public  int AddModules(Modules _modules ) 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
          return  modulesDAO.CreateModules(_modules);

        }
        #endregion

        #region EditModules
        public  int EditModules(Modules _modules) 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.UpdateModules(_modules);
        }
        #endregion

        #region GetAllModules
        public DataTable GetAllModules() 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetAllModules();
        }
        #endregion

        #region MixModules
        public DataTable MixModules() 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.MixModules();
        }
        #endregion

        #region MixModulesAdmin
        public DataTable MixModulesAdmin()
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.MixModulesAdmin();
        }
        #endregion

        #region GetModulesById
        public Modules GetModulesById(int mID) 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetModulesById(mID);
        }
        #endregion

        #region GetModulesByUrl
        public Modules GetModulesByUrl(string url)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetModulesByUrl(url);
        }
        #endregion
        #region GetModulesBySlug
        public Modules GetModulesBySlug(string Slug)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            return modulesDAO.GetModulesBySlug(Slug);
        }
        #endregion

        #region DeleteModules
        public void DeleteModules(int mID) 
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            modulesDAO.DeleteModules(mID);
        }
        #endregion

        #region CheckExist
        public bool CheckExist(string ModulesName)
        {
            bool name = false;
            DataTable dataTable = GetAllModules();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Slug = '"+ ModulesName +"'";
                if (dataView.Count > 0)
                    name = true;
            }
            return name;

        }
        #endregion

  

        //View MainMenu
        #region ViewMainModules
        public DataTable ViewMainModules(string AdminName)
        {
            DataTable dataTable = new DataTable();
            AdminBSO adminBSO = new AdminBSO();
            Admin admin = adminBSO.GetAdminById(AdminName);

            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = rolesBSO.GetRolesById(admin.RolesID);
            string strModules = roles.RolesModules;

            strModules = strModules.Replace(",", "','");
            ModulesBSO modulesBSO = new ModulesBSO();
            DataTable table = modulesBSO.MixModules();

            if (AdminName.Equals("administrator")) 
            {

                 dataTable = table;
            }
            else
            {
               
                DataView dataView = new DataView(table);
                dataView.RowFilter = "Slug in ('" + strModules + "')";
                dataView.Sort = "Modules_ID ASC";
                dataTable = dataView.ToTable();
            }

            return dataTable;
        }
        #endregion

        #region ViewMainModulesRoles
        public DataTable ViewMainModulesRoles(string AdminName)
        {
            DataTable dataTable = new DataTable();

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

            }


         //   string strModules = roles.RolesModules;

            strModules = strModules.Replace(",", "','");
            ModulesBSO modulesBSO = new ModulesBSO();
            DataTable table = modulesBSO.MixModulesAdmin();

            if (AdminName.Equals("administrator"))
            {

                dataTable = table;
            }
            else
            {

                DataView dataView = new DataView(table);
                dataView.RowFilter = "Slug in ('" + strModules + "')";
                dataView.Sort = "Modules_ID ASC";
                dataTable = dataView.ToTable();
            }

            return dataTable;
        }

        public DataTable ViewMainModulesByRoles(string AdminName)
        {
            DataTable dataTable = new DataTable();

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

            }


         //   string strModules = roles.RolesModules;

            strModules = strModules.Replace(",", "','");
            ModulesBSO modulesBSO = new ModulesBSO();
            DataTable table = modulesBSO.MixModulesAdmin();

            if (AdminName.Equals("administrator"))
            {

                dataTable = table;
            }
            else
            {

                DataView dataView = new DataView(table);
                dataView.RowFilter = "Slug in ('" + strModules + "')";
                dataView.Sort = "Modules_ID ASC";
                dataTable = dataView.ToTable();
            }

            return dataTable;
        }
        #endregion


        #region CheckLevelRoles
        public bool CheckLevelRoles(string url , string AdminName) 
        {
            bool levelRoles = false;

            if (AdminName.Equals("administrator"))
            {
                levelRoles = true;
            }
            else
            {

                DataTable table = ViewMainModules(AdminName);
                DataView dataView = new DataView(table);
                try
                {
                    dataView.RowFilter = "Slug = '" + url + "'";
                    if (dataView.Count > 0)
                    levelRoles = true;
                }
                catch 
                {
                    levelRoles = false;
                }
                
            }
            return levelRoles;
        }
        #endregion

        #region CheckLevelModulesRoles
        public bool CheckLevelModulesRoles(string url, string AdminName)
        {
            bool levelRoles = false;

            if (AdminName.Equals("administrator"))
            {
                levelRoles = true;
            }
            else
            {

                DataTable table = ViewMainModulesRoles(AdminName);
                DataView dataView = new DataView(table);
                try
                {
                    dataView.RowFilter = "Slug = '" + url + "'";
                    if (dataView.Count > 0)
                        levelRoles = true;
                }
                catch
                {
                    levelRoles = false;
                }

            }
            return levelRoles;
        }
        #endregion

        #region ModulesUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void ModulesUpOrder(int cId, int cOrder)
        {
            ModulesDAO modulesDAO = new ModulesDAO();
            modulesDAO.ModulesUpOrder(cId, cOrder);
        }
        #endregion
        
    }

    
  
}
