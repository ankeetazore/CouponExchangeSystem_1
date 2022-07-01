using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponExchangeSystemApi_1.Migrations
{
    public partial class couponexchangesystem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    EmailId = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<long>(type: "BIGINT", nullable: true),
                    CouponUploadCount = table.Column<int>(type: "int", nullable: true),
                    CouponExchangeCount = table.Column<int>(type: "int", nullable: true),
                    ProfilePath = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CouponCategoryDetails",
                columns: table => new
                {
                    CouponCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CategoryImagePath = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCategoryDetails", x => x.CouponCategoryId);
                    table.ForeignKey(
                        name: "FK_CouponCategoryDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    UserRole = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponDetails",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiryDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    MinSpend = table.Column<int>(type: "int", nullable: true),
                    MaxOff = table.Column<int>(type: "int", nullable: true),
                    BrandName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CouponCode = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ProductList = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CouponCategoryId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponDetails", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_CouponDetails_CouponCategoryDetails_CouponCategoryId",
                        column: x => x.CouponCategoryId,
                        principalTable: "CouponCategoryDetails",
                        principalColumn: "CouponCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponCategoryDetails_UserId",
                table: "CouponCategoryDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponDetails_CouponCategoryId",
                table: "CouponDetails",
                column: "CouponCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponDetails_UserId",
                table: "CouponDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDetails_UserId",
                table: "UserLoginDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponDetails");

            migrationBuilder.DropTable(
                name: "UserLoginDetails");

            migrationBuilder.DropTable(
                name: "CouponCategoryDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
