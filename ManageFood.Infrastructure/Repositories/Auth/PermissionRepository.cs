using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories.Auth
{
  public class PermissionRepository(IFoodShopRepositoryContext context) : Repository<FoodShopContext, PermissionEntity>(context), IPermissionRepository { }
}
