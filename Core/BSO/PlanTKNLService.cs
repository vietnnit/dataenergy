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
    public class PlanTKNLService
    {

        PlanTKNLDao plantknlDao = new PlanTKNLDao();
        public int Insert(PlanTKNL obj)
        {
            PlanTKNLBO plantknlBO = new PlanTKNLBO(obj);
            return plantknlDao.Insert(plantknlBO);
        }
        public DataTable GetPlanTKNLEnerprise(int OrganizationId, Int32 IdKH, bool blIsFiveYear, bool blIsPlan)
        {
            return plantknlDao.GetPlanTKNLEnerprise(OrganizationId, IdKH, blIsFiveYear, blIsPlan);
        }
        public DataTable GetResultSolution5Year(int FromYear, int ToYear, int EnterpriseId)
        {
            return plantknlDao.GetResultSolution5Year(FromYear, ToYear, EnterpriseId);
        }
        public PlanTKNL Update(PlanTKNL obj)
        {
            PlanTKNLBO plantknlBO = new PlanTKNLBO(obj);
            plantknlDao.Update(plantknlBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return plantknlDao.Delete(_Id);
        }
        public PlanTKNL FindByKey(int _Id)
        {
            return new PlanTKNL(plantknlDao.FindByKey(_Id));
        }
        public IList<PlanTKNL> FindAll()
        {
            IList<PlanTKNL> list = new List<PlanTKNL>();
            IList<PlanTKNLBO> listBO = new List<PlanTKNLBO>();
            listBO = plantknlDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (PlanTKNLBO obj in listBO)
                    list.Add(new PlanTKNL(obj));
            return list;
        }

    }
}
