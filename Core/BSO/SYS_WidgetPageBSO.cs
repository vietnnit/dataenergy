using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_WidgetPageBSO
    {
        public SYS_WidgetPageBSO() 
        {
            //constructor
        }

        #region CreateSYS_WidgetPage
        public int CreateSYS_WidgetPageGet(SYS_WidgetPage sys_WidgetPage)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.CreateSYS_WidgetPageGet(sys_WidgetPage);
        }
        #endregion

        #region UpdateSYS_WidgetPage
        public void UpdateSYS_WidgetPage(SYS_WidgetPage sys_WidgetPage) 
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            sys_WidgetPageDAO.UpdateSYS_WidgetPage(sys_WidgetPage);
        }
        #endregion

        #region DeleteSYS_WidgetPage
        public void DeleteSYS_WidgetPage(int Id) 
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            sys_WidgetPageDAO.DeleteSYS_WidgetPage(Id);
        }
        #endregion

        #region GetSYS_WidgetPageById
        public SYS_WidgetPage GetSYS_WidgetPageById(int Id) 
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageById(Id);
        }
        #endregion

        #region GetSYS_WidgetPageByRegionId
        public DataTable GetSYS_WidgetPageByRegionId(string regionId, int pageLayoutId, bool status, string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageByRegionId(regionId, pageLayoutId, status, _lang);
        }
        public DataTable GetSYS_WidgetPageByPageLayoutId(int pageLayoutId, bool status, string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageByPageLayoutId(pageLayoutId, status, _lang);
        }
        #endregion

        #region GetSYS_WidgetPageByAllRegionId
        public DataTable GetSYS_WidgetPageByAllRegionId(string regionId, int pageLayoutId, string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageByAllRegionId(regionId, pageLayoutId, _lang);
        }
        #endregion

        #region GetSYS_WidgetPageAll
        public DataTable GetSYS_WidgetPageAll(string _lang) 
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageAll(_lang);
        }

        public DataTable GetSYS_WidgetPageFullAll(string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageFullAll(_lang);
        }
        public DataTable GetSYS_WidgetPageFullAll(int pageLayoutId, string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageFullAll(pageLayoutId,_lang);
        }
        public DataTable GetSYS_WidgetPageFullAll(int pageLayoutId, string regionId, string _lang)
        {
            SYS_WidgetPageDAO sys_WidgetPageDAO = new SYS_WidgetPageDAO();
            return sys_WidgetPageDAO.GetSYS_WidgetPageFullAll(pageLayoutId, regionId, _lang);
        }
        #endregion 
        
        #region SYS_WidgetPageUpOrder
        public void SYS_WidgetPageUpOrder(int Id, int cOrder)
        {
            SYS_WidgetPageDAO _widgetDAO = new SYS_WidgetPageDAO();
            _widgetDAO.SYS_WidgetPageUpOrder(Id, cOrder);
        }
        #endregion


    }
}
