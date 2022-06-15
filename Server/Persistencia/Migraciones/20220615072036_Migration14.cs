using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaDistribuidoraId",
                table: "OrdenPedido",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPedido_EmpresaDistribuidoraId",
                table: "OrdenPedido",
                column: "EmpresaDistribuidoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenPedido_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "OrdenPedido",
                column: "EmpresaDistribuidoraId",
                principalTable: "EmpresaDistribuidora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenPedido_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "OrdenPedido");

            migrationBuilder.DropIndex(
                name: "IX_OrdenPedido_EmpresaDistribuidoraId",
                table: "OrdenPedido");

            migrationBuilder.DropColumn(
                name: "EmpresaDistribuidoraId",
                table: "OrdenPedido");
        }
    }
}
