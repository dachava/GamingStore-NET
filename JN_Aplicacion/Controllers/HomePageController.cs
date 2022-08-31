using JN_Aplicacion_Proyecto.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace JN_Aplicacion_Proyecto.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IConfiguration _config;
        // private HelperMail helpermail;

        public HomePageController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index() //string receptor, string asunto, string texto
        {
           /* string mensajefinal = "<h1>Proyecto Fide-Gaming<h1/><h4>" + asunto + " <h4/>"
                                    ;
            this.helpermail.SendMail(receptor, asunto, mensajefinal);
            ViewData["MENSAJE"] = "Mensaje enviado a '" + receptor + "'"; */
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactoObj model) //string receptor, string asunto, string texto
        {
            try
            {
                ViewBag.Resultado = string.Empty;

                string correo = _config.GetSection("AppSettings:Correo").Value;
                string clave = _config.GetSection("AppSettings:Clave").Value;

                using (MailMessage email = new MailMessage(correo, model.Correo))
                {
                    email.Subject = "Correo Contacto de: " + model.Nombre;
                    email.Body = "Hola " + model.Nombre + " ,\n" + "Mi correo es: " + " ,\n" + " ,\n" + model.Correo + " ,\n" + "Asunto: " + model.Asunto + model.body;
                    email.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(correo, clave);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(email);
                    }
                }

                ViewData["MENSAJE"] = "Mensaje enviado, pronto estaremos en contacto";
                return View("Index");
            }
            catch (Exception)
            {
                ViewBag.Resultado = "No se envío correctamente el mensaje";
                return View("Index");
            }

           /* ViewData["MENSAJE"] = "Mensaje enviado a '" + model.Correo + "'"; 
            return View();*/
        }

        public IActionResult Nintendo()
        {
            Entities.ProductoObj obj;
            List<Entities.ProductoObj> lobj = new List<ProductoObj>();
            obj = new ProductoObj();
            obj.NOMBRE = "Mario Kart";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://as01.epimg.net/meristation/imagenes/2019/10/07/noticias/1570455236_456144_1570455511_noticia_normal.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Super Mario Bros";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://assets.nintendo.com/image/upload/c_fill,w_1200/q_auto:best/f_auto/dpr_auto/ncom/es_LA/games/switch/n/new-super-mario-bros-u-deluxe-switch/hero";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "Super Smash Brawl";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/12/super-smash-bros-ultimate_1.jpg?itok=fkYBHneu";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "Animal Crossing ";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 17000;
            obj.IMAGE_URL = "https://animal-crossing.com/assets/icons/share_icon.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Mario Vs Sonic";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://fs-prod-cdn.nintendo-europe.com/media/images/08_content_images/games_6/nintendo_switch_7/nswitch_mario_sonicattheolympicgames/NSwitch_MASATOG_Overview_Gold_BG.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Zelda";
            obj.EMPRESA = "Nintendo";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://i.ytimg.com/vi/oeWPTTjQg18/maxresdefault.jpg";

            lobj.Add(obj);

            return View(lobj);
        }

        public IActionResult PlayStation()
        {
            Entities.ProductoObj obj;
            List<Entities.ProductoObj> lobj = new List<ProductoObj>();
            obj = new ProductoObj();
            obj.NOMBRE = "The Last Of Us";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://as01.epimg.net/meristation/imagenes/2021/08/07/noticias/1628341018_089796_1628341117_noticia_normal.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "The Last Of Us Part II";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 15000;
            obj.IMAGE_URL = "https://as01.epimg.net/meristation/imagenes/2020/04/03/header_image/261291431585911280.jpg";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "FIFA 2022";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 17000;
            obj.IMAGE_URL = "https://esports.as.com/2022/06/16/fifa/FIFA-llega-Xbox-Game-Pass_1583851632_997394_1440x810.jpg";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "Red Dead Redemption";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 17000;
            obj.IMAGE_URL = "https://c4.wallpaperflare.com/wallpaper/385/385/311/4k-screenshot-red-dead-redemption-2-wallpaper-preview.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Little Nightmares";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://assets.nintendo.com/image/upload/c_fill,w_1200/q_auto:best/f_auto/dpr_auto/ncom/es_LA/games/switch/l/little-nightmares-ii-switch/hero";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "UFC";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://gmedia.playstation.com/is/image/SIEPDC/ufc-4-screenshot-05-ps4-24jun20-en-us?$native$";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Days Gone";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://cl.buscafs.com/www.levelup.com/public/uploads/images/695536/695536.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Resident Evil Biohazard";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 35000;
            obj.IMAGE_URL = "https://img2.rtve.es/i/?w=1200&i=https://img2.rtve.es/imagenes/trailer-resident-evil-7-biohazard-videojuego/1486412194196.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Spider Man";
            obj.EMPRESA = "Play Station";
            obj.PRECIO = 30000;
            obj.IMAGE_URL = "https://as01.epimg.net/meristation/imagenes/2020/12/18/noticias/1608300964_763476_1608301048_noticia_normal.jpg";

            lobj.Add(obj);
            return View(lobj);
        }

        public IActionResult XBox()
        {
            Entities.ProductoObj obj;
            List<Entities.ProductoObj> lobj = new List<ProductoObj>();
            obj = new ProductoObj();
            obj.NOMBRE = "HALO";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://i.ytimg.com/vi/zM4sLMw_IMw/maxresdefault.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Cuphead";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 15000;
            obj.IMAGE_URL = "https://compass-ssl.xbox.com/assets/25/4f/254f270b-1cbe-4a29-975c-851a8de5aea6.jpg?n=Cuphead_gallery-0_1350x759_01.jpg";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "Watch Dogs";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 17000;
            obj.IMAGE_URL = "https://s1.gaming-cdn.com/images/products/11832/616x353/watch-dogs-legion-xbox-one-xbox-series-x-s-xbox-one-xbox-series-x-s-game-microsoft-store-united-states-cover.jpg?v=1654077746";

            lobj.Add(obj);


            obj = new ProductoObj();
            obj.NOMBRE = "Call of Duty";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 17000;
            obj.IMAGE_URL = "https://www.somosxbox.com/wp-content/uploads/2020/03/call-of-duty-warzone-soporta-juego-cruzado-790x441.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Need for Speed";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://store-images.s-microsoft.com/image/apps.46186.69435230515002378.5c54c210-6100-4e84-81d0-b92a5aadc00d.019c1377-72ee-4d05-9084-1ab70452bb03?q=90&w=480&h=270";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Tony Hawk";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 27000;
            obj.IMAGE_URL = "https://sm.ign.com/t/ign_es/screenshot/default/wallpapersdencom-tony-hawk-s-pro-skater-1-remaster-3840x2160_acud.1280.jpg";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Crash Bandicoot";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 25000;
            obj.IMAGE_URL = "https://store-images.s-microsoft.com/image/apps.8017.65328483881162508.89a95049-a2dc-4b27-8f56-0a4f5a72a393.31a122bb-6c53-49a1-bd7e-a23586dc6961?q=90&w=480&h=270";

            lobj.Add(obj);

            obj = new ProductoObj();
            obj.NOMBRE = "Grand Theft Auto V";
            obj.EMPRESA = "X-Box";
            obj.PRECIO = 35000;
            obj.IMAGE_URL = "https://compass-ssl.xbox.com/assets/a0/4f/a04f2744-74d9-4668-8263-e0261fbea869.jpg?n=GTA-V_GLP-Page-Hero-1084_1920x1080.jpg";

            lobj.Add(obj);
            return View(lobj);
        }
    }

}
