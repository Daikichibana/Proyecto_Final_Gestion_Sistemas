namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class Rubro : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Rubro(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
