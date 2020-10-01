using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETO;
using DAO;

namespace BSO
{
    public class DocTypeBSO
    {
        #region "Function Common"
        DocTypeDao typesDAO = new DocTypeDao();

        public IList<DocTypeDTO> FindAll()
        {
            List<DocTypeDTO> listDTO = new List<DocTypeDTO>();
            IList<DocTypeBO> listBO = typesDAO.FindAll();

            if (listBO != null && listBO.Count > 0)
            {
                foreach (DocTypeBO obj in listBO)
                {
                    listDTO.Add(new DocTypeDTO(obj));

                }
            }
            else return null;
            return listDTO;
        }
        public long Insert(DocTypeDTO entity)
        {
            return typesDAO.Insert(new DocTypeBO(entity));
        }
        public int Delete(int _TypeID)
        {
            return typesDAO.Delete(_TypeID);
        }
        public bool Update(DocTypeDTO entity)
        {
            if (typesDAO.Update(new DocTypeBO(entity)) != null)
                return true;
            else
                return false;
        }
        public DocTypeDTO FindByID(int _TypeID)
        {
            return new DocTypeDTO(typesDAO.FindByKey(_TypeID));
        }
        #endregion
    }
}
