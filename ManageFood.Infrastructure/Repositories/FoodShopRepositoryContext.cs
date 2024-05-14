using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories
{
  public class FoodShopRepositoryContext(FoodShopContext context) : RepositoryContext<FoodShopContext>(context), IFoodShopRepositoryContext { }
}
