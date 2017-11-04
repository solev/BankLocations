using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BankLocations.Models;
using BankLocations.Dto;
using AutoMapper.QueryableExtensions;

namespace BankLocations.Controllers
{
    public class ZonesController : ApiController
    {
        private BankDb db = new BankDb();


        // GET: api/Zones
        public IList<ZoneDto> GetZonesForSite(int siteId)
        {
            var zoneBankLocations = db.CadZoneBankLocations.Where(x => x.SiteId == siteId).ToList();
            var zones = zoneBankLocations.GroupBy(x => x.Zone)
            .Select(x => new ZoneDto
            {
                SiteId = x.Select(t => t.SiteId).FirstOrDefault(),
                ZoneName = x.Key,
                ZoneId = x.Key,
                Banks = x.GroupBy(t => t.Bank).Select(t => new BankDto
                {
                    BankNumber = t.Key,
                    ZoneId = x.Key,
                    BankId = x.Key + t.Key,               
                    Locations = t.Select(l => new LocationDto
                    {
                        LocationNumber = l.Location,
                        BankId = x.Key + t.Key,
                        LocationId = x.Key + t.Key + l.Location,
                        PositionX = l.PositionX,
                        PositionY = l.PositionY,
                        Vendor = l.CadVendor?.VendorName,
                        VendorId = l.VendorId
                    }).ToList()
                }).ToList()
            }).ToList();

            zones.ForEach(x => x.Banks.ForEach(t => {                
                t.VendorName = t.Locations.Select(l => l.Vendor).FirstOrDefault();
                t.VendorId = t.Locations.Select(l => l.VendorId).FirstOrDefault();
            }));

            return zones;
        }

        [HttpPost]

        public IHttpActionResult UpdateBankVendor(BankDto bankDetails, int siteId)
        {            
            using (var procDb = new Upwork_20171101_LocationValidationEntities())
            {
                var res = procDb.wsp_AssignVendorToBank(bankDetails.VendorId, siteId, bankDetails.ZoneId, bankDetails.BankNumber);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}