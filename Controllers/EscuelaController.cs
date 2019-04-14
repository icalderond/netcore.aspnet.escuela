using System;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;
using System.Linq;

namespace net.practices.aspnetcore.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var escuelaFromDb=_context.Escuelas.FirstOrDefault();
            return View(escuelaFromDb);
        }
    }
}