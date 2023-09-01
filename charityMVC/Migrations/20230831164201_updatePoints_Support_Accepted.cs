using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class updatePoints_Support_Accepted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_support",
                table: "support");

            migrationBuilder.DropColumn(
                name: "income_supportImg",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "support");

            migrationBuilder.DropColumn(
                name: "DocumentUrl",
                table: "support");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "support");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "support");

            migrationBuilder.DropColumn(
                name: "username",
                table: "support");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "support",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "SupportId",
                table: "support",
                newName: "phone");

            migrationBuilder.AlterColumn<bool>(
                name: "widow",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "proxy",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "income_support",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "house_rent",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "elderly",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "disability",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "debt",
                table: "user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<bool>(
                name: "isAccepted",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "support",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "support",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "support",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullAddress",
                table: "support",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "support",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "points",
                table: "support",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pointValue",
                table: "points",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Accepteds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_support",
                table: "support",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accepteds_userId",
                table: "Accepteds",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_support",
                table: "support");

            migrationBuilder.DropIndex(
                name: "IX_Accepteds_userId",
                table: "Accepteds");

            migrationBuilder.DropColumn(
                name: "isAccepted",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "support");

            migrationBuilder.DropColumn(
                name: "city",
                table: "support");

            migrationBuilder.DropColumn(
                name: "fullAddress",
                table: "support");

            migrationBuilder.DropColumn(
                name: "name",
                table: "support");

            migrationBuilder.DropColumn(
                name: "points",
                table: "support");

            migrationBuilder.DropColumn(
                name: "pointValue",
                table: "points");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Accepteds");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "support",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "support",
                newName: "SupportId");

            migrationBuilder.AlterColumn<bool>(
                name: "widow",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "proxy",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "income_support",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "house_rent",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "elderly",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "disability",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "debt",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "income_supportImg",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "support",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "support",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentUrl",
                table: "support",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "support",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "support",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "support",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_support",
                table: "support",
                column: "SupportId");
        }
    }
}
