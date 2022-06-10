using AutoMapper;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Entidades;
using Compartido.Modulos.Basico.Dto;
using Compartido.Modulos.Clientes.Dto;
using Compartido.Modulos.Distribuidoras.Dto;
using Compartido.Modulos.Inventario.Dto;
using Compartido.Modulos.Usuarios.Dto;

namespace Proyecto_Final_Gestion_Sistemas.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TipoProductoDTO, TipoProducto>();
            CreateMap<TipoProducto, TipoProductoDTO>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<RubroDTO, Rubro>();
            CreateMap<NITDTO, NIT>();
            CreateMap<NIT, NITDTO>();
            CreateMap<ResponsableEmpresaDTO, ResponsableEmpresa>();
            CreateMap<ResponsableEmpresa, ResponsableEmpresaDTO>();
            CreateMap<Rubro, RubroDTO> ();
            CreateMap<Rol, RolDTO> ();
            CreateMap<RolDTO, Rol> ();
            CreateMap<Usuario, UsuarioDTO> ();
            CreateMap<UsuarioDTO, Usuario> ();
            CreateMap<TarjetaCliente, TarjetaClienteDTO>();
            CreateMap<TarjetaClienteDTO, TarjetaCliente>();
            CreateMap<EmpresaCliente, EmpresaClienteDTO>();
            CreateMap<EmpresaClienteDTO, EmpresaCliente>();
            CreateMap<EmpresaDistribuidoraDTO, EmpresaDistribuidora>();
            CreateMap<EmpresaDistribuidora, EmpresaDistribuidoraDTO>();
            CreateMap<ConductorDTO, Conductor>();
            CreateMap<Conductor, ConductorDTO>();
            CreateMap<VehiculoDTO, Vechiculo>();
            CreateMap<Vechiculo, VehiculoDTO>();
            CreateMap<Sucursales, SucursalesDTO>();
            CreateMap<SucursalesDTO, Sucursales>();
            CreateMap<ResponsableAlmacenDTO, ResponsableAlmacen>();
            CreateMap<ResponsableAlmacen, ResponsableAlmacenDTO>();
        }
    }
}
