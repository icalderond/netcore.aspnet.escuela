using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;
using System.Linq;

namespace net.practices.aspnetcore.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var alumnoFromDb = _context.Alumnos.FirstOrDefault();
            ViewBag.Fecha = DateTime.UtcNow;

            return View(alumnoFromDb);
        }

        public IActionResult MultiAlumno()
        {
            var alumnosFromDb = _context.Alumnos.ToList();

            return View(alumnosFromDb);
        }
    }
}