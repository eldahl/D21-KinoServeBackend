using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoServerBackend.Migrations
{
    /// <inheritdoc />
    public partial class Screenings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                table: "Screenings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MovieName",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieName",
                table: "Screenings");

            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                table: "Screenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
