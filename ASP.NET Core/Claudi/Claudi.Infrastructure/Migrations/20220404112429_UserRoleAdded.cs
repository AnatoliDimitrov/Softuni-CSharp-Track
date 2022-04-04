using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claudi.Infrastructure.Migrations
{
    public partial class UserRoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                column: "ConcurrencyStamp",
                value: "c7b9d1e8-99a9-478f-833a-7919fa3cf0c4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8695a758-35e0-44fa-99d7-909a344009e2", "d4f189f0-2dee-465e-90b0-9d14ff2d0ed8", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30cfadad-34f5-4a15-aa5d-76d2218912d2", "AQAAAAEAACcQAAAAEOpRMraimzpiTQGWdChnM/MVa1rtHBLxzaXF6y1JBksjtygiXRYnisSq1k4Q2UaaqQ==", "6a14e0c2-8b83-45cc-8a4c-afd319dc7eaf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8695a758-35e0-44fa-99d7-909a344009e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                column: "ConcurrencyStamp",
                value: "3d4175ab-4ff6-4860-8aab-3730633fb745");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0998371e-11dd-4b52-a770-ed4da59943e6", "AQAAAAEAACcQAAAAEB3lmrEJJwrzHO6/1ipAEoIe3fjYg9L2KEhmme4jPg7eUT9HC19BGSjBv3djhE29bg==", "f34cc670-d0c4-439a-9f87-a990f6f26372" });
        }
    }
}
