namespace ManageFood.Domain.Entities
{
  public class UserEntity
  {
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public required string DocumentNumber { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public RoleEntity? Role { get; set; }
  }
}
