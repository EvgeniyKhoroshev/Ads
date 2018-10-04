using AppServices.ServiceInterfaces;
using AppServices.Services;
using Domain;
using Domain.Data.Repositories;
using Domain.RepositoryInterfaces;
using SimpleInjector;
namespace WebApi.ComponentRegistrar
{
    public static class SimpleRegistrar
    {
        public static void RegisterAll(Container container)
        {
            container.Register<IAdvertRepository, AdvertRepository>();
            container.Register<IAdvertService, AdvertService>();
            container.Register<AdsDBContext>(ScopedLifestyle.Scoped);


        }
    }
}
