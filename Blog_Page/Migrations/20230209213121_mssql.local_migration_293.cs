using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPage.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration293 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavoritePosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavoritePosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
