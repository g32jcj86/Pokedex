using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class pokeInfoesController : ODataController
    {
        private PokedexEntities db = new PokedexEntities();


        // GET: odata/pokeInfoes
        [EnableQuery]
        public IQueryable<pokeInfo> GetpokeInfoes()
        {
            return db.pokeInfoes;
        }

        // GET: odata/pokeInfoes(5)
        [EnableQuery]
        public SingleResult<pokeInfo> GetpokeInfo([FromODataUri] int key)
        {
            return SingleResult.Create(db.pokeInfoes.Where(pokeInfo => pokeInfo.id == key));
        }

        // PUT: odata/pokeInfoes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<pokeInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pokeInfo pokeInfo = db.pokeInfoes.Find(key);
            if (pokeInfo == null)
            {
                return NotFound();
            }

            patch.Put(pokeInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pokeInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pokeInfo);
        }

        // POST: odata/pokeInfoes
        public IHttpActionResult Post(pokeInfo pokeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pokeInfoes.Add(pokeInfo);
            db.SaveChanges();

            return Created(pokeInfo);
        }

        // PATCH: odata/pokeInfoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<pokeInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pokeInfo pokeInfo = db.pokeInfoes.Find(key);
            if (pokeInfo == null)
            {
                return NotFound();
            }

            patch.Patch(pokeInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pokeInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pokeInfo);
        }

        // DELETE: odata/pokeInfoes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            pokeInfo pokeInfo = db.pokeInfoes.Find(key);
            if (pokeInfo == null)
            {
                return NotFound();
            }

            db.pokeInfoes.Remove(pokeInfo);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pokeInfoExists(int key)
        {
            return db.pokeInfoes.Count(e => e.id == key) > 0;
        }
    }
}
