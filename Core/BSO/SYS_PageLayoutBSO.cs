using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_PageLayoutBSO
    {
        public SYS_PageLayoutBSO() 
        {
            //constructor
        }

        #region CreateSYS_PageLayout
        public int CreateSYS_PageLayoutGet(SYS_PageLayout sys_PageLayout)
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.CreateSYS_PageLayoutGet(sys_PageLayout);
        }
        #endregion

        #region UpdateSYS_PageLayout
        public void UpdateSYS_PageLayout(SYS_PageLayout sys_PageLayout) 
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            sys_PageLayoutDAO.UpdateSYS_PageLayout(sys_PageLayout);
        }
        #endregion

        #region DeleteSYS_PageLayout
        public void DeleteSYS_PageLayout(int Id) 
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            sys_PageLayoutDAO.DeleteSYS_PageLayout(Id);
        }
        #endregion

        #region GetSYS_PageLayoutById
        public SYS_PageLayout GetSYS_PageLayoutById(int Id) 
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutById(Id);
        }
        public SYS_PageLayout GetSYS_PageLayoutBySlug(string slug, string _lang)
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutBySlug(slug, _lang);
        }
        #endregion

        #region GetSYS_PageLayoutByTemplateId
        public SYS_PageLayout GetSYS_PageLayoutByTemplateId(int templateId, string _lang)
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutByTemplateId(templateId,_lang);
        }
        #endregion

        #region GetSYS_PageLayoutAll
        public DataTable GetSYS_PageLayoutAll(string _lang) 
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutAll(_lang);
        }
        public DataTable GetSYS_PageLayoutAllTemplate(string _lang)
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutAllTemplate(_lang);
        }

        public SYS_PageLayout GetSYS_PageLayoutAllTemplatebyID(int Id, string _lang)
        {
            SYS_PageLayoutDAO sys_PageLayoutDAO = new SYS_PageLayoutDAO();
            return sys_PageLayoutDAO.GetSYS_PageLayoutAllTemplatebyID(Id, _lang);
        }
        #endregion

        #region SYS_PageLayoutUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void SYS_PageLayoutUpOrder(int Id, int cOrder)
        {
            SYS_PageLayoutDAO _pageLayoutDAO = new SYS_PageLayoutDAO();
            _pageLayoutDAO.SYS_PageLayoutUpOrder(Id, cOrder);
        }
        #endregion
    }
}
