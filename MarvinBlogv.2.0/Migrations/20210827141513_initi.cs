using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvinBlogv._2._0.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000) CHARACTER SET utf8mb4",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 15, 15, 12, 820, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 15, 15, 12, 821, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 15, 15, 12, 817, DateTimeKind.Local).AddTicks(580));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "varchar(1000) CHARACTER SET utf8mb4",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 13, 5, 39, 302, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 13, 5, 39, 303, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 13, 5, 39, 299, DateTimeKind.Local).AddTicks(1994));
        }
    }
}
