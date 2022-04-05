#nullable disable

namespace Claudi.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedMeToUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8695a758-35e0-44fa-99d7-909a344009e2", "90b21bc9-9062-4142-b3f9-774e6797e080" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b5792b-739b-4ddc-b61d-1c5585fdd9c8", "AQAAAAEAACcQAAAAEBoLiWsu+aMFVb4/MI4kvvEAiJvp0fJhiVd2vxNywBFUjG0gUmo5wytOJpAfoorh7Q==", "9f7a0ee3-e4f5-4f5a-addd-fdddd35c8c3e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8695a758-35e0-44fa-99d7-909a344009e2", "90b21bc9-9062-4142-b3f9-774e6797e080" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e18fb-65b5-4bf9-9926-628afdb1c465",
                column: "ConcurrencyStamp",
                value: "c7b9d1e8-99a9-478f-833a-7919fa3cf0c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8695a758-35e0-44fa-99d7-909a344009e2",
                column: "ConcurrencyStamp",
                value: "d4f189f0-2dee-465e-90b0-9d14ff2d0ed8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b21bc9-9062-4142-b3f9-774e6797e080",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30cfadad-34f5-4a15-aa5d-76d2218912d2", "AQAAAAEAACcQAAAAEOpRMraimzpiTQGWdChnM/MVa1rtHBLxzaXF6y1JBksjtygiXRYnisSq1k4Q2UaaqQ==", "6a14e0c2-8b83-45cc-8a4c-afd319dc7eaf" });
        }
    }
}
