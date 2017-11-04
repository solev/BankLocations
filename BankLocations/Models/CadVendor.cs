namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CadVendor")]
    public partial class CadVendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [StringLength(150)]
        public string VendorName { get; set; }

        [Required]
        [StringLength(10)]
        public string VendorAbbreviation { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(150)]
        public string CreatedBy { get; set; }      
    }
}
