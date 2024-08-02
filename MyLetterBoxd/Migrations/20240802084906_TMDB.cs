using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class TMDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Entertainments_FilmID",
                table: "Cast");

            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Entertainments_FilmID1",
                table: "Cast");

            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Entertainments_SerieID",
                table: "Cast");

            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Entertainments_SerieID1",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_FilmID",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_FilmID1",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_SerieID",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_SerieID1",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "FilmID1",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "SerieID",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "SerieID1",
                table: "Cast");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "Cast",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmID1",
                table: "Cast",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieID",
                table: "Cast",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieID1",
                table: "Cast",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cast_FilmID",
                table: "Cast",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_FilmID1",
                table: "Cast",
                column: "FilmID1");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_SerieID",
                table: "Cast",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_SerieID1",
                table: "Cast",
                column: "SerieID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Entertainments_FilmID",
                table: "Cast",
                column: "FilmID",
                principalTable: "Entertainments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Entertainments_FilmID1",
                table: "Cast",
                column: "FilmID1",
                principalTable: "Entertainments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Entertainments_SerieID",
                table: "Cast",
                column: "SerieID",
                principalTable: "Entertainments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Entertainments_SerieID1",
                table: "Cast",
                column: "SerieID1",
                principalTable: "Entertainments",
                principalColumn: "ID");
        }
    }
}
