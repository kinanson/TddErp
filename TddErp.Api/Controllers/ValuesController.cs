using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TddErp.Api.GenerateCore;
using TddErp.Model.Enum;

namespace TddErp.Api.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize]
        // GET: api/Value
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        public string Get(TemplateEnum Id)
        {
            switch (Id)
            {
                case TemplateEnum.Master:
                    return ChooseTemplate.GetMasterTemplate();
                case TemplateEnum.MasterDtoName:
                    return "value";
                case TemplateEnum.MasterDetail:
                    return "value";
                default:
                    return "value";
            }
        }

        // POST: api/Value
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Value/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Value/5
        public void Delete(int id)
        {
        }
    }
}
