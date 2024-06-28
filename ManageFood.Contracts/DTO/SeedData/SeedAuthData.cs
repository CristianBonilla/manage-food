using ManageFood.Domain.Entities;

namespace ManageFood.Contracts.DTO.SeedData
{
  public class SeedAuthData
  {
    public required SeedDataCollection<RoleEntity> Roles { get; set; }
    public required SeedDataCollection<PermissionEntity> Permissions { get; set; }
    public required SeedDataCollection<RolePermissionEntity> RolePermissions { get; set; }
    public required SeedDataCollection<UserEntity> Users { get; set; }
  }
}
