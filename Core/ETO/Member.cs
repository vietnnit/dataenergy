using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Member
    {
        public Member() 
        {
            //constructor
        }

        private int memberId;
        public int MemberID
        {
            get { return memberId; }
            set { memberId = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string passWord;
        public string Password
        {
            get { return passWord; }
            set { passWord = value; }
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
        private string avatar;
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
    }
}
