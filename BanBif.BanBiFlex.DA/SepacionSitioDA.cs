using BanBif.BanBiFlex.BE.Login;
using BanBif.BanBiFlex.BE.MisReservas;
using BanBif.BanBiFlex.BE.Reserva;
using BanBif.BanBiFlex.BE.ValidarSitio;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.DA
{
    public class SepacionSitioDA
    {
        public List<SP_BANBIFLEX_LOGIN_Result2> Login(LoginRequest request)
        {
            using (var db = new panelEntities())
            {
                var login = db.SP_BANBIFLEX_LOGIN(request.nroDocumento).ToList();
                return login;
            }
        }

        public List<SP_BANBIFLEX_VALIDAR_FECHA_A_RESERVAR_Result1> ValidarFechasReserva()
        {
            using (var db = new panelEntities())
            {
                var fechas = db.SP_BANBIFLEX_VALIDAR_FECHA_A_RESERVAR().ToList();
                return fechas;
            }
        }

        public int ActualizarEstadoReserva(ActualizarEstadoReservaRequest request)
        {
            using (var db = new panelEntities())
            {
               return db.SP_BANBIFLEX_ACTUALIZAR_ESTADO_RESERVA(request.IdReserva, request.Estado);               
            }
        }

        public List<SP_BANBIFLEX_LISTAR_RESERVAS_Result> ListarMisReservas(MisReservasRequest request)
        {
            using (var db = new panelEntities())
            {
                return db.SP_BANBIFLEX_LISTAR_RESERVAS(request.UsuarioId).ToList();
            }
        }
        public string ValidarAforo(int Piso, string Fecha)
        {
            using (var db = new panelEntities())
            {
                var result= db.SP_BANBIFLEX_VALIDAR_AFORO_PISO(Piso, Fecha).ToList();
                return result[0].ToString();
            }
        }


        public int ValidarAforoSala(AforoSitioRequest request)
        {
            using (var db = new panelEntities())
            {
                var result = db.SP_BANBIFLEX_AFORO_SALA(request.IdSala).ToList();
                return (int) result[0];
            }
        }
        public int ValidarHoraSala(HoraSitioRequest request)
        {
            using (var db = new panelEntities())
            {
                string fecha = string.Concat(request.Fecha.Substring(0, 4), request.Fecha.Substring(5, 2), request.Fecha.Substring(8, 2));
                var result = db.SP_BANBIFLEX_VALIDAR_HORA_SALA(request.IdSala, request.Hora, fecha).ToList();
                return (int)result[0];
            }
        }


        public List<SP_BANBIFLEX_VALIDAR_SITIO_USUARIO_Result2> ValidarSitio(ValidarSitioRequest request)
        {
            using (var db = new panelEntities())
            {
                string fecha=string.Concat(request.Fecha.Substring(0,4), request.Fecha.Substring(5, 2), request.Fecha.Substring(8, 2));
                var sitios = db.SP_BANBIFLEX_VALIDAR_SITIO_USUARIO(request.Piso, request.Sitio, fecha,request.UserId).ToList();
                return sitios;
            } 
        }

        public List<SP_BANBIFLEX_VALIDAR_SALAS_REUNIONES_Result> SalaReuniones(ValidarSitioRequest request)
        {
            using (var db = new panelEntities())
            {
                string fecha = string.Concat(request.Fecha.Substring(0, 4), request.Fecha.Substring(5, 2), request.Fecha.Substring(8, 2));
                var sitios = db.SP_BANBIFLEX_VALIDAR_SALAS_REUNIONES(fecha).ToList();
                return sitios;
            }
        }

        public List<SP_BANBIFLEX_LISTAR_RESERVAS_DOCUMENTO_Result> ValidarReservasDocumento(ValidarReservaDocRequest request)
        {
            using (var db = new panelEntities())
            {            
               return db.SP_BANBIFLEX_LISTAR_RESERVAS_DOCUMENTO(request.Documento,request.HostName).ToList();              
            }
        }

        public int RegistrarReserva(ReservaRequest request)
        {
            using (var db = new panelEntities())
            {
                string anio = request.Fecha.Year.ToString();
                string mes = request.Fecha.Month.ToString();
                string dia  = request.Fecha.Day.ToString();
                
                if(Convert.ToInt16(dia) < 10)
                {
                    dia = string.Concat("0", dia);
                }

                if (Convert.ToInt16(mes) < 10)
                {
                    mes = string.Concat("0", mes);
                }

                string fecha = string.Concat(anio, mes, dia);

                string Aforo = ValidarAforo(request.EspacioTrabajoId, fecha);
                if(Aforo== "AFORO ACEPTABLE")
                {
                    var registro = new BANBIFLEX_RESERVA();
                    registro.FECHA =  request.Fecha;
                    registro.ID_ESPACIOTRABAJO = request.EspacioTrabajoId;
                    registro.ID_USUARIO = request.UsuarioId;
                    registro.ESTADO = "RESERVADO";
                    registro.NROPLACA = request.Placa;
                    registro.COMENTARIO = request.Comentario;
                    registro.FECHARESERVA = DateTime.Now;
                    if(request.HoraFinal== null)
                    {
                        registro.HoraInicial = "09:00";
                        registro.HoraFinal = "18:00";
                    }
                    else
                    {
                        registro.HoraFinal = request.HoraFinal;
                        registro.HoraInicial = request.HoraInicial;
                    }
                    
                    db.BANBIFLEX_RESERVA.Add(registro);
                    db.SaveChanges();

                    if (request.Placa != string.Empty)
                    {
                        db.SP_BANBIFLEX_ACTUALIZA_ESTACIONAMIENTO_RESERVA(registro.ID, fecha, request.Comentario);
                    }

                    return registro.ID;
                }
                else
                {
                    return -2;
                }
            }
        }

        public int ValidarCorreoUsuario(ValidarCorreoRequest request)
        {
            using (var db = new panelEntities())
            {
                var result = db.SP_BANBIFLEX_VALIDAR_CORREO_PARTICIPANTE(request.Correo).ToList();
                if(result.Count>0)
                {
                    return (int)result[0];
                }
                else
                {
                    return 0; 
                }
               
            }
        }
    }
}
