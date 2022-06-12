using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteDistribuidora",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientesId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistribuidorasId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDistribuidora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteDistribuidora_EmpresaDistribuidora_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "EmpresaDistribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteDistribuidora_EmpresaDistribuidora_DistribuidorasId",
                        column: x => x.DistribuidorasId,
                        principalTable: "EmpresaDistribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDistribuidora_ClientesId",
                table: "ClienteDistribuidora",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDistribuidora_DistribuidorasId",
                table: "ClienteDistribuidora",
                column: "DistribuidorasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteDistribuidora");
        }
    }
}
