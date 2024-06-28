using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;
using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.SeedWork.Collections.Auth
{
  class PermissionCollection : SeedDataCollection<PermissionEntity>
  {
    protected override PermissionEntity[] Collection => [
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
        PermissionId = Permissions.AllowListOrderByUser.Id,
        Order = 3,
        Name = Permissions.AllowListOrderByUser.Name,
        DisplayName = "List Order By User",
        Created = new DateTimeOffset(2024, 3, 2, 8, 49, 33, TimeSpan.FromHours(3))
      },
      new PermissionEntity
      {
        PermissionId = Permissions.AllowCreateOrder.Id,
        Order = 4,
        Name = Permissions.AllowCreateOrder.Name,
        DisplayName = "Create Order",
        Created = new DateTimeOffset(2024, 3, 2, 20, 1, 0, TimeSpan.FromHours(3))
      }
    ];
  }
}
