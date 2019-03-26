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
    public class alimentosController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/alimentos
        public IQueryable<alimentos> Getalimentos()
        {
            return db.alimentos;
        }

        // GET: api/alimentos/5
        [ResponseType(typeof(alimentos))]
        public async Task<IHttpActionResult> Getalimentos(int id)
        {
            alimentos alimentos = await db.alimentos.FindAsync(id);
            if (alimentos == null)
            {
                return NotFound();
            }

            return Ok(alimentos);
        }

        // PUT: api/alimentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putalimentos(int id, alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alimentos.codigo)
            {
                return BadRequest();
            }

            db.Entry(alimentos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alimentosExists(id))
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

        // POST: api/alimentos
        [ResponseType(typeof(alimentos))]
        public async Task<IHttpActionResult> Postalimentos(alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.alimentos.Add(alimentos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (alimentosExists(alimentos.codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alimentos.codigo }, alimentos);
        }

        // DELETE: api/alimentos/5
        [ResponseType(typeof(alimentos))]
        public async Task<IHttpActionResult> Deletealimentos(int id)
        {
            alimentos alimentos = await db.alimentos.FindAsync(id);
            if (alimentos == null)
            {
                return NotFound();
            }

            db.alimentos.Remove(alimentos);
            await db.SaveChangesAsync();

            return Ok(alimentos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool alimentosExists(int id)
        {
            return db.alimentos.Count(e => e.codigo == id) > 0;
        }
    }
}