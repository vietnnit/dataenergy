using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class VideosCate
    {
        public VideosCate() 
        {
            //constructor
        }

        private int videoscateid;
        public int VideosCateID 
        {
            get { return videoscateid; }
            set { videoscateid = value; }
        }

        private int parentcateid;
        public int ParentCateID
        {
            get { return parentcateid; }
            set { parentcateid = value; }
        }

        private string videoscatename;
        public string VideosCateName
        {
            get { return videoscatename; }
            set { videoscatename = value; }
        }

        private int videoscatetotal;
        public int VideosCateTotal
        {
            get { return videoscatetotal; }
            set { videoscatetotal = value; }
        }

        private int videoscateorder;
        public int VideosCateOrder
        {
            get { return videoscateorder; }
            set { videoscateorder = value; }
        }


        private string imagethumb;
        public string ImageThumb
        {
            get { return imagethumb; }
            set { imagethumb = value; }
        }

        private string imagelarge;
        public string ImageLarge
        {
            get { return imagelarge; }
            set { imagelarge = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }



        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private DateTime created;
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
