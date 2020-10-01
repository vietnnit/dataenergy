using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class OrderDetail
    {
        public OrderDetail() 
        {
            //constructor
        }
        private int orderDetailId;
        public int OrderDetailID
        {
            get { return orderDetailId; }
            set { orderDetailId = value; }
        }

        private int orderId;
        public int OrderID
        {
            get { return orderId; }
            set { orderId = value; }
        }
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quatity;
        public int Quatity
        {
            get { return quatity; }
            set { quatity = value; }
        }
    }
}
