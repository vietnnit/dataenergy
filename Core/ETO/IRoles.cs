using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class IRoles
    {
        public IRoles() 
        {
            //constructor
        }
        private int rolesId;
        public int RolesID
        {
            get { return rolesId; }
            set { rolesId = value; }
        }
        private string rolesName;
        public string RolesName 
        {
            get { return rolesName; }
            set { rolesName = value; }
        }
        private string rolesModules;
        public string RolesModules 
        {
            get { return rolesModules; }
            set { rolesModules = value; }
        }

        //private string rolesCode;
        //public string RolesCode
        //{
        //    get { return rolesCode; }
        //    set { rolesCode = value; }
        //}

    }
}
