using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class CateNewsGroupBSO
    {
        public CateNewsGroupBSO()
        {
            //constructor
        }

        #region CreateCateNewsGroup
        public int CreateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.CreateCateNewsGroup(cateNewsGroup);
        }
        #endregion

        #region UpdateCateNewsGroup
        public void UpdateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            cateNewsGroupDAO.UpdateCateNewsGroup(cateNewsGroup);
        }
        #endregion

        #region DeleteCateNewsGroup
        public void DeleteCateNewsGroup(int Id)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            cateNewsGroupDAO.DeleteCateNewsGroup(Id);
        }
        #endregion

        #region GetCateNewsGroupById
        public CateNewsGroup GetCateNewsGroupById(int Id)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupById(Id);
        }
        public string GetSlugById(int Id)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetSlugById(Id);
        }
        #endregion

        #region GetCateNewsGroupByGroupCate
        public CateNewsGroup GetCateNewsGroupByGroupCate(int groupcate, string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupByGroupCate(groupcate,_lang);
        }
        #endregion

        #region GetCateNewsGroupAll
        public DataTable GetCateNewsGroupAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupAll(_lang);
        }
        public DataTable GetCateNewsGroupAll(string _lang, string username)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupAll(_lang, username);
        }
        #endregion

        #region GetCateNewsGroupViewAll
        public DataTable GetCateNewsGroupViewAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupViewAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupHomeAll
        public DataTable GetCateNewsGroupHomeAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupHomeAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupMenuAll
        public DataTable GetCateNewsGroupMenuAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupMenuAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupNewAll
        public DataTable GetCateNewsGroupNewAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupNewAll(_lang);
        }
        public DataTable GetCateNewsGroupNewAll(string _lang, string username)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupNewAll(_lang, username);
        }
        #endregion

        #region GetCateNewsGroupPageAll
        public DataTable GetCateNewsGroupPageAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupPageAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupRegisterAll
        public DataTable GetCateNewsGroupRegisterAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupRegisterAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupOfficialAll
        public DataTable GetCateNewsGroupOfficialAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupOfficialAll(_lang);
        }
        public DataTable GetCateNewsGroupOfficialAll(string _lang, string username)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupOfficialAll(_lang, username);
        }
        #endregion

        #region GetCateNewsGroupFaqAll
        public DataTable GetCateNewsGroupFaqAll(string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupFaqAll(_lang);
        }
        #endregion

        #region GetCateNewsGroupByMenu
        public DataTable GetCateNewsGroupByMenu(int _menu, string _lang)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupByMenu(_menu,_lang);
        }
        #endregion

        #region CateNewsGroupUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void CateNewsGroupUpOrder(int cId, int cOrder)
        {
            CateNewsGroupDAO catenewsGroupDAO = new CateNewsGroupDAO();
            catenewsGroupDAO.CateNewsGroupUpOrder(cId, cOrder);
        }
        #endregion

        #region CateNewsGroupUpMenu
        /// <summary>
        /// Thay doi gia tri Menu
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void CateNewsGroupUpMenu(int cId, int _menu)
        {
            CateNewsGroupDAO catenewsGroupDAO = new CateNewsGroupDAO();
            catenewsGroupDAO.CateNewsGroupUpMenu(cId, _menu);
        }
        #endregion
    }
}
