using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;


namespace BSO
{
    public class NewsCommentBSO
    {
        public NewsCommentBSO()
        {
            //constructor
        }
        #region CreateNewsComment
        public void CreateNewsComment(NewsComment newsComment)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.CreateNewsComment(newsComment);
        }
        public int CreateNewsCommentGet(NewsComment newsComment)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.CreateNewsCommentGet(newsComment);
        }
        #endregion

        #region GetNewsCommentById
        public NewsComment GetNewsCommentById(int commentID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetNewsCommentById(commentID);
        }
        #endregion

        #region GetAllNewsComment
        public DataTable GetAllNewsComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsComment();
        }
        #endregion

        #region GetAllGroupCateNewsComment
        public DataTable GetAllGroupCateNewsComment(int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllGroupCateNewsComment(group);
        }
        #endregion

        #region GetAllViewNewsComment
        public DataTable GetAllViewNewsComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewNewsComment();
        }

        public DataTable GetAllViewNewsComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewNewsComment(ID);
        }
        #endregion

        #region GetAllViewAnnounceComment
        public DataTable GetAllViewAnnounceComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewAnnounceComment();
        }

        public DataTable GetAllViewAnnounceComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewAnnounceComment(ID);
        }
        #endregion

        #region GetAllViewCompanyComment
        public DataTable GetAllViewCompanyComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewCompanyComment();
        }

        public DataTable GetAllViewCompanyComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewCompanyComment(ID);
        }
        #endregion

        #region GetAllViewDownloadComment
        public DataTable GetAllViewDownloadComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewDownloadComment();
        }

        public DataTable GetAllViewDownloadComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewDownloadComment(ID);
        }
        #endregion

        #region GetAllNewsGroupComment
        public DataTable GetAllNewsGroupComment(int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsGroupComment(group);
        }

        public DataTable GetAllNewsGroupComment(int ID, int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsGroupComment(ID, group);
        }
        #endregion

        #region GetNewsCommentByNewsID
        public DataTable GetNewsCommentByNewsID(int newsID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetNewsCommentByNewsID(newsID);
        }
        #endregion


        #region UpdateNewsComment
        public void UpdateNewsComment(NewsComment newsComment)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.UpdateNewsComment(newsComment);
        }
        #endregion
        #region UpdateNewsComment
        public void UpdateNewsComment(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.UpdateNewsComment(restr, value);
        }

        public void UpdateNewsComment(string strId, string value,string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.UpdateNewsComment(restr, value,username,date);
        }
        public void UpdateNewsComment(int Id, string value, string username, DateTime date)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.UpdateNewsComment(Id, value, username, date);
        }
        #endregion

        #region DeleteNewsComment
        public void DeleteNewsComment(int commentID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.DeleteNewsComment(commentID);
        }
        #endregion

        #region DeleteNewsComment
        public void DeleteNewsComment(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            newsCommentDAO.DeleteNewsComment(restr);
        }
        #endregion



    }
}
