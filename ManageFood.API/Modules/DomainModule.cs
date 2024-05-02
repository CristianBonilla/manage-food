using Autofac;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.SeedWork;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.API.Modules
{
  public class DomainModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<SeedData>()
        .As<ISeedData>()
        .InstancePerLifetimeScope();
      builder.RegisterType<FoodShopRepositoryContext>()
        .As<IFoodShopRepositoryContext>()
        .InstancePerLifetimeScope();
    }
  }
}
