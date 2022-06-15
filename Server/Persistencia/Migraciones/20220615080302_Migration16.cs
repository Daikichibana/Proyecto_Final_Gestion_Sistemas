using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_AsignacionVechiculoConductor_ConductorAsignadoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConductorAsignadoId",
                table: "Pedido",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_AsignacionVechiculoConductor_ConductorAsignadoId",
                table: "Pedido",
                column: "ConductorAsignadoId",
                principalTable: "AsignacionVechiculoConductor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_AsignacionVechiculoConductor_ConductorAsignadoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConductorAsignadoId",
                table: "Pedido",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_AsignacionVechiculoConductor_ConductorAsignadoId",
                table: "Pedido",
                column: "ConductorAsignadoId",
                principalTable: "AsignacionVechiculoConductor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
