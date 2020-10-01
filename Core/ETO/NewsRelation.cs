using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsRelation
    {
        public NewsRelation() 
        {
            //constructor
        }

        private int id;
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
       

        private int _newsID;
        public int NewsID
        {
            get { return _newsID; }
            set { _newsID = value; }
        }

        private int _newsgroupID;
        public int NewsGroupID
        {
            get { return _newsgroupID; }
            set { _newsgroupID = value; }
        }

       
    }
}
