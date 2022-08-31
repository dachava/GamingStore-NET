using JN_Aplicacion_Proyecto.Entities;
using System.Net.Http.Headers;

namespace JN_Aplicacion_Proyecto.Models
{
    public class CarritoModel
    {

        public List<CarritoObj>? MostrarCarrito(IConfiguration _config, string token, int ID_USUARIO)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Carrito/MostrarCarrito?ID_USUARIO=" + ID_USUARIO;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync< List<CarritoObj>>().Result;
                }

                return new List<CarritoObj>();
            }
        }

        public CarritoObj? InsertarAlCarrito(IConfiguration _config, string token, CarritoObj producto)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(producto);
                string rutaServicio = rutaBase + "api/Carrito/InsertarAlCarrito";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<CarritoObj>().Result;
                }

                return new CarritoObj();
            }
        }

        public CarritoObj? QuitarDelCarrito(IConfiguration _config, string token, CarritoObj producto)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(producto);
                string rutaServicio = rutaBase + "api/Producto/QuitarDelCarrito";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    // return respuesta.Content.ReadFromJsonAsync<ProductoObj>().Result;
                    return new CarritoObj();
                }

                return new CarritoObj();
            }
        }
    }
}
