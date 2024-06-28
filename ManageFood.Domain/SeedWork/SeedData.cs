using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.SeedWork.Collections;

namespace ManageFood.Domain.SeedWork
{
  public class SeedData : ISeedData
  {
    public SeedAuthData Auth => new()
    {
      Roles = AuthCollection.Roles,
      Permissions = AuthCollection.Permissions,
      RolePermissions = AuthCollection.RolePermissions
    };

    public SeedFoodShopData FoodShop => new()
    {
      Catalogues = FoodShopCollection.Catalogues,
      Products = FoodShopCollection.Products,
      Inventories = FoodShopCollection.Inventories,
      Orders = FoodShopCollection.Orders
    };
  }
}
