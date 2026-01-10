using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAlgumasPropriedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Porcentagem",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "BeatColabs");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Licencas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Bpm",
                table: "Beats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApresenFimLucrativos",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApresenSemFinsLucrativos",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "BeatLicencas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Distribuicao",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ExibirEmissoraRadio",
                table: "BeatLicencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExibirEmissoraTV",
                table: "BeatLicencas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoUso",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoyaltShare",
                table: "BeatLicencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreamingAudio",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreamingVideo",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "BeatLicencas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                column: "Preco",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                column: "Preco",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                column: "Preco",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Licencas");

            migrationBuilder.DropColumn(
                name: "ApresenFimLucrativos",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "ApresenSemFinsLucrativos",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "Distribuicao",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "ExibirEmissoraRadio",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "ExibirEmissoraTV",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "PeriodoUso",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "RoyaltShare",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "StreamingAudio",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "StreamingVideo",
                table: "BeatLicencas");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "BeatLicencas");

            migrationBuilder.AddColumn<int>(
                name: "Porcentagem",
                table: "Licencas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Bpm",
                table: "Beats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "BeatColabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"),
                column: "Porcentagem",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("75974e74-12de-41e4-9fca-f9b87e04e5a6"),
                column: "Porcentagem",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Licencas",
                keyColumn: "Id",
                keyValue: new Guid("ead25d1b-6568-4913-98cd-2f363f235d8b"),
                column: "Porcentagem",
                value: 100);
        }
    }
}
