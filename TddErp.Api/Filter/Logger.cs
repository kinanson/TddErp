using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TddErp.Api.Filter
{
    public class Logger : ActionFilterAttribute
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var result = actionContext.ActionArguments.Values;
            if (result.Count > 0)
            {
                logger.Info(JsonConvert.SerializeObject(result));
            }
        }
    }
}