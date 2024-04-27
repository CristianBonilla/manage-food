using ManageFood.Domain.Entities;

namespace ManageFood.Domain.SeedWork.Collections.Shop
{
  class ProductCollection
  {
    private int index = 0;
    private static readonly CatalogueCollection catalogues = SeedData.Shop.Catalogues;
    private static readonly InventoryCollection inventories = SeedData.Shop.Inventories;
    private readonly ProductEntity[] products = new ProductEntity[13];

    public int Length => products.Length;

    public ProductCollection()
    {
      Init([
        new ProductEntity
        {
          ProductId = new("{0ab34369-9ea3-4153-97ae-099ebef7f746}"),
          InventoryId = inventories[0],
          CatalogueId = catalogues[0].CatalogueId,
          Name = "Apio",
          Description = "Apio crudo",
          Created = new DateTimeOffset(2024, 2, 10, 9, 46, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{b1369640-650a-46f8-ad78-677690e222db}"),
          InventoryId = inventories[1],
          CatalogueId = catalogues[0].CatalogueId,
          Name = "Chayote cocido picado",
          Created = new DateTimeOffset(2024, 2, 11, 2, 26, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{9f15a35d-c294-471b-905f-e72d85538610}"),
          InventoryId = inventories[2],
          CatalogueId = catalogues[0].CatalogueId,
          Name = "Chile jalapeño",
          Created = new DateTimeOffset(2024, 2, 11, 10, 4, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{8b0ce0e2-2850-4673-bc32-8cfd0554409b}"),
          InventoryId = inventories[3],
          CatalogueId = catalogues[1].CatalogueId,
          Name = "Fresa entera",
          Created = new DateTimeOffset(2024, 2, 14, 55, 31, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{3bfd012b-734b-424b-8c38-31f550037db6}"),
          InventoryId = inventories[4],
          CatalogueId = catalogues[1].CatalogueId,
          Name = "Guayaba rosa",
          Created = new DateTimeOffset(2024, 2, 15, 47, 11, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{7124211b-ff28-41b6-8404-d111c0a7ddb3}"),
          InventoryId = inventories[5],
          CatalogueId = catalogues[2].CatalogueId,
          Name = "Galleta salmas",
          Created = new DateTimeOffset(2024, 2, 18, 6, 10, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{9037cc53-fa37-4dd6-8833-40d583fd2371}"),
          InventoryId = inventories[6],
          CatalogueId = catalogues[2].CatalogueId,
          Name = "Maíz Tostado",
          Created = new DateTimeOffset(2024, 2, 18, 40, 33, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{3cbcffd4-60a8-4584-97a0-eacabf555ad8}"),
          InventoryId = inventories[7],
          CatalogueId = catalogues[2].CatalogueId,
          Name = "Galleta de animalitos",
          Created = new DateTimeOffset(2024, 2, 18, 43, 17, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{920c202d-4ed1-453d-8769-557f4e5d0f90}"),
          InventoryId = inventories[8],
          CatalogueId = catalogues[2].CatalogueId,
          Name = "Pan de barra",
          Created = new DateTimeOffset(2024, 2, 19, 3, 56, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{96be3795-4827-4def-b766-6302e4ae3fef}"),
          InventoryId = inventories[9],
          CatalogueId = catalogues[2].CatalogueId,
          Name = "Galleta maría",
          Created = new DateTimeOffset(2024, 2, 19, 10, 5, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{b3ce1679-ae8e-4f5b-9c22-0b672d7aab48}"),
          InventoryId = inventories[10],
          CatalogueId = catalogues[3].CatalogueId,
          Name = "Cristal",
          Description = "Agua natural Cristal",
          Created = new DateTimeOffset(2024, 2, 19, 48, 36, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{67073233-c813-4646-ba42-06b7e7997fa9}"),
          InventoryId = inventories[11],
          CatalogueId = catalogues[3].CatalogueId,
          Name = "Leche entera",
          Description = "Leche entera alqueria",
          Created = new DateTimeOffset(2024, 2, 21, 2, 0, 0, TimeSpan.FromHours(3))
        },
        new ProductEntity
        {
          ProductId = new("{b323b549-dd2f-4fa5-aace-46239ed7f954}"),
          InventoryId = inventories[12],
          CatalogueId = catalogues[3].CatalogueId,
          Name = "Té Verde",
          Description = "Té Verde FUZE Manzanilla",
          Created = new DateTimeOffset(2024, 2, 22, 9, 59, 0, TimeSpan.FromHours(3))
        }
      ]);
    }

    public ProductEntity this[int index] => products.ElementAt(index);

    public ProductEntity[] GetAll() => products;

    private void Init(params ProductEntity[] products)
    {
      foreach (ProductEntity product in products)
        this.products[index++] = product;
    }
  }
}
