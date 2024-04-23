using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4267), null, "Toys & Industrial", null },
                    { 2, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4280), null, "Sports & Beauty", null },
                    { 3, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4294), null, "Home, Automotive & Computers", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "ParentId", "Priority", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5925), null, "Electronic", 0, 1, null },
                    { 2, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5931), null, "Moda", 0, 2, null },
                    { 3, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5933), null, "Computer", 1, 1, null },
                    { 4, new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5934), null, "Dress", 2, 2, null },
                    { 5, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(125), null, "Shoes, Grocery & Computers", 1, 8, null },
                    { 6, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(134), null, "Garden", 4, 7, null },
                    { 7, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(171), null, "Computers", 1, 9, null },
                    { 8, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(185), null, "Electronics, Books & Shoes", 2, 5, null },
                    { 9, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(193), null, "Garden", 2, 6, null },
                    { 10, new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(199), null, "Sports", 4, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6267), null, "Voluptatem.", "Commodi.", null },
                    { 2, 4, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6292), null, "Iusto.", "Cum.", null },
                    { 3, 3, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6311), null, "Sit.", "Autem.", null },
                    { 4, 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6325), null, "Nobis.", "Dignissimos.", null },
                    { 5, 2, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6340), null, "Aut.", "Quo.", null },
                    { 6, 2, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6358), null, "Magnam.", "Id.", null },
                    { 7, 2, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6400), null, "Nemo.", "Quam.", null },
                    { 8, 3, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6415), null, "Praesentium.", "Incidunt.", null },
                    { 9, 3, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6430), null, "Tempore.", "Itaque.", null },
                    { 10, 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6447), null, "Maiores.", "Minima.", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DeletedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8575), null, "Optio.", 14.93m, 1922.19m, "Officia.", null },
                    { 2, 2, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8641), null, "Sint.", 39.40m, 169.88m, "Perspiciatis.", null },
                    { 3, 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8660), null, "Iure.", 12.57m, 1979.92m, "Reprehenderit.", null },
                    { 4, 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8682), null, "Est.", 15.39m, 1903.35m, "Amet.", null },
                    { 5, 1, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8699), null, "Dolore.", 25.83m, 1108.90m, "Quo.", null },
                    { 6, 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8717), null, "Exercitationem.", 28.56m, 533.04m, "Rerum.", null },
                    { 7, 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8733), null, "Aut.", 22.06m, 1134.56m, "Eius.", null },
                    { 8, 1, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8751), null, "Sint.", 26.19m, 715.87m, "Qui.", null },
                    { 9, 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8768), null, "Alias.", 16.29m, 433.50m, "Aut.", null },
                    { 10, 1, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8785), null, "Dignissimos.", 15.25m, 1826.42m, "Debitis.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
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
                name: "Details");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
