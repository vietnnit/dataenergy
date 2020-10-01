using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class PictureBSO
    {
        public PictureBSO() 
        {
            //constructor
        }

        #region CreatePicture
        public void CreatePicture(Picture picture) 
        {
            PictureDAO pictureDAO = new PictureDAO();
            pictureDAO.CreatePicture(picture);
        }
        #endregion

        #region UpdatePicture
        public void UpdatePicture(Picture picture) 
        {
            PictureDAO pictureDAO = new PictureDAO();
            pictureDAO.UpdatePicture(picture);
        }
        #endregion

        #region DeletePicture
        public void DeletePicture(int Id) 
        {
            PictureDAO pictureDAO = new PictureDAO();
            pictureDAO.DeletePicture(Id);
        }
        public void DeletePicture(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            PictureDAO pictureDAO = new PictureDAO();
            pictureDAO.DeletePicture(restr);
        }
        #endregion

        #region GetPictureByProduct
        public DataTable GetPictureByProduct(int pId) 
        {
            PictureDAO pictureDAO = new PictureDAO();
            return pictureDAO.GetPictureByProduct(pId);

        }
        #endregion

        #region GetPictureByID
        public Picture GetPictureByID(int Id)
        {
            PictureDAO pictureDAO = new PictureDAO();
            return pictureDAO.GetPictureById(Id);

        }
        #endregion

        #region GetPictureByAll
        public DataTable GetPictureByAll()
        {
            PictureDAO pictureDAO = new PictureDAO();
            return pictureDAO.GetPictureByAll();

        }
        #endregion

        #region PictureUpOrder
        public void PictureUpOrder(int cId, int cOrder)
        {
            PictureDAO pictureDAO = new PictureDAO();
            pictureDAO.PictureUpOrder(cId, cOrder);
        }
        #endregion
    }
}
