using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vechiculo_Conductor_ConductorId",
                table: "Vechiculo");

            migrationBuilder.DropIndex(
                name: "IX_Vechiculo_ConductorId",
                table: "Vechiculo");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Vechiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConductorId",
                table: "Vechiculo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vechiculo_ConductorId",
                table: "Vechiculo",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vechiculo_Conductor_ConductorId",
                table: "Vechiculo",
                column: "ConductorId",
                principalTable: "Conductor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
