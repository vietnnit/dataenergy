using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
     public class Email
    {
         public Email() 
        {
            //constructor
        }

        private int emailid;
        public int EmailID 
        {
            get { return emailid; }
            set { emailid = value; }
        }

        private string emailaddress;
        public string EmailAddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
