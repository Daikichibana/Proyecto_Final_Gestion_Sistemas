using System;
using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Entidades
{
    public class TarjetaCliente : Entity
    {
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }

        public TarjetaCliente(int numeroTarjeta, DateTime fechaExpiracion, string nombreTitular)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaExpiracion = fechaExpiracion;
            NombreTitular = nombreTitular;
        }

        public TarjetaCliente()
        {

        }
    }

}
