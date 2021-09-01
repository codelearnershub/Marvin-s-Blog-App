using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvinBlogv._2._0.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedOn", "Name", "PublishedOn" },
                values: new object[] { 1, new DateTime(2021, 8, 27, 18, 1, 36, 537, DateTimeKind.Local).AddTicks(7041), "adeoyemarvellous7@gmail.com", null, "SuperAdmin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FullName", "HashSalt", "LastModifiedOn", "PasswordHash", "PublishedOn" },
                values: new object[] { 1, new DateTime(2021, 8, 27, 18, 1, 36, 518, DateTimeKind.Local).AddTicks(8211), "adeoyemarvellous7@gmail.com", "adeoyemarvellous7@gmail.com", "Marvellous Adeoye", "GHAku+jJgJVENsz/Y7le9w==", null, "jeYMxCrAXGBEfEJB7j3IuPv4LhgThc7OIsAovL/J13Q=", null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedOn", "PublishedOn", "RoleId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 8, 27, 18, 1, 36, 538, DateTimeKind.Local).AddTicks(3487), "adeoyemarvellous@gmail.com", null, null, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
