using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using DAO;

namespace BSO
{
    public class FaqsCateBSO
    {
       
        public FaqsCateBSO()
        {
            //constructor
        }

        #region CreateFaqsCate
        public void CreateCateNew(FaqsCate _faqsCate)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            _faqsCateDAO.CreateFaqsCate(_faqsCate);
        }
        #endregion

        #region CreateFaqsCateGet
        public int CreateCateNewGet(FaqsCate _faqsCate)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            return _faqsCateDAO.CreateFaqsCateGet(_faqsCate);
        }
        #endregion

        #region UpdateFaqsCate
        public void UpdateFaqsCate(FaqsCate _faqsCate)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            _faqsCateDAO.UpdateFaqsCate(_faqsCate);
        }
        #endregion

        #region GetFaqsCate
        public DataTable GetFaqsCate()
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            return _faqsCateDAO.GetFaqsCate();
        }
        #endregion

        #region GetFaqsCateById
        public FaqsCate GetFaqsCateById(int cId)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            return _faqsCateDAO.GetFaqsCateById(cId);
        }
        #endregion

        #region ExistName
        public bool ExistName(string catename)
        {
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateCheck", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return reader.HasRows;
                }
            }
        }
        #endregion

       
       

        //DeleteFaqsCate

        #region DeleteFaqsCateAll
        public void DeleteFaqsCateAll(int cateID)
        {
            //FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            try
            {
                DataTable table = GetFaqsCate();
                for (int m = 0; m < table.Rows.Count;m++ )
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["FaqsCateParentID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["FaqsCateID"]);
                    if (cateID == pParent)
                        this.DeleteFaqsCateAll(cCate);
                       // _faqsCateDAO.DeleteFaqsCate(cCate);
                }
          
               FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
                _faqsCateDAO.DeleteFaqsCate(cateID);
            }   
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
            
        }
        #endregion
        
        #region FaqsCateUpOrder
        /// <summary>
        /// Thay doi thu tu Danh muc
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="cOrder"></param>
        public void FaqsCateUpOrder(int cId, int cOrder) 
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            _faqsCateDAO.FaqsCateUpOrder(cId, cOrder);
        }
        #endregion

       
                
        //Cate Company

        #region getFaqsCateLevel
        public DataTable getFaqsCateLevel(int iCate)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", iCate);
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

        #region GetFaqsCateParentAll
        public DataTable GetFaqsCateParentAll(int Id)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            return _faqsCateDAO.GetFaqsCateParentAll(Id);
        }
        #endregion

        

        


        #region getFaqsCateClient
        public DataTable getFaqsCateClient(int iCate)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqsCateGetClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FaqsCateID", iCate);

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

        //Lay Cate theo nhom


        #region GetFaqsCateSearchName
        public DataTable GetFaqsCateSearchName(string _text)
        {
            FaqsCateDAO _faqsCateDAO = new FaqsCateDAO();
            return _faqsCateDAO.GetFaqsCateSearchName(_text);
        }
        #endregion


        
    }
}
