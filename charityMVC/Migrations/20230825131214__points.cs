using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace charityMVC.Migrations
{
    /// <inheritdoc />
    public partial class _points : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "points");
        }
    }
}
