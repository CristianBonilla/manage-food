using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.Infrastructure.Repositories.FoodShop.Interfaces
{
  public interface IOrderRepository : IRepository<FoodShopContext, OrderEntity> { }
}
