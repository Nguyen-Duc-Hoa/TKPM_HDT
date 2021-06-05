using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PurchaseController : ApiController
    {

        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        [HttpGet]
        [Route("api/Purchase/{idUser}")]

        public IQueryable<sp_Purchase_Result> GetPurchaseUser(int idUser)
        {
            return db.sp_Purchase().Where(x => x.id_user == idUser).OrderBy(x=>x.date).AsQueryable();
        }

    }
}
