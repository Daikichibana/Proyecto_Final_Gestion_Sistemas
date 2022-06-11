using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaProveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "text", nullable: true),
                    RazonSocial = table.Column<string>(type: "text", nullable: true),
                    EmailEmpresa = table.Column<string>(type: "text", nullable: true),
                    EmpresaDistribuidoraId = table.Column<Guid>(type: "uuid", nullable: false),
                    RubroId = table.Column<Guid>(type: "uuid", nullable: false),
                    NITId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsableId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaProveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaProveedor_EmpresaDistribuidora_EmpresaDistribuidoraId",
                        column: x => x.EmpresaDistribuidoraId,
                        principalTable: "EmpresaDistribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaProveedor_NIT_NITId",
                        column: x => x.NITId,
                        principalTable: "NIT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaProveedor_ResponsableEmpresa_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "ResponsableEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaProveedor_Rubro_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NroSucursal = table.Column<int>(type: "integer", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    EmpresaDistribuidoraId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_EmpresaDistribuidora_EmpresaDistribuidoraId",
                        column: x => x.EmpresaDistribuidoraId,
                        principalTable: "EmpresaDistribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroTarjeta = table.Column<int>(type: "integer", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NombreTitular = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaCliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProveedor_EmpresaDistribuidoraId",
                table: "EmpresaProveedor",
                column: "EmpresaDistribuidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProveedor_NITId",
                table: "EmpresaProveedor",
                column: "NITId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProveedor_ResponsableId",
                table: "EmpresaProveedor",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaProveedor_RubroId",
                table: "EmpresaProveedor",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_EmpresaDistribuidoraId",
                table: "Sucursales",
                column: "EmpresaDistribuidoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaProveedor");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "TarjetaCliente");
        }
    }
}
