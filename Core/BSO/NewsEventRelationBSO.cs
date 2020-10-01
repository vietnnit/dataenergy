using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsEventRelationBSO
    {
        public NewsEventRelationBSO() 
        {
            //constructor
        }

        #region CreateNewsEventRelation
        public int CreateNewsEventRelationGet(NewsEventRelation newsEventRealation)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.CreateNewsEventRelationGet(newsEventRealation);
        }
        #endregion

        #region UpdateNewsEventRelation
        public void UpdateNewsEventRelation(NewsEventRelation newsEventRealation) 
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            newsEventRealationDAO.UpdateNewsEventRelation(newsEventRealation);
        }
        #endregion

        #region DeleteNewsEventRelation
        public void DeleteNewsEventRelation(int Id) 
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            newsEventRealationDAO.DeleteNewsEventRelation(Id);
        }
        public void DeleteNewsEventRelation(string strId, int newsEventID)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            newsEventRealationDAO.DeleteNewsEventRelation(restr, newsEventID);
        }
        #endregion


        #region GetNewsEventRelationByNewsEventID
        public DataTable GetNewsEventRelationByNewsEventID(int newsEventID)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationByNewsEventID(newsEventID);
        }
        public NewsEventRelation GetNewsEventRelationByNewsGroupID(int newsGroupID)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationByNewsGroupID(newsGroupID);
        }
        public NewsEventRelation GetNewsEventRelationByID(int newsGroupID, int newsEventID)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationByID(newsGroupID, newsEventID);
        }
        #endregion

        #region GetNewsEventRelationPaging
        public DataTable GetNewsEventRelationPaging(string lang, int newsEventID, PagingInfo _paging)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationPaging(lang, newsEventID, _paging);
        }
         #endregion

        #region GetNewsEventRelationSearchPaging
        public DataTable GetNewsEventRelationSearchPaging(string finter,string lang, int newsEventID, PagingInfo _paging)
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationSearchPaging(finter, lang, newsEventID, _paging);
        }
        #endregion
        #region GetNewsEventRelationAll
        public DataTable GetNewsEventRelationAll() 
        {
            NewsEventRelationDAO newsEventRealationDAO = new NewsEventRelationDAO();
            return newsEventRealationDAO.GetNewsEventRelationAll();
        }
        #endregion

       
    }
}
