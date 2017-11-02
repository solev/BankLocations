using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.Dto
{
    public class LocationDto
    {
        public int LocationId { get; set; }

        public byte LocationNumber { get; set; }

        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public int BankId { get; set; }
    }
}