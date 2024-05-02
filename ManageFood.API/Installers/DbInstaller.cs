using Microsoft.EntityFrameworkCore;
using ManageFood.Domain.Helpers;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.API.Installers
{
  class DbInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
      string? connectionString = configuration.GetConnectionString(ApiConfigKeys.ManageFoodConnection) ?? throw new InvalidOperationException($"Connection string '{ApiConfigKeys.ManageFoodConnection}' not established");
      services.AddDbContextPool<FoodShopContext>(options =>
      {
        options.UseSqlServer(connectionString);
      });
    }
  }
}
