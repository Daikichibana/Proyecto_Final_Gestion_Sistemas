using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
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
