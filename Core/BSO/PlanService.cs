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
    public class PlanService
    {

        PlanDao planDao = new PlanDao();
        public int Insert(Plan obj)
        {
            PlanBO planBO = new PlanBO(obj);
            return planDao.Insert(planBO);
        }
        public Int32 Update(Plan obj)
        {
            PlanBO planBO = new PlanBO(obj);
            planDao.Update(planBO);
            return obj.Id;
        }
        public long Delete(int _Id)
        {
            return planDao.Delete(_Id);
        }
        public Plan FindByKey(int _Id)
        {
            return new Plan(planDao.FindByKey(_Id));
        }
        public DataTable GetReportPlanEnerprise(int OrganizationId, DateTime? begindate, DateTime? enddate, string key)
        {
            return planDao.GetReportPlanEnerprise(OrganizationId, begindate, enddate, key);
        }
        public IList<Plan> FindAll()
        {
            IList<Plan> list = new List<Plan>();
            IList<PlanBO> listBO = new List<PlanBO>();
            listBO = planDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (PlanBO obj in listBO)
                    list.Add(new Plan(obj));
            return list;
        }
        public IList<Plan> GetPlanByReportId(int ReportId)
        {
            IList<Plan> list = new List<Plan>();
            IList<PlanBO> listBO = new List<PlanBO>();
            listBO = planDao.GetPlanByReportId(ReportId);
            if (listBO != null && listBO.Count > 0)
                foreach (PlanBO obj in listBO)
                    list.Add(new Plan(obj));
            return list;
        }

    }
}
