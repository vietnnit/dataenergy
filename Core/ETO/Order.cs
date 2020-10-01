using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Order
    {
        public Order() 
        {
            //constructor
        }
        private int Id;
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        private int orderId;
        public int OrderID
        {
            get { return orderId; }
            set { orderId = value; }
        }
        private int memberId;
        public int MemberID
        {
            get { return memberId; }
            set { memberId = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
        
        private bool isActived;
        public bool IsActived
        {
            get { return isActived; }
            set { isActived = value; }
        }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        
        private string nickYahoo;
        public string NickYahoo
        {
            get { return nickYahoo; }
            set { nickYahoo = value; }
        }
        private string nickSkype;
        public string NickSkype
        {
            get { return nickSkype; }
            set { nickSkype = value; }
        }

        private string require;
        public string Require
        {
            get { return require; }
            set { require = value; }
        }
    }
}
