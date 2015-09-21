using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TddErp.Api.Infrastructure;
using TddErp.Api.Models;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace TddErp.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        private ModelFactory modelFactory;
        private ApplicationUserManager appUserManager = null;
        private ApplicationRoleManager appRoleManager = null;

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
     
        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (modelFactory == null)
                {
                    modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return modelFactory;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}