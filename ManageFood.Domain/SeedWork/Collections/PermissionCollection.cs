using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class PermissionCollection
  {
    private int index = 0;
    private readonly PermissionEntity[] permissions = new PermissionEntity[3];

    public int Length => permissions.Length;

    public Guid this[int index] => permissions.ElementAt(index).PermissionId;

    public PermissionEntity[] GetAll() => permissions;

    public PermissionCollection()
    {
      Init([
        new PermissionEntity
        {
          PermissionId = Permissions.AllowManageFood.Id,
          Order = 1,
          Name = Permissions.AllowManageFood.Name,
          DisplayName = "Manage Food",
          Created = new DateTimeOffset(2024, 2, 24, 10, 10, 0, TimeSpan.FromHours(3))
        },
        new PermissionEntity
        {
          PermissionId = Permissions.AllowListOrders.Id,
          Order = 2,
          Name = Permissions.AllowListOrders.Name,
          DisplayName = "List Orders",
          Created = new DateTimeOffset(2024, 3, 1, 14, 5, 0, TimeSpan.FromHours(3))
        },
        new PermissionEntity
        {
          PermissionId = Permissions.AllowCreateOrder.Id,
          Order = 3,
          Name = Permissions.AllowCreateOrder.Name,
          DisplayName = "Create Order",
          Created = new DateTimeOffset(2024, 3, 2, 20, 1, 0, TimeSpan.FromHours(3))
        }
      ]);
    }

    private void Init(params PermissionEntity[] permissions)
    {
      foreach (PermissionEntity permission in permissions)
        this.permissions[index++] = permission;
    }
  }
}
