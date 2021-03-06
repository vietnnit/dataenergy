using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_PageLayoutDAO : BaseDAO
    {
        public SYS_PageLayoutDAO() 
        {
            //constructor
        }

        #region SYS_PageLayoutReader
        private SYS_PageLayout SYS_PageLayoutReader(SqlDataReader reader) 
        {
            SYS_PageLayout sys_PageLayout = new SYS_PageLayout();
            sys_PageLayout.Id = (int)reader["Id"];
            sys_PageLayout.PageName = (string)reader["PageName"];
            sys_PageLayout.SlugPageName = (string)reader["SlugPageName"];
            sys_PageLayout.TemplateId = (int)reader["TemplateId"];
            sys_PageLayout.Orders = (int)reader["Orders"];
            sys_PageLayout.Language = (string)reader["Language"];
            return sys_PageLayout;
        }
        #endregion

        #region CreateSYS_PageLayout
        public int CreateSYS_PageLayoutGet(SYS_PageLayout sys_PageLayout)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@PageName", sys_PageLayout.PageName);
                command.Parameters.AddWithValue("@SlugPageName", sys_PageLayout.SlugPageName);
                command.Parameters.AddWithValue("@TemplateId", sys_PageLayout.TemplateId);
                command.Parameters.AddWithValue("@Orders", sys_PageLayout.Orders);
                command.Parameters.AddWithValue("@Language", sys_PageLayout.Language);
               
                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateSYS_PageLayout
        public void UpdateSYS_PageLayout(SYS_PageLayout sys_PageLayout)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID",sys_PageLayout.Id);
                command.Parameters.AddWithValue("@PageName", sys_PageLayout.PageName);
                command.Parameters.AddWithValue("@SlugPageName", sys_PageLayout.SlugPageName);
                command.Parameters.AddWithValue("@TemplateId", sys_PageLayout.TemplateId);
                command.Parameters.AddWithValue("@Orders", sys_PageLayout.Orders);
                command.Parameters.AddWithValue("@Language", sys_PageLayout.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_PageLayout");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_PageLayout
        public void DeleteSYS_PageLayout(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_PageLayout");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_PageLayoutById
        public SYS_PageLayout GetSYS_PageLayoutById(int Id) 
        {
            SYS_PageLayout sys_PageLayout = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_PageLayout = SYS_PageLayoutReader(reader);
                    //else
                    //    throw new DataAccessException("Khong tim thay gia tri sys_PageLayout");
                    command.Dispose();
                }
            }
            return sys_PageLayout;
        }

        public SYS_PageLayout GetSYS_PageLayoutBySlug(string slug, string _lang)
        {
            SYS_PageLayout sys_PageLayout = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetBySlug", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Slug", String.IsNullOrEmpty(slug)?"":slug);
                command.Parameters.AddWithValue("@Language", string.IsNullOrEmpty(_lang) ? "" : _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_PageLayout = SYS_PageLayoutReader(reader);
                    //else
                    //    throw new DataAccessException("Khong tim thay gia tri sys_PageLayout");
                    command.Dispose();
                }
            }
            return sys_PageLayout;
        }
        #endregion

        #region GetSYS_PageLayoutByTemplateId
        public SYS_PageLayout GetSYS_PageLayoutByTemplateId(int templateId, string _lang)
        {
            SYS_PageLayout sys_PageLayout = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetByTemplateId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TemplateId", templateId);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_PageLayout = SYS_PageLayoutReader(reader);
                    //else
                    //    throw new DataAccessException("Khong tim thay gia tri sys_PageLayout");
                    command.Dispose();
                }
            }
            return sys_PageLayout;
        }
        #endregion

        #region GetSYS_PageLayoutAll
        public DataTable GetSYS_PageLayoutAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetAll",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable GetSYS_PageLayoutAllTemplate(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetAllTemplate", connection);
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

        public SYS_PageLayout GetSYS_PageLayoutAllTemplatebyID(int Id, string _lang)
        {
            SYS_PageLayout sys_PageLayout = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutGetAllTemplatebyID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_PageLayout = SYS_PageLayoutReader(reader);
                    //else
                    //    throw new DataAccessException("Khong tim thay gia tri sys_PageLayout");
                    command.Dispose();
                }
            }
            return sys_PageLayout;
           
        }

        #endregion

        #region SYS_PageLayoutUpOrder
        public void SYS_PageLayoutUpOrder(int Id, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_PageLayoutUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Orders", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật");
                else
                    command.Dispose();
            }
        }
        #endregion
    }
}
