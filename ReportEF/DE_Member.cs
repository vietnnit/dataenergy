namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? IsDelete { get; set; }

        public int? EnterpriseId { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
