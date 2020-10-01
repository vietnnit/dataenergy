using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class EmailDAO : BaseDAO
    {
        public EmailDAO() 
        {
            //constructor
        }

        #region EmailReader
        private Email EmailReader(SqlDataReader reader) 
        {
            Email email = new Email();
            email.EmailID = (int)reader["EmailID"];
            email.EmailAddress = (string) reader["EmailAddress"];
            email.Name = (string)reader["Name"];
          
            return email;
        }
        #endregion

        #region CreateEmail
        public void CreateEmail(Email email) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@EmailID",0);
                command.Parameters.AddWithValue("@EmailAddress",email.EmailAddress);
                command.Parameters.AddWithValue("@Name",email.Name);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong them moi duoc email");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateEmail
        public void UpdateEmail(Email email)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@EmailID",email.EmailID);
                command.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                command.Parameters.AddWithValue("@Name", email.Name);
             
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc email");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteEmail
        public void DeleteEmail(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmailID",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc email");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetEmailById
        public Email GetEmailById(int Id) 
        {
            Email email = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmailID",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        email = EmailReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri email");
                    command.Dispose();
                }
            }
            return email;
        }
        #endregion

        #region GetEmailAll
        public DataTable GetEmailAll() 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailGetAll",connection);
                command.CommandType = CommandType.StoredProcedure;
 
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
    }
}
