using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "Accepteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<string>(type: "text", nullable: false),
                    clerkId = table.Column<int>(type: "integer", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accepteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    isSuperAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clerk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clerk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    children_count_1 = table.Column<int>(type: "integer", nullable: false),
                    children_count_2 = table.Column<int>(type: "integer", nullable: false),
                    children_count_3 = table.Column<int>(type: "integer", nullable: false),
                    children_count_4 = table.Column<int>(type: "integer", nullable: false),
                    children_count_4p = table.Column<int>(type: "integer", nullable: false),
                    hasNo_income_support = table.Column<int>(type: "integer", nullable: false),
                    has_disability = table.Column<int>(type: "integer", nullable: false),
                    widow = table.Column<int>(type: "integer", nullable: false),
                    elderly = table.Column<int>(type: "integer", nullable: false),
                    has_debt = table.Column<int>(type: "integer", nullable: false),
                    house_is_rent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
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
                    phone = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    fullAddress = table.Column<string>(type: "text", nullable: false),
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
                    _proxy_name = table.Column<string>(type: "text", nullable: true),
                    _proxy_account_number = table.Column<string>(type: "text", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accepteds");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "clerk");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "support");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
