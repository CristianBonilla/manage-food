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

    class Shop
    {
      public static IEnumerable<CatalogueEntity> Catalogues => CatalogueCollection.List;
      public static IEnumerable<ProductEntity> Products => ProductCollection.List;
    }
  }
}
