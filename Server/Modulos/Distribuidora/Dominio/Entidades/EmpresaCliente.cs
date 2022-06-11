﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class EmpresaCliente : Entity, IEmpresa
    {
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public Rubro Rubro { get; set; }
        public NIT NIT { get; set; }
        public ResponsableEmpresa Responsable { get; set; }

        [ForeignKey("Rubro")]
        public Guid RubroId { get; set; }

        [ForeignKey("NIT")]
        public Guid NITId { get; set; }

        [ForeignKey("Responsable")]
        public Guid ResponsableId { get; set; }

        public EmpresaCliente(string nombreEmpresa, string razonSocial, string emailEmpresa, Rubro rubro, NIT nIT, ResponsableEmpresa responsable)
        {
            NombreEmpresa = nombreEmpresa;
            RazonSocial = razonSocial;
            EmailEmpresa = emailEmpresa;
            Rubro = rubro;
            NIT = nIT;
            Responsable = responsable;
        }

        public EmpresaCliente()
        {

        }
    }
}