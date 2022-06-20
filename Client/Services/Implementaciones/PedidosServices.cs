using Compartido;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services.Implementaciones
{
    public class PedidosServices : IPedidosServices
    {
        private readonly HttpClient _http;
        private string BasePedido = "api/AdministrarPedido";
        private string BaseRealizarEntregaAConductor = "api/AsignarEntregaAConductor";
        private string BaseRealizarEntregaPedidoConductor = "api/RealizarEntregaDePedidoAConductor";
        private string BaseRealizarEntregaDePedidoACliente = "api/RealizarEntregaDePedidoACliente";
        private string BaseRealizarFacturacionCliente = "api/RealizarFacturacionCliente";
        private string BaseRealizarPedidoDistribuidora = "api/RealizarPedidoADistribuidora";
        public PedidosServices(HttpClient http)
        {
            _http = http;
        }
        #region Administrar Pedidos
        public async Task<ServiceResponse<PedidoDTO>> ObtenerPorIdPedido(Guid Id)
        {
            string EnlacePedido = BasePedido + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<PedidoDTO>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<PedidoDTO>> EliminarPedido(Guid Id)
        {
            string EnlacePedido = BasePedido + "/";
            var result = await _http.DeleteAsync(EnlacePedido);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }
        public async Task<ServiceResponse<OrdenPedidoDTO>> EliminarOrdenPedido(Guid Id)
        {
            string EnlacePedido = BasePedido + "/";
            var result = await _http.DeleteAsync(EnlacePedido);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {
            string EnlacePedido = BasePedido + $"/ObtenerOrdenesPedidosDistribuidoraPorId?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosClientePorId(Guid Id)
        {
            string EnlacePedido = BasePedido + $"/ObtenerOrdenesPedidosClientePorId?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosDistribuidoraPorId(Guid Id)
        {
            string EnlacePedido = BasePedido + $"/ObtenerPedidosDistribuidoraPorId?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosClientePorId(Guid Id)
        {
            string EnlacePedido = BasePedido + $"/ObtenerPedidosClientePorId?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<PedidoDTO>> ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmarPedidoDTO)
        {
            string EnlacePedido = BasePedido + "/ConfirmarOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlacePedido, confirmarPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<DetalleOrdenPedidoDTO>>> ObtenerDetalleOrdenPedidoPorIdOrden(Guid Id)
        {
            string EnlacePedido = BasePedido + $"/ObtenerDetalleOrdenPedidoPorIdOrden?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<DetalleOrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }
        #endregion

        #region Asignar Entrega a conductor
        public async Task<ServiceResponse<object>> AsignarEntregaAconductor(AsignacionEntregaConductorDTO asignacion)
        {
            string EnlaceRealizarEntregaConductor = BaseRealizarEntregaAConductor + "/AsignarEntregaAconductor";
            var result = await _http.PostAsJsonAsync(EnlaceRealizarEntregaConductor, asignacion);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<object>>();

            return content;
        }
        #endregion

        #region Realizar Entrega de pedido a cliente
        public async Task<ServiceResponse<object>> ConfirmarEntregaCliente(Guid IdPedido)
        {
            string EnlaceRealizarEntregaDePedidoACliente = BaseRealizarEntregaDePedidoACliente + $"/ConfirmarEntregaCliente?IdPedido={IdPedido}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<object>>(EnlaceRealizarEntregaDePedidoACliente);
            return result;
        }
        #endregion

        #region Realizar Entrega de pedido a conductor
        public async Task<ServiceResponse<object>> ConfirmarEntregaPedido(Guid IdPedido)
        {
            string EnlaceRealizarEntregaPedidoConductor = BaseRealizarEntregaPedidoConductor + $"/ConfirmarEntregaPedido?IdPedido={IdPedido}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<object>>(EnlaceRealizarEntregaPedidoConductor);
            return result;
        }
        #endregion

        #region Realizar facturacion cliente
        public async Task<ServiceResponse<object>> EliminarFactura(Guid Id)
        {
            string EnlaceRealizarFacturacionCliente = BaseRealizarFacturacionCliente + "/";
            var result = await _http.DeleteAsync(EnlaceRealizarFacturacionCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<object>>();

            return content;
        }
        public async Task<ServiceResponse<List<FacturaDTO>>> ObtenerTodoFactura()
        {
            string EnlaceRealizarFacturacionCliente = BaseRealizarFacturacionCliente + "/ObtenerTodoFactura";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<FacturaDTO>>>(EnlaceRealizarFacturacionCliente);
            return result;
        }
        public async Task<ServiceResponse<FacturaDTO>> ObtenerPorIdFactura(Guid Id)
        {
            string EnlaceRealizarFacturacionCliente = BaseRealizarFacturacionCliente + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<FacturaDTO>>(EnlaceRealizarFacturacionCliente);
            return result;
        }
        public async Task<ServiceResponse<object>> ConfirmarPago(Guid Id)
        {
            /*
            string EnlaceRealizarFacturacionCliente = BaseRealizarFacturacionCliente + "/ConfirmarPago";
            var result = await _http.PostAsJsonAsync(EnlaceRealizarFacturacionCliente, Id);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<object>>();
            return content;
            */

            string EnlaceRealizarFacturacionCliente = BaseRealizarFacturacionCliente + $"/ConfirmarPago?IdPedido={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<object>>(EnlaceRealizarFacturacionCliente);
            return result;
        }

        #endregion

        #region Realizar Pedido a distribuidora
        public async Task<ServiceResponse<object>> RealizarOrdenPedido(RegistroPedidoDTO registro)
        {
            string EnlaceRealizarPedidoDistribuidora = BaseRealizarPedidoDistribuidora + "/RealizarOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlaceRealizarPedidoDistribuidora, registro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<object>>();

            return content;
        }
        #endregion
    }
}
