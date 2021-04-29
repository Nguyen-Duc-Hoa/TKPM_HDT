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
    public class SubcategoriesController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Subcategories
        public IQueryable<view_Subcategories> Getview_Subcategories()
        {
            return db.view_Subcategories;
        }

        // GET: api/Subcategories/5
        [ResponseType(typeof(view_Subcategories))]
        public IHttpActionResult Getview_Subcategories(int id)
        {
            view_Subcategories subcategory = db.view_Subcategories.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(subcategory);
        }

        // PUT: api/Subcategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_Subcategories(int id, view_Subcategories subcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subcategory.id)
            {
                return BadRequest();
            }

            db.Entry(subcategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_SubcategoriesExists(id))
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

        // POST: api/Subcategories
        [ResponseType(typeof(view_Subcategories))]
        public IHttpActionResult Postview_Subcategories(view_Subcategories subcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_Subcategories.Add(subcategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subcategory.id }, subcategory);
        }

        // DELETE: api/Subcategories/5
        [ResponseType(typeof(view_Subcategories))]
        public IHttpActionResult Deleteview_Subcategories(int id)
        {
            view_Subcategories subcategory = db.view_Subcategories.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            db.view_Subcategories.Remove(subcategory);
            db.SaveChanges();

            return Ok(subcategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_SubcategoriesExists(int id)
        {
            return db.view_Subcategories.Count(e => e.id == id) > 0;
        }
    }
}