using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class CateNewsPermissionBSO
    {
        public CateNewsPermissionBSO() 
        {
            //constructor
        }

        #region CreateCateNewsPermission
        public void CreateCateNewsPermission(CateNewsPermission cateNewsPermission) 
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            cateNewsPermissionDAO.CreateCateNewsPermission(cateNewsPermission);
        }
        #endregion

        #region UpdateCateNewsPermission
        public void UpdateCateNewsPermission(CateNewsPermission cateNewsPermission) 
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            cateNewsPermissionDAO.UpdateCateNewsPermission(cateNewsPermission);
        }
        #endregion

        #region DeleteCateNewsPermission
        public void DeleteCateNewsPermission(int Id) 
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            cateNewsPermissionDAO.DeleteCateNewsPermission(Id);
        }
        #endregion

        #region DeleteCateNewsPermissionRoles
        public void DeleteCateNewsPermissionRoles(int Id, string lang)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            cateNewsPermissionDAO.DeleteCateNewsPermissionRoles(Id, lang);
        }
        #endregion

        #region DeleteCateNewsPermissionCateID
        public void DeleteCateNewsPermissionCateID(int Id)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            cateNewsPermissionDAO.DeleteCateNewsPermissionCateID(Id);
        }
        #endregion

        #region GetCateNewsPermissionById
        public CateNewsPermission GetCateNewsPermissionById(int Id) 
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionById(Id);
        }
        #endregion

        #region GetCateNewsPermissionByRoles
        public DataTable GetCateNewsPermissionByRoles(int rolesID, string lang)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionByRoles(rolesID, lang);
        }
        #endregion

        #region GetCateNewsPermissionByCateID
        public DataTable GetCateNewsPermissionByCateID(int cateID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionByCateID(cateID);
        }
        #endregion

        #region GetCateNewsPermissionAll
        public DataTable GetCateNewsPermissionAll() 
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionAll();
        }
        #endregion

        #region GetCateNewsPermission
        public CateNewsPermission GetCateNewsPermission(int rolesId, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermission(rolesId, cateNewsID);
        }
        #endregion

        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.CheckExitPermission(rolesID, cateNewsID);
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetPermission(rolesID, cateNewsID);
        }
        #endregion

        #region GetRoles
        public string GetRoles(int cateID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetRoles(cateID);
        }
        #endregion

        #region GetCateNewsID
        public string GetCateNewsID(int rolesID, string lang)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsID(rolesID, lang);
        }

        public string GetCateNewsID(string strRoles, string lang)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsID(strRoles, lang);
        }
        #endregion
    }
}
