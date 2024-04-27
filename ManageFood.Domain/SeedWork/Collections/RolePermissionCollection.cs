using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class RolePermissionCollection
  {
    private int index = 0;
    private readonly RolePermissionEntity[] rolePermissions = new RolePermissionEntity[5];

    public int Length => rolePermissions.Length;

    public RolePermissionCollection()
    {
      Init([
        new RolePermissionEntity
        {
          RoleId = Roles.AdminUser.Id,
          PermissionId = Permissions.AllowManageFood.Id,
          Created = new DateTimeOffset(2024, 3, 1, 17, 33, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = Roles.AdminUser.Id,
          PermissionId = Permissions.AllowListOrders.Id,
          Created = new DateTimeOffset(2024, 3, 9, 22, 12, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = Roles.AdminUser.Id,
          PermissionId = Permissions.AllowCreateOrder.Id,
          Created = new DateTimeOffset(2024, 3, 24, 11, 43, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = Roles.CommonUser.Id,
          PermissionId = Permissions.AllowListOrderByUser.Id,
          Created = new DateTimeOffset(2024, 3, 24, 17, 8, 0, TimeSpan.FromHours(3)),
        },
        new RolePermissionEntity
        {
          RoleId = Roles.CommonUser.Id,
          PermissionId = Permissions.AllowCreateOrder.Id,
          Created = new DateTimeOffset(2024, 3, 24, 19, 17, 0, TimeSpan.FromHours(3))
        }
      ]);
    }

    public (Guid RoleId, Guid PermissionId) this[int index] => Id(rolePermissions.ElementAt(index));

    public RolePermissionEntity[] GetAll() => [.. rolePermissions];

    private void Init(params RolePermissionEntity[] rolePermissions)
    {
      foreach (RolePermissionEntity rolePermission in rolePermissions)
        this.rolePermissions[index++] = rolePermission;
    }

    private static (Guid RoleId, Guid PermissionId) Id(RolePermissionEntity rolePermission) => (rolePermission.RoleId, rolePermission.PermissionId);
  }
}
