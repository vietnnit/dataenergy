using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using ePower.DE.Domain;
using ePower.DE.Dao;

namespace ePower.DE.Service
{
    public class PlanTBService
    {

        PlanTBDao plantbDao = new PlanTBDao();
        public DataTable GetPlanTBEnterprise(int OrganizationId, Int32 IdKH, bool blIsFiveYear, bool blIsPlan)
        {
            return plantbDao.GetPlanTBEnterprise(OrganizationId, IdKH, blIsFiveYear, blIsPlan);
        }
        public int Insert(PlanTB obj)
        {
            PlanTBBO plantbBO = new PlanTBBO(obj);
            return plantbDao.Insert(plantbBO);
        }
        public PlanTB Update(PlanTB obj)
        {
            PlanTBBO plantbBO = new PlanTBBO(obj);
            plantbDao.Update(plantbBO);
            return obj;
        }

        public long Delete(int _Id)
        {
            return plantbDao.Delete(_Id);
        }
        public PlanTB FindByKey(int _Id)
        {
            return new PlanTB(plantbDao.FindByKey(_Id));
        }
        public IList<PlanTB> FindAll()
        {
            IList<PlanTB> list = new List<PlanTB>();
            IList<PlanTBBO> listBO = new List<PlanTBBO>();
            listBO = plantbDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (PlanTBBO obj in listBO)
                    list.Add(new PlanTB(obj));
            return list;
        }

    }
}
