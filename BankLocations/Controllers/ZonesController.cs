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
        public IQueryable<Zone> GetZones()
        {
            return db.Zones;
        }

        // GET: api/Zones
        public IList<ZoneDto> GetZonesForSite(int siteId)
        {
            return db.Zones                
                .Where(x=>x.SiteId == siteId).ProjectTo<ZoneDto>().ToList();
        }

        // GET: api/Zones/5
        [ResponseType(typeof(Zone))]
        public async Task<IHttpActionResult> GetZone(int id)
        {
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            return Ok(zone);
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