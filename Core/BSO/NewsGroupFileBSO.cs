using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsGroupFileBSO
    {
        public NewsGroupFileBSO()
        {
            //constructor
        }

        #region CreateNewsGroupFile
        public void CreateNewsGroupFile(NewsGroupFile _newsGroupFile)
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            _newsGroupFileDAO.CreateNewsGroupFile(_newsGroupFile);
        }
        #endregion

        #region UpdateNewsGroupFile
        public void UpdateNewsGroupFile(NewsGroupFile _newsGroupFile)
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            _newsGroupFileDAO.UpdateNewsGroupFile(_newsGroupFile);
        }
        #endregion

        #region DeleteNewsGroupFile
        public void DeleteNewsGroupFile(int Id)
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            _newsGroupFileDAO.DeleteNewsGroupFile(Id);
        }
        public void DeleteNewsGroupFile(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            _newsGroupFileDAO.DeleteNewsGroupFile(restr);
        }
        #endregion

        #region GetNewsGroupFileByID
        public NewsGroupFile GetNewsGroupFileByID(int Id)
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            return _newsGroupFileDAO.GetNewsGroupFileByID(Id);

        }
        #endregion


        #region GetNewsGroupFileByNewsGroup
        public DataTable GetNewsGroupFileByNewsGroup(int pId)
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            return _newsGroupFileDAO.GetNewsGroupFileByNewsGroup(pId);

        }
        #endregion

        #region GetNewsGroupFileAll
        public DataTable GetNewsGroupFileAll()
        {
            NewsGroupFileDAO _newsGroupFileDAO = new NewsGroupFileDAO();
            return _newsGroupFileDAO.GetNewsGroupFileAll();

        }
        #endregion
    }
}
