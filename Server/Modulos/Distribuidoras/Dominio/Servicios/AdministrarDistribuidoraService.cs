using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Servicios
{
    public class AdministrarDistribuidoraService : IAdministrarDistribuidoraService
    {
        IEmpresaDistribuidoraRepository _empresaDistribuidoraRepository;

        public AdministrarDistribuidoraService(IEmpresaDistribuidoraRepository empresaDistribuidoraRepository)
        {
            _empresaDistribuidoraRepository = empresaDistribuidoraRepository;
        }
        public EmpresaDistribuidora Actualizar(EmpresaDistribuidora entity)
        {
            return _empresaDistribuidoraRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _empresaDistribuidoraRepository.Eliminar(id);
        }
        public EmpresaDistribuidora Guardar(EmpresaDistribuidora entity)
        {
            return _empresaDistribuidoraRepository.Guardar(entity);
        }
        public EmpresaDistribuidora ObtenerPorId(Guid id)
        {
            return _empresaDistribuidoraRepository.ObtenerPorId(id);
        }
        public IList<EmpresaDistribuidora> ObtenerTodo()
        {
            return _empresaDistribuidoraRepository.ObtenerTodo();
        }
    }
}
