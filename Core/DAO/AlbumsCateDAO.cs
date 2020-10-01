using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class AlbumsCateDAO:BaseDAO
    {
        public AlbumsCateDAO() 
        {
            //constructor
        }

        #region AlbumsCateReader
        private AlbumsCate AlbumsCateReader(SqlDataReader reader) 
        {
            AlbumsCate albumscate = new AlbumsCate();
            albumscate.AlbumsCateID = (int)reader["AlbumsCateID"];
            albumscate.ParentCateID = (int)reader["ParentCateID"];
            albumscate.AlbumsCateName = (string)reader["AlbumsCateName"];
            albumscate.AlbumsCateTotal = (int)reader["AlbumsCateTotal"];
            albumscate.AlbumsCateOrder = (int)reader["AlbumsCateOrder"];
            albumscate.ImageThumb = (string)reader["ImageThumb"];
            albumscate.ImageLarge = (string)reader["ImageLarge"];
            albumscate.Description = (string)reader["Description"];
            albumscate.UserName = (string)reader["UserName"];
            albumscate.Created = (DateTime)reader["Created"];
            albumscate.Language = (string)reader["Language"];
            return albumscate;
        }
        #endregion

        #region CreateAlbumsCate
        public void CreateAlbumsCate(AlbumsCate albumscate) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
                command.Parameters.AddWithValue("@ParentCateID",albumscate.ParentCateID);
                command.Parameters.AddWithValue("@AlbumsCateName",albumscate.AlbumsCateName);
                command.Parameters.AddWithValue("@AlbumsCateTotal",albumscate.AlbumsCateTotal);
                command.Parameters.AddWithValue("@AlbumsCateOrder",albumscate.AlbumsCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", albumscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albumscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", albumscate.Description);
                command.Parameters.AddWithValue("@UserName", albumscate.UserName);
                command.Parameters.AddWithValue("@Created", albumscate.Created);
                command.Parameters.AddWithValue("@Language", albumscate.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể tạo danh mục tin");
                else
                    command.Dispose();
            }
        }
        public int CreateAlbumsCateGet(AlbumsCate albumscate)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
                command.Parameters.AddWithValue("@ParentCateID", albumscate.ParentCateID);
                command.Parameters.AddWithValue("@AlbumsCateName", albumscate.AlbumsCateName);
                command.Parameters.AddWithValue("@AlbumsCateTotal", albumscate.AlbumsCateTotal);
                command.Parameters.AddWithValue("@AlbumsCateOrder", albumscate.AlbumsCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", albumscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albumscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", albumscate.Description);
                command.Parameters.AddWithValue("@UserName", albumscate.UserName);
                command.Parameters.AddWithValue("@Created", albumscate.Created);
                command.Parameters.AddWithValue("@Language", albumscate.Language);

                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong them duoc san pham");
                else
                {
                    i = (int)parameter.Value;
                    command.Dispose();
                }
            }
            return i;
        }
        #endregion

        #region UpdateAlbumsCate
        public void UpdateAlbumsCate(AlbumsCate albumscate)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AlbumsCateID",albumscate.AlbumsCateID);
                command.Parameters.AddWithValue("@ParentCateID", albumscate.ParentCateID);
                command.Parameters.AddWithValue("@AlbumsCateName", albumscate.AlbumsCateName);
                command.Parameters.AddWithValue("@AlbumsCateTotal", albumscate.AlbumsCateTotal);
                command.Parameters.AddWithValue("@AlbumsCateOrder", albumscate.AlbumsCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", albumscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albumscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", albumscate.Description);
                command.Parameters.AddWithValue("@UserName", albumscate.UserName);
                command.Parameters.AddWithValue("@Created", albumscate.Created);
                command.Parameters.AddWithValue("@Language", albumscate.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteAlbumsCate
        public void DeleteAlbumsCate(int cId) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID",cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa danh mục tin");
                else
                    command.Dispose();
            }
            
        }
        #endregion
   

        #region AlbumsCateUpOrder
        public void AlbumsCateUpOrder(int cId , int cOrder) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", cId);
                command.Parameters.AddWithValue("@AlbumsCateOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetAlbumsCateParent
        public DataTable GetAlbumsCateParent(int cateID, string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGetOrderDate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", cateID);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }

            return table;
        }
        public DataTable GetAlbumsCateParentPaging(int cateID, PagingInfo _paging, string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGetOrderDatePaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", cateID);
                command.Parameters.AddWithValue("@CurrentPage", _paging.CurrentPage);
                command.Parameters.AddWithValue("@PageSize", _paging.PageSize);
                command.Parameters.AddWithValue("@Language", _lang);
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

        #region GetAlbumsCate
        public DataTable GetAlbumsCate(string _lang) 
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("AlbumsCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("AlbumsCateName");
            datatable.Columns.Add("AlbumsCateTotal");
            datatable.Columns.Add("AlbumsCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Language");
           

            DataTable table = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID",0);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["AlbumsCateID"] = row["AlbumsCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["AlbumsCateName"] = row["AlbumsCateName"].ToString();
                    datarow["AlbumsCateTotal"] = row["AlbumsCateTotal"].ToString();
                    datarow["AlbumsCateOrder"] = row["AlbumsCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                   
                    datatable.Rows.Add(datarow);
                    this.GetParentCate(datatable, Convert.ToInt32(datarow["AlbumsCateID"]), 1, "&nbsp;&nbsp;", _lang);
                }
            
            }
            return datatable;
        }

        private void GetParentCate(DataTable table, int cID, int level, string sSpace, string _lang)
        {

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", cID);
                command.Parameters.AddWithValue("@Language", _lang);
                
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["AlbumsCateID"] = subrow["AlbumsCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["AlbumsCateName"] = sStr + subrow["AlbumsCateName"].ToString();
                        rs["AlbumsCateTotal"] = subrow["AlbumsCateTotal"].ToString();
                        rs["AlbumsCateOrder"] = subrow["AlbumsCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentCate(table, Convert.ToInt32(rs["AlbumsCateID"]), level + 1, "&nbsp;&nbsp;", _lang);
                    }
                }
            }
        }
        #endregion

        
        #region GetAlbumsCateById
        public AlbumsCate GetAlbumsCateById(int cId) 
        {
            AlbumsCate albumscate = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID",cId);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        albumscate = AlbumsCateReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy danh mục");
                    command.Dispose();
                }
            }
            return albumscate;
        }
        #endregion

        #region GetAlbumsCateBullet
        public DataTable GetCateGroupBullet(string bullet, string _lang)
        {
            string str = HttpUtility.HtmlDecode("<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace = str;
            string sSpace1 = HttpUtility.HtmlDecode("</b>");


            DataTable datatable = new DataTable();
            datatable.Columns.Add("AlbumsCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("AlbumsCateName");
            datatable.Columns.Add("AlbumsCateTotal");
            datatable.Columns.Add("AlbumsCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Language");

            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["AlbumsCateID"] = row["AlbumsCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["AlbumsCateName"] = sSpace+ row["AlbumsCateName"].ToString() +sSpace1;
                    datarow["AlbumsCateTotal"] = row["AlbumsCateTotal"].ToString();
                    datarow["AlbumsCateOrder"] = row["AlbumsCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Language"] = row["Language"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupBullet(datatable, Convert.ToInt32(datarow["AlbumsCateID"]), 1, "&nbsp;&nbsp;&nbsp;", bullet, _lang);
                }

            }
            return datatable;
        }

        private void GetParentGroupBullet(DataTable table, int cID, int level, string sSpace, string bullet, string _lang)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;");
         //   sSpace = sSpace + str;

            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr += sSpace;
                }
            }
            sStr += str;
            DataTable subtable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AlbumsCateID", cID);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["AlbumsCateID"] = subrow["AlbumsCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["AlbumsCateName"] = sStr + subrow["AlbumsCateName"].ToString();
                        rs["AlbumsCateTotal"] = subrow["AlbumsCateTotal"].ToString();
                        rs["AlbumsCateOrder"] = subrow["AlbumsCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Language"] = subrow["Language"].ToString();

                        table.Rows.Add(rs);
                        this.GetParentGroupBullet(table, Convert.ToInt32(rs["AlbumsCateID"]),level + 1, "&nbsp;&nbsp;&nbsp;", bullet, _lang);
                    }
                }
            }
        }
        #endregion


     

        
    }
}
