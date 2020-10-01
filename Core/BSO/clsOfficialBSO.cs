using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using DAO;
namespace BSO
{
    public class OfficialBso
    {
        public OfficialBso()
        {
            //Constructor
        }
        OfficialDao typesDAO = new OfficialDao();
        public DataTable FindList(string Keywords, int groupdoc, int cateid,int agentId, int doctypeId, int AreaId, bool? Status, string lang, DateTime? fromDate, DateTime? toDate, ePower.Core.PagingInfo paging)
        {
            return typesDAO.FindList(Keywords, groupdoc, cateid,agentId, doctypeId, AreaId, Status, lang, fromDate, toDate, paging);
        }
        public IList<OfficialDTO> FindAll()
        {
            List<OfficialDTO> listDTO = new List<OfficialDTO>();
            IList<OfficialBO> listBO = typesDAO.FindAll();

            if (listBO != null && listBO.Count > 0)
            {
                foreach (OfficialBO obj in listBO)
                {
                    listDTO.Add(new OfficialDTO(obj));
                }
            }
            else return null;
            return listDTO;
        }

        public long Insert(OfficialDTO entity)
        {
            return typesDAO.Insert(new OfficialBO(entity));
        }
        public int Delete(int _TypeID)
        {
            return typesDAO.Delete(_TypeID);
        }
        public bool Update(OfficialDTO entity)
        {
            if (typesDAO.Update(new OfficialBO(entity)) != null)
                return true;
            else
                return false;
        }
        public OfficialDTO FindByID(int _TypeID)
        {
            return new OfficialDTO(typesDAO.FindByKey(_TypeID));
        }

    }
}
