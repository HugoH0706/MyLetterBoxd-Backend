using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Entertainments_EntertainmentID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_EntertainmentID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "EntertainmentID",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntertainmentID",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_EntertainmentID",
                table: "Genres",
                column: "EntertainmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Entertainments_EntertainmentID",
                table: "Genres",
                column: "EntertainmentID",
                principalTable: "Entertainments",
                principalColumn: "ID");
        }
    }
}
