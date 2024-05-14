using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.Infrastructure.Repositories.Interfaces.FoodShop
{
  public interface IProductRepository : IRepository<FoodShopContext, ProductEntity> { }
}
