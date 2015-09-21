using System.Linq;
using System.Web.Http;
using TddErp.Model.Models;
using TddErp.Service.Interface;

namespace TddErp.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("Api/Publish")]
    public class PublishController : BaseApiController
    {
        private IPublishService service;

        public PublishController(IPublishService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            return Ok(service.GetAll().SelectMany(x => x.Books).ToList());
        }

        public IHttpActionResult Get(string publishID)
        {
            return Ok(service.Get(publishID));
        }

        public IHttpActionResult Post(Publish publish)
        {
            service.Add(publish);
            return Ok();
        }

        public IHttpActionResult Delete(string publishID)
        {
            var publish = service.Get(publishID);
            service.Delete(publish);
            return Ok();
        }
    }
}