using ManageFood.Domain.Entities;
using ManageFood.Domain.SeedWork.Collections;
using ManageFood.Domain.SeedWork.Collections.Shop;

namespace ManageFood.Domain.SeedWork
{
  class SeedData
  {
    public static RoleCollection Roles => new();
    public static PermissionCollection Permissions => new();
    public static RolePermissionCollection RolePermissions => new();

    internal class Shop
    {
      public static CatalogueCollection Catalogues => new();
      public static ProductCollection Products => new();
      public static InventoryCollection Inventories => new();
    }
  }
}
