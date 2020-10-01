namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNewsApprovedComment")]
    public partial class tblNewsApprovedComment
    {
        [Key]
        [Column(Order = 0)]
        public int ApprovedCommentNewsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsID { get; set; }

        public string Content { get; set; }

        public bool? Actived { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
    }
}
