using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class paymentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paymentId",
                table: "support",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentId",
                table: "support");
        }
    }
}
