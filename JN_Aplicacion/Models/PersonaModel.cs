using JN_Aplicacion_Proyecto.Entities;
using JN_Aplicacion.Entities;
using System.Net.Http.Headers;
namespace JN_Aplicacion_Proyecto.Models
{
    public class PersonaModel
    {
       public PersonaObj? ConsultarUsuario(IConfiguration _config, string token, int ID_USUARIO)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                
                string rutaServicio = rutaBase + "api/Persona/ConsultarUsuario?ID_USUARIO=" + ID_USUARIO;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<PersonaObj>().Result;
                }

                return new PersonaObj();
            }
        }

        public PersonaObj? RegistrarUsuario(IConfiguration _config, string token, PersonaObj persona)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(persona);
                string rutaServicio = rutaBase + "api/Persona/RegistrarUsuario";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<PersonaObj>().Result;
                }

                return new PersonaObj();
            }
        }

        public PersonaObj? ActualizarUsuario(IConfiguration _config, string token, PersonaObj persona)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(persona);
                string rutaServicio = rutaBase + "api/Persona/ActualizarUsuario";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<PersonaObj>().Result;
                }

                return new PersonaObj();
            }
        }

    }
}
