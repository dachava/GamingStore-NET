using JN_Aplicacion_Proyecto.Entities;
using JN_Aplicacion_Proyecto.Models;
using Microsoft.AspNetCore.Mvc;

namespace JN_Aplicacion_Proyecto.Controllers
{
    public class CarritoController : Controller
    {
        Log oLog = new Log(@"C:\Users\rasan\OneDrive\Documentos\Lenguajes\PAW\Proyecto_Aplicacion_V4\Aplicacion_Proyecto.sln\Logs");
        private readonly IConfiguration _config;
        CarritoModel model = new CarritoModel();

        public CarritoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult MostrarCarrito(int ID_USUARIO)
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.MostrarCarrito(_config, token, ID_USUARIO);
            return View(datos);
        }

        [HttpGet]
        public ActionResult InsertarAlCarrito()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertarAlCarrito(CarritoObj producto)
        {
            try
            {
                 string token = HttpContext.Session.GetString("Token");
                var datos = model.InsertarAlCarrito(_config, token, producto);
                return RedirectToAction("ConsultarJuegos", "Producto");
            }
            catch
            {
                oLog.Add(producto + " - " + "Problema al insertar un producto al sistema");
                return View();
            }
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuitarDelCarrito(CarritoObj producto)
        {
            try
            {
               string token = HttpContext.Session.GetString("Token");
               var datos = model.QuitarDelCarrito(_config, token, producto);
                return Ok(datos);
            }
            catch (Exception ex)
            {
                oLog.Add(producto + " - " + "Problema al quitar un producto del sistema");
                return View();
            }
        }
    }
}
