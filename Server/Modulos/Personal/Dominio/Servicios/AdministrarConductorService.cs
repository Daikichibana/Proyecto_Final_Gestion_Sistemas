using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarConductorService : IAdministrarConductorService
    {
        IConductorRepository _conductorRepository;

        public AdministrarConductorService(IConductorRepository conductorRepository)
        {
            _conductorRepository = conductorRepository;
        }
        public Conductor Actualizar(Conductor entity)
        {
            return _conductorRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _conductorRepository.Eliminar(id);
        }
        public Conductor Guardar(Conductor entity)
        {
            return _conductorRepository.Guardar(entity);
        }
        public Conductor ObtenerPorId(Guid id)
        {
            return _conductorRepository.ObtenerPorId(id);
        }
        public IList<Conductor> ObtenerTodo()
        {
            return _conductorRepository.ObtenerTodo();
        }

    }
}
