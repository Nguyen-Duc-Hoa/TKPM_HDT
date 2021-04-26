using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Categories
        public IQueryable<view_categories> Getview_categories()
        {
            return db.view_categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(view_categories))]
        public IHttpActionResult Getview_categories(int id)
        {
            view_categories view_categories = db.view_categories.Find(id);
            if (view_categories == null)
            {
                return NotFound();
            }

            return Ok(view_categories);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_categories(int id, view_categories view_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_categories.id)
            {
                return BadRequest();
            }

            db.Entry(view_categories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_categoriesExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(view_categories))]
        public IHttpActionResult Postview_categories(view_categories view_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_categories.Add(view_categories);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_categories.id }, view_categories);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(view_categories))]
        public IHttpActionResult Deleteview_categories(int id)
        {
            view_categories view_categories = db.view_categories.Find(id);
            if (view_categories == null)
            {
                return NotFound();
            }

            db.view_categories.Remove(view_categories);
            db.SaveChanges();

            return Ok(view_categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_categoriesExists(int id)
        {
            return db.view_categories.Count(e => e.id == id) > 0;
        }
    }
}