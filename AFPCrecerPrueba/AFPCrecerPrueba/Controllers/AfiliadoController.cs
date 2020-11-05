using DAL.ApplicationDBContext;
using DAL.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AFPCrecerPrueba.Controllers
{
    [RoutePrefix("api/Afiliados")]

    public class AfiliadoController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Afiliados/5
        [ResponseType(typeof(Afiliado))]
        [HttpGet]
        public async Task<IHttpActionResult> GetAfiliado(int id)
        {
            var afiliado = await this.db.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return Ok(afiliado);
        }

        // PUT: api/Afiliados/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutAfiliados(Afiliado afiliado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.db.Entry(afiliado).State = EntityState.Modified;

            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfiliadoExists(afiliado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(afiliado);
        }

        // POST: api/Afiliados
        [ResponseType(typeof(Afiliado))]
        [HttpPost]
        public async Task<IHttpActionResult> PostAfiliado(Afiliado afiliado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.db.Afiliados.Add(afiliado);
            await this.db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = afiliado.Id }, afiliado);
        }

        // DELETE: api/Afiliados/5
        [ResponseType(typeof(Afiliado))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAfiliado(int id)
        {
            var afiliado = await this.db.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }

            this.db.Afiliados.Remove(afiliado);
            await this.db.SaveChangesAsync();

            return Ok(afiliado);
        }

        private bool AfiliadoExists(int id)
        {
            return this.db.Afiliados.Count(e => e.Id == id) > 0;
        }
    }
}
