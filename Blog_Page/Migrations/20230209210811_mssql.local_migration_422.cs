using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPage.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration422 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserUserId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BlogUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogUserUserId",
                table: "BlogPosts",
                newName: "BlogUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_BlogUserUserId",
                table: "BlogPosts",
                newName: "IX_BlogPosts_BlogUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserId",
                table: "BlogPosts",
                column: "BlogUserId",
                principalTable: "BlogUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BlogUserId",
                table: "BlogPosts",
                newName: "BlogUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_BlogUserId",
                table: "BlogPosts",
                newName: "IX_BlogPosts_BlogUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserUserId",
                table: "BlogPosts",
                column: "BlogUserUserId",
                principalTable: "BlogUsers",
                principalColumn: "UserId");
        }
    }
}
