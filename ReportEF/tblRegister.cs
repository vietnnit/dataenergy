namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRegister")]
    public partial class tblRegister
    {
        [Key]
        public int RegisterID { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone1 { get; set; }

        [StringLength(50)]
        public string Phone2 { get; set; }

        [StringLength(50)]
        public string Phone3 { get; set; }

        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(150)]
        public string FullName2 { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        public DateTime? Birth { get; set; }

        public bool? Actived { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string NickYahoo { get; set; }

        [StringLength(50)]
        public string NickSkype { get; set; }

        [StringLength(50)]
        public string TN_Nam { get; set; }

        [StringLength(5)]
        public string TN_Mon1 { get; set; }

        [StringLength(5)]
        public string TN_Mon2 { get; set; }

        [StringLength(5)]
        public string TN_Mon3 { get; set; }

        [StringLength(5)]
        public string TN_Mon4 { get; set; }

        [StringLength(5)]
        public string TN_Mon5 { get; set; }

        [StringLength(250)]
        public string TN_Truong { get; set; }

        [StringLength(250)]
        public string DT_Truong { get; set; }

        [StringLength(50)]
        public string DT_SBD { get; set; }

        [StringLength(5)]
        public string DT_Mon1 { get; set; }

        [StringLength(5)]
        public string DT_Mon2 { get; set; }

        [StringLength(5)]
        public string DT_Mon3 { get; set; }

        [StringLength(5)]
        public string DT_Khoi { get; set; }

        [StringLength(50)]
        public string DT_Nganh { get; set; }

        [StringLength(250)]
        public string NV_Truong { get; set; }

        [StringLength(50)]
        public string NV_Nganh { get; set; }

        [StringLength(50)]
        public string NV_He { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
