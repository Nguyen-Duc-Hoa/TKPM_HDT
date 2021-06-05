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
    public class SearchController : ApiController
    {
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        [HttpGet]
        [Route("api/Search/{text}")]
        public IQueryable<sp_searchName_Result> SearchbyName(string text)
        {
            return db.sp_searchName(text).AsQueryable();
        }
    }
}
