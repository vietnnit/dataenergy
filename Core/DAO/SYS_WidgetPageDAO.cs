using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class SYS_WidgetPageDAO : BaseDAO
    {
        public SYS_WidgetPageDAO() 
        {
            //constructor
        }

        #region SYS_WidgetPageReader
        private SYS_WidgetPage SYS_WidgetPageReader(SqlDataReader reader) 
        {
            SYS_WidgetPage sys_WidgetPage = new SYS_WidgetPage();
            sys_WidgetPage.Id = (int)reader["Id"];
            sys_WidgetPage.PageLayoutId = (int)reader["PageLayoutId"];
            sys_WidgetPage.RegionId = (string)reader["RegionId"];
            sys_WidgetPage.WidgetControl = (string)reader["WidgetControl"];
            sys_WidgetPage.WidgetDir = (string)reader["WidgetDir"];
            sys_WidgetPage.WidgetHTML = (string)reader["WidgetHTML"];
            sys_WidgetPage.WidgetIcon = (string)reader["WidgetIcon"];
            sys_WidgetPage.WidgetInfo = (string)reader["WidgetInfo"];
            sys_WidgetPage.WidgetName = (string)reader["WidgetName"];
            sys_WidgetPage.WidgetOrder = (int)reader["WidgetOrder"];
            sys_WidgetPage.WidgetRecord = (int)reader["WidgetRecord"];
            sys_WidgetPage.WidgetRecord2 = (int)reader["WidgetRecord2"];
            sys_WidgetPage.WidgetStatus = (bool)reader["WidgetStatus"];
            sys_WidgetPage.WidgetTitle = (string)reader["WidgetTitle"];
            sys_WidgetPage.WidgetValue = (string)reader["WidgetValue"];
            sys_WidgetPage.WidgetValue2 = (string)reader["WidgetValue2"];
            sys_WidgetPage.Language = (string)reader["Language"];


            return sys_WidgetPage;
        }
        #endregion

        #region CreateSYS_WidgetPage
        public int CreateSYS_WidgetPageGet(SYS_WidgetPage sys_WidgetPage)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@PageLayoutId", sys_WidgetPage.PageLayoutId);
                command.Parameters.AddWithValue("@RegionId", sys_WidgetPage.RegionId);
                command.Parameters.AddWithValue("@WidgetControl", sys_WidgetPage.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_WidgetPage.WidgetDir);
                command.Parameters.AddWithValue("@WidgetHTML", sys_WidgetPage.WidgetHTML);
                command.Parameters.AddWithValue("@WidgetIcon", sys_WidgetPage.WidgetIcon);
                command.Parameters.AddWithValue("@WidgetInfo", sys_WidgetPage.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetName", sys_WidgetPage.WidgetName);
                command.Parameters.AddWithValue("@WidgetOrder", sys_WidgetPage.WidgetOrder);
                command.Parameters.AddWithValue("@WidgetRecord", sys_WidgetPage.WidgetRecord);
                command.Parameters.AddWithValue("@WidgetRecord2", sys_WidgetPage.WidgetRecord2);
                command.Parameters.AddWithValue("@WidgetStatus", sys_WidgetPage.WidgetStatus);
                command.Parameters.AddWithValue("@WidgetTitle", sys_WidgetPage.WidgetTitle);
                command.Parameters.AddWithValue("@WidgetValue", sys_WidgetPage.WidgetValue);
                command.Parameters.AddWithValue("@WidgetValue2", sys_WidgetPage.WidgetValue2);
                command.Parameters.AddWithValue("@Language", sys_WidgetPage.Language);
               
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

        #region UpdateSYS_WidgetPage
        public void UpdateSYS_WidgetPage(SYS_WidgetPage sys_WidgetPage)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID",sys_WidgetPage.Id);
                command.Parameters.AddWithValue("@PageLayoutId", sys_WidgetPage.PageLayoutId);
                command.Parameters.AddWithValue("@RegionId", sys_WidgetPage.RegionId);
                command.Parameters.AddWithValue("@WidgetControl", sys_WidgetPage.WidgetControl);
                command.Parameters.AddWithValue("@WidgetDir", sys_WidgetPage.WidgetDir);
                command.Parameters.AddWithValue("@WidgetHTML", sys_WidgetPage.WidgetHTML);
                command.Parameters.AddWithValue("@WidgetIcon", sys_WidgetPage.WidgetIcon);
                command.Parameters.AddWithValue("@WidgetInfo", sys_WidgetPage.WidgetInfo);
                command.Parameters.AddWithValue("@WidgetName", sys_WidgetPage.WidgetName);
                command.Parameters.AddWithValue("@WidgetOrder", sys_WidgetPage.WidgetOrder);
                command.Parameters.AddWithValue("@WidgetRecord", sys_WidgetPage.WidgetRecord);
                command.Parameters.AddWithValue("@WidgetRecord2", sys_WidgetPage.WidgetRecord2);
                command.Parameters.AddWithValue("@WidgetStatus", sys_WidgetPage.WidgetStatus);
                command.Parameters.AddWithValue("@WidgetTitle", sys_WidgetPage.WidgetTitle);
                command.Parameters.AddWithValue("@WidgetValue", sys_WidgetPage.WidgetValue);
                command.Parameters.AddWithValue("@WidgetValue2", sys_WidgetPage.WidgetValue2);
                command.Parameters.AddWithValue("@Language", sys_WidgetPage.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong cap nhat duoc sys_WidgetPage");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteSYS_WidgetPage
        public void DeleteSYS_WidgetPage(int Id) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong xoa duoc sys_WidgetPage");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetSYS_WidgetPageById
        public SYS_WidgetPage GetSYS_WidgetPageById(int Id) 
        {
            SYS_WidgetPage sys_WidgetPage = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        sys_WidgetPage = SYS_WidgetPageReader(reader);
                    else
                        throw new DataAccessException("Khong tim thay gia tri sys_WidgetPage");
                    command.Dispose();
                }
            }
            return sys_WidgetPage;
        }
        #endregion

        #region GetSYS_WidgetPageByRegionId
        public DataTable GetSYS_WidgetPageByRegionId(string regionId, int pageLayoutId, bool status,string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetByRegionId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegionId", regionId);
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@WidgetStatus", status);
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
        public DataTable GetSYS_WidgetPageByPageLayoutId(int pageLayoutId, bool status,string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetByRegionId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@WidgetStatus", status);
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

        #region GetSYS_WidgetPageByAllRegionId
        public DataTable GetSYS_WidgetPageByAllRegionId(string regionId, int pageLayoutId, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetByAllRegionId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegionId", regionId);
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

        #region GetSYS_WidgetPageAll
        public DataTable GetSYS_WidgetPageAll(string _lang) 
        {
            DataTable datatable = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetAll",connection);
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

        public DataTable GetSYS_WidgetPageFullAll(string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetFullAll", connection);
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

        public DataTable GetSYS_WidgetPageFullAll(int pageLayoutId, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetFullbyPageID", connection);
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
        public DataTable GetSYS_WidgetPageFullAll(int pageLayoutId, string regionID, string _lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageGetFullbyPageIDRegionID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageLayoutId", pageLayoutId);
                command.Parameters.AddWithValue("@RegionId", regionID);
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

        #region SYS_WidgetPageUpOrder
        public void SYS_WidgetPageUpOrder(int Id, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_SYS_WidgetPageUpOrder", connection);
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
    }
}
