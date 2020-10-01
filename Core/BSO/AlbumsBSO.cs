using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class AlbumsBSO
    {
        public AlbumsBSO() 
        {
            //constructor
        }

        #region CreateAlbums
        public void CreateAlbums(Albums albums) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.CreateAlbums(albums);
        }

        public int CreateAlbumsGet(Albums albums)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.CreateAlbumsGet(albums);
        }
        #endregion

        #region UpdateAlbums
        public void UpdateAlbums(Albums albums) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.UpdateAlbums(albums);
        }
        #endregion

        #region UpdateAlbums
        public void UpdateAlbums(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.UpdateAlbums(restr, value);
        }
        #endregion

        #region UpdateAlbumsApproval
        public void UpdateAlbumsApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.UpdateAlbumsApproval(restr, value,username,date);
        }
        public void UpdateAlbumsApproval(int Id, string value, string username, DateTime date)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.UpdateAlbumsApproval(Id, value, username, date);
        }
        #endregion

        #region DeleteAlbums
        public void DeleteAlbums(int nId) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.DeleteAlbums(nId);
        }
        public void DeleteAlbums(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.DeleteAlbums(restr);
        }
        #endregion

        

        #region GetAlbumsById
        public Albums GetAlbumsById(int nId) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsById(nId);
        }
        #endregion

        

        #region GetAlbumsAll
        public DataTable GetAlbumsAll(string _lang) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsAll(_lang);
        }
        #endregion

        #region GetAlbumsHot
        public DataTable GetAlbumsHot(string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot(_lang);
        }
        public DataTable GetAlbumsHot(int n, string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot( n, _lang);
        }
        public DataTable GetAlbumsHot(int n, string approval, string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsHot(n, approval,_lang);
        }
        #endregion

        #region GetAlbumsViewHome
        public DataTable GetAlbumsViewHome(string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome(_lang);
        }

        public DataTable GetAlbumsViewHome(int n, string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome(n, _lang);
        }

        public DataTable GetAlbumsViewHome(int n, string approval, string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsViewHome( n, approval,_lang);
        }
        #endregion

        #region AlbumsClickUpdate
        public void AlbumsClickUpdate(int nId) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            albumsDAO.AlbumsClickUpdate(nId);
        }
        #endregion

        #region AlbumsSearch
        public DataTable AlbumsSearch(string keyword, int cId, string _lang) 
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.AlbumsSearch(keyword, cId, _lang);
        }
        #endregion


        #region GetAlbumsView
        public DataTable GetAlbumsView(string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsView(_lang);
        }
        #endregion
        

        //client
        #region GetAlbumsByCate
        public DataTable GetAlbumsByCate(int iCateId, string _lang) 
        {
            DataTable dataTable = new DataTable();
            DataTable table = GetAlbumsAll(_lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "AlbumsCateID = " + iCateId + " and Status = 'True' ";
                dataView.Sort = "PostDate Desc ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }
        #endregion

        #region AlbumsFollow
        public DataTable AlbumsFollow(int Id, int cId, string _lang)
        {
            DataTable dataTable = new DataTable();

            Albums albums = GetAlbumsById(Id);
            DateTime PostTime = albums.PostDate;

            DataTable table = GetAlbumsAll(_lang);
            if (table != null)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "AlbumsID <> " + Id + "and CateAlbumsID = " + cId;
                dataView.Sort = "PostDate DESC ";
                dataTable = dataView.ToTable();
            }
            return dataTable;

        }

        public DataTable AlbumsFollow(int Id, int cId, int n, string _lang)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.AlbumsFollow(Id, cId, n, _lang);

        }
        #endregion

        #region GetAlbumsByCateAll
        public DataTable GetAlbumsByCateAll(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateAll(restr, _lang);
        }
        #endregion

        #region GetAlbumsByCateHomeAll
        public DataTable GetAlbumsByCateHomeAll(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(restr, _lang);
        }
        #endregion

        #region GetAlbumsByCateHomeAll
        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(n, restr, _lang);
        }
        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeAll(n, restr, approval, _lang);
        }
        #endregion

        #region GetAlbumsByCateHomeList
        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr, num, _lang);
        }
        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr, num, approval, _lang);
        }
        public DataTable GetAlbumsByCateHomeList(string strCate, string _lang)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AlbumsDAO albumsDAO = new AlbumsDAO();
            return albumsDAO.GetAlbumsByCateHomeList(restr, _lang);
        }
        #endregion
    }
}
