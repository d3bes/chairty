using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accepteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    fullAddress = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    isApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    points = table.Column<float>(type: "REAL", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    bank_account_number = table.Column<string>(type: "TEXT", nullable: true),
                    proxyName = table.Column<string>(type: "TEXT", nullable: true),
                    proxy_account_number = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accepteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "acceptedsPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    payMentId = table.Column<string>(type: "TEXT", nullable: false),
                    acceptedId = table.Column<string>(type: "TEXT", nullable: false),
                    createdTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acceptedsPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    isSuperAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clerk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clerk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayMents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    acceptedsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    pointsCount = table.Column<float>(type: "REAL", nullable: false),
                    pointValue = table.Column<float>(type: "REAL", nullable: false),
                    createDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    income = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    children_count_1 = table.Column<int>(type: "INTEGER", nullable: false),
                    children_count_2 = table.Column<int>(type: "INTEGER", nullable: false),
                    children_count_3 = table.Column<int>(type: "INTEGER", nullable: false),
                    children_count_4 = table.Column<int>(type: "INTEGER", nullable: false),
                    children_count_4p = table.Column<int>(type: "INTEGER", nullable: false),
                    hasNo_income_support = table.Column<int>(type: "INTEGER", nullable: false),
                    has_disability = table.Column<int>(type: "INTEGER", nullable: false),
                    widow = table.Column<int>(type: "INTEGER", nullable: false),
                    elderly = table.Column<int>(type: "INTEGER", nullable: false),
                    has_debt = table.Column<int>(type: "INTEGER", nullable: false),
                    house_is_rent = table.Column<int>(type: "INTEGER", nullable: false),
                    pointValue = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "smsValidation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    ValidationCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smsValidation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "support",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    fullAddress = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    points = table.Column<float>(type: "REAL", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    paymentId = table.Column<string>(type: "TEXT", nullable: true),
                    bank_account_number = table.Column<string>(type: "TEXT", nullable: true),
                    proxyName = table.Column<string>(type: "TEXT", nullable: true),
                    proxy_account_number = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    birthDate = table.Column<string>(type: "TEXT", nullable: true),
                    points = table.Column<float>(type: "REAL", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: true),
                    fullAddress = table.Column<string>(type: "TEXT", nullable: false),
                    id_image = table.Column<string>(type: "TEXT", nullable: true),
                    family_card_image = table.Column<string>(type: "TEXT", nullable: true),
                    bank_account_number = table.Column<string>(type: "TEXT", nullable: false),
                    children_count = table.Column<int>(type: "INTEGER", nullable: true),
                    income_support = table.Column<bool>(type: "INTEGER", nullable: false),
                    disability = table.Column<bool>(type: "INTEGER", nullable: false),
                    disability_proof = table.Column<string>(type: "TEXT", nullable: true),
                    widow = table.Column<bool>(type: "INTEGER", nullable: false),
                    elderly = table.Column<bool>(type: "INTEGER", nullable: false),
                    debt = table.Column<bool>(type: "INTEGER", nullable: false),
                    debt_proof = table.Column<string>(type: "TEXT", nullable: true),
                    house_rent = table.Column<bool>(type: "INTEGER", nullable: false),
                    rent_proof = table.Column<string>(type: "TEXT", nullable: true),
                    proxy = table.Column<bool>(type: "INTEGER", nullable: false),
                    _proxy_name = table.Column<string>(type: "TEXT", nullable: true),
                    _proxy_account_number = table.Column<string>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    isAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    isPhoneValid = table.Column<bool>(type: "INTEGER", nullable: false)
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
                name: "acceptedsPayments");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "clerk");

            migrationBuilder.DropTable(
                name: "PayMents");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "smsValidation");

            migrationBuilder.DropTable(
                name: "support");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
