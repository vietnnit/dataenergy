using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class VideosDAO:BaseDAO
    {
        public VideosDAO() 
        {
            //constructor
        }

        #region VideosReader
        private Videos VideosReader(SqlDataReader reader) 
        {
            Videos videos = new Videos();
            videos.VideosID = (int)reader["VideosID"];
            videos.VideosCateID = (int)reader["VideosCateID"];
            videos.Title = (string)reader["Title"];
            videos.Description = (string)reader["Description"];
            videos.ImageThumb = (string)reader["ImageThumb"];
            videos.ImageLarge = (string)reader["ImageLarge"];
            videos.Author = (string)reader["Author"];
            videos.PostDate = (DateTime) reader["PostDate"];
            videos.Status = (bool)reader["Status"];
            videos.Ishot = (bool)reader["Ishot"];
            videos.Isview = (int) reader["Isview"];
            videos.Ishome = (bool)reader["Ishome"];
            videos.IsComment = (bool)reader["IsComment"];
            videos.ApprovalDate = (DateTime)reader["ApprovalDate"];
            videos.ApprovalUserName = (string)reader["ApprovalUserName"];
            videos.IsApproval = (bool)reader["IsApproval"];
            videos.CreatedUserName = (string)reader["CreatedUserName"];
            videos.CommentTotal = (int)reader["CommentTotal"];
            videos.VideosUrl = (string)reader["VideosUrl"];
            videos.FileName = (string)reader["FileName"];
            videos.VideosType = (bool)reader["VideosType"];
            videos.Language = (string)reader["Language"];
            return videos;
        }
        #endregion

        #region CreateVideos
        public void CreateVideos(Videos videos) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@VideosID", 0);
                command.Parameters.AddWithValue("@VideosCateID", videos.VideosCateID);
                command.Parameters.AddWithValue("@Title", videos.Title);
                command.Parameters.AddWithValue("@Description", videos.Description);
                command.Parameters.AddWithValue("@ImageThumb", videos.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videos.ImageLarge);
                command.Parameters.AddWithValue("@Author", videos.Author);
                command.Parameters.AddWithValue("@PostDate", videos.PostDate);
                command.Parameters.AddWithValue("@Status", videos.Status);
                command.Parameters.AddWithValue("@Ishot", videos.Ishot);
                command.Parameters.AddWithValue("@Isview", videos.Isview);
                command.Parameters.AddWithValue("@Ishome", videos.Ishome);
                command.Parameters.AddWithValue("@IsComment", videos.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", videos.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", videos.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", videos.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", videos.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", videos.CommentTotal);

                command.Parameters.AddWithValue("@VideosUrl", videos.VideosUrl);
                command.Parameters.AddWithValue("@FileName", videos.FileName);
                command.Parameters.AddWithValue("@VideosType", videos.VideosType);
                command.Parameters.AddWithValue("@Language", videos.Language);

                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm mới tin");
                else
                    command.Dispose();
            }
        }

        public int CreateVideosGet(Videos videos)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@VideosID", 0);
                command.Parameters.AddWithValue("@VideosCateID", videos.VideosCateID);
                command.Parameters.AddWithValue("@Title", videos.Title);
                command.Parameters.AddWithValue("@Description", videos.Description);
                command.Parameters.AddWithValue("@ImageThumb", videos.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videos.ImageLarge);
                command.Parameters.AddWithValue("@Author", videos.Author);
                command.Parameters.AddWithValue("@PostDate", videos.PostDate);
                command.Parameters.AddWithValue("@Status", videos.Status);
                command.Parameters.AddWithValue("@Ishot", videos.Ishot);
                command.Parameters.AddWithValue("@Isview", videos.Isview);
                command.Parameters.AddWithValue("@Ishome", videos.Ishome);
                command.Parameters.AddWithValue("@IsComment", videos.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", videos.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", videos.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", videos.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", videos.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", videos.CommentTotal);

                command.Parameters.AddWithValue("@VideosUrl", videos.VideosUrl);
                command.Parameters.AddWithValue("@FileName", videos.FileName);
                command.Parameters.AddWithValue("@VideosType", videos.VideosType);
                command.Parameters.AddWithValue("@Language", videos.Language);


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

        #region UpdateVideos
        public void UpdateVideos(Videos videos)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@VideosID", videos.VideosID);
                command.Parameters.AddWithValue("@VideosCateID", videos.VideosCateID);
                command.Parameters.AddWithValue("@Title", videos.Title);
                command.Parameters.AddWithValue("@Description", videos.Description);
                command.Parameters.AddWithValue("@ImageThumb", videos.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videos.ImageLarge);
                command.Parameters.AddWithValue("@Author", videos.Author);
                command.Parameters.AddWithValue("@PostDate", videos.PostDate);
                command.Parameters.AddWithValue("@Status", videos.Status);
                command.Parameters.AddWithValue("@Ishot", videos.Ishot);
                command.Parameters.AddWithValue("@Isview", videos.Isview);
                command.Parameters.AddWithValue("@Ishome", videos.Ishome);
                command.Parameters.AddWithValue("@IsComment", videos.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", videos.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", videos.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", videos.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", videos.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", videos.CommentTotal);

                command.Parameters.AddWithValue("@VideosUrl", videos.VideosUrl);
                command.Parameters.AddWithValue("@FileName", videos.FileName);
                command.Parameters.AddWithValue("@VideosType", videos.VideosType);
                command.Parameters.AddWithValue("@Language", videos.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateVideos
        public void UpdateVideos(string strId, string value) 
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblVideos set Status = "+ value +" where VideosID in('" + strId + "')";
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

        #region UpdateVideosApproval
        public void UpdateVideosApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblVideos set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where VideosID in('" + strId + "')";
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

        public void UpdateVideosApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblVideos set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where VideosID = @VideosID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@VideosID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteVideos
        public void DeleteVideos(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("VideosID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }


  
        public void DeleteVideos(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblVideos where VideosID in('" + sId + "')";
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

        #region GetVideosById
        public Videos GetVideosById(int Id) 
        {
            Videos videos = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        videos = VideosReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy tin");
                    
                } 
                command.Dispose();
            }
            return videos;
        }
        #endregion

        

        #region GetVideosAll
        public DataTable GetVideosAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosGetAll", connection);
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

        #region GetVideosHot
        public DataTable GetVideosHot(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosHot", connection);
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

        public DataTable GetVideosHot(int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND [Status] = 1 ORDER BY [PostDate] DESC ";
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

        public DataTable GetVideosHot(int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY PostDate DESC ";
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
        public DataTable GetVideosHot(int n, string approval,int cId, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND VideosCateID = @cateID And Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY PostDate DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@cateID", cId);
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

        public Videos GetVideosHotTop1(string approval, int cId, string _lang)
        {
            Videos videos = null;
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top 1 * from tblVideos where [Language]=@Language AND VideosCateID = @cateID And Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY PostDate DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@cateID", cId);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        videos = VideosReader(reader);
                    //else
                    //    throw new DataAccessException("Không tìm thấy tin");

                }
                command.Dispose();
            }
            return videos;
        }
        public Videos GetVideosHotTop1(string approval,string _lang)
        {
            Videos videos = null;
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top 1 * from tblVideos where [Language]=@Language AND Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY PostDate DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        videos = VideosReader(reader);
                    //else
                    //    throw new DataAccessException("Không tìm thấy tin");

                }
                command.Dispose();
            }
            return videos;
        }
        #endregion

        #region GetVideosViewHome
        public DataTable GetVideosViewHome(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosViewHome", connection);
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

        public DataTable GetVideosViewHome(int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND [IsHome] = 1 AND [Status] = 1 ORDER BY [PostDate] DESC ";
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

        public DataTable GetVideosViewHome(int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [PostDate] DESC ";
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
        

        #region VideosClickUpdate
        public void VideosClickUpdate(int nId) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosClickUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosID",nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region VideosSearch
        public DataTable VideosSearch(string keyword,int cateid, string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosSearch",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Keyword",keyword);
                command.Parameters.AddWithValue("@VideosCateID",cateid);
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

        #region GetVideosView
        public DataTable GetVideosView(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosView", connection);
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

        #region GetVideosByCateAll
        public DataTable GetVideosByCateAll(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblVideos where [Language]=@Language AND VideosCateID in('" + strCate + "') order by videosid desc";
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

        #region GetVideosByCateHomeAll
        public DataTable GetVideosByCateHomeAll(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblVideos where [Language]=@Language AND status=1 and VideosCateID in('" + strCate + "') order by PostDate";
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

        #region GetVideosByCateHomeAll
        public DataTable GetVideosByCateHomeAll(int n, string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND status=1 and VideosCateID in('" + strCate + "') order by PostDate";
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
        public DataTable GetVideosByCateHomeAll(int n, string strCate, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblVideos where [Language]=@Language AND status=1 and VideosCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by PostDate desc";
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

        #region GetVideosByCateHomeList
        public DataTable GetVideosByCateHomeList(string strCate, int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblVideos where [Language]=@Language AND VideosCateID in('" + strCate + "') order by PostDate Desc";
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

        public DataTable GetVideosByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblVideos where [Language]=@Language AND VideosCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by PostDate Desc";
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

        public DataTable GetVideosByCateHomeList(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblVideos where [Language]=@Language AND VideosCateID in('" + strCate + "') order by PostDate Desc";
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

        #region VideosFollow

        public DataTable VideosFollow(int Id, int cId, int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblVideos WHERE [Language]=@Language AND VideosCateID = " + cId + " AND VideosID < " + Id + " ORDER BY PostDate DESC";


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

        public DataTable GetVideosPagingApproved(int CateID, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosGetCateAprrovedPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", CateID);
                command.Parameters.AddWithValue("@CurrentPage", _paging.CurrentPage);
                command.Parameters.AddWithValue("@PageSize", _paging.PageSize);
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
    }
}
