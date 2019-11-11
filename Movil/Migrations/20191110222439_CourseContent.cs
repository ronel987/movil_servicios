using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movil.Migrations
{
    public partial class CourseContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CourseContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseContent_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4551b63e-db95-48cf-8f36-582635b76f96", "0f5fb135-e417-4c6a-98f1-b43cd0c546bd", "Usuario", "Usuario" },
                    { "26c59de1-fe00-4e96-94f3-afd23b9ccd25", "acd4a51d-72b2-4357-9220-c46bcd8dc163", "Profesor", "Profesor" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("4d0176c0-b51e-4bb7-8c2a-a63bd6715ec7"), "Matemáticas", true },
                    { new Guid("3b7fec5a-c1c0-4888-ae1b-3d250a59e1e0"), "Baile", true },
                    { new Guid("570d6e81-7f38-4ffb-a6cb-3cc6a8f9c4dd"), "Peluquería", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseContent_CourseId",
                table: "CourseContent",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseContent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c59de1-fe00-4e96-94f3-afd23b9ccd25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4551b63e-db95-48cf-8f36-582635b76f96");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b7fec5a-c1c0-4888-ae1b-3d250a59e1e0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d0176c0-b51e-4bb7-8c2a-a63bd6715ec7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("570d6e81-7f38-4ffb-a6cb-3cc6a8f9c4dd"));

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
    }
}
