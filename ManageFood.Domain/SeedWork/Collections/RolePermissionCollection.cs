using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class RolePermissionCollection
  {
    private int index = 0;
    private static readonly RoleCollection roles = SeedData.Roles;
    private static readonly PermissionCollection permissions = SeedData.Permissions;
    private readonly RolePermissionEntity[] rolePermissions = new RolePermissionEntity[6];

    public int Length => rolePermissions.Length;

    public RolePermissionCollection()
    {
      Init([
        new RolePermissionEntity
        {
          RoleId = roles[0],
          PermissionId = permissions[0],
          Created = new DateTimeOffset(2024, 3, 1, 17, 33, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = roles[0],
          PermissionId = permissions[1],
          Created = new DateTimeOffset(2024, 3, 9, 22, 12, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = roles[0],
          PermissionId = permissions[2],
          Created = new DateTimeOffset(2024, 3, 24, 11, 43, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = roles[0],
          PermissionId = permissions[3],
          Created = new DateTimeOffset(2024, 3, 25, 4, 28, 0, TimeSpan.FromHours(3)),
        },
        new RolePermissionEntity
        {
          RoleId = roles[1],
          PermissionId = permissions[2],
          Created = new DateTimeOffset(2024, 3, 25, 30, 1, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = roles[1],
          PermissionId = permissions[3],
          Created = new DateTimeOffset(2024, 3, 28, 1, 22, 0, TimeSpan.FromHours(3))
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
