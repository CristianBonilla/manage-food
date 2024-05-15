using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.Infrastructure.Repositories.Auth.Interfaces
{
  public interface IRolePermissionRepository : IRepository<FoodShopContext, RolePermissionEntity> { }
}
