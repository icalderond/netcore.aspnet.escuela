using System;
using Microsoft.AspNetCore.Mvc;
using net.practices.aspnetcore.Models;

namespace net.practices.aspnetcore.Controllers
{
    public class EscuelaController:Controller
    {
        public IActionResult Index()
        {
            var escuela=new Escuela();
            escuela.AñoFundación=2005;
            escuela.EscuelaId=Guid.NewGuid().ToString();
            escuela.Nombre="IDA Schoool";
            
            return View(escuela);
        }
    }
}