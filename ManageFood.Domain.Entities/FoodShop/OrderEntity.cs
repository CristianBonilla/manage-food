namespace ManageFood.Domain.Entities.FoodShop
{
  public class OrderEntity
  {
    public Guid OrderId { get; set; }
    public required Guid UserId { get; set; }
    public required Guid ProductId { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
  }
}
