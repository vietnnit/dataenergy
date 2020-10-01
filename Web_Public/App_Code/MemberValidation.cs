using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Net;
using ePower.Core;
using BSO;
using ETO;
public class MemberValidation : SSOInfo
{
    private string CookieOwnerName = "OwnerMemberName";
    private string CookieProcessIDName = "MemberProcessID";
    private string CookieInfo = "212322434234ASDSGDfdfdsfdsfsd16";
    private string _OwnerName;
    public string OwnerName
    {
        get
        {
            return _OwnerName;
        }
        set
        {
            SetCookie(CookieOwnerName, value.ToString());
        }
    }
    private int _ProcessID;
    public int ProcessID
    {
        get
        {
            return _ProcessID;
        }
        set
        {
            SetCookie(CookieProcessIDName, value.ToString());
        }
    }

    public MemberValidation()
    {
        GetMember(CookieOwnerName);

        string sValue = GetCookie(CookieOwnerName);
        //if (!string.IsNullOrEmpty(sValue))
        //{
        //    SetCookie(CookieOwnerName, sValue);
        //}

        if (sValue == "")
            _OwnerName = "";
        else
            _OwnerName = sValue;

        sValue = GetCookie(CookieProcessIDName);
        //if (!string.IsNullOrEmpty(sValue))
        //{
        //    SetCookie(CookieProcessIDName, sValue);
        //}
        if (sValue == "")
            _ProcessID = 0;
        else
            _ProcessID = int.Parse(sValue);

    }
    public int CheckLogin(string UserName, string PassWord)
    {
        SecurityBSO securityBSO = new SecurityBSO();
        int nRet = 1;
        AdminBSO adminBSO = new AdminBSO();
        Admin objUser = adminBSO.GetAdminByAccountPass(UserName, PassWord);

        if (objUser == null)
        {
            nRet = -1;
        }
        else if (objUser.AdminPass != securityBSO.EncPwd(PassWord))
        {
            nRet = -1;
        }
        if (nRet == -1)
            return nRet;

        return nRet;
    }
    public override bool IsSigned()
    {
        bool b = base.IsMemberSigned(CookieOwnerName);
        if (!b)
        {
            SignOut();
            return false;
        }
        return true;

    }

    public void SignIn(string _UserName, string _UserId, string OrgId, bool blRemember, string _SesionID)
    {
        base.MemberSignIn(CookieOwnerName, _UserName, _UserId, OrgId, blRemember, _SesionID);
    }
    public override void SignOut()
    {
        base.SignOut();
        base.SetCookie(CookieOwnerName, "");
        base.SetCookie(CookieProcessIDName, "");
    }

}
