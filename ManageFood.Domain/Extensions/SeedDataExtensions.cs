using Microsoft.EntityFrameworkCore;
using ManageFood.Contracts.DTO.SeedData;

namespace ManageFood.Domain.Extensions
{
  public static class SeedDataExtensions
  {
    static ISeedData? _seedData;

    public static ISeedData? GetSeedData(this DbContextOptions _) => _seedData;

    public static void SetSeedData(this DbContextOptions _, ISeedData seedData) => _seedData = seedData;
  }
}
