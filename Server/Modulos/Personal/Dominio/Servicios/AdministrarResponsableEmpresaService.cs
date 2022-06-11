using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarResponsableEmpresaService : IResponsableEmpresaService
    {
        IResponsableEmpresaRepository _responsableEmpresaRepository;

        public AdministrarResponsableEmpresaService(IResponsableEmpresaRepository responsableEmpresaRepository)
        {
            _responsableEmpresaRepository = responsableEmpresaRepository;
        }
        public ResponsableEmpresa Actualizar(ResponsableEmpresa entity)
        {
            return _responsableEmpresaRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _responsableEmpresaRepository.Eliminar(id);
        }
        public ResponsableEmpresa Guardar(ResponsableEmpresa entity)
        {
            return _responsableEmpresaRepository.Guardar(entity);
        }
        public ResponsableEmpresa ObtenerPorId(Guid id)
        {
            return _responsableEmpresaRepository.ObtenerPorId(id);
        }

        public IList<ResponsableEmpresa> ObtenerTodo()
        {
            return _responsableEmpresaRepository.ObtenerTodo();
        }
    }
}
