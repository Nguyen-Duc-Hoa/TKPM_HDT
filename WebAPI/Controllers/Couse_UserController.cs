using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Couse_UserController : ApiController
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        [Route("api/Course_User/{id}")]
        public IQueryable<sp_Couse_User_Result> getCourse_User(int id)
        {
            return db.sp_Couse_User(id).Where(x => x.state == true).AsQueryable();
        }
       
        [HttpGet]
        [Route("api/Course_User/notBought/{idUser}")]

        public IQueryable<sp_notBought_Result> getCourse_notBought(int idUser)
        {
            return db.sp_notBought(idUser).Where(x => x.state == true).AsQueryable();
        }

    }
}