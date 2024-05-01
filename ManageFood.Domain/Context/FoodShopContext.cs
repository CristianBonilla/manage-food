using Microsoft.EntityFrameworkCore;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.EntitiesConfig;
using ManageFood.Domain.Extensions;

namespace ManageFood.Domain.Context
{
  public class FoodShopContext(DbContextOptions<FoodShopContext> options) : DbContext(options)
  {
    readonly ISeedData? _seedData = options.GetSeedData();

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyEntityTypeConfig(_seedData,
        typeof(RoleConfig),
        typeof(PermissionConfig),
        typeof(RolePermissionConfig),
        typeof(UserConfig));
      builder.ApplyEntityTypeConfig(_seedData,
        typeof(CatalogueConfig),
        typeof(ProductConfig),
        typeof(InventoryConfig));
    }
  }
}
