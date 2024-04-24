using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections
{
  class PermissionCollection
  {
    public static IEnumerable<PermissionEntity> List =>
    [
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
    ];

    public Guid this[int index] => List.ElementAt(index).PermissionId;
  }
}
