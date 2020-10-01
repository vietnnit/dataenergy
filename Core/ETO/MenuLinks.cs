using System;
using System.Collections.Generic;
using System.Text;

namespace ETO
{
    public class MenuLinks
    {
        public MenuLinks()
        {
            // Contructor
        }
        private int menuLinksId;
        public int MenuLinksID
        {
            get { return menuLinksId; }
            set { menuLinksId = value; }
        }

        private int menuLinksParent;
        public int MenuLinksParent
        {
            get { return menuLinksParent; }
            set { menuLinksParent = value; }
        }

        private string menuLinksName;
        public string MenuLinksName
        {
            get { return menuLinksName; }
            set { menuLinksName = value; }
        }

        private string menuLinksUrl;
        public string MenuLinksUrl
        {
            get { return menuLinksUrl; }
            set { menuLinksUrl = value; }
        }

        private int menuLinksOrder;
        public int MenuLinksOrder
        {
            get { return menuLinksOrder; }
            set { menuLinksOrder = value; }
        }

        private string menuLinkshelp;
        public string MenuLinksHelp
        {
            get { return menuLinkshelp; }
            set { menuLinkshelp = value; }
        }

        private string menuLinksicon;
        public string MenuLinksIcon
        {
            get { return menuLinksicon; }
            set { menuLinksicon = value; }
        }
        private bool status;
        public bool Status
        {
            get
            {
                return status;
            }
            set { status = value; }

        }

        private bool isView;
        public bool IsView
        {
            get
            {
                return isView;
            }
            set { isView = value; }

        }
        private string target;
        public string Target
        {
            get { return target; }
            set { target = value; }
        }

        private bool isflash;
        public bool IsFlash
        {
            get { return isflash; }
            set { isflash = value; }
        }

        private string filename;
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int hit;
        public int Hit
        {
            get { return hit; }
            set { hit = value; }
        }

        private string _lang;
        public string Language
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
