namespace ManageFood.Domain.Entities
{
  public class CatalogueEntity
  {
    public Guid CatalogueId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ICollection<ProductEntity> Products { get; set; } = [];
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
