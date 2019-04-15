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

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var alumnoResult = from alumno in _context.Alumnos
                                   where alumno.Id == id
                                   select alumno;
                return View(alumnoResult.SingleOrDefault());
            }
            else
            {
                return View("MultiAlumno",_context.Alumnos.ToList());
            }
        }

        public IActionResult MultiAlumno()
        {
            return View(_context.Alumnos.ToList());
        }
    }
}