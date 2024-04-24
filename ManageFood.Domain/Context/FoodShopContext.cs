using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ManageFood.Domain.Context
{
  public class FoodShopContext(DbContextOptions<FoodShopContext> contextOptions) : DbContext(contextOptions)
  {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
