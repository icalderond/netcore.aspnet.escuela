using System;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;

namespace net.practices.aspnetcore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura();
            asignatura.UniqueId = Guid.NewGuid().ToString();
            asignatura.Nombre = "Matematicas";

            ViewBag.Fecha=DateTime.UtcNow;

            return View(asignatura);
        }
    }
}