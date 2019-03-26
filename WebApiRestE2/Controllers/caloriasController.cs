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
using WebApiRestE2.Models;

namespace WebApiRestE2.Controllers
{
    public class caloriasController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/calorias
        public IQueryable<calorias> Getcalorias()
        {
            return db.calorias;
        }

        // GET: api/calorias/5
        [ResponseType(typeof(calorias))]
        public async Task<IHttpActionResult> Getcalorias(string id)
        {
            calorias calorias = await db.calorias.FindAsync(id);
            if (calorias == null)
            {
                return NotFound();
            }

            return Ok(calorias);
        }

        // PUT: api/calorias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcalorias(string id, calorias calorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calorias.email)
            {
                return BadRequest();
            }

            db.Entry(calorias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!caloriasExists(id))
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

        // POST: api/calorias
        [ResponseType(typeof(calorias))]
        public async Task<IHttpActionResult> Postcalorias(calorias calorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.calorias.Add(calorias);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (caloriasExists(calorias.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = calorias.email }, calorias);
        }

        // DELETE: api/calorias/5
        [ResponseType(typeof(calorias))]
        public async Task<IHttpActionResult> Deletecalorias(string id)
        {
            calorias calorias = await db.calorias.FindAsync(id);
            if (calorias == null)
            {
                return NotFound();
            }

            db.calorias.Remove(calorias);
            await db.SaveChangesAsync();

            return Ok(calorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool caloriasExists(string id)
        {
            return db.calorias.Count(e => e.email == id) > 0;
        }
    }
}