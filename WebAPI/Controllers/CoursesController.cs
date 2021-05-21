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
    public class CoursesController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Courses
        public IQueryable<view_allCourses> Getview_allCourses()
        {
            return db.view_allCourses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(view_allCourses))]
        public IHttpActionResult Getview_allCourses(int id)
        {
            view_allCourses view_allCourses = db.view_allCourses.Find(id);
            if (view_allCourses == null)
            {
                return NotFound();
            }

            return Ok(view_allCourses);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_allCourses(int id, view_allCourses view_allCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_allCourses.id)
            {
                return BadRequest();
            }

            db.Entry(view_allCourses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_allCoursesExists(id))
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

        // POST: api/Courses
        [ResponseType(typeof(view_allCourses))]
        public IHttpActionResult Postview_allCourses(view_allCourses view_allCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_allCourses.Add(view_allCourses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_allCourses.id }, view_allCourses);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(view_allCourses))]
        public IHttpActionResult Deleteview_allCourses(int id)
        {
            view_allCourses view_allCourses = db.view_allCourses.Find(id);
            if (view_allCourses == null)
            {
                return NotFound();
            }

            db.view_allCourses.Remove(view_allCourses);
            db.SaveChanges();

            return Ok(view_allCourses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_allCoursesExists(int id)
        {
            return db.view_allCourses.Count(e => e.id == id) > 0;
        }


        [Route("api/Courses/RemoveLike/{idStudent}/{idCourse}")]
        [ResponseType(typeof(Bookdetail))]
        public IHttpActionResult RemoveLike (int idStudent, int idCourse)
        {
            Bookdetail bookdetail = db.Bookdetails.Find(idStudent, idCourse);
            if (bookdetail == null)
            {
                return NotFound();
            }

            db.Bookdetails.Remove(bookdetail);
            db.SaveChanges();

            return Ok(bookdetail);

        }
    }
}