using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class EmailBSO
    {
        public EmailBSO() 
        {
            //constructor
        }

        #region CreateEmail
        public void CreateEmail(Email email) 
        {
            EmailDAO emailDAO = new EmailDAO();
            emailDAO.CreateEmail(email);
        }
        #endregion

        #region UpdateEmail
        public void UpdateEmail(Email email) 
        {
            EmailDAO emailDAO = new EmailDAO();
            emailDAO.UpdateEmail(email);
        }
        #endregion

        #region DeleteEmail
        public void DeleteEmail(int Id) 
        {
            EmailDAO emailDAO = new EmailDAO();
            emailDAO.DeleteEmail(Id);
        }
        #endregion

        #region GetEmailById
        public Email GetEmailById(int Id) 
        {
            EmailDAO emailDAO = new EmailDAO();
            return emailDAO.GetEmailById(Id);
        }
        #endregion

        #region GetEmailAll
        public DataTable GetEmailAll() 
        {
            EmailDAO emailDAO = new EmailDAO();
            return emailDAO.GetEmailAll();
        }
        #endregion

        #region CheckExist
        public bool CheckExist(string EmailAddress)
        {
            bool exist = false;
            DataTable dataTable = GetEmailAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "EmailAddress = '" + EmailAddress + "'";
                if (dataView.Count > 0)
                    exist = true;
            }

            return exist;
        }
        #endregion
    }
}
