using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.Reserva
{
    public class ReservaRequest
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha{ get; set; }
        public int EspacioTrabajoId { get; set; }
        public int EstacionamientoId { get; set; }
        public string Placa { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaIngreso1 { get; set; }
        public DateTime FechaIngreso2 { get; set; }
        public DateTime FechaIngreso3 { get; set; }
        public DateTime FechaIngreso4 { get; set; }
        public DateTime FechaIngreso5 { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

    }
}
