using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class Modules
    {
        public Modules() 
        {
            // Contructor
        }
        private int modulesId;
        public int ModulesID
        {
            get { return modulesId; }
            set { modulesId = value; }
        }

        private int modulesParent;
        public int ModulesParent
        {
            get { return modulesParent; }
            set { modulesParent = value; }
        }

        private string modulesName;
        public string ModulesName
        {
            get { return modulesName; }
            set { modulesName = value; }
        }

        private string modulesDir;
        public string ModulesDir
        {
            get { return modulesDir; }
            set { modulesDir = value; }
        }

        private string modulesUrl;
        public string ModulesUrl
        {
            get { return modulesUrl; }
            set { modulesUrl = value; }
        }

        private int modulesOrder;
        public int ModulesOrder
        {
            get { return modulesOrder; }
            set { modulesOrder = value; }
        }

        private string moduleshelp;
        public string ModulesHelp
        {
            get { return moduleshelp; }
            set { moduleshelp = value; }
        }

        private string modulesicon;
        public string ModulesIcon
        {
            get { return modulesicon; }
            set { modulesicon = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private bool isview;
        public bool IsView
        {
            get { return isview; }
            set { isview = value; }
        }

        private bool ismenu;
        public bool IsMenu
        {
            get { return ismenu; }
            set { ismenu = value; }
        }

        private string slug;
        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }
    }
}
