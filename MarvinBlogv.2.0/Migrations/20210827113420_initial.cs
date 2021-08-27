using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvinBlogv._2._0.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 12, 34, 19, 508, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 12, 34, 19, 508, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 12, 34, 19, 501, DateTimeKind.Local).AddTicks(4511));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 17, 33, 41, 248, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 17, 33, 41, 249, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 17, 33, 41, 237, DateTimeKind.Local).AddTicks(8756));
        }
    }
}
