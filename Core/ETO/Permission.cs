using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Permission
    {
        public Permission()
        {

        }

        private int permissionID;
        public int PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        private string permissionName;
        public string PermissionName
        {
            get { return permissionName; }
            set { permissionName = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string value1;
        public string Value
        {
            get { return value1; }
            set { value1 = value; }
        }
    }
}
