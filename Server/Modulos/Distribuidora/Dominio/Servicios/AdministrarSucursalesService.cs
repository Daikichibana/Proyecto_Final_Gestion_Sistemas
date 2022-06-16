using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarSucursalesService : IAdministrarSucursalesService
    {
        ISucursalRepository _sucursalRepository;
        public AdministrarSucursalesService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }
        public Sucursales ActualizarSucursales(Sucursales entity)
        {
            return _sucursalRepository.Actualizar(entity);
        }
        public void EliminarSucursales(Guid id)
        {
            _sucursalRepository.Eliminar(id);
        }
        public Sucursales GuardarSucursales(Sucursales entity)
        {
            return _sucursalRepository.Guardar(entity);
        }
        public Sucursales ObtenerPorIdSucursales(Guid id)
        {
            return _sucursalRepository.ObtenerPorId(id);
        }
        public IList<Sucursales> ObtenerTodoSucursales()
        {
            return _sucursalRepository.ObtenerTodo();
        }
    }
}
