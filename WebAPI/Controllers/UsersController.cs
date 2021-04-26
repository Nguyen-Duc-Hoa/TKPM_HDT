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
    public class UsersController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: api/Users
        public IQueryable<view_allUsers> Getview_allUsers()
        {
            return db.view_allUsers;
        }

        // GET: api/Users/5
        [ResponseType(typeof(view_allUsers))]
        public IHttpActionResult Getview_allUsers(int id)
        {
            view_allUsers view_allUsers = db.view_allUsers.Find(id);
            if (view_allUsers == null)
            {
                return NotFound();
            }

            return Ok(view_allUsers);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putview_allUsers(int id, view_allUsers view_allUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_allUsers.id)
            {
                return BadRequest();
            }

            db.Entry(view_allUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!view_allUsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(view_allUsers))]
        public IHttpActionResult Postview_allUsers(view_allUsers view_allUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.view_allUsers.Add(view_allUsers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = view_allUsers.id }, view_allUsers);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(view_allUsers))]
        public IHttpActionResult Deleteview_allUsers(int id)
        {
            view_allUsers view_allUsers = db.view_allUsers.Find(id);
            if (view_allUsers == null)
            {
                return NotFound();
            }

            db.view_allUsers.Remove(view_allUsers);
            db.SaveChanges();

            return Ok(view_allUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool view_allUsersExists(int id)
        {
            return db.view_allUsers.Count(e => e.id == id) > 0;
        }
    }
}