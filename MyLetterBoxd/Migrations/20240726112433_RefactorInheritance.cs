using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class RefactorInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entertainments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Directors = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Actors = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    EntertainmentType = table.Column<int>(type: "int", nullable: false),
                    Seasons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainments", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserEntertainments",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EntertainmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntertainments", x => new { x.UserID, x.EntertainmentID });
                    table.ForeignKey(
                        name: "FK_UserEntertainments_Entertainments_EntertainmentID",
                        column: x => x.EntertainmentID,
                        principalTable: "Entertainments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEntertainments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
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
                columns: new[] { "ID", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "password" },
                    { 2, "Jane", "Smith", "password" }
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

            migrationBuilder.CreateIndex(
                name: "IX_UserEntertainments_EntertainmentID",
                table: "UserEntertainments",
                column: "EntertainmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntertainments");

            migrationBuilder.DropTable(
                name: "Entertainments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
