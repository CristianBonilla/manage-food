using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class RoleCollection
  {
    private int index = 0;
    private readonly RoleEntity[] roles = new RoleEntity[2];

    public int Length => roles.Length;

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

    public Guid this[int index] => roles.ElementAt(index).RoleId;

    public RoleEntity[] GetAll() => [.. roles];

    private void Init(params RoleEntity[] roles)
    {
      foreach (RoleEntity role in roles)
        this.roles[index++] = role;
    }
  }
}
