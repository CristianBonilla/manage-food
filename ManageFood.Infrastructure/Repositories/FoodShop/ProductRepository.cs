using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Infrastructure.Contexts.FoodShop;
using ManageFood.Infrastructure.Repositories.FoodShop.Interfaces;
using ManageFood.Infrastructure.Repositories.Interfaces;

namespace ManageFood.Infrastructure.Repositories.FoodShop
{
  public class ProductRepository(IFoodShopRepositoryContext context) : Repository<FoodShopContext, ProductEntity>(context), IProductRepository { }
}
