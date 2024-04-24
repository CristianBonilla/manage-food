namespace ManageFood.Domain.Entities
{
  public class RolePermissionEntity
  {
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public RoleEntity? Role {  get; set; }
    public PermissionEntity? Permission { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
