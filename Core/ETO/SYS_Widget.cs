using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_Widget
    {
        public SYS_Widget()
        {

        }

        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
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
       

        private bool _widgetStatus;
        public bool WidgetStatus 
        {
            get { return _widgetStatus; }
            set { _widgetStatus = value; }
        }
        private int _widgetType;
        public int WidgetType 
        {
            get { return _widgetType; }
            set { _widgetType = value; }
        }

    }
}