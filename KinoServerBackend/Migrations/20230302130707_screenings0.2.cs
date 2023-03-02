using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoServerBackend.Migrations
{
    /// <inheritdoc />
    public partial class screenings02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Screenings",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Screenings",
                newName: "Id");
        }
    }
}
