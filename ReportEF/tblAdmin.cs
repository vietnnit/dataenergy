namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAdmin")]
    public partial class tblAdmin
    {
        [Key]
        public int Admin_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Username { get; set; }

        [StringLength(100)]
        public string Admin_FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Password { get; set; }

        public int Roles_ID { get; set; }

        public bool? Admin_Actived { get; set; }

        [StringLength(500)]
        public string Admin_Permission { get; set; }

        public DateTime? Admin_Created { get; set; }

        public DateTime? Admin_Log { get; set; }

        [StringLength(50)]
        public string Admin_Phone { get; set; }

        [StringLength(500)]
        public string Admin_Address { get; set; }

        public DateTime? Admin_Birth { get; set; }

        public bool? Admin_Sex { get; set; }

        [StringLength(50)]
        public string Admin_NickYahoo { get; set; }

        [StringLength(50)]
        public string Admin_NickSkype { get; set; }

        [StringLength(100)]
        public string Admin_Avatar { get; set; }

        public bool? Admin_LoginType { get; set; }

        public int? Admin_OrganizationId { get; set; }

        public virtual tblRole tblRole { get; set; }
    }
}
