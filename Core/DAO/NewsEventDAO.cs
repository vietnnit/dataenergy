using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsEventDAO:BaseDAO
    {
        #region NewsEventReader
        private NewsEvent NewsEventReader(SqlDataReader reader)
        {
            NewsEvent newsGroup = new NewsEvent();
            newsGroup.NewsEventID = (int)reader["NewsEventID"];
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
            return newsGroup;
        }
        #endregion

        #region CreateNewsEvent
        public void CreateNewsEvent(NewsEvent newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsEventID", 0);
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


                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm mới tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CreateNewsEventGet
        public int CreateNewsEventGet(NewsEvent newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsEventID", 0);
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

        #region UpdateNewsEvent
        public void UpdateNewsEvent(NewsEvent newsGroup)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsEventID", newsGroup.NewsEventID);
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
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsEvent
        public void UpdateNewsEvent(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsEvent set Status = " + value + " where NewsEventID in('" + strId + "')";
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

        #region UpdateNewsEventApproval
        public void UpdateNewsEventApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsEvent set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsEventID in('" + strId + "')";
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

        public void UpdateNewsEventApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsEvent set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsEventID = @NewsEventID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsEventID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsEvent
        public void DeleteNewsEvent(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("NewsEventID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }



        public void DeleteNewsEvent(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsEvent where NewsEventID in('" + sId + "')";
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

        #region GetNewsEventById
        public NewsEvent GetNewsEventById(int Id)
        {
            NewsEvent newsGroup = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsEventID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        newsGroup = NewsEventReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        newsGroup = null;

                }
                command.Dispose();
            }
            return newsGroup;
        }
        #endregion



        #region GetNewsEventAll
        public DataTable GetNewsEventAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetAllbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", -1);
                command.Parameters.AddWithValue("@CateID", -1);
                command.Parameters.AddWithValue("@strCate", "");
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsEventAll(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetAllbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", -1);
                command.Parameters.AddWithValue("@strCate", "");
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsEventAll(string lang, int group, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                 SqlCommand command = new SqlCommand("_NewsEventGetAllbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", -1);
                command.Parameters.AddWithValue("@strCate", strCate);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsEventAll(string lang, int group, int cateId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetAllbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateID", cateId);
                command.Parameters.AddWithValue("@strCate", "");
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

        #region GetNewsEventPaging
        public DataTable GetNewsEventPaging(string lang, int group, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPaging", connection);
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

        public DataTable GetNewsEventPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingbyCate", connection);
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

        public DataTable GetNewsEventPaging(string lang, int group, int CateID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingbyCateID", connection);
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
        public DataTable GetNewsEventPagingApproved(string lang, int group, int CateID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingbyCateIDApproved", connection);
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

        public DataTable GetNewsEventAllPaging(string lang, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetAllPaging", connection);
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

        #endregion

        #region GetNewsEventPagingParent
        public DataTable GetNewsEventPagingParent(string lang, int pId, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingParent", connection);
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

        public DataTable GetNewsEventPagingParent(string lang, int pId, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingParentbyCate", connection);
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

        #region GetNewsEventPagingbyTags
        public DataTable GetNewsEventPagingbyTags(int tagsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingbyTags", connection);
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
        public DataTable GetNewsEventPagingbyTagsApproved(int tagsID, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventGetPagingbyTagsApproved", connection);
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

        #region GetNewsEventHot
        public DataTable GetNewsEventHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventHot", connection);
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

        public DataTable GetNewsEventHot(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventHotGroup", connection);
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

        public DataTable GetNewsEventHot(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsEventHot(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        public DataTable GetNewsEventHotOtherGroup(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] != @GroupCate AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        public DataTable GetNewsEventHot(int n, string lang, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0   ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventViewHome
        public DataTable GetNewsEventViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventViewHome", connection);
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

        public DataTable GetNewsEventViewHome(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventViewHomeGroup", connection);
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

        public DataTable GetNewsEventViewHome(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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
        public DataTable GetNewsEventViewHome(string lang, int n, int cID, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND CateNewsID = @cateID AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsEventViewHome(string lang, string strCate, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND CateNewsID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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
        public DataTable GetNewsEventViewHome(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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


        #region NewsEventClickUpdate
        public void NewsEventClickUpdate(int nId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventClickUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsEventID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region NewsEventSearch
        public DataTable NewsEventSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventSearch", connection);
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

        public DataTable NewsEventSearch(string finter)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventSearchs", connection);
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

         public DataTable NewsEventSearchPaging(string finter, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventSearchPaging", connection);
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

        #region GetNewsEventView
        public DataTable GetNewsEventView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventView", connection);
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

        public DataTable GetNewsEventView(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsEventViewGroup", connection);
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

        #region GetNewsEventByCateAll
        public DataTable GetNewsEventByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where CateNewsID in('" + strCate + "') AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventByCateAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where CateNewsID in('" + strCate + "') AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0   ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventByCateHomeAll
        public DataTable GetNewsEventByCateHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where status=1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate order by NewsEventID";
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

        public DataTable GetNewsEventByCateHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsEvent where status=1 and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  order by NewsEventID";
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
        public DataTable GetNewsEventByCateHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsEvent where status=1 and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventByCateIsHomeAll
        public DataTable GetNewsEventByCateIsHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where status=1 and IsHome = 1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate AND [ParentNewsID] = 0  order by NewsEventID";
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

        public DataTable GetNewsEventByCateIsHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsEvent where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  order by NewsEventID";
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
        public DataTable GetNewsEventByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsEvent where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventByCateHomeList
        public DataTable GetNewsEventByCateHomeList(string strCate, int num, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where CateNewsID in('" + strCate + "') And GroupCate = @GroupCate AND [ParentNewsID] = 0 ORDER BY PostDate DESC, NewsEventID DESC";
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

        public DataTable GetNewsEventByCateHomeList(string strCate, int num, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0 AND Status = 1 ORDER BY PostDate DESC, NewsEventID DESC";
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

        public DataTable GetNewsEventByCateHomeList(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string approval, int num, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventByCateHomeList(string strCate, int group, string approval, int num, string isHome, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventByCateHot(string strCate, int group, string approval, int num, string isHome, string isHot)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND isHot =" + isHot + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventByListNewsID
        public DataTable GetNewsEventByListNewsID(string lang, string strCate, string approval, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsEvent where NewsEventID in('" + strCate + "') AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventByListNewsID(string lang, string strCate, int num, string approval, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsEvent where NewsEventID in('" + strCate + "') AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " AND [ParentNewsID] = 0 AND [Language]=@Language  ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region NewsEventFollow

        public DataTable NewsEventFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsEvent WHERE CateNewsID = " + cId + " AND NewsEventID < " + Id + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";


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

        public DataTable NewsEventFollow(int Id, int cId, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsEvent WHERE CateNewsID = " + cId + " AND NewsEventID < " + Id + " AND status=1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";


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

        #region NewsEventParent
        public DataTable NewsEventParent(int pId, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT * FROM tblNewsEvent WHERE ParentNewsID = " + pId + " AND status=1 AND IsApproval = " + approval + " ORDER BY PostDate DESC, NewsEventID DESC";


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

        #region GetNewsEventByCate


        public DataTable GetNewsEventByCate(int iCateId, string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsEvent WHERE CateNewsID = " + iCateId + " AND status=1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";


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

        #region GetNewsEventViewAll
        public DataTable GetNewsEventViewAll(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsEventViewAll(string lang, int n, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY [PostDate] DESC ";
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


        public DataTable GetNewsEventLates(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and IsHome = 1 and IsHot = 0 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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
        public DataTable GetNewsEventLates(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and IsHome = 1 and IsHot = 0 AND Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY PostDate DESC, NewsEventID DESC";
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

        #region GetNewsEventViewAll
        public DataTable GetNewsEventHits(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and IsHome = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate AND [ParentNewsID] = 0  ORDER BY isView DESC ";
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

        public DataTable GetNewsEventHits(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsEvent where Language = '" + lang + "' and IsHome = 1 and Status = 1 AND IsApproval = " + approval + " AND [ParentNewsID] = 0  ORDER BY isView DESC ";
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
    }
}