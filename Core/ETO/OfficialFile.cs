using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class OfficialFile
    {
        public OfficialFile()
        {
            //constructor
        }

        private int officialFileid;
        public int OfficialFileID
        {
            get { return officialFileid; }
            set { officialFileid = value; }
        }

        private int officialid;
        public int OfficialID
        {
            get { return officialid; }
            set { officialid = value; }
        }

        private string filename;
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
