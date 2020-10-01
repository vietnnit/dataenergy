namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOfficial")]
    public partial class tblOfficial
    {
        public int ID { get; set; }

        public int? CateOfficialID { get; set; }

        [StringLength(50)]
        public string NoCode { get; set; }

        [StringLength(1000)]
        public string OfficialName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DatePublic { get; set; }

        [StringLength(200)]
        public string Company { get; set; }

        [StringLength(200)]
        public string Classify { get; set; }

        [StringLength(150)]
        public string Writer { get; set; }

        [Column(TypeName = "ntext")]
        public string Quote { get; set; }

        [StringLength(1000)]
        public string KeyShort { get; set; }

        [StringLength(250)]
        public string Attached { get; set; }

        public bool? Status { get; set; }

        public bool? IsApproval { get; set; }

        [StringLength(50)]
        public string ApprovalUserName { get; set; }

        public DateTime? ApprovalDate { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? GroupCate { get; set; }

        [StringLength(5)]
        public string Language { get; set; }

        public bool? isDelete { get; set; }

        public int? DocTypeId { get; set; }

        public int? OrgId { get; set; }

        public int? AreaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EffectDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiredDate { get; set; }

        public int? IdErav { get; set; }

        [StringLength(800)]
        public string PathFile { get; set; }

        public DateTime? DisscussionDate { get; set; }

        public byte? GroupDoc { get; set; }

        [StringLength(400)]
        public string NoteDoc { get; set; }
    }
}
