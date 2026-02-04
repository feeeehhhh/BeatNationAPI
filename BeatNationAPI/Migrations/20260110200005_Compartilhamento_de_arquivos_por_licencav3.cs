using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Compartilhamento_de_arquivos_por_licencav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CompartilharMp3",
                table: "BeatLicencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompartilharTrackout",
                table: "BeatLicencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompartilharWav",
                table: "BeatLicencas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompartilharMp3",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "CompartilharTrackout",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "CompartilharWav",
                table: "BeatLicencas");
        }
    }
}
