using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageFood.Domain.Entities;
using ManageFood.Domain.SeedWork;

namespace ManageFood.Domain.EntitiesConfig
{
  class RoleConfig : IEntityTypeConfiguration<RoleEntity>
  {
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
      builder.ToTable("Role", "dbo")
        .HasKey(key => key.RoleId);
      builder.Property(property => property.RoleId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.Name)
        .HasMaxLength(30)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.DisplayName)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasIndex(index => new { index.Name, index.DisplayName })
        .IsUnique();
      builder.HasData(SeedData.Roles.GetAll());
    }
  }

  class PermissionConfig : IEntityTypeConfiguration<PermissionEntity>
  {
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
      builder.ToTable("Permission", "dbo")
        .HasKey(key => key.PermissionId);
      builder.Property(property => property.PermissionId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.Order)
        .IsRequired();
      builder.Property(property => property.Name)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.DisplayName)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasIndex(index => new { index.Name, index.DisplayName })
        .IsUnique();
      builder.HasData(SeedData.Permissions.GetAll());
    }
  }

  class RolePermissionConfig : IEntityTypeConfiguration<RolePermissionEntity>
  {
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
      builder.ToTable("RolePermission", "dbo")
        .HasKey(key => new { key.RoleId, key.PermissionId });
      builder.HasOne(one => one.Role)
        .WithMany(many => many.RolePermissions)
        .HasForeignKey(key => key.RoleId);
      builder.HasOne(one => one.Permission)
        .WithMany(many => many.RolePermissions)
        .HasForeignKey(key => key.PermissionId);
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasData(SeedData.RolePermissions.GetAll());
    }
  }
}
