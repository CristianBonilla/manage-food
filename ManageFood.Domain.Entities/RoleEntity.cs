namespace ManageFood.Domain.Entities
{
  public class RoleEntity
  {
    public Guid RoleId { get; set; }
    public required string Name { get; set; }
    public required string DisplayName { get; set; }
    public ICollection<PermissionEntity> Permissions { get; set; } = [];
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
