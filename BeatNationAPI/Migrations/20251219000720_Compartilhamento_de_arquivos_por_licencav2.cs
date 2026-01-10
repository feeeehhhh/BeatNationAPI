using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Compartilhamento_de_arquivos_por_licencav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                column: "CompartilharMp3",
                value: true);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                column: "CompartilharWav",
                value: true);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                columns: new[] { "CompartilharMp3", "CompartilharTrackout", "CompartilharWav" },
                values: new object[] { true, true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                column: "CompartilharMp3",
                value: false);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                column: "CompartilharWav",
                value: false);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                columns: new[] { "CompartilharMp3", "CompartilharTrackout", "CompartilharWav" },
                values: new object[] { false, false, false });
        }
    }
}
