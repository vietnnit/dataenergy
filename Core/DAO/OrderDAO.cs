using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace DAO
{
    public class OrderDAO : BaseDAO
    {
        public OrderDAO() 
        {
            //constructor
        }

        #region OrderReader
        private Order OrderReader(SqlDataReader reader)
        {
            Order order = new Order();
            order.ID = (int)reader["ID"];
            order.OrderID = (int)reader["OrderID"];
            order.MemberID = (int)reader["MemberID"];
            order.Title = (string)reader["Title"];
            order.DateCreated = (DateTime)reader["DateCreated"];
            order.IsActived = (bool)reader["IsActived"];

            order.FullName = (string)reader["FullName"];
            order.Email = (string)reader["Email"];
            order.Phone = (string)reader["Phone"];
            order.Address = (string)reader["Address"];

            order.NickYahoo = (string)reader["NickYahoo"];
            order.NickSkype = (string)reader["NickSkype"];
            order.Require = (string)reader["Require"];
            
            return order;
        }
        #endregion

        #region GetOrderAll
        public DataTable GetOrderAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetAll", connection);
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


        #region GetOrderById
        public Order GetOrderById(int orderID)
        {
            Order order = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        order = OrderReader(reader);
                    else
                        throw new DataAccessException("khong ton tai order");
                }
                command.Dispose();

            }
            return order;
        }
        #endregion

        #region CreateOrder
        public void CreateOrder(Order order)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@MemberID", order.MemberID);
                command.Parameters.AddWithValue("@Title", order.Title);
                command.Parameters.AddWithValue("@DateCreated", order.DateCreated);
                command.Parameters.AddWithValue("@IsActived", order.IsActived);

                command.Parameters.AddWithValue("@FullName", order.FullName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@Phone", order.Phone);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@NickYahoo", order.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", order.NickSkype);
                command.Parameters.AddWithValue("@Require", order.Require);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public int CreateOrderGet(Order order)
        {
            int i = 0;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@MemberID", order.MemberID);
                command.Parameters.AddWithValue("@Title", order.Title);
                command.Parameters.AddWithValue("@DateCreated", order.DateCreated);
                command.Parameters.AddWithValue("@IsActived", order.IsActived);

                command.Parameters.AddWithValue("@FullName", order.FullName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@Phone", order.Phone);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@NickYahoo", order.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", order.NickSkype);
                command.Parameters.AddWithValue("@Require", order.Require);
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

        #region UpdateOrder
        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID", order.OrderID);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@MemberID", order.MemberID);
                command.Parameters.AddWithValue("@Title", order.Title);
                command.Parameters.AddWithValue("@DateCreated", order.DateCreated);
                command.Parameters.AddWithValue("@IsActived", order.IsActived);

                command.Parameters.AddWithValue("@FullName", order.FullName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@Phone", order.Phone);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@NickYahoo", order.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", order.NickSkype);
                command.Parameters.AddWithValue("@Require", order.Require);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể cập nhật");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateOrder
        public void UpdateOrder(string strId, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "update tblOrder set IsActived =" + value + " where OrderID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("khong the cap nhat");
                else
                    command.Dispose();
            }
        }
        #endregion



        #region DeleteOrder
        public void DeleteOrder(int orderID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa order");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetOrderMemberAll
        public DataTable GetOrderMemberAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderMemberGetAll", connection);
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

        #region OrderSearch
        public DataTable OrderSearch(string keyword, int memberid)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderSearch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@MemberID", memberid);
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

        #region GetOrderByMemberId
        public DataTable GetOrderByMemberId(int memberID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetByMemberId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MemberID", memberID);
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
