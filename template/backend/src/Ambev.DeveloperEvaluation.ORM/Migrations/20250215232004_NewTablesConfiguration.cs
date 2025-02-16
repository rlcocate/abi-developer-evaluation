using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class NewTablesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SaleDate = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalSaleAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("42f52c7c-c384-4940-90aa-473ad27ccf70"), "São Paulo", "Cervejaria Alpha" },
                    { new Guid("acf14adc-0f5b-41f5-af82-fb1590175751"), "Belo Horizonte", "Cervejaria Gamma" },
                    { new Guid("d4ee3913-6610-4680-aa9b-0ad1d5a5e4ec"), "Rio de Janeiro", "Cervejaria Beta" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("28365b82-b6f5-42b6-9bf6-7fa4ec25cc60"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(5799), "sarah.connor@example.com", "Sarah", "Connor", "(11) 55555-1984", null },
                    { new Guid("564124a7-c362-4581-9515-32462ed6ae89"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(5802), "ellen.ripley@example.com", "Ellen", "Ripley", "(11) 96555-1979", null },
                    { new Guid("772043ab-e6a8-4810-9b9f-55b17c1f6093"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(5795), "marty.mcfly@example.com", "Marty", "McFly", "(11) 55555-1985", null },
                    { new Guid("c2b2006a-fa9c-4f5b-9186-d41edfeac055"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(5855), "jane.doe@example.com", "Jane", "Doe", "(66) 43555-1971", null },
                    { new Guid("d55e14bb-096c-4728-b82e-5a82db940a82"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(5850), "john.doe@example.com", "John", "Doe", "(66) 43555-1970", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("798d1478-f4eb-44f1-9cc0-ef6072d66929"), "Cerveja Lager", 15.00m },
                    { new Guid("9294b1bb-887d-460c-bb67-7a175c11d99f"), "Cerveja Stout", 25.00m },
                    { new Guid("ca7f8f7a-eea7-420f-88b9-003085a542c4"), "Cerveja IPA", 20.00m }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BranchId", "CustomerId", "SaleDate", "SaleNumber", "Status", "TotalSaleAmount" },
                values: new object[,]
                {
                    { new Guid("034c5068-7e9b-43f7-9db8-7304309719a3"), new Guid("d4ee3913-6610-4680-aa9b-0ad1d5a5e4ec"), new Guid("c2b2006a-fa9c-4f5b-9186-d41edfeac055"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(6388), "S0005", "NotCancelled", 300.00m },
                    { new Guid("7f6e73d8-1b61-4459-a1df-a374c0939c42"), new Guid("42f52c7c-c384-4940-90aa-473ad27ccf70"), new Guid("772043ab-e6a8-4810-9b9f-55b17c1f6093"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(6372), "S0001", "NotCancelled", 80.00m },
                    { new Guid("87de74ae-0012-4555-9d20-1555a5d2b276"), new Guid("d4ee3913-6610-4680-aa9b-0ad1d5a5e4ec"), new Guid("28365b82-b6f5-42b6-9bf6-7fa4ec25cc60"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(6378), "S0002", "NotCancelled", 240.00m },
                    { new Guid("a16b758b-2a2b-43cd-b290-34679290d274"), new Guid("42f52c7c-c384-4940-90aa-473ad27ccf70"), new Guid("d55e14bb-096c-4728-b82e-5a82db940a82"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(6385), "S0004", "NotCancelled", 100.00m },
                    { new Guid("c9bfb56e-2220-4a9a-8b02-3165d1a8a54e"), new Guid("acf14adc-0f5b-41f5-af82-fb1590175751"), new Guid("564124a7-c362-4581-9515-32462ed6ae89"), new DateTime(2025, 2, 15, 23, 20, 3, 407, DateTimeKind.Utc).AddTicks(6381), "S0003", "NotCancelled", 200.00m }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "ProductId", "Quantity", "SaleId", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("18469eb8-36b5-473c-9c52-e8dba8992198"), 0.20m, new Guid("9294b1bb-887d-460c-bb67-7a175c11d99f"), 10, new Guid("87de74ae-0012-4555-9d20-1555a5d2b276"), 200.0000m },
                    { new Guid("4c2192ee-1512-4125-8c09-e867c08d8ac9"), 0.00m, new Guid("ca7f8f7a-eea7-420f-88b9-003085a542c4"), 3, new Guid("a16b758b-2a2b-43cd-b290-34679290d274"), 60.00m },
                    { new Guid("970082f1-5fb3-4299-a666-712afb76b97f"), 0.20m, new Guid("798d1478-f4eb-44f1-9cc0-ef6072d66929"), 13, new Guid("c9bfb56e-2220-4a9a-8b02-3165d1a8a54e"), 156.0000m },
                    { new Guid("b32dfe36-862c-45d8-9d1f-5823f4ffa596"), 0.10m, new Guid("ca7f8f7a-eea7-420f-88b9-003085a542c4"), 4, new Guid("7f6e73d8-1b61-4459-a1df-a374c0939c42"), 72.0000m },
                    { new Guid("f93805f8-bc40-47ed-a447-5a5da6f673e6"), 0.20m, new Guid("9294b1bb-887d-460c-bb67-7a175c11d99f"), 15, new Guid("034c5068-7e9b-43f7-9db8-7304309719a3"), 300.0000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BranchId",
                table: "Sales",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");
        }
    }
}
