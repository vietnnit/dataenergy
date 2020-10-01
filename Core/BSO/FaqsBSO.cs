using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;

namespace BSO
{
    public class FaqsBSO
    {
        public FaqsBSO() 
        {
            //constructor
        }
        #region CreateFaqs
        public void CreateFaqs(Faqs _faqs)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.CreateFaqs(_faqs);
        }

        public int CreateFaqsGet(Faqs _faqs)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.CreateFaqsGet(_faqs);
        }
        #endregion

        #region GetFaqsById
        public Faqs GetFaqsById(int Id)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsById(Id);
        }
        #endregion

        #region GetAllFaqs
        public DataTable GetAllFaqs()
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetAllFaqs();
        }
        #endregion

        #region UpdateFaqs
        public void UpdateFaqs(Faqs _faqs)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.UpdateFaqs(_faqs);
        }
        #endregion

        #region DeleteFaqs
        public void DeleteFaqs(int Id)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.DeleteFaqs(Id);
        }
        public void DeleteFaqs(string sId)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.DeleteFaqs(sId);
        }
        #endregion

         #region GetFaqsGetFaqsCateName

        public DataTable GetFaqsGetFaqsCateName(string username)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsGetFaqsCateName(username);
        }

         #endregion

        #region UpdateFaqsApproval
        public void UpdateFaqsApproval(string strId, string actived, string username, DateTime date)
        {
            if (strId != "")
                strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.UpdateFaqsApproval(strId, actived, username, date);
        }
        public void UpdateFaqsApproval(int Id, string actived, string username, DateTime date)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            _faqsDAO.UpdateFaqsApproval(Id, actived, username, date);
        }
        #endregion



        #region GetFaqsByFaqsCateID
        public DataTable GetFaqsByFaqsCateID(int Id)
        {
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsByFaqsCateID(Id);
        }

        public DataTable GetFaqsByFaqsCateID(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsByFaqsCateID(restr);
        }


         #endregion


        #region GetFaqsPaging
        public DataTable GetFaqsPaging(int _FaqsCateID, string _strFaqsCateID, string _Title, string _Fullname, string _Phone, int _actived, PagingInfo _paging)
        {
            string restr ="";
            if(_strFaqsCateID != "")
                restr = _strFaqsCateID.Remove(_strFaqsCateID.LastIndexOf(",")).Replace(",", "','");
           
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsPaging(_FaqsCateID, restr, _Title, _Fullname, _Phone, _actived, _paging);
        }
        public DataTable GetFaqsParentPaging(int _parentFaqsID, int _FaqsCateID, string _strFaqsCateID, string _Title, string _Fullname, string _Phone, int _actived, PagingInfo _paging)
        {
            string restr = "";
            if (_strFaqsCateID != "")
                restr = _strFaqsCateID.Remove(_strFaqsCateID.LastIndexOf(",")).Replace(",", "','");

            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.GetFaqsParentPaging(_parentFaqsID, _FaqsCateID, restr, _Title, _Fullname, _Phone, _actived, _paging);
        }
        public DataTable FaqsSearchPaging(string finter, PagingInfo _paging)
        {
           
            FaqsDAO _faqsDAO = new FaqsDAO();
            return _faqsDAO.FaqsSearchPaging(finter, _paging);
        }

        #endregion

    }
}
