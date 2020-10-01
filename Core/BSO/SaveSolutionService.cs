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
    public class SaveSolutionService
    {

        SaveSolutionDao savesolutionDao = new SaveSolutionDao();
        public int Insert(SaveSolution obj)
        {
            SaveSolutionBO savesolutionBO = new SaveSolutionBO(obj);
            return savesolutionDao.Insert(savesolutionBO);
        }
        public SaveSolution Update(SaveSolution obj)
        {
            SaveSolutionBO savesolutionBO = new SaveSolutionBO(obj);
            savesolutionDao.Update(savesolutionBO);
            return obj;
        }
        public long Delete(int _Id)
        {
            return savesolutionDao.Delete(_Id);
        }
        public SaveSolution FindByKey(int _Id)
        {
            return new SaveSolution(savesolutionDao.FindByKey(_Id));
        }
        public IList<SaveSolution> FindAll()
        {
            IList<SaveSolution> list = new List<SaveSolution>();
            IList<SaveSolutionBO> listBO = new List<SaveSolutionBO>();
            listBO = savesolutionDao.FindAll();
            if (listBO != null && listBO.Count > 0)
                foreach (SaveSolutionBO obj in listBO)
                    list.Add(new SaveSolution(obj));
            return list;
        }
        public DataTable GetSaveSolution(int ReportId)
        {
            DbParameter[] parameter = new DbParameter[1];
            parameter[0] = new DbParameter("@ReportId", ReportId);         
            return new Db().GetDataTable("GetSaveSolution", parameter, System.Data.CommandType.StoredProcedure);
        }
    }
}
