using Microsoft.AspNetCore.Mvc;

namespace appWebEjemplo.Controllers
{
    public class Cli : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
