namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ReportTemp2014
    {
        public int Id { get; set; }

        public int? Year { get; set; }

        public int? EnterpriseId { get; set; }

        [StringLength(20)]
        public string Dien_kWh { get; set; }

        [StringLength(20)]
        public string Than_Tan { get; set; }

        [StringLength(20)]
        public string DO_Tan { get; set; }

        [StringLength(20)]
        public string FO_Tan { get; set; }

        [StringLength(20)]
        public string Xang_Tan { get; set; }

        [StringLength(20)]
        public string Gas_Tan { get; set; }

        [StringLength(20)]
        public string Khi_M3 { get; set; }

        [StringLength(20)]
        public string LPG_Tan { get; set; }

        [StringLength(20)]
        public string Khac_SoDo { get; set; }

        [StringLength(50)]
        public string AreaName { get; set; }

        [StringLength(100)]
        public string SubAreaName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public int? AreaId { get; set; }

        public int? SubAreaId { get; set; }

        public int? OrgId { get; set; }

        public decimal? No_TOE { get; set; }

        [StringLength(20)]
        public string KhacSoDo { get; set; }

        public bool IsDelete { get; set; }

        [StringLength(20)]
        public string DO_lit { get; set; }

        [StringLength(20)]
        public string FO_lit { get; set; }

        [StringLength(20)]
        public string Xang_lit { get; set; }

        [StringLength(20)]
        public string NLPL_Tan { get; set; }
    }
}
