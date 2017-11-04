using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.Dto
{
    public class BankDto
    {
        public string BankId { get; set; }
        public string BankNumber { get; set; }
        public string ZoneId { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }


        public virtual List<LocationDto> Locations { get; set; }
    }
}