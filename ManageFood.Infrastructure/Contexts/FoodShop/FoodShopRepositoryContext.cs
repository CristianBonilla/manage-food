using ManageFood.Infrastructure.Repository;

namespace ManageFood.Infrastructure.Contexts.FoodShop
{
  public class FoodShopRepositoryContext(FoodShopContext context) : RepositoryContext<FoodShopContext>(context), IFoodShopRepositoryContext { }
}
