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
    public class AlbumsCateBSO
    {
        public AlbumsCateBSO()
        {
            //constructor
        }

        #region CreateAlbumsCate
        public void CreateCateNew(AlbumsCate albumcate)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            albumcateDAO.CreateAlbumsCate(albumcate);
        }
        public int CreateCateNewGet(AlbumsCate albumcate)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.CreateAlbumsCateGet(albumcate);
        }
        #endregion

        #region UpdateAlbumsCate
        public void UpdateAlbumsCate(AlbumsCate albumcate)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            albumcateDAO.UpdateAlbumsCate(albumcate);
        }
        #endregion

        #region GetAlbumsCate
        public DataTable GetAlbumsCate(string _lang)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCate(_lang);
        }
        #endregion

        #region GetAlbumsCateById
        public AlbumsCate GetAlbumsCateById(int cId)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCateById(cId);
        }
        #endregion

        #region ExistName
        public bool ExistName(string catename)
        {
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return reader.HasRows;
                }
            }
        }
        #endregion

        //Client

        #region MenuAlbums
        public void MenuAlbums(Menu menu, int iParentID, string _lang)
        {
            try
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumsCateID", iParentID);
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
                        MenuItem menuitem = new MenuItem(row["AlbumsCateName"].ToString());
                        menuitem.NavigateUrl = "~/Default.aspx?go=albumcate&id=" + row["AlbumsCateID"].ToString();
                        this.SubMenuNews(menuitem, Convert.ToInt32(row["AlbumsCateID"]), _lang);
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
                    SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumsCateID", iCate_ID);
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
                        MenuItem _childNote = new MenuItem(row["AlbumsCateName"].ToString());
                        _childNote.NavigateUrl = "~/Default.aspx?go=albumcate&id=" + row["AlbumsCateID"].ToString();
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuNews(_childNote, Convert.ToInt32(row["AlbumsCateID"]), _lang);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }


        }
        #endregion



        //DeleteAlbumsCate

        #region DeleteAlbumsCateAll
        public void DeleteAlbumsCateAll(int cateID, string _lang)
        {

            try
            {
                DataTable table = GetAlbumsCate(_lang);
                for (int m = 0; m < table.Rows.Count; m++)
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentCateID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["AlbumsCateID"]);
                    if (cateID == pParent)
                        this.DeleteAlbumsCateAll(cCate, _lang);
                }

                AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
                albumcateDAO.DeleteAlbumsCate(cateID);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }

        }
        #endregion

        #region AlbumsCateUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void AlbumsCateUpOrder(int cId, int cOrder)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            albumcateDAO.AlbumsCateUpOrder(cId, cOrder);
        }
        #endregion


        #region CateNavigator
        /// <summary>
        /// Tao dieu huong cho danh muc
        /// Khi su dung can phai khai bao: string cate_navigator = "";
        /// url co dang: Default.aspx?go=albumcate&id= ;
        /// </summary>
        /// <param name="cate_navigator"></param>
        /// <param name="cateId"></param>
        /// <param name="url"></param>

        public void CateNavigator(ref string cate_navigator, int cateId, string url)
        {
            try
            {
                AlbumsCate albumcate = GetAlbumsCateById(cateId);

                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }

                cate_navigator = "<a href='" + url + cateId + "'>" + albumcate.AlbumsCateName + "</a>" + cate_navigator;

                if (albumcate.ParentCateID != 0)
                    this.CateNavigator(ref cate_navigator, albumcate.ParentCateID, url);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }

        }
        #endregion


        //Cate Company

        #region getAlbumsCateLevel
        public DataTable getAlbumsCateLevel(int iCate, string _lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", iCate);
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





        #region getAlbumsCateClient
        public DataTable getAlbumsCateClient(int iCate, string _lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", iCate);
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
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetCateGroupBullet(bullet, _lang);
        }
        #endregion

        #region GetAlbumsCateParent
        public DataTable GetAlbumsCateParent(int cateID, string _lang)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCateParent(cateID,_lang);
        }
        public DataTable GetAlbumsCateParentPaging(int cateID, PagingInfo _paging, string _lang)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCateParentPaging(cateID, _paging,_lang);
        }
        #endregion

    }
}
