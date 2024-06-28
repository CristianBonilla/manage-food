using ManageFood.Domain.Entities.FoodShop;

namespace ManageFood.Contracts.DTO.SeedData
{
  public class SeedFoodShopData
  {
    public required SeedDataCollection<CatalogueEntity> Catalogues { get; set; }
    public required SeedDataCollection<ProductEntity> Products { get; set; }
    public required SeedDataCollection<InventoryEntity> Inventories { get; set; }
    public required SeedDataCollection<OrderEntity> Orders { get; set; }
  }
}
