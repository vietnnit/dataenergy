using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_WidgetPageLayout
    {
        public SYS_WidgetPageLayout()
        {

        }

        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

        private int _pageLayouID;
        public int PageLayoutId 
        { 
            get { return _pageLayouID; } 
            set { _pageLayouID = value; } 
        }

        private int _widgetID;
        public int WidgetId
        {
            get { return _widgetID; }
            set { _widgetID = value; }
        }

        private string _regionId;
        public string RegionId
        {
            get { return _regionId; }
            set { _regionId = value; }
        }

        private string _HTML;
        public string HTML 
        {
            get { return _HTML; }
            set { _HTML = value; }
        }

        private string _Icon;
        public string Icon 
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        private string _Info;
        public string Info 
        {
            get { return _Info; }
            set { _Info = value; }
        }

        private int _Orders;
        public int Orders
        { 
            get { return _Orders; }
            set { _Orders = value; }
        }

        private int _widgerRecord;
        public int Record {
            get { return _widgerRecord; }
            set { _widgerRecord = value; }
        }
        private int _Record2;
        public int Record2 
        {
            get { return _Record2; }
            set { _Record2 = value; }
        }

        private bool _Status;
        public bool Status 
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _Title;
        public string Title 
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _Value;
        public string Value 
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _Value2;
        public string Value2
        {
            get { return _Value2; }
            set { _Value2 = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}