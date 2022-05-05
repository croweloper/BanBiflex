using BanBif.BanBiFlex.BE.Reserva;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;

namespace BanBif.BanBiFlex.App.Lectora.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.App = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            string ip = Request.UserHostAddress;
            string hostName = Request.UserHostName;
            ViewBag.Ip = ip;
            ViewBag.HostName = hostName;
            return View();
        }

        public ActionResult ListarReservasDocumento(ValidarReservaDocRequest request)
        {
            string apiBaseUrl = ConfigurationManager.AppSettings.Get("UrlAPI").ToString();
            string apiUrl = apiBaseUrl + "api/BanBiflex/ListarReservasDocumento";
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

                var resultado = JsonConvert.DeserializeObject<ReservasDocumentoResponse>(dataObjects);

                return Json(resultado);
            }
        }
    }
}
