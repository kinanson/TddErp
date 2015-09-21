using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TddErp.Model.Models;

namespace TddErp.Api.App_Start
{
    public class AutofacConfig
    {
        public static void Bootstrap(IAppBuilder app, HttpConfiguration config)
        {
            // 容器建立者
            var builder = new ContainerBuilder();

            // 註冊Web API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // 註冊相依關係              
            //Service
            builder.RegisterAssemblyTypes(Assembly.Load("TddErp.Service"))
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterType<ApplicationDbContext>().As<IContext>().InstancePerRequest();

            // 建立容器
            var container = builder.Build();

            // 建立相依解析器
            var resolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }
    }
}