using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class RebuildV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeatColabs");

            migrationBuilder.DropTable(
                name: "BeatLicencas");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "PresetLicencas");

            migrationBuilder.RenameColumn(
                name: "UrlCapa",
                table: "Beats",
                newName: "UrlCover");

            migrationBuilder.RenameColumn(
                name: "Tom",
                table: "Beats",
                newName: "Tone");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Beats",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Beats",
                newName: "Scale");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Beats",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Escala",
                table: "Beats",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Beats",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "AtualizadoEm",
                table: "Beats",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DurationUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShareMp3 = table.Column<bool>(type: "bit", nullable: false),
                    ShareWav = table.Column<bool>(type: "bit", nullable: false),
                    ShareTrackout = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompartilharMp3 = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharWav = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharTrackout = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseAssignment_Beats_BeatId",
                        column: x => x.BeatId,
                        principalTable: "Beats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseAssignment_Licenses_LicencasId",
                        column: x => x.LicencasId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Licenses",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Category", "CreatedAt", "Description", "Distribution", "DurationUse", "ExibirEmissoraRadio", "ExibirEmissoraTV", "Name", "Price", "ProducerId", "RoyaltShare", "ShareMp3", "ShareTrackout", "ShareWav", "StreamingAudio", "StreamingVideo", "UpdatedAt", "Video" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "300", "2500", "NaoExclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença padrão para uso básico", "15000", "1", true, false, "Básica", 0m, null, 20, true, false, false, "20000", "20000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "500", "5000", "NaoExclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença avançada com mais benefícios dispóniveis", "20000", "3", true, true, "VIP", 0m, null, 20, false, false, true, "50000", "50000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Ilimited", "Ilimited", "Exclusiva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença exclusiva para uso total e irrestrito", "Ilimited", "Ilimited", true, true, "Exclusiva", 0m, null, 20, true, true, true, "Ilimited", "Ilimited", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilimited" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseAssignment_BeatId",
                table: "LicenseAssignment",
                column: "BeatId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseAssignment_LicencasId",
                table: "LicenseAssignment",
                column: "LicencasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseAssignment");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.RenameColumn(
                name: "UrlCover",
                table: "Beats",
                newName: "UrlCapa");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Beats",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "Tone",
                table: "Beats",
                newName: "Tom");

            migrationBuilder.RenameColumn(
                name: "Scale",
                table: "Beats",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Beats",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Beats",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Beats",
                newName: "Escala");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Beats",
                newName: "AtualizadoEm");

            migrationBuilder.CreateTable(
                name: "BeatColabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Participacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "PresetLicencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetLicencas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetLicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompartilharMp3 = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharTrackout = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharWav = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodoUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompartilharMp3 = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharTrackout = table.Column<bool>(type: "bit", nullable: false),
                    CompartilharWav = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoUso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "PresetLicencas",
                columns: new[] { "Id", "Descricao", "Nome", "OwnerId" },
                values: new object[] { new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), "Preset inicial com as 3 licenças padrão", "Default", null });

            migrationBuilder.InsertData(
                table: "Licencas",
                columns: new[] { "Id", "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "AtualizadoEm", "Categoria", "CompartilharMp3", "CompartilharTrackout", "CompartilharWav", "CriadoEm", "Descricao", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "Nome", "OwnerId", "PeriodoUso", "Preco", "PresetLicencaId", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "300", "2500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NaoExclusiva", true, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença padrão para uso básico", "15000", true, false, "Básica", null, "1", 0m, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "20000", "20000", "1" },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "500", "5000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NaoExclusiva", false, false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença avançada com mais benefícios dispóniveis", "20000", true, true, "VIP", null, "3", 0m, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "50000", "50000", "1" },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Ilimitado", "Ilimitado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exclusiva", true, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Licença exclusiva para uso total e irrestrito", "Ilimitado", true, true, "Exclusiva", null, "Ilimitado", 0m, new Guid("97806a3e-ea4d-4c0f-a82f-664f9016990f"), 20, "Ilimitado", "Ilimitado", "Ilimitado" }
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
                name: "IX_Licencas_PresetLicencaId",
                table: "Licencas",
                column: "PresetLicencaId");
        }
    }
}
