using Microsoft.EntityFrameworkCore.Migrations;

namespace Movil.Migrations
{
    public partial class FullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3e8412f-4948-4968-b2f4-8993c6da590d", "043e29bc-f9a8-4dbc-b349-eb7347c26052", "Usuario", "Usuario" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf0b21a6-3478-4993-8e56-ca03d32cb4b9", "f26614ec-1634-462a-b366-76659e66af7f", "Profesor", "Profesor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e8412f-4948-4968-b2f4-8993c6da590d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0b21a6-3478-4993-8e56-ca03d32cb4b9");
        }
    }
}
