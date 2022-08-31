using JN_Aplicacion.Entities;
using JN_Aplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JN_Aplicacion.Controllers
{
    [SesionUsuario]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            var token = HttpContext.Session.GetString("Token");

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Persona/ConsultarUsuario?cedula=" + "402420620";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadFromJsonAsync<PersonaObj>().Result;
                }
            }

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Persona/ConsultarUsuarios";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadFromJsonAsync<List<PersonaObj>>().Result;
                }
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