using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Register
    {
        public Register() 
        {
            //constructor
        }

        private int _RegisterId;
        public int RegisterID
        {
            get { return _RegisterId; }
            set { _RegisterId = value; }
        }

       
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string fullName2;
        public string FullName2
        {
            get { return fullName2; }
            set { fullName2 = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string phone1;
        public string Phone1
        {
            get { return phone1; }
            set { phone1 = value; }
        }
        private string phone2;
        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }
        private string phone3;
        public string Phone3
        {
            get { return phone3; }
            set { phone3 = value; }
        }
        private string address1;
        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        private string address2;
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        private DateTime birth;
        public DateTime Birth
        {
            get { return birth; }
            set { birth = value; }
        }
        private bool actived;
        public bool Actived
        {
            get { return actived; }
            set { actived = value; }
        }
        private bool sex;
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
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
        private string _TN_Nam;
        public string TN_Nam
        {
            get { return _TN_Nam; }
            set { _TN_Nam = value; }
        }

        private string _TN_Mon1;
        public string TN_Mon1
        {
            get { return _TN_Mon1; }
            set { _TN_Mon1 = value; }
        }

        private string _TN_Mon2;
        public string TN_Mon2
        {
            get { return _TN_Mon2; }
            set { _TN_Mon2 = value; }
        }
        private string _TN_Mon3;
        public string TN_Mon3
        {
            get { return _TN_Mon3; }
            set { _TN_Mon3 = value; }
        }
        private string _TN_Mon4;
        public string TN_Mon4
        {
            get { return _TN_Mon4; }
            set { _TN_Mon4 = value; }
        }
        private string _TN_Mon5;
        public string TN_Mon5
        {
            get { return _TN_Mon5; }
            set { _TN_Mon5 = value; }
        }

        private string _TN_Truong;
        public string TN_Truong
        {
            get { return _TN_Truong; }
            set { _TN_Truong = value; }
        }

        private string _DT_Truong;
        public string DT_Truong
        {
            get { return _DT_Truong; }
            set { _DT_Truong = value; }
        }

        private string _DT_SBD;
        public string DT_SBD
        {
            get { return _DT_SBD; }
            set { _DT_SBD = value; }
        }

        private string _DT_Mon1;
        public string DT_Mon1
        {
            get { return _DT_Mon1; }
            set { _DT_Mon1 = value; }
        }

        private string _DT_Mon2;
        public string DT_Mon2
        {
            get { return _DT_Mon2; }
            set { _DT_Mon2 = value; }
        }

        private string _DT_Mon3;
        public string DT_Mon3
        {
            get { return _DT_Mon3; }
            set { _DT_Mon3 = value; }
        }

        private string _DT_Khoi;
        public string DT_Khoi
        {
            get { return _DT_Khoi; }
            set { _DT_Khoi = value; }
        }

        private string _DT_Nganh;
        public string DT_Nganh
        {
            get { return _DT_Nganh; }
            set { _DT_Nganh = value; }
        }

        private string _NV_Truong;
        public string NV_Truong
        {
            get { return _NV_Truong; }
            set { _NV_Truong = value; }
        }

        private string _NV_He;
        public string NV_He
        {
            get { return _NV_He; }
            set { _NV_He = value; }
        }

        private string _NV_Nganh;
        public string NV_Nganh
        {
            get { return _NV_Nganh; }
            set { _NV_Nganh = value; }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
    }
}
