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
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
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
                    { 1, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(5288), null, "Baby", null },
                    { 2, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(5317), null, "Sports & Books", null },
                    { 3, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(5322), null, "Computers", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "ParentId", "Priority", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(6344), null, "Electronic", 0, 1, null },
                    { 2, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(6348), null, "Moda", 0, 2, null },
                    { 3, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(6349), null, "Computer", 1, 1, null },
                    { 4, new DateTime(2024, 4, 21, 16, 15, 38, 727, DateTimeKind.Local).AddTicks(6351), null, "Dress", 2, 2, null },
                    { 5, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(408), null, "Beauty, Sports & Electronics", 1, 7, null },
                    { 6, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(439), null, "Home & Outdoors", 3, 9, null },
                    { 7, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(446), null, "Health", 3, 10, null },
                    { 8, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(454), null, "Outdoors", 2, 3, null },
                    { 9, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(464), null, "Kids & Tools", 4, 10, null },
                    { 10, new DateTime(2024, 4, 21, 16, 15, 38, 729, DateTimeKind.Local).AddTicks(478), null, "Clothing & Jewelery", 2, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(6982), null, "Quisquam.", "Sint.", null },
                    { 2, 1, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7025), null, "A.", "Quasi.", null },
                    { 3, 4, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7052), null, "Voluptas.", "Debitis.", null },
                    { 4, 1, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7068), null, "Cupiditate.", "Modi.", null },
                    { 5, 1, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7083), null, "Itaque.", "Rerum.", null },
                    { 6, 1, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7099), null, "Eaque.", "Temporibus.", null },
                    { 7, 2, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7118), null, "Ea.", "Vero.", null },
                    { 8, 2, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7134), null, "Sit.", "Blanditiis.", null },
                    { 9, 1, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7149), null, "Praesentium.", "Sint.", null },
                    { 10, 4, new DateTime(2024, 4, 21, 16, 15, 38, 730, DateTimeKind.Local).AddTicks(7165), null, "Vel.", "Aut.", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DeletedDate", "Description", "Discount", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(2924), null, "Doloribus.", 25.94m, 993.35m, "Aliquid.", null },
                    { 2, 1, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(2947), null, "Iste.", 40.65m, 1909.87m, "In.", null },
                    { 3, 2, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(2965), null, "Excepturi.", 39.63m, 647.41m, "Praesentium.", null },
                    { 4, 1, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3011), null, "Iste.", 45.75m, 1199.61m, "Molestiae.", null },
                    { 5, 3, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3031), null, "Quis.", 19.40m, 1038.29m, "Ipsa.", null },
                    { 6, 3, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3050), null, "Eum.", 30.47m, 1336.14m, "Et.", null },
                    { 7, 2, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3067), null, "Maiores.", 30.82m, 800.21m, "Commodi.", null },
                    { 8, 2, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3084), null, "Sit.", 13.66m, 1123.22m, "Voluptatem.", null },
                    { 9, 3, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3103), null, "Pariatur.", 36.20m, 447.31m, "Rerum.", null },
                    { 10, 1, new DateTime(2024, 4, 21, 16, 15, 38, 732, DateTimeKind.Local).AddTicks(3121), null, "Consectetur.", 22.06m, 354.58m, "Quia.", null }
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
