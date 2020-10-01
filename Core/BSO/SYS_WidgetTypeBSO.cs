using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_WidgetTypeBSO
    {
        public SYS_WidgetTypeBSO() 
        {
            //constructor
        }

        #region CreateSYS_WidgetType
        public int CreateSYS_WidgetTypeGet(SYS_WidgetType sys_WidgetType)
        {
            SYS_WidgetTypeDAO sys_WidgetTypeDAO = new SYS_WidgetTypeDAO();
            return sys_WidgetTypeDAO.CreateSYS_WidgetTypeGet(sys_WidgetType);
        }
        #endregion

        #region UpdateSYS_WidgetType
        public void UpdateSYS_WidgetType(SYS_WidgetType sys_WidgetType) 
        {
            SYS_WidgetTypeDAO sys_WidgetTypeDAO = new SYS_WidgetTypeDAO();
            sys_WidgetTypeDAO.UpdateSYS_WidgetType(sys_WidgetType);
        }
        #endregion

        #region DeleteSYS_WidgetType
        public void DeleteSYS_WidgetType(int Id) 
        {
            SYS_WidgetTypeDAO sys_WidgetTypeDAO = new SYS_WidgetTypeDAO();
            sys_WidgetTypeDAO.DeleteSYS_WidgetType(Id);
        }
        #endregion

        #region GetSYS_WidgetTypeById
        public SYS_WidgetType GetSYS_WidgetTypeById(int Id) 
        {
            SYS_WidgetTypeDAO sys_WidgetTypeDAO = new SYS_WidgetTypeDAO();
            return sys_WidgetTypeDAO.GetSYS_WidgetTypeById(Id);
        }
        #endregion


        #region GetSYS_WidgetTypeAll
        public DataTable GetSYS_WidgetTypeAll() 
        {
            SYS_WidgetTypeDAO sys_WidgetTypeDAO = new SYS_WidgetTypeDAO();
            return sys_WidgetTypeDAO.GetSYS_WidgetTypeAll();
        }

        #endregion 

        #region SYS_WidgetTypeUpOrder
        public void SYS_WidgetTypeUpOrder(int Id, int cOrder)
        {
            SYS_WidgetTypeDAO _widgettypeDAO = new SYS_WidgetTypeDAO();
            _widgettypeDAO.SYS_WidgetTypeUpOrder(Id, cOrder);
        }
        #endregion

    }
}
