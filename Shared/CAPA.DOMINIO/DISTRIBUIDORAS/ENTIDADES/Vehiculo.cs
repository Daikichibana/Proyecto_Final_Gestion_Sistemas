namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class Vehiculo : Entity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public Vehiculo(string placa, string modelo, string marca)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
        }

        public Vehiculo()
        {
            
        }
    }
}
