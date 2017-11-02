namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Site")]
    public partial class Site
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiteId { get; set; }

        [Required]
        [StringLength(50)]
        public string SiteName { get; set; }

        public byte[] BackgroundImage { get; set; }

    }
}
