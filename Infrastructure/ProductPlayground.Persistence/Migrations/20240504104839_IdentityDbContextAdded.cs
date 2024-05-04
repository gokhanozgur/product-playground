using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductPlayground.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDbContextAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(2711), "Electronics & Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(2726), "Grocery, Books & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(2739), "Electronics, Automotive & Shoes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 4, 13, 48, 39, 348, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name", "ParentId" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7160), "Health", 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7215), "Baby, Movies & Grocery", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7232), "Clothing, Shoes & Tools", 3, 10 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7245), "Books & Music", 3, 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7260), "Computers, Home & Baby", 1, 7 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 349, DateTimeKind.Local).AddTicks(7276), "Computers, Toys & Baby", 3, 7 });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2025), "Eos.", "Quos." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2044), "Et.", "Assumenda." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2087), "Sint.", "Ipsa." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2104), "Autem.", "Occaecati." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2119), "Ea.", "Laudantium." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2134), "Cupiditate.", "Consectetur." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2151), "Ut.", "Aut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2166), "Molestiae.", "Nihil." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2181), "Magnam.", "Dolore." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2024, 5, 4, 13, 48, 39, 351, DateTimeKind.Local).AddTicks(2195), "Amet.", "Doloremque." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1254), "Ut.", 19.73m, 1286.50m, "Reiciendis." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1274), "Porro.", 43.91m, 1125.17m, "Et." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1290), "Eaque.", 39.07m, 1292.76m, "Autem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1321), "Consequuntur.", 37.10m, 1007.30m, "Rerum." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1340), "Quam.", 29.40m, 835.88m, "Voluptatem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1358), "Suscipit.", 20.95m, 1196.09m, "Quas." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1374), "Vel.", 27.26m, 816.62m, "Placeat." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1391), "Et.", 37.04m, 1371.76m, "Exercitationem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1408), "Ut.", 46.23m, 727.59m, "Quo." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 5, 4, 13, 48, 39, 353, DateTimeKind.Local).AddTicks(1425), "Porro.", 13.95m, 615.77m, "Occaecati." });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4267), "Toys & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4280), "Sports & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(4294), "Home, Automotive & Computers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 10, 58, 8, 915, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name", "ParentId" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(125), "Shoes, Grocery & Computers", 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(134), "Garden", 4, 7 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(171), "Computers", 1, 9 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(185), "Electronics, Books & Shoes", 2, 5 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(193), "Garden", 2, 6 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name", "ParentId", "Priority" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 917, DateTimeKind.Local).AddTicks(199), "Sports", 4, 10 });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6267), "Voluptatem.", "Commodi." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6292), "Iusto.", "Cum." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6311), "Sit.", "Autem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6325), "Nobis.", "Dignissimos." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6340), "Aut.", "Quo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6358), "Magnam.", "Id." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6400), "Nemo.", "Quam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6415), "Praesentium.", "Incidunt." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6430), "Tempore.", "Itaque." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 4, 23, 10, 58, 8, 918, DateTimeKind.Local).AddTicks(6447), "Maiores.", "Minima." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8575), "Optio.", 14.93m, 1922.19m, "Officia." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8641), "Sint.", 39.40m, 169.88m, "Perspiciatis." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8660), "Iure.", 12.57m, 1979.92m, "Reprehenderit." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8682), "Est.", 15.39m, 1903.35m, "Amet." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8699), "Dolore.", 25.83m, 1108.90m, "Quo." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8717), "Exercitationem.", 28.56m, 533.04m, "Rerum." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8733), "Aut.", 22.06m, 1134.56m, "Eius." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8751), "Sint.", 26.19m, 715.87m, "Qui." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8768), "Alias.", 16.29m, 433.50m, "Aut." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 4, 23, 10, 58, 8, 920, DateTimeKind.Local).AddTicks(8785), "Dignissimos.", 15.25m, 1826.42m, "Debitis." });
        }
    }
}
