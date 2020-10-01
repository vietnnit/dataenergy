using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class OfficialFileBSO
    {
        public OfficialFileBSO()
        {
            //constructor
        }

        #region CreateOfficialFile
        public void CreateOfficialFile(OfficialFile officialFile)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            officialFileDAO.CreateOfficialFile(officialFile);
        }
        #endregion

        #region UpdateOfficialFile
        public void UpdateOfficialFile(OfficialFile officialFile)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            officialFileDAO.UpdateOfficialFile(officialFile);
        }
        #endregion

        #region DeleteOfficialFile
        public void DeleteOfficialFile(int Id)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            officialFileDAO.DeleteOfficialFile(Id);
        }
        public void DeleteOfficialFile(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            officialFileDAO.DeleteOfficialFile(restr);
        }
        #endregion

        #region GetOfficialFileByID
        public OfficialFile GetOfficialFileByID(int Id)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileByID(Id);

        }
        #endregion


        #region GetOfficialFileByOfficial
        public DataTable GetOfficialFileByOfficial(int pId)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileByOfficial(pId);

        }
        #endregion

        #region GetOfficialFileAll
        public DataTable GetOfficialFileAll()
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileAll();

        }
        #endregion
    }
}
