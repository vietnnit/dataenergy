using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Web;
using ETO;
namespace DAO
{
    public class PhoneBookDAO : BaseDAO
    {
        public DataTable GetDepartMent()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where ParentId=0 Order by [Orders]";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable PhoneBookGetParentID(int parentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where ParentId=" + parentID +" Order by [Orders]";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }



        public void CreatePhoneBook(PhoneBook _phoneBook)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("CreatePhoneBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FullName", _phoneBook.FullName);
                command.Parameters.AddWithValue("@Email", _phoneBook.Email);
                command.Parameters.AddWithValue("@Phone1", _phoneBook.Phone1);

                command.Parameters.AddWithValue("@Phone2", _phoneBook.Phone2);
                command.Parameters.AddWithValue("@HomePhone", _phoneBook.HomePhone);

                command.Parameters.AddWithValue("@Officephone", _phoneBook.Officephone);
                command.Parameters.AddWithValue("@Address", _phoneBook.Address);

                command.Parameters.AddWithValue("@ParentId", _phoneBook.ParentId);
                command.Parameters.AddWithValue("@CreatorId", _phoneBook.CreatorId);
                command.Parameters.AddWithValue("@Orders", _phoneBook.Orders);
                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public DataTable GetListPhoneBook()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable PhoneBookGetAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }


        public DataTable GetDetial(int _id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where Id= " + _id;
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void UpdatePhoneBook(PhoneBook _phoneBook)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("UpdatePhoneBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FullName", _phoneBook.FullName);
                command.Parameters.AddWithValue("@Email", _phoneBook.Email);
                command.Parameters.AddWithValue("@Phone1", _phoneBook.Phone1);

                command.Parameters.AddWithValue("@Phone2", _phoneBook.Phone2);
                command.Parameters.AddWithValue("@HomePhone", _phoneBook.HomePhone);

                command.Parameters.AddWithValue("@Officephone", _phoneBook.Officephone);
                command.Parameters.AddWithValue("@Address", _phoneBook.Address);

                command.Parameters.AddWithValue("@ParentId", _phoneBook.ParentId);
                command.Parameters.AddWithValue("@Id", _phoneBook.Id);
                command.Parameters.AddWithValue("@Orders", _phoneBook.Orders);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Lỗi không thể tao moi");
                else
                    command.Dispose();
            }
        }

        public void Delete(int _Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = " Delete tblPhoneBook Where Id= " + _Id;
                SQL = SQL + " Delete tblPhoneBook Where ParentId =" + _Id;
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            
        }


        public DataTable GetListPhoneBook(int _departMent,string _fullName)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "SELECT * FROM tblPhoneBook Where 1=1 ";
                string _cond = "";
               
                if (_departMent <= 0)
                {
                    SQL = "select *,";
                    SQL += "(select Fullname from tblPhoneBook as A1";
                    SQL += "    where A1.Id=A.ParentId  ";
                    SQL += ") AS GruopFull";

                    SQL += ",";
                    SQL += "(";
                    SQL += "    select Orders from tblPhoneBook as A3";
	                SQL += "    where A3.Id=A.ParentId  ";
                    SQL += ") AS Orders1 ";

                    SQL += " from tblPhoneBook AS A ";
                    SQL += " Where ParentId IN ";
                    SQL += "(";
                    SQL += "   select Top(100000) ParentId From tblPhoneBook";
                    SQL += "  Where ParentId!=0 ORDER BY Orders ";
                    SQL += ")";
                }
                else
                {
                    SQL = "select *,";
                    SQL += "(select Fullname from tblPhoneBook as A1";
                    SQL += "    where A1.Id=A.ParentId";
                    SQL += ") AS GruopFull";

                    SQL += ",";
                    SQL += "(";
	                SQL += "    select Orders from tblPhoneBook as A3";
	                SQL += "    where A3.Id=A.ParentId  ";
                    SQL += ") AS Orders1 ";

                    SQL += " from tblPhoneBook AS A ";
                    SQL += " Where ParentId IN ";
                    SQL += "(";
                    SQL += "   select Top(100000) ParentId From tblPhoneBook";
                    SQL += "  Where ParentId!=0 ORDER BY Orders ";
                    SQL += ")";
                    _cond += " AND ParentId=" + _departMent;
                }
                if (_fullName.Trim() != "")
                {
                    _cond += " AND FullName Like'%" + _fullName+ "%'";
                }
                SQL += _cond +" Order by Orders1 ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        #region PhoneBookUpOrder
        public void PhoneBookUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_PhoneBookUpOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", cId);
                command.Parameters.AddWithValue("@Orders", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Không thể cập nhật danh mục tin");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region MixPhoneBook
        public DataTable MixPhoneBook()
        {
          //  DataTable table1 = new DataTable();
            
            DataTable table2 = PhoneBookGetParentID(0);

            DataTable table1 = table2.Clone();

            foreach (DataRow r2 in table2.Rows)
            {

                table1.ImportRow(r2);
                this.SubMixPhoneBook(table1, Convert.ToInt32(r2["ID"]), "");
            }
            return table1;
        }
        #endregion

        #region SubMixPhoneBook
        public void SubMixPhoneBook(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();

            subTable = PhoneBookGetParentID(mID);

            if (subTable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subTable.Rows)
                {
                    subrow["FullName"] = sSpace + subrow["FullName"].ToString();

                    table.ImportRow(subrow);
                    this.SubMixPhoneBook(table, Convert.ToInt32(subrow["ID"]), "");
                }
            }
            
        }
        #endregion

        public DataTable GetListPhoneBooks()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string SQL = "";
             //   string _cond = "";

                SQL = " select *,''Level1 ";
                SQL += "    ,(select FullName from V_PhoneBook A1 Where A1.Id= A.parentId)	AS GruopFull ";
                SQL += "     from dbo.tblPhoneBook A ";

                SQL += SQL + " ORDER BY [Orders] ASC ";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

    }
}
