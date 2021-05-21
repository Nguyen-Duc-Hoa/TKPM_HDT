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
    public class CurriculumController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Curriculum
        public IQueryable<view_allCurriculum> Getview_allCurriculum()
        {
            return db.view_allCurriculum;
        }

        // GET: api/Curriculum/5
        [ResponseType(typeof(view_allCurriculum))]
        public IHttpActionResult Getview_allCurriculum(int id)
        {
            view_allCurriculum view_allCurriculum = db.view_allCurriculum.Find(id);
            if (view_allCurriculum == null)
            {
                return NotFound();
            }

            return Ok(view_allCurriculum);
        }

        [Route("api/GetCurriculumCourse/{id}")]
        public IQueryable<getCurriculumByCourse_Result> GetCurriculumCourse(int id)
        {
            List<getCurriculumByCourse_Result> curri = db.getCurriculumByCourse(id).ToList();
            return curri.AsQueryable();
        }
        // PUT: api/Curriculum/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_allCurriculum(int id, Curriculum view_allCurriculum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_allCurriculum.id)
            {
                return BadRequest();
            }

            db.Entry(view_allCurriculum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_allCurriculumExists(id))
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

        // POST: api/Curriculum
        [ResponseType(typeof(view_allCurriculum))]
        public IHttpActionResult Postview_allCurriculum(view_allCurriculum view_allCurriculum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_allCurriculum.Add(view_allCurriculum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_allCurriculum.id }, view_allCurriculum);
        }

        // DELETE: api/Curriculum/5
        [ResponseType(typeof(Curriculum))]
        public IHttpActionResult Deleteview_allCurriculum(int id)
        {
            Curriculum view_allCurriculum = db.Curricula.Find(id);
            if (view_allCurriculum == null)
            {
                return NotFound();
            }

            db.Curricula.Remove(view_allCurriculum);
            db.SaveChanges();

            return Ok(view_allCurriculum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_allCurriculumExists(int id)
        {
            return db.Curricula.Count(e => e.id == id) > 0;
        }
    }
}