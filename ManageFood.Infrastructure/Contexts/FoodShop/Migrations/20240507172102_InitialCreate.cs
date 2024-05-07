using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageFood.Infrastructure.Contexts.FoodShop.Migrations
{
  /// <inheritdoc />
  public partial class InitialCreate : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.EnsureSchema(
          name: "dbo");

      migrationBuilder.CreateTable(
          name: "Catalogue",
          schema: "dbo",
          columns: table => new
          {
            CatalogueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
            Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Catalogue", x => x.CatalogueId);
          });

      migrationBuilder.CreateTable(
          name: "Inventoy",
          schema: "dbo",
          columns: table => new
          {
            ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Quantity = table.Column<int>(type: "int", nullable: false),
            QuantityAvailable = table.Column<int>(type: "int", nullable: false),
            Unit = table.Column<float>(type: "real(5)", precision: 5, scale: 2, nullable: false),
            UnitType = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
            Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Inventoy", x => x.ProductId);
          });

      migrationBuilder.CreateTable(
          name: "Permission",
          schema: "dbo",
          columns: table => new
          {
            PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
            Order = table.Column<int>(type: "int", nullable: false),
            Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            DisplayName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Permission", x => x.PermissionId);
          });

      migrationBuilder.CreateTable(
          name: "Role",
          schema: "dbo",
          columns: table => new
          {
            RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
            Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            DisplayName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Role", x => x.RoleId);
          });

      migrationBuilder.CreateTable(
          name: "Product",
          schema: "dbo",
          columns: table => new
          {
            ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            CatalogueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Product", x => x.ProductId);
            table.ForeignKey(
                      name: "FK_Product_Catalogue_ProductId",
                      column: x => x.ProductId,
                      principalSchema: "dbo",
                      principalTable: "Catalogue",
                      principalColumn: "CatalogueId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Product_Inventoy_ProductId",
                      column: x => x.ProductId,
                      principalSchema: "dbo",
                      principalTable: "Inventoy",
                      principalColumn: "ProductId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "RolePermission",
          schema: "dbo",
          columns: table => new
          {
            RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
            table.ForeignKey(
                      name: "FK_RolePermission_Permission_PermissionId",
                      column: x => x.PermissionId,
                      principalSchema: "dbo",
                      principalTable: "Permission",
                      principalColumn: "PermissionId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_RolePermission_Role_RoleId",
                      column: x => x.RoleId,
                      principalSchema: "dbo",
                      principalTable: "Role",
                      principalColumn: "RoleId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "User",
          schema: "dbo",
          columns: table => new
          {
            UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
            RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            DocumentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            Username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            Password = table.Column<string>(type: "varchar(max)", nullable: false),
            Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
            Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.UserId);
            table.ForeignKey(
                      name: "FK_User_Role_RoleId",
                      column: x => x.RoleId,
                      principalSchema: "dbo",
                      principalTable: "Role",
                      principalColumn: "RoleId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "Catalogue",
          columns: new[] { "CatalogueId", "Created", "Description", "Name" },
          values: new object[,]
          {
                    { new Guid("16d135b1-e117-47ad-a4ac-c15d40f133fd"), new DateTimeOffset(new DateTime(2024, 2, 14, 10, 11, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Frutas" },
                    { new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 18, 5, 33, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Cereales sin grasa", "Cereales" },
                    { new Guid("a35a2e5a-63a7-48a6-ab62-1ab5bf012c65"), new DateTimeOffset(new DateTime(2024, 2, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Bebidas" },
                    { new Guid("efddc257-66f9-4abc-815e-cd8bb4d39897"), new DateTimeOffset(new DateTime(2024, 2, 10, 9, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Verduras" }
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "Inventoy",
          columns: new[] { "ProductId", "Created", "Price", "Quantity", "QuantityAvailable", "Unit", "UnitType" },
          values: new object[,]
          {
                    { new Guid("0ab34369-9ea3-4153-97ae-099ebef7f746"), new DateTimeOffset(new DateTime(2024, 2, 10, 9, 11, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4400.5m, 24, 20, 500.2f, "G" },
                    { new Guid("3bfd012b-734b-424b-8c38-31f550037db6"), new DateTimeOffset(new DateTime(2024, 2, 15, 20, 11, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2490.10m, 310, 310, 500f, "G" },
                    { new Guid("3cbcffd4-60a8-4584-97a0-eacabf555ad8"), new DateTimeOffset(new DateTime(2024, 2, 18, 23, 17, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 17430.40m, 45, 43, 500f, "G" },
                    { new Guid("67073233-c813-4646-ba42-06b7e7997fa9"), new DateTimeOffset(new DateTime(2024, 2, 21, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 48250.50m, 19, 19, 1.3f, "Lt" },
                    { new Guid("7124211b-ff28-41b6-8404-d111c0a7ddb3"), new DateTimeOffset(new DateTime(2024, 2, 18, 6, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 55500m, 8, 7, 720.2f, "G" },
                    { new Guid("8b0ce0e2-2850-4673-bc32-8cfd0554409b"), new DateTimeOffset(new DateTime(2024, 2, 14, 17, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 9120.50m, 120, 68, 1000.8f, "G" },
                    { new Guid("9037cc53-fa37-4dd6-8833-40d583fd2371"), new DateTimeOffset(new DateTime(2024, 2, 18, 21, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 15167.50m, 13, 9, 250.5f, "G" },
                    { new Guid("920c202d-4ed1-453d-8769-557f4e5d0f90"), new DateTimeOffset(new DateTime(2024, 2, 19, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 5200.5m, 80, 71, 250.5f, "G" },
                    { new Guid("96be3795-4827-4def-b766-6302e4ae3fef"), new DateTimeOffset(new DateTime(2024, 2, 19, 10, 5, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 7900m, 33, 11, 200f, "G" },
                    { new Guid("9f15a35d-c294-471b-905f-e72d85538610"), new DateTimeOffset(new DateTime(2024, 2, 11, 10, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 8990.50m, 10, 8, 220f, "G" },
                    { new Guid("b1369640-650a-46f8-ad78-677690e222db"), new DateTimeOffset(new DateTime(2024, 2, 11, 2, 26, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3250.44m, 66, 51, 340.5f, "G" },
                    { new Guid("b323b549-dd2f-4fa5-aace-46239ed7f954"), new DateTimeOffset(new DateTime(2024, 2, 22, 9, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2720.80m, 50, 29, 400f, "Ml" },
                    { new Guid("b3ce1679-ae8e-4f5b-9c22-0b672d7aab48"), new DateTimeOffset(new DateTime(2024, 2, 19, 20, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 22000m, 29, 22, 7200f, "Ml" }
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "Permission",
          columns: new[] { "PermissionId", "Created", "DisplayName", "Name", "Order" },
          values: new object[,]
          {
                    { new Guid("7cadecb0-c11f-4884-beaf-7b37090282a1"), new DateTimeOffset(new DateTime(2024, 3, 2, 8, 49, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "List Order By User", "AllowListOrderByUser", 3 },
                    { new Guid("a4f4aba0-8a5c-431d-82d5-de44bebd223e"), new DateTimeOffset(new DateTime(2024, 3, 1, 14, 5, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "List Orders", "AllowListOrders", 2 },
                    { new Guid("b4748720-c24d-44bb-9c76-cdddc3a0574d"), new DateTimeOffset(new DateTime(2024, 2, 24, 10, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Manage Food", "AllowManageFood", 1 },
                    { new Guid("e74c1d1b-c402-43d1-9492-0df9a67729c8"), new DateTimeOffset(new DateTime(2024, 3, 2, 20, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Create Order", "AllowCreateOrder", 4 }
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "Role",
          columns: new[] { "RoleId", "Created", "DisplayName", "Name" },
          values: new object[,]
          {
                    { new Guid("838c1363-9abd-4999-95e8-71382312ac74"), new DateTimeOffset(new DateTime(2024, 2, 5, 16, 23, 11, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Common User", "CommonUser" },
                    { new Guid("d146b771-7df4-411f-8ccb-490b2d65d22f"), new DateTimeOffset(new DateTime(2024, 1, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Administrator", "AdminUser" }
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "Product",
          columns: new[] { "ProductId", "CatalogueId", "Created", "Description", "Name" },
          values: new object[,]
          {
                    { new Guid("0ab34369-9ea3-4153-97ae-099ebef7f746"), new Guid("efddc257-66f9-4abc-815e-cd8bb4d39897"), new DateTimeOffset(new DateTime(2024, 2, 10, 9, 11, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Apio crudo", "Apio" },
                    { new Guid("3bfd012b-734b-424b-8c38-31f550037db6"), new Guid("16d135b1-e117-47ad-a4ac-c15d40f133fd"), new DateTimeOffset(new DateTime(2024, 2, 15, 20, 11, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Guayaba rosa" },
                    { new Guid("3cbcffd4-60a8-4584-97a0-eacabf555ad8"), new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 18, 23, 17, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Galleta de animalitos" },
                    { new Guid("67073233-c813-4646-ba42-06b7e7997fa9"), new Guid("a35a2e5a-63a7-48a6-ab62-1ab5bf012c65"), new DateTimeOffset(new DateTime(2024, 2, 21, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Leche entera alqueria", "Leche entera" },
                    { new Guid("7124211b-ff28-41b6-8404-d111c0a7ddb3"), new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 18, 6, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Galleta salmas" },
                    { new Guid("8b0ce0e2-2850-4673-bc32-8cfd0554409b"), new Guid("16d135b1-e117-47ad-a4ac-c15d40f133fd"), new DateTimeOffset(new DateTime(2024, 2, 14, 17, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Fresa entera" },
                    { new Guid("9037cc53-fa37-4dd6-8833-40d583fd2371"), new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 18, 21, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Maíz Tostado" },
                    { new Guid("920c202d-4ed1-453d-8769-557f4e5d0f90"), new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 19, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Pan de barra" },
                    { new Guid("96be3795-4827-4def-b766-6302e4ae3fef"), new Guid("525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b"), new DateTimeOffset(new DateTime(2024, 2, 19, 10, 5, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Galleta maría" },
                    { new Guid("9f15a35d-c294-471b-905f-e72d85538610"), new Guid("efddc257-66f9-4abc-815e-cd8bb4d39897"), new DateTimeOffset(new DateTime(2024, 2, 11, 10, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Chile jalapeño" },
                    { new Guid("b1369640-650a-46f8-ad78-677690e222db"), new Guid("efddc257-66f9-4abc-815e-cd8bb4d39897"), new DateTimeOffset(new DateTime(2024, 2, 11, 2, 26, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Chayote cocido picado" },
                    { new Guid("b323b549-dd2f-4fa5-aace-46239ed7f954"), new Guid("a35a2e5a-63a7-48a6-ab62-1ab5bf012c65"), new DateTimeOffset(new DateTime(2024, 2, 22, 9, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Té Verde FUZE Manzanilla", "Té Verde" },
                    { new Guid("b3ce1679-ae8e-4f5b-9c22-0b672d7aab48"), new Guid("a35a2e5a-63a7-48a6-ab62-1ab5bf012c65"), new DateTimeOffset(new DateTime(2024, 2, 19, 20, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Agua natural Cristal", "Cristal" }
          });

      migrationBuilder.InsertData(
          schema: "dbo",
          table: "RolePermission",
          columns: new[] { "PermissionId", "RoleId", "Created" },
          values: new object[,]
          {
                    { new Guid("7cadecb0-c11f-4884-beaf-7b37090282a1"), new Guid("838c1363-9abd-4999-95e8-71382312ac74"), new DateTimeOffset(new DateTime(2024, 3, 25, 0, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("e74c1d1b-c402-43d1-9492-0df9a67729c8"), new Guid("838c1363-9abd-4999-95e8-71382312ac74"), new DateTimeOffset(new DateTime(2024, 3, 28, 1, 22, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("7cadecb0-c11f-4884-beaf-7b37090282a1"), new Guid("d146b771-7df4-411f-8ccb-490b2d65d22f"), new DateTimeOffset(new DateTime(2024, 3, 24, 11, 43, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("a4f4aba0-8a5c-431d-82d5-de44bebd223e"), new Guid("d146b771-7df4-411f-8ccb-490b2d65d22f"), new DateTimeOffset(new DateTime(2024, 3, 9, 22, 12, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("b4748720-c24d-44bb-9c76-cdddc3a0574d"), new Guid("d146b771-7df4-411f-8ccb-490b2d65d22f"), new DateTimeOffset(new DateTime(2024, 3, 1, 17, 33, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { new Guid("e74c1d1b-c402-43d1-9492-0df9a67729c8"), new Guid("d146b771-7df4-411f-8ccb-490b2d65d22f"), new DateTimeOffset(new DateTime(2024, 3, 25, 4, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
          });

      migrationBuilder.CreateIndex(
          name: "IX_Catalogue_Name",
          schema: "dbo",
          table: "Catalogue",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Permission_Name_DisplayName",
          schema: "dbo",
          table: "Permission",
          columns: new[] { "Name", "DisplayName" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Product_Name",
          schema: "dbo",
          table: "Product",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Role_Name_DisplayName",
          schema: "dbo",
          table: "Role",
          columns: new[] { "Name", "DisplayName" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_RolePermission_PermissionId",
          schema: "dbo",
          table: "RolePermission",
          column: "PermissionId");

      migrationBuilder.CreateIndex(
          name: "IX_User_DocumentNumber_Username_Email",
          schema: "dbo",
          table: "User",
          columns: new[] { "DocumentNumber", "Username", "Email" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_User_RoleId",
          schema: "dbo",
          table: "User",
          column: "RoleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Product",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "RolePermission",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "User",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "Catalogue",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "Inventoy",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "Permission",
          schema: "dbo");

      migrationBuilder.DropTable(
          name: "Role",
          schema: "dbo");
    }
  }
}
