using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KruzeAuto.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        #region Methods
        //GET api/students
        [HttpGet]
        [Route("")]
        public List<Announcement> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.AnnouncementBusiness.ReadAll();
            }
        }
    }
    #endregion

}