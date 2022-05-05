using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BanBif.BanBiFlex.BE.Login;
using BanBif.BanBiFlex.BE.Fechas;
using BanBif.BanBiFlex.BE.ValidarSitio;
using System.Web.Http;
using BanBif.BanBiFlex.BL;
using BanBif.BanBiFlex.BE.Reserva;
using BanBif.BanBiFlex.BE.MisReservas;

namespace BanBif.BanBiFlex.Api.Controllers
{
    public class BanbiflexController : ApiController
    {
        [HttpPost]
        [Route("api/BanBiflex/Login")]
        public IHttpActionResult ListadoOferta(LoginRequest request)
        {
            return Json(new SepacionSitioBL().Login(request));
        }

        [HttpPost]
        [Route("api/BanBiflex/ValidarFechas")]
        public IHttpActionResult ValidarFechas(FechasRequest request)
        {
            return Json(new SepacionSitioBL().ValidarFechasReserva());
        }


        [HttpPost]
        [Route("api/BanBiflex/ValidarSitios")]
        public IHttpActionResult ValidarSitios(ValidarSitioRequest request)
        {
            return Json(new SepacionSitioBL().ValidarSitio(request));
        }
        [HttpPost]
        [Route("api/BanBiflex/ValidarSalas")]
        public IHttpActionResult ValidarSalas(ValidarSitioRequest request)
        {
            return Json(new SepacionSitioBL().ValidarSalasReuniones(request));
        }
        [HttpPost]
        [Route("api/BanBiflex/RegistrarReserva")]
        public IHttpActionResult RegistrarReserva(ReservaRequest request)
        {
            return Json(new SepacionSitioBL().RegistrarReserva(request));
        }
        [HttpPost]
        [Route("api/BanBiflex/MisReservas")]
        public IHttpActionResult MisReservas(MisReservasRequest request)
        {
            return Json(new SepacionSitioBL().ListarMisReservas(request));
        }
        [HttpPost]
        [Route("api/BanBiflex/ListarReservasDocumento")]
        public IHttpActionResult ListarReservasDocumento(ValidarReservaDocRequest request)
        {
            return Json(new SepacionSitioBL().ListarReservasDocumento(request));
        }


        [HttpPost]
        [Route("api/BanBiflex/ActualizarEstadoReserva")]
        public IHttpActionResult ActualizarEstadoReserva(ActualizarEstadoReservaRequest request)
        {
            return Json(new SepacionSitioBL().ActualizarEstadoReserva(request));
        }

        [HttpPost]
        [Route("api/BanBiflex/ValidarAforoSala")]
        public IHttpActionResult ValidarAforoSala(AforoSitioRequest request)
        {
            return Json(new SepacionSitioBL().ValidarAforoSala(request));
        }

        [HttpPost]
        [Route("api/BanBiflex/ValidarCorreoUsuario")]
        public IHttpActionResult ValidarCorreoUsuario(ValidarCorreoRequest request)
        {
            return Json(new SepacionSitioBL().ValidarCorreoUsuario(request));
        }

        [HttpPost]
        [Route("api/BanBiflex/ValidarHoraSala")]
        public IHttpActionResult ValidarHoraSala(HoraSitioRequest request)
        {
            return Json(new SepacionSitioBL().ValidarHoraSala(request));
        }

    }
}