using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductPlayground.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(4134), null, "Industrial", null },
                    { 2, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(4172), null, "Health & Grocery", null },
                    { 3, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(4188), null, "Grocery, Clothing & Outdoors", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "ParentId", "Priority", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(6502), null, "Electronic", 0, 1, null },
                    { 2, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(6506), null, "Moda", 0, 2, null },
                    { 3, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(6508), null, "Computer", 1, 1, null },
                    { 4, new DateTime(2024, 4, 13, 11, 56, 48, 919, DateTimeKind.Local).AddTicks(6510), null, "Dress", 2, 2, null },
                    { 5, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2013), null, "Kids, Grocery & Jewelery", 3, 2, null },
                    { 6, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2035), null, "Computers", 1, 7, null },
                    { 7, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2041), null, "Books", 2, 8, null },
                    { 8, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2050), null, "Clothing", 2, 4, null },
                    { 9, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2062), null, "Grocery & Toys", 3, 8, null },
                    { 10, new DateTime(2024, 4, 13, 11, 56, 48, 921, DateTimeKind.Local).AddTicks(2080), null, "Electronics, Baby & Garden", 1, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7396), null, "Quae.", "Veritatis.", null },
                    { 2, 4, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7416), null, "Officia.", "Mollitia.", null },
                    { 3, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7439), null, "Omnis.", "Consequuntur.", null },
                    { 4, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7457), null, "Distinctio.", "Nobis.", null },
                    { 5, 4, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7472), null, "Aut.", "Hic.", null },
                    { 6, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7489), null, "Neque.", "Minus.", null },
                    { 7, 1, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7511), null, "Laudantium.", "Officiis.", null },
                    { 8, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7525), null, "Possimus.", "Expedita.", null },
                    { 9, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7570), null, "Voluptate.", "Ratione.", null },
                    { 10, 2, new DateTime(2024, 4, 13, 11, 56, 48, 922, DateTimeKind.Local).AddTicks(7588), null, "Sapiente.", "Sed.", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DeletedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2635), null, "Laboriosam.", 11.83m, 334.56m, "Ut.", null },
                    { 2, 2, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2657), null, "Voluptas.", 30.86m, 1169.18m, "Molestiae.", null },
                    { 3, 2, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2675), null, "Nihil.", 28.97m, 1349.63m, "Tenetur.", null },
                    { 4, 3, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2694), null, "Laborum.", 18.04m, 818.90m, "Sed.", null },
                    { 5, 3, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2714), null, "Esse.", 26.00m, 734.82m, "Culpa.", null },
                    { 6, 1, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2734), null, "Cumque.", 10.98m, 1787.88m, "Ea.", null },
                    { 7, 3, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2780), null, "Perspiciatis.", 40.00m, 702.34m, "Autem.", null },
                    { 8, 2, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2801), null, "Quia.", 46.58m, 1253.13m, "Occaecati.", null },
                    { 9, 2, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2820), null, "Quibusdam.", 32.54m, 664.10m, "Sed.", null },
                    { 10, 3, new DateTime(2024, 4, 13, 11, 56, 48, 924, DateTimeKind.Local).AddTicks(2838), null, "Dolor.", 13.09m, 1184.25m, "Aperiam.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
