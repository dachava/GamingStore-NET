using Microsoft.AspNetCore.Mvc;
using JN_Aplicacion.Entities;
using JN_Aplicacion.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using JN_Aplicacion_Proyecto.Models;
using JN_Aplicacion_Proyecto.Entities;

namespace JN_Aplicacion_Proyecto.Controllers
{
    
    public class ProductoController : Controller
    {
        Log oLog = new Log(@"C:\Users\rasan\OneDrive\Documentos\Lenguajes\PAW\Proyecto_Aplicacion_V4\Aplicacion_Proyecto.sln\Logs");
        private readonly IConfiguration _config;
        ProductoModel model = new ProductoModel();

        public ProductoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ConsultarJuegos()
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarJuegos(_config, token);
            return View(datos);
        }

        [HttpGet]
        public ActionResult ConsultarJuego(int ID_PRODUCTO)
        {
            try
            {
                HttpContext.Session.SetInt32("ID_PRODUCTO", ID_PRODUCTO);
                string token = HttpContext.Session.GetString("Token");
                var datos = model.ConsultarJuego(_config, token, ID_PRODUCTO);
                return View(datos);
            }
            catch
            {
                oLog.Add(ID_PRODUCTO + " - " + "Problema al consultar un juego del sistema");
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult FiltrarJuego(int ID_TIPO)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.FiltrarJuego(_config, token, ID_TIPO);
                HttpContext.Session.SetInt32("TipoDeJuego", ID_TIPO);
                return View(datos);
            }
            catch
            {
                oLog.Add(ID_TIPO + " - " + "Problema al filtrar un juego del sistema");
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult RegistrarJuego()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarJuego(ProductoObj producto)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.RegistrarJuego(_config,token, producto);
                return RedirectToAction("ConsultarJuegos", "Producto");
            }
            catch
            {
                oLog.Add(producto + " - " + "Problema al registrar un juego al sistema");
                return View();
            }
        }

        public ActionResult EditarJuego(int ID_PRODUCTO)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.ConsultarJuego(_config, token, ID_PRODUCTO);
                return View(datos);
            }
            catch
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarJuego(ProductoObj producto)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.EditarJuego(_config, token, producto);
                return RedirectToAction("ConsultarJuegos", "Producto");
            }
            catch
            {
                oLog.Add(producto + " - " + "Problema al editar un juego al sistema");
                return View();
            }
        }


        public ActionResult EliminarJuego(int ID_PRODUCTO)
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarJuego(_config, token, ID_PRODUCTO);
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarJuego(ProductoObj producto)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
               var datos = model.EliminarJuego(_config, token, producto);
                //return View("ConsultarJuegos", "Producto");
                var datos1 = model.ConsultarJuegos(_config, token);
                return View("ConsultarJuegos",datos1);
            }
            catch (Exception ex)
            {
                oLog.Add(producto + " - " + "Problema al eliminar un juego del sistema");
                return View();
            }
        }

    }
}
