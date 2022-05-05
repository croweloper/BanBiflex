using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.Reserva
{
    public class MisReservasResult
    {
        public int? Id { get; set; } 
        public string Fecha { get; set; }
        public int? Piso { get; set; }
        public int? Sitio { get; set; }
        public int? Estacionamiento { get; set; }
        public string Placa { get; set; }
        public string Comentario { get; set; }
        public string Estado { get; set; }
    }
}
