using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class PresetsAtualizados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeatLicencas_LicencasBase_LicencaId",
                table: "BeatLicencas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetLicencasConfig_LicencasBase_LicencaBaseId",
                table: "PresetLicencasConfig");

            migrationBuilder.DropTable(
                name: "LicencasBase");

            migrationBuilder.RenameColumn(
                name: "LicencaBaseNome",
                table: "PresetLicencasConfig",
                newName: "LicencaNome");

            migrationBuilder.RenameColumn(
                name: "LicencaBaseId",
                table: "PresetLicencasConfig",
                newName: "LicencasId");

            migrationBuilder.RenameIndex(
                name: "IX_PresetLicencasConfig_LicencaBaseId",
                table: "PresetLicencasConfig",
                newName: "IX_PresetLicencasConfig_LicencasId");

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StreamingVideo",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StreamingAudio",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PeriodoUso",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Distribuicao",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApresenSemFinsLucrativos",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApresenFimLucrativos",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Licencas",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "NaoExclusiva", "Licença padrão para uso básico", "Básica", null },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "NaoExclusiva", "Licença avançada com mais benefícios dispóniveis", "VIP", null },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Exclusiva", "Licença exclusiva para uso total e irrestrito", "Exclusiva", null }
                });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "300", "2500", "15000", "1", "20000", "20000", "1" });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "500", "5000", "20000", "3", "50000", "50000", "1" });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { "Ilimitado", "Ilimitado", "Ilimitado", "Ilimitado", "Ilimitado", "Ilimitado", "Ilimitado" });

            migrationBuilder.AddForeignKey(
                name: "FK_BeatLicencas_Licencas_LicencaId",
                table: "BeatLicencas",
                column: "LicencaId",
                principalTable: "Licencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetLicencasConfig_Licencas_LicencasId",
                table: "PresetLicencasConfig",
                column: "LicencasId",
                principalTable: "Licencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeatLicencas_Licencas_LicencaId",
                table: "BeatLicencas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetLicencasConfig_Licencas_LicencasId",
                table: "PresetLicencasConfig");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.RenameColumn(
                name: "LicencasId",
                table: "PresetLicencasConfig",
                newName: "LicencaBaseId");

            migrationBuilder.RenameColumn(
                name: "LicencaNome",
                table: "PresetLicencasConfig",
                newName: "LicencaBaseNome");

            migrationBuilder.RenameIndex(
                name: "IX_PresetLicencasConfig_LicencasId",
                table: "PresetLicencasConfig",
                newName: "IX_PresetLicencasConfig_LicencaBaseId");

            migrationBuilder.AlterColumn<int>(
                name: "Video",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StreamingVideo",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StreamingAudio",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoUso",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Distribuicao",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ApresenSemFinsLucrativos",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ApresenFimLucrativos",
                table: "PresetLicencasConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.InsertData(
                table: "LicencasBase",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), "Básica" },
                    { new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"), "VIP" },
                    { new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"), "Exclusiva" }
                });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { 300, 2500, 15000, 1, 20000, 20000, 1 });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { 500, 5000, 20000, 3, 50000, 50000, 1 });

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ApresenFimLucrativos", "ApresenSemFinsLucrativos", "Distribuicao", "PeriodoUso", "StreamingAudio", "StreamingVideo", "Video" },
                values: new object[] { 999999, 999999, 999999, 99999, 999999, 999999, 999999 });

            migrationBuilder.AddForeignKey(
                name: "FK_BeatLicencas_LicencasBase_LicencaId",
                table: "BeatLicencas",
                column: "LicencaId",
                principalTable: "LicencasBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetLicencasConfig_LicencasBase_LicencaBaseId",
                table: "PresetLicencasConfig",
                column: "LicencaBaseId",
                principalTable: "LicencasBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
