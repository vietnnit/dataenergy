namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_EnterpriseHistory
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int? ProvinceId { get; set; }

        public int? DistrictId { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "ntext")]
        public string Info { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public int? ManProvinceId { get; set; }

        public int? ManDistrictId { get; set; }

        [StringLength(50)]
        public string ManPhone { get; set; }

        [StringLength(255)]
        public string ManEmail { get; set; }

        [StringLength(255)]
        public string ManAddress { get; set; }

        [StringLength(255)]
        public string ManPerson { get; set; }

        public int? AreaId { get; set; }

        [StringLength(50)]
        public string ManFax { get; set; }

        public int? SubAreaId { get; set; }

        [StringLength(50)]
        public string MST { get; set; }

        public int? OrganizationId { get; set; }

        public bool? IsConfirm { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        public bool? IsImportant { get; set; }

        [StringLength(200)]
        public string ParentName { get; set; }
        public int? MoHinhQLNL { get; set; }
    }
}
