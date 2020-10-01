using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class FaqsCateDAO : BaseDAO
    {
        public FaqsCateDAO()
        {
            //constructor
        }

        #region FaqsCateReader
        private FaqsCate FaqsCateReader(SqlDataReader reader)
        {
            FaqsCate _faqsCate = new FaqsCate();
            _faqsCate.FaqsCateID = (int)reader["FaqsCateID"];
            _faqsCate.FaqsCateParentID = (int)reader["FaqsCateParentID"];
            _faqsCate.FaqsCateName = (string)reader["FaqsCateName"];
            _faqsCate.FaqsCateOrder = (int)reader["FaqsCateOrder"];
            _faqsCate.Icon = (string)reader["Icon"];
            _faqsCate.Phone = (string)reader["Phone"];
            _faqsCate.Note = (string)reader["Note"];
            _faqsCate.UserName = (string)reader["UserName"];
            _faqsCate.Created = (DateTime)reader["Created"];
            return _faqsCate;
        }
        #endregion

        #region CreateFaqsCate
        public void CreateFaqsCate(FaqsCate _faqsCate)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@FaqsCateID", 0);
                command.Parameters.AddWithValue("@FaqsCateParentID", _faqsCate.FaqsCateParentID);
                command.Parameters.AddWithValue("@FaqsCateName", _faqsCate.FaqsCateName);
                command.Parameters.AddWithValue("@FaqsCateOrder", _faqsCate.FaqsCateOrder);
                command.Parameters.AddWithValue("@Icon", _faqsCate.Icon);
                command.Parameters.AddWithValue("@Phone", _faqsCate.Phone);
                command.Parameters.AddWithValue("@Note", _faqsCate.Note);
                command.Parameters.AddWithValue("@UserName", _faqsCate.UserName);
                command.Parameters.AddWithValue("@Created", _faqsCate.Created);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể tạo danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region CreateFaqsCateGet
        public int CreateFaqsCateGet(FaqsCate _faqsCate)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateInsert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", 0);
                command.Parameters.AddWithValue("@FaqsCateParentID", _faqsCate.FaqsCateParentID);
                command.Parameters.AddWithValue("@FaqsCateName", _faqsCate.FaqsCateName);
                command.Parameters.AddWithValue("@FaqsCateOrder", _faqsCate.FaqsCateOrder);
                command.Parameters.AddWithValue("@Icon", _faqsCate.Icon);
                command.Parameters.AddWithValue("@Phone", _faqsCate.Phone);
                command.Parameters.AddWithValue("@Note", _faqsCate.Note);
                command.Parameters.AddWithValue("@UserName", _faqsCate.UserName);
                command.Parameters.AddWithValue("@Created", _faqsCate.Created);


                SqlParameter sp = new SqlParameter("@pReturnValue", SqlDbType.Int);
                sp.Direction = ParameterDirection.Output;
                command.Parameters.Add(sp);

                connection.Open();
                command.ExecuteNonQuery();

                int id = Convert.ToInt32(sp.Value.ToString());

                return id;
            }
        }
        #endregion

        #region UpdateFaqsCate
        public void UpdateFaqsCate(FaqsCate _faqsCate)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@FaqsCateID", _faqsCate.FaqsCateID);
                command.Parameters.AddWithValue("@FaqsCateParentID", _faqsCate.FaqsCateParentID);
                command.Parameters.AddWithValue("@FaqsCateName", _faqsCate.FaqsCateName);
                command.Parameters.AddWithValue("@FaqsCateOrder", _faqsCate.FaqsCateOrder);
                command.Parameters.AddWithValue("@Icon", _faqsCate.Icon);
                command.Parameters.AddWithValue("@Phone", _faqsCate.Phone);
                command.Parameters.AddWithValue("@Note", _faqsCate.Note);
                command.Parameters.AddWithValue("@UserName", _faqsCate.UserName);
                command.Parameters.AddWithValue("@Created", _faqsCate.Created);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteFaqsCate
        public void DeleteFaqsCate(int cId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa danh mục tin");
                else
                    command.Dispose();
            }

        }
        #endregion



        #region FaqsCateUpOrder
        public void FaqsCateUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", cId);
                command.Parameters.AddWithValue("@FaqsCateOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetFaqsCate
        public DataTable GetFaqsCate()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("FaqsCateID");
            datatable.Columns.Add("FaqsCateParentID");
            datatable.Columns.Add("FaqsCateName");
            datatable.Columns.Add("FaqsCateOrder");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Phone");
            datatable.Columns.Add("Note");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");


            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", 0);
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
                    datarow["FaqsCateID"] = row["FaqsCateID"].ToString();
                    datarow["FaqsCateParentID"] = row["FaqsCateParentID"].ToString();
                    datarow["FaqsCateName"] = row["FaqsCateName"].ToString();
                    datarow["FaqsCateOrder"] = row["FaqsCateOrder"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Phone"] = row["Phone"].ToString();
                    datarow["Note"] = row["Note"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();


                    datatable.Rows.Add(datarow);
                    this.GetFaqsCateParent(datatable, Convert.ToInt32(datarow["FaqsCateID"]), 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                }

            }
            return datatable;
        }

        private void GetFaqsCateParent(DataTable table, int cID,  int level, string sSpace)
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
                SqlCommand command = new SqlCommand("_FaqsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", cID);
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
                        rs["FaqsCateID"] = subrow["FaqsCateID"].ToString();
                        rs["FaqsCateParentID"] = subrow["FaqsCateParentID"].ToString();
                        rs["FaqsCateName"] = sStr + subrow["FaqsCateName"].ToString();
                        rs["FaqsCateOrder"] = subrow["FaqsCateOrder"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Phone"] = subrow["Phone"].ToString();
                        rs["Note"] = subrow["Note"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();

                        table.Rows.Add(rs);
                        this.GetFaqsCateParent(table, Convert.ToInt32(rs["FaqsCateID"]), level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                }
            }
        }
        #endregion


        #region GetFaqsCateById
        public FaqsCate GetFaqsCateById(int cId)
        {
            FaqsCate _faqsCate = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", cId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        _faqsCate = FaqsCateReader(reader);
                    else
                        throw new DataAccessException("Không tìm thấy danh mục");
                    command.Dispose();
                }
            }
            return _faqsCate;
        }

       
        #endregion

        #region GetFaqsCateParentAll
        public DataTable GetFaqsCateParentAll(int Id)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", Id);
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


        
        #region GetFaqsCateSearchName
        public DataTable GetFaqsCateSearchName(string _text)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateSearchName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchText", _text);
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
    }
}
