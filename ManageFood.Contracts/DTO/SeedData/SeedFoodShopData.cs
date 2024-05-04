using ManageFood.Domain.Entities.FoodShop;

namespace ManageFood.Contracts.DTO.SeedData
{
  public class SeedFoodShopData
  {
    public required ISeedDataCollection<Guid, CatalogueEntity> Catalogues { get; set; }
    public required ISeedDataCollection<ProductEntity, ProductEntity> Products { get; set; }
    public required ISeedDataCollection<Guid, InventoryEntity> Inventories { get; set; }
  }
}
