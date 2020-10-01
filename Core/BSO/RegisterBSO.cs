using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class RegisterBSO
    {
        public RegisterBSO() 
        {
            //constructor
        }
        #region CreateRegister
        public void CreateRegister(Register _register)
        {
            RegisterDAO _registerDAO = new RegisterDAO();
            _registerDAO.CreateRegister(_register);
        }
        #endregion

        #region GetRegisterById
        public Register GetRegisterById(int _register)
        {
            RegisterDAO _registerDAO = new RegisterDAO();
            return _registerDAO.GetRegisterById(_register);
        }
        #endregion

        #region GetAllRegister
        public DataTable GetAllRegister()
        {
            RegisterDAO _registerDAO = new RegisterDAO();
            return _registerDAO.GetAllRegister();
        }
        #endregion

        #region UpdateRegister
        public void UpdateRegister(Register _register)
        {
            RegisterDAO _registerDAO = new RegisterDAO();
            _registerDAO.UpdateRegister(_register);
        }
        #endregion

        #region DeleteRegister
        public void DeleteRegister(int _register)
        {
            RegisterDAO _registerDAO = new RegisterDAO();
            _registerDAO.DeleteRegister(_register);
        }
        #endregion


        
    }
}
