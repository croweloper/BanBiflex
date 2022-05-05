using BanBif.BanBiFlex.BE.Fechas;
using BanBif.BanBiFlex.BE.Login;
using BanBif.BanBiFlex.BE.MisReservas;
using BanBif.BanBiFlex.BE.Reserva;
using BanBif.BanBiFlex.BE.ValidarSitio;
using BanBif.BanBiFlex.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BL
{
    public class SepacionSitioBL
    {
        public LoginResponse Login(LoginRequest request)
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.Login(request);
            var resultData = new LoginResult();

            foreach (var item in listaBD)
            {
                resultData.Id = (int)item.ID;
                resultData.Nombre = item.NOMBRE;
                resultData.Piso = (int)item.PISO;
                resultData.Estado = (int)item.ESTADO;                
                resultData.NroSitio = (int)item.NROSITIO;
                resultData.FlagDeclaracionJurada = (int)item.DECLARACIONJURADA;
                resultData.FlagListaNegra = (int)item.LISTANEGRA;
                resultData.FlagGrupoCero = (int)item.GRUPOCERO;
                resultData.Correo = item.CORREO;
            }

            return new LoginResponse { result = true, data = resultData };
        }

        public FechasResponse ValidarFechasReserva()
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.ValidarFechasReserva();
            var resultData = new FechasResult();

            foreach (var item in listaBD)
            {
                resultData.FechaMin = item.FECHINICIAL;
                resultData.FechaMax = item.FECHAFINAL;
            }

            return new FechasResponse { result = true, data = resultData };

        }
        public ValidarSitioResponse ValidarSitio(ValidarSitioRequest request)
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.ValidarSitio(request);
            var resultData = new List<ValidarSitioResult>();
            foreach (var item in listaBD)
            {
                resultData.Add(new ValidarSitioResult
                {
                    Mensaje = item.Mensaje,
                    Id= item.ID,
                    Nro=(int) item.NRO
                });
            }

            return new ValidarSitioResponse { result = true, data = resultData };
        }


        public ValidarSitioResponse ValidarSalasReuniones(ValidarSitioRequest request)
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.SalaReuniones(request);
            var resultData = new List<ValidarSitioResult>();
            foreach (var item in listaBD)
            {
                resultData.Add(new ValidarSitioResult
                {
                    Mensaje = item.SALA,
                    Id = item.ID,
                    Nro = 0
                });
            }

            return new ValidarSitioResponse { result = true, data = resultData };
        }

        public ReservaResponse RegistrarReserva(ReservaRequest request)
        {
            var Da = new SepacionSitioDA();
            return new ReservaResponse { result = true, data = Da.RegistrarReserva(request) };
        }

        public AforoSitioResponse ValidarAforoSala(AforoSitioRequest request)
        {
            var Da = new SepacionSitioDA();
            return new AforoSitioResponse { result = true, data = Da.ValidarAforoSala(request) };
        }

        public HoraSitioResponse ValidarHoraSala(HoraSitioRequest request)
        {
            var Da = new SepacionSitioDA();
            return new HoraSitioResponse { result = true, data = Da.ValidarHoraSala(request) };
        }

        public ValidarCorreoResponse ValidarCorreoUsuario(ValidarCorreoRequest request)
        {
            var Da = new SepacionSitioDA();
            return new ValidarCorreoResponse { result = true, data = Da.ValidarCorreoUsuario(request) };
        }
        public MisReservasResponse ListarMisReservas(MisReservasRequest request)
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.ListarMisReservas(request);
            var resultData = new List<MisReservasResult>();
            foreach (var item in listaBD)
            {
                resultData.Add(new MisReservasResult
                {
                    Fecha =  item.FECHA,
                    Id = item.ID,
                    Sitio = item.SITIO,
                    Estacionamiento= item.ESTACIONAMIENTO,
                    Comentario=item.COMENTARIO,
                    Estado=item.ESTADO, 
                    Piso = item.PISO,   
                    Placa= item.NROPLACA
                });
            }
            return new MisReservasResponse { result = true, data = resultData };
        }

        public ReservasDocumentoResponse ListarReservasDocumento(ValidarReservaDocRequest request)
        {
            var Da = new SepacionSitioDA();
            var listaBD = Da.ValidarReservasDocumento(request);
            var resultData = new List<ReservasDocumentoResult>();
            foreach (var item in listaBD)
            {
                resultData.Add(new ReservasDocumentoResult
                {
                    Fecha = item.FECHA.ToString(),
                    Id = item.ID,
                    Sitio = item.NRO,
                    Nombre = item.NOMBRE,
                    Comentario = item.COMENTARIO,
                    Tipo = item.TIPO,
                    Piso = item.PISO,
                    Placa = item.NROPLACA,
                    HoraFinal=item.HoraFinal,
                    HoraInicial=item.HoraInicial                    
                });
            }
            return new ReservasDocumentoResponse { result = true, data = resultData };
        }

        public ActualizarEstadoReservaResponse ActualizarEstadoReserva(ActualizarEstadoReservaRequest request)
        {
            try
            {
                var Da = new SepacionSitioDA();
                return new ActualizarEstadoReservaResponse { result = true, data = Da.ActualizarEstadoReserva(request) };
            }
            catch
            {            
                return new ActualizarEstadoReservaResponse { result = false, data = 0};
            }
            

        }
    }
}
