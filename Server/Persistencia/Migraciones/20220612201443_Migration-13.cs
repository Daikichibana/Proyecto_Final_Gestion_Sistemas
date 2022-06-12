using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteDistribuidora_EmpresaDistribuidora_ClientesId",
                table: "ClienteDistribuidora");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteDistribuidora_EmpresaCliente_ClientesId",
                table: "ClienteDistribuidora",
                column: "ClientesId",
                principalTable: "EmpresaCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteDistribuidora_EmpresaCliente_ClientesId",
                table: "ClienteDistribuidora");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteDistribuidora_EmpresaDistribuidora_ClientesId",
                table: "ClienteDistribuidora",
                column: "ClientesId",
                principalTable: "EmpresaDistribuidora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
