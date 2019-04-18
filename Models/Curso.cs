using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace net.practices.aspnetcore.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(5)]
        public override string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        [Display(Prompt = "Dirección de correspondencia", Name = "Address")]
        [Required(ErrorMessage = "Se requiere inluir una direccion")]
        [MinLength(10, ErrorMessage = "El tamano minimo de la dirección es diez")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }
    }
}