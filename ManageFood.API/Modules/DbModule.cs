using Autofac;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.SeedWork;

namespace ManageFood.API.Modules
{
  public class DbModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<SeedData>()
        .As<ISeedData>()
        .InstancePerLifetimeScope();
    }
  }
}
