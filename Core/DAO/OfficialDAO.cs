using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class OfficialDAO : BaseDAO
    {
        public OfficialDAO()
        {
            //Constructor
        }

        #region OfficialReader
        private Official OfficialReader(SqlDataReader reader)
        {
            Official official = new Official();
            official.OfficialID = (int)reader["OfficialID"];
            official.CateOfficialID = (int)reader["CateOfficialID"];
            official.NoCode = (string)reader["NoCode"];
            official.OfficialName = (string)reader["OfficialName"];
            official.DatePublic = (DateTime)reader["DatePublic"];
            official.Company = (string)reader["Company"];
            official.Classify = (string)reader["Classify"];
            official.Writer = (string)reader["Writer"];
            official.Quote = (string)reader["Quote"];
            official.KeyShort = (string)reader["KeyShort"];
            official.Attached = (string)reader["Attached"];
            official.Status = (bool)reader["Status"];
            official.ApprovalDate = (DateTime)reader["ApprovalDate"];
            official.ApprovalUserName = (string)reader["ApprovalUserName"];
            official.IsApproval = (bool)reader["IsApproval"];
            official.CreatedUserName = (string)reader["CreatedUserName"];
            official.CreatedDate = (DateTime)reader["CreatedDate"];
            official.GroupCate = (int)reader["GroupCate"];
            official.Language = (string)reader["Language"];
            official.isDelete = (bool)reader["isDelete"];

            return official;
        }
        #endregion

        #region CreateOfficial
        public void CreateOfficial(Official official)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OfficialID", 0);
                command.Parameters.AddWithValue("@CateOfficialID", official.CateOfficialID);
                command.Parameters.AddWithValue("@NoCode", official.NoCode);
                command.Parameters.AddWithValue("@OfficialName", official.OfficialName);
                command.Parameters.AddWithValue("@DatePublic", official.DatePublic);
                command.Parameters.AddWithValue("@Company", official.Company);
                command.Parameters.AddWithValue("@Classify", official.Classify);
                command.Parameters.AddWithValue("@Writer", official.Writer);
                command.Parameters.AddWithValue("@Quote", official.Quote);
                command.Parameters.AddWithValue("@KeyShort", official.KeyShort);
                command.Parameters.AddWithValue("@Attached", official.Attached);
                command.Parameters.AddWithValue("@Status", official.Status);

                command.Parameters.AddWithValue("@ApprovalDate", official.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", official.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", official.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", official.CreatedUserName);
                command.Parameters.AddWithValue("@CreatedDate", official.CreatedDate);
                command.Parameters.AddWithValue("@GroupCate", official.GroupCate);
                command.Parameters.AddWithValue("@Language", official.Language);
                command.Parameters.AddWithValue("@isDelete", official.isDelete);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them moi duoc official");
                else
                    command.Dispose();
            }
        }

        public int CreateOfficialGet(Official official)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OfficialID", 0);
                command.Parameters.AddWithValue("@CateOfficialID", official.CateOfficialID);
                command.Parameters.AddWithValue("@NoCode", official.NoCode);
                command.Parameters.AddWithValue("@OfficialName", official.OfficialName);
                command.Parameters.AddWithValue("@DatePublic", official.DatePublic);
                command.Parameters.AddWithValue("@Company", official.Company);
                command.Parameters.AddWithValue("@Classify", official.Classify);
                command.Parameters.AddWithValue("@Writer", official.Writer);
                command.Parameters.AddWithValue("@Quote", official.Quote);
                command.Parameters.AddWithValue("@KeyShort", official.KeyShort);
                command.Parameters.AddWithValue("@Attached", official.Attached);
                command.Parameters.AddWithValue("@Status", official.Status);

                command.Parameters.AddWithValue("@ApprovalDate", official.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", official.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", official.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", official.CreatedUserName);
                command.Parameters.AddWithValue("@CreatedDate", official.CreatedDate);
                command.Parameters.AddWithValue("@GroupCate", official.GroupCate);
                command.Parameters.AddWithValue("@Language", official.Language);
                command.Parameters.AddWithValue("@isDelete", official.isDelete);
                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc san pham");
                else
                    i = (int)parameter.Value;
                command.Dispose();
            }
            return i;
        }
        #endregion

        #region UpdateOfficial
        public void UpdateOfficial(Official official)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OfficialID", official.OfficialID);
                command.Parameters.AddWithValue("@CateOfficialID", official.CateOfficialID);
                command.Parameters.AddWithValue("@NoCode", official.NoCode);
                command.Parameters.AddWithValue("@OfficialName", official.OfficialName);
                command.Parameters.AddWithValue("@DatePublic", official.DatePublic);
                command.Parameters.AddWithValue("@Company", official.Company);
                command.Parameters.AddWithValue("@Classify", official.Classify);
                command.Parameters.AddWithValue("@Writer", official.Writer);
                command.Parameters.AddWithValue("@Quote", official.Quote);
                command.Parameters.AddWithValue("@KeyShort", official.KeyShort);
                command.Parameters.AddWithValue("@Attached", official.Attached);
                command.Parameters.AddWithValue("@Status", official.Status);

                command.Parameters.AddWithValue("@ApprovalDate", official.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", official.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", official.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", official.CreatedUserName);
                command.Parameters.AddWithValue("@CreatedDate", official.CreatedDate);
                command.Parameters.AddWithValue("@GroupCate", official.GroupCate);
                command.Parameters.AddWithValue("@Language", official.Language);
                command.Parameters.AddWithValue("@isDelete", official.isDelete);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc official");
                else
                    command.Dispose();
            }
        }

        public void UpdateOfficial(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set Status = @Status where OfficialID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Status", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        public void UpdateOfficial(int officialId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set Status = @Status where OfficialID = @OfficialID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@OfficialID", officialId);
                command.Parameters.AddWithValue("@Status", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }

        public void UpdateOfficial(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set IsApproval = @IsApproval, ApprovalUserName = @ApprovalUserName,ApprovalDate = @Date  where OfficialID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@ApprovalUserName", username);
                command.Parameters.AddWithValue("@IsApproval", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        public void UpdateOfficial(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set IsApproval = @IsApproval, ApprovalUserName = @ApprovalUserName ,ApprovalDate = @Date  where OfficialID = @OfficialID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@OfficialID", Id);
                command.Parameters.AddWithValue("@ApprovalUserName", username);
                command.Parameters.AddWithValue("@IsApproval", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteOfficial
        public void DeleteOfficial(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficialID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc official");
                else
                    command.Dispose();
            }
        }

        public void DeleteOfficial(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblOfficial where OfficialID in('" + sId + "')";
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

        #region UpdateOfficialisDelete
        public void UpdateOfficialisDelete(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set IsDelete = @IsDelete where OfficialID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@IsDelete", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }

        public void UpdateOfficialisDelete(int Id, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOfficial set IsDelete = @IsDelete where OfficialID = @OfficialID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@OfficialID", Id);
                command.Parameters.AddWithValue("@IsDelete", value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetOfficialAll
        public DataTable GetOfficialAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetAll", connection);
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
        public DataTable GetOfficialAll(int group, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetAllGroup", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetOfficialAll(int group, string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') AND GroupCate = @GroupCate  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region GetOfficialNews
        public DataTable GetOfficialNews(int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial WHERE [isDelete]=0 and [Language]=@Language order by DatePublic Desc";
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

        public DataTable GetOfficialNews(int num, int group, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * where [isDelete]=0 and [Language]=@Language AND GroupCate = @GroupCate  from tblOfficial order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetOfficialNews(int num, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from  tblOfficial Where [isDelete]=0 and [Language]=@Language AND status = 1 AND IsApproval = @IsApproval order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
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

        public DataTable GetOfficialNews(int num, int group, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial Where [isDelete]=0 and [Language]=@Language AND GroupCate = @GroupCate and status = 1 AND IsApproval = @IsApproval order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", _lang);
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
        #endregion

        #region GetOfficialById
        public Official GetOfficialById(int Id)
        {
            Official official = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficialID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        official = OfficialReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    command.Dispose();
                }
            }
            return official;
        }
        #endregion

        #region OfficialSearch
        public DataTable OfficialSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialSearch", connection);
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


        public DataTable OfficialSearchPaging(string finter, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialSearchPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Finter", finter);
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
        #endregion

        #region GetOfficialByCateHomeList
        public DataTable GetOfficialByCateHomeList(string strCate, int num, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') order by DatePublic Desc";
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

         public DataTable GetOfficialByCateHomeList(string strCate, int num, int group, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where [isDelete]=0 and [Language]=@Language AND GroupCate=@GroupCate and CateOfficialID in('" + strCate + "') order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetOfficialByCateHomeList(string strCate, int num, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') AND status=1 AND IsApproval = @IsApproval order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
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

        public DataTable GetOfficialByCateHomeList(string strCate, int num, int group, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where [isDelete]=0 and [Language]=@Language AND GroupCate = @GroupCate and CateOfficialID in('" + strCate + "') AND status=1 AND IsApproval = @IsApproval order by DatePublic Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", _lang);
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

        public DataTable GetOfficialByCateHomeList(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') order by OfficialID Desc";
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

        public DataTable GetOfficialByCateHomeList(int group, string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND GroupCate = @GroupCate and CateOfficialID in('" + strCate + "') order by OfficialID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        #region OfficialClickUpdate
        public void OfficialClickUpdate(int nId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialClickUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfficialID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật số lần click");
                else
                    command.Dispose();
            }
        }
        #endregion

        

        #region GetOfficialPaging
        public DataTable GetOfficialPaging(int group, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
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

        public DataTable GetOfficialPaging(int group, string strCate, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@strCate", strCate);
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

        public DataTable GetOfficialPaging(int group, int CateID, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCateID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateOfficialID", CateID);
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
        public DataTable GetOfficialPagingApproved(int group, int CateID, PagingInfo _paging, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCateIDApproved", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateOfficialID", CateID);
                command.Parameters.AddWithValue("@IsApproval", 1);
                command.Parameters.AddWithValue("@Status", -1);
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
        #endregion

        #region GetOfficialByCate
        public DataTable GetOfficialByCate(int CateID, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@CateOffficialID", CateID );
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
        public DataTable GetOfficialByCate(int CateID, int group, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID and GroupCate = @GroupCate  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@CateOffficialID", CateID);
                command.Parameters.AddWithValue("@GroupCate", group);
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
        public DataTable GetOfficialByCate(string strCate, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') ORDER BY DatePublic DESC";
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
        public DataTable GetOfficialByCate(string strCate, int group, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "select * from tblOfficial where [isDelete]=0 and [Language]=@Language AND CateOfficialID in('" + strCate + "') AND [GroupCate] = @GroupCate ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
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
        public DataTable GetOfficialByCate(int iCateId, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID And IsApproval = @IsApproval  AND status=@status  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@IsApproval", approval);
                command.Parameters.AddWithValue("@status", 1);
                command.Parameters.AddWithValue("@CateOfficialID", iCateId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetOfficialByCate(int iCateId, int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID AND IsApproval = @IsApproval AND status=@status  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@IsApproval", approval);
                command.Parameters.AddWithValue("@status", 1);
                command.Parameters.AddWithValue("@CateOfficialID", iCateId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetOfficialByCate(int iCateId, int n, int group, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND GroupCate = @Groupcate and CateOfficialID = @CateOfficialID And IsApproval=@IsApproval AND status=@status  ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@IsApproval", approval);
                command.Parameters.AddWithValue("@status", 1);
                command.Parameters.AddWithValue("@CateOfficialID", iCateId);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetOfficialByCate(string strCate, int n, int group, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {

                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND GroupCate = @Groupcate and CateOfficialID in('" + strCate + "') And IsApproval=@IsApproval AND status=@status ORDER BY DatePublic DESC";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@IsApproval", approval);
                command.Parameters.AddWithValue("@status", 1);

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

        #region GetOfficialPagingbyUser

        public DataTable GetOfficialPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCate_user", connection);
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

        public DataTable GetOfficialPagingbyUser(string lang, int group, string strCate, PagingInfo _paging, string username, int isAprroved, int status)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCate_user", connection);
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

        public DataTable GetOfficialPagingbyUserisDelete(string lang, int group, string strCate, PagingInfo _paging, string username, int isAprroved, int status, int isDelete)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCate_user", connection);
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

        public DataTable GetOfficialPagingbyUserisDelete(string lang, int group, int officialCateID, PagingInfo _paging, string username, int isAprroved, int status, int isDelete)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetPagingbyCateID_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@CateOfficialID", officialCateID);
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

        #region OfficialFollow

        public DataTable OfficialFollow(int Id, int cId, int n, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID AND Id < @OfficialID ORDER BY DatePublic DESC";

                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@CateOfficialID", cId);
                command.Parameters.AddWithValue("@OfficialID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable OfficialFollow(int Id, int cId, int n, string approval, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT Top " + Convert.ToString(n) + " * FROM tblOfficial WHERE [isDelete]=0 and [Language]=@Language AND CateOfficialID = @CateOfficialID AND OfficialID < @OfficialID AND status=1 AND IsApproval = @IsApproval ORDER BY DatePublic DESC";

                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Language", _lang);
                command.Parameters.AddWithValue("@CateOfficialID", cId);
                command.Parameters.AddWithValue("@OfficialID", Id);
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
        #endregion
    }
}
