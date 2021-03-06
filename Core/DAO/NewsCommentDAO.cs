using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsCommentDAO : BaseDAO
    {
        public NewsCommentDAO()
        {
            //constructor
        }

        #region NewsCommentReader
        private NewsComment NewsCommentReader(SqlDataReader reader)
        {
            NewsComment newsComment = new NewsComment();
            newsComment.CommentNewsID = (int)reader["CommentNewsID"];
            newsComment.NewsID = (int)reader["NewsID"];
            newsComment.FullName = (string)reader["FullName"];
            newsComment.Email = (string)reader["Email"];
            newsComment.Title = (string)reader["Title"];
            newsComment.Content = (string)reader["Content"];
            newsComment.DateCreated = (DateTime)reader["DateCreated"];
            newsComment.Actived = (bool)reader["Actived"];
            newsComment.GroupCate = (int)reader["GroupCate"];
            newsComment.ApprovalUserName = (string)reader["ApprovalUserName"];
            newsComment.ApprovalDate = (DateTime)reader["ApprovalDate"];

            return newsComment;
        }
        #endregion

        #region GetAllNewsComment
        public DataTable GetAllNewsComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAllGroupCateNewsComment
        public DataTable GetAllGroupCateNewsComment(int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGroupCateGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAllViewNewsComment
        public DataTable GetAllViewNewsComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentViewGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewNewsComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentViewGetbyID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAllViewAnnounceComment
        public DataTable GetAllViewAnnounceComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceCommentViewGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewAnnounceComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceCommentViewGetbyID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAllViewCompanyComment
        public DataTable GetAllViewCompanyComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyCommentViewGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewCompanyComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyCommentViewGetbyID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetAllViewDownloadComment
        public DataTable GetAllViewDownloadComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadCommentViewGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewDownloadComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadCommentViewGetbyID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetNewsCommentByNewsID
        public DataTable GetNewsCommentByNewsID(int newsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetNewsID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsID", newsID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetNewsCommentById
        public NewsComment GetNewsCommentById(int commentID)
        {
            NewsComment newsComment = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CommentNewsID", commentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        newsComment = NewsCommentReader(reader);
                    else
                        throw new DataAccessException("khong ton tai newsComment");
                }
                command.Dispose();

            }
            return newsComment;
        }
        #endregion

        #region CreateNewsComment
        public void CreateNewsComment(NewsComment newsComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CommentNewsID", 0);
                command.Parameters.AddWithValue("@NewsID", newsComment.NewsID);
                command.Parameters.AddWithValue("@FullName", newsComment.FullName);
                command.Parameters.AddWithValue("@Email", newsComment.Email);
                command.Parameters.AddWithValue("@Title", newsComment.Title);
                command.Parameters.AddWithValue("@Content", newsComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", newsComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", newsComment.ApprovalDate);


                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public int CreateNewsCommentGet(NewsComment newsComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CommentNewsID", 0);
                command.Parameters.AddWithValue("@NewsID", newsComment.NewsID);
                command.Parameters.AddWithValue("@FullName", newsComment.FullName);
                command.Parameters.AddWithValue("@Email", newsComment.Email);
                command.Parameters.AddWithValue("@Title", newsComment.Title);
                command.Parameters.AddWithValue("@Content", newsComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", newsComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", newsComment.ApprovalDate);


                SqlParameter sp = new SqlParameter("@pReturnValue", SqlDbType.Int);
                sp.Direction = ParameterDirection.Output;
                command.Parameters.Add(sp);

                connection.Open();
                command.ExecuteNonQuery();

                int id = Convert.ToInt32(sp.Value.ToString());

                return id;
            }
        }
        #endregion

        #region UpdateNewsComment
        public void UpdateNewsComment(NewsComment newsComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CommentNewsID", newsComment.CommentNewsID);
                command.Parameters.AddWithValue("@NewsID", newsComment.NewsID);
                command.Parameters.AddWithValue("@FullName", newsComment.FullName);
                command.Parameters.AddWithValue("@Email", newsComment.Email);
                command.Parameters.AddWithValue("@Title", newsComment.Title);
                command.Parameters.AddWithValue("@Content", newsComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", newsComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", newsComment.ApprovalDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsComment
        public void UpdateNewsComment(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsComment set Actived =" + value + " where CommentNewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong the cap nhat");
                else
                    command.Dispose();
            }
        }

        public void UpdateNewsComment(string strId, string value,string username,DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsComment set Actived =" + value + ",ApprovalUserName='"+username+"', ApprovalDate = @Date where CommentNewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong the cap nhat");
                else
                    command.Dispose();
            }
        }
        public void UpdateNewsComment(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsComment set Actived = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsCommentID = @NewsCommentID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsCommentID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion


        #region DeleteNewsComment
        public void DeleteNewsComment(int commentID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CommentNewsID", commentID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa newsComment");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsComment
        public void DeleteNewsComment(string strId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsComment where CommentNewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong the xoa đánh giá");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetAllNewsGroupComment

        public DataTable GetAllNewsGroupComment(int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsComment.*  FROM tblNewsGroup INNER JOIN tblNewsComment ON tblNewsGroup.NewsGroupID = tblNewsComment.NewsID WHERE (tblNewsComment.GroupCate = @GroupCate) ORDER BY DateCreated Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllNewsGroupComment(int Id, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsComment.*  FROM tblNewsGroup INNER JOIN tblNewsComment ON tblNewsGroup.NewsGroupID = tblNewsComment.NewsID ";
                SQL += "WHERE 1=1 ";
                if (group > -1)
                    SQL += " AND tblNewsComment.GroupCate = @GroupCate ";
                if (Id > -1)
                    SQL += "AND NewsID=@NewsGroupID ";
                SQL += "ORDER BY DateCreated Desc";

                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion
    }
}
