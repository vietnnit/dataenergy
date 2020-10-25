namespace ReportEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DE_ReportFuel
    {
        public int Id { get; set; }

        public int? Year { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string Modifier { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public int? EnterpriseId { get; set; }

        [StringLength(50)]
        public string ReporterName { get; set; }

        public DateTime? AprovedDate { get; set; }

        public int? AreaId { get; set; }

        public int? SubAreaId { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? ConfirmedDate { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int? ProviceId { get; set; }

        public int? DistrictId { get; set; }

        public int? UserId { get; set; }

        public int? ApproverId { get; set; }

        public int? SendSatus { get; set; }

        public bool? IsDelete { get; set; }

        public bool? ApprovedSatus { get; set; }

        public decimal? NoFuel_TOE { get; set; }

        public DateTime? ReportDate { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? OrganizationId { get; set; }

        public DateTime? SendDate { get; set; }

        public int? ProvinceParentId { get; set; }

        public int? DistrictParentId { get; set; }

        [StringLength(255)]
        public string AddressParent { get; set; }

        [StringLength(50)]
        public string FaxParent { get; set; }

        [StringLength(50)]
        public string PhoneParent { get; set; }

        [StringLength(255)]
        public string ParentName { get; set; }

        [StringLength(50)]
        public string EmailParent { get; set; }

        public bool? IsFiveYear { get; set; }

        [StringLength(255)]
        public string PathFile { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string Responsible { get; set; }

        public int? OwnerId { get; set; }

        public int? ProcessStatus { get; set; }
        [StringLength(50)]
        public string ReportType { get; set; }
    }
}
