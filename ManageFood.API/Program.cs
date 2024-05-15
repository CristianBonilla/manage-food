using Autofac.Extensions.DependencyInjection;
using ManageFood.API.Extensions;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.API
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      IHost host = CreateHostBuilder(args).Build();
      await host.DbStart<FoodShopContext>().Migration();
      await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(builder =>
        {
          builder.UseStartup<Startup>();
        });
  }
}
