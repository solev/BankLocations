namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bank")]
    public partial class Bank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankId { get; set; }

        [Required]
        [StringLength(10)]
        public string BankNumber { get; set; }

        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
