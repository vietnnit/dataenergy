using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class AlbumsCate
    {
        public AlbumsCate() 
        {
            //constructor
        }

        private int albumscateid;
        public int AlbumsCateID 
        {
            get { return albumscateid; }
            set { albumscateid = value; }
        }

        private int parentcateid;
        public int ParentCateID
        {
            get { return parentcateid; }
            set { parentcateid = value; }
        }

        private string albumscatename;
        public string AlbumsCateName
        {
            get { return albumscatename; }
            set { albumscatename = value; }
        }

        private int albumscatetotal;
        public int AlbumsCateTotal
        {
            get { return albumscatetotal; }
            set { albumscatetotal = value; }
        }

        private int albumscateorder;
        public int AlbumsCateOrder
        {
            get { return albumscateorder; }
            set { albumscateorder = value; }
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
