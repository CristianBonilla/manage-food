namespace ManageFood.Domain.Entities
{
  public class RoleEntity
  {
    public Guid RoleId { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public ICollection<RolePermissionEntity> RolePermissions { get; set; } = [];
    public ICollection<UserEntity> Users { get; set; } = [];
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
