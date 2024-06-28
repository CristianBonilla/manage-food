using ManageFood.Domain.Entities.FoodShop;

namespace ManageFood.Domain.Entities
{
  public class UserEntity
  {
    public Guid UserId { get; set; }
    public required Guid RoleId { get; set; }
    public required string DocumentNumber { get; set; }
    public required string Mobile { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required bool IsActive { get; set; }
    public required byte[] Salt { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public RoleEntity Role { get; set; } = null!;
    public ICollection<OrderEntity> Orders { get; set; } = [];
  }
}
