using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movil.Migrations
{
    public partial class changeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCourses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "549cc7b5-51ae-4b7d-9a7c-35b823f8d91a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d1c1f3-413f-4808-bb6d-d65634fd044e");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Courses",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c6f9992-db2d-4ed4-8885-17453089f490", "2da33f4e-3f3c-4102-add8-c07603204242", "Usuario", "Usuario" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0971877a-1de5-4d4d-af2d-240a605cf24b", "95f0ca96-7650-4bed-8e0a-f97208724f74", "Profesor", "Profesor" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0971877a-1de5-4d4d-af2d-240a605cf24b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c6f9992-db2d-4ed4-8885-17453089f490");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CategoryCourses",
                columns: table => new
                {
                    IdCategory = table.Column<Guid>(nullable: false),
                    IdCourse = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourses", x => new { x.IdCategory, x.IdCourse });
                    table.ForeignKey(
                        name: "FK_CategoryCourses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3d1c1f3-413f-4808-bb6d-d65634fd044e", "07b1311d-3dcd-4359-aba3-24bb69ae7f31", "Usuario", "Usuario" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "549cc7b5-51ae-4b7d-9a7c-35b823f8d91a", "2e7512dd-0486-49cc-a02f-97533d95b21f", "Profesor", "Profesor" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourses_CategoryId",
                table: "CategoryCourses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourses_CourseId",
                table: "CategoryCourses",
                column: "CourseId");
        }
    }
}
