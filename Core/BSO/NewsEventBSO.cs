using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsEventBSO
    {
        public NewsEventBSO() 
        {
            //constructor
        }

        #region CreateNewsEvent
        public void CreateNewsEvent(NewsEvent newsEvent) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.CreateNewsEvent(newsEvent);
        }
        #endregion

        #region CreateNewsEventGet
        public int CreateNewsEventGet(NewsEvent newsEvent)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.CreateNewsEventGet(newsEvent);
        }
        #endregion

        #region UpdateNewsEvent
        public void UpdateNewsEvent(NewsEvent newsEvent) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.UpdateNewsEvent(newsEvent);
        }
        #endregion

        #region UpdateNewsEvent
        public void UpdateNewsEvent(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.UpdateNewsEvent(restr, value);
        }
        #endregion

        #region UpdateNewsEventApproval
        public void UpdateNewsEventApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.UpdateNewsEventApproval(restr, value,username,date);
        }
        public void UpdateNewsEventApproval(int Id, string value, string username, DateTime date)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.UpdateNewsEventApproval(Id, value, username, date);
        }
        #endregion

        #region DeleteNewsEvent
        public void DeleteNewsEvent(int nId) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.DeleteNewsEvent(nId);
        }
        public void DeleteNewsEvent(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.DeleteNewsEvent(restr);
        }
        #endregion

        

        #region GetNewsEventById
        public NewsEvent GetNewsEventById(int nId) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventById(nId);
        }
        #endregion

        

        #region GetNewsEventAll
        public DataTable GetNewsEventAll(string lang) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventAll(lang);
        }
        public DataTable GetNewsEventAll(string lang, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventAll(lang, group);
        }
        public DataTable GetNewsEventAll(string lang, int group, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventAll(lang, group, restr);
        }
        public DataTable GetNewsEventAll(string lang, int group, int cateId)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventAll(lang, group, cateId);
        }
        #endregion

        #region GetNewsEventPaging
        public DataTable GetNewsEventPaging(string lang, int group, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPaging(lang, group, _paging);
        }
        public DataTable GetNewsEventPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPaging(lang, group, restr, _paging);
        }
        public DataTable GetNewsEventPaging(string lang, int group, int cateID, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPaging(lang, group,cateID, _paging);
        }
        public DataTable GetNewsEventPagingApproved(string lang, int group, int cateID, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPagingApproved(lang, group, cateID, _paging);
        }

        public DataTable GetNewsEventAllPaging(string lang, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventAllPaging(lang, _paging);
        }
        #endregion

        #region GetNewsEventPagingParent
        public DataTable GetNewsEventPagingParent(string lang, int group, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPagingParent(lang, group, _paging);
        }
        public DataTable GetNewsEventPagingParent(string lang, int group, string strCate, PagingInfo _paging)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPagingParent(lang, group, restr, _paging);
        }
        //public DataTable GetNewsEventPaging(string lang, int group, int cateID, PagingInfo _paging)
        //{
        //    NewsEventDAO newsEventDAO = new NewsEventDAO();
        //    return newsEventDAO.GetNewsEventPaging(lang, group, cateID, _paging);
        //}
        //public DataTable GetNewsEventPagingApproved(string lang, int group, int cateID, PagingInfo _paging)
        //{
        //    NewsEventDAO newsEventDAO = new NewsEventDAO();
        //    return newsEventDAO.GetNewsEventPagingApproved(lang, group, cateID, _paging);
        //}
        #endregion

        #region GetNewsEventPagingbyTags

        public DataTable GetNewsEventPagingbyTags(int tagsID, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPagingbyTags(tagsID, _paging);
        }
        public DataTable GetNewsEventPagingbyTagsApproved(int tagsID, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventPagingbyTagsApproved(tagsID, _paging);
        }
        #endregion

        #region GetNewsEventHot
        public DataTable GetNewsEventHot(string lang)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHot(lang);
        }
        public DataTable GetNewsEventHot(string lang, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHot(lang, group);
        }
        public DataTable GetNewsEventHot(string lang, int n, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHot(lang, n, group);
        }
        public DataTable GetNewsEventHot(string lang, int n, string approval, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHot(lang, n, approval, group);
        }
        public DataTable GetNewsEventHotOtherGroup(string lang, int n, string approval, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHotOtherGroup(lang, n, approval, group);
        }

        public DataTable GetNewsEventHot(int n, string lang, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHot(n, lang, approval);
        }
        #endregion

        #region GetNewsEventViewHome
        public DataTable GetNewsEventViewHome(string lang)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang);
        }
        public DataTable GetNewsEventViewHome(string lang, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang, group);
        }

        public DataTable GetNewsEventViewHome(string lang, int n, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang, n, group);
        }
        public DataTable GetNewsEventViewHome(string lang, int n, int cID, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang, n, cID, group);
        }

        public DataTable GetNewsEventViewHome(string lang, string strCate, int n, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang, restr, n, group);
        }

        public DataTable GetNewsEventViewHome(string lang, int n, string approval, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewHome(lang, n, approval, group);
        }
        #endregion

        #region NewsEventClickUpdate
        public void NewsEventClickUpdate(int nId) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            newsEventDAO.NewsEventClickUpdate(nId);
        }
        #endregion

        #region NewsEventSearch
        public DataTable NewsEventSearch(string keyword,int cId,string lang) 
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventSearch(keyword, cId, lang);
        }

        public DataTable NewsEventSearch(string _findter)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventSearch(_findter);
        }

        public DataTable NewsEventSearchPaging(string _findter, PagingInfo _paging)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventSearchPaging(_findter, _paging);
        }


        #endregion


        #region GetNewsEventView
        public DataTable GetNewsEventView(string lang)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventView(lang);
        }
        public DataTable GetNewsEventView(string lang, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventView(lang, group);
        }
        #endregion
        

        //client
        #region GetNewsEventByCate
        public DataTable GetNewsEventByCate(int iCateId , string lang) 
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsEventAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' ";
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsEventByCate(int iCateId, string lang, string approval)
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsEventAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' and IsApproval =" + approval;
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsEventByCate(int iCateId, string lang, int n, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCate(iCateId, lang, n, approval);

        }

        

        #endregion

        #region NewsEventFollow
        public DataTable NewsEventFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();

            NewsEvent newsEvent = GetNewsEventById(Id);
            DateTime PostTime = newsEvent.PostDate;

            DataTable table = GetNewsEventAll(Language.language);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "NewsEventID <> " + Id + "and CateNewsID = " + cId;
                dataView.Sort = "PostDate DESC ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable NewsEventFollow(int Id, int cId, int n)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventFollow(Id, cId, n);

        }
        public DataTable NewsEventFollow(int Id, int cId, int n, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventFollow(Id, cId, n, approval);

        }
        #endregion

        #region NewsEventParent
        public DataTable NewsEventParent(int pId, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.NewsEventParent(pId, approval);

        }
        #endregion

        #region GetNewsEventByCateAll
        public DataTable GetNewsEventByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateAll(restr);
        }
        public DataTable GetNewsEventByCateAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateAll(restr, group);
        }
        #endregion

        #region GetNewsEventByCateHomeAll
        public DataTable GetNewsEventByCateHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeAll(restr, group);
        }

        public DataTable GetNewsEventByCateHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeAll(n, restr, group);
        }
        public DataTable GetNewsEventByCateHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeAll(n, restr, approval, group);
        }
        #endregion

        #region GetNewsEventByCateIsHomeAll
        public DataTable GetNewsEventByCateIsHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateIsHomeAll(restr, group);
        }

        public DataTable GetNewsEventByCateIsHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateIsHomeAll(n, restr, group);
        }
        public DataTable GetNewsEventByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateIsHomeAll(n, restr, approval, group);
        }
        #endregion

        #region GetNewsEventByCateHomeList
        public DataTable GetNewsEventByCateHomeList(string strCate, int num, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, num, group);
        }
        public DataTable GetNewsEventByCateHomeList(string strCate, int num, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, num, approval, group);
        }
        public DataTable GetNewsEventByCateHomeList(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, group);
        }
        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string aproval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, group, aproval);
        }
        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string aproval, int num, string isHome)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, group, aproval, num, isHome);
        }
        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string aproval, int num, string isHome, string lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHomeList(restr, group, aproval, num, isHome, lang);
        }

        public DataTable GetNewsEventByCateHot(string strCate, int group, string aproval, int num, string isHome, string isHot)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByCateHot(restr, group, aproval, num, isHome, isHot);
        }
        #endregion

        #region GetNewsEventByListNewsID
        public DataTable GetNewsEventByListNewsID(string lang, string strCate, string aproval, string isHome)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByListNewsID(lang, restr, aproval, isHome);
        }
        public DataTable GetNewsEventByListNewsID(string lang, string strCate, int num, string aproval, string isHome)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventByListNewsID(lang, restr, num, aproval, isHome);
        }
        #endregion

        #region GetNewsEventViewAll
        public DataTable GetNewsEventViewAll(string lang, int n, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewAll(lang, n, group);
        }
        public DataTable GetNewsEventViewAll(string lang, int n, int group, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventViewAll(lang, n, group, approval);
        }
        #endregion

        public DataTable GetNewsEventLates(string lang, int n, string approval, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventLates(lang, n, approval, group);
        }
        public DataTable GetNewsEventLates(string lang, int n, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventLates(lang, n, approval);
        }

        public DataTable GetNewsEventHits(string lang, int n, string approval, int group)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHits(lang, n, approval, group);
        }
        public DataTable GetNewsEventHits(string lang, int n, string approval)
        {
            NewsEventDAO newsEventDAO = new NewsEventDAO();
            return newsEventDAO.GetNewsEventHits(lang, n, approval);
        }
    }
}
