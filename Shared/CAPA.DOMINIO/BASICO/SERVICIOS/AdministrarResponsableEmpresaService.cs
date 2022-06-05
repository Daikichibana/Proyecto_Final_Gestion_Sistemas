using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA.BASICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.BASICO.SERVICIOS
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
