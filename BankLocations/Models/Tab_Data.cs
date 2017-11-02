namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tab_Data
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZoneId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ZoneName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string BankNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(7)]
        public string LocationNumber { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string SiteName { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiteId { get; set; }
    }
}
