using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//(3) Agregamos una clase que se llama Mascota y ponemos atributos y propiedades//
//(4) Agregamos a la clase [Required]//
namespace Veterinaria.Models
{
    public class Mascota
    {
        private int Id;
        [Required]
        private string NombreMascota;
        [Required]
        private string NombreDueño;
        [Required]
        private int Edad;
        [Required]
        private string Telefono;
        private int idSexo;
        private int idEspecie;

        public int Id1 { get => Id; set => Id = value; }
        public string NombreMascota1 { get => NombreMascota; set => NombreMascota = value; }
        public string NombreDueño1 { get => NombreDueño; set => NombreDueño = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public int IdSexo { get => idSexo; set => idSexo = value; }
        public int IdEspecie { get => idEspecie; set => idEspecie = value; }
    }
}