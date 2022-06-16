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
        public ResponsableEmpresa ActualizarResponsableEmpresa(ResponsableEmpresa entity)
        {
            return _responsableEmpresaRepository.Actualizar(entity);
        }
        public void EliminarResponsableEmpresa(Guid id)
        {
            _responsableEmpresaRepository.Eliminar(id);
        }
        public ResponsableEmpresa GuardarResponsableEmpresa(ResponsableEmpresa entity)
        {
            return _responsableEmpresaRepository.Guardar(entity);
        }
        public ResponsableEmpresa ObtenerPorIdResponsableEmpresa(Guid id)
        {
            return _responsableEmpresaRepository.ObtenerPorId(id);
        }

        public IList<ResponsableEmpresa> ObtenerTodoResponsableEmpresa()
        {
            return _responsableEmpresaRepository.ObtenerTodo();
        }
    }
}
