using Compartido.Dto.Pedidos;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IAsignarEntregaAConductorService
    {
        void AsignarEntregaAconductor(AsignacionEntregaConductorDTO asignacion);
    }
}
