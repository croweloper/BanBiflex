using BanBif.BanBiFlex.BE.Fechas;
using BanBif.BanBiFlex.BE.MisReservas;
using BanBif.BanBiFlex.BE.Reserva;
using BanBif.BanBiFlex.BE.ValidarSitio;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;

namespace BanBif.BanBiFlex.App.Controllers
{
    public class MisReservasController : Controller
    {
        // GET: MisReservas
        public ActionResult Index()
        {
            ViewBag.App = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            return View();
        }

        public ActionResult ListarMisReservas(MisReservasRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/MisReservas";
            var result = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate,
                    X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                result = client.PostAsync(apiUrl, content).Result;
                var dataObjects = "";

                dataObjects = result.Content.ReadAsStringAsync().Result;

                var resultado = JsonConvert.DeserializeObject<MisReservasResponse>(dataObjects);

                return Json(resultado);
            }
        }

        public ActionResult ActualizarEstadoReserva(ActualizarEstadoReservaRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ActualizarEstadoReserva";
            var result = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate,
                    X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                result = client.PostAsync(apiUrl, content).Result;
                var dataObjects = "";

                dataObjects = result.Content.ReadAsStringAsync().Result;

                var resultado = JsonConvert.DeserializeObject<ActualizarEstadoReservaResponse>(dataObjects);

                return Json(resultado);
            }
        }
    }
}