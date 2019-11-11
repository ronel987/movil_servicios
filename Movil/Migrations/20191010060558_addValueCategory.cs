using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movil.Migrations
{
    public partial class addValueCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0971877a-1de5-4d4d-af2d-240a605cf24b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c6f9992-db2d-4ed4-8885-17453089f490");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a9ecafe-0c10-427f-bd6c-60d2f77899fc", "12a1ae75-bce3-4d39-b962-fbe760a6b68a", "Usuario", "Usuario" },
                    { "1cbd7d25-6161-4d3e-abe0-b3068a95f124", "90f9ec99-781f-48cb-88b0-edd0842c3c6e", "Profesor", "Profesor" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("c19d3522-0833-4c7b-8f69-3bbfb6f9e270"), "Matemáticas", true },
                    { new Guid("ea7e5b67-c3e1-4cbc-a5e5-ce78eeb76d30"), "Baile", true },
                    { new Guid("8ef28b0f-18de-4151-8c5b-b2571c5acc38"), "Peluquería", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cbd7d25-6161-4d3e-abe0-b3068a95f124");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a9ecafe-0c10-427f-bd6c-60d2f77899fc");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ef28b0f-18de-4151-8c5b-b2571c5acc38"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c19d3522-0833-4c7b-8f69-3bbfb6f9e270"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea7e5b67-c3e1-4cbc-a5e5-ce78eeb76d30"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c6f9992-db2d-4ed4-8885-17453089f490", "2da33f4e-3f3c-4102-add8-c07603204242", "Usuario", "Usuario" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0971877a-1de5-4d4d-af2d-240a605cf24b", "95f0ca96-7650-4bed-8e0a-f97208724f74", "Profesor", "Profesor" });
        }
    }
}
