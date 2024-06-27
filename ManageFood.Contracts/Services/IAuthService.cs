using System.Linq.Expressions;
using ManageFood.Domain.Entities;

namespace ManageFood.Contracts.Services
{
  public interface IAuthService
  {
    Task<RoleEntity> AddRole(RoleEntity role, params Guid[] permissionIDs);
    Task<UserEntity> AddUser(UserEntity user);
    Task<RoleEntity?> FindRoleById(Guid roleId);
    Task<RoleEntity?> FindRoleByName(string roleName);
    Task<UserEntity?> FindUserById(Guid userId);
    Task<UserEntity?> FindUserByUsername(string username);
    Task<UserEntity?> FindUserByEmail(string email);
    IAsyncEnumerable<RoleEntity> GetRoles();
    IAsyncEnumerable<PermissionEntity> GetPermissionsByRoleId(Guid roleId);
    IAsyncEnumerable<UserEntity> GetUsers();
  }
}
