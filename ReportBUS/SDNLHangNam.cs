using ReportBUS.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportEF;
using System.Data.SqlClient;

namespace ReportBUS
{
    public class SDNLHangNam
    {
        public List<rpSDNLHangNam> DN_Get_BaoCao(int ReportId)
        {
            try
            {
                using (var ctx = new ReportModels())
                {
                    string rawCommand = string.Empty;
                    if (ctx.BC_SDNL_HangNam.Any(o => o.ReportId == ReportId))
                    {
                        rawCommand += " select a.id FuelId, a.FuelName, c.id MeasurementId, c.MeasurementName, b.TOE, ";
                        rawCommand += " cast(isnull(d.IdDN,0) as int) IdDN, cast(isnull(d.MucTieuThu,0) as decimal(20, 10)) as MucTieuThu, cast(isnull(d.NangLuongQuyDoi,0) as decimal(20, 10)) as NangLuongQuyDoi, cast(isnull(d.TrangThai,0) as int) TrangThai";
                        rawCommand += " from [dbo].[DE_Fuel] a";
                        rawCommand += " inner join [dbo].[DE_MeasurementFuel] b on a.Id=b.FuelId";
                        rawCommand += " inner join [dbo].[DE_Measurement] c on b.MeasurementId=c.Id";
                        rawCommand += " left join [dbo].[BC_SDNL_HangNam] d on a.id=d.FuelId and c.Id=d.MeasurementId and d.ReportId=@ReportId";
                        var result = ctx.Database.SqlQuery<rpSDNLHangNam>(rawCommand, new SqlParameter("@ReportId", ReportId)).ToList();
                        return result;
                    }
                    else
                    {
                        rawCommand += " select a.id FuelId, a.FuelName, c.id MeasurementId, c.MeasurementName, b.TOE, ";
                        rawCommand += " cast(0 as int) IdDN, cast(0 as decimal(20, 10)) as MucTieuThu, cast(0 as decimal(20, 10)) as NangLuongQuyDoi, cast(0 as int) TrangThai";
                        rawCommand += " from [dbo].[DE_Fuel] a";
                        rawCommand += " inner join [dbo].[DE_MeasurementFuel] b on a.Id=b.FuelId";
                        rawCommand += " inner join [dbo].[DE_Measurement] c on b.MeasurementId=c.Id";
                        var result = ctx.Database.SqlQuery<rpSDNLHangNam>(rawCommand).ToList();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> DN_Get_NamBaoCao(int id_dn)
        {
            try
            {
                List<int> result = new List<int>();
                using (var ctx = new ReportModels())
                {
                    if (ctx.BC_SDNL_HangNam.Any(o => o.IdDN == id_dn))
                    {
                        result = ctx.BC_SDNL_HangNam.GroupBy(o => new { NamBaoCao = o.NamBaoCao }).OrderByDescending(o => o.Key.NamBaoCao).Select(o => o.Key.NamBaoCao).ToList();
                    }
                    else
                        result.Add(DateTime.Now.Year);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
