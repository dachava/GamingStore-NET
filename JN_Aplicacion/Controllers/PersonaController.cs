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
    public class PersonaController : Controller
    {
        Log oLog = new Log(@"C:\Users\rasan\OneDrive\Documentos\Lenguajes\PAW\Proyecto_Aplicacion_V4\Aplicacion_Proyecto.sln\Logs");
        private readonly IConfiguration _config;
        PersonaModel model = new PersonaModel();

        public PersonaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(PersonaObj persona)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.RegistrarUsuario(_config, token, persona);
                return RedirectToAction("Index", "Home");
                
            }
            catch
            {
                oLog.Add(persona + " - " + "Problema al registrar un usuario al sistema");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarUsuario(int ID_USUARIO)
        {
            try
            { 
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarUsuario(_config, token, ID_USUARIO);
            return View(datos);
            }
            catch
            {
                oLog.Add(ID_USUARIO + " - " + "Problema al consultar un usuario del sistema");
                return View();
            }
        }

        public ActionResult ActualizarUsuario(int ID_USUARIO)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.ConsultarUsuario(_config, token, ID_USUARIO);
                return View(datos);
            }
            catch
            {
                oLog.Add(ID_USUARIO + " - " + "Problema al actualizar un usuario del sistema");
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarUsuario(PersonaObj persona)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.ActualizarUsuario(_config, token, persona);
                return RedirectToAction("ConsultarJuegos", "Producto");
            }
            catch
            {
                oLog.Add(persona + " - " + "Problema al actualizar un usuario del sistema");
                return View();
            }
        }
    }
}
