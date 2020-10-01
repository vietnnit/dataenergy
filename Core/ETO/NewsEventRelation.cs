using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsEventRelation
    {
        public NewsEventRelation() 
        {
            //constructor
        }

        private int id;
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
       

        private int _newsEventID;
        public int NewsEventID
        {
            get { return _newsEventID; }
            set { _newsEventID = value; }
        }

        private int _newsgroupID;
        public int NewsGroupID
        {
            get { return _newsgroupID; }
            set { _newsgroupID = value; }
        }

       
    }
}
