using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_WidgetPageLayoutBSO
    {
        public SYS_WidgetPageLayoutBSO() 
        {
            //constructor
        }

        #region CreateSYS_WidgetPageLayout
        public int CreateSYS_WidgetPageLayoutGet(SYS_WidgetPageLayout sys_WidgetPageLayout)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.CreateSYS_WidgetPageLayoutGet(sys_WidgetPageLayout);
        }
        #endregion

        #region UpdateSYS_WidgetPageLayout
        public void UpdateSYS_WidgetPageLayout(SYS_WidgetPageLayout sys_WidgetPageLayout) 
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            sys_WidgetPageLayoutDAO.UpdateSYS_WidgetPageLayout(sys_WidgetPageLayout);
        }
        #endregion

        #region DeleteSYS_WidgetPageLayout
        public void DeleteSYS_WidgetPageLayout(int Id) 
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            sys_WidgetPageLayoutDAO.DeleteSYS_WidgetPageLayout(Id);
        }

        public void DeleteSYS_WidgetPageLayout(string strId)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            sys_WidgetPageLayoutDAO.DeleteSYS_WidgetPageLayout(strId);
        }
        #endregion

        #region GetSYS_WidgetPageLayoutById
        public SYS_WidgetPageLayout GetSYS_WidgetPageLayoutById(int Id) 
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutById(Id);
        }
        #endregion


        #region GetSYS_WidgetPageLayoutAll
        public DataTable GetSYS_WidgetPageLayoutAll(string _lang) 
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutAll(_lang);
        }

        public DataTable GetSYS_WidgetPageLayoutFullAll(string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutFullAll(_lang);
        }
        public DataTable GetSYS_WidgetPageLayoutFullAll(int pageLayoutId, string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutFullAll(pageLayoutId,_lang);
        }

        #endregion 
        
        #region SYS_WidgetPageLayoutUpOrder
        public void SYS_WidgetPageLayoutUpOrder(int Id, int cOrder)
        {
            SYS_WidgetPageLayoutDAO _widgetDAO = new SYS_WidgetPageLayoutDAO();
            _widgetDAO.SYS_WidgetPageLayoutUpOrder(Id, cOrder);
        }
        #endregion

        #region GetSYS_WidgetPageLayoutByRegionId
        public DataTable GetSYS_WidgetPageLayoutByRegionId(string regionId, int pageLayoutId, bool status, string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutByRegionId(regionId, pageLayoutId, status, _lang);
        }
       
        #endregion

        #region GetSYS_WidgetPageLayoutByAllRegionId
        public DataTable GetSYS_WidgetPageLayoutByAllRegionId(string regionId, int pageLayoutId, string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutByAllRegionId(regionId, pageLayoutId, _lang);
        }
        #endregion

        public DataTable GetSYS_WidgetPageLayoutByPageLayoutId(int pageLayoutId, bool status, string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutByPageLayoutId(pageLayoutId,status, _lang);
        }

        public DataTable GetSYS_WidgetPageLayoutAllByPageLayoutId(int pageLayoutId, bool status, string _lang)
        {
            SYS_WidgetPageLayoutDAO sys_WidgetPageLayoutDAO = new SYS_WidgetPageLayoutDAO();
            return sys_WidgetPageLayoutDAO.GetSYS_WidgetPageLayoutAllByPageLayoutId(pageLayoutId, status, _lang);
        }

    }
}
