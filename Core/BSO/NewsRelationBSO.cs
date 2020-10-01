using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsRelationBSO
    {
        public NewsRelationBSO() 
        {
            //constructor
        }

        #region CreateNewsRelation
        public int CreateNewsRelationGet(NewsRelation newsRelation)
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.CreateNewsRelationGet(newsRelation);
        }
        #endregion

        #region UpdateNewsRelation
        public void UpdateNewsRelation(NewsRelation newsRelation) 
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            newsRelationDAO.UpdateNewsRelation(newsRelation);
        }
        #endregion

        #region DeleteNewsRelation
        public void DeleteNewsRelation(int Id) 
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            newsRelationDAO.DeleteNewsRelation(Id);
        }
        public void DeleteNewsRelation(string strId, int newsID)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            newsRelationDAO.DeleteNewsRelation(restr, newsID);
        }
        #endregion


        #region GetNewsRelationByNewsID
        public DataTable GetNewsRelationByNewsID(int newsID)
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.GetNewsRelationByNewsID(newsID);
        }
        public NewsRelation GetNewsRelationByNewsGroupID(int newsGroupID)
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.GetNewsRelationByNewsGroupID(newsGroupID);
        }
        public NewsRelation GetNewsRelationByID(int newsGroupID, int newsID)
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.GetNewsRelationByID(newsGroupID, newsID);
        }
        #endregion

        #region GetNewsRelationPaging
        public DataTable GetNewsRelationPaging(string lang, int newsID, PagingInfo _paging)
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.GetNewsRelationPaging(lang, newsID, _paging);
        }
         #endregion
        #region GetNewsRelationAll
        public DataTable GetNewsRelationAll() 
        {
            NewsRelationDAO newsRelationDAO = new NewsRelationDAO();
            return newsRelationDAO.GetNewsRelationAll();
        }
        #endregion

       
    }
}
