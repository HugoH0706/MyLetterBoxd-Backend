using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class TMDBUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entertainments",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserEntertainments",
                keyColumns: new[] { "EntertainmentID", "UserID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserEntertainments",
                keyColumns: new[] { "EntertainmentID", "UserID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserEntertainments",
                keyColumns: new[] { "EntertainmentID", "UserID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Entertainments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entertainments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entertainments",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Entertainments");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Entertainments",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "Directors",
                table: "Entertainments",
                newName: "Description");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Entertainments",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Character = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilmID = table.Column<int>(type: "int", nullable: true),
                    FilmID1 = table.Column<int>(type: "int", nullable: true),
                    SerieID = table.Column<int>(type: "int", nullable: true),
                    SerieID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cast_Entertainments_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Entertainments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cast_Entertainments_FilmID1",
                        column: x => x.FilmID1,
                        principalTable: "Entertainments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cast_Entertainments_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Entertainments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cast_Entertainments_SerieID1",
                        column: x => x.SerieID1,
                        principalTable: "Entertainments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntertainmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Entertainments_EntertainmentID",
                        column: x => x.EntertainmentID,
                        principalTable: "Entertainments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CastEntertainments",
                columns: table => new
                {
                    CastID = table.Column<int>(type: "int", nullable: false),
                    EntertainmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastEntertainments", x => new { x.CastID, x.EntertainmentID });
                    table.ForeignKey(
                        name: "FK_CastEntertainments_Cast_CastID",
                        column: x => x.CastID,
                        principalTable: "Cast",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastEntertainments_Entertainments_EntertainmentID",
                        column: x => x.EntertainmentID,
                        principalTable: "Entertainments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenreEntertainments",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    EntertainmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEntertainments", x => new { x.GenreID, x.EntertainmentID });
                    table.ForeignKey(
                        name: "FK_GenreEntertainments_Entertainments_EntertainmentID",
                        column: x => x.EntertainmentID,
                        principalTable: "Entertainments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEntertainments_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_CastEntertainments_EntertainmentID",
                table: "CastEntertainments",
                column: "EntertainmentID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreEntertainments_EntertainmentID",
                table: "GenreEntertainments",
                column: "EntertainmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_EntertainmentID",
                table: "Genres",
                column: "EntertainmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastEntertainments");

            migrationBuilder.DropTable(
                name: "GenreEntertainments");

            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Entertainments",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Entertainments",
                newName: "Directors");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Entertainments",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Entertainments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Entertainments",
                columns: new[] { "ID", "Actors", "Directors", "EntertainmentType", "Genre", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "[\"Leonardo DiCaprio\"]", "[\"Christopher Nolan\"]", 1, "Sci-Fi", 4, "Inception" },
                    { 2, "[\"Keanu Reeves\"]", "[\"The Wachowskis\"]", 1, "Sci-Fi", 4, "The Matrix" }
                });

            migrationBuilder.InsertData(
                table: "Entertainments",
                columns: new[] { "ID", "Actors", "Directors", "EntertainmentType", "Genre", "Rating", "Seasons", "Title" },
                values: new object[,]
                {
                    { 3, "[\"Bryan Cranston\"]", "[\"Vince Gilligan\"]", 2, "Crime", 4, 5, "Breaking Bad" },
                    { 4, "[\"Winona Ryder\"]", "[\"The Duffer Brothers\"]", 2, "Sci-Fi", 3, 4, "Stranger Things" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "password", "JD" },
                    { 2, "Jane", "Smith", "password", "JM" }
                });

            migrationBuilder.InsertData(
                table: "UserEntertainments",
                columns: new[] { "EntertainmentID", "UserID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 2 }
                });
        }
    }
}
