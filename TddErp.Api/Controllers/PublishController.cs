using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TddErp.Common;
using TddErp.Model.Models;
using TddErp.Service.Interface;

namespace TddErp.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [RoutePrefix("Api/Publish")]
    public class PublishController : BaseApiController
    {
        IPublishService service;

        public PublishController(IPublishService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            return Ok(service.GetAll().SelectMany(x=>x.Books).ToList());
        }

        public IHttpActionResult Get(string publishID)
        {
            return Ok(service.Get(publishID));
        }
        
        public IHttpActionResult post(Publish publish)
        { 
            service.Add(publish);
            return Ok();
        }

        public IHttpActionResult delete(string publishID)
        {
            var publish = service.Get(publishID);
            service.Delete(publish);
            return Ok();
        }
    }
}
