using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claudi.Infrastructure.Migrations
{
    public partial class AddedMorePropertiesToConfiguredProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "ConfiguredProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ConfiguredProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SquareMeters",
                table: "ConfiguredProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "ConfiguredProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "ConfiguredProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ConfiguredProducts");

            migrationBuilder.DropColumn(
                name: "SquareMeters",
                table: "ConfiguredProducts");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ConfiguredProducts");
        }
    }
}
