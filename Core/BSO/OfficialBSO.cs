using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class OfficialBSO
    {
        public OfficialBSO()
        {
            //Constructor
        }

        #region CreateOfficial
        public void CreateOfficial(Official official) 
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.CreateOfficial(official);
        }
        public int CreateOfficialGet(Official official)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.CreateOfficialGet(official);
        }
        #endregion

        #region UpdateOfficial
        public void UpdateOfficial(Official official) 
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficial(official);
        }
        #endregion

        #region UpdateOfficial
        public void UpdateOfficial(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficial(restr, value);
        }

        public void UpdateOfficial(int officialID, string value)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficial(officialID, value);
        }

        public void UpdateOfficial(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficial(restr, value, username, date);
        }
        public void UpdateOfficial(int Id, string value, string username, DateTime date)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficial(Id, value, username, date);
        }
        #endregion

        #region DeleteOfficial
        public void DeleteOfficial(int Id) 
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.DeleteOfficial(Id);
        }

        public void DeleteOfficial(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.DeleteOfficial(restr);
        }
        #endregion

        #region UpdateOfficialisDelete
        public void UpdateOfficialisDelete(string strId, string value)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficialisDelete(strId, value);
        }
        public void UpdateOfficialisDelete(int Id, string value)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.UpdateOfficialisDelete(Id, value);
        }
        #endregion

        #region GetOfficialById
        public Official GetOfficialById(int Id) 
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialById(Id);
        }
        #endregion

        #region GetOfficialAll
        public DataTable GetOfficialAll(string _lang) 
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialAll(_lang);
        }
        public DataTable GetOfficialAll(int group, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialAll(group,_lang);
        }
        public DataTable GetOfficialAll(int group, string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialAll(group, strCate,_lang);
        }
        #endregion

        #region GetOfficialNews
        public DataTable GetOfficialNews(int num, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num,_lang);
        }
        public DataTable GetOfficialNews(int num, int group, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num, group,_lang);
        }
        public DataTable GetOfficialNews(int num, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num, approval,_lang);
        }
        public DataTable GetOfficialNews(int num, int group, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num, group, approval,_lang);
        }
        #endregion

        #region OfficialSearch
        public DataTable OfficialSearch(string keyword, int cId, string lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.OfficialSearch(keyword, cId, lang);
        }
        public DataTable OfficialSearchPaging(string finter, PagingInfo _paging, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.OfficialSearchPaging(finter, _paging, _lang);
        }
        #endregion

        #region GetOfficialByCateHomeList
        public DataTable GetOfficialByCateHomeList(string strCate, int num, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num, _lang);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, int num, int group, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num, group, _lang);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num, approval, _lang);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, int num, int group, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num, group, approval, _lang);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, _lang);
        }

        public DataTable GetOfficialByCateHomeList(int group, string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(group, restr, _lang);
        }
        #endregion

        //client
        #region GetOfficialByCate
        public DataTable GetOfficialByCate(int CateID, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(CateID, _lang);
        }
        public DataTable GetOfficialByCate(int CateID, int group, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(CateID, group,_lang);
        }
        public DataTable GetOfficialByCate(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(restr,_lang);
        }
        public DataTable GetOfficialByCate(string strCate, int group, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(restr, group, _lang);
        }
        public DataTable GetOfficialByCate(int iCateId, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(iCateId, approval, _lang);
        }
        public DataTable GetOfficialByCate(int iCateId, int n, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(iCateId,n, approval, _lang);
        }
        public DataTable GetOfficialByCate(int iCateId, int n, int group, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(iCateId, n,group, approval, _lang);
        }
        public DataTable GetOfficialByCate(string strCate, int n, int group, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCate(restr, n, group, approval, _lang);
        }
        #endregion

        #region OfficialFollow
        public DataTable OfficialFollow(int Id, int cId, int n, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.OfficialFollow(Id, cId, n, _lang);

        }
        public DataTable OfficialFollow(int Id, int cId, int n, string approval, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.OfficialFollow(Id, cId, n, approval, _lang);

        }
        #endregion

        #region OfficialClickUpdate
        public void OfficialClickUpdate(int nId)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            officialDAO.OfficialClickUpdate(nId);
        }
        #endregion

        #region GetOfficialPagingbyUser

        public DataTable GetOfficialPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPagingbyUser(lang, group, strCate, _paging, username);
        }

        public DataTable GetOfficialPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username, int isApproved, int status)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPagingbyUser(lang, group, strCate, _paging, username, isApproved, status);
        }
        public DataTable GetOfficialPagingbyUserisDelete(string lang, int group, string strCate, PagingInfo _paging, string username, int isApproved, int status, int isDelete)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPagingbyUserisDelete(lang, group, strCate, _paging, username, isApproved, status, isDelete);
        }
        public DataTable GetOfficialPagingbyUserisDelete(string lang, int group, int officialCateID, PagingInfo _paging, string username, int isApproved, int status, int isDelete)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPagingbyUserisDelete(lang, group, officialCateID, _paging, username, isApproved, status, isDelete);
        }
        #endregion

        #region GetOfficialPaging
        public DataTable GetOfficialPaging(int group, PagingInfo _paging, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPaging(group, _paging, _lang);
        }

        public DataTable GetOfficialPaging(int group, string strCate, PagingInfo _paging, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPaging(group, restr, _paging,_lang);
        }
        public DataTable GetOfficialPaging(int group, int CateID, PagingInfo _paging, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPaging(group, CateID, _paging,_lang);
        }

        public DataTable GetOfficialPagingApproved(int group, int CateID, PagingInfo _paging, string _lang)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialPagingApproved(group, CateID, _paging, _lang);
        }
        #endregion
    }
}
