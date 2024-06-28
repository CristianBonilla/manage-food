using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Domain.SeedWork.Collections.Auth;

namespace ManageFood.Domain.SeedWork.Collections.FoodShop
{
  class OrderCollection : SeedDataCollection<OrderEntity>
  {
    static readonly UserCollection _users = AuthCollection.Users;
    static readonly ProductCollection _products = FoodShopCollection.Products;

    protected override OrderEntity[] Collection => [
      new OrderEntity
      {
        OrderId = new("{e384af28-6c38-4bf2-83cc-18ae3b58a23a}"),
        UserId = _users[0].UserId,
        ProductId = _products[3].ProductId,
        Created = new DateTimeOffset(2024, 4, 1, 20, 11, 0, TimeSpan.FromHours(3))
      },
      new OrderEntity
      {
        OrderId = new("{4520742c-0ed4-4b5f-bb2b-887be306fb85}"),
        UserId = _users[0].UserId,
        ProductId = _products[6].ProductId,
        Created = new DateTimeOffset(2024, 4, 3, 17, 8, 0, TimeSpan.FromHours(3))
      },
    ];
  }
}
