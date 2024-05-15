using ManageFood.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ManageFood.API.Extensions
{
  static class DbStartExtensions
  {
    public static async Task DbStart<TContext>(this IHost host, DbInitializers initializer) where TContext : DbContext
    {
      await using AsyncServiceScope scope = host.Services.CreateAsyncScope();
      DatabaseFacade database = DatabaseInstance<TContext>(scope);

      await (initializer switch
      {
        DbInitializers.OpenConnection => database.OpenConnectionAsync(),
        DbInitializers.EnsureCreated => database.EnsureCreatedAsync(),
        DbInitializers.Migrate => database.MigrateAsync(),
        _ => throw new ArgumentOutOfRangeException(nameof(initializer), $"Not expected initializer value: {initializer}")
      });
    }

    private static DatabaseFacade DatabaseInstance<TContext>(AsyncServiceScope scope) where TContext : DbContext
    {
      TContext context = scope.ServiceProvider.GetRequiredService<TContext>();

      return context.Database;
    }
  }
}
