using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IRealizarPedidoAProveedorService
    {
        public void realizarPedidoProveedor(NotaRecepcionDTO notaRecepcionDTO);
    }
}
