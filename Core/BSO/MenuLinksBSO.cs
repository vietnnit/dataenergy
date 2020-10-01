using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using ETO;
using DAO;
namespace BSO
{
    public class MenuLinksBSO
    {
        public MenuLinksBSO()
        {
            //Constructor
        }


        #region AddMenuLinks
        public int AddMenuLinks(MenuLinks _menuLinks)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.CreateMenuLinks(_menuLinks);

        }
        #endregion

        #region EditMenuLinks
        public int EditMenuLinks(MenuLinks _menuLinks)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.UpdateMenuLinks(_menuLinks);
        }
        #endregion

        #region GetAllMenuLinks
        public DataTable GetAllMenuLinks(string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetAllMenuLinks(_lang);
        }
        #endregion

        #region MixMenuLinks
        public DataTable MixMenuLinks(string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.MixMenuLinks(_lang);
        }
        #endregion

        #region MixMenuLinksBullet
        public DataTable MixMenuLinksBullet(string bullet, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.MixMenuLinksBullet(bullet,_lang);
        }
        #endregion

        #region GetMenuLinksById
        public MenuLinks GetMenuLinksById(int mID)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetMenuLinksById(mID);
        }
        #endregion

        #region GetMenuLinksByUrl
        public MenuLinks GetMenuLinksByUrl(string url, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetMenuLinksByUrl(url, _lang);
        }
        #endregion

        #region DeleteMenuLinks
        public void DeleteMenuLinks(int mID)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            menuLinksDAO.DeleteMenuLinks(mID);
        }
        #endregion

        #region CheckExist
        public bool CheckExist(string menuLinksName, string _lang)
        {
            bool name = false;
            DataTable dataTable = GetAllMenuLinks(_lang);
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "MenuLinksUrl = '" + menuLinksName + "'";
                if (dataView.Count > 0)
                    name = true;
            }
            return name;

        }
        #endregion

        #region MenuLinksUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void MenuLinksUpOrder(int cId, int cOrder)
        {
            MenuLinksDAO menulinksDAO = new MenuLinksDAO();
            menulinksDAO.MenuLinksUpOrder(cId, cOrder);
        }
        #endregion

        #region GetHotMenuLinks
        public DataTable GetHotMenuLinks(string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks(_lang);
        }
        #endregion

        #region GetHotMenuLinks
        public DataTable GetHotMenuLinks(int num, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks(num, _lang);
        }
        public DataTable GetHotMenuLinks(string position, int num, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks(position, num,_lang);
        }

        public DataTable GetHotMenuLinks(string position, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks(position, _lang);
        }

        public DataTable GetRootMenuLinks(string position, string _lang)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetRootMenuLinks(position, _lang);
        }
        public DataTable GetMenuByParent(int ParentId)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetMenuByParent(ParentId);
        }
        
        #endregion

        #region getCateClient
        public DataTable getCateClient(int iCate, string _lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MenuLinksParent", iCate);
                command.Parameters.AddWithValue("@Language", _lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();

                }
            }

            return table;
        }
        #endregion

        #region MenuLinksClickUpdate
        public void MenuLinksClickUpdate(int nId)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            menuLinksDAO.MenuLinksClickUpdate(nId);
        }
        #endregion
    }



}
