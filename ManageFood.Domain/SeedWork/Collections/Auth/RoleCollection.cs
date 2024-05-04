using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;
using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.SeedWork.Collections.Auth
{
  class RoleCollection : ISeedDataCollection<Guid, RoleEntity>
  {
    int _index;
    readonly RoleEntity[] _roles = new RoleEntity[2];

    public int Length => _roles.Length;

    public RoleCollection()
    {
      Init([
        new RoleEntity
        {
          RoleId = Roles.AdminUser.Id,
          Name = Roles.AdminUser.Name,
          DisplayName = "Administrator",
          Created = new DateTimeOffset(2024, 1, 10, 12, 30, 0, TimeSpan.FromHours(3))
        },
        new RoleEntity
        {
          RoleId = Roles.CommonUser.Id,
          Name = Roles.CommonUser.Name,
          DisplayName = "Common User",
          Created = new DateTimeOffset(2024, 2, 5, 16, 23, 11, TimeSpan.FromHours(3))
        }
      ]);
    }

    public Guid this[int index] => _roles.ElementAt(index).RoleId;

    public IEnumerable<RoleEntity> GetAll() => [.. _roles];

    private void Init(params RoleEntity[] roles)
    {
      foreach (RoleEntity role in roles)
        _roles[_index++] = role;
    }
  }
}
