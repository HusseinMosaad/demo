using Microsoft.Practices.Unity;
using OnlineStore.Entity.Database.ProductRepository;
using OnlineStore.Service.ProductService;
using System.Web.Http;
using Unity.WebApi;

namespace OnlineStore.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}