using System;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;

namespace net.practices.aspnetcore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "IDA Schoool";
            escuela.Ciudad="Reforma";
            escuela.Pais="México";
            escuela.TipoEscuela=TiposEscuela.Secundaria;
            escuela.Dirección="Avenida siempre viva 3245";

            return View(escuela);
        }
    }
}