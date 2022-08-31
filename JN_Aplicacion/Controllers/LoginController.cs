using JN_Aplicacion.Entities;
using JN_Aplicacion.Models;
using JN_Aplicacion_Proyecto;
using Microsoft.AspNetCore.Mvc;

namespace JN_Aplicacion.Controllers
{
    public class LoginController : Controller
    {
        //C:\Users\rasan\OneDrive\Documentos\Lenguajes\PAW\Proyecto_Aplicacion_V4\Aplicacion_Proyecto.sln
        Log oLog = new Log(@"C:\Users\rasan\OneDrive\Documentos\Lenguajes\PAW\Proyecto_Aplicacion_V4\Aplicacion_Proyecto.sln\Logs");
        private readonly IConfiguration _config;
        LoginModel modelo = new LoginModel();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            try
            {
                PersonaObj persona = new PersonaObj();
                return View(persona);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult InicioSesion(PersonaObj persona)
        {
            try
            {
                var respuesta = modelo.ValidarUsuario(persona, _config);
                if (respuesta != null)
                {
                    HttpContext.Session.SetString("Token", respuesta.Token);
                    HttpContext.Session.SetString("Usuario", respuesta.EMAIL);
                    HttpContext.Session.SetInt32("TipoUsuario", respuesta.ID_TIPO);
                    HttpContext.Session.SetInt32("IDUsuario", respuesta.ID_USUARIO);
                    HttpContext.Session.SetString("Nombre", respuesta.NOMBRE);
                    return RedirectToAction("Index", "HomePage");
                }
                else
                {
                    HttpContext.Session.Clear();
                    oLog.Add(persona.EMAIL + " - " + "Problema al ingresar al sistema");
                    return View();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("InicioSesion", "Login");
        }

    }
}

