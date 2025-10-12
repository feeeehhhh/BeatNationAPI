using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPresetDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "PresetLicencas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "LicencasBase",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "Básica" },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "VIP" },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Exclusiva" }
                });

            migrationBuilder.InsertData(
                table: "PresetLicencas",
                columns: new[] { "Id", "Descricao", "Nome", "OwnerId" },
                values: new object[] { new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), "Preset inicial com as 3 licenças padrão", "Default", null });

            migrationBuilder.InsertData(
                table: "PresetLicencasConfig",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "LicencaBaseId", "PeriodoUso", "Porcentagem", "Preco", "PresetLicencaId", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 300, 2500, 15000, true, false, new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), 1, 20, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, 20000, 20000, 1 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 500, 5000, 20000, true, true, new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), 3, 30, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, 50000, 50000, 1 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 999999, 999999, 999999, true, true, new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), 99999, 100, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, 999999, 999999, 999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "LicencasBase",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"));

            migrationBuilder.DeleteData(
                table: "LicencasBase",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"));

            migrationBuilder.DeleteData(
                table: "LicencasBase",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"));

            migrationBuilder.DeleteData(
                table: "PresetLicencas",
                keyColumn: "Id",
                keyValue: new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "PresetLicencas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
