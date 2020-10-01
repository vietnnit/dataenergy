using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class SYS_TemplatePageBSO
    {
        public SYS_TemplatePageBSO() 
        {
            //constructor
        }

        

        #region CreateSYS_TemplatePage
        public int CreateSYS_TemplatePageGet(SYS_TemplatePage sys_TemplatePage)
        {
            SYS_TemplatePageDAO sys_TemplatePageDAO = new SYS_TemplatePageDAO();
            return sys_TemplatePageDAO.CreateSYS_TemplatePageGet(sys_TemplatePage);
        }
        #endregion

        #region UpdateSYS_TemplatePage
        public void UpdateSYS_TemplatePage(SYS_TemplatePage sys_TemplatePage)
        {
            SYS_TemplatePageDAO sys_TemplatePageDAO = new SYS_TemplatePageDAO();
            sys_TemplatePageDAO.UpdateSYS_TemplatePage(sys_TemplatePage);
        }
        #endregion

        #region DeleteSYS_TemplatePage
        public void DeleteSYS_TemplatePage(int Id) 
        {
            SYS_TemplatePageDAO sys_TemplatePageDAO = new SYS_TemplatePageDAO();
            sys_TemplatePageDAO.DeleteSYS_TemplatePage(Id);
        }
        #endregion

        #region GetSYS_TemplatePageById
        public SYS_TemplatePage GetSYS_TemplatePageById(int Id) 
        {
            SYS_TemplatePageDAO sys_TemplatePageDAO = new SYS_TemplatePageDAO();
            return sys_TemplatePageDAO.GetSYS_TemplatePageById(Id);
        }
        #endregion

        

        #region GetSYS_TemplatePageAll
        public DataTable GetSYS_TemplatePageAll(string _lang) 
        {
            SYS_TemplatePageDAO sys_TemplatePageDAO = new SYS_TemplatePageDAO();
            return sys_TemplatePageDAO.GetSYS_TemplatePageAll(_lang);
        }
        #endregion
    }
}
