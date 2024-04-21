using appWebEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Text.Json.Serialization;

namespace appWebEjemplo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            string url = "https://localhost:44343/api/alumno/registrar";
            HttpClient cliente = new HttpClient();

            AlumnoRequest alu = new AlumnoRequest();
            alu.Codigo = 120;
            alu.Nombre = "Kendy";
            alu.ApellidoPaterno = "Grau";
            alu.ApellidoMaterno = "Reyes";
            alu.Genero = "M";
            alu.Documento = "89783476";
            alu.Estado = 1;

            var solicitud = cliente.PostAsync(
                url,
                alu,
                new JsonMediaTypeFormatter()
                ).Result;

            if (solicitud.IsSuccessStatusCode)
            {
                var result = solicitud.Content.ReadAsStringAsync().Result;
                var respuesta = JsonConvert.DeserializeObject<ResponseServer>(result);
                Debug.WriteLine("Codigo : " + respuesta.codigo);
                Debug.WriteLine("Mensaje : " + respuesta.mensaje);
            }








            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
