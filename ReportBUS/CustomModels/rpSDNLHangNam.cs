using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportBUS.CustomModels
{
    public class rpSDNLHangNam
    {
        public int idDN { get; set; }
        public int NamBaoCao { get; set; }
        public int FuelId { get; set; }
        public string FuelName { get; set; }
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public int TrangThai { get; set; }

        public decimal TOE { get; set; }
        public decimal MucTieuThu { get; set; }
        public decimal NangLuongQuyDoi { get; set; }
    }
}



