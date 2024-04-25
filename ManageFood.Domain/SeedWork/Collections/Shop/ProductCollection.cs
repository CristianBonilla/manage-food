using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections.Shop
{
  class ProductCollection
  {
    public static IEnumerable<ProductEntity> List =>
    [
      new ProductEntity
      {
        ProductId = new("{0ab34369-9ea3-4153-97ae-099ebef7f746}"),
        CatalogueId = new("{efddc257-66f9-4abc-815e-cd8bb4d39897}"),
        Name = "Apio",
        Description = "Apio crudo",
        Created = new DateTimeOffset(2024, 2, 10, 9, 46, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{b1369640-650a-46f8-ad78-677690e222db}"),
        CatalogueId = new("{efddc257-66f9-4abc-815e-cd8bb4d39897}"),
        Name = "Chayote cocido picado",
        Created = new DateTimeOffset(2024, 2, 11, 2, 26, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{9f15a35d-c294-471b-905f-e72d85538610}"),
        CatalogueId = new("{efddc257-66f9-4abc-815e-cd8bb4d39897}"),
        Name = "Chile jalapeño",
        Created = new DateTimeOffset(2024, 2, 11, 10, 4, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{8b0ce0e2-2850-4673-bc32-8cfd0554409b}"),
        CatalogueId = new("{16d135b1-e117-47ad-a4ac-c15d40f133fd}"),
        Name = "Fresa entera",
        Created = new DateTimeOffset(2024, 2, 14, 55, 31, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{3bfd012b-734b-424b-8c38-31f550037db6}"),
        CatalogueId = new("{16d135b1-e117-47ad-a4ac-c15d40f133fd}"),
        Name = "Guayaba rosa",
        Created = new DateTimeOffset(2024, 2, 15, 47, 11, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{7124211b-ff28-41b6-8404-d111c0a7ddb3}"),
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Galleta salmas",
        Created = new DateTimeOffset(2024, 2, 18, 6, 10, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{9037cc53-fa37-4dd6-8833-40d583fd2371}"),
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Tostada",
        Description = "Tostada de maíz horneada",
        Created = new DateTimeOffset(2024, 2, 18, 40, 33, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{3cbcffd4-60a8-4584-97a0-eacabf555ad8}"),
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Galleta de animalitos",
        Created = new DateTimeOffset(2024, 2, 18, 43, 17, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{920c202d-4ed1-453d-8769-557f4e5d0f90}"),
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Pan de barra",
        Created = new DateTimeOffset(2024, 2, 19, 3, 56, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{96be3795-4827-4def-b766-6302e4ae3fef}"),
        CatalogueId = new("{525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b}"),
        Name = "Galleta maría",
        Created = new DateTimeOffset(2024, 2, 19, 10, 5, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{b3ce1679-ae8e-4f5b-9c22-0b672d7aab48}"),
        CatalogueId = new("{a35a2e5a-63a7-48a6-ab62-1ab5bf012c65}"),
        Name = "Cristal",
        Description = "Agua natural Cristal",
        Created = new DateTimeOffset(2024, 2, 19, 48, 36, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{67073233-c813-4646-ba42-06b7e7997fa9}"),
        CatalogueId = new("{a35a2e5a-63a7-48a6-ab62-1ab5bf012c65}"),
        Name = "Leche entera",
        Description = "Leche entera alqueria",
        Created = new DateTimeOffset(2024, 2, 21, 2, 0, 0, TimeSpan.FromHours(3))
      },
      new ProductEntity
      {
        ProductId = new("{b323b549-dd2f-4fa5-aace-46239ed7f954}"),
        CatalogueId = new("{a35a2e5a-63a7-48a6-ab62-1ab5bf012c65}"),
        Name = "Té de manzanilla",
        Description = "Té de manzanilla sin endulzar",
        Created = new DateTimeOffset(2024, 2, 22, 9, 59, 0, TimeSpan.FromHours(3))
      },
    ];

    public Guid this[int index] => List.ElementAt(index).ProductId;
  }
}
