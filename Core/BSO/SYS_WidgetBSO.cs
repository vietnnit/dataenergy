using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_WidgetBSO
    {
        public SYS_WidgetBSO() 
        {
            //constructor
        }

        #region CreateSYS_Widget
        public int CreateSYS_WidgetGet(SYS_Widget sys_Widget)
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            return sys_WidgetDAO.CreateSYS_WidgetGet(sys_Widget);
        }
        #endregion

        #region UpdateSYS_Widget
        public void UpdateSYS_Widget(SYS_Widget sys_Widget) 
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            sys_WidgetDAO.UpdateSYS_Widget(sys_Widget);
        }
        #endregion

        #region DeleteSYS_Widget
        public void DeleteSYS_Widget(int Id) 
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            sys_WidgetDAO.DeleteSYS_Widget(Id);
        }
        #endregion

        #region GetSYS_WidgetById
        public SYS_Widget GetSYS_WidgetById(int Id) 
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            return sys_WidgetDAO.GetSYS_WidgetById(Id);
        }
        #endregion

        #region GetSYS_WidgetByType
        public DataTable GetSYS_WidgetByType(int _widgetType)
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            return sys_WidgetDAO.GetSYS_WidgetByType(_widgetType);
        }
        #endregion

        #region GetSYS_WidgetAll
        public DataTable GetSYS_WidgetAll() 
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            return sys_WidgetDAO.GetSYS_WidgetAll();
        }
        public DataTable GetSYS_WidgetAllFull()
        {
            SYS_WidgetDAO sys_WidgetDAO = new SYS_WidgetDAO();
            return sys_WidgetDAO.GetSYS_WidgetAllFull();
        }
        #endregion 

    }
}
