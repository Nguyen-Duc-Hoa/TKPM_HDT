using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CartController : ApiController
    {

        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        [HttpGet]
        [Route("api/Cart/{idUser}")]
        public IQueryable<sp_Cart_Result> GetCart(int idUser)
        {
            return db.sp_Cart(idUser).AsQueryable();
        }

    }
}
