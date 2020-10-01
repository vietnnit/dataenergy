namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblVideosCate")]
    public partial class tblVideosCate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVideosCate()
        {
            tblVideos = new HashSet<tblVideo>();
        }

        [Key]
        public int VideosCateID { get; set; }

        public int? ParentCateID { get; set; }

        [Required]
        [StringLength(200)]
        public string VideosCateName { get; set; }

        public int? VideosCateTotal { get; set; }

        public int? VideosCateOrder { get; set; }

        [StringLength(1000)]
        public string ImageThumb { get; set; }

        [StringLength(1000)]
        public string ImageLarge { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVideo> tblVideos { get; set; }
    }
}
