namespace CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES
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
