using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_proxy_account_number",
                table: "support",
                newName: "proxy_account_number");

            migrationBuilder.AddColumn<string>(
                name: "bank_account_number",
                table: "Accepteds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "proxyName",
                table: "Accepteds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "proxy_account_number",
                table: "Accepteds",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bank_account_number",
                table: "Accepteds");

            migrationBuilder.DropColumn(
                name: "proxyName",
                table: "Accepteds");

            migrationBuilder.DropColumn(
                name: "proxy_account_number",
                table: "Accepteds");

            migrationBuilder.RenameColumn(
                name: "proxy_account_number",
                table: "support",
                newName: "_proxy_account_number");
        }
    }
}
