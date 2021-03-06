using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace DAO
{
    public class OrderDetailDAO : BaseDAO
    {
        public OrderDetailDAO() 
        {
            //constructor
        }

        #region OrderDetailReader
        private OrderDetail OrderDetailReader(SqlDataReader reader)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderDetailID = (int)reader["OrderDetailID"];
            orderDetail.OrderID = (int)reader["OrderID"];
            orderDetail.ProductID = (int)reader["ProductID"];
            orderDetail.Price = (double)reader["Price"];
            orderDetail.Quatity = (int)reader["Quatity"];
            return orderDetail;
        }
        #endregion

        #region GetOrderDetailAll
        public DataTable GetOrderDetailAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetAll", connection);
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

        #region GetOrderDetailById
        public OrderDetail GetOrderDetailById(int orderDetailID)
        {
            OrderDetail orderDetail = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        orderDetail = OrderDetailReader(reader);
                    else
                        throw new DataAccessException("khong ton tai orderDetail");
                }
                command.Dispose();

            }
            return orderDetail;
        }
        #endregion

        #region CreateOrderDetail
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                command.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                command.Parameters.AddWithValue("@Price", orderDetail.Price);
                command.Parameters.AddWithValue("@Quatity", orderDetail.Quatity);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateOrderDetail
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                command.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                command.Parameters.AddWithValue("@Price", orderDetail.Price);
                command.Parameters.AddWithValue("@Quatity", orderDetail.Quatity);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteOrderDetail
        public void DeleteOrderDetail(int orderDetailID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa orderDetail");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteOrderDetailOrder
        public void DeleteOrderDetailOrder(int orderID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailDeleteOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa orderDetail");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetOrderDetailByOrderId
        public DataTable GetOrderDetailByOrderId(int orderID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetByOrderId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderID", orderID);
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

    }
}
