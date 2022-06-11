using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia.Migraciones
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleNotaRecepcion_Stock_StockId",
                table: "DetalleNotaRecepcion");

            migrationBuilder.AlterColumn<Guid>(
                name: "StockId",
                table: "DetalleNotaRecepcion",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotaRecepcionId",
                table: "DetalleNotaRecepcion",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "NotaRecepcion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistribuidoraId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaRecepcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaRecepcion_EmpresaDistribuidora_DistribuidoraId",
                        column: x => x.DistribuidoraId,
                        principalTable: "EmpresaDistribuidora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaRecepcion_EmpresaProveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "EmpresaProveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeseaFactura = table.Column<bool>(type: "boolean", nullable: false),
                    PedidoConfirmado = table.Column<bool>(type: "boolean", nullable: false),
                    AclaracionCliente = table.Column<string>(type: "text", nullable: true),
                    AclaracionDistribuidor = table.Column<string>(type: "text", nullable: true),
                    MetodoPago = table.Column<string>(type: "text", nullable: true),
                    CodigoQR = table.Column<byte[]>(type: "bytea", nullable: true),
                    EmpresaClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenPedido_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CantidadOrdenada = table.Column<int>(type: "integer", nullable: false),
                    OrdenPedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenPedido_OrdenPedido_OrdenPedidoId",
                        column: x => x.OrdenPedidoId,
                        principalTable: "OrdenPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenPedido_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EstadoEnvio = table.Column<string>(type: "text", nullable: true),
                    EstadoPago = table.Column<string>(type: "text", nullable: true),
                    OrdenPedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConductorAsignadoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_AsignacionVechiculoConductor_ConductorAsignadoId",
                        column: x => x.ConductorAsignadoId,
                        principalTable: "AsignacionVechiculoConductor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_OrdenPedido_OrdenPedidoId",
                        column: x => x.OrdenPedidoId,
                        principalTable: "OrdenPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NroComprobante = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotaRecepcion_NotaRecepcionId",
                table: "DetalleNotaRecepcion",
                column: "NotaRecepcionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenPedido_OrdenPedidoId",
                table: "DetalleOrdenPedido",
                column: "OrdenPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenPedido_StockId",
                table: "DetalleOrdenPedido",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PedidoId",
                table: "Factura",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaRecepcion_DistribuidoraId",
                table: "NotaRecepcion",
                column: "DistribuidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaRecepcion_ProveedorId",
                table: "NotaRecepcion",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPedido_EmpresaClienteId",
                table: "OrdenPedido",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ConductorAsignadoId",
                table: "Pedido",
                column: "ConductorAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_OrdenPedidoId",
                table: "Pedido",
                column: "OrdenPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleNotaRecepcion_NotaRecepcion_NotaRecepcionId",
                table: "DetalleNotaRecepcion",
                column: "NotaRecepcionId",
                principalTable: "NotaRecepcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleNotaRecepcion_Stock_StockId",
                table: "DetalleNotaRecepcion",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleNotaRecepcion_NotaRecepcion_NotaRecepcionId",
                table: "DetalleNotaRecepcion");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleNotaRecepcion_Stock_StockId",
                table: "DetalleNotaRecepcion");

            migrationBuilder.DropTable(
                name: "DetalleOrdenPedido");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "NotaRecepcion");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "OrdenPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetalleNotaRecepcion_NotaRecepcionId",
                table: "DetalleNotaRecepcion");

            migrationBuilder.DropColumn(
                name: "NotaRecepcionId",
                table: "DetalleNotaRecepcion");

            migrationBuilder.AlterColumn<Guid>(
                name: "StockId",
                table: "DetalleNotaRecepcion",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleNotaRecepcion_Stock_StockId",
                table: "DetalleNotaRecepcion",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
