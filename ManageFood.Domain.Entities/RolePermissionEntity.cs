namespace ManageFood.Domain.Entities
{
  public class RolePermissionEntity
  {
    public required Guid RoleId { get; set; }
    public required Guid PermissionId { get; set; }
    public RoleEntity Role { get; set; } = null!;
    public PermissionEntity Permission { get; set; } = null!;
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
