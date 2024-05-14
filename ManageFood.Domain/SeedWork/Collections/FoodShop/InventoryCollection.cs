using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Domain.Helpers;

namespace ManageFood.Domain.SeedWork.Collections.FoodShop
{
  class InventoryCollection : ISeedDataCollection<Guid, InventoryEntity>
  {
    int _index;
    static readonly ProductCollection _products = FoodShopCollection.Products;
    readonly InventoryEntity[] _inventories = new InventoryEntity[_products.Length];

    public int Length => _inventories.Length;

    public InventoryCollection()
    {
      Init([
        new InventoryEntity
        {
          ProductId = _products[0].ProductId,
          Quantity = 24,
          QuantityAvailable = 20,
          UnitType = UnitType.Gram,
          Unit = 500.2M,
          Price = 4400.5M,
          Created = _products[0].Created,
        },
        new InventoryEntity
        {
          ProductId = _products[1].ProductId,
          Quantity = 66,
          QuantityAvailable = 51,
          UnitType = UnitType.Gram,
          Unit = 340.5M,
          Price = 3250.44M,
          Created = _products[1].Created,
        },
        new InventoryEntity
        {
          ProductId = _products[2].ProductId,
          Quantity = 10,
          QuantityAvailable = 8,
          UnitType = UnitType.Gram,
          Unit = 220M,
          Price = 8990.50M,
          Created = _products[2].Created,
        },
        new InventoryEntity
        {
          ProductId = _products[3].ProductId,
          Quantity = 120,
          QuantityAvailable = 68,
          UnitType = UnitType.Gram,
          Unit = 1000.8M,
          Price = 9120.50M,
          Created = _products[3].Created
        },
        new InventoryEntity
        {
          ProductId = _products[4].ProductId,
          Quantity = 310,
          QuantityAvailable = 310,
          UnitType = UnitType.Gram,
          Unit = 500M,
          Price = 2490.10M,
          Created = _products[4].Created
        },
        new InventoryEntity
        {
          ProductId = _products[5].ProductId,
          Quantity = 8,
          QuantityAvailable = 7,
          UnitType = UnitType.Gram,
          Unit = 720.2M,
          Price = 55500M,
          Created = _products[5].Created
        },
        new InventoryEntity
        {
          ProductId = _products[6].ProductId,
          Quantity = 13,
          QuantityAvailable = 9,
          UnitType = UnitType.Gram,
          Unit = 250.5M,
          Price = 15167.50M,
          Created = _products[6].Created
        },
        new InventoryEntity
        {
          ProductId = _products[7].ProductId,
          Quantity = 45,
          QuantityAvailable = 43,
          UnitType = UnitType.Gram,
          Unit = 500M,
          Price = 17430.40M,
          Created = _products[7].Created
        },
        new InventoryEntity
        {
          ProductId = _products[8].ProductId,
          Quantity = 80,
          QuantityAvailable = 71,
          UnitType = UnitType.Gram,
          Unit = 250.5M,
          Price = 5200.5M,
          Created = _products[8].Created
        },
        new InventoryEntity
        {
          ProductId = _products[9].ProductId,
          Quantity = 33,
          QuantityAvailable = 11,
          UnitType = UnitType.Gram,
          Unit = 200M,
          Price = 7900M,
          Created = _products[9].Created
        },
        new InventoryEntity
        {
          ProductId = _products[10].ProductId,
          Quantity = 29,
          QuantityAvailable = 22,
          UnitType = UnitType.Milliliter,
          Unit = 7200M,
          Price = 22000M,
          Created = _products[10].Created
        },
        new InventoryEntity
        {
          ProductId = _products[11].ProductId,
          Quantity = 19,
          QuantityAvailable = 19,
          UnitType = UnitType.Liter,
          Unit = 1.3M,
          Price = 48250.50M,
          Created = _products[11].Created
        },
        new InventoryEntity
        {
          ProductId = _products[12].ProductId,
          Quantity = 50,
          QuantityAvailable = 29,
          UnitType = UnitType.Milliliter,
          Unit = 400M,
          Price = 2720.80M,
          Created = _products[12].Created
        }
      ]);
    }

    public Guid this[int index] => _inventories.ElementAt(index).ProductId;

    public IEnumerable<InventoryEntity> GetAll() => [.. _inventories];

    private void Init(params InventoryEntity[] inventories)
    {
      foreach (InventoryEntity inventory in inventories)
        _inventories[_index++] = inventory;
    }
  }
}
