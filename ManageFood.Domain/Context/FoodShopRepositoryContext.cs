using ManageFood.Infrastructure.Repository;

namespace ManageFood.Domain.Context
{
  public class FoodShopRepositoryContext(FoodShopContext context) : RepositoryContext<FoodShopContext>(context), IFoodShopRepositoryContext { }
}
