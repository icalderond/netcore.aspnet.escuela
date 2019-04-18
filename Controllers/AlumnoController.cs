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
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        public IActionResult Edit(string id)
        {
            var alumnoResult = from alumno in _context.Alumnos
                                   where alumno.Id == id
                                   select alumno;
            return View(alumnoResult.SingleOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                var alumnoToEdit = _context.Alumnos
                .FirstOrDefault(x => x.Id == alumno.Id);

                alumnoToEdit.Nombre = alumno.Nombre;

                _context.Alumnos.Update(alumnoToEdit);
                _context.SaveChanges();

                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }
    }
}