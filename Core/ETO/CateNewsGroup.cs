using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class CateNewsGroup
    {
         public CateNewsGroup()
        {

        }

        private int cateNewsGroupID;
        public int CateNewsGroupID
        {
            get { return cateNewsGroupID; }
            set { cateNewsGroupID = value; }
        }

        private int groupCate;
        public int GroupCate
        {
            get { return groupCate; }
            set { groupCate = value; }
        }

        private string cateNewsGroupName;
        public string CateNewsGroupName
        {
            get { return cateNewsGroupName; }
            set { cateNewsGroupName = value; }
        }

        private string shortName;
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int order;
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        private bool isview;
        public bool IsView
        {
            get { return isview; }
            set { isview = value; }
        }

        private bool ishome;
        public bool IsHome
        {
            get { return ishome; }
            set { ishome = value; }
        }
        private bool ismenu;
        public bool IsMenu
        {
            get { return ismenu; }
            set { ismenu = value; }
        }

        private bool isnews;
        public bool IsNew
        {
            get { return isnews; }
            set { isnews = value; }
        }

        private bool ispage;
        public bool IsPage
        {
            get { return ispage; }
            set { ispage = value; }
        }

        private bool isurl;
        public bool IsUrl
        {
            get { return isurl; }
            set { isurl = value; }
        }
        private bool isregister;
        public bool IsRegister
        {
            get { return isregister; }
            set { isregister = value; }
        }
        private bool isfaq;
        public bool IsFaq
        {
            get { return isfaq; }
            set { isfaq = value; }
        }

        private bool isofficial;
        public bool IsOfficial
        {
            get { return isofficial; }
            set { isofficial = value; }
        }

        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private int position;
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        private int _menu;
        public int Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }

        private int _pageLayoutID;
        public int PageLayoutID
        {
            get { return _pageLayoutID; }
            set { _pageLayoutID = value; }
        }
    }
}
