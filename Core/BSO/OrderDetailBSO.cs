using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class OrderDetailBSO
    {
        public OrderDetailBSO() 
        {
            //constructor
        }


        #region CreateOrderDetail
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            orderDetailDAO.CreateOrderDetail(orderDetail);
        }
        #endregion

        #region UpdateOrderDetail
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            orderDetailDAO.UpdateOrderDetail(orderDetail);
        }
        #endregion

        #region DeleteOrderDetail
        public void DeleteOrderDetail(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            orderDetailDAO.DeleteOrderDetail(Id);
        }
        #endregion

        #region DeleteOrderDetailOrder
        public void DeleteOrderDetailOrder(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            orderDetailDAO.DeleteOrderDetailOrder(Id);
        }
        #endregion

        #region GetOrderDetailById
        public OrderDetail GetOrderDetailById(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailById(Id);
        }
        #endregion

        #region GetOrderDetailByOrderId
        public DataTable GetOrderDetailByOrderId(int Id)
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailByOrderId(Id);
        }
        #endregion

        #region GetOrderDetailAll
        public DataTable GetOrderDetailAll()
        {
            OrderDetailDAO orderDetailDAO = new OrderDetailDAO();
            return orderDetailDAO.GetOrderDetailAll();
        }
        #endregion
    }
}
