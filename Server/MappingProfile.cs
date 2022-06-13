using AutoMapper;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Compartido.Dto.Inventario;
using Compartido.Dto.Inventario.General;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Compartido.Dto.Pedidos.General;

namespace Proyecto_Final_Gestion_Sistemas.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Modulo Distribuidora
            CreateMap<Rubro, RubroDTO>();
            CreateMap<RubroDTO, Rubro>();
            CreateMap<NITDTO, NIT>();
            CreateMap<NIT, NITDTO>();
            CreateMap<TarjetaCliente, TarjetaClienteDTO>();
            CreateMap<TarjetaClienteDTO, TarjetaCliente>();
            CreateMap<EmpresaCliente, EmpresaClienteDTO>();
            CreateMap<EmpresaClienteDTO, EmpresaCliente>();
            CreateMap<EmpresaDistribuidoraDTO, EmpresaDistribuidora>();
            CreateMap<EmpresaDistribuidora, EmpresaDistribuidoraDTO>();
            CreateMap<VehiculoDTO, Vechiculo>();
            CreateMap<Vechiculo, VehiculoDTO>();
            CreateMap<Sucursales, SucursalesDTO>();
            CreateMap<SucursalesDTO, Sucursales>();
            CreateMap<ClientesDistribuidoraDTO, ClientesDistribuidora>();
            CreateMap<ClientesDistribuidora, ClientesDistribuidoraDTO>();

            // Modulo Inventario
            CreateMap<TipoProductoDTO, TipoProducto>();
            CreateMap<TipoProducto, TipoProductoDTO>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<StockDTO, Stock>();

            // Modulo Pedidos
            CreateMap<DetalleOrdenPedido, DetalleOrdenPedidoDTO>();
            CreateMap<DetalleOrdenPedidoDTO, DetalleOrdenPedido>();
            CreateMap<Factura, FacturaDTO>();
            CreateMap<FacturaDTO, Factura>();
            CreateMap<OrdenPedido, OrdenPedidoDTO>();
            CreateMap<OrdenPedidoDTO, OrdenPedido>();
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<PedidoDTO, Pedido>();

            // Modulo Personal
            CreateMap<ResponsableEmpresaDTO, ResponsableEmpresa>();
            CreateMap<ResponsableEmpresa, ResponsableEmpresaDTO>();
            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<ConductorDTO, Conductor>();
            CreateMap<Conductor, ConductorDTO>();
            CreateMap<ResponsableAlmacenDTO, ResponsableAlmacen>();
            CreateMap<ResponsableAlmacen, ResponsableAlmacenDTO>();
            CreateMap<UsuariosRoles, UsuariosRolesDTO>();
            CreateMap<UsuariosRolesDTO, UsuariosRoles>();
           
        }
    }
}
