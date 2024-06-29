namespace ManageFood.Domain.Entities
{
  public class PermissionEntity
  {
    public Guid PermissionId { get; set; }
    public int Order {  get; set; }
    public required string Name {  get; set; }
    public required string DisplayName { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
  }
}
