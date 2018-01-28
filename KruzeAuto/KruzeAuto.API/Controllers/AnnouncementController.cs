using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KruzeAuto.API.Controllers
{
    [RoutePrefix("api/Announcement")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnnouncementController : ApiController
    {
        #region Methods
        [HttpPost]
        [Route("InsertAnnouncement")]
        public int InsertAnnouncement([FromBody] Announcement announcement)
        {
            using (BusinessContext context = new BusinessContext())
            {
                 context.AnnouncementBusiness.Insert(announcement);
                return 1;
            }
        }
        #endregion

    }
}