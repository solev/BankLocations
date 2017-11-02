namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zone")]
    public partial class Zone
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZoneId { get; set; }        

        [Required]
        [StringLength(50)]
        public string ZoneName { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        public virtual ICollection<Bank> Banks { get; set; }
    }
}
