using Microsoft.EntityFrameworkCore;
using ManageFood.Domain.EntitiesConfig;

namespace ManageFood.Domain.Context
{
  public class FoodShopContext(DbContextOptions<FoodShopContext> contextOptions) : DbContext(contextOptions)
  {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfig).Assembly);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodShopConfig).Assembly);
    }
  }
}
