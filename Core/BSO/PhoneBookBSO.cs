using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class PhoneBookBSO
    {
        public PhoneBookBSO() 
        {
            //constructor
        }
        PhoneBookDAO objDAO = new PhoneBookDAO();
        public DataTable GetDepartMent()
        {
            return objDAO.GetDepartMent();
        }
        public DataTable GetListPhoneBook()
        {
            return objDAO.GetListPhoneBook();
        }
        public void CreatePhoneBook(PhoneBook _obj)
        {
            objDAO.CreatePhoneBook(_obj);
        }

        public DataTable GetDetial(int _id)
        {
            return objDAO.GetDetial(_id);
        }
        public void UpdatePhoneBook(PhoneBook _phoneBook)
        {
            objDAO.UpdatePhoneBook(_phoneBook);
        }
        public void Delete(int _Id)
        {
            objDAO.Delete(_Id);
        }

        public DataTable GetListPhoneBook(int _departMent, string _fullName)
        {
            return objDAO.GetListPhoneBook(_departMent,_fullName);
        }
        public void PhoneBookUpOrder(int _Id, int _Order)
        {
            objDAO.PhoneBookUpOrder(_Id, _Order);
        }
        public DataTable MixPhoneBook()
        {
            return objDAO.MixPhoneBook();
        }

        public DataTable PhoneBookGetParentID(int pID)
        {
            return objDAO.PhoneBookGetParentID(pID);
        }
        public DataTable PhoneBookGetAll()
        {
            return objDAO.PhoneBookGetAll();
        }

        public DataTable GetListPhoneBooks()
        {
            return objDAO.GetListPhoneBooks();
        }

    }
}
