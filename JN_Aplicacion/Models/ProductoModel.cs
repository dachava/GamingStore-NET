using JN_Aplicacion_Proyecto.Entities;
using System.Net.Http.Headers;

namespace JN_Aplicacion_Proyecto.Models
{
    public class ProductoModel
    {
        public List<ProductoObj>? ConsultarJuegos(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Producto/ConsultarJuegos";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<ProductoObj>>().Result;
                }

                return new List<ProductoObj>();
            }
        }

        public ProductoObj? ConsultarJuego(IConfiguration _config, string token, int ID_PRODUCTO)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Producto/ConsultarJuego?ID_PRODUCTO=" + ID_PRODUCTO;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProductoObj>().Result;
                }

                return new ProductoObj();
            }
        }

        public List<ProductoObj>? FiltrarJuego(IConfiguration _config, string token, int ID_TIPO)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Producto/FiltrarJuego?ID_TIPO=" + ID_TIPO;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<ProductoObj>>().Result;
                }

                return new List<ProductoObj>();
            }
        }

        public ProductoObj? RegistrarJuego(IConfiguration _config, string token , ProductoObj producto)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(producto);
                string rutaServicio = rutaBase + "api/Producto/RegistrarJuego";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProductoObj>().Result;
                }

                return new ProductoObj();
            }
        }
       
        public ProductoObj? EditarJuego(IConfiguration _config, string token, ProductoObj producto)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(producto);
                string rutaServicio = rutaBase + "api/Producto/EditarJuego";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProductoObj>().Result;
                }

                return new ProductoObj();
            }
        }
     
        public ProductoObj? EliminarJuego(IConfiguration _config, string token, ProductoObj producto)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(producto);
                string rutaServicio = rutaBase + "api/Producto/EliminarJuego";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    // return respuesta.Content.ReadFromJsonAsync<ProductoObj>().Result;
                    return new ProductoObj();
                }

                return new ProductoObj();
            }
        }
    }
}
