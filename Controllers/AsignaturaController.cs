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
        public IActionResult Index()
        {
            var asignaturaFromDb = _context.Asignaturas.FirstOrDefault(); ;

            ViewBag.Fecha = DateTime.UtcNow;

            return View(asignaturaFromDb);
        }

        public IActionResult MultiAsignatura()
        {
            var asignaturasFromDb = _context.Asignaturas.ToList();

            return View(asignaturasFromDb);
        }
    }
}