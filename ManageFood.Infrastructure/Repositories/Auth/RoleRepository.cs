using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories.Auth
{
  public class RoleRepository(IFoodShopRepositoryContext context) : Repository<FoodShopContext, RoleEntity>(context), IRoleRepository { }
}
