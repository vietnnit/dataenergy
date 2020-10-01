using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class MemberBSO
    {
        public MemberBSO() 
        {
            //constructor
        }
        #region CreateMember
        public void CreateMember(Member member)
        {
            MemberDAO memberDAO = new MemberDAO();
            memberDAO.CreateMember(member);
        }
        #endregion

        #region GetMemberById
        public Member GetMemberById(string UserName)
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetMemberById(UserName);
        }
        #endregion

        #region GetAllMember
        public DataTable GetAllMember()
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetAllMember();
        }
        #endregion

        #region UpdateMember
        public void UpdateMember(Member member)
        {
            MemberDAO memberDAO = new MemberDAO();
            memberDAO.UpdateMember(member);
        }
        #endregion

        #region DeleteMember
        public void DeleteMember(string UserName)
        {
            MemberDAO memberDAO = new MemberDAO();
            memberDAO.DeleteMember(UserName);
        }
        #endregion


        #region CheckExist
        public bool CheckExist(string UserName)
        {
            bool exist = false;
            DataTable dataTable = GetAllMember();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Username = '" + UserName + "'";
                if (dataView.Count > 0)
                    exist = true;
            }

            return exist;
        }
        #endregion

        #region CheckLoginMember
        public bool CheckLoginMember(string name, string pass)
        {
            bool login = false;
            SecurityBSO securityBSO = new SecurityBSO();
            pass = securityBSO.EncPwd(pass);
            DataTable dataTable = GetAllMember();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "UserName = '" + name + "' AND Password = '" + pass + "' AND Actived = 'True'";
                if (dataView.Count > 0)
                    login = true;
            }
            return login;
        }
        #endregion

        #region GetMemberByMemberId
        public Member GetMemberByMemberId(int memberID)
        {
            MemberDAO memberDAO = new MemberDAO();
            return memberDAO.GetMemberByMemberId(memberID);
        }
        #endregion

    }
}
