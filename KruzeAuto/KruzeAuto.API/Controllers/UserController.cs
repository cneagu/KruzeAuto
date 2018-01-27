using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KruzeAuto.API.Controllers
{
    [RoutePrefix("api/User")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("Insert")]
        public int Insert([FromBody] User singIn)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserBusiness.Insert(singIn);
                return 1;
            }

        }

        [HttpGet]
        [Route("LogIn/{email}/{password}")]
        public Guid GetGuid(string email, string password)
        {
            using(BusinessContext context = new BusinessContext())
            {
                return context.UserBusiness.ReadLogIn(email, password);
 
            }           
        }

        [HttpPost]
        [Route("ReadById/{id}")]
        public User ReadById(Guid id)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserBusiness.ReadByID(id);

            }
        }

        [HttpPost]
        [Route("UserLocation/Insert")]
        public int Insert([FromBody] UserLocation singIn)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserLocationBusiness.Insert(singIn);
                return 1;
            }

        }
    }
}