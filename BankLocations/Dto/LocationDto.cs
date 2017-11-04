using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.Dto
{
    public class LocationDto
    {
        public string LocationId { get; set; }

        public string LocationNumber { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public string BankId { get; set; }
        public string Vendor { get; set; }
        public int? VendorId { get; set; }

    }
}