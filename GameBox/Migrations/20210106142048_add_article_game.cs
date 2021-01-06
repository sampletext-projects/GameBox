using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBox.Migrations
{
    public partial class add_article_game : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Article",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_GameId",
                table: "Article",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Games_GameId",
                table: "Article",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Games_GameId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_GameId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Article");
        }
    }
}
