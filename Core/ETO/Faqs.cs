using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Faqs
    {
        public Faqs() 
        {
            //constructor
        }

        private int _faqsId;
        public int FaqsID
        {
            get { return _faqsId; }
            set { _faqsId = value; }
        }

        private int _faqsCate;
        public int FaqsCateID
        {
            get { return _faqsCate; }
            set { _faqsCate = value; }
        }

        private int _parentFaqsID;
        public int ParentFaqsID
        {
            get { return _parentFaqsID; }
            set { _parentFaqsID = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string contents;
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
       
        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private bool actived;
        public bool Actived
        {
            get { return actived; }
            set { actived = value; }
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
        private int orders;
        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        private DateTime _postDate;
        public DateTime PostDate
        {
            get { return _postDate; }
            set { _postDate = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private DateTime _ApprovedDate;
        public DateTime ApprovedDate
        {
            get { return _ApprovedDate; }
            set { _ApprovedDate = value; }
        }
    }
}
