using ManageFood.Domain.SeedWork.Collections.Auth;

namespace ManageFood.Domain.SeedWork.Collections
{
  class AuthCollection
  {
    public static RoleCollection Roles => new();
    public static PermissionCollection Permissions => new();
    public static RolePermissionCollection RolePermissions => new();
  }
}
