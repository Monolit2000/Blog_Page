using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPage.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration517 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts");

            migrationBuilder.DropIndex(
                name: "IX_FavoritePosts_BlogPostId1",
                table: "FavoritePosts");

            migrationBuilder.DropColumn(
                name: "BlogPostId1",
                table: "FavoritePosts");

            migrationBuilder.AlterColumn<string>(
                name: "BlogPostId",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BlogUserUserId",
                table: "BlogPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUsers", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePosts_BlogPostId",
                table: "FavoritePosts",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogUserUserId",
                table: "BlogPosts",
                column: "BlogUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserUserId",
                table: "BlogPosts",
                column: "BlogUserUserId",
                principalTable: "BlogUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogUsers_BlogUserUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId",
                table: "FavoritePosts");

            migrationBuilder.DropTable(
                name: "BlogUsers");

            migrationBuilder.DropIndex(
                name: "IX_FavoritePosts_BlogPostId",
                table: "FavoritePosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_BlogUserUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "BlogUserUserId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "FavoritePosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FavoritePosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BlogPostId1",
                table: "FavoritePosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePosts_BlogPostId1",
                table: "FavoritePosts",
                column: "BlogPostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritePosts_BlogPosts_BlogPostId1",
                table: "FavoritePosts",
                column: "BlogPostId1",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }
    }
}
