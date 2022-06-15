using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio
{
    public interface IInventarioFachada
    { 
    
    }

    public class InventarioFachada : IInventarioFachada
    {
        IActualizarStockPorCompraService actualizarStockService;
        IAdministrarNotaRecepcionService administrarNotaRecepcionService;
        IAdministrarProductoService administrarProductoService;
        IGestionarTipoProductoService gestionarTipoProductoService;
        IRealizarPedidoAProveedorService realizarPedidoAProveedorService;

        public InventarioFachada()
        {
        }

        public InventarioFachada(IActualizarStockPorCompraService actualizarStockService, IAdministrarNotaRecepcionService administrarNotaRecepcionService, IAdministrarProductoService administrarProductoService, IGestionarTipoProductoService gestionarTipoProductoService, IRealizarPedidoAProveedorService realizarPedidoAProveedorService)
        {
            this.actualizarStockService = actualizarStockService;
            this.administrarNotaRecepcionService = administrarNotaRecepcionService;
            this.administrarProductoService = administrarProductoService;
            this.gestionarTipoProductoService = gestionarTipoProductoService;
            this.realizarPedidoAProveedorService = realizarPedidoAProveedorService;
        }
    }
}
