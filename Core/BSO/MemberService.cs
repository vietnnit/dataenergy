using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;
using ePower.DE.Dao;

namespace ePower.DE.Service
{
    public class MemberService
    {

        MemberDao memberDao = new MemberDao();
        public int Insert(Member obj)
        {
            MemberBO memberBO = new MemberBO(obj);
            return memberDao.Insert(memberBO);
        }
        public Member Update(Member obj)
        {
            MemberBO memberBO = new MemberBO(obj);
            memberDao.Update(memberBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return memberDao.Delete(_Id);
        }
        public Member FindByKey(int _Id)
        {
            return new Member(memberDao.FindByKey(_Id));
        }
        public IList<Member> FindAll()
        {
            IList<Member> list = new List<Member>();
            IList<MemberBO> listBO = new List<MemberBO>();
            listBO = memberDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (MemberBO obj in listBO)
                    list.Add(new Member(obj));
            return list;
        }
        public IList<Member> GetAccoutByEnterprise(int EnterpriseId)
        {
            return memberDao.GetAccoutByEnterprise(EnterpriseId);
        }
        public IList<Member> MemberLogin(int EnterpriseId)
        {
            return memberDao.GetAccoutByEnterprise(EnterpriseId);
        }
        public IList<Member> MemberLogin(string accountName, string passwordEncrypt)
        {
            return memberDao.MemberLogin(accountName, passwordEncrypt);
        }
        public IList<Member> GetMemberByAccount(string strAccountName)
        {
            return memberDao.GetMemberByAccount(strAccountName);
        }
        public IList<Member> GetMemberByEmail(string strEmail)
        {
            return memberDao.GetMemberByEmail(strEmail);
        }
        public bool ExistAccount(string strAccountName)
        {
            IList<Member> list = memberDao.GetMemberByAccount(strAccountName);
            if (list != null && list.Count > 0)
                return true;
            else
                return false;
        }
        public bool ExistEmail(string strEmail)
        {
            IList<Member> list = memberDao.GetMemberByEmail(strEmail);
            if (list != null && list.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable FindList(int OrgId, int EnterpriseId, bool? blIsActived, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {
            return memberDao.FindList(OrgId, EnterpriseId, blIsActived, FromDate, ToDate, keyword, paging);
        }
        public int ChangePass(string newPass, string oldPass, string AccountName)
        {
            return memberDao.ChangePass(newPass, oldPass, AccountName);
        }
                
    }
}
