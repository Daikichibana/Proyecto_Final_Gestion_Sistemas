using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_EmpresaDistribuidoraId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "EmpresaDistribuidoraId",
                table: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaDistribuidoraId",
                table: "Stock",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stock_EmpresaDistribuidoraId",
                table: "Stock",
                column: "EmpresaDistribuidoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "Stock",
                column: "EmpresaDistribuidoraId",
                principalTable: "EmpresaDistribuidora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
