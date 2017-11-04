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
using System.Data.SqlClient;

namespace BankLocations.Controllers
{
    public class CadVendorsController : ApiController
    {
        private BankDb db = new BankDb();

        // GET: api/CadVendors
        public IQueryable<CadVendor> GetCadVendors()
        {
            return db.CadVendors;
        }

        // GET: api/CadVendors/5
        [ResponseType(typeof(CadVendor))]
        public async Task<IHttpActionResult> GetCadVendor(int id)
        {
            CadVendor cadVendor = await db.CadVendors.FindAsync(id);
            if (cadVendor == null)
            {
                return NotFound();
            }

            return Ok(cadVendor);
        }

        // PUT: api/CadVendors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCadVendor(int id, CadVendor cadVendor)
        {
            try
            {
                System.Data.Entity.Core.Objects.ObjectParameter op = new System.Data.Entity.Core.Objects.ObjectParameter("VendorId_OUTPUT", typeof(Int32));
                using (var procDb = new Upwork_20171101_LocationValidationEntities())
                {
                    var res = procDb.wsp_CadVendor_CRUD("UPDATE_DBO_CADVENDOR", cadVendor.VendorId, op, cadVendor.VendorName, cadVendor.VendorAbbreviation, cadVendor.Description);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadVendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CadVendors
        [ResponseType(typeof(CadVendor))]
        public IHttpActionResult PostCadVendor(CadVendor cadVendor)
        {
            System.Data.Entity.Core.Objects.ObjectParameter op = new System.Data.Entity.Core.Objects.ObjectParameter("VendorId_OUTPUT", typeof(Int32));
            using (var procDb = new Upwork_20171101_LocationValidationEntities())
            {
                var res = procDb.wsp_CadVendor_CRUD("INSERT_DBO_CADVENDOR", null, op, cadVendor.VendorName, cadVendor.VendorAbbreviation, cadVendor.Description);
            }

            return CreatedAtRoute("DefaultApi", new { id = cadVendor.VendorId }, cadVendor);
        }

        // DELETE: api/CadVendors/5
        [ResponseType(typeof(CadVendor))]
        public async Task<IHttpActionResult> DeleteCadVendor(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter op = new System.Data.Entity.Core.Objects.ObjectParameter("VendorId_OUTPUT", typeof(Int32));
            using (var procDb = new Upwork_20171101_LocationValidationEntities())
            {
                var res = procDb.wsp_CadVendor_CRUD("DELETE_DBO_CADVENDOR", id, op, null, null, null);
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

        private bool CadVendorExists(int id)
        {
            return db.CadVendors.Count(e => e.VendorId == id) > 0;
        }
    }
}