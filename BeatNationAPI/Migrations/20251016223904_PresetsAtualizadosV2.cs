using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class PresetsAtualizadosV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresetLicencasConfig");

            migrationBuilder.DropColumn(
                name: "PresetLicencaId",
                table: "BeatLicencas");

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Licencas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Licencas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PresetLicencaId",
                table: "Licencas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LicencaConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodoUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Porcentagem = table.Column<int>(type: "int", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicencaConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicencaConfig_Licencas_LicencaId",
                        column: x => x.LicencaId,
                        principalTable: "Licencas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LicencaConfig",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "LicencaId", "LicencasId", "PeriodoUso", "Porcentagem", "Preco", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "300", "2500", "15000", true, false, null, new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "1", 20, 0, 20, "20000", "20000", "1" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "500", "5000", "20000", true, true, null, new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "3", 30, 0, 20, "50000", "50000", "1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Ilimitado", "Ilimitado", "Ilimitado", true, true, null, new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Ilimitado", 100, 0, 20, "Ilimitado", "Ilimitado", "Ilimitado" }
                });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                columns: new[] { "AtualizadoEm", "CriadoEm", "PresetLicencaId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                columns: new[] { "AtualizadoEm", "CriadoEm", "PresetLicencaId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                columns: new[] { "AtualizadoEm", "CriadoEm", "PresetLicencaId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") });

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_PresetLicencaId",
                table: "Licencas",
                column: "PresetLicencaId");

            migrationBuilder.CreateIndex(
                name: "IX_LicencaConfig_LicencaId",
                table: "LicencaConfig",
                column: "LicencaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licencas_PresetLicencas_PresetLicencaId",
                table: "Licencas",
                column: "PresetLicencaId",
                principalTable: "PresetLicencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licencas_PresetLicencas_PresetLicencaId",
                table: "Licencas");

            migrationBuilder.DropTable(
                name: "LicencaConfig");

            migrationBuilder.DropIndex(
                name: "IX_Licencas_PresetLicencaId",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "PresetLicencaId",
                table: "Licencas");

            migrationBuilder.AddColumn<Guid>(
                name: "PresetLicencaId",
                table: "BeatLicencas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PresetLicencasConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetLicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    LicencaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentagem = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetLicencasConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresetLicencasConfig_Licencas_LicencasId",
                        column: x => x.LicencasId,
                        principalTable: "Licencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresetLicencasConfig_PresetLicencas_PresetLicencaId",
                        column: x => x.PresetLicencaId,
                        principalTable: "PresetLicencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PresetLicencasConfig",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "LicencaNome", "LicencasId", "PeriodoUso", "Porcentagem", "Preco", "PresetLicencaId", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "300", "2500", "15000", true, false, "Básica", new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "1", 20, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "20000", "20000", "1" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "500", "5000", "20000", true, true, "VIP", new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "3", 30, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "50000", "50000", "1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Ilimitado", "Ilimitado", "Ilimitado", true, true, "Exclusiva", new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Ilimitado", 100, 0, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "Ilimitado", "Ilimitado", "Ilimitado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresetLicencasConfig_LicencasId",
                table: "PresetLicencasConfig",
                column: "LicencasId");

            migrationBuilder.CreateIndex(
                name: "IX_PresetLicencasConfig_PresetLicencaId",
                table: "PresetLicencasConfig",
                column: "PresetLicencaId");
        }
    }
}
