using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bpm = table.Column<int>(type: "int", nullable: false),
                    ISRC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlMp3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlWav = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlTrackout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlCapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresetLicencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetLicencas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeatColabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Participacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatColabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeatColabs_Beats_BeatId",
                        column: x => x.BeatId,
                        principalTable: "Beats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PresetLicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licencas_PresetLicencas_PresetLicencaId",
                        column: x => x.PresetLicencaId,
                        principalTable: "PresetLicencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeatLicencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatLicencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeatLicencas_Beats_BeatId",
                        column: x => x.BeatId,
                        principalTable: "Beats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeatLicencas_Licencas_LicencaId",
                        column: x => x.LicencaId,
                        principalTable: "Licencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicencaConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicencaConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicencaConfig_Licencas_LicencaId",
                        column: x => x.LicencaId,
                        principalTable: "Licencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PresetLicencas",
                columns: new[] { "Id", "Descricao", "Nome", "OwnerId" },
                values: new object[] { new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), "Preset inicial com as 3 licenças padrão", "Default", null });

            migrationBuilder.InsertData(
                table: "Licencas",
                columns: new[] { "Id", "AtualizadoEm", "Categoria", "CriadoEm", "Descricao", "Nome", "OwnerId", "PresetLicencaId" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NaoExclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença padrão para uso básico", "Básica", null, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NaoExclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença avançada com mais benefícios dispóniveis", "VIP", null, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença exclusiva para uso total e irrestrito", "Exclusiva", null, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f") }
                });

            migrationBuilder.InsertData(
                table: "LicencaConfig",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "LicencaId", "PeriodoUso", "Porcentagem", "Preco", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "300", "2500", "15000", true, false, new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "1", 20, 0, 20, "20000", "20000", "1" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "500", "5000", "20000", true, true, new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "3", 30, 0, 20, "50000", "50000", "1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Ilimitado", "Ilimitado", "Ilimitado", true, true, new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Ilimitado", 100, 0, 20, "Ilimitado", "Ilimitado", "Ilimitado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeatColabs_BeatId",
                table: "BeatColabs",
                column: "BeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BeatLicencas_BeatId",
                table: "BeatLicencas",
                column: "BeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BeatLicencas_LicencaId",
                table: "BeatLicencas",
                column: "LicencaId");

            migrationBuilder.CreateIndex(
                name: "IX_LicencaConfig_LicencaId",
                table: "LicencaConfig",
                column: "LicencaId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_PresetLicencaId",
                table: "Licencas",
                column: "PresetLicencaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeatColabs");

            migrationBuilder.DropTable(
                name: "BeatLicencas");

            migrationBuilder.DropTable(
                name: "LicencaConfig");

            migrationBuilder.DropTable(
                name: "Beats");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "PresetLicencas");
        }
    }
}
