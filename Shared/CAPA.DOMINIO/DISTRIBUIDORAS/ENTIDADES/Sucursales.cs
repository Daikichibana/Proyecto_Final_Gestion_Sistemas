﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class Sucursales : Entity
    {
        public int NroSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        /*public EmpresaDistribuidora Distribuidora { get; set; }

        [ForeignKey("EmpresaDistribuidora")]
        public Guid DistribuidoraId { get; set; }*/

        public Sucursales(int nroSucursal, string direccion, string telefono)//, EmpresaDistribuidora empresaDistribuidora)
        {
            NroSucursal = nroSucursal;
            Direccion = direccion;
            Telefono = telefono;
           // Distribuidora = empresaDistribuidora;
        }

        public Sucursales()
        {

        }
    }
}
