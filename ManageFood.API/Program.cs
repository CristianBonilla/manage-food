using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.API
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      IHost host = CreateHostBuilder(args).Build();
      await DbMigrationStart<FoodShopContext>(host);
      await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(builder =>
        {
          builder.UseStartup<Startup>();
        });

    private static async Task DbMigrationStart<TContext>(IHost host) where TContext : DbContext
    {
      using IServiceScope scope = host.Services.CreateScope();
      TContext context = scope.ServiceProvider.GetRequiredService<TContext>();
      await context.Database.MigrateAsync();
    }
  }
}
