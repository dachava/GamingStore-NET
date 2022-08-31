using JN_Aplicacion.Entities;

namespace JN_Aplicacion.Models
{
    public class LoginModel
    {
        public PersonaObj? ValidarUsuario(PersonaObj persona, IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(persona);
                string rutaServicio = rutaBase + "api/Persona/Autenticar";
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                return (respuesta.IsSuccessStatusCode ? respuesta.Content.ReadFromJsonAsync<PersonaObj>().Result : null);
            }
        }
    }
}
