using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoServerBackend.Migrations
{
    /// <inheritdoc />
    public partial class Screenings03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MovieName",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieName",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Screenings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Screenings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieName",
                table: "Screenings",
                column: "MovieName");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Movies_MovieName",
                table: "Screenings",
                column: "MovieName",
                principalTable: "Movies",
                principalColumn: "Name");
        }
    }
}
