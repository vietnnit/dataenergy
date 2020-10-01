using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class VideosCateDAO:BaseDAO
    {
        public VideosCateDAO() 
        {
            //constructor
        }

        #region VideosCateReader
        private VideosCate VideosCateReader(SqlDataReader reader) 
        {
            VideosCate videoscate = new VideosCate();
            videoscate.VideosCateID = (int)reader["VideosCateID"];
            videoscate.ParentCateID = (int)reader["ParentCateID"];
            videoscate.VideosCateName = (string)reader["VideosCateName"];
            videoscate.VideosCateTotal = (int)reader["VideosCateTotal"];
            videoscate.VideosCateOrder = (int)reader["VideosCateOrder"];
            videoscate.ImageThumb = (string)reader["ImageThumb"];
            videoscate.ImageLarge = (string)reader["ImageLarge"];
            videoscate.Description = (string)reader["Description"];
            videoscate.UserName = (string)reader["UserName"];
            videoscate.Created = (DateTime)reader["Created"];
            videoscate.Language = (string)reader["Language"];
            return videoscate;
        }
        #endregion

        #region CreateVideosCate
        public void CreateVideosCate(VideosCate videoscate) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type",0);
                command.Parameters.AddWithValue("@VideosCateID", 0);
                command.Parameters.AddWithValue("@ParentCateID",videoscate.ParentCateID);
                command.Parameters.AddWithValue("@VideosCateName",videoscate.VideosCateName);
                command.Parameters.AddWithValue("@VideosCateTotal",videoscate.VideosCateTotal);
                command.Parameters.AddWithValue("@VideosCateOrder",videoscate.VideosCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", videoscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videoscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", videoscate.Description);
                command.Parameters.AddWithValue("@UserName", videoscate.UserName);
                command.Parameters.AddWithValue("@Created", videoscate.Created);
                command.Parameters.AddWithValue("@Language", videoscate.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể tạo danh mục tin");
                else
                    command.Dispose();
            }
        }
        public int CreateVideosCateGet(VideosCate videoscate)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@VideosCateID", 0);
                command.Parameters.AddWithValue("@ParentCateID", videoscate.ParentCateID);
                command.Parameters.AddWithValue("@VideosCateName", videoscate.VideosCateName);
                command.Parameters.AddWithValue("@VideosCateTotal", videoscate.VideosCateTotal);
                command.Parameters.AddWithValue("@VideosCateOrder", videoscate.VideosCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", videoscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videoscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", videoscate.Description);
                command.Parameters.AddWithValue("@UserName", videoscate.UserName);
                command.Parameters.AddWithValue("@Created", videoscate.Created);
                command.Parameters.AddWithValue("@Language", videoscate.Language);

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

        #region UpdateVideosCate
        public void UpdateVideosCate(VideosCate videoscate)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@VideosCateID",videoscate.VideosCateID);
                command.Parameters.AddWithValue("@ParentCateID", videoscate.ParentCateID);
                command.Parameters.AddWithValue("@VideosCateName", videoscate.VideosCateName);
                command.Parameters.AddWithValue("@VideosCateTotal", videoscate.VideosCateTotal);
                command.Parameters.AddWithValue("@VideosCateOrder", videoscate.VideosCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", videoscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", videoscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", videoscate.Description);
                command.Parameters.AddWithValue("@UserName", videoscate.UserName);
                command.Parameters.AddWithValue("@Created", videoscate.Created);
                command.Parameters.AddWithValue("@Language", videoscate.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteVideosCate
        public void DeleteVideosCate(int cId) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateDelete",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID",cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa danh mục tin");
                else
                    command.Dispose();
            }
            
        }
        #endregion
   

        #region VideosCateUpOrder
        public void VideosCateUpOrder(int cId , int cOrder) 
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", cId);
                command.Parameters.AddWithValue("@VideosCateOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetVideosCateParent
        public DataTable GetVideosCateParent(int cateID, string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGetOrderDate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", cateID);
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
        public DataTable GetVideosCateParentPaging(int cateID, PagingInfo _paging, string _lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGetOrderDatePaging", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", cateID);
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

        #region GetVideosCate
        public DataTable GetVideosCate(string _lang) 
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("VideosCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("VideosCateName");
            datatable.Columns.Add("VideosCateTotal");
            datatable.Columns.Add("VideosCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Language");
           

            DataTable table = new DataTable();
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID",0);
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
                    datarow["VideosCateID"] = row["VideosCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["VideosCateName"] = row["VideosCateName"].ToString();
                    datarow["VideosCateTotal"] = row["VideosCateTotal"].ToString();
                    datarow["VideosCateOrder"] = row["VideosCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Language"] = row["Language"].ToString();

                   
                    datatable.Rows.Add(datarow);
                    this.GetParentCate(datatable, Convert.ToInt32(datarow["VideosCateID"]), 1, "&nbsp;&nbsp;", _lang);
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
                SqlCommand command = new SqlCommand("_VideosCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", cID);
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
                        rs["VideosCateID"] = subrow["VideosCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["VideosCateName"] = sStr + subrow["VideosCateName"].ToString();
                        rs["VideosCateTotal"] = subrow["VideosCateTotal"].ToString();
                        rs["VideosCateOrder"] = subrow["VideosCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Language"] = subrow["Language"].ToString();

                        table.Rows.Add(rs);
                        this.GetParentCate(table, Convert.ToInt32(rs["VideosCateID"]), level + 1, "&nbsp;&nbsp;", _lang);
                    }
                }
            }
        }
        #endregion

        
        #region GetVideosCateById
        public VideosCate GetVideosCateById(int cId) 
        {
            VideosCate videoscate = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID",cId);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        videoscate = VideosCateReader(reader);
                    //else
                    //    throw new DataAccessException("Không tìm thấy danh mục");
                    command.Dispose();
                }
            }
            return videoscate;
        }
        #endregion

        #region GetVideosCateBullet
        public DataTable GetCateGroupBullet(string bullet, string _lang)
        {
            string str = HttpUtility.HtmlDecode("<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace = str;
            string sSpace1 = HttpUtility.HtmlDecode("</b>");


            DataTable datatable = new DataTable();
            datatable.Columns.Add("VideosCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("VideosCateName");
            datatable.Columns.Add("VideosCateTotal");
            datatable.Columns.Add("VideosCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Language");


            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideosCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", 0);
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
                    datarow["VideosCateID"] = row["VideosCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["VideosCateName"] = sSpace+ row["VideosCateName"].ToString() +sSpace1;
                    datarow["VideosCateTotal"] = row["VideosCateTotal"].ToString();
                    datarow["VideosCateOrder"] = row["VideosCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Language"] = row["Language"].ToString();

                    datatable.Rows.Add(datarow);
                    this.GetParentGroupBullet(datatable, Convert.ToInt32(datarow["VideosCateID"]), 1, "&nbsp;&nbsp;&nbsp;", bullet, _lang);
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
                SqlCommand command = new SqlCommand("_VideosCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VideosCateID", cID);
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
                        rs["VideosCateID"] = subrow["VideosCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["VideosCateName"] = sStr + subrow["VideosCateName"].ToString();
                        rs["VideosCateTotal"] = subrow["VideosCateTotal"].ToString();
                        rs["VideosCateOrder"] = subrow["VideosCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroupBullet(table, Convert.ToInt32(rs["VideosCateID"]),level + 1, "&nbsp;&nbsp;&nbsp;", bullet, _lang);
                    }
                }
            }
        }
        #endregion

        
    }
}