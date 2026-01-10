using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Compartilhamento_de_arquivos_por_licenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CompartilharMp3",
                table: "Licencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompartilharTrackout",
                table: "Licencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompartilharWav",
                table: "Licencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                columns: new[] { "CompartilharMp3", "CompartilharTrackout", "CompartilharWav" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                columns: new[] { "CompartilharMp3", "CompartilharTrackout", "CompartilharWav" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                columns: new[] { "CompartilharMp3", "CompartilharTrackout", "CompartilharWav" },
                values: new object[] { false, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompartilharMp3",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "CompartilharTrackout",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "CompartilharWav",
                table: "Licencas");
        }
    }
}
