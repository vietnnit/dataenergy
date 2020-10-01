using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Contact
    {
        public Contact() 
        {
            //constructor
        }

        private int contactId;
        public int ContactID
        {
            get { return contactId; }
            set { contactId = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {name = value; }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }


        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string require;
        public string Require
        {
            get { return require; }
            set { require = value; }
        }
        private string attact;
        public string Attact
        {
            get { return attact; }
            set { attact = value; }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
