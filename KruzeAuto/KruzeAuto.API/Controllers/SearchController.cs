using KruzeAuto.API.Models;
using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KruzeAuto.API.Controllers
{
    [RoutePrefix("api/Search")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        #region Methods
        [HttpPost]
        [Route("")]
        public List<Search> ReadAll([FromBody] MainSearch search)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.SearchBusiness.MainSearch(search.Type, search.Condition, search.Brand, search.Model, search.Km,
                    search.Registration, search.Fuel[0], search.Fuel[1], search.Fuel[2], search.Fuel[3], search.Fuel[4], search.Fuel[5], search.Fuel[6], search.Price);
            }
        }
        #endregion
    }
}