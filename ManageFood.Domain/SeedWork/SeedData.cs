using ManageFood.Domain.Entities;
using ManageFood.Domain.SeedWork.Collections;

namespace ManageFood.Domain.SeedWork
{
  class SeedData
  {
    public static IEnumerable<RoleEntity> Roles => RoleCollection.List;
    public static IEnumerable<PermissionEntity> Permissions => PermissionCollection.List;
    public static IEnumerable<RolePermissionEntity> RolePermissions => RolePermissionCollection.List;
  }
}
