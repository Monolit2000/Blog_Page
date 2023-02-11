using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPage.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "repliesId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "repliesId",
                table: "Comments");
        }
    }
}
