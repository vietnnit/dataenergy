using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Net;
using System.Configuration;


namespace ePower.Core
{
    /// <summary>
    /// Summary description for Config
    /// </summary>
    public sealed class Config
    {
        private static readonly Config instance = new Config();
        private string _SSODomain;
        public static string SSODomain
        {
            get
            {
                return instance._SSODomain;
            }
        }
        private string _LoginURL;
        public static string LoginURL
        {
            get
            {
                return instance._LoginURL;
            }
        }
       
        private string _SQLConn;
        public static string SQLConn
        {
            get
            {
                return instance._SQLConn;
            }
        }
        private string _DomainName;
        public static string DomainName
        {
            get
            {
                return instance._DomainName;
            }
        }
        private string _SiteName;
        public static string SiteName
        {
            get
            {
                return instance._SiteName;
            }
        }
        private string _mediaFileTypes;
        public static string mediaFileTypes
        {
            get
            {
                return instance._mediaFileTypes;
            }
        }

        private string _imageFileTypes;
        public static string imageFileTypes
        {
            get
            {
                return instance._imageFileTypes;
            }
        }
        private int _maxStatus;
        public static int maxStatus
        {
            get
            {
                return instance._maxStatus;
            }
        }
        private string _mediaUrl;
        public static string mediaUrl
        {
            get
            {

                string sRet = instance._mediaUrl;
                if (!sRet.EndsWith("/"))
                    sRet += "/";
                return sRet;
            }
        }
        private string _mediaPath;
        public static string mediaPath
        {
            get
            {

                string sRet = instance._mediaPath;
                if (!sRet.EndsWith("/"))
                    sRet += "/";
                return sRet;
            }
        }
        private string _urlMediastore;
        public static string urlMediastore
        {
            get
            {

                string sRet = instance._urlMediastore;
                if (!sRet.EndsWith("/"))
                    sRet += "/";
                return sRet;
            }
        }
        private string _urlCss;
        public static string urlCss
        {
            get
            {

                string sRet = instance._urlCss;
                if (!sRet.EndsWith("/"))
                    sRet += "/";
                return sRet;
            }
        }
        private string _urlJs;
        public static string urlJs
        {
            get
            {

                string sRet = instance._urlJs;
                if (!sRet.EndsWith("/"))
                    sRet += "/";
                return sRet;
            }
        }
        Config()
        {
            _SSODomain = getAppStr("SSO_DOMAIN");
            _LoginURL = getAppStr("LOGIN_URL");
            //_SQLConn = getConnStr("SQLConn");            
            _DomainName = getAppStr("DomainName");
            _SiteName = getAppStr("SiteName");
            _mediaFileTypes = getAppStr("mediaFileTypes");
            _imageFileTypes = getAppStr("imageFileTypes");
            _maxStatus = int.Parse(getAppStr("maxStatus"));
            _mediaUrl = getAppStr("mediaUrl");
            _mediaPath = getAppStr("mediaPath");

            _urlMediastore = getAppStr("urlMediastore");
            _urlCss = getAppStr("urlCss");
            _urlJs = getAppStr("urlJs");

        }
        private string getConnStr(string Name)
        {
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced("ePower", "@1B2c3D4e5F6g7H8");
            return rijndaelKey.Decrypt(ConfigurationManager.ConnectionStrings[Name].ConnectionString);
        }
        private string getAppStr(string Name)
        {
            return ConfigurationManager.AppSettings[Name] == null ? string.Empty : ConfigurationSettings.AppSettings[Name].ToString();
        }
        private static Config Instance
        {
            get { return instance; }
        }
    }
}