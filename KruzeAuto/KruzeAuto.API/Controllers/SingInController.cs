using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KruzeAuto.API.Controllers
{
    [RoutePrefix("api/SingIn")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SingInController : ApiController
    {
        #region Methods
        //GET api/students
        [HttpPost]
        [Route("")]
        public User ReadSingIn([FromBody] User singIn)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserBusiness.ReadSingIn(singIn.Email, singIn.UserName, singIn.PhoneNumber);
            }
        }

       
        
        #endregion
    }
}