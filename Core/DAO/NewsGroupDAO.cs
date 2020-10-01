using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsGroupDAO : BaseDAO
    {
        #region NewsGroupReader
        private NewsGroup NewsGroupReader(SqlDataReader reader)
        {
            NewsGroup newsGroup = new NewsGroup();
            newsGroup.NewsGroupID = (int)reader["NewsGroupID"];
            newsGroup.CateNewsID = (int)reader["CateNewsID"];
            newsGroup.ParentNewsID = (int)reader["ParentNewsID"];
            newsGroup.GroupCate = (int)reader["GroupCate"];
            newsGroup.Title = (string)reader["Title"];
            newsGroup.ShortDescribe = (string)reader["ShortDescribe"];
            newsGroup.FullDescribe = (string)reader["FullDescribe"];
            newsGroup.ImageThumb = (string)reader["ImageThumb"];
            newsGroup.ImageLarge = (string)reader["ImageLarge"];
            newsGroup.FileName = (string)reader["FileName"];
            newsGroup.Author = (string)reader["Author"];
            newsGroup.PostDate = (DateTime)reader["PostDate"];
            newsGroup.RelationTotal = (int)reader["RelationTotal"];
            newsGroup.Status = (bool)reader["Status"];
            newsGroup.Language = (string)reader["Language"];
            newsGroup.Ishot = (bool)reader["Ishot"];
            newsGroup.Isview = (int)reader["Isview"];
            newsGroup.Ishome = (bool)reader["Ishome"];
            newsGroup.TypeNews = (bool)reader["TypeNews"];
            newsGroup.IsComment = (bool)reader["IsComment"];
            newsGroup.ApprovalDate = (DateTime)reader["ApprovalDate"];
            newsGroup.ApprovalUserName = (string)reader["ApprovalUserName"];
            newsGroup.IsApproval = (bool)reader["IsApproval"];
            newsGroup.CreatedUserName = (string)reader["CreatedUserName"];
            newsGroup.CommentTotal = (int)reader["CommentTotal"];
            newsGroup.Slug = (string)reader["Slug"];
            newsGroup.Keyword = (string)reader["Keyword"];
            newsGroup.Tags = (string)reader["Tags"];
            newsGroup.ShortTitle = (string)reader["ShortTitle"];
            newsGroup.isUrl = (bool)reader["isUrl"];
            newsGroup.Url = (string)reader["Url"];
            newsGroup.isDelete = (bool)reader["isDelete"];
            return newsGroup;
        }
        #endregion

        #region CreateNewsGroup
        public void CreateNewsGroup(NewsGroup newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsGroupID", 0);
                command.Parameters.AddWithValue("@CateNewsID", newsGroup.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsGroup.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsGroup.GroupCate);
                command.Parameters.AddWithValue("@Title", newsGroup.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsGroup.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsGroup.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsGroup.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsGroup.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsGroup.FileName);
                command.Parameters.AddWithValue("@Author", newsGroup.Author);
                command.Parameters.AddWithValue("@PostDate", newsGroup.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsGroup.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsGroup.Status);
                command.Parameters.AddWithValue("@Language", newsGroup.Language);
                command.Parameters.AddWithValue("@Ishot", newsGroup.Ishot);
                command.Parameters.AddWithValue("@Isview", newsGroup.Isview);
                command.Parameters.AddWithValue("@Ishome", newsGroup.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsGroup.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsGroup.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", newsGroup.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsGroup.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsGroup.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsGroup.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsGroup.CommentTotal);

                command.Parameters.AddWithValue("@Slug", newsGroup.Slug);
                command.Parameters.AddWithValue("@Keyword", newsGroup.Keyword);
                command.Parameters.AddWithValue("@Tags", newsGroup.Tags);

                command.Parameters.AddWithValue("@ShortTitle", newsGroup.ShortTitle);
                command.Parameters.AddWithValue("@isUrl", newsGroup.isUrl);
                command.Parameters.AddWithValue("@Url", newsGroup.Url);

                command.Parameters.AddWithValue("@isDelete", newsGroup.isDelete);


                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm mới tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CreateNewsGroupGet
        public int CreateNewsGroupGet(NewsGroup newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsGroupID", 0);
                command.Parameters.AddWithValue("@CateNewsID", newsGroup.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsGroup.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsGroup.GroupCate);
                command.Parameters.AddWithValue("@Title", newsGroup.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsGroup.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsGroup.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsGroup.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsGroup.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsGroup.FileName);
                command.Parameters.AddWithValue("@Author", newsGroup.Author);
                command.Parameters.AddWithValue("@PostDate", newsGroup.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsGroup.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsGroup.Status);
                command.Parameters.AddWithValue("@Language", newsGroup.Language);
                command.Parameters.AddWithValue("@Ishot", newsGroup.Ishot);
                command.Parameters.AddWithValue("@Isview", newsGroup.Isview);
                command.Parameters.AddWithValue("@Ishome", newsGroup.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsGroup.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsGroup.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", newsGroup.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsGroup.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsGroup.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsGroup.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsGroup.CommentTotal);

                command.Parameters.AddWithValue("@Slug", newsGroup.Slug);
                command.Parameters.AddWithValue("@Keyword", newsGroup.Keyword);
                command.Parameters.AddWithValue("@Tags", newsGroup.Tags);

                command.Parameters.AddWithValue("@ShortTitle", newsGroup.ShortTitle);
                command.Parameters.AddWithValue("@isUrl", newsGroup.isUrl);
                command.Parameters.AddWithValue("@Url", newsGroup.Url);

                command.Parameters.AddWithValue("@isDelete", newsGroup.isDelete);

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

        #region UpdateNewsGroup
        public void UpdateNewsGroup(NewsGroup newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsGroupID", newsGroup.NewsGroupID);
                command.Parameters.AddWithValue("@CateNewsID", newsGroup.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsGroup.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsGroup.GroupCate);
                command.Parameters.AddWithValue("@Title", newsGroup.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsGroup.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsGroup.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsGroup.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsGroup.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsGroup.FileName);
                command.Parameters.AddWithValue("@Author", newsGroup.Author);
                command.Parameters.AddWithValue("@PostDate", newsGroup.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsGroup.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsGroup.Status);
                command.Parameters.AddWithValue("@Language", newsGroup.Language);
                command.Parameters.AddWithValue("@Ishot", newsGroup.Ishot);
                command.Parameters.AddWithValue("@Isview", newsGroup.Isview);
                command.Parameters.AddWithValue("@Ishome", newsGroup.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsGroup.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsGroup.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", newsGroup.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsGroup.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsGroup.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsGroup.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsGroup.CommentTotal);

                command.Parameters.AddWithValue("@Slug", newsGroup.Slug);
                command.Parameters.AddWithValue("@Keyword", newsGroup.Keyword);
                command.Parameters.AddWithValue("@Tags", newsGroup.Tags);

                command.Parameters.AddWithValue("@ShortTitle", newsGroup.ShortTitle);
                command.Parameters.AddWithValue("@isUrl", newsGroup.isUrl);
                command.Parameters.AddWithValue("@Url", newsGroup.Url);

                command.Parameters.AddWithValue("@isDelete", newsGroup.isDelete);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsGroup
        public void UpdateNewsGroup(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set Status = " + value + " where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        public void UpdateNewsGroup(int Id, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set Status = " + value + " where NewsGroupID =" + Id;
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

        #region UpdateNewsGroupApproval
        public void UpdateNewsGroupApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsGroupID in('" + strId + "')";
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

        public void UpdateNewsGroupApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsGroupID = @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsGroupisDelete
        public void UpdateNewsGroupisDelete(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDelete = " + value + "  where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }

        public void UpdateNewsGroupisDelete(int Id, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDelete = " + value + " where NewsGroupID = @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsGroupCate

        public void UpdateNewsGroupCate(int cateNewsId, int groupCate)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsGroup set GroupCate = @GroupCate where CateNewsID = @CateNewsID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@CateNewsID", cateNewsId);
                command.Parameters.AddWithValue("@GroupCate", groupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsGroup
        public void DeleteNewsGroup(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }



        public void DeleteNewsGroup(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsGroup where NewsGroupID in('" + sId + "')";
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

        #region GetNewsGroupById
        public NewsGroup GetNewsGroupById(int Id)
        {
            NewsGroup newsGroup = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        newsGroup = NewsGroupReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        newsGroup = null;

                }
                command.Dispose();
            }
            return newsGroup;
        }
        #endregion



        #region GetNewsGroupAll
        public DataTable GetNewsGroupAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupAll(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetAllGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupAll(string lang, int group, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where Language=@Language And CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND [ParentNewsID] = 0 AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", lang);
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

        #region GetNewsGroupPagingbyUser

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCate_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@CreatedUserName", username);
                command.Parameters.AddWithValue("@IsApproval", -1);
                command.Parameters.AddWithValue("@Status", -1);
                command.Parameters.AddWithValue("@isDelete", 0);
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

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username, int isAprroved, int status)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCate_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@CreatedUserName", username);
                command.Parameters.AddWithValue("@IsApproval", isAprroved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isDelete", 0);
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

        public DataTable GetNewsGroupPagingbyUserisDelete(string lang, int group, string strCate, PagingInfo _paging, string username, int isAprroved, int status, int isDelete)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCate_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@CreatedUserName", username);
                command.Parameters.AddWithValue("@IsApproval", isAprroved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isDelete", isDelete);
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

        #region GetNewsGroupPaging
        public DataTable GetNewsGroupPaging(string lang, int group, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetNewsGroupPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
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

        public DataTable GetNewsGroupPaging(string lang, int group, int CateID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
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
        public DataTable GetNewsGroupPagingApproved(string lang, int group, int CateID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCateIDApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@IsApproval", 1);
                command.Parameters.AddWithValue("@Status", 1);
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
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbystrCateApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", 1);
                command.Parameters.AddWithValue("@Status", 1);
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

        public DataTable GetNewsGroupPagingApproved(string lang, int group, int CateID, PagingInfo _paging, int isApproved, int status)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCateIDApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
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
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging, int isApproved, int status)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbystrCateApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
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
        public DataTable GetNewsGroupAllPaging(string lang, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetAllPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
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

        public DataTable GetNewsGroupPagingApproved(string lang, int group, int CateID, PagingInfo _paging, int isApproved, int status, int isHot, int isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyCateIDApprovedHot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isHot", isHot);
                command.Parameters.AddWithValue("@isHome", isHome);
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
        public DataTable GetNewsGroupPagingApproved(string lang, int group, string strCate, PagingInfo _paging, int isApproved, int status, int isHot, int isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbystrCateApprovedHot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isHot", isHot);
                command.Parameters.AddWithValue("@isHome", isHome);
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



        #region GetNewsGroupPagingParent
        public DataTable GetNewsGroupPagingParent(string lang, int pId, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@pId", pId);
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

        public DataTable GetNewsGroupPagingParent(string lang, int pId, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingParentbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@pId", pId);
                command.Parameters.AddWithValue("@strCate", strCate);
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

        #region GetNewsGroupPagingbyTags
        public DataTable GetNewsGroupPagingbyTags(int tagsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyTags", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TagsID", tagsID);
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
        public DataTable GetNewsGroupPagingbyTagsApproved(int tagsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingbyTagsApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TagsID", tagsID);
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

        #region GetNewsGroupHot
        public DataTable GetNewsGroupHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupHot", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupHotGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsOneByGroup(string lang, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select * from tblNewsGroup where Language = '" + lang + "' and TypeNews = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupHot(string lang, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select * from tblNewsGroup where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, string approval, string hot, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select * from tblNewsGroup where Language = '" + lang + "' and Ishot = " + hot + " AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHotOtherGroup(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] != @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(int n, string lang, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and Ishot = 1 AND IsHome<>1 AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0   AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
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

        #region GetNewsGroupViewHome
        public DataTable GetNewsGroupViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewHome", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewHomeGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupViewHome(string lang, int n, int cID, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND CateNewsID = @cateID AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@cateID", cID);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, string strCate, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND CateNewsID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupViewHome(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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


        #region NewsGroupClickUpdate
        public void NewsGroupClickUpdate(int nId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupClickUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsGroupID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region NewsGroupSearch
        public DataTable NewsGroupSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupSearch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateNewsID", cateid);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }


            return datatable;
        }

        public DataTable NewsGroupSearch(string finter)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsSearchs", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Finter", finter);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable NewsGroupSearchPaging(string finter, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsSearchPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Finter", finter);
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

        #region GetNewsGroupView
        public DataTable GetNewsGroupView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupView", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupView(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetNewsGroupByCateAll
        public DataTable GetNewsGroupByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0  ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetNewsGroupByCateHomeAll
        public DataTable GetNewsGroupByCateHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate  AND [isDelete] = 0 order by NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 order by NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetNewsGroupByCateIsHomeAll
        public DataTable GetNewsGroupByCateIsHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where status=1 and IsHome = 1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 order by NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 order by NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetNewsGroupByCateHomeList
        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "') And GroupCate = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0 AND Status = 1  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string approval, int num, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string approval, int num, string isHome, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHot(string strCate, int group, string approval, int num, string isHome, string isHot)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND isHot =" + isHot + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHot(int CateID, int group, string approval, int num, string isHome, string isHot)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID = @CateNewsID AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND isHot =" + isHot + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateNewsID", CateID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHotAll(int CateID, int group, string approval, string isHome, string isHot)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                //string SQL = "select * from tblNewsGroup where CateNewsID = @CateNewsID AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND isHot =" + isHot + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                string SQL = "select * from tblNewsGroup where CateNewsID = @CateNewsID AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND TypeNews =" + isHot + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateNewsID", CateID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByCateHotAll(string strCate, int group, string approval, string isHome, string isHot)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND isHot =" + isHot + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetNewsGroupByListNewsID
        public DataTable GetNewsGroupByListNewsID(string lang, string strCate, string approval, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsGroup where NewsGroupID in('" + strCate + "') AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupByListNewsID(string lang, string strCate, int num, string approval, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where NewsGroupID in('" + strCate + "') AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", lang);
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

        #region NewsGroupFollow

        public DataTable NewsGroupFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsGroup WHERE CateNewsID = " + cId + " AND NewsGroupID < " + Id + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";


                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;


                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable NewsGroupFollow(int Id, int cId, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsGroup WHERE CateNewsID = " + cId + " AND NewsGroupID < " + Id + " AND status=1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";


                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;


                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable NewsGroupFollow(DateTime postDateID, int id, int cId, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsGroup WHERE CateNewsID = @CateNewsID AND PostDate <= @PostDate AND NewsGroupID <> @NewsGroupID AND status=1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@CateNewsID", cId);
                command.Parameters.AddWithValue("@PostDate", postDateID);
                command.Parameters.AddWithValue("@NewsGroupID", id);

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

        #region NewsGroupParent
        public DataTable NewsGroupParent(int pId, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT * FROM tblNewsGroup WHERE ParentNewsID = " + pId + " AND status=1 AND IsApproval = " + approval + "  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";


                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;


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

        #region GetNewsGroupByCate


        public DataTable GetNewsGroupByCate(int iCateId, string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsGroup WHERE CateNewsID = " + iCateId + " AND status=1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0   AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";


                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;


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

        #region GetNewsGroupViewAll
        public DataTable GetNewsGroupViewAll(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewAll(string lang, int n, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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


        public DataTable GetNewsGroupLates(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and IsHome = 1 and IsHot = 0 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsLatest(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                //string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = @Language and IsHome = 1 and IsHot = 0 AND Status = 1 AND IsApproval = @IsApproval AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = @Language and IsHome = 1 AND Status = 1 AND IsApproval = @IsApproval AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@IsApproval", approval);
       
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetNewsGroupLates(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and IsHome = 1 and IsHot = 0 AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY PostDate DESC, NewsGroupID DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                //command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        #region GetNewsGroupViewAll
        public DataTable GetNewsGroupHits(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and IsHome = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY isView DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHits(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and IsHome = 1 and Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  AND [isDelete] = 0 ORDER BY isView DESC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                //command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetNewsGroupPaging(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isHot", isHot);
                command.Parameters.AddWithValue("@isHome", isHome);
                command.Parameters.AddWithValue("@isDelete", isDelete);
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

        public DataTable GetNewsGroupPagingbyUser(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, string username, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isHot", isHot);
                command.Parameters.AddWithValue("@isHome", isHome);
                command.Parameters.AddWithValue("@isDelete", isDelete);
                command.Parameters.AddWithValue("@CreatedUserName", username);
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

        public DataTable GetNewsGroupPagingRecord(string lang, int group, int CateID, string strCate, int isApproved, int status, int isHot, int isHome, int isDelete, int nRecord)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetPagingRecord", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", CateID);
                command.Parameters.AddWithValue("@strCate", strCate);
                command.Parameters.AddWithValue("@IsApproval", isApproved);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@isHot", isHot);
                command.Parameters.AddWithValue("@isHome", isHome);
                command.Parameters.AddWithValue("@isDelete", isDelete);
                command.Parameters.AddWithValue("@nRecord", nRecord);
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