using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class updateproxy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "proxy_name",
                table: "user",
                newName: "_proxy_name");

            migrationBuilder.RenameColumn(
                name: "proxy_account_number",
                table: "user",
                newName: "_proxy_account_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_proxy_name",
                table: "user",
                newName: "proxy_name");

            migrationBuilder.RenameColumn(
                name: "_proxy_account_number",
                table: "user",
                newName: "proxy_account_number");
        }
    }
}
