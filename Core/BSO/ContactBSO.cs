using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class ContactBSO
    {
        public ContactBSO()
        {
            //constructor
        }


        #region CreateContact
        public void CreateContact(Contact contact)
        {
            ContactDAO contactDAO = new ContactDAO();
            contactDAO.CreateContact(contact);
        }
        #endregion

        #region UpdateContact
        public void UpdateContact(Contact contact)
        {
            ContactDAO contactDAO = new ContactDAO();
            contactDAO.UpdateContact(contact);
        }
        #endregion



        #region DeleteContact
        public void DeleteContact(int Id)
        {
            ContactDAO contactDAO = new ContactDAO();
            contactDAO.DeleteContact(Id);
        }
        #endregion

        #region GetContactById
        public Contact GetContactById(int Id)
        {
            ContactDAO contactDAO = new ContactDAO();
            return contactDAO.GetContactById(Id);
        }
        #endregion

        #region GetContactAll
        public DataTable GetContactAll()
        {
            ContactDAO contactDAO = new ContactDAO();
            return contactDAO.GetContactAll();
        }
        #endregion

   
    }
}
