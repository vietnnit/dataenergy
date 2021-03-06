using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using ePower.Dao;

namespace DAO
{
    public class OfficialDao : EntityDao<OfficialBO>
    {
        public OfficialDao()
        {
            //Constructor
        }
        public DataTable FindList(string Keywords, int groupdoc, int cateid, int agentId, int doctypeId, int AreaId, bool? Status, string lang, DateTime? fromDate, DateTime? toDate, ePower.Core.PagingInfo paging)
        {
            Db db = new Db();
            DbParameter[] param = new DbParameter[12];
            param[0] = new DbParameter("@keyword", Keywords);
            param[1] = new DbParameter("@CateOfficialID", cateid);
            param[2] = new DbParameter("@DocTypeId", doctypeId);
            if (fromDate != null)
                param[3] = new DbParameter("@FromDate", fromDate);
            else
                param[3] = new DbParameter("@FromDate", DBNull.Value);
            if (toDate != null)
                param[4] = new DbParameter("@ToDate", toDate);
            else
                param[4] = new DbParameter("@ToDate", DBNull.Value);
            if (Status != null)
                param[5] = new DbParameter("@Status", Status);
            else
                param[5] = new DbParameter("@Status", DBNull.Value);
            param[6] = new DbParameter("@GroupDoc", groupdoc);
            param[7] = new DbParameter("@AreaId", AreaId);
            param[8] = new DbParameter("@Language", lang);

            param[9] = new DbParameter("@CurrentPage", paging.CurrentPage);
            param[10] = new DbParameter("@PageSize", paging.PageSize);
            param[11] = new DbParameter("@AgentId", agentId);

            return db.GetDataTable("_DocumentSearch", param, CommandType.StoredProcedure);
        }
    }
}
