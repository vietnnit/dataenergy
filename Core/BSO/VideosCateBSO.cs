using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using DAO;
namespace BSO
{
    public class VideosCateBSO
    {
        public VideosCateBSO()
        {
            //constructor
        }

        #region CreateVideosCate
        public void CreateCateNew(VideosCate videoscate)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            videoscateDAO.CreateVideosCate(videoscate);
        }
        public int CreateCateNewGet(VideosCate videoscate)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.CreateVideosCateGet(videoscate);
        }
        #endregion

        #region UpdateVideosCate
        public void UpdateVideosCate(VideosCate videoscate)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            videoscateDAO.UpdateVideosCate(videoscate);
        }
        #endregion

        #region GetVideosCate
        public DataTable GetVideosCate(string _lang)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.GetVideosCate(_lang);
        }
        #endregion

        #region GetVideosCateById
        public VideosCate GetVideosCateById(int cId)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.GetVideosCateById(cId);
        }
        #endregion

        #region ExistName
        public bool ExistName(string catename)
        {
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return reader.HasRows;
                }
            }
        }
        #endregion

        //Client

        #region MenuVideos
        public void MenuVideos(Menu menu, int iParentID, string _lang)
        {
            try
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_VideosCateGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VideosCateID", iParentID);
                    command.Parameters.AddWithValue("@Language", _lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MenuItem menuitem = new MenuItem(row["VideosCateName"].ToString());
                        menuitem.NavigateUrl = "~/Default.aspx?go=videoscate&id=" + row["VideosCateID"].ToString();
                        this.SubMenuNews(menuitem, Convert.ToInt32(row["VideosCateID"]), _lang);
                        menu.Items.Add(menuitem);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        private void SubMenuNews(MenuItem _parentNote, int iCate_ID, string _lang)
        {
            try
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_VideosCateGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VideosCateID", iCate_ID);
                    command.Parameters.AddWithValue("@Language", _lang);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                        command.Dispose();

                    }
                }
                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        MenuItem _childNote = new MenuItem(row["VideosCateName"].ToString());
                        _childNote.NavigateUrl = "~/Default.aspx?go=videoscate&id=" + row["VideosCateID"].ToString();
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuNews(_childNote, Convert.ToInt32(row["VideosCateID"]),_lang);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }


        }
        #endregion



        //DeleteVideosCate

        #region DeleteVideosCateAll
        public void DeleteVideosCateAll(int cateID, string _lang)
        {

            try
            {
                DataTable table = GetVideosCate(_lang);
                for (int m = 0; m < table.Rows.Count; m++)
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentCateID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["VideosCateID"]);
                    if (cateID == pParent)
                        this.DeleteVideosCateAll(cCate, _lang);
                }

                VideosCateDAO videoscateDAO = new VideosCateDAO();
                videoscateDAO.DeleteVideosCate(cateID);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }

        }
        #endregion

        #region VideosCateUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void VideosCateUpOrder(int cId, int cOrder)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            videoscateDAO.VideosCateUpOrder(cId, cOrder);
        }
        #endregion


        #region CateNavigator
        /// <summary>
        /// Tao dieu huong cho danh muc
        /// Khi su dung can phai khai bao: string cate_navigator = "";
        /// url co dang: Default.aspx?go=videoscate&id= ;
        /// </summary>
        /// <param name="cate_navigator"></param>
        /// <param name="cateId"></param>
        /// <param name="url"></param>

        public void CateNavigator(ref string cate_navigator, int cateId, string url)
        {
            try
            {
                VideosCate videoscate = GetVideosCateById(cateId);

                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }

                cate_navigator = "<a href='" + url + cateId + "'>" + videoscate.VideosCateName + "</a>" + cate_navigator;

                if (videoscate.ParentCateID != 0)
                    this.CateNavigator(ref cate_navigator, videoscate.ParentCateID, url);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }

        }
        #endregion


        //Cate Company

        #region getVideosCateLevel
        public DataTable getVideosCateLevel(int iCate, string _lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", iCate);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        #endregion





        #region getVideosCateClient
        public DataTable getVideosCateClient(int iCate, string _lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", iCate);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();

                }
            }

            return table;
        }
        #endregion





        #region GetCateGroupBullet
        public DataTable GetCateGroupBullet(string bullet, string _lang)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.GetCateGroupBullet(bullet,_lang);
        }
        #endregion

        #region GetVideosCateParent
        public DataTable GetVideosCateParent(int cateID, string _lang)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.GetVideosCateParent(cateID, _lang);
        }
        public DataTable GetVideosCateParentPaging(int cateID, PagingInfo _paging, string _lang)
        {
            VideosCateDAO videoscateDAO = new VideosCateDAO();
            return videoscateDAO.GetVideosCateParentPaging(cateID, _paging, _lang);
        }
        #endregion

    }
}
