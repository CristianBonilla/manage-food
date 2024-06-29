using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections.Shop
{
  class CatalogueCollection
  {
    public static IEnumerable<CatalogueEntity> List =>
    [
      new CatalogueEntity
      {
        CatalogueId = new("{efddc257-66f9-4abc-815e-cd8bb4d39897}"),
        Name = "Verduras",
        Created = new DateTimeOffset(2024, 2, 10, 9, 45, 0, TimeSpan.FromHours(3))
      },
      new CatalogueEntity
      {
        CatalogueId = new("{16d135b1-e117-47ad-a4ac-c15d40f133fd}"),
        Name = "Frutas",
        Created = new DateTimeOffset(2024, 2, 14, 50, 11, 0, TimeSpan.FromHours(3))
      },
      new CatalogueEntity
      {
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Cereales",
        Description = "Cereales sin grasa",
        Created = new DateTimeOffset(2024, 2, 18, 5, 33, 0, TimeSpan.FromHours(3))
      },
      new CatalogueEntity
      {
        CatalogueId = new("{a35a2e5a-63a7-48a6-ab62-1ab5bf012c65}"),
        Name = "Bebidas",
        Created = new DateTimeOffset(2024, 2, 19, 41, 0, 0, TimeSpan.FromHours(3))
      },
    ];

    public Guid this[int index] => List.ElementAt(index).CatalogueId;
  }
}
