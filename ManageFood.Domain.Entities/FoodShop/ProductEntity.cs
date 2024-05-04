namespace ManageFood.Domain.Entities.FoodShop
{
  public class ProductEntity
  {
    public Guid ProductId { get; set; }
    public required Guid CatalogueId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public CatalogueEntity Catalogue { get; set; } = null!;
  }
}
