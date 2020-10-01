using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Net;

namespace ePower.Core
{
    public class SSOInfo
    {
        private string _CookieUserInfo = "eb4a3c8426d5a29404e4e148cc92af13";
        private string _SSODomain = Config.SSODomain;

        private RijndaelEnhanced rijndaelKey;
        private int _LifeTime = 60;     //15 phut
        private bool _FullControl = false;
        private bool _Remember = false;
        private int _UserId = 0;
        private bool _HidenMenuLeft = true;
        private string _UserName = "";
        private string _SessionID = "";
        private string _ClientIP = "";
        private int _OrgId = 0;
        private bool _IsExpires = true;
        private bool _isSuperAdmin = false;
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public bool FullControl
        {
            get { return _FullControl; }
            set { _FullControl = value; }
        }
        public bool Remember
        {
            get { return _Remember; }
            set { _Remember = value; }
        }
        public string SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }
        public string ClientIP
        {
            get { return _ClientIP; }
            set { _ClientIP = value; }
        }
        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }
        public void LifeTimeSetting(int TimeExpiresSetting)
        {
            _LifeTime = TimeExpiresSetting;
        }
        public bool HidenMenuLeft
        {
            get { return _HidenMenuLeft; }
            set { HidenMenuLeft = value; }
        }
        public bool isSuper
        {
            get { return _isSuperAdmin; }
            set { _isSuperAdmin = value; }
        }
        public SSOInfo()
        {
            rijndaelKey = new RijndaelEnhanced(Key.sKey, "@1B2c3D4e5F6g7H8");
        }

        public SSOInfo(string key)
        {
            rijndaelKey = new RijndaelEnhanced(key, "@1B2c3D4e5F6g7H8");
        }
        public virtual bool IsSigned()
        {
            this.Get();
            bool bLoged = (this._UserName.Length > 0 && this._ClientIP.Length > 0);
            //if (bLoged)
            //{
            //    this.SetCookieUserInfo(this._UserName, this._UserId.ToString(), this.Remember, this._SessionID, this._isSuperAdmin);
            //}
            return bLoged;
        }

        public void SignIn(string _UserName)
        {
            this.SetCookieUserInfo(_UserName, HttpContext.Current.Session.SessionID);
        }
        public void SignIn(string _UserName, string _SesionID)
        {
            this.SetCookieUserInfo(_UserName, _SesionID);
        }
        public void SignIn(string _UserName, string _UserId, string _fullControl, string blHidenMenuLeft, bool blRemember, string _SesionID, bool _isSuperadmin)
        {
            //if (this.IsSigned())
            //{
            //    System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Expires = DateTime.Now.AddMinutes(_LifeTime);
            //    System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].HttpOnly = true;
            //}
            //else
            //{
            this.SetCookieUserInfo(_UserName, _UserId, _fullControl, blHidenMenuLeft, blRemember, _SesionID, _isSuperadmin);
            //}
        }
        public void SignIn(string _UserName, string _UserId, int OrgId, string _SesionID, bool _isSuperadmin)
        {
            this.SetCookieUserInfo(_UserName, _UserId, OrgId, _SesionID, _isSuperadmin);
        }
        #region Member Method

        public void MemberSignIn(string cookiename, string _UserName, string _UserId, string OrgId, bool blRemember, string _SesionID)
        {
            this.SetCookieMemberInfo(cookiename, _UserName, _UserId, OrgId, blRemember, _SesionID);
        }
        private void SetCookieMemberInfo(string cookiename, string _strUsername, string _strUserId, string OrgId, bool blRemember, string _strSessionID)
        {
            string CookieValue = "";
            CookieValue += _strUsername;
            CookieValue += "|" + _strUserId;
            CookieValue += "|" + OrgId;
            CookieValue += "|" + blRemember;
            CookieValue += "|" + _strSessionID;
            CookieValue += "|" + DBCommon.ClientIP;
            CookieValue += "|" + DateTime.Now.AddMinutes(_LifeTime);
            SetCookie(cookiename, CookieValue);
        }
        private string[] GetCookieMemberInfo(string cookiename)
        {
            string[] CookieValue = new string[0];
            CookieValue = GetCookie(cookiename).Split(new char[] { '|' });
            return CookieValue;
        }

        public SSOInfo GetMember(string cookieName)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

            string[] CookieValueArray = GetCookieMemberInfo(cookieName);
            try
            {
                this._UserName = CookieValueArray[0];
                this._UserId = TypeHelper.ToInt32(CookieValueArray[1]);
                this._OrgId = TypeHelper.ToInt32(CookieValueArray[2]);
                this._Remember = TypeHelper.ToBoolean(CookieValueArray[3]);
                this._SessionID = CookieValueArray[4];
                this._ClientIP = CookieValueArray[5];
            }
            catch
            { this._ClientIP = DBCommon.ClientIP; }
            //try
            //{
            //    if (!String.IsNullOrEmpty(CookieValueArray[6]) && Convert.ToDateTime(CookieValueArray[6], ci) > DateTime.Now)
            //    {
            //        this._IsExpires = false;
            //    }
            //}
            //catch
            //{ this._IsExpires = false; }


            return this;
        }
        public virtual bool IsMemberSigned(string cookiename)
        {
            this.GetMember(cookiename);
            bool bLoged = (this._UserName.Length > 0 && this._ClientIP.Length > 0);
            return bLoged;
            //if (bLoged)
            //{
            //    this.SetCookieMemberInfo(cookiename, this._UserName, this._UserId.ToString(), this._OrgId, this.Remember, this._SessionID);
            //}
            //return bLoged;
        }
        #endregion

        public virtual void SignOut()
        {
            DelCookieUserInfo();
        }
        public SSOInfo Get()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

            string[] CookieValueArray = GetCookieUserInfo();
            try
            {
                this._UserName = CookieValueArray[0];
                this._UserId = TypeHelper.ToInt32(CookieValueArray[1]);
                this._OrgId = TypeHelper.ToInt32(CookieValueArray[2]);
                this._SessionID = CookieValueArray[3];
                this._ClientIP = CookieValueArray[4];
                this._isSuperAdmin = TypeHelper.ToBoolean(CookieValueArray[6]);
            }
            catch
            { this._ClientIP = DBCommon.ClientIP; }
            //try
            //{
            //    if (!String.IsNullOrEmpty(CookieValueArray[5]) && Convert.ToDateTime(CookieValueArray[5], ci) > DateTime.Now)
            //    {
            //        this._IsExpires = false;
            //    }
            //}
            //catch
            //{ this._IsExpires = false; }


            return this;
        }

        //ghi thong tin UserInfo
        public void SetCookie(string CookieName, string CookieValue)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[CookieName] != null)
                System.Web.HttpContext.Current.Response.Cookies.Set(System.Web.HttpContext.Current.Request.Cookies[CookieName]);
            else
                System.Web.HttpContext.Current.Response.Cookies.Set(new HttpCookie(CookieName, ""));

            System.Web.HttpContext.Current.Response.Cookies[CookieName].Value = rijndaelKey.Encrypt(CookieValue);
            if (!_SSODomain.Equals(""))
            {
                System.Web.HttpContext.Current.Response.Cookies[CookieName].Path = "/";
                System.Web.HttpContext.Current.Response.Cookies[CookieName].Domain = _SSODomain;
            }
            System.Web.HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddMonths(6);   // DateTime.Now.AddMinutes(_LifeTime);
            System.Web.HttpContext.Current.Response.Cookies[CookieName].HttpOnly = true;
        }
        public string GetCookie(string CookieName)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[CookieName] != null && System.Web.HttpContext.Current.Request.Cookies[CookieName].Value.ToString() != string.Empty)
            {
                try
                {
                    return rijndaelKey.Decrypt(System.Web.HttpContext.Current.Request.Cookies[CookieName].Value.ToString());
                }
                catch { }
                return string.Empty;
            }
            else
                return "";
        }
        private void SetCookieUserInfo(string UseNname, string SessionID)
        {
            string CookieValue = "";
            CookieValue += UseNname;
            CookieValue += "|" + SessionID;
            CookieValue += "|" + DBCommon.ClientIP;
            CookieValue += "|" + DateTime.Now.AddMinutes(_LifeTime);

            if (System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo] != null)
                System.Web.HttpContext.Current.Response.Cookies.Set(System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo]);
            else
                System.Web.HttpContext.Current.Response.Cookies.Set(new HttpCookie(_CookieUserInfo, ""));

            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Value = rijndaelKey.Encrypt(CookieValue);
            if (!_SSODomain.Equals(""))
            {
                System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Path = "/";
                System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Domain = _SSODomain;
            }
            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Expires = DateTime.Now.AddMonths(6);//DateTime.Now.AddMinutes(_LifeTime);
            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].HttpOnly = true;
        }
        private void SetCookieUserInfo(string _strUsername, string _strUserId, string _fullControl, string blHidenMenuLeft, bool blRemember, string _strSessionID, bool _isSuper)
        {
            string CookieValue = "";
            CookieValue += _strUsername;
            CookieValue += "|" + _strUserId;
            CookieValue += "|" + _fullControl;
            CookieValue += "|" + blHidenMenuLeft;
            CookieValue += "|" + blRemember;
            CookieValue += "|" + _strSessionID;
            CookieValue += "|" + DBCommon.ClientIP;
            CookieValue += "|" + DateTime.Now.AddMinutes(_LifeTime);
            CookieValue += "|" + _isSuper;
            if (System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo] != null)
                System.Web.HttpContext.Current.Response.Cookies.Set(System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo]);
            else
                System.Web.HttpContext.Current.Response.Cookies.Set(new HttpCookie(_CookieUserInfo, ""));

            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Value = rijndaelKey.Encrypt(CookieValue);
            if (!_SSODomain.Equals(""))
            {
                System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Path = "/";
                System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Domain = _SSODomain;
            }

            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Expires = DateTime.Now.AddMonths(6);

            System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].HttpOnly = true;
        }
        private void SetCookieUserInfo(string _strUsername, string _strUserId, int _OrgId, string _strSessionID, bool _isSuper)
        {
            string CookieValue = "";
            CookieValue += _strUsername;
            CookieValue += "|" + _strUserId;
            CookieValue += "|" + _OrgId;
            CookieValue += "|" + _strSessionID;
            CookieValue += "|" + DBCommon.ClientIP;
            CookieValue += "|" + DateTime.Now.AddMinutes(_LifeTime);
            CookieValue += "|" + _isSuper;
            SetCookie(_CookieUserInfo, CookieValue);
            //if (System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo] != null)
            //    System.Web.HttpContext.Current.Response.Cookies.Set(System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo]);
            //else
            //    System.Web.HttpContext.Current.Response.Cookies.Set(new HttpCookie(_CookieUserInfo, ""));

            //System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Value = rijndaelKey.Encrypt(CookieValue);
            //if (!_SSODomain.Equals(""))
            //{
            //    System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Path = "/";
            //    System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Domain = _SSODomain;
            //}

            //System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Expires = DateTime.MaxValue;

            //System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].HttpOnly = true;
        }
        private string[] GetCookieUserInfo()
        {
            string[] CookieValue = new string[0];
            if (System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo] != null)
            {
                try
                {
                    CookieValue = rijndaelKey.Decrypt(System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo].Value.ToString()).Split(new char[] { '|' });
                }
                catch
                {
                    CookieValue = "|||||".Split(new char[] { '|' });
                }
            }
            else
                CookieValue = "|||||".Split(new char[] { '|' });
            return CookieValue;
        }

        private void DelCookieUserInfo()
        {

            if (System.Web.HttpContext.Current.Request.Cookies[_CookieUserInfo] != null)
            {
                if (!_SSODomain.Equals(""))
                {
                    System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Domain = _SSODomain;
                }
                System.Web.HttpContext.Current.Response.Cookies[_CookieUserInfo].Expires = DateTime.Now.AddMonths(-1);
            }
        }
    }
}
