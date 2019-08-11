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
    builder.EntitySet<userInfo>("userInfoes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class userInfoesController : ODataController
    {
        private PokedexEntities db = new PokedexEntities();

        // GET: odata/userInfoes
        [EnableQuery]
        public IQueryable<userInfo> GetuserInfoes()
        {
            return db.userInfoes;
        }

        // GET: odata/userInfoes(5)
        [EnableQuery]
        public SingleResult<userInfo> GetuserInfo([FromODataUri] int key)
        {
            return SingleResult.Create(db.userInfoes.Where(userInfo => userInfo.uid == key));
        }

        // PUT: odata/userInfoes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<userInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userInfo userInfo = db.userInfoes.Find(key);
            if (userInfo == null)
            {
                return NotFound();
            }

            patch.Put(userInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userInfo);
        }

        // POST: odata/userInfoes
        public IHttpActionResult Post(userInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userInfoes.Add(userInfo);
            db.SaveChanges();

            return Created(userInfo);
        }

        // PATCH: odata/userInfoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<userInfo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userInfo userInfo = db.userInfoes.Find(key);
            if (userInfo == null)
            {
                return NotFound();
            }

            patch.Patch(userInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userInfoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userInfo);
        }

        // DELETE: odata/userInfoes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            userInfo userInfo = db.userInfoes.Find(key);
            if (userInfo == null)
            {
                return NotFound();
            }

            db.userInfoes.Remove(userInfo);
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

        private bool userInfoExists(int key)
        {
            return db.userInfoes.Count(e => e.uid == key) > 0;
        }
    }
}
