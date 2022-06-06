﻿using AutoMapper;
using CAPAS.CAPA.DOMINIO.BASICO.DTO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.CLIENTES.DTO;
using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.USUARIOS.DTO;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;

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
