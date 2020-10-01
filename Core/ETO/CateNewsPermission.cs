using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class CateNewsPermission
    {
        public CateNewsPermission() 
        {
            //constructor
        }

        private int catenewsPermissionid;
        public int CateNewsPermissionID 
        {
            get { return catenewsPermissionid; }
            set { catenewsPermissionid = value; }
        }
        private int rolesID;
        public int RolesID
        {
            get { return rolesID; }
            set { rolesID = value; }
        }
       

        private int cateNewsID;
        public int CateNewsID
        {
            get { return cateNewsID; }
            set { cateNewsID = value; }
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

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
