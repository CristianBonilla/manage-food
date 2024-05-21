using System.Linq.Expressions;
using ManageFood.Domain.Entities;

namespace ManageFood.Contracts.Services
{
  public interface IAuthService
  {
    Task<RoleEntity> AddRole(RoleEntity role, params Guid[] permissionIDs);
    Task<UserEntity> AddUser(UserEntity user);
    Task<RoleEntity?> FindRole(Expression<Func<RoleEntity, bool>> predicate);
    Task<UserEntity?> FindUser(Expression<Func<UserEntity, bool>> predicate);
    Task<bool> RoleExists(Expression<Func<RoleEntity, bool>> predicate);
    Task<bool> UserExists(Expression<Func<UserEntity, bool>> predicate);
    IAsyncEnumerable<RoleEntity> GetRoles();
    IAsyncEnumerable<PermissionEntity> GetPermissionsByRoleId(Guid roleId);
    IAsyncEnumerable<UserEntity> GetUsers();
  }
}
