using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class TarjetaCliente : Entity
    {
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }
        public EmpresaCliente EmpresaCliente { get; set; }

        [ForeignKey("EmpresaCliente")]
        public Guid EmpresaClienteId { get; set; }

        public TarjetaCliente()
        {

        }
        public TarjetaCliente(int numeroTarjeta, DateTime fechaExpiracion, string nombreTitular, EmpresaCliente empresaCliente)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaExpiracion = fechaExpiracion;
            NombreTitular = nombreTitular;
            EmpresaCliente = empresaCliente;
        }
    }

}
