using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections.Auth
{
  class RolePermissionCollection : SeedDataCollection<RolePermissionEntity>
  {
    static readonly RoleCollection _roles = AuthCollection.Roles;
    static readonly PermissionCollection _permissions = AuthCollection.Permissions;

    protected override RolePermissionEntity[] Collection => [
      new RolePermissionEntity
      {
        RoleId = _roles[0].RoleId,
        PermissionId = _permissions[0].PermissionId,
        Created = new DateTimeOffset(2024, 3, 1, 17, 33, 0, TimeSpan.FromHours(3))
      },
      new RolePermissionEntity
      {
        RoleId = _roles[0].RoleId,
        PermissionId = _permissions[1].PermissionId,
        Created = new DateTimeOffset(2024, 3, 9, 22, 12, 0, TimeSpan.FromHours(3))
      },
      new RolePermissionEntity
      {
        RoleId = _roles[0].RoleId,
        PermissionId = _permissions[2].PermissionId,
        Created = new DateTimeOffset(2024, 3, 24, 11, 43, 0, TimeSpan.FromHours(3))
      },
      new RolePermissionEntity
      {
        RoleId = _roles[0].RoleId,
        PermissionId = _permissions[3].PermissionId,
        Created = new DateTimeOffset(2024, 3, 25, 4, 28, 0, TimeSpan.FromHours(3)),
      },
      new RolePermissionEntity
      {
        RoleId = _roles[1].RoleId,
        PermissionId = _permissions[2].PermissionId,
        Created = new DateTimeOffset(2024, 3, 25, 0, 1, 0, TimeSpan.FromHours(3))
      },
      new RolePermissionEntity
      {
        RoleId = _roles[1].RoleId,
        PermissionId = _permissions[3].PermissionId,
        Created = new DateTimeOffset(2024, 3, 28, 1, 22, 0, TimeSpan.FromHours(3))
      }
    ];

    public RolePermissionCollection() : base(6) { }
  }
}
