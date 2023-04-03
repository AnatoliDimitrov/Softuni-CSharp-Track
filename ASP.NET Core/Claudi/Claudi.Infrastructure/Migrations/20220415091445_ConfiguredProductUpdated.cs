using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claudi.Infrastructure.Migrations
{
    public partial class ConfiguredProductUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguredProducts_ProductColors_ColorId",
                table: "ConfiguredProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguredProducts_ProductModels_ModelId",
                table: "ConfiguredProducts");

            migrationBuilder.DropIndex(
                name: "IX_ConfiguredProducts_ColorId",
                table: "ConfiguredProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "ConfiguredProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                column: "ConcurrencyStamp",
                value: "5e899ef6-4543-438b-b3c8-79541fae48fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8695a758-35e0-44fa-99d7-909a344009e2",
                column: "ConcurrencyStamp",
                value: "f3aef16a-8f30-4ea1-ab07-1040a80c7fd4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efa3dc6b-1840-4873-82e7-9be83a8ee151", "AQAAAAEAACcQAAAAECjjIBDYzWtzJhEZ9t8QghmWWRYxU5DKttQAIRvJN2qibP/J55ucNa3EWGjRff2Krw==", "1b5e2de6-0eb6-4a9d-beca-ac676a7633d6" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguredProducts_ProductModels_ModelId",
                table: "ConfiguredProducts",
                column: "ModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguredProducts_ProductModels_ModelId",
                table: "ConfiguredProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "ConfiguredProducts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                column: "ConcurrencyStamp",
                value: "44308d1c-6c38-4e05-9427-4234ff2128e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8695a758-35e0-44fa-99d7-909a344009e2",
                column: "ConcurrencyStamp",
                value: "6e67645e-7040-488e-be10-79b06ebb1095");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b5792b-739b-4ddc-b61d-1c5585fdd9c8", "AQAAAAEAACcQAAAAEBoLiWsu+aMFVb4/MI4kvvEAiJvp0fJhiVd2vxNywBFUjG0gUmo5wytOJpAfoorh7Q==", "9f7a0ee3-e4f5-4f5a-addd-fdddd35c8c3e" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguredProducts_ColorId",
                table: "ConfiguredProducts",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguredProducts_ProductColors_ColorId",
                table: "ConfiguredProducts",
                column: "ColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguredProducts_ProductModels_ModelId",
                table: "ConfiguredProducts",
                column: "ModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
