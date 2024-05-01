using Microsoft.EntityFrameworkCore;
using ManageFood.Domain.Context;
using ManageFood.Domain.Helpers;
using ManageFood.Domain.Extensions;
using ManageFood.Domain.SeedWork;

namespace ManageFood.API.Installers
{
  class DbInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
      string? connectionString = configuration.GetConnectionString(ApiConfigKeys.ManageFoodConnection) ?? throw new InvalidOperationException($"Connection string '{ApiConfigKeys.ManageFoodConnection}' not established");
      services.AddDbContextPool<FoodShopContext>(options =>
      {
        options.Options.SetSeedData(new SeedData());
        options.UseSqlServer(connectionString);
      });
    }
  }
}
