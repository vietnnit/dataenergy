using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class AdminRolesBSO
    {
        public AdminRolesBSO() 
        {
            //constructor
        }

        #region CreateAdminRoles
        public void CreateAdminRoles(AdminRoles adminRoles) 
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            adminRolesDAO.CreateAdminRoles(adminRoles);
        }
        #endregion

        #region UpdateAdminRoles
        public void UpdateAdminRoles(AdminRoles adminRoles) 
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            adminRolesDAO.UpdateAdminRoles(adminRoles);
        }
        #endregion

        #region DeleteAdminRoles
        public void DeleteAdminRoles(int Id) 
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            adminRolesDAO.DeleteAdminRoles(Id);
        }
        #endregion

        #region DeleteAdminRolesRoles
        public void DeleteAdminRolesRoles(int Id)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            adminRolesDAO.DeleteAdminRolesRoles(Id);
        }
        #endregion

        #region DeleteAdminRolesUserName
        public void DeleteAdminRolesUserName(string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            adminRolesDAO.DeleteAdminRolesUserName(username);
        }
        #endregion

        #region GetAdminRolesById
        public AdminRoles GetAdminRolesById(int Id) 
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesById(Id);
        }
        #endregion

        #region GetAdminRolesByRoles
        public DataTable GetAdminRolesByRoles(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesByRoles(rolesID);
        }
        #endregion

        #region GetAdminRolesByUserName
        public DataTable GetAdminRolesByUserName(string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesByUserName(username);
        }
        #endregion

        #region GetAdminRolesAll
        public DataTable GetAdminRolesAll() 
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesAll();
        }
        #endregion

        #region GetAdminRoles
        public AdminRoles GetAdminRoles(int rolesId, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRoles(rolesId, username);
        }
        #endregion

        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.CheckExitPermission(rolesID, username);
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetPermission(rolesID, username);
        }
        #endregion

        #region CheckExitRolesUser
        public bool CheckExitRolesUser(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.CheckExitRolesUser(rolesID, username);
        }
        #endregion

        #region GetRoles
        public string GetRoles(string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetRoles(username);
        }
        #endregion

        #region GetAdminUserName
        public string GetAdminUserName(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminUserName(rolesID);
        }
        #endregion

        #region GetAdminUserName1
        public string GetAdminUserName1(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminUserName1(rolesID);
        }
        #endregion
    }
}
