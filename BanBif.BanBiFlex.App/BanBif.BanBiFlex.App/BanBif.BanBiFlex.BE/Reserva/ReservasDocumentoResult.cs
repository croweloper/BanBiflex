using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.Reserva
{
    public class ReservasDocumentoResult
    {
        public int? Id { get; set; }
        public string Fecha { get; set; }
        public int? Piso { get; set; }
        public int? Sitio { get; set; }
        public string Nombre { get; set; }
        public string Placa { get; set; }
        public string Comentario { get; set; }
        public string Tipo { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }

    }
}
