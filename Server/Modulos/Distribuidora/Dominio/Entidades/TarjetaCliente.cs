﻿using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class TarjetaCliente : Entity
    {
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }

        public TarjetaCliente()
        {

        }
        public TarjetaCliente(int numeroTarjeta, DateTime fechaExpiracion, string nombreTitular)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaExpiracion = fechaExpiracion;
            NombreTitular = nombreTitular;
        }
    }

}
