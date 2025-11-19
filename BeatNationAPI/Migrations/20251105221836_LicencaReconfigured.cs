using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class LicencaReconfigured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicencaConfig");

            migrationBuilder.AddColumn<string>(
                name: "ApresenFimLucrativos",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApresenSemFinsLucrativos",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distribuicao",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ExibirEmissoraRadio",
                table: "Licencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExibirEmissoraTV",
                table: "Licencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PeriodoUso",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Porcentagem",
                table: "Licencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoyaltShare",
                table: "Licencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreamingAudio",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreamingVideo",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Licencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "PeriodoUso", "Porcentagem", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "300", "2500", "15000", true, false, "1", 20, 20, "20000", "20000", "1" });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "PeriodoUso", "Porcentagem", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "500", "5000", "20000", true, true, "3", 30, 20, "50000", "50000", "1" });

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "ExibirEmissoraRadio", "ExibirEmissoraTV", "PeriodoUso", "Porcentagem", "RoyaltShare", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "Ilimitado", "Ilimitado", "Ilimitado", true, true, "Ilimitado", 100, 20, "Ilimitado", "Ilimitado", "Ilimitado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApresenFimLucrativos",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "ApresenSemFinsLucrativos",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "Distribuicao",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "ExibirEmissoraRadio",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "ExibirEmissoraTV",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "PeriodoUso",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "Porcentagem",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "RoyaltShare",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "StreamingAudio",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "StreamingVideo",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Licencas");

            migrationBuilder.CreateTable(
                name: "LicencaConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApresenFimLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApresenSemFinsLucrativos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribuicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExibirEmissoraRadio = table.Column<bool>(type: "bit", nullable: false),
                    ExibirEmissoraTV = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_LicencaConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicencaConfig_Licencas_LicencaId",
                        column: x => x.LicencaId,
                        principalTable: "Licencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_LicencaConfig_LicencaId",
                table: "LicencaConfig",
                column: "LicencaId");
        }
    }
}
