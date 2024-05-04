namespace ManageFood.Domain.Entities.FoodShop
{
  public class CatalogueEntity
  {
    public Guid CatalogueId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = [];
  }
}
