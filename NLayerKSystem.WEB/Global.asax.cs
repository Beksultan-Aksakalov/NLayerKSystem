using Autofac;
using Autofac.Integration.Mvc;
using NLayerKSystem.BLL;
using NLayerKSystem.BLL.Service;
using NLayerKSystem.DAL;
using NLayerKSystem.WEB.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace NLayerKSystem.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new DALModule("KSystemContext"));
            builder.RegisterModule(new BLLModule());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
