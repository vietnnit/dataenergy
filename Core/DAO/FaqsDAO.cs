using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class FaqsDAO : BaseDAO
    {
        public FaqsDAO()
        {
            //constructor
        }

        #region FaqsReader
        private Faqs FaqsReader(SqlDataReader reader)
        {
            Faqs _faqs = new Faqs();
            _faqs.FaqsID = (int)reader["FaqsID"];
            _faqs.FaqsCateID = (int)reader["FaqsCateID"];
            _faqs.ParentFaqsID = (int)reader["ParentFaqsID"];
            _faqs.FullName = (string)reader["FullName"];
            _faqs.Title = (string)reader["Title"];
            _faqs.Contents = (string)reader["Contents"];
            _faqs.Email = (string)reader["Email"];
            _faqs.Department = (string)reader["Department"];
            _faqs.Phone = (string)reader["Phone"];
            _faqs.Fax = (string)reader["Fax"];
            _faqs.Address = (string)reader["Address"];
            _faqs.Actived = (bool)reader["Actived"];
            _faqs.NickYahoo = (string)reader["NickYahoo"];
            _faqs.NickSkype = (string)reader["NickSkype"];
            _faqs.Orders = (int)reader["Orders"];
            _faqs.PostDate = (DateTime)reader["PostDate"];
            _faqs.UserName = (string)reader["UserName"];
            _faqs.ApprovedDate = (DateTime)reader["ApprovedDate"];
            return _faqs;
        }
        #endregion

        #region GetAllFaqs
        public DataTable GetAllFaqs()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetAll", connection);
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

        #region GetFaqsById
        public Faqs GetFaqsById(int Id)
        {
            Faqs _faqs = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _faqs = FaqsReader(reader);
                    else
                        throw new DataAccessException("khong ton tai _faqs");
                }
                command.Dispose();

            }
            return _faqs;
        }
        #endregion

        #region GetFaqsByFaqsCateID
        public DataTable GetFaqsByFaqsCateID(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetByFaqsCateId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }


        public DataTable GetFaqsByFaqsCateID(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                //SqlCommand command = new SqlCommand("_FaqsGetByFaqsCateId", connection);
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@FaqsCateID", Id);

                string SQL = "select * from tblFaqs where FaqsCateID in('" + strCate + "') order by PostDate Desc";
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

        #endregion



        #region CreateFaqs
        public void CreateFaqs(Faqs _faqs)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@FaqsID", 0);
                command.Parameters.AddWithValue("@FaqsCateID", _faqs.FaqsCateID);
                command.Parameters.AddWithValue("@ParentFaqsID", _faqs.ParentFaqsID);
                command.Parameters.AddWithValue("@FullName", _faqs.FullName);
                command.Parameters.AddWithValue("@Title", _faqs.Title);
                command.Parameters.AddWithValue("@Contents", _faqs.Contents);
                command.Parameters.AddWithValue("@Email", _faqs.Email);
                command.Parameters.AddWithValue("@Department", _faqs.Department);
                command.Parameters.AddWithValue("@Phone", _faqs.Phone);
                command.Parameters.AddWithValue("@Fax", _faqs.Fax);
                command.Parameters.AddWithValue("@Address", _faqs.Address);
                command.Parameters.AddWithValue("@Actived", _faqs.Actived);
                command.Parameters.AddWithValue("@NickYahoo", _faqs.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", _faqs.NickSkype);
                command.Parameters.AddWithValue("@Orders", _faqs.Orders);
                command.Parameters.AddWithValue("@PostDate", _faqs.PostDate);
                command.Parameters.AddWithValue("@UserName", _faqs.UserName);
                command.Parameters.AddWithValue("@ApprovedDate", _faqs.ApprovedDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public int CreateFaqsGet(Faqs _faqs)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@FaqsID", 0);
                command.Parameters.AddWithValue("@FaqsCateID", _faqs.FaqsCateID);
                command.Parameters.AddWithValue("@ParentFaqsID", _faqs.ParentFaqsID);
                command.Parameters.AddWithValue("@FullName", _faqs.FullName);
                command.Parameters.AddWithValue("@Title", _faqs.Title);
                command.Parameters.AddWithValue("@Contents", _faqs.Contents);
                command.Parameters.AddWithValue("@Email", _faqs.Email);
                command.Parameters.AddWithValue("@Department", _faqs.Department);
                command.Parameters.AddWithValue("@Phone", _faqs.Phone);
                command.Parameters.AddWithValue("@Fax", _faqs.Fax);
                command.Parameters.AddWithValue("@Address", _faqs.Address);
                command.Parameters.AddWithValue("@Actived", _faqs.Actived);
                command.Parameters.AddWithValue("@NickYahoo", _faqs.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", _faqs.NickSkype);
                command.Parameters.AddWithValue("@Orders", _faqs.Orders);
                command.Parameters.AddWithValue("@PostDate", _faqs.PostDate);
                command.Parameters.AddWithValue("@UserName", _faqs.UserName);
                command.Parameters.AddWithValue("@ApprovedDate", _faqs.ApprovedDate);

                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc");
                else
                    i = (int)parameter.Value;
                command.Dispose();
            }
            return i;
        }
        #endregion

        #region UpdateFaqs
        public void UpdateFaqs(Faqs _faqs)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@FaqsID", _faqs.FaqsID);
                command.Parameters.AddWithValue("@FaqsCateID", _faqs.FaqsCateID);
                command.Parameters.AddWithValue("@ParentFaqsID", _faqs.ParentFaqsID);
                command.Parameters.AddWithValue("@FullName", _faqs.FullName);
                command.Parameters.AddWithValue("@Title", _faqs.Title);
                command.Parameters.AddWithValue("@Contents", _faqs.Contents);
                command.Parameters.AddWithValue("@Email", _faqs.Email);
                command.Parameters.AddWithValue("@Department", _faqs.Department);
                command.Parameters.AddWithValue("@Phone", _faqs.Phone);
                command.Parameters.AddWithValue("@Fax", _faqs.Fax);
                command.Parameters.AddWithValue("@Address", _faqs.Address);
                command.Parameters.AddWithValue("@Actived", _faqs.Actived);
                command.Parameters.AddWithValue("@NickYahoo", _faqs.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", _faqs.NickSkype);
                command.Parameters.AddWithValue("@Orders", _faqs.Orders);
                command.Parameters.AddWithValue("@PostDate", _faqs.PostDate);
                command.Parameters.AddWithValue("@UserName", _faqs.UserName);
                command.Parameters.AddWithValue("@ApprovedDate", _faqs.ApprovedDate); 
                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteFaqs
        public void DeleteFaqs(int Id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa _faqs");
                else
                    command.Dispose();
            }
        }

        public void DeleteFaqs(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete tblFaqs where FaqsID in('" + sId + "')";
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

        #region UpdateFaqsApproval
        public void UpdateFaqsApproval(string strId, string actived, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblFaqs set Actived = @Actived, UserName = @UserName,ApprovedDate = @Date  where FaqsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Actived", actived);
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }

        public void UpdateFaqsApproval(int Id, string actived, string username, DateTime date)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblFaqs set Actived = @Actived, UserName = @UserName,ApprovedDate = @Date  where FaqsID = @FaqsCateID";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Actived", actived);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@FaqsCateID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không cập nhật được tin nào");
                else
                    command.Dispose();
            }
        }
        #endregion


        #region GetFaqsGetFaqsCateName

        public DataTable GetFaqsGetFaqsCateName(string username)
        {
            //   DataTable datatable = new DataTable();


            DataTable table = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetFaqsCateName", connection);
                command.CommandType = CommandType.StoredProcedure;

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


        #region GetFaqsPaging
        public DataTable GetFaqsPaging(int _FaqsCateID, string _strFaqsCateID, string _Title, string _Fullname, string _Phone, int _actived, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", _FaqsCateID);
                command.Parameters.AddWithValue("@strFaqsCate", _strFaqsCateID);
                command.Parameters.AddWithValue("@Title", _Title);
                command.Parameters.AddWithValue("@FullName", _Fullname);
                command.Parameters.AddWithValue("@Phone", _Phone);
                command.Parameters.AddWithValue("@Actived", _actived);
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

        public DataTable GetFaqsParentPaging(int _parentFaqsID, int _FaqsCateID, string _strFaqsCateID, string _Title, string _Fullname, string _Phone, int _actived, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsGetParentPaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsParentID", _parentFaqsID);
                command.Parameters.AddWithValue("@FaqsCateID", _FaqsCateID);
                command.Parameters.AddWithValue("@strFaqsCate", _strFaqsCateID);
                command.Parameters.AddWithValue("@Title", _Title);
                command.Parameters.AddWithValue("@FullName", _Fullname);
                command.Parameters.AddWithValue("@Phone", _Phone);
                command.Parameters.AddWithValue("@Actived", _actived);
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

        public DataTable FaqsSearchPaging(string finter, PagingInfo _paging)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsSearchPaging", connection);
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

    }
}
