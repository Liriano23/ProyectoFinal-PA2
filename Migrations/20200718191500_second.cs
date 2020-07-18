using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal_PA2.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "VentasDetalle",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2020, 7, 18, 15, 14, 59, 540, DateTimeKind.Local).AddTicks(4975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "VentasDetalle");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "FechaIngreso",
                value: new DateTime(2020, 7, 18, 15, 6, 5, 822, DateTimeKind.Local).AddTicks(8149));
        }
    }
}
