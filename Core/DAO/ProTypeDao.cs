using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ePower.Dao;
using ePower.Core;
using PR.Domain;

namespace PR.Dao
{
    public class ProTypeDao : EntityDao<ProTypeBO>
    {
        Db db = new Db();
        public int DeleteByProjectId(int ProjectId)
        {
            Db db = new Db();
            DbParameter[] param = new DbParameter[1];
            param[0] = new DbParameter("@ProjectId", ProjectId);
            return db.Delete("DELETE FROM " + new ProTypeBO().TableName + " WHERE ProjectId=@ProjectId", param, CommandType.Text);
        }
        public IList<ProTypeBO> GetListByProject(int ProjectId)
        {
            Db db = new Db();
            DbParameter[] param = new DbParameter[1];
            param[0] = new DbParameter("@ProjectId", ProjectId);
            return db.GetList<ProTypeBO>("SELECT * FROM " + new ProTypeBO().TableName + "  WHERE ProjectId=@ProjectId", param, CommandType.Text);
        }
    }
}
