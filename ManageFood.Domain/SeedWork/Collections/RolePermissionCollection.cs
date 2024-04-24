using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class RolePermissionCollection
  {
    public static IEnumerable<RolePermissionEntity> List =>
    [
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
    ];

    public RolePermissionEntity this[int index] => List.ElementAt(index);
  }
}
