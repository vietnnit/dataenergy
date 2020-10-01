using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class AdminRoles
    {
         public AdminRoles() 
        {
            //constructor
        }

        private int adminRolesid;
        public int AdminRolesID 
        {
            get { return adminRolesid; }
            set { adminRolesid = value; }
        }
        private int rolesID;
        public int RolesID
        {
            get { return rolesID; }
            set { rolesID = value; }
        }
       

        private string adminUserName;
        public string AdminUserName
        {
            get { return adminUserName; }
            set { adminUserName = value; }
        }

        private string permission;
        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }
        private DateTime created;
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
