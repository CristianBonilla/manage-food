using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;

namespace ManageFood.Infrastructure.Contexts.FoodShop.Config
{
  class CatalogueConfig(ISeedData? seedData) : IEntityTypeConfiguration<CatalogueEntity>
  {
    public void Configure(EntityTypeBuilder<CatalogueEntity> builder)
    {
      builder.ToTable("Catalogue", "dbo")
        .HasKey(key => key.CatalogueId);
      builder.Property(property => property.CatalogueId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.Name)
        .HasMaxLength(30)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Description)
        .HasMaxLength(100)
        .IsUnicode(false);
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasMany(many => many.Products)
        .WithOne(one => one.Catalogue)
        .HasForeignKey(key => key.CatalogueId)
        .OnDelete(DeleteBehavior.Cascade);
      builder.HasIndex(index => new { index.Name })
        .IsUnique();
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Catalogues.GetAll());
    }
  }

  class ProductConfig(ISeedData? seedData) : IEntityTypeConfiguration<ProductEntity>
  {
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
      builder.ToTable("Product", "dbo")
        .HasKey(key => key.ProductId);
      builder.Property(property => property.Name)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Description)
        .HasMaxLength(100)
        .IsUnicode(false);
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasOne(one => one.Catalogue)
        .WithMany(many => many.Products)
        .HasForeignKey(key => key.ProductId);
      builder.HasOne(one => one.Inventory)
        .WithOne(one => one.Product)
        .HasForeignKey<InventoryEntity>(key => key.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
      builder.HasIndex(index => new { index.Name })
        .IsUnique();
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Products.GetAll());
    }
  }

  class InventoryConfig(ISeedData? seedData) : IEntityTypeConfiguration<InventoryEntity>
  {
    public void Configure(EntityTypeBuilder<InventoryEntity> builder)
    {
      builder.ToTable("Inventoy", "dbo")
        .HasKey(key => key.ProductId);
      builder.Property(property => property.Quantity)
        .IsRequired();
      builder.Property(property => property.QuantityAvailable)
        .IsRequired();
      builder.Property(property => property.Unit)
        .HasPrecision(5, 2)
        .IsRequired();
      builder.Property(property => property.UnitType)
        .HasMaxLength(3)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Price)
        .HasPrecision(7, 2)
        .IsRequired();
      builder.HasOne(one => one.Product)
        .WithOne(one => one.Inventory)
        .HasForeignKey<ProductEntity>(key => key.InventoryId)
        .OnDelete(DeleteBehavior.Cascade);
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Inventories.GetAll());
    }
  }
}
