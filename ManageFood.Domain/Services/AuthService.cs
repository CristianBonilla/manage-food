using System.Linq.Expressions;
using ManageFood.Contracts.Services;
using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Domain.Services
{
  public class AuthService(
    IFoodShopRepositoryContext context,
    IRoleRepository roleRepository,
    IPermissionRepository permissionRepository,
    IRolePermissionRepository rolePermissionRepository,
    IUserRepository userRepository) : IAuthService
  {
    readonly IFoodShopRepositoryContext _context = context;
    readonly IRoleRepository _roleRepository = roleRepository;
    readonly IPermissionRepository _permissionRepository = permissionRepository;
    readonly IRolePermissionRepository _rolePermissionRepository = rolePermissionRepository;
    readonly IUserRepository _userRepository = userRepository;

    public async Task<RoleEntity> AddRole(RoleEntity role, params Guid[] permissionIDs)
    {
      role = _roleRepository.Create(role);
      var rolePermissions = _permissionRepository.GetByFilter(permission => permissionIDs.Any(permissionId => permissionId == permission.PermissionId))
        .Select(permission => new RolePermissionEntity { Role = role, Permission = permission });
      _ = _rolePermissionRepository.CreateRange(rolePermissions);
      _ = await _context.SaveAsync();

      return role;
    }

    public async Task<UserEntity> AddUser(UserEntity user)
    {
      user = _userRepository.Create(user);
      _ = await _context.SaveAsync();

      return user;
    }

    public Task<RoleEntity?> FindRole(Expression<Func<RoleEntity, bool>> predicate) => Task.FromResult(_roleRepository.Find(predicate, role => role.RolePermissions));

    public Task<UserEntity?> FindUser(Expression<Func<UserEntity, bool>> predicate) => Task.FromResult(_userRepository.Find(predicate, user => user.Role));

    public Task<bool> RoleExists(Expression<Func<RoleEntity, bool>> predicate) => Task.FromResult(_roleRepository.Exists(predicate));

    public Task<bool> UserExists(Expression<Func<UserEntity, bool>> predicate) => Task.FromResult(_userRepository.Exists(predicate));

    public IAsyncEnumerable<PermissionEntity> GetPermissionsByRoleId(Guid roleId)
    {
      var rolePermissions = _rolePermissionRepository.GetByFilter(
        rolePermission => rolePermission.RoleId == roleId,
        rolePermissions => rolePermissions.OrderBy(order => order.Permission.DisplayName).ThenBy(order => order.Permission.Name),
        rolePermission => rolePermission.Permission)
        .Select(rolePermission => rolePermission.Permission)
        .ToAsyncEnumerable();

      return rolePermissions;
    }

    public IAsyncEnumerable<RoleEntity> GetRoles()
    {
      var roles = _roleRepository.GetAll(roles => roles.OrderBy(order => order.DisplayName)
        .ThenBy(order => order.Name), role => role.RolePermissions)
        .ToAsyncEnumerable();

      return roles;
    }

    public IAsyncEnumerable<UserEntity> GetUsers()
    {
      var users = _userRepository.GetAll(users => users.OrderBy(order => order.Role.DisplayName)
        .ThenBy(order => order.Firstname)
        .ThenBy(order => order.Username), user => user.Role)
        .ToAsyncEnumerable();

      return users;
    }
  }
}
