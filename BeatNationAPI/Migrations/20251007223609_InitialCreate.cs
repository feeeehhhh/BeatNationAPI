using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.CreateTable(
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
                 name: "LicencasBase",
                 columns: table => new
                 {
                     Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_LicencasBase", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "PresetLicencas",
                 columns: table => new
                 {
                     Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                 name: "BeatLicencas",
                 columns: table => new
                 {
                     Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     BeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                     LicencaId = table.Column<int>(type: "int", nullable: false),
                     LicencaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                         name: "FK_BeatLicencas_LicencasBase_LicencaId1",
                         column: x => x.LicencaId1,
                         principalTable: "LicencasBase",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                 });

             migrationBuilder.CreateTable(
                 name: "PresetLicencasConfig",
                 columns: table => new
                 {
                     Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     PresetLicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     LicencaBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     PeriodoUso = table.Column<int>(type: "int", nullable: false),
                     Distribuicao = table.Column<int>(type: "int", nullable: false),
                     StreamingAudio = table.Column<int>(type: "int", nullable: false),
                     StreamingVideo = table.Column<int>(type: "int", nullable: false),
                     Video = table.Column<int>(type: "int", nullable: false),
                     ApresenSemFinsLucrativos = table.Column<int>(type: "int", nullable: false),
                     ApresenFimLucrativos = table.Column<int>(type: "int", nullable: false),
                     Preco = table.Column<int>(type: "int", nullable: false),
                     Porcentagem = table.Column<int>(type: "int", nullable: false),
                     RoyaltShare = table.Column<int>(type: "int", nullable: false),
                     ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                     ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false)
                 }, 
            constraints: table =>
                    {
                        table.PrimaryKey("PK_PresetLicencasConfig", x => x.Id);
                        table.ForeignKey(
                            name: "FK_PresetLicencasConfig_LicencasBase_LicencaBaseId",
                            column: x => x.LicencaBaseId,
                            principalTable: "LicencasBase",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_PresetLicencasConfig_PresetLicencas_PresetLicencaId",
                            column: x => x.PresetLicencaId,
                            principalTable: "PresetLicencas",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
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
                    name: "IX_BeatLicencas_LicencaId1",
                    table: "BeatLicencas",
                    column: "LicencaId1");

                migrationBuilder.CreateIndex(
                    name: "IX_PresetLicencasConfig_LicencaBaseId",
                    table: "PresetLicencasConfig",
                    column: "LicencaBaseId");

                migrationBuilder.CreateIndex(
                    name: "IX_PresetLicencasConfig_PresetLicencaId",
                    table: "PresetLicencasConfig",
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
                    name: "PresetLicencasConfig");

                migrationBuilder.DropTable(
                    name: "Beats");

                migrationBuilder.DropTable(
                    name: "LicencasBase");

                migrationBuilder.DropTable(
                    name: "PresetLicencas");
            */
        }
    }
}
