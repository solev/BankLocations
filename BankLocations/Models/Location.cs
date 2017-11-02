namespace BankLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Location")]
    public partial class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationId { get; set; }        

        public byte LocationNumber { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }


        public int BankId { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
