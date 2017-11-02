using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.Dto
{
    public class BankDto
    {
        public int BankId { get; set; }
        public string BankNumber { get; set; }
        public int ZoneId { get; set; }

        public virtual ICollection<LocationDto> Locations { get; set; }
    }
}