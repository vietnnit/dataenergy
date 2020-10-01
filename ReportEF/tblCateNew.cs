namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCateNew
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCateNew()
        {
            tblNewsEvents = new HashSet<tblNewsEvent>();
            tblNewsLogs = new HashSet<tblNewsLog>();
        }

        [Key]
        public int CateNewsID { get; set; }

        public int? ParentNewsID { get; set; }

        [Required]
        [StringLength(120)]
        public string CateNewsName { get; set; }

        public int? CateNewsTotal { get; set; }

        public int? CateNewsOrder { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        public int? GroupCate { get; set; }

        [StringLength(1000)]
        public string Icon { get; set; }

        [StringLength(200)]
        public string Slogan { get; set; }

        [StringLength(1000)]
        public string Roles { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        public bool? IsUrl { get; set; }

        public bool? status { get; set; }

        [StringLength(120)]
        public string ShortName { get; set; }

        public int? PageLayoutID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNewsEvent> tblNewsEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNewsLog> tblNewsLogs { get; set; }
    }
}
