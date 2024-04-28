using Microsoft.EntityFrameworkCore;
using ManageFood.Domain.Context;
using ManageFood.Domain.Helpers;

namespace ManageFood.API.Installers
{
  class DbInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
      //string? connectionString = configuration.GetConnectionString(ApiConfigKeys.ManageFoodConnection);
      //if (connectionString is not null)
      //  services.AddDbContextPool<FoodShopContext>(options => options.UseSqlServer(connectionString));
    }
  }
}
