using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    isSuperAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clerk",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clerk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "support",
                columns: table => new
                {
                    SupportId = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DocumentUrl = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support", x => x.SupportId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    fullName = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    id_image = table.Column<string>(type: "text", nullable: true),
                    family_card_image = table.Column<string>(type: "text", nullable: true),
                    bank_account_number = table.Column<string>(type: "text", nullable: true),
                    children_count = table.Column<int>(type: "integer", nullable: true),
                    income_support = table.Column<bool>(type: "boolean", nullable: true),
                    income_supportImg = table.Column<string>(type: "text", nullable: true),
                    disability = table.Column<bool>(type: "boolean", nullable: true),
                    disability_proof = table.Column<string>(type: "text", nullable: true),
                    widow = table.Column<bool>(type: "boolean", nullable: true),
                    elderly = table.Column<bool>(type: "boolean", nullable: true),
                    debt = table.Column<bool>(type: "boolean", nullable: true),
                    debt_proof = table.Column<string>(type: "text", nullable: true),
                    house_rent = table.Column<bool>(type: "boolean", nullable: true),
                    rent_proof = table.Column<string>(type: "text", nullable: true),
                    proxy = table.Column<bool>(type: "boolean", nullable: true),
                    proxy_name = table.Column<string>(type: "text", nullable: true),
                    proxy_account_number = table.Column<string>(type: "text", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    supportId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_support_supportId",
                        column: x => x.supportId,
                        principalTable: "support",
                        principalColumn: "SupportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_support_UserId",
                table: "support",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_supportId",
                table: "user",
                column: "supportId");

            migrationBuilder.AddForeignKey(
                name: "FK_support_user_UserId",
                table: "support",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_support_user_UserId",
                table: "support");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "clerk");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "support");
        }
    }
}
