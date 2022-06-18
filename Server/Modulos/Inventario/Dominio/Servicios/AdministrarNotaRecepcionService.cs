using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class AdministrarNotaRecepcionService : IAdministrarNotaRecepcionService
    {
        INotaRecepcionRepository _notaRecepcionRepository;
        IMapper _mapper;
        public AdministrarNotaRecepcionService(INotaRecepcionRepository notaRecepcionRepository, IMapper mapper) {
            _notaRecepcionRepository = notaRecepcionRepository;
            _mapper = mapper;
        }

        public IList<NotaRecepcionDTO> GuardarNotaRecepcion(IList<NotaRecepcionDTO> entity)
        {
            throw new NotImplementedException();
        }

        public NotaRecepcionDTO ObtenerPorIdNotaRecepcion(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<NotaRecepcionDTO> ObtenerTodoNotaRecepcion()
        {
            throw new NotImplementedException();
        }
    }
}
