using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades
{
    public class NIT : Entity
    {
        public string NombreFacturacion { get; set; }
        public string NumeroNIT { get; set; }
        public NIT(string nombreFacturacion, string numeroNIT)
        {
            NombreFacturacion = nombreFacturacion;
            NumeroNIT = numeroNIT;
        }
    }
}
