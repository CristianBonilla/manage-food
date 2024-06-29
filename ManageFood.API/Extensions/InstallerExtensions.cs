using System.Reflection;
using ManageFood.API.Installers;

namespace ManageFood.API.Extensions
{
  static class InstallerExtensions
  {
    public static void InstallServicesFromAssembly(
      this IServiceCollection services,
      IConfiguration configuration,
      IWebHostEnvironment env)
    {
      IInstaller[] installers = Assembly.GetExecutingAssembly().GetTypes()
        .Where(type => typeof(IInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IInstaller>()
        .ToArray();
      foreach (IInstaller installer in installers)
        installer.InstallServices(services, configuration, env);
    }
  }
}
