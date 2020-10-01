using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsCate
    {
        public NewsCate() 
        {
            //constructor
        }

        private int id;
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
       

        private int _catenewsID;
        public int CateNewsID
        {
            get { return _catenewsID; }
            set { _catenewsID = value; }
        }

        private int _newsgroupID;
        public int NewsGroupID
        {
            get { return _newsgroupID; }
            set { _newsgroupID = value; }
        }

       
    }
}
