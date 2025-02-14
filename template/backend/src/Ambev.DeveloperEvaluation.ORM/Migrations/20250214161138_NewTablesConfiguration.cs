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
                    BranchName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
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
                    ProductName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
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
                columns: new[] { "Id", "BranchName", "Location" },
                values: new object[,]
                {
                    { new Guid("633847d6-b6ba-47b5-a356-6cb1148a31f2"), "Cervejaria Beta", "Rio de Janeiro" },
                    { new Guid("bf09bfe9-9c9a-4b63-b5bb-e730c3cb554d"), "Cervejaria Gamma", "Belo Horizonte" },
                    { new Guid("efa78f83-59bf-4802-bbb2-7851b42cd8bc"), "Cervejaria Alpha", "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0fe5c3bf-1505-4985-ab26-2940226a034b"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(8544), "sarah.connor@example.com", "Sarah", "Connor", "(11) 55555-1984", null },
                    { new Guid("2687ed9b-55ab-4d2f-93be-dd395efa71b5"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(8546), "ellen.ripley@example.com", "Ellen", "Ripley", "(11) 96555-1979", null },
                    { new Guid("3bbf47b0-10a6-4dcd-857a-f52750260296"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(8549), "john.doe@example.com", "John", "Doe", "(66) 43555-1970", null },
                    { new Guid("5a236e83-530e-473b-b9f0-59c0a4ff95d6"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(8495), "marty.mcfly@example.com", "Marty", "McFly", "(11) 55555-1985", null },
                    { new Guid("fa0199d1-a031-4e83-819b-ff935c1ea924"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(8552), "jane.doe@example.com", "Jane", "Doe", "(66) 43555-1971", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("2e0dd60a-a35e-415b-b206-6c7e5f3f4a1c"), "Cerveja Lager", 15.00m },
                    { new Guid("65f47bfa-848b-4be6-ba19-a26fba4383be"), "Cerveja IPA", 20.00m },
                    { new Guid("eb693d8d-753c-46ee-9ebb-1c439b3f6401"), "Cerveja Stout", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BranchId", "CustomerId", "SaleDate", "SaleNumber", "Status", "TotalSaleAmount" },
                values: new object[,]
                {
                    { new Guid("4330fabe-a073-47ba-b0d5-3ef3d493f27f"), new Guid("bf09bfe9-9c9a-4b63-b5bb-e730c3cb554d"), new Guid("2687ed9b-55ab-4d2f-93be-dd395efa71b5"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(9021), "S0003", "NotCancelled", 200.00m },
                    { new Guid("43746cdf-eb34-441c-a0eb-a9383287fc38"), new Guid("633847d6-b6ba-47b5-a356-6cb1148a31f2"), new Guid("fa0199d1-a031-4e83-819b-ff935c1ea924"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(9028), "S0005", "NotCancelled", 300.00m },
                    { new Guid("4c0befa3-c729-443b-a5f7-c418fb288646"), new Guid("efa78f83-59bf-4802-bbb2-7851b42cd8bc"), new Guid("3bbf47b0-10a6-4dcd-857a-f52750260296"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(9024), "S0004", "NotCancelled", 100.00m },
                    { new Guid("6611af78-5c48-4f06-8ae8-9ed161b1f6f6"), new Guid("633847d6-b6ba-47b5-a356-6cb1148a31f2"), new Guid("0fe5c3bf-1505-4985-ab26-2940226a034b"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(9018), "S0002", "NotCancelled", 240.00m },
                    { new Guid("9a0c10a6-ef7e-46c7-a672-b0e0b0927ee8"), new Guid("efa78f83-59bf-4802-bbb2-7851b42cd8bc"), new Guid("5a236e83-530e-473b-b9f0-59c0a4ff95d6"), new DateTime(2025, 2, 14, 16, 11, 38, 34, DateTimeKind.Utc).AddTicks(9009), "S0001", "NotCancelled", 80.00m }
                });

            migrationBuilder.InsertData(
                table: "SaleItems",
                columns: new[] { "Id", "Discount", "ProductId", "Quantity", "SaleId", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("12649b5b-add1-4b1c-9b1c-3db6a82b0dce"), 0.20m, new Guid("eb693d8d-753c-46ee-9ebb-1c439b3f6401"), 10, new Guid("6611af78-5c48-4f06-8ae8-9ed161b1f6f6"), 200.0000m },
                    { new Guid("2eb756d4-190a-47ea-bcd9-156727788929"), 0.20m, new Guid("eb693d8d-753c-46ee-9ebb-1c439b3f6401"), 15, new Guid("43746cdf-eb34-441c-a0eb-a9383287fc38"), 300.0000m },
                    { new Guid("5fbff848-ea92-4699-81ee-780aa1c6d242"), 0.10m, new Guid("65f47bfa-848b-4be6-ba19-a26fba4383be"), 4, new Guid("9a0c10a6-ef7e-46c7-a672-b0e0b0927ee8"), 72.0000m },
                    { new Guid("83169228-14f7-41d4-be25-ae1f9988cf8d"), 0.00m, new Guid("65f47bfa-848b-4be6-ba19-a26fba4383be"), 3, new Guid("4c0befa3-c729-443b-a5f7-c418fb288646"), 60.00m },
                    { new Guid("ffeafcc2-f2a7-4b90-92f8-ff2ac65b8fa9"), 0.20m, new Guid("2e0dd60a-a35e-415b-b206-6c7e5f3f4a1c"), 13, new Guid("4330fabe-a073-47ba-b0d5-3ef3d493f27f"), 156.0000m }
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
