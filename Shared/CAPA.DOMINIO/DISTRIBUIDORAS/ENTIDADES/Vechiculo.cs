using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class Vechiculo : Entity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        /*public Conductor Conductor { get; set; }

        [ForeignKey("Conductor")]
        public Guid ConductorId { get; set; }*/

        public Vechiculo(string placa, string modelo, string marca)//, Conductor conductor)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            //Conductor = conductor;
        }

        public Vechiculo()
        {
            
        }
    }
}
