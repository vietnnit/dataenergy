namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_BaocaoLinhVuc
    {
        [Key]
        public int AutoId { get; set; }

        [Required]
        [StringLength(1000)]
        public string TenMauBC { get; set; }

        [Required]
        [StringLength(255)]
        public string TemplateBC { get; set; }

        [Required]
        [StringLength(50)]
        public string PhanLoaiBC { get; set; }

        [Required]
        [StringLength(255)]
        public string TenControl { get; set; }

        public bool TrangThai { get; set; }

        public int IdLinhVuc { get; set; }
    }
}
