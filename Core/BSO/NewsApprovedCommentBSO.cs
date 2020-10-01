using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;


namespace BSO
{
    public class NewsApprovedCommentBSO
    {
        public NewsApprovedCommentBSO()
        {
            //constructor
        }
        #region CreateNewsApprovedComment
        public void CreateNewsApprovedComment(NewsApprovedComment newsApprovedComment)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.CreateNewsApprovedComment(newsApprovedComment);
        }
        public int CreateNewsApprovedCommentGet(NewsApprovedComment newsApprovedComment)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.CreateNewsApprovedCommentGet(newsApprovedComment);
        }
        #endregion

        #region GetNewsApprovedCommentById
        public NewsApprovedComment GetNewsApprovedCommentById(int commentID)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.GetNewsApprovedCommentById(commentID);
        }
        #endregion

        #region GetAllNewsApprovedComment
        public DataTable GetAllNewsApprovedComment()
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.GetAllNewsApprovedComment();
        }
        #endregion

      

        #region GetAllNewsGroupApprovedComment
        public DataTable GetAllNewsGroupApprovedComment()
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.GetAllNewsGroupApprovedComment();
        }

        public DataTable GetAllNewsGroupApprovedComment(int ID)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.GetAllNewsGroupApprovedComment(ID);
        }
        #endregion

        #region GetNewsApprovedCommentByNewsID
        public DataTable GetNewsApprovedCommentByNewsID(int newsID)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            return newsApprovedCommentDAO.GetNewsApprovedCommentByNewsID(newsID);
        }
        #endregion


        #region UpdateNewsApprovedComment
        public void UpdateNewsApprovedComment(NewsApprovedComment newsApprovedComment)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.UpdateNewsApprovedComment(newsApprovedComment);
        }
        #endregion
        #region UpdateNewsApprovedComment
        public void UpdateNewsApprovedComment(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.UpdateNewsApprovedComment(restr, value);
        }

        public void UpdateNewsApprovedComment(string strId, string value,string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.UpdateNewsApprovedComment(restr, value,username,date);
        }
        public void UpdateNewsApprovedComment(int Id, string value, string username, DateTime date)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.UpdateNewsApprovedComment(Id, value, username, date);
        }
        #endregion

        #region DeleteNewsApprovedComment
        public void DeleteNewsApprovedComment(int commentID)
        {
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.DeleteNewsApprovedComment(commentID);
        }
        #endregion

        #region DeleteNewsApprovedComment
        public void DeleteNewsApprovedComment(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsApprovedCommentDAO newsApprovedCommentDAO = new NewsApprovedCommentDAO();
            newsApprovedCommentDAO.DeleteNewsApprovedComment(restr);
        }
        #endregion



    }
}
