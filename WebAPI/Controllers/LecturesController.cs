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
    public class LecturesController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Lectures
        public IQueryable<view_allLectures> Getview_allLectures()
        {
            return db.view_allLectures;
        }

        [HttpGet]
        [Route("api/LecturesByChap/{idChapter}")]
        public IQueryable<view_allLectures> LecturesByChap(int idChapter)
        {
            return db.view_allLectures.Where(x => x.id_chapter == idChapter);
        }

        // GET: api/Lectures/5
        [ResponseType(typeof(view_allLectures))]
        public IHttpActionResult Getview_allLectures(int id)
        {
            view_allLectures view_allLectures = db.view_allLectures.Find(id);
            if (view_allLectures == null)
            {
                return NotFound();
            }

            return Ok(view_allLectures);
        }

        // PUT: api/Lectures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_allLectures(int id, view_allLectures view_allLectures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_allLectures.id)
            {
                return BadRequest();
            }

            db.Entry(view_allLectures).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_allLecturesExists(id))
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

        // POST: api/Lectures
        [ResponseType(typeof(view_allLectures))]
        public IHttpActionResult Postview_allLectures(view_allLectures view_allLectures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_allLectures.Add(view_allLectures);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_allLectures.id }, view_allLectures);
        }

        // DELETE: api/Lectures/5
        [ResponseType(typeof(view_allLectures))]
        public IHttpActionResult Deleteview_allLectures(int id)
        {
            view_allLectures view_allLectures = db.view_allLectures.Find(id);
            if (view_allLectures == null)
            {
                return NotFound();
            }

            db.view_allLectures.Remove(view_allLectures);
            db.SaveChanges();

            return Ok(view_allLectures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_allLecturesExists(int id)
        {
            return db.view_allLectures.Count(e => e.id == id) > 0;
        }
    }
}