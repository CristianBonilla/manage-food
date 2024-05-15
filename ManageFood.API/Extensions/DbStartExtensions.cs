using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ManageFood.API.Extensions
{
  static class DbStartExtensions
  {
    public static (Func<Task> OpenConnection, Func<Task> EnsureCreated, Func<Task> Migration) DbStart<TContext>(this IHost host) where TContext : DbContext
    {
      AsyncServiceScope scope = host.Services.CreateAsyncScope();
      TContext context = scope.ServiceProvider.GetRequiredService<TContext>();
      DatabaseFacade database = context.Database;

      return (OpenConnection, EnsureCreated, Migration);

      async Task OpenConnection()
      {
        await using (scope.ConfigureAwait(false))
        {
          await database.OpenConnectionAsync();
        }
      }

      async Task EnsureCreated()
      {
        await using (scope.ConfigureAwait(false))
        {
          await database.EnsureCreatedAsync();
        }
      }

      async Task Migration()
      {
        await using (scope.ConfigureAwait(false))
        {
          await database.MigrateAsync();
        }
      }
    }
  }
}
