using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using ETO;

namespace BSO
{
    public class OfficeRelateBSO
    {
        #region "Function Common"
        OfficeRelateDao organizationDAO = new OfficeRelateDao();

        public IList<OfficeRelateDTO> FindAll()
        {
            List<OfficeRelateDTO> listDTO = new List<OfficeRelateDTO>();
            IList<OfficeRelateBO> listBO = organizationDAO.FindAll();

            if (listBO != null && listBO.Count > 0)
            {
                foreach (OfficeRelateBO obj in listBO)
                {
                    listDTO.Add(new OfficeRelateDTO(obj));

                }
            }
            else return null;
            return listDTO;
        }

        public long Insert(OfficeRelateDTO entity)
        {
            return organizationDAO.Insert(new OfficeRelateBO(entity));
        }
        public int Delete(int _OrgID)
        {
            return organizationDAO.Delete(_OrgID);
        }
        public int DeleteDocRelate(int DocId, int DocRelateId)
        {
            return organizationDAO.DeleteDocRelate(DocId, DocRelateId);
        }
        public bool Update(OfficeRelateDTO entity)
        {

            if (organizationDAO.Update(new OfficeRelateBO(entity)) != null)
                return true;
            else
                return false;
        }

        public OfficeRelateDTO FindByID(int _OrgID)
        {
            return new OfficeRelateDTO(organizationDAO.FindByKey(_OrgID));
        }
        public DataTable GetDocRelate(int DocId)
        {
            return organizationDAO.GetDocRelate(DocId);
        }
        #endregion
    }
}
