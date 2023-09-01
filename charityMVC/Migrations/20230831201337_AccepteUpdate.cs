using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class AccepteUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "Accepteds",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "Accepteds");
        }
    }
}
