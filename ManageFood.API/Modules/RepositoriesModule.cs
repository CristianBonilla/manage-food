using Autofac;
using ManageFood.Contracts.Repository;
using ManageFood.Infrastructure.Repositories;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.API.Modules
{
  public class RepositoriesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(RepositoryContext<>))
        .As(typeof(IRepositoryContext<>))
        .InstancePerLifetimeScope();
      builder.RegisterGeneric(typeof(Repository<,>))
        .As(typeof(IRepository<,>))
        .InstancePerLifetimeScope();
      builder.RegisterType<FoodShopRepositoryContext>()
        .As<IFoodShopRepositoryContext>()
        .InstancePerLifetimeScope();
    }
  }
}
