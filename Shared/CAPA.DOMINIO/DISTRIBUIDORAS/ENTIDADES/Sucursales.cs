namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class Sucursales : Entity
    {
        public int NroSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
        public Sucursales(int nroSucursal, string direccion, string telefono)
        {
            NroSucursal = nroSucursal;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Sucursales()
        {

        }
    }
}
