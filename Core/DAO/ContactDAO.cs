using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace DAO
{
    public class ContactDAO : BaseDAO
    {
        public ContactDAO()
        {
            //constructor
        }

        #region ContactReader
        private Contact ContactReader(SqlDataReader reader)
        {
            Contact contact = new Contact();
            contact.ContactID = (int)reader["ContactID"];
            contact.Name = (string)reader["Name"];
            contact.Address = (string)reader["Address"];
            contact.Tel = (string)reader["Tel"];
            contact.Fax = (string)reader["Fax"];
            contact.Email = (string)reader["Email"];
            contact.City = (string)reader["City"];
            contact.Date = (DateTime)reader["Date"];
            contact.Require = (string)reader["Require"];
            contact.Attact = (string)reader["Attact"];

            return contact;
        }
        #endregion

        #region GetContactAll
        public DataTable GetContactAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactGetAll", connection);
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


        #region GetContactById
        public Contact GetContactById(int contactID)
        {
            Contact contact = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ContactID", contactID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        contact = ContactReader(reader);
                    else
                        throw new DataAccessException("khong ton tai contact");
                }
                command.Dispose();

            }
            return contact;
        }
        #endregion

        #region CreateContact
        public void CreateContact(Contact contact)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ContactID", 0);

                command.Parameters.AddWithValue("@Date", contact.Date);

                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Company", contact.Company);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Tel", contact.Tel);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@Fax", contact.Fax);
                command.Parameters.AddWithValue("@Require", contact.Require);
                command.Parameters.AddWithValue("@Attact", contact.Attact);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateContact
        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ContactID", contact.ContactID);
                command.Parameters.AddWithValue("@Date", contact.Date);

                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Company", contact.Company);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Tel", contact.Tel);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@Fax", contact.Fax);
                command.Parameters.AddWithValue("@Require", contact.Require);
                command.Parameters.AddWithValue("@Attact", contact.Attact);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
            }
        }
        #endregion

        //#region UpdateContact
        //public void UpdateContact(string strId, string value)
        //{
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string SQL = "update tblContact set Actived =" + value + " where ContactID in('" + strId + "')";
        //        SqlCommand command = new SqlCommand(SQL, connection);
        //        command.CommandText = SQL;
        //        connection.Open();
        //        if (command.ExecuteNonQuery() <= 0)
        //            throw new DataAccessException("khong the cap nhat");
        //        else
        //            command.Dispose();
        //    }
        //}
        //#endregion



        #region DeleteContact
        public void DeleteContact(int contactID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ContactID", contactID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa contact");
                else
                    command.Dispose();
            }
        }
        #endregion




    }
}
