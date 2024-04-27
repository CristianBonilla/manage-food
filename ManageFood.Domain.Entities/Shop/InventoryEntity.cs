using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.Entities
{
  public class InventoryEntity
  {
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
    public required int QuantityAvailable { get; set; }
    public required float Unit {  get; set; }
    public required UnitType UnitType { get; set; }
    public required decimal Price { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
