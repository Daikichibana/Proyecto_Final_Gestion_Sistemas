using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaDistribuidoraId",
                table: "Vechiculo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vechiculo_EmpresaDistribuidoraId",
                table: "Vechiculo",
                column: "EmpresaDistribuidoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vechiculo_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "Vechiculo",
                column: "EmpresaDistribuidoraId",
                principalTable: "EmpresaDistribuidora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vechiculo_EmpresaDistribuidora_EmpresaDistribuidoraId",
                table: "Vechiculo");

            migrationBuilder.DropIndex(
                name: "IX_Vechiculo_EmpresaDistribuidoraId",
                table: "Vechiculo");

            migrationBuilder.DropColumn(
                name: "EmpresaDistribuidoraId",
                table: "Vechiculo");
        }
    }
}
