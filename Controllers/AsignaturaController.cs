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
            return View(_context.Asignaturas.FirstOrDefault());
        }

        public IActionResult MultiAsignatura()
        {
            return View(_context.Asignaturas.ToList());
        }
    }
}