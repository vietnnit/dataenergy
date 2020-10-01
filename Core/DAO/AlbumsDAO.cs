using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class AlbumsDAO:BaseDAO
    {
        public AlbumsDAO() 
        {
            //constructor
        }

        #region AlbumsReader
        private Albums AlbumsReader(SqlDataReader reader) 
        {
            Albums albums = new Albums();
            albums.AlbumsID = (int)reader["AlbumsID"];
            albums.AlbumsCateID = (int)reader["AlbumsCateID"];
            albums.Title = (string)reader["Title"];
            albums.Description = (string)reader["Description"];
            albums.ImageThumb = (string)reader["ImageThumb"];
            albums.ImageLarge = (string)reader["ImageLarge"];
            albums.Author = (string)reader["Author"];
            albums.PostDate = (DateTime) reader["PostDate"];
            albums.Status = (bool)reader["Status"];
            albums.Ishot = (bool)reader["Ishot"];
            albums.Isview = (int) reader["Isview"];
            albums.Ishome = (bool)reader["Ishome"];
            albums.IsComment = (bool)reader["IsComment"];
            albums.ApprovalDate = (DateTime)reader["ApprovalDate"];
            albums.ApprovalUserName = (string)reader["ApprovalUserName"];
            albums.IsApproval = (bool)reader["IsApproval"];
            albums.CreatedUserName = (string)reader["CreatedUserName"];
            albums.CommentTotal = (int)reader["CommentTotal"];
            albums.Language = (string)reader["Language"];

            return albums;
        }
        #endregion

        #region CreateAlbums
        public void CreateAlbums(Albums albums) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumsID", 0);
                command.Parameters.AddWithValue("@AlbumsCateID", albums.AlbumsCateID);
                command.Parameters.AddWithValue("@Title", albums.Title);
                command.Parameters.AddWithValue("@Description", albums.Description);
                command.Parameters.AddWithValue("@ImageThumb", albums.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albums.ImageLarge);
                command.Parameters.AddWithValue("@Author", albums.Author);
                command.Parameters.AddWithValue("@PostDate", albums.PostDate);
                command.Parameters.AddWithValue("@Status", albums.Status);
                command.Parameters.AddWithValue("@Ishot", albums.Ishot);
                command.Parameters.AddWithValue("@Isview", albums.Isview);
                command.Parameters.AddWithValue("@Ishome", albums.Ishome);
                command.Parameters.AddWithValue("@IsComment", albums.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", albums.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", albums.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", albums.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", albums.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", albums.CommentTotal);
                command.Parameters.AddWithValue("@Language", albums.Language);

                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm mới tin");
                else
                    command.Dispose();
            }
        }

        public int CreateAlbumsGet(Albums albums)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumsID", 0);
                command.Parameters.AddWithValue("@AlbumsCateID", albums.AlbumsCateID);
                command.Parameters.AddWithValue("@Title", albums.Title);
                command.Parameters.AddWithValue("@Description", albums.Description);
                command.Parameters.AddWithValue("@ImageThumb", albums.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albums.ImageLarge);
                command.Parameters.AddWithValue("@Author", albums.Author);
                command.Parameters.AddWithValue("@PostDate", albums.PostDate);
                command.Parameters.AddWithValue("@Status", albums.Status);
                command.Parameters.AddWithValue("@Ishot", albums.Ishot);
                command.Parameters.AddWithValue("@Isview", albums.Isview);
                command.Parameters.AddWithValue("@Ishome", albums.Ishome);
                command.Parameters.AddWithValue("@IsComment", albums.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", albums.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", albums.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", albums.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", albums.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", albums.CommentTotal);
                command.Parameters.AddWithValue("@Language", albums.Language);


                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc san pham");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateAlbums
        public void UpdateAlbums(Albums albums)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AlbumsID", albums.AlbumsID);
                command.Parameters.AddWithValue("@AlbumsCateID", albums.AlbumsCateID);
                command.Parameters.AddWithValue("@Title", albums.Title);
                command.Parameters.AddWithValue("@Description", albums.Description);
                command.Parameters.AddWithValue("@ImageThumb", albums.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albums.ImageLarge);
                command.Parameters.AddWithValue("@Author", albums.Author);
                command.Parameters.AddWithValue("@PostDate", albums.PostDate);
                command.Parameters.AddWithValue("@Status", albums.Status);
                command.Parameters.AddWithValue("@Ishot", albums.Ishot);
                command.Parameters.AddWithValue("@Isview", albums.Isview);
                command.Parameters.AddWithValue("@Ishome", albums.Ishome);
                command.Parameters.AddWithValue("@IsComment", albums.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", albums.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", albums.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", albums.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", albums.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", albums.CommentTotal);
                command.Parameters.AddWithValue("@Language", albums.Language);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateAlbums
        public void UpdateAlbums(string strId, string value) 
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblAlbums set Status = "+ value +" where AlbumsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateAlbumsApproval
        public void UpdateAlbumsApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblAlbums set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AlbumsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }

        public void UpdateAlbumsApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblAlbums set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AlbumsID = @AlbumsID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@AlbumsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteAlbums
        public void DeleteAlbums(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("AlbumsID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }


  
        public void DeleteAlbums(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblAlbums where AlbumsID in('" + sId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetAlbumsById
        public Albums GetAlbumsById(int Id) 
        {
            Albums albums = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        albums = AlbumsReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy tin");
                    
                } 
                command.Dispose();
            }
            return albums;
        }
        #endregion

        

        #region GetAlbumsAll
        public DataTable GetAlbumsAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsHot
        public DataTable GetAlbumsHot(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsHot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsHot(int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [Status] = 1 AND [Language]=@Language ORDER BY [AlbumsID] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsHot(int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [Language]=@Language AND Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY AlbumsID DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsViewHome
        public DataTable GetAlbumsViewHome(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsViewHome", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsViewHome(int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [Language]=@Language AND [IsHome] = 1 AND [Status] = 1 ORDER BY [AlbumsID] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsViewHome(int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [Language]=@Language AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [AlbumsID] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion
        

        #region AlbumsClickUpdate
        public void AlbumsClickUpdate(int nId) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsClickUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsID",nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region AlbumsSearch
        public DataTable AlbumsSearch(string keyword,int cateid, string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsSearch",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Keyword",keyword);
                command.Parameters.AddWithValue("@AlbumsCateID",cateid);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsView
        public DataTable GetAlbumsView(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsView", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsByCateAll
        public DataTable GetAlbumsByCateAll(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblAlbums where [Language]=@Language AND AlbumsCateID in('" + strCate + "') order by albumsid desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsByCateHomeAll
        public DataTable GetAlbumsByCateHomeAll(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblAlbums where [Language]=@Language AND status=1 and AlbumsCateID in('" + strCate + "') order by AlbumsID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region GetAlbumsByCateHomeAll
        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAlbums where [Language]=@Language AND status=1 and AlbumsCateID in('" + strCate + "') order by AlbumsID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string approval,string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAlbums where [Language]=@Language AND status=1 and AlbumsCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AlbumsID desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        #endregion

        #region GetAlbumsByCateHomeList
        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAlbums where [Language]=@Language AND AlbumsCateID in('" + strCate + "') order by AlbumsID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAlbums where [Language]=@Language AND AlbumsCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AlbumsID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAlbumsByCateHomeList(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblAlbums where [Language]=@Language AND AlbumsCateID in('" + strCate + "') order by AlbumsID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region AlbumsFollow

        public DataTable AlbumsFollow(int Id, int cId, int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblAlbums WHERE [Language]=@Language AND AlbumsCateID = " + cId + " AND AlbumsID < " + Id + " ORDER BY AlbumsID DESC";


                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion
    }
}
