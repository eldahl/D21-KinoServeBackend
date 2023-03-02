using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoServerBackend.Migrations
{
    /// <inheritdoc />
    public partial class screeningsByID : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Screenings");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieID",
                table: "Screenings",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Movies_MovieID",
                table: "Screenings",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Movies_MovieID",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieID",
                table: "Screenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Screenings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Name");

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
