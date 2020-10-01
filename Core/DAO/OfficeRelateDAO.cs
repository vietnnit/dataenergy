using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePower.Core;
using ePower.Dao;
using ETO;

namespace DAO
{
    public class OfficeRelateDao : EntityDao<OfficeRelateBO>
    {
        #region "Function Common"
        public IList<OfficeRelateBO> FindAll()
        {
            IList<OfficeRelateBO> list;
            try
            {
                list = base.FindAll();

            }
            catch (Exception ex)
            {
                return null;
            }
            return list;
        }
        public DataTable GetDocRelate(int DocId)
        {
            Db db = new Db();
            DbParameter[] param = new DbParameter[1];
            param[0] = new DbParameter("@DocId", DocId);
            return db.GetDataTable("_GetDocRelate", param, CommandType.StoredProcedure);
        }
        public int DeleteDocRelate(int DocId, int DocRelateId)
        {
            Db db = new Db();
            DbParameter[] param = new DbParameter[1];
            param[0] = new DbParameter("@DocId", DocId);
            param[0] = new DbParameter("@DocRelateId", DocId);
            return db.Update("DELETE FROM " + new OfficeRelateBO().TableName + " WHERE DocId=" + DocId + " AND DocRelateId=" + DocRelateId, param, CommandType.Text);
        }
        #endregion
    }
}

