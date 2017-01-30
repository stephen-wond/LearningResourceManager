using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using LRM.Server.Models;

namespace LRM.Server.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ResourcesController : ApiController
    {
        private LRMContext db = new LRMContext();

        // GET: api/Resources
        public IQueryable<ResourceQuickDTO> GetResources()
        {
            var resource = from r in db.Resources
                select new ResourceQuickDTO()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Link = r.Link,
                    Description = r.Description
                };
            return resource;
        }

        // GET: api/Resources/5
        [ResponseType(typeof(ResourceDTO))]
        public IHttpActionResult GetResource(int id)
        {
            var resource = db.Resources.Select(r =>
                new ResourceDTO()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Link = r.Link,
                    Description = r.Description,
                    Keywords = r.Keywords
                }).SingleOrDefault(r => r.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            return Ok(resource);
        }

        // PUT: api/Resources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResource(int id, Resource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resource.Id)
            {
                return BadRequest();
            }

            db.Entry(resource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(id))
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

        // POST: api/Resources
        [ResponseType(typeof(ResourceDTO))]
        public IHttpActionResult PostResource(Resource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resources.Add(resource);
            db.SaveChanges();

            db.Entry(resource).Reference(x => x.Name).Load();

            var dto = new ResourceDTO()
            {
                Id = resource.Id,
                Name = resource.Name,
                Link = resource.Link,
                Description = resource.Description,
                Keywords = resource.Keywords
            };

            return CreatedAtRoute("DefaultApi", new { id = resource.Id }, dto);
        }

        // DELETE: api/Resources/5
        [ResponseType(typeof(ResourceDTO))]
        public IHttpActionResult DeleteResource(int id)
        {
            var dto = db.Resources.Select(r =>
               new ResourceDTO()
               {
                   Id = r.Id,
                   Name = r.Name,
                   Link = r.Link,
                   Description = r.Description,
                   Keywords = r.Keywords
               }).SingleOrDefault(r => r.Id == id);

            Resource resource = db.Resources.Find(id);

            if (resource == null)
            {
                return NotFound();
            }

            db.Resources.Remove(resource);
            db.SaveChanges();

            return Ok(dto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResourceExists(int id)
        {
            return db.Resources.Count(e => e.Id == id) > 0;
        }
    }
}