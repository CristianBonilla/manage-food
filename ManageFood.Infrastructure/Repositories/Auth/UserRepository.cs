using ManageFood.Domain.Entities;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.Auth.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories.Auth
{
  public class UserRepository(IFoodShopRepositoryContext context) : Repository<FoodShopContext, UserEntity>(context), IUserRepository { }
}
