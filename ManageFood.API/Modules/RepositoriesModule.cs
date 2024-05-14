using Autofac;
using Autofac.Core;
using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories;
using ManageFood.Infrastructure.Repositories.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces.Auth;
using ManageFood.Infrastructure.Repositories.Interfaces.FoodShop;

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

      //builder.RegisterType<Repository<FoodShopContext, RoleEntity>>()
      //  .As<IRepository<FoodShopContext, RoleEntity>>()
      //  .InstancePerLifetimeScope();

      //builder.RegisterType<Repository<FoodShopContext, PermissionEntity>>()
      //  .As<IPermissionRepository>()
      //  .InstancePerLifetimeScope();
      //builder.RegisterType<Repository<FoodShopContext, RolePermissionEntity>>()
      //  .As<IRolePermissionRepository>()
      //  .InstancePerLifetimeScope();
      //builder.RegisterType<Repository<FoodShopContext, UserEntity>>()
      //  .As<IUserRepository>()
      //  .InstancePerLifetimeScope();

      //builder.RegisterType<Repository<FoodShopContext, CatalogueEntity>>()
      //  .As<ICatalogueRepository>()
      //  .InstancePerLifetimeScope();
      //builder.RegisterType<Repository<FoodShopContext, ProductEntity>>()
      //  .As<IProductRepository>()
      //  .InstancePerLifetimeScope();
      //builder.RegisterType<Repository<FoodShopContext, InventoryEntity>>()
      //  .As<IInventoryRepository>()
      //  .InstancePerLifetimeScope();
    }
  }
}
