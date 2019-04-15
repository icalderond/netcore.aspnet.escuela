using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;

namespace net.practices.aspnetcore.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrEmpty(asignaturaId))
            {
                var asignatura = _context.Asignaturas
                .Where(x => x.Id == asignaturaId).SingleOrDefault();
                return View(asignatura);
            }
            else
            {
                return View("MultiAsignatura", _context.Asignaturas.ToList());
            }
        }

        public IActionResult MultiAsignatura()
        {
            return View(_context.Asignaturas.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();

                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }

        public IActionResult Edit(string id)
        {
            var asignaturaResult = from asignatura in _context.Asignaturas
                              where asignatura.Id == id
                              select asignatura;
            return View(asignaturaResult.SingleOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                var asignaturaToEdit = _context.Asignaturas
                .FirstOrDefault(x => x.Id == asignatura.Id);

                asignaturaToEdit.Nombre = asignatura.Nombre;

                _context.Asignaturas.Update(asignaturaToEdit);
                _context.SaveChanges();

                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
    }
}