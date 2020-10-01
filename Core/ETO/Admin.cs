using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Admin
    {
        public Admin() 
        {
            //constructor
        }
        private int adminId;
        public int AdminID 
        {
            get { return adminId; }
            set { adminId = value; }
        }
        private string adminName;
        public string AdminName 
        {
            get { return adminName; }
            set { adminName = value; }
        }
        private string adminFullName;
        public string AdminFullName
        {
            get { return adminFullName; }
            set { adminFullName = value; }
        }
        private string adminEmail;
        public string AdminEmail
        {
            get { return adminEmail; }
            set { adminEmail = value; }
        }
        private string adminPass;
        public string AdminPass
        {
            get { return adminPass; }
            set { adminPass = value; }
        }
        private int rolesId;
        public int RolesID
        {
            get { return rolesId; }
            set { rolesId = value; }
        }
        private bool adminActive;
        public bool AdminActive
        {
            get { return adminActive; }
            set { adminActive = value; }
        }

        private string adminPermission;
        public string AdminPermission
        {
            get { return adminPermission; }
            set { adminPermission = value; }
        }
        private DateTime adminCreated;
        public DateTime AdminCreated
        {
            get { return adminCreated; }
            set { adminCreated = value; }
        }
        private DateTime adminLog;
        public DateTime AdminLog
        {
            get { return adminLog; }
            set { adminLog = value; }
        }
        private string phone;
        public string AdminPhone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string address;
        public string AdminAddress
        {
            get { return address; }
            set { address = value; }
        }
        private DateTime birth;
        public DateTime AdminBirth
        {
            get { return birth; }
            set { birth = value; }
        }

        private bool sex;
        public bool AdminSex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string nickYahoo;
        public string AdminNickYahoo
        {
            get { return nickYahoo; }
            set { nickYahoo = value; }
        }
        private string nickSkype;
        public string AdminNickSkype
        {
            get { return nickSkype; }
            set { nickSkype = value; }
        }
        private string avatar;
        public string AdminAvatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        private bool loginType;
        public bool AdminLoginType
        {
            get { return loginType; }
            set { loginType = value; }
        }
        private int _OrganizationId;
        public int AdminOrganizationId
        {
            get { return _OrganizationId; }
            set { _OrganizationId = value; }
        }
    }
}
