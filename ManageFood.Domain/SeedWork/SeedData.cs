using ManageFood.Domain.Entities;
using ManageFood.Domain.SeedWork.Collections;
using ManageFood.Domain.SeedWork.Collections.Shop;

namespace ManageFood.Domain.SeedWork
{
  class SeedData
  {
    public static IEnumerable<RoleEntity> Roles => RoleCollection.List;
    public static IEnumerable<PermissionEntity> Permissions => PermissionCollection.List;
    public static IEnumerable<RolePermissionEntity> RolePermissions => RolePermissionCollection.List;

    internal class Shop
    {
      public static CatalogueCollection Catalogues => new();
      public static ProductCollection Products => new();
      public static InventoryCollection Inventories => new();
    }
  }
}
