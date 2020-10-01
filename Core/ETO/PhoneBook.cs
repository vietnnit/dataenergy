using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class PhoneBook
    {
        public PhoneBook() 
        {
            //constructor
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone1;
        public string Phone1
        {
            get { return _phone1; }
            set { _phone1 = value; }
        }

        private string _phone2;
        public string Phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _homePhone;
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        private string _officephone;
        public string Officephone
        {
            get { return _officephone; }
            set { _officephone = value; }
        }

        private DateTime? _createDate;
        public DateTime? CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

       

        private string _creatorId;
        public string CreatorId
        {
            get { return _creatorId; }
            set { _creatorId = value; }
        }

        private Boolean _checkParent;
        public Boolean CheckParent
        {
            get { return _checkParent; }
            set { _checkParent = value; }
        }

        private int _parentId;
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
    }
}
