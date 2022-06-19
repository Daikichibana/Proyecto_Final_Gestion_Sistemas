using Compartido;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
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

        public PedidosServices(HttpClient http)
        {
            _http = http;
        }
        #region Administrar Pedido
        public async Task<ServiceResponse<PedidoDTO>> ActualizarPedido(PedidoDTO pedidoDTO)
        {
            var EnlacePedido = BasePedido + "/ActualizarPedido";
            var result = await _http.PutAsJsonAsync(EnlacePedido, pedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> CrearPedido(PedidoDTO pedidoDTO)
        {
            var EnlacePedido = BasePedido + "/InsertarPedido";
            var result = await _http.PostAsJsonAsync(EnlacePedido, pedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> EliminarPedido(PedidoDTO pedidoDTO)
        {
            var EnlacePedido = BasePedido + $"/EliminarPedido?Id={pedidoDTO.Id}";
            var result = await _http.DeleteAsync(EnlacePedido);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerTodosLosPedidos()
        {
            var EnlacePedido = BasePedido + "/ObtenerTodosPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(EnlacePedido);
            return result;
        }
        public async Task<ServiceResponse<OrdenPedidoDTO>> ActualizarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + "/ActualizarOrdenPedido";
            var result = await _http.PutAsJsonAsync(EnlacePedido, OrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> CrearOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + "/InsertarOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlacePedido, OrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> EliminarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + $"/EliminarOrdenPedido?Id={OrdenPedidoDTO.Id}";
            var result = await _http.DeleteAsync(EnlacePedido);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerTodosLosOrdenPedido()
        {
            var EnlacePedido = BasePedido + "/ObtenerTodosOrdenPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> ActualizarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + "/ActualizarDetalleOrdenPedido";
            var result = await _http.PutAsJsonAsync(EnlacePedido, DetalleOrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> CrearDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + "/InsertarDetalleOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlacePedido, DetalleOrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> EliminarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var EnlacePedido = BasePedido + $"/EliminarDetalleOrdenPedido?Id={DetalleOrdenPedidoDTO.Id}";
            var result = await _http.DeleteAsync(EnlacePedido);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<DetalleOrdenPedidoDTO>>> ObtenerTodosLosDetalleOrdenPedido()
        {
            var EnlacePedido = BasePedido + "/ObtenerDetalleOrdenPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<DetalleOrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerOrdenesPedidosDistribuidoraPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosClientePorId(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerOrdenesPedidosClientePorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosDistribuidoraPorId(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerPedidosDistribuidoraPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosClientePorId(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerPedidosClientePorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<PedidoDTO>> ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmacion)
        {
            var EnlacePedido = BasePedido + "/ConfirmarOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlacePedido, confirmacion);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> ObtenerPorIdPedido(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerPorIdPedido?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<PedidoDTO>>(EnlacePedido);
            return result;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> ObtenerOrdenesPedidosPorId(Guid Id)
        {
            var EnlacePedido = BasePedido + "/ObtenerOrdenesPedidosPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>(EnlacePedido);
            return result;
        }
        #endregion

        #region Asignar Entrega a conductor
        #endregion

        #region Realizar Entrega de pedido a cliente
        #endregion

        #region Realizar entrega de pedido a conductor
        #endregion

        #region Realizar facturacion cliente
        #endregion

        #region Realizar Pedido a distribuidora
        #endregion
    }
}
