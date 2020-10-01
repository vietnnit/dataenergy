using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class SiteMapBSO : StaticSiteMapProvider
    {
        public SiteMapBSO()
            : base()
            {
                //constructor
            }

        private String _siteMapFileName;
        private SiteMapNode _rootNode = null;
        private bool m_RefreshSitemap;
        private const String SiteMapNodeName = "siteMapNode";

        #region RefreshSitemap
        public void RefreshSitemap()
        {
            m_RefreshSitemap = true;
        }
        #endregion

        #region RootNode
        public override SiteMapNode RootNode
        {
            get { return BuildSiteMap(); }
        }
        #endregion

        #region Initialize
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection attributes)
        {
            base.Initialize(name, attributes);
            _siteMapFileName = attributes["siteMapFile"];
        }
        #endregion

        #region BuildSiteMap
        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if (null == _rootNode || m_RefreshSitemap)
                {
                    m_RefreshSitemap = false;
                    Clear();
                    XmlDocument siteMapXml = LoadSiteMapXml();
                    XmlElement rootElement = (XmlElement)siteMapXml.GetElementsByTagName(SiteMapNodeName)[0];
                    AddDynamicNodes(rootElement);
                    GenerateSiteMapNodes(rootElement);
                }
            }
            return _rootNode;
        }
        #endregion

        #region LoadSiteMapXml
        private XmlDocument LoadSiteMapXml()
        {
            XmlDocument siteMapXml = new XmlDocument();
            siteMapXml.Load(AppDomain.CurrentDomain.BaseDirectory + _siteMapFileName);
            return siteMapXml;
        }
        #endregion

        #region GenerateSiteMapNodes
        private void GenerateSiteMapNodes(XmlElement rootElement)
        {
            _rootNode = GetSiteMapNodeFromElement(rootElement);
            AddNode(_rootNode);
            CreateChildNodes(rootElement, _rootNode);
        }
        #endregion

        #region CreateChildNodes
        private void CreateChildNodes(XmlElement parentElement, SiteMapNode parentNode)
        {
            foreach (XmlNode xmlElement in parentElement.ChildNodes)
            {
                if (xmlElement.Name == SiteMapNodeName)
                {
                    SiteMapNode childNode = GetSiteMapNodeFromElement((XmlElement)xmlElement);
                    AddNode(childNode, parentNode);
                    CreateChildNodes((XmlElement)xmlElement, childNode);
                }
            }
        }
        #endregion

        #region AddDynamicNodes
        private void AddDynamicNodes(XmlElement rootElement)
        {

            //Add Page info to root
            //PagesBSO pagesBSO = new PagesBSO();
            //DataTable datatable = pagesBSO.GetPagesCate(Language.language);
            //if (datatable != null) 
            //{
            //    foreach(DataRow rows in datatable.Rows)
            //    {
            //        AddDynamicChildElement(rootElement, "~/Default2.aspx?goto=" + rows["PageName"].ToString(), rows["PageName"].ToString(), rows["PageName"].ToString());
            //    }
            //}

        }
        #endregion

        #region AddDynamicChildElement
        private static XmlElement AddDynamicChildElement(XmlElement parentElement, String url, String title, String description)
        {
            // Create new element from the parameters
            XmlElement childElement = parentElement.OwnerDocument.CreateElement(SiteMapNodeName);
            childElement.SetAttribute("url", url);
            childElement.SetAttribute("title", title);
            childElement.SetAttribute("description", description);

            // Add it to the parent
            parentElement.AppendChild(childElement);
            return childElement;
        }
        #endregion

        #region GetSiteMapNodeFromElement
        private SiteMapNode GetSiteMapNodeFromElement(XmlElement rootElement)
        {
            SiteMapNode newSiteMapNode;
            String url = rootElement.GetAttribute("url");
            String title = rootElement.GetAttribute("title");
            String description = rootElement.GetAttribute("description");

            // The key needs to be unique, so hash the url and title.
            newSiteMapNode = new SiteMapNode(this,
            (url + title).GetHashCode().ToString(), url, title, description);

            return newSiteMapNode;
        }
        #endregion

        #region GetRootNodeCore
        protected override SiteMapNode GetRootNodeCore()
        {
            return RootNode;
        }
        #endregion

        #region Clear
        protected override void Clear()
        {
            lock (this)
            {
                _rootNode = null;
                base.Clear();
            }
        }
        #endregion
    }
}
