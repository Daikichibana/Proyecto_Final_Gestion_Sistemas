using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class Vechiculo : Entity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public Vechiculo()
        {

        }
        public Vechiculo(string placa, string modelo, string marca)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
        }
    }
}
