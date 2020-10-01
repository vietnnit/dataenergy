using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class VideosBSO
    {
        public VideosBSO() 
        {
            //constructor
        }

        #region CreateVideos
        public void CreateVideos(Videos videos) 
        {
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.CreateVideos(videos);
        }

        public int CreateVideosGet(Videos videos)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.CreateVideosGet(videos);
        }
        #endregion

        #region UpdateVideos
        public void UpdateVideos(Videos videos) 
        {
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.UpdateVideos(videos);
        }
        #endregion

        #region UpdateVideos
        public void UpdateVideos(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.UpdateVideos(restr, value);
        }
        #endregion

        #region UpdateVideosApproval
        public void UpdateVideosApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.UpdateVideosApproval(restr, value,username,date);
        }
        public void UpdateVideosApproval(int Id, string value, string username, DateTime date)
        {
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.UpdateVideosApproval(Id, value, username, date);
        }
        #endregion

        #region DeleteVideos
        public void DeleteVideos(int nId) 
        {
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.DeleteVideos(nId);
        }
        public void DeleteVideos(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.DeleteVideos(restr);
        }
        #endregion

        

        #region GetVideosById
        public Videos GetVideosById(int nId) 
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosById(nId);
        }
        #endregion

        

        #region GetVideosAll
        public DataTable GetVideosAll(string _lang) 
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosAll(_lang);
        }
        #endregion

        #region GetVideosHot
        public DataTable GetVideosHot(string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHot(_lang);
        }
        public DataTable GetVideosHot(int n, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHot( n, _lang);
        }
        public DataTable GetVideosHot(int n, string approval, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHot(n, approval, _lang);
        }
        public DataTable GetVideosHot(int n, string approval, int cID, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHot(n, approval, cID, _lang);
        }
        public Videos GetVideosHotTop1(string approval, int cID, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHotTop1(approval, cID,_lang);
        }
        public Videos GetVideosHotTop1(string approval, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosHotTop1(approval,_lang);
        }
        #endregion

        #region GetVideosViewHome
        public DataTable GetVideosViewHome(string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosViewHome(_lang);
        }

        public DataTable GetVideosViewHome(int n, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosViewHome(n,_lang);
        }

        public DataTable GetVideosViewHome(int n, string approval, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosViewHome( n, approval,_lang);
        }
        #endregion

        #region VideosClickUpdate
        public void VideosClickUpdate(int nId) 
        {
            VideosDAO videosDAO = new VideosDAO();
            videosDAO.VideosClickUpdate(nId);
        }
        #endregion

        #region VideosSearch
        public DataTable VideosSearch(string keyword, int cId, string _lang) 
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.VideosSearch(keyword, cId, _lang);
        }
        #endregion


        #region GetVideosView
        public DataTable GetVideosView(string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosView(_lang);
        }
        #endregion
        

        //client
        #region GetVideosByCate
        public DataTable GetVideosByCate(int iCateId, string _lang) 
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetVideosAll(_lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "VideosCateID = " + iCateId + " and Status = 'True' ";
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }
        #endregion

        #region VideosFollow
        public DataTable VideosFollow(int Id, int cId, string _lang)
        {
            DataTable dataTable = new DataTable();

            Videos videos = GetVideosById(Id);
            DateTime PostTime = videos.PostDate;

            DataTable table = GetVideosAll(_lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "VideosID <> " + Id + "and CateVideosID = " + cId;
                dataView.Sort = "PostDate DESC ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable VideosFollow(int Id, int cId, int n, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.VideosFollow(Id, cId, n, _lang);

        }
        #endregion

        #region GetVideosByCateAll
        public DataTable GetVideosByCateAll(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateAll(restr,_lang);
        }
        #endregion

        #region GetVideosByCateHomeAll
        public DataTable GetVideosByCateHomeAll(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeAll(restr,_lang);
        }
        #endregion

        #region GetVideosByCateHomeAll
        public DataTable GetVideosByCateHomeAll(int n, string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeAll(n, restr,_lang);
        }
        public DataTable GetVideosByCateHomeAll(int n, string strCate, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeAll(n, restr, approval, _lang);
        }
        #endregion

        #region GetVideosByCateHomeList
        public DataTable GetVideosByCateHomeList(string strCate, int num, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeList(restr, num, _lang);
        }
        public DataTable GetVideosByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeList(restr, num, approval, _lang);
        }
        public DataTable GetVideosByCateHomeList(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosByCateHomeList(restr, _lang);
        }
        #endregion

        public DataTable GetVideosPagingApproved(int CateID, PagingInfo _paging, string _lang)
        {
            VideosDAO videosDAO = new VideosDAO();
            return videosDAO.GetVideosPagingApproved(CateID, _paging, _lang);
        }
    }
}
