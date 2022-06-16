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

        public EmpresaProveedor ActualizarProveedor(EmpresaProveedor entity)
        {
            return _proveedorRepository.Actualizar(entity);
        }

        public void EliminarProveedor(Guid id)
        {
            _proveedorRepository.Eliminar(id);
        }

        public EmpresaProveedor GuardarProveedor(EmpresaProveedor entity)
        {
            return _proveedorRepository.Guardar(entity);
        }

        public EmpresaProveedor ObtenerPorIdProveedor(Guid id)
        {
            return _proveedorRepository.ObtenerPorId(id);
        }

        public IList<EmpresaProveedor> ObtenerTodoProveedor()
        {
            return _proveedorRepository.ObtenerTodo();
        }

    }
}
