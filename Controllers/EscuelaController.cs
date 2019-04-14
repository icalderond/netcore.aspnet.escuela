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
            // var escuela = new Escuela();
            // escuela.AñoDeCreación = 2005;
            // escuela.UniqueId = Guid.NewGuid().ToString();
            // escuela.Nombre = "IDA Schoool";
            // escuela.Ciudad="Reforma";
            // escuela.Pais="México";
            // escuela.TipoEscuela=TiposEscuela.Secundaria;
            // escuela.Dirección="Avenida siempre viva 3245";

            var escuelaFromDb=_context.Escuelas.FirstOrDefault();

            return View(escuelaFromDb);
        }
    }
}