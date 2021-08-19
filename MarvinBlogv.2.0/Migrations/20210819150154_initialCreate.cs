using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvinBlogv._2._0.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_FollowersId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_FollowingId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_MadeById",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MadeById",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowersId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowingId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "MadeById",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "FollewerId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowersId",
                table: "Followers");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowerId",
                table: "Followers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Followers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserId",
                table: "Followers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Followers_UserId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Followers");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MadeById",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FollewerId",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowersId",
                table: "Followers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MadeById",
                table: "Reviews",
                column: "MadeById");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowersId",
                table: "Followers",
                column: "FollowersId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowingId",
                table: "Followers",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_FollowersId",
                table: "Followers",
                column: "FollowersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_FollowingId",
                table: "Followers",
                column: "FollowingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_MadeById",
                table: "Reviews",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
