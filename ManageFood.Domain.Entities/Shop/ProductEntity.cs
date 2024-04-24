namespace ManageFood.Domain.Entities
{
  public class ProductEntity
  {
    public Guid ProductId { get; set; }
    public Guid CatalogueId { get; set; }
    public Guid InventoryId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public CatalogueEntity Catalogue { get; set; } = null!;
    public InventoryEntity Inventory { get; set; } = null!;
  }
}
