using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class AdminBSO
    {
        public AdminBSO()
        {
            //constructor
        }

        #region CreateAdmin
        public int CreateAdmin(Admin admin)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.CreateAdmin(admin);
        }
        #endregion

        #region GetAdminById
        public Admin GetAdminById(string nameadmin)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminById(nameadmin);
        }
        public Admin GetAdminById(int id)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminById(id);
        }
        #endregion

        #region GetAllAdmin
        public DataTable GetAllAdmin()
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAllAdmin();
        }
        #endregion

        #region UpdateAdmin
        public void UpdateAdmin(Admin admin)
        {
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.UpdateAdmin(admin);
        }
        public int ChangePass(string newPass, string oldPass, int Admin_id)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.ChangePass(newPass, oldPass, Admin_id);
        }
        #endregion

        #region DeleteAdmin
        public void DeleteAdmin(string adminname)
        {
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.DeleteAdmin(adminname);
        }
        public void DeleteAdmin(int adminID)
        {
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.DeleteAdmin(adminID);
        }
        #endregion


        #region CheckExist
        public bool CheckExist(string adminname)
        {
            bool exist = false;
            DataTable dataTable = GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Admin_Username = '" + adminname + "'";
                if (dataView.Count > 0)
                    exist = true;
            }

            return exist;
        }
        #endregion

        #region CheckExistEmail
        public bool CheckExistEmail(string email)
        {
            bool exist = false;
            DataTable dataTable = GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Admin_Email = '" + email + "'";
                if (dataView.Count > 0)
                    exist = true;
            }

            return exist;
        }
        #endregion

        #region CheckLoginAdmin
        public bool CheckLoginAdmin(string name, string pass)
        {
            bool login = false;
            SecurityBSO securityBSO = new SecurityBSO();
            pass = securityBSO.EncPwd(pass);

            AdminDAO adminDAO = new AdminDAO();
            Admin _admin = adminDAO.GetAdminByAccountPass(name, pass);

            if (_admin != null)
                login = true;

            return login;
        }
        #endregion

        #region GetAdminByAccountPass
        public Admin GetAdminByAccountPass(string name, string pass)
        {
            SecurityBSO securityBSO = new SecurityBSO();
            pass = securityBSO.EncPwd(pass);

            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByAccountPass(name, pass);

        }
        #endregion
        #region GetAdminByEmail
        public Admin GetAdminByEmail(string email)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByEmail(email);

        }
        #endregion

        #region CheckUserName
        public bool CheckUserName(string name)
        {
            bool login = false;
            DataTable dataTable = GetAllAdmin();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Admin_Username = '" + name + "' AND Admin_Actived = 'True'";
                if (dataView.Count > 0)
                    login = true;
            }
            return login;
        }
        #endregion

        //#region CheckPermission
        //public bool CheckPermission(string name, string permission)
        //{
        //    bool check = false;
        //    //Admin admin = new Admin();
        //    //admin = GetAdminById(name);
        //    //string strPermission = admin.AdminPermission;

        //    AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
        //    //string strRoles = adminRolesBSO.GetRoles(AdminName);
        //    //RolesBSO rolesBSO = new RolesBSO();
        //    DataTable table1 = adminRolesBSO.GetAdminRolesByUserName(name);

        //    string strPermission = "";

        //    if (table1.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in table1.Rows)
        //        {
        //            strPermission += row["Roles_Modules"].ToString();
        //        }

        //    }

        //    strPermission = strPermission.Replace(",", "','");
        //    int i = strPermission.IndexOf(permission);
        //    if (i != -1)
        //        check = true;

        //    return check;
        //}
        //#endregion

        #region CheckPermission
        public bool CheckPermission(string name, string permission)
        {
            bool check = false;
            Admin admin = new Admin();
            admin = GetAdminById(name);
            string strPermission = admin.AdminPermission;

            strPermission = strPermission.Replace(",", "','");
            int i = strPermission.IndexOf(permission);
            if (i != -1)
                check = true;

            return check;
        }
        #endregion

        //#region CheckPermissionRoles
        //public bool CheckPermissionRoles(string name, string permission, string modulename)
        //{
        //    bool check = false;
        //    AdminRolesBSO adminRolesBSO = new AdminRolesBSO();

        //    Admin admin = new Admin();
        //    admin = GetAdminById(name);
        //    string strPermission = admin.AdminPermission;

        //    strPermission = strPermission.Replace(",", "','");
        //    int i = strPermission.IndexOf(permission);
        //    if (i != -1)
        //        check = true;

        //    return check;
        //}
        //#endregion

        #region GetAllAdminRoles
        public DataTable GetAllAdminRoles()
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAllAdminRoles();
        }
        #endregion

        #region UpdateAdminLog
        public void UpdateAdminLog(string name, DateTime log)
        {
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.UpdateAdminLog(name, log);
        }
        #endregion

        #region AdminGetRolesByID
        public DataTable AdminGetRolesByID(int rolesID)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.AdminGetRolesByID(rolesID);
        }
        #endregion

        #region AdminAllGetRolesByID
        public DataTable AdminGetAllRolesByID(int rolesID)
        {
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.AdminGetAllRolesByID(rolesID);
        }
        #endregion

        #region GetAdminByCateHomeList
        public DataTable GetAdminByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByCateHomeList(restr);
        }
        #endregion

        #region GetAdminBystrName
        public DataTable GetAdminBystrName(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AdminDAO adminDAO = new AdminDAO();
            return adminDAO.GetAdminByStrName(restr);
        }
        #endregion

        #region GetStrAdmin
        public string GetStrAdmin()
        {
            DataTable table = new DataTable();
            table = GetAllAdmin();

            string strID = "";

            if (table.Rows.Count > 0)
            {
                foreach (DataRow subrow in table.Rows)
                {
                    strID += subrow["Admin_UserName"].ToString() + ",";
                }
            }

            return strID;
        }
        #endregion
    }
}
