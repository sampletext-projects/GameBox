using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBox.Migrations
{
    public partial class add_article_short_desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Article");
        }
    }
}
