using ManageFood.Contracts.Repository;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Infrastructure.Contexts.FoodShop;

namespace ManageFood.Infrastructure.Repositories.Interfaces.FoodShop
{
  public interface ICatalogueRepository : IRepository<FoodShopContext, CatalogueEntity> { }
}
