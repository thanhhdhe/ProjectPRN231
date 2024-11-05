using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class InitialCreateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProductStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductAttrs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Skus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkuNo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    SkuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkuDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SkuType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    SkuStock = table.Column<int>(type: "int", nullable: false),
                    SkuPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skus_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreateTime", "IsDeleted", "ProductAttrs", "ProductDesc", "ProductName", "ProductStatus", "Sort", "UpdateTime" },
                values: new object[] { 1L, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7806), false, "{\"brand\": \"Apple\", \"model\": \"iPhone 12\"}", "Apple iPhone 12 with advanced features", "iPhone 12", (byte)1, 1, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7806) });

            migrationBuilder.InsertData(
                table: "Skus",
                columns: new[] { "Id", "CreateTime", "ProductId", "SkuDescription", "SkuName", "SkuNo", "SkuPrice", "SkuStock", "SkuType", "Sort", "Status", "UpdateTime" },
                values: new object[] { 1, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7905), 1L, "iPhone 12 with 64GB storage, Black color", "iPhone 12 64GB Black", "IP12-64-BLACK", 799.99m, 50, (byte)0, 1, (byte)1, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.InsertData(
                table: "Skus",
                columns: new[] { "Id", "CreateTime", "ProductId", "SkuDescription", "SkuName", "SkuNo", "SkuPrice", "SkuStock", "SkuType", "Sort", "Status", "UpdateTime" },
                values: new object[] { 2, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7908), 1L, "iPhone 12 with 128GB storage, White color", "iPhone 12 128GB White", "IP12-128-WHITE", 849.99m, 30, (byte)1, 2, (byte)1, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7908) });

            migrationBuilder.InsertData(
                table: "Skus",
                columns: new[] { "Id", "CreateTime", "ProductId", "SkuDescription", "SkuName", "SkuNo", "SkuPrice", "SkuStock", "SkuType", "Sort", "Status", "UpdateTime" },
                values: new object[] { 3, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7911), 1L, "iPhone 12 with 256GB storage, Blue color", "iPhone 12 256GB Blue", "IP12-256-BLUE", 949.99m, 20, (byte)2, 3, (byte)1, new DateTime(2024, 11, 4, 12, 7, 53, 810, DateTimeKind.Local).AddTicks(7911) });

            migrationBuilder.CreateIndex(
                name: "IX_Skus_ProductId",
                table: "Skus",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skus");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
