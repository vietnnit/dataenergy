using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsCateBSO
    {
        public NewsCateBSO() 
        {
            //constructor
        }

        #region CreateNewsCate
        public int CreateNewsCateGet(NewsCate newsCate)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.CreateNewsCateGet(newsCate);
        }
        #endregion

        #region UpdateNewsCate
        public void UpdateNewsCate(NewsCate newsCate) 
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            newsCateDAO.UpdateNewsCate(newsCate);
        }
        #endregion

        #region DeleteNewsCate
        public void DeleteNewsCate(int Id) 
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            newsCateDAO.DeleteNewsCate(Id);
        }
        public void DeleteNewsCate(string strId, int cateNewsID)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            newsCateDAO.DeleteNewsCate(restr, cateNewsID);
        }
        public void DeleteNewsCatebyNewsID(int _newsID)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            newsCateDAO.DeleteNewsCatebyNewsID(_newsID);
        }
        public void DeleteNewsCatebyCateID(int _cateID)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            newsCateDAO.DeleteNewsCatebyCateID(_cateID);
        }
        #endregion


        #region GetNewsCateByCateNewsID
        public DataTable GetNewsCateByCateNewsID(int cateNewsID)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.GetNewsCateByCateNewsID(cateNewsID);
        }
        public DataTable GetNewsCateByNewsGroupID(int newsGroupID)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.GetNewsCateByNewsGroupID(newsGroupID);
        }
        public NewsCate GetNewsCateByID(int newsGroupID, int cateNewsID)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.GetNewsCateByID(newsGroupID, cateNewsID);
        }
        #endregion

        #region GetNewsCatePaging
        public DataTable GetNewsCatePaging(string lang, int cateNewsID, PagingInfo _paging)
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.GetNewsCatePaging(lang, cateNewsID, _paging);
        }
         #endregion
        #region GetNewsCateAll
        public DataTable GetNewsCateAll() 
        {
            NewsCateDAO newsCateDAO = new NewsCateDAO();
            return newsCateDAO.GetNewsCateAll();
        }
        #endregion

       
    }
}
