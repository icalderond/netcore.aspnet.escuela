using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;

namespace net.practices.aspnetcore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura();
            asignatura.UniqueId = Guid.NewGuid().ToString();
            asignatura.Nombre = "Matematicas";

            ViewBag.Fecha = DateTime.UtcNow;

            return View(asignatura);
        }

        public IActionResult MultiAsignatura()
        {
            var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas",
                            UniqueId=Guid.NewGuid().ToString()} ,
                            new Asignatura{Nombre="Educación Física",
                            UniqueId=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Castellano",
                            UniqueId=Guid.NewGuid().ToString()},
                            new Asignatura{Nombre="Ciencias Naturales",
                            UniqueId=Guid.NewGuid().ToString()}
                };

            return View(listaAsignaturas);
        }
    }
}