using ManageFood.Domain.Entities;
using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.SeedWork.Collections.Shop
{
  class InventoryCollection
  {
    private int index = 0;
    private readonly InventoryEntity[] inventories = new InventoryEntity[products.Length];

    public int Length => inventories.Length;

    public Guid this[int index] => inventories.ElementAt(index).ProductId;

    public InventoryCollection()
    {
      Init([
        new InventoryEntity
        {
          ProductId = products[0].ProductId,
          Quantity = 24,
          QuantityAvailable = 20,
          UnitType = UnitType.Gram,
          Unit = 500.2F,
          Price = 4400.5M,
          Created = products[0].Created,
        },
        new InventoryEntity
        {
          ProductId = products[1].ProductId,
          Quantity = 66,
          QuantityAvailable = 51,
          UnitType = UnitType.Gram,
          Unit = 340.5F,
          Price = 3250.44M,
          Created = products[1].Created,
        },
        new InventoryEntity
        {
          ProductId = products[2].ProductId,
          Quantity = 10,
          QuantityAvailable = 8,
          UnitType = UnitType.Gram,
          Unit = 220F,
          Price = 8990.50M,
          Created = products[2].Created,
        },
        new InventoryEntity
        {
          ProductId = products[3].ProductId,
          Quantity = 120,
          QuantityAvailable = 68,
          UnitType = UnitType.Gram,
          Unit = 1000.8F,
          Price = 9120.50M,
          Created = products[3].Created
        },
        new InventoryEntity
        {
          ProductId = products[4].ProductId,
          Quantity = 310,
          QuantityAvailable = 310,
          UnitType = UnitType.Gram,
          Unit = 500F,
          Price = 2490.10M,
          Created = products[4].Created
        },
        new InventoryEntity
        {
          ProductId = products[5].ProductId,
          Quantity = 8,
          QuantityAvailable = 7,
          UnitType = UnitType.Gram,
          Unit = 720.2F,
          Price = 55500M,
          Created = products[5].Created
        },
        new InventoryEntity
        {
          ProductId = products[6].ProductId,
          Quantity = 13,
          QuantityAvailable = 9,
          UnitType = UnitType.Gram,
          Unit = 250.5F,
          Price = 15167.50M,
          Created = products[6].Created
        },
        new InventoryEntity
        {
          ProductId = products[7].ProductId,
          Quantity = 45,
          QuantityAvailable = 43,
          UnitType = UnitType.Gram,
          Unit = 500F,
          Price = 17430.40M,
          Created = products[7].Created
        },
        new InventoryEntity
        {
          ProductId = products[8].ProductId,
          Quantity = 80,
          QuantityAvailable = 71,
          UnitType = UnitType.Gram,
          Unit = 250.5F,
          Price = 5200.5M,
          Created = products[8].Created
        },
        new InventoryEntity
        {
          ProductId = products[9].ProductId,
          Quantity = 33,
          QuantityAvailable = 11,
          UnitType = UnitType.Gram,
          Unit = 200F,
          Price = 7900M,
          Created = products[9].Created
        },
        new InventoryEntity
        {
          ProductId = products[10].ProductId,
          Quantity = 29,
          QuantityAvailable = 22,
          UnitType = UnitType.Milliliter,
          Unit = 7200F,
          Price = 22000M,
          Created = products[10].Created
        },
        new InventoryEntity
        {
          ProductId = products[11].ProductId,
          Quantity = 19,
          QuantityAvailable = 19,
          UnitType = UnitType.Liter,
          Unit = 1.3F,
          Price = 48250.50M,
          Created = products[11].Created
        },
        new InventoryEntity
        {
          ProductId = products[12].ProductId,
          Quantity = 50,
          QuantityAvailable = 29,
          UnitType = UnitType.Milliliter,
          Unit = 400F,
          Price = 2720.80M,
          Created = products[12].Created
        }
      ]);
    }

    private static readonly ProductCollection products = SeedData.Shop.Products;

    private void Init(params InventoryEntity[] inventories)
    {
      foreach (InventoryEntity inventory in inventories)
        this.inventories[index++] = inventory;
    }
  }
}
