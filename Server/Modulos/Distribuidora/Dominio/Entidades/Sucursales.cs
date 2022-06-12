using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class Sucursales : Entity
    {
        public int NroSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EmpresaDistribuidora EmpresaDistribuidora { get; set; }

        [ForeignKey("EmpresaDistribuidora")]
        public Guid EmpresaDistribuidoraId { get; set; }


        public Sucursales()
        {

        }

        public Sucursales(int nroSucursal, string direccion, string telefono, Guid empresaDistribuidoraId)
        {
            NroSucursal = nroSucursal;
            Direccion = direccion;
            Telefono = telefono;
            EmpresaDistribuidoraId = empresaDistribuidoraId;
        }
    }
}
