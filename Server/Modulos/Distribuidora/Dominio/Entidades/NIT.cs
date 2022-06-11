namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class NIT : Entity
    {
        public string NombreFacturacion { get; set; }
        public string NumeroNIT { get; set; }

        public NIT()
        {

        }
        public NIT(string nombreFacturacion, string numeroNIT)
        {
            NombreFacturacion = nombreFacturacion;
            NumeroNIT = numeroNIT;
        }
    }
}
