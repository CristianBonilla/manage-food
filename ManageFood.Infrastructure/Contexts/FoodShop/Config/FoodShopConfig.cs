using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities.FoodShop;
using ManageFood.Domain.Helpers;

namespace ManageFood.Infrastructure.Contexts.FoodShop.Config
{
  class CatalogueConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<CatalogueEntity>
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

  class ProductConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<ProductEntity>
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
        .HasForeignKey(key => key.CatalogueId);
      builder.HasMany(many => many.Orders)
        .WithOne(one => one.Product)
        .HasForeignKey(key => key.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
      builder.HasIndex(index => new { index.Name })
        .IsUnique();
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Products.GetAll());
    }
  }

  class InventoryConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<InventoryEntity>
  {
    public void Configure(EntityTypeBuilder<InventoryEntity> builder)
    {
      builder.ToTable("Inventory", "dbo")
        .HasKey(key => key.ProductId);
      builder.Property(property => property.Quantity)
        .IsRequired();
      builder.Property(property => property.Unit)
        .HasPrecision(9, 2)
        .IsRequired();
      builder.Property(property => property.UnitType)
        .HasConversion(unitType => unitType.Value, unitType => StringEnumeration.FromValue<UnitType>(unitType) ?? UnitType.Gram)
        .HasMaxLength(3)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Price)
        .HasPrecision(10, 2)
        .IsRequired();
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasOne(one => one.Product)
        .WithOne()
        .HasForeignKey<ProductEntity>(key => key.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Inventories.GetAll());
    }
  }

  class OrderConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<OrderEntity>
  {
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
      builder.ToTable("Order", "dbo")
        .HasKey(key => key.OrderId);
      builder.Property(property => property.OrderId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasOne(one => one.User)
        .WithMany(many => many.Orders)
        .HasForeignKey(key => key.UserId);
      builder.HasOne(one => one.Product)
        .WithMany(many => many.Orders)
        .HasForeignKey(key => key.ProductId);
      if (seedData is not null)
        builder.HasData(seedData.FoodShop.Orders.GetAll());
    }
  }
}
