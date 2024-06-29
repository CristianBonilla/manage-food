using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.Entities.FoodShop
{
  public class InventoryEntity
  {
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
    public required decimal Unit {  get; set; }
    public required UnitType UnitType { get; set; }
    public required decimal Price { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
  }
}
