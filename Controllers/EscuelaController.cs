using Microsoft.AspNetCore.Mvc;

namespace net.practices.aspnetcore.Controllers
{
    public class EscuelaController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}