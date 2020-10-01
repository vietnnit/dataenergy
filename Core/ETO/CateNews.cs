using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class CateNews
    {
        public CateNews() 
        {
            //constructor
        }

        private int catenewsid;
        public int CateNewsID 
        {
            get { return catenewsid; }
            set { catenewsid = value; }
        }

        private int parentnewsid;
        public int ParentNewsID
        {
            get { return parentnewsid; }
            set { parentnewsid = value; }
        }

        private string catenewsname;
        public string CateNewsName
        {
            get { return catenewsname; }
            set { catenewsname = value; }
        }

        private int catenewstotal;
        public int CateNewsTotal
        {
            get { return catenewstotal; }
            set { catenewstotal = value; }
        }

        private int catenewsorder;
        public int CateNewsOrder
        {
            get { return catenewsorder; }
            set { catenewsorder = value; }
        }

        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        private int groupcate;
        public int GroupCate 
        {
            get { return groupcate; }
            set { groupcate = value; }
        }

        private string icon;
        public string Icon 
        {
            get { return icon; }
            set { icon = value; }
        }
        private string slogan;
        public string Slogan 
        {
            get { return slogan; }
            set { slogan = value; }
        }

        private string roles;
        public string Roles
        {
            get { return roles; }
            set { roles = value; }
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

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private bool isurl;
        public bool isUrl
        {
            get { return isurl; }
            set { isurl = value; }
        }
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }
        private int _pageLayoutID;
        public int PageLayoutID
        {
            get { return _pageLayoutID; }
            set { _pageLayoutID = value; }
        }

    }
}
