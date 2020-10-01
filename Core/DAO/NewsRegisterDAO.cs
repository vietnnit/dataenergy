using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class NewsRegisterDAO:BaseDAO
    {
        #region NewsRegisterReader
        private NewsRegister NewsRegisterReader(SqlDataReader reader)
        {
            NewsRegister _newsRegister = new NewsRegister();
            _newsRegister.NewsRegisterID = (int)reader["NewsRegisterID"];
            _newsRegister.CateNewsID = (int)reader["CateNewsID"];
            _newsRegister.ParentNewsID = (int)reader["ParentNewsID"];
            _newsRegister.GroupCate = (int)reader["GroupCate"];
            _newsRegister.Title = (string)reader["Title"];
            _newsRegister.ShortDescribe = (string)reader["ShortDescribe"];
            _newsRegister.FullDescribe = (string)reader["FullDescribe"];
            _newsRegister.ImageThumb = (string)reader["ImageThumb"];
            _newsRegister.ImageLarge = (string)reader["ImageLarge"];
            _newsRegister.FileName = (string)reader["FileName"];
            _newsRegister.Author = (string)reader["Author"];
            _newsRegister.PostDate = (DateTime)reader["PostDate"];
            _newsRegister.RelationTotal = (int)reader["RelationTotal"];
            _newsRegister.Status = (bool)reader["Status"];
            _newsRegister.Language = (string)reader["Language"];
            _newsRegister.Ishot = (bool)reader["Ishot"];
            _newsRegister.Isview = (int)reader["Isview"];
            _newsRegister.Ishome = (bool)reader["Ishome"];
            _newsRegister.TypeNews = (bool)reader["TypeNews"];
            _newsRegister.IsComment = (bool)reader["IsComment"];
            _newsRegister.ApprovalDate = (DateTime)reader["ApprovalDate"];
            _newsRegister.ApprovalUserName = (string)reader["ApprovalUserName"];
            _newsRegister.IsApproval = (bool)reader["IsApproval"];
            _newsRegister.CreatedUserName = (string)reader["CreatedUserName"];
            _newsRegister.CommentTotal = (int)reader["CommentTotal"];
            return _newsRegister;
        }
        #endregion

        #region CreateNewsRegister
        public void CreateNewsRegister(NewsRegister _newsRegister)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsRegisterID", 0);
                command.Parameters.AddWithValue("@CateNewsID", _newsRegister.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", _newsRegister.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", _newsRegister.GroupCate);
                command.Parameters.AddWithValue("@Title", _newsRegister.Title);
                command.Parameters.AddWithValue("@ShortDescribe", _newsRegister.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", _newsRegister.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", _newsRegister.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", _newsRegister.ImageLarge);
                command.Parameters.AddWithValue("@FileName", _newsRegister.FileName);
                command.Parameters.AddWithValue("@Author", _newsRegister.Author);
                command.Parameters.AddWithValue("@PostDate", _newsRegister.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", _newsRegister.RelationTotal);
                command.Parameters.AddWithValue("@Status", _newsRegister.Status);
                command.Parameters.AddWithValue("@Language", _newsRegister.Language);
                command.Parameters.AddWithValue("@Ishot", _newsRegister.Ishot);
                command.Parameters.AddWithValue("@Isview", _newsRegister.Isview);
                command.Parameters.AddWithValue("@Ishome", _newsRegister.Ishome);
                command.Parameters.AddWithValue("@TypeNews", _newsRegister.TypeNews);
                command.Parameters.AddWithValue("@IsComment", _newsRegister.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", _newsRegister.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", _newsRegister.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", _newsRegister.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", _newsRegister.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", _newsRegister.CommentTotal);


                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể thêm mới tin");
                else
                    command.Dispose();
            }
        }

        public int CreateNewsRegisterGet(NewsRegister _newsRegister)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsRegisterID", 0);
                command.Parameters.AddWithValue("@CateNewsID", _newsRegister.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", _newsRegister.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", _newsRegister.GroupCate);
                command.Parameters.AddWithValue("@Title", _newsRegister.Title);
                command.Parameters.AddWithValue("@ShortDescribe", _newsRegister.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", _newsRegister.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", _newsRegister.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", _newsRegister.ImageLarge);
                command.Parameters.AddWithValue("@FileName", _newsRegister.FileName);
                command.Parameters.AddWithValue("@Author", _newsRegister.Author);
                command.Parameters.AddWithValue("@PostDate", _newsRegister.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", _newsRegister.RelationTotal);
                command.Parameters.AddWithValue("@Status", _newsRegister.Status);
                command.Parameters.AddWithValue("@Language", _newsRegister.Language);
                command.Parameters.AddWithValue("@Ishot", _newsRegister.Ishot);
                command.Parameters.AddWithValue("@Isview", _newsRegister.Isview);
                command.Parameters.AddWithValue("@Ishome", _newsRegister.Ishome);
                command.Parameters.AddWithValue("@TypeNews", _newsRegister.TypeNews);
                command.Parameters.AddWithValue("@IsComment", _newsRegister.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", _newsRegister.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", _newsRegister.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", _newsRegister.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", _newsRegister.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", _newsRegister.CommentTotal);

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

        #region UpdateNewsRegister
        public void UpdateNewsRegister(NewsRegister _newsRegister)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsRegisterID", _newsRegister.NewsRegisterID);
                command.Parameters.AddWithValue("@CateNewsID", _newsRegister.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", _newsRegister.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", _newsRegister.GroupCate);
                command.Parameters.AddWithValue("@Title", _newsRegister.Title);
                command.Parameters.AddWithValue("@ShortDescribe", _newsRegister.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", _newsRegister.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", _newsRegister.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", _newsRegister.ImageLarge);
                command.Parameters.AddWithValue("@FileName", _newsRegister.FileName);
                command.Parameters.AddWithValue("@Author", _newsRegister.Author);
                command.Parameters.AddWithValue("@PostDate", _newsRegister.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", _newsRegister.RelationTotal);
                command.Parameters.AddWithValue("@Status", _newsRegister.Status);
                command.Parameters.AddWithValue("@Language", _newsRegister.Language);
                command.Parameters.AddWithValue("@Ishot", _newsRegister.Ishot);
                command.Parameters.AddWithValue("@Isview", _newsRegister.Isview);
                command.Parameters.AddWithValue("@Ishome", _newsRegister.Ishome);
                command.Parameters.AddWithValue("@TypeNews", _newsRegister.TypeNews);
                command.Parameters.AddWithValue("@IsComment", _newsRegister.IsComment);

                command.Parameters.AddWithValue("@ApprovalDate", _newsRegister.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", _newsRegister.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", _newsRegister.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", _newsRegister.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", _newsRegister.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateNewsRegister
        public void UpdateNewsRegister(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsRegister set Status = " + value + " where NewsRegisterID in('" + strId + "')";
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

        #region UpdateNewsRegisterApproval
        public void UpdateNewsRegisterApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsRegister set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsRegisterID in('" + strId + "')";
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

        public void UpdateNewsRegisterApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblNewsRegister set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsRegisterID = @NewsRegisterID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsRegisterID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteNewsRegister
        public void DeleteNewsRegister(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("NewsRegisterID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không xóa được tin");
                else
                    command.Dispose();
            }
        }



        public void DeleteNewsRegister(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblNewsRegister where NewsRegisterID in('" + sId + "')";
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

        #region GetNewsRegisterById
        public NewsRegister GetNewsRegisterById(int Id)
        {
            NewsRegister _newsRegister = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsRegisterID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsRegister = NewsRegisterReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newsRegister = null;

                }
                command.Dispose();
            }
            return _newsRegister;
        }
        #endregion

        #region GetNewsRegisterByParentNewsId
        public NewsRegister GetNewsRegisterByParentNewsId(int Id)
        {
            NewsRegister _newsRegister = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetByParentNewsId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ParentNewsID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _newsRegister = NewsRegisterReader(reader);
                    else
                        // throw new DataAccessException("Không tìm thấy tin");
                        _newsRegister = null;

                }
                command.Dispose();
            }
            return _newsRegister;
        }
        #endregion



        #region GetNewsRegisterAll
        public DataTable GetNewsRegisterAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetAll", connection);
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

        public DataTable GetNewsRegisterAll(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetAllGroup", connection);
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

        public DataTable GetNewsRegisterAll(string lang, int group, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where Language=@Language And CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate ORDER BY PostDate DESC";
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

        #region GetNewsRegisterPaging
        public DataTable GetNewsRegisterPaging(string lang, int group, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetPaging", connection);
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

        public DataTable GetNewsRegisterPaging(string lang, int group, string strCate, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterGetPagingbyCate", connection);
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
        #endregion

        #region GetNewsRegisterHot
        public DataTable GetNewsRegisterHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterHot", connection);
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

        public DataTable GetNewsRegisterHot(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterHotGroup", connection);
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

        public DataTable GetNewsRegisterHot(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsRegisterHot(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] = @GroupCate ORDER BY PostDate DESC ";
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

        public DataTable GetNewsRegisterHotOtherGroup(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " AND [GroupCate] != @GroupCate ORDER BY PostDate DESC ";
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

        public DataTable GetNewsRegisterHot(int n, string lang, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + "  ORDER BY PostDate DESC ";
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

        #region GetNewsRegisterViewHome
        public DataTable GetNewsRegisterViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterViewHome", connection);
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

        public DataTable GetNewsRegisterViewHome(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterViewHomeGroup", connection);
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

        public DataTable GetNewsRegisterViewHome(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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
        public DataTable GetNewsRegisterViewHome(string lang, int n, int cID, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND CateNewsID = @cateID AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsRegisterViewHome(string lang, string strCate, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND CateNewsID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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
        public DataTable GetNewsRegisterViewHome(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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


        #region NewsRegisterClickUpdate
        public void NewsRegisterClickUpdate(int nId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterClickUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NewsRegisterID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region NewsRegisterSearch
        public DataTable NewsRegisterSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterSearch", connection);
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

        public DataTable NewsRegisterSearch(string finter)
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
        #endregion

        #region GetNewsRegisterView
        public DataTable GetNewsRegisterView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterView", connection);
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

        public DataTable GetNewsRegisterView(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsRegisterViewGroup", connection);
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

        #region GetNewsRegisterByCateAll
        public DataTable GetNewsRegisterByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where CateNewsID in('" + strCate + "') ORDER BY PostDate DESC";
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
        public DataTable GetNewsRegisterByCateAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where CateNewsID in('" + strCate + "') AND [GroupCate] = @GroupCate  ORDER BY PostDate DESC";
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

        #region GetNewsRegisterByCateHomeAll
        public DataTable GetNewsRegisterByCateHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where status=1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate order by NewsRegisterID";
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

        public DataTable GetNewsRegisterByCateHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsRegister where status=1 and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate order by NewsRegisterID";
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
        public DataTable GetNewsRegisterByCateHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsRegister where status=1 and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate ORDER BY PostDate DESC";
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

        #region GetNewsRegisterByCateIsHomeAll
        public DataTable GetNewsRegisterByCateIsHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where status=1 and IsHome = 1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate order by NewsRegisterID";
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

        public DataTable GetNewsRegisterByCateIsHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsRegister where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate order by NewsRegisterID";
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
        public DataTable GetNewsRegisterByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsRegister where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate ORDER BY PostDate DESC";
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

        #region GetNewsRegisterByCateHomeList
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int num, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsRegister where CateNewsID in('" + strCate + "') And GroupCate = @GroupCate ORDER BY PostDate DESC";
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

        public DataTable GetNewsRegisterByCateHomeList(string strCate, int num, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsRegister where CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND Status = 1 ORDER BY PostDate DESC";
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

        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 ORDER BY PostDate DESC";
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

        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblNewsRegister where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " ORDER BY PostDate DESC";
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
        public DataTable GetNewsRegisterByCateHomeList(string strCate, int group, string approval, int num, string isHome)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsRegister where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " AND IsHome = " + isHome + " ORDER BY PostDate DESC";
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

        #region NewsRegisterFollow

        public DataTable NewsRegisterFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsRegister WHERE CateNewsID = " + cId + " AND NewsRegisterID < " + Id + " ORDER BY PostDate DESC";


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

        public DataTable NewsRegisterFollow(int Id, int cId, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsRegister WHERE CateNewsID = " + cId + " AND NewsRegisterID < " + Id + " AND status=1 AND IsApproval = " + approval + " ORDER BY PostDate DESC";


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

        #region GetNewsRegisterByCate


        public DataTable GetNewsRegisterByCate(int iCateId, string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblNewsRegister WHERE CateNewsID = " + iCateId + " AND status=1 AND IsApproval = " + approval + " ORDER BY PostDate DESC";


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

        #region GetNewsRegisterViewAll
        public DataTable GetNewsRegisterViewAll(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
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

        public DataTable GetNewsRegisterViewAll(string lang, int n, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsRegister where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate AND IsApproval = " + approval + " ORDER BY [PostDate] DESC ";
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
    }
}
