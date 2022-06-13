using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarProveedorService : IAdministrarProveedorService
    {
        IProveedorRepository _proveedorRepository;

        public AdministrarProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public EmpresaProveedor Actualizar(EmpresaProveedor entity)
        {
            return _proveedorRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _proveedorRepository.Eliminar(id);
        }

        public EmpresaProveedor Guardar(EmpresaProveedor entity)
        {
            return _proveedorRepository.Guardar(entity);
        }

        public EmpresaProveedor ObtenerPorId(Guid id)
        {
            return _proveedorRepository.ObtenerPorId(id);
        }

        public IList<EmpresaProveedor> ObtenerTodo()
        {
            return _proveedorRepository.ObtenerTodo();
        }

    }
}
