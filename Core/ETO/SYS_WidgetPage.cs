using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_WidgetPage
    {
        public SYS_WidgetPage()
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

        private string _regionId;
        public string RegionId 
        {
            get { return _regionId; }
            set { _regionId = value; }
        }

        private string _widgetControl;
        public string WidgetControl 
        {
            get { return _widgetControl; }
            set { _widgetControl = value; }
        }

        private string _widgetDir;
        public string WidgetDir 
        {
            get { return _widgetDir; }
            set { _widgetDir = value; }
        }

        private string _widgetHTML;
        public string WidgetHTML 
        {
            get { return _widgetHTML; }
            set { _widgetHTML = value; }
        }

        private string _widgetIcon;
        public string WidgetIcon 
        {
            get { return _widgetIcon; }
            set { _widgetIcon = value; }
        }

        private string _widgetInfo;
        public string WidgetInfo 
        {
            get { return _widgetInfo; }
            set { _widgetInfo = value; }
        }
        private string _widgetName;
        public string WidgetName
        {
            get { return _widgetName; }
            set { _widgetName = value; }
        }
        private int _widgetOrder;
        public int WidgetOrder
        { 
            get { return _widgetOrder; }
            set { _widgetOrder = value; }
        }

        private int _widgerRecord;
        public int WidgetRecord {
            get { return _widgerRecord; }
            set { _widgerRecord = value; }
        }
        private int _widgetRecord2;
        public int WidgetRecord2 
        {
            get { return _widgetRecord2; }
            set { _widgetRecord2 = value; }
        }

        private bool _widgetStatus;
        public bool WidgetStatus 
        {
            get { return _widgetStatus; }
            set { _widgetStatus = value; }
        }
        private string _widgetTitle;
        public string WidgetTitle 
        {
            get { return _widgetTitle; }
            set { _widgetTitle = value; }
        }
        private string _widgetValue;
        public string WidgetValue 
        {
            get { return _widgetValue; }
            set { _widgetValue = value; }
        }
        private string _widgetValue2;
        public string WidgetValue2
        {
            get { return _widgetValue2; }
            set { _widgetValue2 = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}