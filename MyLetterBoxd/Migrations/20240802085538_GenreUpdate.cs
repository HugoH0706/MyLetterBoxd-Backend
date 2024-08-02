using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLetterBoxd.Migrations
{
    /// <inheritdoc />
    public partial class GenreUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastEntertainments_Casts_CastID",
                table: "CastEntertainments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casts",
                table: "Casts");

            migrationBuilder.RenameTable(
                name: "Casts",
                newName: "Cast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CastEntertainments_Cast_CastID",
                table: "CastEntertainments",
                column: "CastID",
                principalTable: "Cast",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastEntertainments_Cast_CastID",
                table: "CastEntertainments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Casts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casts",
                table: "Casts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CastEntertainments_Casts_CastID",
                table: "CastEntertainments",
                column: "CastID",
                principalTable: "Casts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
