using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class SYS_PageLayout
    {
        public SYS_PageLayout() 
        {
            //constructor
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _pageName;
        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }
        private string _slugPageName;
        public string SlugPageName
        {
            get { return _slugPageName; }
            set { _slugPageName = value; }
        }
        private int _templateId;
        public int TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }
        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
