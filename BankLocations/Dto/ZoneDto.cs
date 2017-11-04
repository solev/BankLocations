using BankLocations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.Dto
{    
    public class ZoneDto
    {
        public string ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int SiteId { get; set; }

        public virtual List<BankDto> Banks { get; set; }
    }
}