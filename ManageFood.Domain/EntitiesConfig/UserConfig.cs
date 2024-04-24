using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageFood.Domain.Entities;

namespace ManageFood.Domain.EntitiesConfig
{
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
