using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPage.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration889 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts");

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId1",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId1",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
