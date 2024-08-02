using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntertainments_Genres_GenreID",
                table: "GenreEntertainments");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Entertainments_EntertainmentID",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_EntertainmentID",
                table: "Genre",
                newName: "IX_Genre_EntertainmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Entertainments_EntertainmentID",
                table: "Genre",
                column: "EntertainmentID",
                principalTable: "Entertainments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntertainments_Genre_GenreID",
                table: "GenreEntertainments",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Entertainments_EntertainmentID",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreEntertainments_Genre_GenreID",
                table: "GenreEntertainments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_EntertainmentID",
                table: "Genres",
                newName: "IX_Genres_EntertainmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreEntertainments_Genres_GenreID",
                table: "GenreEntertainments",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Entertainments_EntertainmentID",
                table: "Genres",
                column: "EntertainmentID",
                principalTable: "Entertainments",
                principalColumn: "ID");
        }
    }
}
