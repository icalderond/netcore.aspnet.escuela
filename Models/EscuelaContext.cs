using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace net.practices.aspnetcore.Models
{
    public class EscuelaContext : DbContext
    {
        #region Properties

        public DbSet<Escuela> Escuelas { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Evaluación> Evaluaciones { get; set; }

        #endregion

        #region Constructor

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        #endregion

        #region  Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Creando escuela para agregar
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "IDA Schoool";
            escuela.Ciudad = "Reforma";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Avenida siempre viva 3245";

            //Cargar cursos de la escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso crear alumnos
            var alumnos = CargarAlumnos(cursos);

            //Cargar evaluaciones


            modelBuilder.Entity<Escuela>().HasData(escuela);
            //Set like array to evite error
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var AsignaturasToAdd = new List<Asignatura> {
                            new Asignatura{ Id = Guid.NewGuid().ToString(),CursoId = curso.Id,Nombre="Matemáticas"} ,
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Educación Física"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Castellano"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Ciencias Naturales"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Programación"}
                };
                asignaturas.AddRange(AsignaturasToAdd);
            }
            return asignaturas;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            var cursosEscuela = new List<Curso>(){
                        new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "101",Jornada = TiposJornada.Mañana },
                        new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso{ Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            return cursosEscuela;
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int limite)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(limite).ToList();
        }

        #endregion
    }
}