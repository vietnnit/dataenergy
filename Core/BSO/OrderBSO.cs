using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class OrderBSO
    {
        public OrderBSO() 
        {
            //constructor
        }


        #region CreateOrder
        public void CreateOrder(Order order)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.CreateOrder(order);
        }
        public int CreateOrderGet(Order order)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.CreateOrderGet(order);
        }
        #endregion

        #region UpdateOrder
        public void UpdateOrder(Order order)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.UpdateOrder(order);
        }
        #endregion

        #region UpdateOrder
        public void UpdateOrder(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.UpdateOrder(restr, value);
        }
        #endregion

        #region DeleteOrder
        public void DeleteOrder(int Id)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.DeleteOrder(Id);
        }
        #endregion

        #region GetOrderById
        public Order GetOrderById(int Id)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderById(Id);
        }
        #endregion

        #region GetOrderAll
        public DataTable GetOrderAll()
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderAll();
        }
        #endregion

        #region GetOrderMemberAll
        public DataTable GetOrderMemberAll()
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderMemberAll();
        }
        #endregion

        #region OrderSearch
        public DataTable OrderSearch(string keyword, int cId)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.OrderSearch(keyword, cId);
        }
        #endregion

        #region GetOrderByMemberId
        public DataTable GetOrderByMemberId(int Id)
        {
            OrderDAO orderDAO = new OrderDAO();
            return orderDAO.GetOrderByMemberId(Id);
        }
        #endregion
    }
}
