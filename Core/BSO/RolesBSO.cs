using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class RolesBSO
    {
        public RolesBSO() 
        {
            //constructor
        }

        #region CreateRoles
        public int CreateRoles(IRoles roles) 
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.CreateRoles(roles);
        }
        #endregion

        #region GetAllRoles
        public DataTable GetAllRoles() 
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetAllRoles();
        }
        #endregion

        #region GetRolesById
        public IRoles GetRolesById(int rId)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesById(rId);
        }
        #endregion
        #region GetRolesByName
        public IRoles GetRolesByName(string name)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesByName(name);
        }
        #endregion

        #region UpdateRoles
        public int UpdateRoles(IRoles roles) 
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.UpdateRoles(roles);
        }
        #endregion

        #region DeleteRoles
        public void DeleteRoles(int rId) 
        {
            RolesDAO rolesDAO = new RolesDAO();
            rolesDAO.DeleteRoles(rId);
        }
        #endregion


        #region GetRolesbyStrRolesID
        public DataTable GetRolesbyStrRolesID(string strRolesID)
        {
            RolesDAO rolesDAO = new RolesDAO();
            return rolesDAO.GetRolesbyStrRolesID(strRolesID);
        }
        #endregion
    }
}
