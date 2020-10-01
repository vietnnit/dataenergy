using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using ETO;

namespace BSO
{
    public class AreaBSO
    {
        #region "Function Common"
        AreaDao organizationDAO = new AreaDao();

        public IList<AreaDTO> FindAll()
        {
            List<AreaDTO> listDTO = new List<AreaDTO>();
            IList<AreaBO> listBO = organizationDAO.FindAll();

            if (listBO != null && listBO.Count > 0)
            {
                foreach (AreaBO obj in listBO)
                {
                    listDTO.Add(new AreaDTO(obj));

                }
            }
            else return null;
            return listDTO;
        }
        public long Insert(AreaDTO entity)
        {
            return organizationDAO.Insert(new AreaBO(entity));
        }
        public int Delete(int _OrgID)
        {
            return organizationDAO.Delete(_OrgID);
        }

        public bool Update(AreaDTO entity)
        {
            if (organizationDAO.Update(new AreaBO(entity)) != null)
                return true;
            else return false;
        }

        public AreaDTO FindByID(int _OrgID)
        {
            return new AreaDTO(organizationDAO.FindByKey(_OrgID));
        }
        public DataTable GetAll()
        {
            return organizationDAO.GetAll();
        }
        #endregion
    }
}
