namespace ManageFood.Domain.Entities
{
  public partial class InventoryEntity
  {
    public required Guid ProductId { get; set; }
    public required float Quantity { get; set; }
    public required float QuantityAvailable { get; set; }
    public required float Unit {  get; set; }
    public required decimal Price { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
