namespace ManageFood.Contracts.DTO.SeedData
{
  public interface ISeedData
  {
    SeedAuthData Auth { get; }
    SeedFoodShopData FoodShop { get; }
  }
}
