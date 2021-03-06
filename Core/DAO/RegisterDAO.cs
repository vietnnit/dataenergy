using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class RegisterDAO : BaseDAO
    {
        public RegisterDAO() 
        {
            //constructor
        }

        #region RegisterReader
        private Register RegisterReader(SqlDataReader reader)
        {
            Register _register = new Register();
            _register.RegisterID = (int)reader["RegisterID"];
            _register.FullName = (string)reader["FullName"];
            _register.FullName2 = (string)reader["FullName2"];
            _register.Email = (string)reader["Email"];
            _register.Phone1 = (string)reader["Phone1"];
            _register.Phone2 = (string)reader["Phone2"];
            _register.Phone3 = (string)reader["Phone3"];
            _register.Address1 = (string)reader["Address1"];
            _register.Address2 = (string)reader["Address2"];
            _register.Birth = (DateTime)reader["Birth"];
            _register.Actived = (bool)reader["Actived"];
            _register.Sex = (bool)reader["Sex"];
            _register.NickYahoo = (string)reader["NickYahoo"];
            _register.NickSkype = (string)reader["NickSkype"];
            _register.TN_Mon1 = (string)reader["TN_Mon1"];
            _register.TN_Mon2 = (string)reader["TN_Mon2"];
            _register.TN_Mon3 = (string)reader["TN_Mon3"];
            _register.TN_Mon4 = (string)reader["TN_Mon4"];
            _register.TN_Mon5 = (string)reader["TN_Mon5"];
            _register.TN_Nam = (string)reader["TN_Nam"];
            _register.TN_Truong = (string)reader["TN_Truong"];
            _register.DT_Khoi = (string)reader["DT_Khoi"];
            _register.DT_Mon1 = (string)reader["DT_Mon1"];
            _register.DT_Mon2 = (string)reader["DT_Mon2"];
            _register.DT_Mon3 = (string)reader["DT_Mon3"];
            _register.DT_SBD = (string)reader["DT_SBD"];
            _register.DT_Truong = (string)reader["DT_Truong"];
            _register.NV_He = (string)reader["NV_He"];
            _register.NV_Nganh = (string)reader["NV_Nganh"];
            _register.NV_Truong = (string)reader["NV_Truong"];
            _register.CreatedDate = (DateTime)reader["CreatedDate"];
           
            return _register;
        }
        #endregion

        #region GetAllRegister
        public DataTable GetAllRegister()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RegisterGetAll", connection);
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

        #region GetRegisterById
        public Register GetRegisterById(int _registerID)
        {
            Register _register = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RegisterGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegisterID", _registerID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _register = RegisterReader(reader);
                    else
                        throw new DataAccessException("Không tồn tại hồ sơ đăng ký");
                }
                command.Dispose();

            }
            return _register;
        }
        #endregion

        #region CreateRegister
        public void CreateRegister(Register _register)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RegisterUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@RegisterID", 0);
                command.Parameters.AddWithValue("@FullName", _register.FullName);
                command.Parameters.AddWithValue("@FullName2", _register.FullName2);
                command.Parameters.AddWithValue("@Email", _register.Email);
                command.Parameters.AddWithValue("@Phone1", _register.Phone1);
                command.Parameters.AddWithValue("@Phone2", _register.Phone2);
                command.Parameters.AddWithValue("@Phone3", _register.Phone3);
                command.Parameters.AddWithValue("@Address1", _register.Address1);
                command.Parameters.AddWithValue("@Address2", _register.Address2);
                command.Parameters.AddWithValue("@Birth", _register.Birth);
                command.Parameters.AddWithValue("@Actived", _register.Actived);
                command.Parameters.AddWithValue("@Sex", _register.Sex);
                command.Parameters.AddWithValue("@NickYahoo", _register.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", _register.NickSkype);
                command.Parameters.AddWithValue("@TN_Mon1", _register.TN_Mon1);
                command.Parameters.AddWithValue("@TN_Mon2", _register.TN_Mon2);
                command.Parameters.AddWithValue("@TN_Mon3", _register.TN_Mon3);
                command.Parameters.AddWithValue("@TN_Mon4", _register.TN_Mon4);
                command.Parameters.AddWithValue("@TN_Mon5", _register.TN_Mon5);
                command.Parameters.AddWithValue("@TN_Nam", _register.TN_Nam);
                command.Parameters.AddWithValue("@TN_Truong", _register.TN_Truong);
                command.Parameters.AddWithValue("@DT_Khoi", _register.DT_Khoi);
                command.Parameters.AddWithValue("@DT_Mon1", _register.DT_Mon1);
                command.Parameters.AddWithValue("@DT_Mon2", _register.DT_Mon2);
                command.Parameters.AddWithValue("@DT_Mon3", _register.DT_Mon3);
                command.Parameters.AddWithValue("@DT_Nganh", _register.DT_Nganh);
                command.Parameters.AddWithValue("@DT_SBD", _register.DT_SBD);
                command.Parameters.AddWithValue("@DT_Truong", _register.DT_Truong);
                command.Parameters.AddWithValue("@NV_He", _register.NV_He);
                command.Parameters.AddWithValue("@NV_Nganh", _register.NV_Nganh);
                command.Parameters.AddWithValue("@NV_Truong", _register.NV_Truong);
                command.Parameters.AddWithValue("@CreatedDate", _register.CreatedDate);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateRegister
        public void UpdateRegister(Register _register)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RegisterUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@RegisterID", _register.RegisterID);
                command.Parameters.AddWithValue("@FullName", _register.FullName);
                command.Parameters.AddWithValue("@FullName2", _register.FullName2);
                command.Parameters.AddWithValue("@Email", _register.Email);
                command.Parameters.AddWithValue("@Phone1", _register.Phone1);
                command.Parameters.AddWithValue("@Phone2", _register.Phone2);
                command.Parameters.AddWithValue("@Phone3", _register.Phone3);
                command.Parameters.AddWithValue("@Address1", _register.Address1);
                command.Parameters.AddWithValue("@Address2", _register.Address2);
                command.Parameters.AddWithValue("@Birth", _register.Birth);
                command.Parameters.AddWithValue("@Actived", _register.Actived);
                command.Parameters.AddWithValue("@Sex", _register.Sex);
                command.Parameters.AddWithValue("@NickYahoo", _register.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", _register.NickSkype);
                command.Parameters.AddWithValue("@TN_Mon1", _register.TN_Mon1);
                command.Parameters.AddWithValue("@TN_Mon2", _register.TN_Mon2);
                command.Parameters.AddWithValue("@TN_Mon3", _register.TN_Mon3);
                command.Parameters.AddWithValue("@TN_Mon4", _register.TN_Mon4);
                command.Parameters.AddWithValue("@TN_Mon5", _register.TN_Mon5);
                command.Parameters.AddWithValue("@TN_Nam", _register.TN_Nam);
                command.Parameters.AddWithValue("@TN_Truong", _register.TN_Truong);
                command.Parameters.AddWithValue("@DT_Khoi", _register.DT_Khoi);
                command.Parameters.AddWithValue("@DT_Mon1", _register.DT_Mon1);
                command.Parameters.AddWithValue("@DT_Mon2", _register.DT_Mon2);
                command.Parameters.AddWithValue("@DT_Mon3", _register.DT_Mon3);
                command.Parameters.AddWithValue("@DT_Nganh", _register.DT_Nganh);
                command.Parameters.AddWithValue("@DT_SBD", _register.DT_SBD);
                command.Parameters.AddWithValue("@DT_Truong", _register.DT_Truong);
                command.Parameters.AddWithValue("@NV_He", _register.NV_He);
                command.Parameters.AddWithValue("@NV_Nganh", _register.NV_Nganh);
                command.Parameters.AddWithValue("@NV_Truong", _register.NV_Truong);
                command.Parameters.AddWithValue("@CreatedDate", _register.CreatedDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteRegister
        public void DeleteRegister(int _registerID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_RegisterDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegisterID", _registerID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa _register");
                else
                    command.Dispose();
            }
        }
        #endregion

       
    }
}
