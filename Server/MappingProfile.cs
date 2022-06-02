using AutoMapper;
using CAPAS.CAPA.DOMINIO.BASICO.DTO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;

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
        }
    }
}
