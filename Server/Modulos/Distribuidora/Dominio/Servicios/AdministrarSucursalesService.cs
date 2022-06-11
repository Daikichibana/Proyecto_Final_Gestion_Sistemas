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
        public Sucursales Actualizar(Sucursales entity)
        {
            return _sucursalRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _sucursalRepository.Eliminar(id);
        }
        public Sucursales Guardar(Sucursales entity)
        {
            return _sucursalRepository.Guardar(entity);
        }
        public Sucursales ObtenerPorId(Guid id)
        {
            return _sucursalRepository.ObtenerPorId(id);
        }
        public IList<Sucursales> ObtenerTodo()
        {
            return _sucursalRepository.ObtenerTodo();
        }
    }
}
