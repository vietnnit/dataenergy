using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class NewsGroupFile
    {
        public NewsGroupFile()
        {
            //constructor
        }

        private int _newsGroupFileid;
        public int NewsGroupFileID
        {
            get { return _newsGroupFileid; }
            set { _newsGroupFileid = value; }
        }

        private int _newsGroupid;
        public int NewsGroupID
        {
            get { return _newsGroupid; }
            set { _newsGroupid = value; }
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
