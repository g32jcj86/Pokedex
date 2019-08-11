using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    /*
    WebApiConfig 類別可能需要其他變更以新增此控制器的路由，請將這些陳述式合併到 WebApiConfig 類別的 Register 方法。注意 OData URL 有區分大小寫。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Pokedex.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<loginRecord>("loginRecords");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class loginRecordsController : ODataController
    {
        private PokedexEntities db = new PokedexEntities();

        // GET: odata/loginRecords
        [EnableQuery]
        public IQueryable<loginRecord> GetloginRecords()
        {
            return db.loginRecords;
        }

        // GET: odata/loginRecords(5)
        [EnableQuery]
        public SingleResult<loginRecord> GetloginRecord([FromODataUri] int key)
        {
            return SingleResult.Create(db.loginRecords.Where(loginRecord => loginRecord.id == key));
        }

        // PUT: odata/loginRecords(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<loginRecord> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            loginRecord loginRecord = db.loginRecords.Find(key);
            if (loginRecord == null)
            {
                return NotFound();
            }

            patch.Put(loginRecord);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginRecordExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(loginRecord);
        }

        // POST: odata/loginRecords
        public IHttpActionResult Post(loginRecord loginRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.loginRecords.Add(loginRecord);
            db.SaveChanges();

            return Created(loginRecord);
        }

        // PATCH: odata/loginRecords(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<loginRecord> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            loginRecord loginRecord = db.loginRecords.Find(key);
            if (loginRecord == null)
            {
                return NotFound();
            }

            patch.Patch(loginRecord);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginRecordExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(loginRecord);
        }

        // DELETE: odata/loginRecords(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            loginRecord loginRecord = db.loginRecords.Find(key);
            if (loginRecord == null)
            {
                return NotFound();
            }

            db.loginRecords.Remove(loginRecord);
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

        private bool loginRecordExists(int key)
        {
            return db.loginRecords.Count(e => e.id == key) > 0;
        }
    }
}
