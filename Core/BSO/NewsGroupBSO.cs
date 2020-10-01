using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class NewsGroupBSO
    {
        public NewsGroupBSO()
        {
            //constructor
        }

        #region CreateNewsGroup
        public void CreateNewsGroup(NewsGroup newsGroup)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.CreateNewsGroup(newsGroup);
        }
        #endregion

        #region CreateNewsGroupGet
        public int CreateNewsGroupGet(NewsGroup newsGroup)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.CreateNewsGroupGet(newsGroup);
        }
        #endregion

        #region UpdateNewsGroup
        public void UpdateNewsGroup(NewsGroup newsGroup)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroup(newsGroup);
        }
        #endregion

        #region UpdateNewsGroup
        public void UpdateNewsGroup(string strId, string value)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroup(strId, value);
        }
        public void UpdateNewsGroup(int Id, string value)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroup(Id, value);
        }
        #endregion

        #region UpdateNewsGroupApproval
        public void UpdateNewsGroupApproval(string strId, string value, string username, DateTime date)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroupApproval(strId, value, username, date);
        }
        public void UpdateNewsGroupApproval(int Id, string value, string username, DateTime date)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroupApproval(Id, value, username, date);
        }
        #endregion

        #region UpdateNewsGroupisDelete
        public void UpdateNewsGroupisDelete(string strId, string value)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroupisDelete(strId, value);
        }
        public void UpdateNewsGroupisDelete(int Id, string value)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroupisDelete(Id, value);
        }
        #endregion

        #region UpdateNewsGroupCate
        public void UpdateNewsGroupCate(int cateNewsID, int groupCate)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.UpdateNewsGroupCate(cateNewsID, groupCate);
        }
        #endregion

        #region DeleteNewsGroup
        public void DeleteNewsGroup(int nId)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.DeleteNewsGroup(nId);
        }
        public void DeleteNewsGroup(string strId)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.DeleteNewsGroup(strId);
        }
        #endregion



        #region GetNewsGroupById
        public NewsGroup GetNewsGroupById(int nId)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupById(nId);
        }
        #endregion



        #region GetNewsGroupAll
        public DataTable GetNewsGroupAll(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang);
        }
        public DataTable GetNewsGroupAll(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang, group);
        }
        public DataTable GetNewsGroupAll(string lang, int group, string strCate)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang, group, strCate);
        }
        #endregion

        #region GetNewsGroupPagingbyUser

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyUser(lang, group, strCate, _paging, username);
        }

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username, int isApproved, int status)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyUser(lang, group, strCate, _paging, username, isApproved, status);
        }

        public DataTable GetNewsGroupPagingbyUserisDelete(string lang, int group, string strCate, PagingInfo _paging, string username, int isApproved, int status, int isDelete)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyUserisDelete(lang, group, strCate, _paging, username, isApproved, status, isDelete);
        }
        #endregion

        #region GetNewsGroupPaging
        public DataTable GetNewsGroupPaging(string lang, int group, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPaging(lang, group, _paging);
        }
        public DataTable GetNewsGroupPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPaging(lang, group, strCate, _paging);
        }
        public DataTable GetNewsGroupPaging(string lang, int group, int cateID, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPaging(lang, group, cateID, _paging);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, int cateID, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, cateID, _paging);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, strCate, _paging);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, int cateID, PagingInfo _paging, int isApproved, int status)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, cateID, _paging, isApproved, status);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging, int isApproved, int status)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, strCate, _paging, isApproved, status);
        }
        public DataTable GetNewsGroupAllPaging(string lang, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAllPaging(lang, _paging);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, int cateID, PagingInfo _paging, int isApproved, int status, int isHot, int isHome)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, cateID, _paging, isApproved, status, isHot, isHome);
        }
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging, int isApproved, int status, int isHot, int isHome)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, strCate, _paging, isApproved, status, isHot, isHome);
        }
        #endregion

        #region GetNewsGroupPagingParent
        public DataTable GetNewsGroupPagingParent(string lang, int group, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingParent(lang, group, _paging);
        }
        public DataTable GetNewsGroupPagingParent(string lang, int group, string strCate, PagingInfo _paging)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingParent(lang, group, strCate, _paging);
        }
        //public DataTable GetNewsGroupPaging(string lang, int group, int cateID, PagingInfo _paging)
        //{
        //    NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
        //    return newsGroupDAO.GetNewsGroupPaging(lang, group, cateID, _paging);
        //}
        //public DataTable GetNewsGroupPagingApproved(string lang, int group, int cateID, PagingInfo _paging)
        //{
        //    NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
        //    return newsGroupDAO.GetNewsGroupPagingApproved(lang, group, cateID, _paging);
        //}
        #endregion

        #region GetNewsGroupPagingbyTags

        public DataTable GetNewsGroupPagingbyTags(int tagsID, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyTags(tagsID, _paging);
        }
        public DataTable GetNewsGroupPagingbyTagsApproved(int tagsID, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyTagsApproved(tagsID, _paging);
        }
        #endregion

        #region GetNewsGroupHot
        public DataTable GetNewsGroupHot(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang);
        }
        public DataTable GetNewsGroupHot(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, group);
        }
        public DataTable GetNewsGroupHot(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, n, group);
        }
        public DataTable GetNewsGroupHot(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, n, approval, group);
        }
        //public DataTable GetNewsNoGroupCateHot(string lang, int n, int group)
        //{
        //    NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
        //    return newsGroupDAO.GetNewsNoGroupCateHot(lang, n, group);
        //}

        public DataTable GetNewsGroupHot(string lang, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, approval, group);
        }
        public DataTable GetNewsOneByGroup(string lang, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsOneByGroup(lang, approval, group);
        }
        public DataTable GetNewsGroupHot(string lang, string approval, string hot, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, approval, hot, group);
        }
        public DataTable GetNewsGroupHotOtherGroup(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHotOtherGroup(lang, n, approval, group);
        }

        public DataTable GetNewsGroupHot(int n, string lang, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(n, lang, approval);
        }

        #endregion

        #region GetNewsGroupViewHome
        public DataTable GetNewsGroupViewHome(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang);
        }
        public DataTable GetNewsGroupViewHome(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, group);
        }
        public DataTable GetNewsGroupViewHome(string lang, int n, int cID, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, cID, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, string strCate, int n, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, strCate, n, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, approval, group);
        }
        #endregion

        #region NewsGroupClickUpdate
        public void NewsGroupClickUpdate(int nId)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            newsGroupDAO.NewsGroupClickUpdate(nId);
        }
        #endregion

        #region NewsGroupSearch
        public DataTable NewsGroupSearch(string keyword, int cId, string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupSearch(keyword, cId, lang);
        }

        public DataTable NewsGroupSearch(string _findter)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupSearch(_findter);
        }

        public DataTable NewsGroupSearchPaging(string _findter, PagingInfo _paging)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupSearchPaging(_findter, _paging);
        }


        #endregion


        #region GetNewsGroupView
        public DataTable GetNewsGroupView(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupView(lang);
        }
        public DataTable GetNewsGroupView(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupView(lang, group);
        }
        #endregion


        //client
        #region GetNewsGroupByCate
        public DataTable GetNewsGroupByCate(int iCateId, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsGroupAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' ";
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsGroupByCate(int iCateId, string lang, string approval)
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetNewsGroupAll(lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' and IsApproval =" + approval;
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable GetNewsGroupByCate(int iCateId, string lang, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCate(iCateId, lang, n, approval);

        }



        #endregion

        #region NewsGroupFollow
        public DataTable NewsGroupFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();

            NewsGroup newsGroup = GetNewsGroupById(Id);
            DateTime PostTime = newsGroup.PostDate;

            DataTable table = GetNewsGroupAll(Language.language);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "NewsGroupID <> " + Id + "and CateNewsID = " + cId;
                dataView.Sort = "PostDate DESC ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable NewsGroupFollow(int Id, int cId, int n)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupFollow(Id, cId, n);

        }
        public DataTable NewsGroupFollow(int Id, int cId, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupFollow(Id, cId, n, approval);

        }
        public DataTable NewsGroupFollow(DateTime postDateID, int id, int cId, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupFollow(postDateID, id, cId, n, approval);

        }
        #endregion

        #region NewsGroupParent
        public DataTable NewsGroupParent(int pId, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupParent(pId, approval);

        }
        #endregion

        #region GetNewsGroupByCateAll
        public DataTable GetNewsGroupByCateAll(string strCate)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateAll(strCate);
        }
        public DataTable GetNewsGroupByCateAll(string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateAll(strCate, group);
        }
        #endregion

        #region GetNewsGroupByCateHomeAll
        public DataTable GetNewsGroupByCateHomeAll(string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(strCate, group);
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(n, strCate, group);
        }
        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, string approval, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(n, strCate, approval, group);
        }
        #endregion

        #region GetNewsGroupByCateIsHomeAll
        public DataTable GetNewsGroupByCateIsHomeAll(string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(strCate, group);
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(n, strCate, group);
        }
        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(n, strCate, approval, group);
        }
        #endregion

        #region GetNewsGroupByCateHomeList
        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, num, group);
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, string approval, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, num, approval, group);
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, group);
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string aproval)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, group, aproval);
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string aproval, int num, string isHome)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, group, aproval, num, isHome);
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string aproval, int num, string isHome, string lang)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(strCate, group, aproval, num, isHome, lang);
        }

        public DataTable GetNewsGroupByCateHot(string strCate, int group, string aproval, int num, string isHome, string isHot)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHot(strCate, group, aproval, num, isHome, isHot);
        }
        public DataTable GetNewsGroupByCateHotAll(string strCate, int group, string aproval, string isHome, string isHot)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHotAll(strCate, group, aproval, isHome, isHot);
        }
        public DataTable GetNewsGroupByCateHot(int CateID, int group, string aproval, int num, string isHome, string isHot)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHot(CateID, group, aproval, num, isHome, isHot);
        }
        public DataTable GetNewsGroupByCateHotAll(int CateID, int group, string aproval, string isHome, string isHot)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHotAll(CateID, group, aproval, isHome, isHot);
        }
        #endregion

        #region GetNewsGroupByListNewsID
        public DataTable GetNewsGroupByListNewsID(string lang, string strCate, string aproval, string isHome)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByListNewsID(lang, strCate, aproval, isHome);
        }
        public DataTable GetNewsGroupByListNewsID(string lang, string strCate, int num, string aproval, string isHome)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByListNewsID(lang, strCate, num, aproval, isHome);
        }
        #endregion

        #region GetNewsGroupViewAll
        public DataTable GetNewsGroupViewAll(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewAll(lang, n, group);
        }
        public DataTable GetNewsGroupViewAll(string lang, int n, int group, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewAll(lang, n, group, approval);
        }
        #endregion

        public DataTable GetNewsGroupLates(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupLates(lang, n, approval, group);
        }
        public DataTable GetNewsLatest(string lang, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsLatest(lang, n, approval);
        }
        public DataTable GetNewsGroupLates(string lang, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupLates(lang, n, approval);
        }

        public DataTable GetNewsGroupHits(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHits(lang, n, approval, group);
        }
        public DataTable GetNewsGroupHits(string lang, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHits(lang, n, approval);
        }

        public DataTable GetNewsGroupPaging(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, PagingInfo _paging)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPaging(lang, group, CateID, strCate, isApproved, status, isHot, isHome, isDelete, _paging);
        }

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, string username, PagingInfo _paging)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingbyUser(lang, group, CateID, strCate, isApproved, status, isHot, isHome, isDelete, username, _paging);
        }

        public DataTable GetNewsGroupPagingRecord(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, int nRecord)
        {
            if (strCate != "")
                strCate = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupPagingRecord(lang, group, CateID, strCate, isApproved, status, isHot, isHome, isDelete, nRecord);
        }
    }
}
