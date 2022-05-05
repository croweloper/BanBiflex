using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.Reserva
{
    public class ReservasDocumentoResponse
    {
        public bool result { get; set; }
        public List<ReservasDocumentoResult> data { get; set; }
    }
}
