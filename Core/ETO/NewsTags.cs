using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsTags
    {
        public NewsTags() 
        {
            //constructor
        }

        private int _newstagsid;
        public int NewsTagsID 
        {
            get { return _newstagsid; }
            set { _newstagsid = value; }
        }

        private int _tagsid;
        public int TagsID
        {
            get { return _tagsid; }
            set { _tagsid = value; }
        }

        private int _newsgroupId;
        public int NewsGroupID
        {
            get { return _newsgroupId; }
            set { _newsgroupId = value; }
        }

       
    }
}
