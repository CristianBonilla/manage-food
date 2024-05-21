namespace ManageFood.Domain.Entities.FoodShop
{
  public class OrderEntity
  {
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
  }
}
