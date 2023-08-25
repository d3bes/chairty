using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class updatesupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_support_user_UserId",
                table: "support");

            migrationBuilder.DropForeignKey(
                name: "FK_user_support_supportId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_supportId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_support_UserId",
                table: "support");

            migrationBuilder.DropColumn(
                name: "supportId",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "supportId",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_user_supportId",
                table: "user",
                column: "supportId");

            migrationBuilder.CreateIndex(
                name: "IX_support_UserId",
                table: "support",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_support_user_UserId",
                table: "support",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_support_supportId",
                table: "user",
                column: "supportId",
                principalTable: "support",
                principalColumn: "SupportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
