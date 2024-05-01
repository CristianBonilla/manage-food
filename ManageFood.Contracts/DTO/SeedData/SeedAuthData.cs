using ManageFood.Domain.Entities;

namespace ManageFood.Contracts.DTO.SeedData
{
  public class SeedAuthData
  {
    public required ISeedDataCollection<Guid, RoleEntity> Roles { get; set; }
    public required ISeedDataCollection<Guid, PermissionEntity> Permissions { get; set; }
    public required ISeedDataCollection<(Guid RoleId, Guid PermissionId), RolePermissionEntity> RolePermissions { get; set; }
  }
}
