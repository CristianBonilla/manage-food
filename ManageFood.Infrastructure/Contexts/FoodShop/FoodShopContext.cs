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
      builder.ApplyEntityTypeConfig(seedData,
        typeof(RoleConfig),
        typeof(PermissionConfig),
        typeof(RolePermissionConfig),
        typeof(UserConfig));
      builder.ApplyEntityTypeConfig(seedData,
        typeof(CatalogueConfig),
        typeof(ProductConfig),
        typeof(InventoryConfig));
    }
  }
}
