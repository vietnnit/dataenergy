using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class PermissionBSO
    {
        public PermissionBSO()
        {
            //constructor
        }

        #region CreatePermission
        public void CreatePermission(Permission permission)
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            permissionDAO.CreatePermission(permission);
        }
        #endregion

        #region UpdatePermission
        public void UpdatePermission(Permission permission)
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            permissionDAO.UpdatePermission(permission);
        }
        #endregion

        #region DeletePermission
        public void DeletePermission(int Id)
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            permissionDAO.DeletePermission(Id);
        }
        #endregion

        #region GetPermissionById
        public Permission GetPermissionById(int Id)
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            return permissionDAO.GetPermissionById(Id);
        }
        #endregion

        #region GetPermissionAll
        public DataTable GetPermissionAll()
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            return permissionDAO.GetPermissionAll();
        }
        #endregion
    }
}
