namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMember")]
    public partial class tblMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public DateTime? Birth { get; set; }

        public bool? Actived { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string NickYahoo { get; set; }

        [StringLength(50)]
        public string NickSkype { get; set; }

        [StringLength(100)]
        public string Avatar { get; set; }
    }
}
