using Autofac;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWork;
using ECommerce.Repository;
using ECommerce.Repository.Repositories;
using ECommerce.Repository.UnitOfWork;
using ECommerce.Service.Mapping;
using ECommerce.Service.Services;
using System.Reflection;

namespace ECommerce.Api.Modules
{
    public class RepositoryServiceDependencyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
           builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();

           builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

           var apiAssembly = Assembly.GetExecutingAssembly();
           var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
           var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

          builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

          builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
                  .AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
