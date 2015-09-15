using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TddErp.Api.App_Start;
using TddErp.Api.Filter;
using TddErp.Api.Infrastructure;
using TddErp.Model.Models;

namespace TddErp.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig autofacConfig = new AutofacConfig();
            HttpConfiguration config = new HttpConfiguration();
            AddFilter(config);
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            AutofacConfig.Bootstrap(app, config);
            app.UseWebApi(config);
        }

        private static void AddFilter(HttpConfiguration config)
        {
            config.Services.Add(typeof(IExceptionLogger), new NlogExceptionLogger());
            //config.Filters.Add(new StartLogger());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}