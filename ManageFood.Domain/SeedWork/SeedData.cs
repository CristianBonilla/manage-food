using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.SeedWork.Collections;
using ManageFood.Domain.SeedWork.Collections.FoodShop;

namespace ManageFood.Domain.SeedWork
{
  public class SeedData : ISeedData
  {
    public SeedAuthData Auth => new()
    {
      Roles = new RoleCollection(),
      Permissions = new PermissionCollection(),
      RolePermissions = new RolePermissionCollection()
    };

    public SeedFoodShopData FoodShop => new()
    {
      Catalogues = new CatalogueCollection(),
      Products = new ProductCollection(),
      Inventories = new InventoryCollection()
    };
  }
}
