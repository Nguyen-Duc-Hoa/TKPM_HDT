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
    public class BookdetailsController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Bookdetails
        public IQueryable<view_Bookdetail> GetBookdetails()
        {
            return db.view_Bookdetail;
        }

        // GET: api/Bookdetails/5

        public IQueryable<view_Bookdetail> GetBookdetails(int id_student)
        {
            List<view_Bookdetail> bookdetail = (from s in db.view_Bookdetail where s.id_student == id_student select s).ToList();


            return bookdetail.AsQueryable();
        }

        [ResponseType(typeof(view_Bookdetail))]
        public IHttpActionResult GetBookdetail(int id_student, int id_course)
        {
            view_Bookdetail bookdetail = db.getBookdetail1(id_student, id_course).FirstOrDefault();
            if (bookdetail == null)
            {
                return NotFound();
            }


            return Ok(bookdetail);
        }


        // POST: api/Bookdetails
        [ResponseType(typeof(view_Bookdetail))]
        public IHttpActionResult PostBookdetail(view_Bookdetail bookdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_Bookdetail.Add(bookdetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BookdetailExists(bookdetail.id_student))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookdetail.id_student }, bookdetail);
        }

        // DELETE: api/Bookdetails/5
        [ResponseType(typeof(view_Bookdetail))]
        public IHttpActionResult DeleteBookdetail(int id_student, int id_course)
        {
            view_Bookdetail bookdetail = db.getBookdetail1(id_student, id_course).FirstOrDefault();

            if (bookdetail == null)
            {
                return NotFound();
            }

            db.view_Bookdetail.Remove(bookdetail);
            db.SaveChanges();

            return Ok(bookdetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookdetailExists(int id)
        {
            return db.view_Bookdetail.Count(e => e.id_student == id) > 0;
        }
    }
}