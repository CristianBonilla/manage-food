using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections.Auth
{
  class RolePermissionCollection : ISeedDataCollection<(Guid RoleId, Guid PermissionId), RolePermissionEntity>
  {
    int _index;
    static readonly RoleCollection _roles = AuthCollection.Roles;
    static readonly PermissionCollection _permissions = AuthCollection.Permissions;
    readonly RolePermissionEntity[] _rolePermissions = new RolePermissionEntity[6];

    public int Length => _rolePermissions.Length;

    public RolePermissionCollection()
    {
      Init([
        new RolePermissionEntity
        {
          RoleId = _roles[0],
          PermissionId = _permissions[0],
          Created = new DateTimeOffset(2024, 3, 1, 17, 33, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = _roles[0],
          PermissionId = _permissions[1],
          Created = new DateTimeOffset(2024, 3, 9, 22, 12, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = _roles[0],
          PermissionId = _permissions[2],
          Created = new DateTimeOffset(2024, 3, 24, 11, 43, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = _roles[0],
          PermissionId = _permissions[3],
          Created = new DateTimeOffset(2024, 3, 25, 4, 28, 0, TimeSpan.FromHours(3)),
        },
        new RolePermissionEntity
        {
          RoleId = _roles[1],
          PermissionId = _permissions[2],
          Created = new DateTimeOffset(2024, 3, 25, 0, 1, 0, TimeSpan.FromHours(3))
        },
        new RolePermissionEntity
        {
          RoleId = _roles[1],
          PermissionId = _permissions[3],
          Created = new DateTimeOffset(2024, 3, 28, 1, 22, 0, TimeSpan.FromHours(3))
        }
      ]);
    }

    public (Guid RoleId, Guid PermissionId) this[int index] => Id(_rolePermissions.ElementAt(index));

    public IEnumerable<RolePermissionEntity> GetAll() => [.. _rolePermissions];

    private void Init(params RolePermissionEntity[] rolePermissions)
    {
      foreach (RolePermissionEntity rolePermission in rolePermissions)
        _rolePermissions[_index++] = rolePermission;
    }

    private static (Guid RoleId, Guid PermissionId) Id(RolePermissionEntity rolePermission) => (rolePermission.RoleId, rolePermission.PermissionId);
  }
}
