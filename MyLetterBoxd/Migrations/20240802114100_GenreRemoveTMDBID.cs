using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class GenreRemoveTMDBID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TMDBID",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TMDBID",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
