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

        [Route("api/TeacherCourses/{id}")]
        public IQueryable<sp_teacherCourses_Result> GetTeacherCourses(int id)
        {
            return db.sp_teacherCourses(id).AsQueryable();
        }
        [Route("api/CoursesByState/{state}")]
        public IQueryable<getCourseByState_Result> GetCoursesByState(bool state)
        {
            List<getCourseByState_Result> course = db.getCourseByState(state).ToList();
            return course.AsQueryable();
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
        public IHttpActionResult Putview_allCourses(int id, Course view_allCourses)
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
        [ResponseType(typeof(Course))]
        public IHttpActionResult Deleteview_allCourses(int id)
        {
            Course view_allCourses = db.Courses.Find(id);
            if (view_allCourses == null)
            {
                return NotFound();
            }

            db.Courses.Remove(view_allCourses);
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
            return db.Courses.Count(e => e.id == id) > 0;
        }
    }
}