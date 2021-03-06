using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsApprovedCommentDAO : BaseDAO
    {
        public NewsApprovedCommentDAO()
        {
            //constructor
        }

        #region NewsApprovedCommentReader
        private NewsApprovedComment NewsApprovedCommentReader(SqlDataReader reader)
        {
            NewsApprovedComment newsApprovedComment = new NewsApprovedComment();
            newsApprovedComment.ApprovedCommentNewsID = (int)reader["ApprovedCommentNewsID"];
            newsApprovedComment.NewsID = (int)reader["NewsID"];
             newsApprovedComment.Content = (string)reader["Content"];
            newsApprovedComment.DateCreated = (DateTime)reader["DateCreated"];
            newsApprovedComment.Actived = (bool)reader["Actived"];
            newsApprovedComment.UserName = (string)reader["UserName"];

            return newsApprovedComment;
        }
        #endregion

        #region GetAllNewsApprovedComment
        public DataTable GetAllNewsApprovedComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentGetAll", connection);
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

      




        #region GetNewsApprovedCommentByNewsID
        public DataTable GetNewsApprovedCommentByNewsID(int newsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentGetNewsID", connection);
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

        #region GetNewsApprovedCommentById
        public NewsApprovedComment GetNewsApprovedCommentById(int commentID)
        {
            NewsApprovedComment newsApprovedComment = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApprovedCommentNewsID", commentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        newsApprovedComment = NewsApprovedCommentReader(reader);
                    else
                        throw new DataAccessException("khong ton tai newsApprovedComment");
                }
                command.Dispose();

            }
            return newsApprovedComment;
        }
        #endregion

        #region CreateNewsApprovedComment
        public void CreateNewsApprovedComment(NewsApprovedComment newsApprovedComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ApprovedCommentNewsID", 0);
                command.Parameters.AddWithValue("@NewsID", newsApprovedComment.NewsID);
                command.Parameters.AddWithValue("@Content", newsApprovedComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsApprovedComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsApprovedComment.Actived);
                command.Parameters.AddWithValue("@UserName", newsApprovedComment.UserName);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public int CreateNewsApprovedCommentGet(NewsApprovedComment newsApprovedComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ApprovedCommentNewsID", 0);
                command.Parameters.AddWithValue("@NewsID", newsApprovedComment.NewsID);
                command.Parameters.AddWithValue("@Content", newsApprovedComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsApprovedComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsApprovedComment.Actived);
                command.Parameters.AddWithValue("@UserName", newsApprovedComment.UserName);

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

        #region UpdateNewsApprovedComment
        public void UpdateNewsApprovedComment(NewsApprovedComment newsApprovedComment)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ApprovedCommentNewsID", newsApprovedComment.ApprovedCommentNewsID);
                command.Parameters.AddWithValue("@NewsID", newsApprovedComment.NewsID);
                command.Parameters.AddWithValue("@Content", newsApprovedComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsApprovedComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsApprovedComment.Actived);
                command.Parameters.AddWithValue("@UserName", newsApprovedComment.UserName);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsApprovedComment
        public void UpdateNewsApprovedComment(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsApprovedComment set Actived =" + value + " where ApprovedCommentNewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong the cap nhat");
                else
                    command.Dispose();
            }
        }

        public void UpdateNewsApprovedComment(string strId, string value,string username,DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsApprovedComment set Actived =" + value + ",UserName='" + username + "', DateCreated = @Date where ApprovedCommentNewsID in('" + strId + "')";
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
        public void UpdateNewsApprovedComment(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsApprovedComment set Actived = " + value + ", UserName = '" + username + "',DateCreated = @Date  where NewsApprovedCommentID = @NewsApprovedCommentID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsApprovedCommentID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion


        #region DeleteNewsApprovedComment
        public void DeleteNewsApprovedComment(int commentID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsApprovedCommentDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApprovedCommentNewsID", commentID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa newsApprovedComment");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsApprovedComment
        public void DeleteNewsApprovedComment(string strId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsApprovedComment where ApprovedCommentNewsID in('" + strId + "')";
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

        #region GetAllNewsGroupApprovedComment

        public DataTable GetAllNewsGroupApprovedComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsApprovedComment.*  FROM tblNewsGroup INNER JOIN tblNewsApprovedComment ON tblNewsGroup.NewsGroupID = tblNewsApprovedComment.NewsID  ORDER BY DateCreated Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllNewsGroupApprovedComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsApprovedComment.*  FROM tblNewsGroup INNER JOIN tblNewsApprovedComment ON tblNewsGroup.NewsGroupID = tblNewsApprovedComment.NewsID WHERE (NewsID=@NewsGroupID) ORDER BY DateCreated Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@NewsGroupID", Id);
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
