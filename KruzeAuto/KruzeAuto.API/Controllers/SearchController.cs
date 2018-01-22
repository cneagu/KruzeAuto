using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace KruzeAuto.API.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {


        #region Methods
        //GET api/students
        //[HttpGet]
        //[Route("")]
        //public List<User> ReadAll()
        //{
        //    using (BusinessContext context = new BusinessContext())
        //    {
        //        return context.UserBusiness.ReadAll();
        //    }
        //}
        [HttpGet]
        [Route("")]
        public IHttpActionResult Search()
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string type = string.Empty;
            string brand = string.Empty;
            string condition = string.Empty;
            string fuel = string.Empty;
            string km = string.Empty;
            string model = string.Empty;
            string price = string.Empty;
            string registration = string.Empty;
            if (headers.Contains("type"))
            {
                type = headers.GetValues("type").First();
            }
            if (headers.Contains("brand"))
            {
                brand = headers.GetValues("brand").First();
            }
            if (headers.Contains("condition"))
            {
                condition = headers.GetValues("condition").First();
            }
            if (headers.Contains("fuel"))
            {
                fuel = headers.GetValues("fuel").First();
            }
            if (headers.Contains("km"))
            {
                km = headers.GetValues("km").First();
            }
            if (headers.Contains("model"))
            {
                model = headers.GetValues("model").First();
            }
            if (headers.Contains("price"))
            {
                price = headers.GetValues("price").First();
            }
            if (headers.Contains("brand"))
            {
                registration = headers.GetValues("registration").First();
            }         
            var data = type + brand + condition + fuel + km + model + price + registration;

            return Ok(data);
        }
        #endregion
    }
}