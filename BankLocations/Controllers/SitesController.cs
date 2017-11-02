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

namespace BankLocations.Controllers
{
    public class SitesController : ApiController
    {
        private BankDb db = new BankDb();

        // GET: api/Sites
        public IQueryable<Site> GetSites()
        {
            return db.Sites;
        }

        // GET: api/Sites/5
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> GetSite(int id)
        {
            Site site = await db.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
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