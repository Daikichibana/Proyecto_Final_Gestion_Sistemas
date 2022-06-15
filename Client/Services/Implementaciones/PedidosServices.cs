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
        private string EnlacePedido = "api/AdministrarPedido";

        public PedidosServices(HttpClient http)
        {
            _http = http;
        }
        #region Administrar Pedido
        public async Task<ServiceResponse<PedidoDTO>> ActualizarPedido(PedidoDTO pedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/ActualizarPedido";
            var result = await _http.PutAsJsonAsync(enlaceConcatenado, pedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> CrearPedido(PedidoDTO pedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/InsertarPedido";
            var result = await _http.PostAsJsonAsync(enlaceConcatenado, pedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> EliminarPedido(PedidoDTO pedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/EliminarPedido";
            var result = await _http.DeleteAsync($"{enlaceConcatenado}?Id={pedidoDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerTodosLosPedidos()
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerTodosPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(enlaceConcatenado);
            return result;
        }
        public async Task<ServiceResponse<OrdenPedidoDTO>> ActualizarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/ActualizarOrdenPedido";
            var result = await _http.PutAsJsonAsync(enlaceConcatenado, OrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> CrearOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/InsertarOrdenPedido";
            var result = await _http.PostAsJsonAsync(enlaceConcatenado, OrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> EliminarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/EliminarOrdenPedido";
            var result = await _http.DeleteAsync($"{enlaceConcatenado}?Id={OrdenPedidoDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerTodosLosOrdenPedido()
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerTodosOrdenPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> ActualizarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/ActualizarDetalleOrdenPedido";
            var result = await _http.PutAsJsonAsync(enlaceConcatenado, DetalleOrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> CrearDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/InsertarDetalleOrdenPedido";
            var result = await _http.PostAsJsonAsync(enlaceConcatenado, DetalleOrdenPedidoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<DetalleOrdenPedidoDTO>> EliminarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO)
        {
            var enlaceConcatenado = EnlacePedido + "/EliminarDetalleOrdenPedido";
            var result = await _http.DeleteAsync($"{enlaceConcatenado}?Id={DetalleOrdenPedidoDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<DetalleOrdenPedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<DetalleOrdenPedidoDTO>>> ObtenerTodosLosDetalleOrdenPedido()
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerDetalleOrdenPedido";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<DetalleOrdenPedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerOrdenesPedidosDistribuidoraPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosClientePorId(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerOrdenesPedidosClientePorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrdenPedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosDistribuidoraPorId(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerPedidosDistribuidoraPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosClientePorId(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerPedidosClientePorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<PedidoDTO>>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<PedidoDTO>> ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmacion)
        {
            var enlaceConcatenado = EnlacePedido + "/ConfirmarOrdenPedido";
            var result = await _http.PostAsJsonAsync(enlaceConcatenado, confirmacion);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PedidoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<PedidoDTO>> ObtenerPorIdPedido(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerPorIdPedido?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<PedidoDTO>>(enlaceConcatenado);
            return result;
        }

        public async Task<ServiceResponse<OrdenPedidoDTO>> ObtenerOrdenesPedidosPorId(Guid Id)
        {
            var enlaceConcatenado = EnlacePedido + "/ObtenerOrdenesPedidosPorId?Id=" + Id;
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrdenPedidoDTO>>(enlaceConcatenado);
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
