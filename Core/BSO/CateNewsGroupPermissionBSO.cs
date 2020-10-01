using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class CateNewsGroupPermissionBSO
    {
        public CateNewsGroupPermissionBSO() 
        {
            //constructor
        }

        #region CreateCateNewsGroupPermission
        public void CreateCateNewsGroupPermission(CateNewsGroupPermission _cateNewsGroupPermission) 
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            _cateNewsGroupPermissionDAO.CreateCateNewsGroupPermission(_cateNewsGroupPermission);
        }
        #endregion

        #region UpdateCateNewsGroupPermission
        public void UpdateCateNewsGroupPermission(CateNewsGroupPermission _cateNewsGroupPermission) 
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            _cateNewsGroupPermissionDAO.UpdateCateNewsGroupPermission(_cateNewsGroupPermission);
        }
        #endregion

        #region DeleteCateNewsGroupPermission
        public void DeleteCateNewsGroupPermission(int Id) 
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            _cateNewsGroupPermissionDAO.DeleteCateNewsGroupPermission(Id);
        }
        #endregion

        #region DeleteCateNewsGroupPermissionRoles
        public void DeleteCateNewsGroupPermissionRoles(int Id, string lang)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            _cateNewsGroupPermissionDAO.DeleteCateNewsGroupPermissionRoles(Id, lang);
        }
        #endregion

        #region DeleteCateNewsGroupPermissionCateID
        public void DeleteCateNewsGroupPermissionCateID(int Id)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            _cateNewsGroupPermissionDAO.DeleteCateNewsGroupPermissionCateID(Id);
        }
        #endregion

        #region GetCateNewsGroupPermissionById
        public CateNewsGroupPermission GetCateNewsGroupPermissionById(int Id) 
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupPermissionById(Id);
        }
        #endregion

        #region GetCateNewsGroupPermissionByRoles
        public DataTable GetCateNewsGroupPermissionByRoles(int rolesID, string lang)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupPermissionByRoles(rolesID, lang);
        }
        #endregion

        #region GetCateNewsGroupPermissionByCateID
        public DataTable GetCateNewsGroupPermissionByCateID(int cateID)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupPermissionByCateID(cateID);
        }
        #endregion

        #region GetCateNewsGroupPermissionAll
        public DataTable GetCateNewsGroupPermissionAll() 
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupPermissionAll();
        }
        #endregion

        #region GetCateNewsGroupPermission
        public CateNewsGroupPermission GetCateNewsGroupPermission(int rolesId, int _cateNewsGroupID)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupPermission(rolesId, _cateNewsGroupID);
        }
        #endregion

        #region CheckExitPermission
        public bool CheckExitPermission(int rolesID, int _cateNewsGroupID)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.CheckExitPermission(rolesID, _cateNewsGroupID);
        }
        #endregion

        #region GetPermission
        public string GetPermission(int rolesID, int _cateNewsGroupID)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetPermission(rolesID, _cateNewsGroupID);
        }
        #endregion

        #region GetRoles
        public string GetRoles(int cateID)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetRoles(cateID);
        }
        #endregion

        #region GetCateNewsGroupID
        public string GetCateNewsGroupID(int rolesID, string lang)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupID(rolesID, lang);
        }

        public string GetCateNewsGroupID(string strRoles, string lang)
        {
            CateNewsGroupPermissionDAO _cateNewsGroupPermissionDAO = new CateNewsGroupPermissionDAO();
            return _cateNewsGroupPermissionDAO.GetCateNewsGroupID(strRoles, lang);
        }
        #endregion
    }
}
