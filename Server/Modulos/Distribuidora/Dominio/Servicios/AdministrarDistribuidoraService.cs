using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarDistribuidoraService : IAdministrarDistribuidoraService
    {
        IEmpresaDistribuidoraRepository _empresaDistribuidoraRepository;

        public AdministrarDistribuidoraService(IEmpresaDistribuidoraRepository empresaDistribuidoraRepository)
        {
            _empresaDistribuidoraRepository = empresaDistribuidoraRepository;
        }
        public EmpresaDistribuidora ActualizarDistribuidora(EmpresaDistribuidora entity)
        {
            return _empresaDistribuidoraRepository.Actualizar(entity);
        }
        public void EliminarDistribuidora(Guid id)
        {
            _empresaDistribuidoraRepository.Eliminar(id);
        }
        public EmpresaDistribuidora GuardarDistribuidora(EmpresaDistribuidora entity)
        {
            return _empresaDistribuidoraRepository.Guardar(entity);
        }
        public EmpresaDistribuidora ObtenerPorIdDistribuidora(Guid id)
        {
            return _empresaDistribuidoraRepository.ObtenerPorId(id);
        }
        public IList<EmpresaDistribuidora> ObtenerTodoDistribuidora()
        {
            return _empresaDistribuidoraRepository.ObtenerTodo();
        }
    }
}
