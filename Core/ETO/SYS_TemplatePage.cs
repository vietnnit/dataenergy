using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_TemplatePage
    {
        public SYS_TemplatePage() 
        {
            //constructor
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _templateName;
        public string TemplateName
        {
            get { return _templateName; }
            set { _templateName = value; }
        }
        private string _templateControl;
        public string TemplateControl
        {
            get { return _templateControl; }
            set { _templateControl = value; }
        }
        private string _masterControl;
        public string MasterControl
        {
            get { return _masterControl; }
            set { _masterControl = value; }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
