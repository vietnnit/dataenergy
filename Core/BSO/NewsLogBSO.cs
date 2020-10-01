using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsLogBSO
    {
        public NewsLogBSO() 
        {
            //constructor
        }

        public NewsLog GetNewsLog(NewsGroup newGroup, string username, DateTime date, int version)
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            return newsLogDAO.GetNewsLog(newGroup, username, date, version);
        }

        #region CreateNewsLog
        public int CreateNewsLog(NewsLog newsLog) 
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            return newsLogDAO.CreateNewsLog(newsLog);
        }
        #endregion

        

        #region UpdateNewsLog
        public void UpdateNewsLog(NewsLog newsLog) 
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            newsLogDAO.UpdateNewsLog(newsLog);
        }
        #endregion

    
        #region DeleteNewsLog
        public void DeleteNewsLog(int newsLogID, int newsGroupID) 
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            newsLogDAO.DeleteNewsLog(newsLogID, newsGroupID);
        }
        public void DeleteNewsLog(string strId)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            newsLogDAO.DeleteNewsLog(strId);
        }
        #endregion

        

        #region GetNewsLogById
        public NewsLog GetNewsLogById(int nId) 
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            return newsLogDAO.GetNewsLogById(nId);
        }
        #endregion

        
        #region GetNewsLogPaging
        public DataTable GetNewsLogPaging(string lang, int newsGroupID, PagingInfo _paging)
        {
            NewsLogDAO newsLogDAO = new NewsLogDAO();
            return newsLogDAO.GetNewsLogPaging(lang, newsGroupID, _paging);
        }
       
        #endregion
    }
}
