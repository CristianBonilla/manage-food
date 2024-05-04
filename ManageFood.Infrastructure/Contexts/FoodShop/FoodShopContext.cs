using Microsoft.EntityFrameworkCore;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Infrastructure.Extensions;
using ManageFood.Infrastructure.Contexts.FoodShop.Config;

namespace ManageFood.Infrastructure.Contexts.FoodShop
{
  public class FoodShopContext(DbContextOptions<FoodShopContext> options, ISeedData seedData) : DbContext(options)
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new RoleConfig(seedData));
      builder.ApplyConfiguration(new PermissionConfig(seedData));
      builder.ApplyConfiguration(new RolePermissionConfig(seedData));
      builder.ApplyConfiguration(new UserConfig());

      builder.ApplyConfiguration(new CatalogueConfig(seedData));
      builder.ApplyConfiguration(new ProductConfig(seedData));
      builder.ApplyConfiguration(new InventoryConfig(seedData));

      //builder.ApplyEntityTypeConfig(seedData,
      //  typeof(RoleConfig),
      //  typeof(PermissionConfig),
      //  typeof(RolePermissionConfig),
      //  typeof(UserConfig));
      //builder.ApplyEntityTypeConfig(seedData,
      //  typeof(CatalogueConfig),
      //  typeof(ProductConfig),
      //  typeof(InventoryConfig));
    }
  }
}
