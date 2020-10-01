using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsLogDAO : BaseDAO
    {
        #region NewsLogReader
        private NewsLog NewsLogReader(SqlDataReader reader)
        {
            NewsLog newsLog = new NewsLog();
            newsLog.NewsLogID = (int)reader["NewsLogID"];
            newsLog.NewsGroupID = (int)reader["NewsGroupID"];
            newsLog.CateNewsID = (int)reader["CateNewsID"];
            newsLog.ParentNewsID = (int)reader["ParentNewsID"];
            newsLog.GroupCate = (int)reader["GroupCate"];
            newsLog.Title = (string)reader["Title"];
            newsLog.ShortDescribe = (string)reader["ShortDescribe"];
            newsLog.FullDescribe = (string)reader["FullDescribe"];
            newsLog.ImageThumb = (string)reader["ImageThumb"];
            newsLog.ImageLarge = (string)reader["ImageLarge"];
            newsLog.FileName = (string)reader["FileName"];
            newsLog.Author = (string)reader["Author"];
            newsLog.PostDate = (DateTime)reader["PostDate"];
            newsLog.RelationTotal = (int)reader["RelationTotal"];
            newsLog.Status = (bool)reader["Status"];
            newsLog.Language = (string)reader["Language"];
            newsLog.Ishot = (bool)reader["Ishot"];
            newsLog.Isview = (int)reader["Isview"];
            newsLog.Ishome = (bool)reader["Ishome"];
            newsLog.TypeNews = (bool)reader["TypeNews"];
            newsLog.IsComment = (bool)reader["IsComment"];
            newsLog.ApprovalDate = (DateTime)reader["ApprovalDate"];
            newsLog.ApprovalUserName = (string)reader["ApprovalUserName"];
            newsLog.IsApproval = (bool)reader["IsApproval"];
            newsLog.CreatedUserName = (string)reader["CreatedUserName"];
            newsLog.CommentTotal = (int)reader["CommentTotal"];
            newsLog.Slug = (string)reader["Slug"];
            newsLog.Keyword = (string)reader["Keyword"];
            newsLog.Tags = (string)reader["Tags"];
            newsLog.ShortTitle = (string)reader["ShortTitle"];
            newsLog.isUrl = (bool)reader["isUrl"];
            newsLog.Url = (string)reader["Url"];
            newsLog.isDelete = (bool)reader["isDelete"];
            newsLog.ModifyDate = (DateTime)reader["ModifyDate"];
            newsLog.ModifyUserName = (string)reader["ModifyUserName"];
            newsLog.Version = (int)reader["Version"];
            return newsLog;
        }

        public NewsLog GetNewsLog(NewsGroup newGroup, string username, DateTime date, int version)
        {
            NewsLog newsLog = new NewsLog();
            newsLog.NewsLogID = 0;
            newsLog.NewsGroupID = newGroup.NewsGroupID;
            newsLog.CateNewsID = newGroup.CateNewsID;
            newsLog.ParentNewsID = newGroup.ParentNewsID;
            newsLog.GroupCate = newGroup.GroupCate;
            newsLog.Title = newGroup.Title;
            newsLog.ShortDescribe = newGroup.ShortDescribe;
            newsLog.FullDescribe = newGroup.FullDescribe;
            newsLog.ImageThumb = newGroup.ImageThumb;
            newsLog.ImageLarge = newGroup.ImageLarge;
            newsLog.FileName = newGroup.FileName;
            newsLog.Author = newGroup.Author;
            newsLog.PostDate = newGroup.PostDate;
            newsLog.RelationTotal = newGroup.RelationTotal;
            newsLog.Status = newGroup.Status;
            newsLog.Language = newGroup.Language;
            newsLog.Ishot = newGroup.Ishot;
            newsLog.Isview = newGroup.Isview;
            newsLog.Ishome = newGroup.Ishome;
            newsLog.TypeNews = newGroup.TypeNews;
            newsLog.IsComment = newGroup.IsComment;
            newsLog.ApprovalDate = newGroup.ApprovalDate;
            newsLog.ApprovalUserName = newGroup.ApprovalUserName;
            newsLog.IsApproval = newGroup.IsApproval;
            newsLog.CreatedUserName = newGroup.CreatedUserName;
            newsLog.CommentTotal = newGroup.CommentTotal;
            newsLog.Slug = newGroup.Slug;
            newsLog.Keyword = newGroup.Keyword;
            newsLog.Tags = newGroup.Tags;
            newsLog.ShortTitle = newGroup.ShortTitle;
            newsLog.isUrl = newGroup.isUrl;
            newsLog.Url = newGroup.Url;
            newsLog.isDelete = newGroup.isDelete;
            newsLog.ModifyDate = date;
            newsLog.ModifyUserName = username;
            newsLog.Version = version;
            return newsLog;
        }

        #endregion

      

        #region CreateNewsLog
        public int CreateNewsLog(NewsLog newsLog)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsLogInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsLogID", 0);
                command.Parameters.AddWithValue("@NewsGroupID", newsLog.NewsGroupID);
                command.Parameters.AddWithValue("@CateNewsID", newsLog.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsLog.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsLog.GroupCate);
                command.Parameters.AddWithValue("@Title", newsLog.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsLog.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsLog.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsLog.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsLog.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsLog.FileName);
                command.Parameters.AddWithValue("@Author", newsLog.Author);
                command.Parameters.AddWithValue("@PostDate", newsLog.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsLog.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsLog.Status);
                command.Parameters.AddWithValue("@Language", newsLog.Language);
                command.Parameters.AddWithValue("@Ishot", newsLog.Ishot);
                command.Parameters.AddWithValue("@Isview", newsLog.Isview);
                command.Parameters.AddWithValue("@Ishome", newsLog.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsLog.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsLog.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", newsLog.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsLog.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsLog.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsLog.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsLog.CommentTotal);

                command.Parameters.AddWithValue("@Slug", newsLog.Slug);
                command.Parameters.AddWithValue("@Keyword", newsLog.Keyword);
                command.Parameters.AddWithValue("@Tags", newsLog.Tags);

                command.Parameters.AddWithValue("@ShortTitle", newsLog.ShortTitle);
                command.Parameters.AddWithValue("@isUrl", newsLog.isUrl);
                command.Parameters.AddWithValue("@Url", newsLog.Url);

                command.Parameters.AddWithValue("@isDelete", newsLog.isDelete);
                command.Parameters.AddWithValue("@ModifyDate", newsLog.ModifyDate);
                command.Parameters.AddWithValue("@ModifyUserName", newsLog.ModifyUserName);
                command.Parameters.AddWithValue("@Version", newsLog.Version);

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

        #region UpdateNewsLog
        public void UpdateNewsLog(NewsLog newsLog)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsLogUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsLogID", newsLog.NewsLogID);
                command.Parameters.AddWithValue("@NewsGroupID", newsLog.NewsGroupID);
                command.Parameters.AddWithValue("@CateNewsID", newsLog.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsLog.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsLog.GroupCate);
                command.Parameters.AddWithValue("@Title", newsLog.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsLog.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsLog.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsLog.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsLog.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsLog.FileName);
                command.Parameters.AddWithValue("@Author", newsLog.Author);
                command.Parameters.AddWithValue("@PostDate", newsLog.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsLog.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsLog.Status);
                command.Parameters.AddWithValue("@Language", newsLog.Language);
                command.Parameters.AddWithValue("@Ishot", newsLog.Ishot);
                command.Parameters.AddWithValue("@Isview", newsLog.Isview);
                command.Parameters.AddWithValue("@Ishome", newsLog.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsLog.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsLog.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", newsLog.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsLog.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsLog.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsLog.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsLog.CommentTotal);

                command.Parameters.AddWithValue("@Slug", newsLog.Slug);
                command.Parameters.AddWithValue("@Keyword", newsLog.Keyword);
                command.Parameters.AddWithValue("@Tags", newsLog.Tags);

                command.Parameters.AddWithValue("@ShortTitle", newsLog.ShortTitle);
                command.Parameters.AddWithValue("@isUrl", newsLog.isUrl);
                command.Parameters.AddWithValue("@Url", newsLog.Url);

                command.Parameters.AddWithValue("@isDelete", newsLog.isDelete);
                command.Parameters.AddWithValue("@ModifyDate", newsLog.ModifyDate);
                command.Parameters.AddWithValue("@ModifyUserName", newsLog.ModifyUserName);
                command.Parameters.AddWithValue("@Version", newsLog.Version);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion


        #region DeleteNewsLog
        public void DeleteNewsLog(int newsLogID, int newsGroupID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsLogDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("NewsLogID", newsLogID);
                command.Parameters.AddWithValue("NewsGroupID", newsGroupID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }



        public void DeleteNewsLog(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsLog where NewsLogID in('" + sId + "')";
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

        #region GetNewsLogById
        public NewsLog GetNewsLogById(int Id)
        {
            NewsLog newsLog = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsLogGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsLogID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        newsLog = NewsLogReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        newsLog = null;

                }
                command.Dispose();
            }
            return newsLog;
        }
        #endregion


        #region GetNewsLogPaging
        public DataTable GetNewsLogPaging(string lang, int newsGroupID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsLogGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@NewsGroupID", newsGroupID);
                command.Parameters.AddWithValue("@CurrentPage", _paging.CurrentPage);
                command.Parameters.AddWithValue("@PageSize", _paging.PageSize);
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