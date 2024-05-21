using Autofac;
using ManageFood.Contracts.Services;
using ManageFood.Domain.Services;
using ManageFood.Infrastructure.Repositories.Auth;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;

namespace ManageFood.API.Modules
{
  class AuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<RoleRepository>()
        .As<IRoleRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<PermissionRepository>()
        .As<IPermissionRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<RolePermissionRepository>()
        .As<IRolePermissionRepository>()
        .InstancePerLifetimeScope();
      builder.RegisterType<UserRepository>()
        .As<IUserRepository>()
        .InstancePerLifetimeScope();

      builder.RegisterType<AuthService>()
        .As<IAuthService>()
        .InstancePerLifetimeScope();
    }
  }
}
