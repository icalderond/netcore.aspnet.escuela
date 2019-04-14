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
        // public IActionResult Index()
        // {
        //     return View(_context.Asignaturas.FirstOrDefault());
        // }

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrEmpty(asignaturaId))
            {
                var asignatura = _context.Asignaturas
                .Where(x => x.Id == asignaturaId).SingleOrDefault();
                return View(asignatura);
            }else{
                return View("MultiAsignatura",_context.Asignaturas.ToList());
            }
        }

        public IActionResult MultiAsignatura()
        {
            return View(_context.Asignaturas.ToList());
        }
    }
}