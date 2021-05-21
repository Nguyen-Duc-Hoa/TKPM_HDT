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
    public class TeachersController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Teachers
        public IQueryable<view_Teachers> GetTeachers()
        {
            return db.view_Teachers;
        }
        [Route("api/TeachersName/{name}")]
        public IQueryable<getTeacherByName_Result> GetTeachersName(string name)
        {
            List<getTeacherByName_Result> teacher = db.getTeacherByName(name).ToList();
            return teacher.AsQueryable();
        }
        // GET: api/Teachers/5
        [ResponseType(typeof(view_Teachers))]
        public IHttpActionResult GetTeacher(int id)
        {
            view_Teachers teacher = db.view_Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/Teachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacher(int id, view_Teachers teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.id)
            {
                return BadRequest();
            }

            db.Entry(teacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        [ResponseType(typeof(view_Teachers))]
        public IHttpActionResult PostTeacher(view_Teachers teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_Teachers.Add(teacher);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeacherExists(teacher.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = teacher.id }, teacher);
        }

        // DELETE: api/Teachers/5
        [ResponseType(typeof(view_Teachers))]
        public IHttpActionResult DeleteTeacher(int id)
        {
            view_Teachers teacher = db.view_Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            db.view_Teachers.Remove(teacher);
            db.SaveChanges();

            return Ok(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherExists(int id)
        {
            return db.view_Teachers.Count(e => e.id == id) > 0;
        }
    }
}