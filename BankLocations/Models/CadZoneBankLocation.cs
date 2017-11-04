namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CadZoneBankLocation")]
    public partial class CadZoneBankLocation
    {
        [Key]
        public int ZoneBankLocationId { get; set; }

        public int? VendorId { get; set; }

        public int SiteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Zone { get; set; }

        [Required]
        [StringLength(10)]
        public string Bank { get; set; }

        [Required]
        [StringLength(7)]
        public string Location { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public virtual CadVendor CadVendor { get; set; }

        public virtual Site Site { get; set; }
    }
}
