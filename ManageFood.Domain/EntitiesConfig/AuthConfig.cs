using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageFood.Contracts.DTO.SeedData;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.EntitiesConfig
{
  class RoleConfig(ISeedData? seedData) : IEntityTypeConfiguration<RoleEntity>
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
      if (seedData is not null)
        builder.HasData(seedData.Auth.Roles.GetAll());
    }
  }

  class PermissionConfig(ISeedData? seedData) : IEntityTypeConfiguration<PermissionEntity>
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
      if (seedData is not null)
        builder.HasData(seedData.Auth.Permissions.GetAll());
    }
  }

  class RolePermissionConfig(ISeedData? seedData) : IEntityTypeConfiguration<RolePermissionEntity>
  {
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
      builder.ToTable("RolePermission", "dbo")
        .HasKey(key => new { key.RoleId, key.PermissionId });
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasOne(one => one.Role)
        .WithMany(many => many.RolePermissions)
        .HasForeignKey(key => key.RoleId);
      builder.HasOne(one => one.Permission)
        .WithMany(many => many.RolePermissions)
        .HasForeignKey(key => key.PermissionId);
      if (seedData is not null)
        builder.HasData(seedData.Auth.RolePermissions.GetAll());
    }
  }

  class UserConfig : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("User", "dbo")
        .HasKey(key => key.UserId);
      builder.Property(property => property.UserId)
        .HasDefaultValueSql("NEWID()");
      builder.Property(property => property.DocumentNumber)
        .IsRequired();
      builder.Property(property => property.Username)
        .HasMaxLength(100)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Password)
        .HasColumnType("varchar(max)")
        .IsRequired();
      builder.Property(property => property.Email)
        .HasMaxLength(100)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Firstname)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Lastname)
        .HasMaxLength(50)
        .IsUnicode(false)
        .IsRequired();
      builder.Property(property => property.Created)
        .HasDefaultValueSql("GETUTCDATE()");
      builder.Property(property => property.Version)
        .IsRowVersion();
      builder.HasOne(property => property.Role)
        .WithMany(many => many.Users)
        .HasForeignKey(key => key.RoleId)
        .OnDelete(DeleteBehavior.Cascade);
      builder.HasIndex(index => new { index.DocumentNumber, index.Username, index.Email })
        .IsUnique();
    }
  }
}
