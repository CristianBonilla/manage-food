namespace ManageFood.Domain.Entities
{
  public class InventoryEntity
  {
    public Guid InventoryId { get; set; }
    public Guid ProductId { get; set; }
    public int QuantityAvailable {  get; set; }
    public int Quantity { get; set; }
    public ProductEntity? Product { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
