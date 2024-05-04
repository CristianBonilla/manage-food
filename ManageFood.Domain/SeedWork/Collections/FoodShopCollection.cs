using ManageFood.Domain.SeedWork.Collections.FoodShop;

namespace ManageFood.Domain.SeedWork.Collections
{
  class FoodShopCollection
  {
    public static CatalogueCollection Catalogues => new();
    public static ProductCollection Products => new();
    public static InventoryCollection Inventories => new();
  }
}
