using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaClienteId",
                table: "TarjetaCliente",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaCliente_EmpresaClienteId",
                table: "TarjetaCliente",
                column: "EmpresaClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaCliente_EmpresaCliente_EmpresaClienteId",
                table: "TarjetaCliente",
                column: "EmpresaClienteId",
                principalTable: "EmpresaCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaCliente_EmpresaCliente_EmpresaClienteId",
                table: "TarjetaCliente");

            migrationBuilder.DropIndex(
                name: "IX_TarjetaCliente_EmpresaClienteId",
                table: "TarjetaCliente");

            migrationBuilder.DropColumn(
                name: "EmpresaClienteId",
                table: "TarjetaCliente");
        }
    }
}
