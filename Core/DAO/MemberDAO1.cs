using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class MemberDAO : BaseDAO
    {
        public MemberDAO() 
        {
            //constructor
        }

        #region MemberReader
        private Member MemberReader(SqlDataReader reader)
        {
            Member member = new Member();
            member.MemberID = (int)reader["MemberID"];
            member.UserName = (string)reader["UserName"];
            member.Password = (string)reader["Password"];
            member.FullName = (string)reader["FullName"];
            member.Email = (string)reader["Email"];
            member.Phone = (string)reader["Phone"];
            member.Address = (string)reader["Address"];
            member.Birth = (DateTime)reader["Birth"];
            member.Actived = (bool)reader["Actived"];
            member.Sex = (bool)reader["Sex"];
            member.NickYahoo = (string)reader["NickYahoo"];
            member.NickSkype = (string)reader["NickSkype"];
            member.Avatar = (string)reader["Avatar"];

            return member;
        }
        #endregion

        #region GetAllMember
        public DataTable GetAllMember()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }
        #endregion

        #region GetMemberById
        public Member GetMemberById(string UserName)
        {
            Member member = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        member = MemberReader(reader);
                    else
                        throw new DataAccessException("khong ton tai member");
                }
                command.Dispose();

            }
            return member;
        }
        #endregion

        #region CreateMember
        public void CreateMember(Member member)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@MemberID", 0);
                command.Parameters.AddWithValue("@Username", member.UserName);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@FullName", member.FullName);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.Parameters.AddWithValue("@Birth", member.Birth);
                command.Parameters.AddWithValue("@Actived", member.Actived);
                command.Parameters.AddWithValue("@Sex", member.Sex);
                command.Parameters.AddWithValue("@NickYahoo", member.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", member.NickSkype);
                command.Parameters.AddWithValue("@Avatar", member.Avatar);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region UpdateMember
        public void UpdateMember(Member member)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@MemberID", member.MemberID);
                command.Parameters.AddWithValue("@Username", member.UserName);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@FullName", member.FullName);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.Parameters.AddWithValue("@Birth", member.Birth);
                command.Parameters.AddWithValue("@Actived", member.Actived);
                command.Parameters.AddWithValue("@Sex", member.Sex);
                command.Parameters.AddWithValue("@NickYahoo", member.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", member.NickSkype);
                command.Parameters.AddWithValue("@Avatar", member.Avatar);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region DeleteMember
        public void DeleteMember(string UserName)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberDelete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể xóa member");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetMemberByMemberId
        public Member GetMemberByMemberId(int memberID)
        {
            Member member = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_MemberGetByMemberId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MemberID", memberID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        member = MemberReader(reader);
                    else
                        throw new DataAccessException("khong ton tai member");
                }
                command.Dispose();

            }
            return member;
        }
        #endregion
    }
}
