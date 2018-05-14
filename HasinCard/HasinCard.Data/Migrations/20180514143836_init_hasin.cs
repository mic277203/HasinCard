using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HasinCard.Data.Migrations
{
    public partial class init_hasin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    QQ = table.Column<string>(maxLength: 15, nullable: true),
                    TelNo = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    SortNo = table.Column<int>(nullable: false),
                    SysUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_SysUsers_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Instructions = table.Column<decimal>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    ProductDesc = table.Column<decimal>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: true),
                    SalePrice = table.Column<decimal>(nullable: false),
                    SortNo = table.Column<int>(nullable: false),
                    SysUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SysUsers_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    SysUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_SysUsers_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ProductId",
                table: "Cards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SysUserId",
                table: "Cards",
                column: "SysUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_SysUserId",
                table: "Categorys",
                column: "SysUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SysUserId",
                table: "Products",
                column: "SysUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "SysUsers");
        }
    }
}
