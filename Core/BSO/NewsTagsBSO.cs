using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;


namespace BSO
{
    public class NewsTagsBSO
    {
        public NewsTagsBSO() 
        {
            //constructor
        }


        #region CreateNewsTags
        public void CreateNewsTags(NewsTags _newsTags) 
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            _newstagsDAO.CreateNewsTags(_newsTags);
        }
        #endregion

        #region UpdateNewsTags
        public void UpdateNewsTags(NewsTags _newsTags) 
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            _newstagsDAO.UpdateNewsTags(_newsTags);
        }
        #endregion

        #region DeleteNewsTags
        public void DeleteNewsTags(int Id) 
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            _newstagsDAO.DeleteNewsTags(Id);
        }
        #endregion

        #region DeleteNewsTagsTagsID
        public void DeleteNewsTagsTagsID(int Id)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            _newstagsDAO.DeleteNewsTagsTagsID(Id);
        }
        #endregion

        #region DeleteNewsTagsNewsID
        public void DeleteNewsTagsNewsID(int Id)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            _newstagsDAO.DeleteNewsTagsNewsID(Id);
        }
        #endregion

        #region GetNewsTagsById
        public NewsTags GetNewsTagsById(int Id) 
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNewsTagsById(Id);

        }
        #endregion

        #region GetNewsTagsByTags
        public DataTable GetNewsTagsByTags(int _tagsID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNewsTagsByTags(_tagsID);
        }
        #endregion

        #region GetNewsTagsByNews
        public DataTable GetNewsTagsByNews(int _newsID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNewsTagsByNews(_newsID);
        }
        #endregion

        #region GetNewsTagsAll
        public DataTable GetNewsTagsAll() 
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNewsTagsAll();
        }
        #endregion

        #region GetNewsTags
        public NewsTags GetNewsTags(int _tagsID, int _newsGroupID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNewsTags(_tagsID, _newsGroupID);
        }
        #endregion


        #region CheckExitTags
        public bool CheckExitTags(int _tagsID, int _newsGroupID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.CheckExitTags(_tagsID,_newsGroupID);
        }
        #endregion

        
        #region GetTags
        public string GetTags(int _newsGroupID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetTags(_newsGroupID);
        }
        #endregion

        #region GetNews
        public string GetNews(int _tagsID)
        {
            NewsTagsDAO _newstagsDAO = new NewsTagsDAO();
            return _newstagsDAO.GetNews(_tagsID);
        }

        
        #endregion
    }
}
