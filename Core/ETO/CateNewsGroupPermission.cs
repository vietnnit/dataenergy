using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class CateNewsGroupPermission
    {
        public CateNewsGroupPermission() 
        {
            //constructor
        }

        private int _catenewsGroupPermissionid;
        public int CateNewsGroupPermissionID 
        {
            get { return _catenewsGroupPermissionid; }
            set { _catenewsGroupPermissionid = value; }
        }
        private int rolesID;
        public int RolesID
        {
            get { return rolesID; }
            set { rolesID = value; }
        }
       

        private int _cateNewsGroupID;
        public int CateNewsGroupID
        {
            get { return _cateNewsGroupID; }
            set { _cateNewsGroupID = value; }
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
