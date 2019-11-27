using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using EghteenPlus.Contracts;
using EghteenPlus.DA;
using EghteenPlus.Services;
using System.Web.Mvc;

namespace EghteenPlus.IoC
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<DataService>().As<IDataService>().WithParameter("context", new EPContext()).SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

 
