using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeatNationAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixLicencaBaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicencaBaseNome",
                table: "PresetLicencasConfig",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "LicencaBaseNome",
                value: "Básica");

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "LicencaBaseNome",
                value: "VIP");

            migrationBuilder.UpdateData(
                table: "PresetLicencasConfig",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "LicencaBaseNome",
                value: "Exclusiva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicencaBaseNome",
                table: "PresetLicencasConfig");
        }
    }
}
