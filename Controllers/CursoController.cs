using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;
using System.Linq;

namespace net.practices.aspnetcore.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var cursoResult = from curso in _context.Cursos
                                   where curso.Id == id
                                   select curso;
                return View(cursoResult.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso",_context.Cursos.ToList());
            }
        }

        public IActionResult MultiCurso()
        {
            return View(_context.Cursos.ToList());
        }
    }
}