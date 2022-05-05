using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.Reserva
{
    public class ActualizarEstadoReservaRequest
    {
        public int IdReserva { get; set; }
        public string Estado { get; set; }
    }
}
