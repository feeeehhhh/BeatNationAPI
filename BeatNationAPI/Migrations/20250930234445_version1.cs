using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bpm = table.Column<int>(type: "int", nullable: false),
                    ISRC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlMP3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlWAV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlTRACKOUT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlCAPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEM = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeatColabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeatId = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Porcentagem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeLicencas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamingVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyaltShare = table.Column<int>(type: "int", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PresetId = table.Column<int>(type: "int", nullable: true),
                    NomePreset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BeatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licencas_Beats_BeatId",
                        column: x => x.BeatId,
                        principalTable: "Beats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeatColabs_BeatId",
                table: "BeatColabs",
                column: "BeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_BeatId",
                table: "Licencas",
                column: "BeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeatColabs");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "Beats");
        }
    }
}
