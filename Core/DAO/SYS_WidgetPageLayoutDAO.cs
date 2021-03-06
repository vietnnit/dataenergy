using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_WidgetPageLayoutDAO : BaseDAO
    {
        public SYS_WidgetPageLayoutDAO() 
        {
            //constructor
        }

        #region SYS_WidgetPageLayoutReader
        private SYS_WidgetPageLayout SYS_WidgetPageLayoutReader(SqlDataReader reader) 
        {
            SYS_WidgetPageLayout sys_WidgetPageLayout = new SYS_WidgetPageLayout();
            sys_WidgetPageLayout.Id = (int)reader["Id"];
            sys_WidgetPageLayout.PageLayoutId = (int)reader["PageLayoutId"];
            sys_WidgetPageLayout.RegionId = (string)reader["RegionId"];
            sys_WidgetPageLayout.WidgetId = (int)reader["WidgetId"];
            sys_WidgetPageLayout.HTML = (string)reader["HTML"];
            sys_WidgetPageLayout.Icon = (string)reader["Icon"];
            sys_WidgetPageLayout.Info = (string)reader["Info"];
            sys_WidgetPageLayout.Orders = (int)reader["Orders"];
            sys_WidgetPageLayout.Record = (int)reader["Record"];
            sys_WidgetPageLayout.Record2 = (int)reader["Record2"];
            sys_WidgetPageLayout.Status = (bool)reader["Status"];
            sys_WidgetPageLayout.Title = (string)reader["Title"];
            sys_WidgetPageLayout.Value = (string)reader["Value"];
            sys_WidgetPageLayout.Value2 = (string)reader["Value2"];
            sys_WidgetPageLayout.Language = (string)reader["Language"];


            return sys_WidgetPageLayout;
        }
        #endregion

        #region CreateSYS_WidgetPageLayout
        public int CreateSYS_WidgetPageLayoutGet(SYS_WidgetPageLayout sys_WidgetPageLayout)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@PageLayoutId", sys_WidgetPageLayout.PageLayoutId);
                command.Parameters.AddWithValue("@RegionId", sys_WidgetPageLayout.RegionId);
                command.Parameters.AddWithValue("@WidgetId", sys_WidgetPageLayout.WidgetId);
                command.Parameters.AddWithValue("@HTML", sys_WidgetPageLayout.HTML);
                command.Parameters.AddWithValue("@Icon", sys_WidgetPageLayout.Icon);
                command.Parameters.AddWithValue("@Info", sys_WidgetPageLayout.Info);
                command.Parameters.AddWithValue("@Orders", sys_WidgetPageLayout.Orders);
                command.Parameters.AddWithValue("@Record", sys_WidgetPageLayout.Record);
                command.Parameters.AddWithValue("@Record2", sys_WidgetPageLayout.Record2);
                command.Parameters.AddWithValue("@Status", sys_WidgetPageLayout.Status);
                command.Parameters.AddWithValue("@Title", sys_WidgetPageLayout.Title);
                command.Parameters.AddWithValue("@Value", sys_WidgetPageLayout.Value);
                command.Parameters.AddWithValue("@Value2", sys_WidgetPageLayout.Value2);
                command.Parameters.AddWithValue("@Language", sys_WidgetPageLayout.Language);
               
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

        #region UpdateSYS_WidgetPageLayout
        public void UpdateSYS_WidgetPageLayout(SYS_WidgetPageLayout sys_WidgetPageLayout)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID",sys_WidgetPageLayout.Id);
                command.Parameters.AddWithValue("@PageLayoutId", sys_WidgetPageLayout.PageLayoutId);
                command.Parameters.AddWithValue("@RegionId", sys_WidgetPageLayout.RegionId);
                command.Parameters.AddWithValue("@WidgetId", sys_WidgetPageLayout.WidgetId);
                command.Parameters.AddWithValue("@HTML", sys_WidgetPageLayout.HTML);
                command.Parameters.AddWithValue("@Icon", sys_WidgetPageLayout.Icon);
                command.Parameters.AddWithValue("@Info", sys_WidgetPageLayout.Info);
                command.Parameters.AddWithValue("@Orders", sys_WidgetPageLayout.Orders);
                command.Parameters.AddWithValue("@Record", sys_WidgetPageLayout.Record);
                command.Parameters.AddWithValue("@Record2", sys_WidgetPageLayout.Record2);
                command.Parameters.AddWithValue("@Status", sys_WidgetPageLayout.Status);
                command.Parameters.AddWithValue("@Title", sys_WidgetPageLayout.Title);
                command.Parameters.AddWithValue("@Value", sys_WidgetPageLayout.Value);
                command.Parameters.AddWithValue("@Value2", sys_WidgetPageLayout.Value2);
                command.Parameters.AddWithValue("@Language", sys_WidgetPageLayout.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_WidgetPageLayout");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_WidgetPageLayout
        public void DeleteSYS_WidgetPageLayout(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_WidgetPageLayout");
                else
                    command.Dispose();
            }
        }

        public void DeleteSYS_WidgetPageLayout(string sId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "delete SYS_WidgetPageLayout where Id in('" + sId + "')";
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

        #region GetSYS_WidgetPageLayoutById
        public SYS_WidgetPageLayout GetSYS_WidgetPageLayoutById(int Id) 
        {
            SYS_WidgetPageLayout sys_WidgetPageLayout = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_WidgetPageLayout = SYS_WidgetPageLayoutReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri sys_WidgetPageLayout");
                    command.Dispose();
                }
            }
            return sys_WidgetPageLayout;
        }
        #endregion

       

     

        #region GetSYS_WidgetPageLayoutAll
        public DataTable GetSYS_WidgetPageLayoutAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetAll",connection);
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

        public DataTable GetSYS_WidgetPageLayoutFullAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetFullAll", connection);
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

        public DataTable GetSYS_WidgetPageLayoutFullAll(int pageLayoutId, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetFullbyPageID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
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

        #region SYS_WidgetPageLayoutUpOrder
        public void SYS_WidgetPageLayoutUpOrder(int Id, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Order", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_WidgetPageLayoutByRegionId
        public DataTable GetSYS_WidgetPageLayoutByRegionId(string regionId, int pageLayoutId, bool status, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutByRegionId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegionId", regionId);
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@Status", status);
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

        #region GetSYS_WidgetPageLayoutByAllRegionId
        public DataTable GetSYS_WidgetPageLayoutByAllRegionId(string regionId, int pageLayoutId, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutByRegionId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegionId", regionId);
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@Status", -1);
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

        public DataTable GetSYS_WidgetPageLayoutByPageLayoutId(int pageLayoutId, bool status, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetByPageLayoutId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@Status", status);
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

        public DataTable GetSYS_WidgetPageLayoutAllByPageLayoutId(int pageLayoutId, bool status, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageLayoutGetAllByPageLayoutId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@Status", status);
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
    }
}
