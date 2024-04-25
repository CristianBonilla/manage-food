using ManageFood.Contracts.Structs;
using ManageFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageFood.Domain.SeedWork.Collections.Shop
{
  class InventoryCollection
  {
    public static IEnumerable<InventoryEntity> List =>
    [
      new InventoryEntity
      {
        ProductId = new("{0ab34369-9ea3-4153-97ae-099ebef7f746}"),
        Quantity = 12500.2F,
        QuantityAvailable = 7900.5F,
        Unit = 500.2F,
        Price = 4400.5M
      }
    ];
  }
}
