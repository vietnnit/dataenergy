using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsRegisterBSO
    {
        public NewsRegisterBSO() 
        {
            //constructor
        }

        #region CreateNewsRegister
        public void CreateNewsRegister(NewsRegister _newsRegister) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.CreateNewsRegister(_newsRegister);
        }

        public int CreateNewsRegisterGet(NewsRegister _newsRegister)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.CreateNewsRegisterGet(_newsRegister);
        }
        #endregion

        #region UpdateNewsRegister
        public void UpdateNewsRegister(NewsRegister _newsRegister) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.UpdateNewsRegister(_newsRegister);
        }
        #endregion

        #region UpdateNewsRegister
        public void UpdateNewsRegister(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.UpdateNewsRegister(restr, value);
        }
        #endregion

        #region UpdateNewsRegisterApproval
        public void UpdateNewsRegisterApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.UpdateNewsRegisterApproval(restr, value,username,date);
        }
        public void UpdateNewsRegisterApproval(int Id, string value, string username, DateTime date)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.UpdateNewsRegisterApproval(Id, value, username, date);
        }
        #endregion

        #region DeleteNewsRegister
        public void DeleteNewsRegister(int nId) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.DeleteNewsRegister(nId);
        }
        public void DeleteNewsRegister(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.DeleteNewsRegister(restr);
        }
        #endregion



        #region GetNewsRegisterByParentNewsId
        public NewsRegister GetNewsRegisterByParentNewsId(int nId) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByParentNewsId(nId);
        }
        #endregion

        #region GetNewsRegisterById
        public NewsRegister GetNewsRegisterById(int nId)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterById(nId);
        }
        #endregion

        

        #region GetNewsRegisterAll
        public DataTable GetNewsRegisterAll(string lang) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterAll(lang);
        }
        public DataTable GetNewsRegisterAll(string lang, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterAll(lang, group);
        }
        public DataTable GetNewsRegisterAll(string lang, int group, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterAll(lang, group, restr);
        }
        #endregion

        #region GetNewsRegisterPaging
        public DataTable GetNewsRegisterPaging(string lang, int group, PagingInfo _paging)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterPaging(lang, group, _paging);
        }
        public DataTable GetNewsRegisterPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterPaging(lang, group, restr, _paging);
        }
        #endregion

        #region GetNewsRegisterHot
        public DataTable GetNewsRegisterHot(string lang)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHot(lang);
        }
        public DataTable GetNewsRegisterHot(string lang, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHot(lang, group);
        }
        public DataTable GetNewsRegisterHot(string lang, int n, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHot(lang, n, group);
        }
        public DataTable GetNewsRegisterHot(string lang, int n, string approval, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHot(lang, n, approval, group);
        }
        public DataTable GetNewsRegisterHotOtherGroup(string lang, int n, string approval, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHotOtherGroup(lang, n, approval, group);
        }

        public DataTable GetNewsRegisterHot(int n, string lang, string approval)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterHot(n, lang, approval);
        }
        #endregion

        #region GetNewsRegisterViewHome
        public DataTable GetNewsRegisterViewHome(string lang)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang);
        }
        public DataTable GetNewsRegisterViewHome(string lang, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang, group);
        }

        public DataTable GetNewsRegisterViewHome(string lang, int n, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang, n, group);
        }
        public DataTable GetNewsRegisterViewHome(string lang, int n, int cID, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang, n, cID, group);
        }

        public DataTable GetNewsRegisterViewHome(string lang, string strCate, int n, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang, restr, n, group);
        }

        public DataTable GetNewsRegisterViewHome(string lang, int n, string approval, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewHome(lang, n, approval, group);
        }
        #endregion

        #region NewsRegisterClickUpdate
        public void NewsRegisterClickUpdate(int nId) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            _newsRegisterDAO.NewsRegisterClickUpdate(nId);
        }
        #endregion

        #region NewsRegisterSearch
        public DataTable NewsRegisterSearch(string keyword,int cId,string lang) 
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.NewsRegisterSearch(keyword, cId, lang);
        }

        public DataTable NewsRegisterSearch(string _findter)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.NewsRegisterSearch(_findter);
        }


        #endregion


        #region GetNewsRegisterView
        public DataTable GetNewsRegisterView(string lang)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterView(lang);
        }
        public DataTable GetNewsRegisterView(string lang, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterView(lang, group);
        }
        #endregion
        

        //client
        #region GetNewsRegisterByCate
        public DataTable GetNewsRegisterByCate(int iCateId , string lang) 
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsRegisterAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' ";
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsRegisterByCate(int iCateId, string lang, string approval)
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsRegisterAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' and IsApproval =" + approval;
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsRegisterByCate(int iCateId, string lang, int n, string approval)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCate(iCateId, lang, n, approval);

        }

        

        #endregion

        #region NewsRegisterFollow
        public DataTable NewsRegisterFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();

            NewsRegister _newsRegister = GetNewsRegisterById(Id);
            DateTime PostTime = _newsRegister.PostDate;

            DataTable table = GetNewsRegisterAll(Language.language);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "NewsRegisterID <> " + Id + "and CateNewsID = " + cId;
                dataView.Sort = "PostDate DESC ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable NewsRegisterFollow(int Id, int cId, int n)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.NewsRegisterFollow(Id, cId, n);

        }
        public DataTable NewsRegisterFollow(int Id, int cId, int n, string approval)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.NewsRegisterFollow(Id, cId, n, approval);

        }
        #endregion

        #region GetNewsRegisterByCateAll
        public DataTable GetNewsRegisterByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateAll(restr);
        }
        public DataTable GetNewsRegisterByCateAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateAll(restr, group);
        }
        #endregion

        #region GetNewsRegisterByCateHomeAll
        public DataTable GetNewsRegisterByCateHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeAll(restr, group);
        }

        public DataTable GetNewsRegisterByCateHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeAll(n, restr, group);
        }
        public DataTable GetNewsRegisterByCateHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeAll(n, restr, approval, group);
        }
        #endregion

        #region GetNewsRegisterByCateIsHomeAll
        public DataTable GetNewsRegisterByCateIsHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateIsHomeAll(restr, group);
        }

        public DataTable GetNewsRegisterByCateIsHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateIsHomeAll(n, restr, group);
        }
        public DataTable GetNewsRegisterByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateIsHomeAll(n, restr, approval, group);
        }
        #endregion

        #region GetNewsRegisterByCateHomeList
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int num, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeList(restr, num, group);
        }
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int num, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeList(restr, num, approval, group);
        }
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeList(restr, group);
        }
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group, string aproval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeList(restr, group, aproval);
        }
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group, string aproval, int num, string isHome)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterByCateHomeList(restr, group, aproval, num, isHome);
        }
        #endregion

        #region GetNewsRegisterViewAll
        public DataTable GetNewsRegisterViewAll(string lang, int n, int group)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewAll(lang, n, group);
        }
        public DataTable GetNewsRegisterViewAll(string lang, int n, int group, string approval)
        {
            NewsRegisterDAO _newsRegisterDAO = new NewsRegisterDAO();
            return _newsRegisterDAO.GetNewsRegisterViewAll(lang, n, group, approval);
        }
        #endregion
    }
}
