using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories.Auth
{
  public class RolePermissionRepository(IFoodShopRepositoryContext context) : Repository<FoodShopContext, RolePermissionEntity>(context), IRolePermissionRepository { }
}
