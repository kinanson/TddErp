using System.Collections.Generic;
using System.Web.Http;
using TddErp.Api.GenerateCore;
using TddErp.Model.Enum;

namespace TddErp.Api.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        public string Get(TemplateEnum id)
        {
            switch (id)
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