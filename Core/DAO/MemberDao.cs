using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;

namespace ePower.DE.Dao
{
    public class MemberDao : EntityDao<MemberBO>
    {
        public IList<Member> GetAccoutByEnterprise(int EnterpriseId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@EnterpriseId", EnterpriseId);
            try
            {
                return new Db().GetList<Member>("SELECT * FROM  DE_Member WHERE EnterpriseId=@EnterpriseId AND IsDelete=0", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public IList<Member> GetMemberByAccount(string strAccountName)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@AccountName", strAccountName);
            try
            {
                return new Db().GetList<Member>("SELECT * FROM  " + new MemberBO().TableName + " WHERE AccountName=@AccountName", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IList<Member> GetMemberByEmail(string strEmail)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@Email", strEmail);
            try
            {
                return new Db().GetList<Member>("SELECT * FROM  " + new MemberBO().TableName + " WHERE Email=@Email", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public IList<Member> MemberLogin(string accountName, string passwordEncrypt)
        {
            DbParameter[] parameter = new DbParameter[2];
            parameter[0] = new DbParameter("@AccountName", accountName);
            parameter[1] = new DbParameter("@Password", passwordEncrypt);

            try
            {
                string sql = "SELECT a.* FROM  DE_Member a inner join DE_Enterprise b on a.EnterpriseId = b.Id WHERE ";
                sql += "(b.TaxCode=@AccountName AND a.Password=@Password AND a.IsActive=1 AND a.IsDelete=0) or ";
                sql += "(a.AccountName=@AccountName AND a.Password=@Password AND a.IsActive=1 AND a.IsDelete=0)";
                return new Db().GetList<Member>(sql, parameter, System.Data.CommandType.Text);
                //return new Db().GetList<Member>("SELECT * FROM  DE_Member WHERE AccountName=@AccountName AND Password=@Password AND IsActive=1 AND IsDelete=0", parameter, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataTable FindList(int OrgId, int EnterpriseId, bool? blIsActived, DateTime? FromDate, DateTime? ToDate, string keyword, PagingInfo paging)
        {            
            DbParameter[] parameter = new DbParameter[8];
            parameter[0] = new DbParameter("@OrgId", OrgId);
            if (FromDate != null)
                parameter[1] = new DbParameter("@FromDate", FromDate);
            else
                parameter[1] = new DbParameter("@FromDate", DBNull.Value);
            if (ToDate != null)
                parameter[2] = new DbParameter("@ToDate", ToDate);
            else
                parameter[2] = new DbParameter("@ToDate", DBNull.Value);
            parameter[3] = new DbParameter("@Keyword", keyword);
            parameter[4] = new DbParameter("@CurrentPage", paging.CurrentPage);
            parameter[5] = new DbParameter("@PageSize", paging.PageSize);

            if (blIsActived != null)
                parameter[6] = new DbParameter("@IsActive", blIsActived);
            else
                parameter[6] = new DbParameter("@IsActive", DBNull.Value);
            parameter[7] = new DbParameter("@EnterpriseId", EnterpriseId);

            try
            {
                return new Db().GetDataTable("Get_Member_Find", parameter, System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int ChangePass(string newPass, string oldPass, string accountname)
        {

            DbParameter[] parameter = new DbParameter[3];
            parameter[0] = new DbParameter("@NewPass", newPass);

            parameter[1] = new DbParameter("@OldPass", oldPass);

            parameter[2] = new DbParameter("@AccountName", accountname);
            try
            {
                //return new Db().Update("UPDATE DE_Member SET Password = @NewPass WHERE AccountName=@AccountName AND Password=@OldPass", parameter, System.Data.CommandType.Text);
                return new Db().Update("Member_PasswordChanged", parameter, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
