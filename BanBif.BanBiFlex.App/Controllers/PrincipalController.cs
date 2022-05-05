using BanBif.BanBiFlex.BE.Fechas;
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
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            ViewBag.App = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            return View();
        }

        public ActionResult ValidarFechas(FechasRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarFechas";
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

                var resultado = JsonConvert.DeserializeObject<FechasResponse>(dataObjects);

                return Json(resultado);
            }
        }

        public ActionResult ValidarSitios(ValidarSitioRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarSitios";
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

                var resultado = JsonConvert.DeserializeObject<ValidarSitioResponse>(dataObjects);

                return Json(resultado);
            }
        }
        public ActionResult ValidarSalas(ValidarSitioRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarSalas";
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

                var resultado = JsonConvert.DeserializeObject<ValidarSitioResponse>(dataObjects);

                return Json(resultado);
            }
        }


        public ActionResult RegistrarReserva(ReservaRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/RegistrarReserva";
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

                var resultado = JsonConvert.DeserializeObject<ReservaResponse>(dataObjects);

                return Json(resultado);
            }
        }

        public ActionResult ValidarAforoSala(AforoSitioRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarAforoSala";
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

                var resultado = JsonConvert.DeserializeObject<AforoSitioResponse>(dataObjects);

                return Json(resultado);
            }
        }

        public ActionResult ValidarCorreoUsuario(ValidarCorreoRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarCorreoUsuario";
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

                var resultado = JsonConvert.DeserializeObject<ValidarCorreoResponse>(dataObjects);

                return Json(resultado);
            }
        }

        public ActionResult ValidarHoraSala(HoraSitioRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ValidarHoraSala";
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

                var resultado = JsonConvert.DeserializeObject<HoraSitioResponse>(dataObjects);

                return Json(resultado);
            }
        }
    }
}