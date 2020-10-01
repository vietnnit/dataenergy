using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_WidgetType
    {
        public SYS_WidgetType()
        {

        }

        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

        private string _widgetTypeName;
        public string WidgetTypeName
        {
            get { return _widgetTypeName; }
            set { _widgetTypeName = value; }
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
       
       

        private bool _widgetStatus;
        public bool WidgetStatus 
        {
            get { return _widgetStatus; }
            set { _widgetStatus = value; }
        }

        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

    }
}