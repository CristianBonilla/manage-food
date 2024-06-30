using Autofac;
using ManageFood.Infrastructure.Repositories.FoodShop;
using ManageFood.Infrastructure.Repositories.FoodShop.Interfaces;

namespace ManageFood.API.Modules
{
  class FoodShopModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<CatalogueRepository>()
        .As<ICatalogueRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<ProductRepository>()
        .As<IProductRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<InventoryRepository>()
        .As<IInventoryRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<OrderRepository>()
        .As<IOrderRepository>()
        .InstancePerLifetimeScope();
    }
  }
}
